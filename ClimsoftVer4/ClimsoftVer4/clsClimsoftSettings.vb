' CLIMSOFT - Climate Database Management System
' Copyright (C) 2015
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.
Imports System.IO


Public Class clsClimsoftSettings
    ' Each running instance of CLIMSOFT will have a single instance of clsClimsoftSettings
    Dim rPath As String
    Dim systemPath As String = System.Environment.GetEnvironmentVariable("PATH")
    ' Default location of R home directory (only used if R_HOME environment variable is not set)
    Dim R_HOME As String = My.Settings.defaultRLocation

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
