'---------------------------------------------------------------------------------------------------
' file:		clsGlobalVariables.vb
'
' summary:	GlobalVariables class
'---------------------------------------------------------------------------------------------------

'''////////////////////////////////////////////////////////////////////////////////////////////////////
''' <summary>   Global Variables. </summary>
'''////////////////////////////////////////////////////////////////////////////////////////////////////

Public Class GlobalVariables

    ''' <summary>
    ''' A string, how the "version number" column is stored in the database in all tables it appears in.
    ''' </summary>
    Public Shared ReadOnly strVersionNumber As String = "version_number"

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Values that represent update types. </summary>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////

    Public Enum UpdateType
        ''' <summary>   An enum constant representing the new record option. When a new record is added. </summary>
        NewRecord
        ''' <summary>   An enum constant representing the correction old option. When a correction is made to an existing record, this is the existing version. </summary>
        CorrectionOld
        ''' <summary>   An enum constant representing the correction option. When a correction is made to an existing record, this is the new version. </summary>
        CorrectionNew
        ''' <summary>   An enum constant representing the event change option. When a change is made to an event that is not a correction e.g. another event is added before this resulting in a change to its current. </summary>
        EventChange
        ''' <summary>   An enum constant representing the event new option. When a new value is added to an existing record corresponding to a new event. </summary>
        EventNew
        ''' <summary>   An enum constant representing the delete option. When a record is deleted. </summary>
        Delete
    End Enum

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Gets the dtb empty audit table. </summary>
    '''
    ''' <value> The dtb empty audit table. </value>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////

    Public Shared ReadOnly Property dtbEmptyAuditTable As DataTable
        Get
            Dim dtbAudit As New DataTable

            dtbAudit.Columns.Add("id", GetType(Integer))
            dtbAudit.Columns.Add("action_id", GetType(Integer))
            dtbAudit.Columns.Add("table", GetType(String))
            dtbAudit.Columns.Add("entry_id", GetType(Integer))
            dtbAudit.Columns.Add("version_old", GetType(Integer))
            dtbAudit.Columns.Add("version_new", GetType(Integer))
            Return dtbAudit
        End Get
    End Property

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Adds to audit table. </summary>
    '''
    ''' <param name="dtbAudit">     The dtb audit. </param>
    ''' <param name="strTable">     The table. </param>
    ''' <param name="iEntryId">     Identifier for the entry. </param>
    ''' <param name="iVersionOld">  Zero-based index of the version old. </param>
    ''' <param name="iVersionNew">  Zero-based index of the version new. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Shared Sub AddToAuditTable(dtbAudit As DataTable, iActionID As Integer, strTable As String, iEntryId As Integer, iVersionOld As Nullable(Of Integer), iVersionNew As Nullable(Of Integer))
        Dim dtbAuditSchema As DataTable
        Dim objParams As New List(Of Object)

        dtbAuditSchema = dtbEmptyAuditTable
        If dtbAudit.Columns.Count <> dtbAuditSchema.Columns.Count Then
            MsgBox("Developer error in GlobalVariables.AddToAuditTable: Cannot add records to audit table. Audit table provided does not match audit table schema (incorrect number of columns).", MsgBoxStyle.Information, Title:="Developer error")
            Exit Sub
        End If
        For i As Integer = 0 To dtbAudit.Columns.Count - 1
            If dtbAudit.Columns(i).ColumnName <> dtbAuditSchema.Columns(i).ColumnName OrElse dtbAudit.Columns(i).DataType <> dtbAuditSchema.Columns(i).DataType Then
                MsgBox("Developer error in GlobalVariables.AddToAuditTable: Cannot add records to audit table. Audit table provided does not match audit table schema (incorrect column name/type).", MsgBoxStyle.Information, Title:="Developer error")
                Exit Sub
            End If
        Next
        ' id can be blank since it is unique and can be set to auto increment in the database
        objParams.Add(DBNull.Value)
        objParams.Add(iActionId)
        objParams.Add(strTable)
        objParams.Add(iEntryId)
        objParams.Add(If(iVersionOld Is Nothing, DBNull.Value, iVersionOld))
        objParams.Add(If(iVersionNew Is Nothing, DBNull.Value, iVersionNew))
        dtbAudit.Rows.Add(objParams.ToArray)
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Constructs an SQL query to get only the current versions from a table. 
    ''' Could be moved to a separate class for query construction
    ''' </summary>
    '''
    ''' <param name="strTable"> A string, the name of the table to query. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
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

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Constructs an SQL query to get only the versions equal to <c>iVersion</c> from a table.
    ''' (Could be moved to a separate class for query construction)
    ''' </summary>
    '''
    ''' <param name="strTable"> A string, the name of the table to query. </param>
    ''' <param name="iVersion"> An integer, the version numbers to extract for each id. </param>
    '''
    ''' <returns> An SQL query string. </returns>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Function GetVersionNumberQuery(strTable As String, iVersion As Integer) As String

    End Function

End Class