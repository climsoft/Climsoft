Module CommonModules
    Function ViewFile(flname As String) As Boolean
        Try
            ViewFile = True
            System.Diagnostics.Process.Start(flname)
        Catch ex As Exception
            ViewFile = False
        End Try
    End Function
End Module
