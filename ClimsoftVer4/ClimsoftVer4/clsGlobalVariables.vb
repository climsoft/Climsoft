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
    ''' This could be moved to a separate class of constants.
    ''' </summary>
    Public Shared ReadOnly strVersionNumber As String = "version_number"

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Values that represent update types. </summary>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////

    Public Enum UpdateType
        ''' <summary>   An enum constant representing the new record option. When a new record is added. </summary>
        NewRecord
        ''' <summary>   An enum constant representing the correction option. When a correction is made to an existing record. </summary>
        Correction
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
    ''' <remarks>   Danny, 12/03/2020. </remarks>
    '''
    ''' <param name="dtbAudit">     The dtb audit. </param>
    ''' <param name="iActionId">    Identifier for the action. </param>
    ''' <param name="strTable">     The table. </param>
    ''' <param name="iEntryId">     Identifier for the entry. </param>
    ''' <param name="iVersionOld">  Zero-based index of the version old. </param>
    ''' <param name="iVersionNew">  Zero-based index of the version new. </param>
    ''' <param name="iId">          (Optional) Zero-based index of the identifier. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////

    Public Shared Sub AddToAuditTable(dtbAudit As DataTable, iActionId As Integer, strTable As String, iEntryId As Integer, iVersionOld As Nullable(Of Integer), iVersionNew As Nullable(Of Integer), Optional iId As Nullable(Of Integer) = Nothing)
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
        objParams.Add(If(iId Is Nothing, DBNull.Value, iId))
        objParams.Add(iActionId)
        objParams.Add(strTable)
        objParams.Add(iEntryId)
        objParams.Add(If(iVersionOld Is Nothing, DBNull.Value, iVersionOld))
        objParams.Add(If(iVersionNew Is Nothing, DBNull.Value, iVersionNew))
        dtbAudit.Rows.Add(objParams.ToArray)
    End Sub
End Class