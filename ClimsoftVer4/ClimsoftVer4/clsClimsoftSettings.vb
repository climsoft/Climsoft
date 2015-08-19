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


Public Class Translations
    Public Shared Function translate(tag As String) As String
        ' Note: if the tag is not found in Resources then Nothing will be returned
        Return My.Resources.ResourceManager.GetObject(tag)
    End Function

    Public Shared Sub translateEach(controls As Control.ControlCollection)
        ' Given a ControlCollection, attempt to translate the Text property of each control
        Dim formControl As Control
        Dim originalTag As String
        Dim translatedString As String

        For Each formControl In controls
            If (TypeOf formControl Is Panel) Then
                ' Recursively translate all controls inside the panel
                translateEach(formControl.Controls)
            ElseIf (TypeOf formControl Is MenuStrip) Then
                ' Translate all MenuItems inside the MenuStrip
                translateMenu(formControl)
            ElseIf (TypeOf formControl Is TextBox OrElse TypeOf formControl Is Button OrElse TypeOf formControl Is Label) Then
                originalTag = formControl.Tag
                If (originalTag IsNot Nothing) Then
                    translatedString = My.Resources.ResourceManager.GetObject(originalTag)
                    If (translatedString IsNot Nothing) Then
                        formControl.Text = translatedString
                    End If
                End If
            End If
        Next formControl
    End Sub

    Public Shared Sub autoTranslate(frm As Form)
        Dim translatedString As String

        ' Attempt to translate the form's title if it has a tag
        If frm.Tag IsNot Nothing Then
            translatedString = My.Resources.ResourceManager.GetObject(frm.Tag)
            If (translatedString IsNot Nothing) Then
                frm.Text = translatedString
            End If
        End If
        ' Translate all controls in object
        translateEach(frm.Controls)
    End Sub

    ' translateMenu and translateSubMenu should not be neccessary if we can improve translateEach to accept any iterable
    Public Shared Sub translateMenu(menuControl As MenuStrip)
        Dim item As ToolStripMenuItem
        Dim originalTag As String
        Dim translatedString As String

        For Each item In menuControl.Items
            ' process this item, then recursively process any sub items
            If item.HasDropDownItems Then
                translateSubMenu(item.DropDownItems)
            End If
            originalTag = item.Tag
            If (originalTag IsNot Nothing) Then
                translatedString = My.Resources.ResourceManager.GetObject(originalTag)
                If (translatedString IsNot Nothing) Then
                    item.Text = translatedString
                End If
            End If
        Next item
    End Sub

    ' translateMenu and translateSubMenu should not be neccessary if we can improve translateEach to accept any iterable
    Public Shared Sub translateSubMenu(subMenuControl As ToolStripItemCollection)
        Dim item As ToolStripMenuItem
        Dim originalTag As String
        Dim translatedString As String

        For Each item In subMenuControl
            ' process this item, then recursively process any sub items
            originalTag = item.Tag
            If (originalTag IsNot Nothing) Then
                translatedString = My.Resources.ResourceManager.GetObject(originalTag)
                If (translatedString IsNot Nothing) Then
                    item.Text = translatedString
                End If
            End If
        Next item
    End Sub

End Class

Public Class clsClimsoftSettings
    ' Each running instance of CLIMSOFT will have a single instance of clsClimsoftSettings
    Dim rPath As String
    Dim systemPath As String = System.Environment.GetEnvironmentVariable("PATH")
    Dim R_HOME As String = "C:\Program Files\R\R-3.2.1"  ' Default location of R home directory (only used if R_HOME environment variable is not set)

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
