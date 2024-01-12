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

Public Class clsLanguageTranslation

    Public Function translateText(textValue As String) As String
        'Code for language translation based on translation stored in table [language_translation] in Climsoft database.
        'This is a proposed alternative to the option of using the Multilanguage tool provided by Microsoft which uses "Resource" files.
        'This translation routine has been tested successfully for the form [frmImportCSV]. If discussed and accepted 
        'then this translation approach shall be applied throughout the project. 
        'The "Tag" value of the control (or object in the case of the parent form) is used to locate the record with the translation
        'in the [language_translation] table. In the case of a message, the variable name for the message shall be used instead of the "Tag".
        '
        'The major advantage of using a translation table in the database is that it will be easier to do the translation using a form or
        ' a data grid or even doing the translation in a spreadsheet and then upload the data into the form.

        '--------  20160206, ASM -----------------.

        Dim lanCulture As String, i As Integer, maxRows As Integer, cultureText As String
        lanCulture = System.Globalization.CultureInfo.CurrentCulture.Name
        ' "lanCulture" gives the current language that is set in the Regional Settings of the OS Control Panel
        maxRows = dsLanguageTable.Tables("languageTranslation").Rows.Count

        cultureText = ""

        For i = 0 To maxRows - 1
            If dsLanguageTable.Tables("languageTranslation").Rows(i).Item("tagID") = textValue Then
                If Strings.Left(lanCulture, 2) = "en" Then
                    cultureText = dsLanguageTable.Tables("languageTranslation").Rows(i).Item("en")
                ElseIf Strings.Left(lanCulture, 2) = "fr" Then
                    cultureText = dsLanguageTable.Tables("languageTranslation").Rows(i).Item("fr")
                ElseIf Strings.Left(lanCulture, 2) = "de" Then
                    cultureText = dsLanguageTable.Tables("languageTranslation").Rows(i).Item("de")
                ElseIf Strings.Left(lanCulture, 2) = "pt" Then
                    cultureText = dsLanguageTable.Tables("languageTranslation").Rows(i).Item("pt")
                Else
                    cultureText = dsLanguageTable.Tables("languageTranslation").Rows(i).Item("en")
                End If
            End If
        Next i

        translateText = cultureText

    End Function
End Class
