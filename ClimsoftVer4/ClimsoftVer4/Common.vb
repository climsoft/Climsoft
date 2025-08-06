Imports Microsoft.Win32
Imports MySql.Data.MySqlClient
Module CommonModules

    Function ViewFile(flname As String) As Boolean
        Try
            ViewFile = True
            System.Diagnostics.Process.Start(flname)
        Catch ex As Exception
            ViewFile = False
        End Try
    End Function
    Function GetWRplotPath(ByRef WRplotPath As String) As Boolean
        On Error GoTo errhandler
        Dim objRegKey As RegistryKey
        Dim KeyStringW32, KeyStringW64 As String

        GetWRplotPath = True
        'Try
        KeyStringW32 = "SOFTWARE\Lakes Environmental Software\WRPlot View"
        KeyStringW64 = "SOFTWARE\Wow6432Node\Lakes Environmental Software\WRPlot View"

        objRegKey = Registry.LocalMachine.OpenSubKey(KeyStringW32)
        If Len(objRegKey.Name) = 0 Then
            objRegKey = Registry.LocalMachine.OpenSubKey(KeyStringW64)
        End If

        WRplotPath = objRegKey.GetValue("Install_Folder")

        If WRplotPath = "" Then GetWRplotPath = False

        'Catch ex As Exception

        Exit Function
errhandler:
        If Err.Number = 91 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)
        GetWRplotPath = False
        'End Try

    End Function

    Function Load_Files(flname As String, tblname As String, skplines As Integer, fldsep As String, Optional fldquotechar As String = "") As Boolean
        Dim lconn As New MySql.Data.MySqlClient.MySqlConnection
        ' Dim cmd As MySqlConnector.MySqlCommand
        Dim fl As MySql.Data.MySqlClient.MySqlBulkLoader
        ' Dim rws As Long
        lconn.ConnectionString = frmLogin.txtusrpwd.Text & ";AllowLoadLocalInfile=true"

        Try
            lconn.Open()
            fl = New MySql.Data.MySqlClient.MySqlBulkLoader(lconn)

            fl.FileName = flname
            fl.TableName = tblname
            fl.EscapeCharacter = "UTFB"
            fl.NumberOfLinesToSkip = skplines
            fl.FieldTerminator = fldsep
            fl.FieldQuotationCharacter = fldquotechar
            'fl.FieldQuotationOptional ='True',
            fl.Local = True

            fl.Load()
            lconn.Close()
            Return True
        Catch ex As Exception
            lconn.Close()
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

End Module
