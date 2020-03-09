''' <summary>
''' </summary>
''' <remarks>
''' The <c>DataStructure</c> will keep data in the same structure/table as in the database.
''' </remarks>
Public Class DataStructure
    ' TODO
    ' 1. Do we allow choice of fields to get? If writing then all fields needed,
    '    but reading only may not need all fields.
    '    Most tables have few fields so might not be needed.
    ' 2. Where should SQL statement construction functions live?

    ''' <summary>
    ''' A string, the name of the table in the database this DataStructure links.
    ''' </summary>
    Private strTableName As String

    ''' <summary>
    ''' A string, how the "id" column is stored in the database in all tables it appears in.
    ''' This could be moved to a separate class of constants.
    ''' </summary>
    Private strId As String = "id"

    ''' <summary>
    ''' A string, how the "version number" column is stored in the database in all tables it appears in.
    ''' This could be moved to a separate class of constants.
    ''' </summary>
    Private strVersionNumber As String = "version_number"

    ''' <summary>
    ''' A string, how the "current/current best" column is stored in <c>strTableName</c>.
    ''' This is "current_best" by default and can either be "current" or "current_best".
    ''' </summary>
    Private strCurrent As String = "current_best"

    ''' <summary>
    ''' A list of strings, the names of the fields in <c>strTableName</c> which uniquely define a row.
    ''' In most tables and by default this is <c>{strId, strVersionNumber}</c> but it is not in all and can be changed.
    ''' </summary>
    Private lstKeyFieldNames As List(Of String) = New List(Of String)({strId, strVersionNumber})

    ''' <summary>
    ''' A <c>DataTable</c> storing the data read from the database.
    ''' This remains static once fetched from the database.
    ''' </summary>
    Private dtbReadTable As DataTable

    ''' <summary>
    ''' A <c>DataTable</c> storing the new data to be written to the database. 
    ''' This builds up as controls change.
    ''' </summary>
    Private dtbWriteTable As DataTable

    ''' <summary>
    ''' A <c>DataTable</c> storing new comments associated to <c>strTableName</c>. 
    ''' </summary>
    Private dtbComments As DataTable

    ''' <summary>
    ''' A <c>DataTable</c> storing new events associated to <c>strTableName</c>. 
    ''' </summary>
    Private dtbEvents As DataTable

    ''' <summary>
    ''' A list of linked <c>DataStructure</c>s that relate to required linked tables in the database.
    ''' </summary>
    ''' <remarks>
    ''' This will included <c>DataStructure</c>s for existing comments and events associated to <c>strTableName</c>.
    ''' </remarks>
    Private lstLinkedDataStructures As List(Of DataStructure)

    ''' <summary>
    ''' This event is raised when <c>dtbReadTable</c> changes.
    ''' The navigator and page control will listen for this and update their values when this event is raised.
    ''' </summary>
    Public Event DataChanged()

    ''' <summary>
    ''' Set the name of the table in the database this DataStructure links to.
    ''' </summary>
    ''' <param name="strNewTableName">A string, the name of the table in the database.</param>
    Public Sub SetTableName(strNewTableName As String)
        strTableName = strNewTableName
    End Sub

    ''' <summary>
    ''' Set the names of the fields in <c>strTableName</c> which uniquely define a row.
    ''' This is needed when updating records.
    ''' In most tables and by default this is <c>{strId, strVersionNumber}</c>.
    ''' This method should only be used if it is different to the default.
    ''' </summary>
    Public Sub SetKeyFields(iEnumerableNewKeyFields As IEnumerable(Of String))
        lstKeyFieldNames = iEnumerableNewKeyFields.ToList()
    End Sub

    ''' <summary>
    ''' Initialises <c>dtbWriteTable</c> as a clone of <c>dtbReadTable</c>.
    ''' This should be called once <c>dtbReadTable</c> has been set.
    ''' </summary>
    ''' <remarks>
    ''' <c>.Clone</c> copies the structure but not the data of a <c>DataTable</c>.
    ''' </remarks>
    Private Sub InitialiseWriteTable()
        If dtbReadTable IsNot Nothing Then
            dtbWriteTable = dtbReadTable.Clone()
        End If
    End Sub

    ''' <summary>
    ''' Gets the comments associated with <c>strTableName</c> and stores them in <c>dtbComments</c>.
    ''' This may be called when getting the main data, or may only be called on demand.
    ''' </summary>
    ''' <param name="bAllVersions">Boolean, if  <c>True</c> all versions returned, if <c>False</c> only the current comment for each id is returned.</param>
    Private Sub SetCommentsTable(Optional bAllVersions As Boolean = False)
        ' SQL command, all versions:
        ' SELECT * FROM c5_comments WHERE table_id=@strTableName

        ' From here: https://stackoverflow.com/questions/612231/how-can-i-select-rows-with-maxcolumn-value-distinct-by-another-column-in-sql
        ' SQL command, current only:
        ' Select Case m.* From c5_comment m
        ' INNER Join(SELECT id, MAX(current) As max_current FROM c5_comment GROUP BY id) m_group
        ' ON m.id=m_group.id
        ' AND m.current=m_group.max_current AND m.table_id=@strTableName

        ' alternative.......

        ' SELECT m.*
        ' FROM c5_comment m
        ' LEFT JOIN c5_comment b
        ' ON m.id = b.id
        ' AND m.current < b.current
        ' WHERE b.current Is NULL AND m.table_id=@strTableName
    End Sub

    ''' <summary>
    ''' Gets the events associated with <c>strTableName</c> and stores them in <c>dtbEvents</c>.
    ''' This may be called when getting the main data, or may only be called on demand.
    ''' </summary>
    Private Sub SetEventsTable()
        ' SQL command, current only:
        ' 
        ' SELECT * FROM (SELECT m.*
        ' 					FROM c5_event_effect m
        '     					LEFT JOIN c5_event_effect b
        '        					ON m.id = b.id
        '        					AND m.current < b.current
        '							WHERE b.current IS NULL AND m.table_id=@strTableName) e_e
        ' INNER JOIN (SELECT m.*
        '				FROM c5_event m
        '    				LEFT JOIN c5_event b
        '        				ON m.id = b.id
        '        				AND m.current < b.current
        '						WHERE b.current IS NULL) e
        ' ON e_e.event_id=e.id
    End Sub

    ''' <summary>
    ''' Constructs an SQL query to get only the current versions from a table.
    ''' (Could be moved to a separate class for query construction)
    ''' </summary>
    ''' <param name="strTable">A string, the name of the table to query.</param>
    ''' <returns></returns>
    Private Function GetCurrentVersionsQuery(strTable As String) As String
        ' From here: https://stackoverflow.com/questions/612231/how-can-i-select-rows-with-maxcolumn-value-distinct-by-another-column-in-sql

        ' Option 1:
        ' #########
        ' Select Case m.* From @strTable m
        ' INNER Join(SELECT id, MAX(@strCurrent) As max_current FROM @strTable GROUP BY id) m_group
        ' ON m.id=m_group.id
        ' AND m.@strCurrent=m_group.max_current

        ' Option 2:
        ' #########
        ' SELECT m.*
        ' FROM @strTable m
        ' LEFT JOIN @strTable b
        ' ON m.id = b.id
        ' AND m.@strCurrent < b.@strCurrent
        ' WHERE b.@strCurrent Is NULL
    End Function

    ''' <summary>
    ''' Constructs an SQL query to get only the versions equal to <c>iVersion</c> from a table.
    ''' (Could be moved to a separate class for query construction)
    ''' </summary>
    ''' <param name="strTable">A string, the name of the table to query.</param>
    ''' <param name="iVersion">An integer, the version numbers to extract for each id.</param>
    ''' <returns></returns>
    Private Function GetVersionNumberQuery(strTable As String, iVersion As Integer) As String

    End Function

    Private Function NewAction(iActionTypeID As Integer, strOperatorID As String) As Integer
        Dim iActionID As Integer
        ' create new entry in action table using iActionTypeID, strOperatorID and current date-time
        ' get back action ID for new entry created
        Return iActionID
    End Function

    Public Sub DoAction(iActionTypeID As Integer, strOperatorID As String, DataStruct As DataStructure, Optional strActionComment As String = "")
        Dim iActionID As Integer

        ' create new entry in action table using iActionTypeID, strOperatorID and current date-time
        ' get back action ID for new entry created
        iActionID = NewAction(iActionTypeID, strOperatorID)
        ' create comment for action comment and add to comment table

        DataStruct.UpdateTable(iActionTypeID)
    End Sub

    Public Sub UpdateTable(iActionID As Integer)
        ' produce table from the read and write table that will corresponds to the 'add's and 'update's of that table
        ' STEPS
        ' 1. Make the update table as a Clone() of the read table
        ' 2. Make a blank audit table to add entries to
        ' 3. Loop through the write table and:
        '    a) read the update type from the write table
        '    b) add a row for each row to the update table, (unless update type = delete)
        '    c) add a row for an edit to the read table if neccessary
        '    d) produce the audit record to be added to the audit write table
        ' 4. Write: update table, audit table, comments table, events table
        ' 5. Call UpdateTable for each lstLinkedDataStructures
    End Sub


    ' Need function which takes these two tables and generates the 'add' and 'update' tables/commands
    ' When adding, only need to update current field of existing records

    ' produce table from the read and write table that will corresponds to the 'add's and 'update's of that table
    ' produce the audit records to be added

    ''' <summary>
    ''' Takes <c>dtbReadTable</c> and <c>dtbWriteTable</c> and produces a <c>DataTable</c> with the correct updates and inserts to be added to the database.
    ''' </summary>
    ''' <returns>A <c>DataTable</c> with </returns>
    Private Function GenerateTableForUpdate() As DataTable

    End Function

    ' UpdateData() adds, updates and deletes data

End Class
