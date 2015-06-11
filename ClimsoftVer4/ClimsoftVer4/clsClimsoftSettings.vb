Imports System.IO


Public Class clsClimsoftSettings
    ' Each running instance of CLIMSOFT will have a single instance of clsClimsoftSettings
    Dim rPath As String
    Dim systemPath As String = System.Environment.GetEnvironmentVariable("PATH")
    Dim R_HOME As String = "C:\Program Files\R\R-3.2.0"  ' Default location of R home directory (only used if R_HOME environment variable is not set)


    Sub rEnvironmentSetUp()
        ' Setup system environment variables.
        If String.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("R_HOME")) Then
            ' The R_HOME system environment variable is not set, therefore set it here
            System.Environment.SetEnvironmentVariable("R_HOME", R_HOME)
        Else
            ' R_HOME is already set, therefore update our default
            R_HOME = System.Environment.GetEnvironmentVariable("R_HOME")
        End If
        ' Add the correct version of R to the system path
        Dim rPath = If(System.Environment.Is64BitProcess, Path.Combine(R_HOME, "bin\x64"), Path.Combine(R_HOME, "bin\i386\"))
        If Directory.Exists(rPath) = False Then
            Throw New DirectoryNotFoundException(String.Format("Could not find the specified path to the directory containing your R installation (R.dll): {0}", rPath))
        End If
        ' Update system path
        systemPath = String.Format("{0}{1}{2}", rPath, System.IO.Path.PathSeparator, systemPath)
        System.Environment.SetEnvironmentVariable("PATH", systemPath)
    End Sub

End Class
