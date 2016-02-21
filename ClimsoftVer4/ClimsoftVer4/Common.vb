Imports Microsoft.Win32
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

    '    Public Function RegValue(ByVal Hive As RegistryHive, ByVal Key As String, ByVal ValueName As String, Optional ErrInfo As String = "") As String

    '        'DEMO USAGE

    '        'Dim sAns As String
    '        'Dim sErr As String = ""

    '        'sAns = RegValue(RegistryHive.LocalMachine, _
    '        '  "SOFTWARE\Microsoft\Windows\CurrentVersion", _
    '        '  "ProgramFilesDir", sErr)
    '        'If sAns <> "" Then
    '        '    Debug.WriteLine("Value = " & sAns)
    '        'Else
    '        '    Debug.WriteLine("This error occurred: " & sErr)

    '        'End If

    '        Dim objParent As RegistryKey
    '        Dim objSubkey As RegistryKey
    '        Dim sAns As String

    '        Select Case Hive
    '            Case RegistryHive.ClassesRoot
    '                objParent = Registry.ClassesRoot
    '            Case RegistryHive.CurrentConfig
    '                objParent = Registry.CurrentConfig
    '            Case RegistryHive.CurrentUser
    '                objParent = Registry.CurrentUser
    '                'Case RegistryHive.DynData
    '                '    objParent = Registry.DynData
    '            Case RegistryHive.LocalMachine
    '                objParent = Registry.LocalMachine
    '            Case RegistryHive.PerformanceData
    '                objParent = Registry.PerformanceData
    '            Case RegistryHive.Users
    '                objParent = Registry.Users
    '        End Select

    '        Try
    '            objSubkey = objParent.OpenSubKey(Key)
    '            'if can't be found, object is not initialized
    '            If Not objSubkey Is Nothing Then
    '                sAns = (objSubkey.GetValue(ValueName))
    '            End If

    '        Catch ex As Exception

    '            ErrInfo = ex.Message
    '        Finally

    '            'if no error but value is empty, populate errinfo
    '            If ErrInfo = "" And sAns = "" Then
    '                ErrInfo = _
    '                   "No value found for requested registry key"
    '            End If
    '        End Try
    '        Return sAns
    '    End Function
End Module
