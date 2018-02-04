Public Class ClsCommonFunctions
    Public Shared Function GetClonedList(lstValues As List(Of String)) As List(Of String)
        Dim lstClonedValues As New List(Of String)
        If lstValues Is Nothing Then
            Return Nothing
        Else
            lstClonedValues.AddRange(lstValues)
            Return lstClonedValues
        End If

    End Function

    Public Shared Function GetClonedDict(dctValues As Dictionary(Of String, List(Of String))) As Dictionary(Of String, List(Of String))
        Dim dctClonedValues As New Dictionary(Of String, List(Of String))

        If dctValues Is Nothing Then
            Return Nothing
        Else
            For Each kvp In dctValues
                dctClonedValues.Add(kvp.Key, GetClonedList(kvp.Value))

            Next
            'For Each strKey As String In dctValues.Keys
            '    dctClonedValues.Add(strKey, GetClonedList(dctValues(strKey)))
            'Next
            Return dctClonedValues
        End If

    End Function
    'Public Shared Sub CloneList(lstValues As List(Of Object))
    '    Dim lstClonedValues As New List(Of Object)
    '    For Each str As Object In lstValues
    '        lstClonedValues.Add(str.clone())
    '    Next
    'End Sub
End Class
