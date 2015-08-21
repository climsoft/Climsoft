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
Imports ClimsoftVer4.Translations


Public Class frmMainMenu

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        HTMLHelp.HelpPage = "welcome.htm"
    End Sub

    ' Methods for icons in main panel.

    Private Sub cmdKeyEntry_Click(sender As Object, e As EventArgs) Handles cmdKeyEntry.Click
        frmKeyEntry.ShowDialog()
    End Sub

    Private Sub cmdPaperArchive_Click(sender As Object, e As EventArgs) Handles cmdPaperArchive.Click
        formPaperArchive.Show()
    End Sub

    Private Sub cmdDataTransfer_Click(sender As Object, e As EventArgs) Handles cmdDataTransfer.Click
        frmDBUtilities.ShowDialog()
    End Sub

    Private Sub cmdQC_Click(sender As Object, e As EventArgs) Handles cmdQC.Click
        frmQC.ShowDialog()
    End Sub

    Private Sub cmdProducts_Click(sender As Object, e As EventArgs) Handles cmdProducts.Click
        frmProducts.ShowDialog()
    End Sub

    Private Sub cmdUserManagement_Click(sender As Object, e As EventArgs) Handles cmdUserManagement.Click
        frmUsers.Show()
    End Sub

    Private Sub cmdMetadata_Click(sender As Object, e As EventArgs) Handles cmdMetadata.Click
        frmLaunchPad.ShowDialog()
    End Sub

    Private Sub cmdSettingsAWS_Click(sender As Object, e As EventArgs) Handles cmdSettingsAWS.Click
        formAWSRealTime.Show()
    End Sub

    Private Sub cmdRedCloseButton_Click(sender As Object, e As EventArgs) Handles cmdRedCloseButton.Click
        End
    End Sub


    ' Methods for menu items.

    ' Input Menu items
    Private Sub mnuInputKeyEntry_Click(sender As Object, e As EventArgs) Handles mnuInputKeyEntry.Click
        frmKeyEntry.ShowDialog()
    End Sub

    Private Sub mnuInputPaperArchive_Click(sender As Object, e As EventArgs) Handles mnuInputPaperArchive.Click

    End Sub

    ' Accessories Menu items
    Private Sub mnuAccessoriesDewPointRH_Click(sender As Object, e As EventArgs) Handles mnuAccessoriesDewPointRH.Click

    End Sub

    Private Sub mnuAccessoriesXMLOutput_Click(sender As Object, e As EventArgs) Handles mnuAccessoriesXMLOutput.Click

    End Sub

    ' QC Menu items
    Private Sub mnuQC_Click(sender As Object, e As EventArgs) Handles mnuQC.Click
        frmQC.ShowDialog()
    End Sub

    ' Products menu items
    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuProducts.Click
        frmProducts.ShowDialog()
    End Sub

    ' Administration Menu items
    ' (currently not implemeted)

    ' Tools Menu Items
    Private Sub mnuToolsOptions_Click(sender As Object, e As EventArgs) Handles mnuToolsOptions.Click

    End Sub

    Private Sub mnuToolsModifyForms_Click(sender As Object, e As EventArgs) Handles mnuToolsModifyForms.Click

    End Sub

    Private Sub SelectLanguageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectLanguageToolStripMenuItem.Click
        frmLanguage.ShowDialog()
        ' When dialog is closed - update language in this window (will any other windows also be open?)
        autoTranslate(Me)
    End Sub

    ' Help Menu Items
    Private Sub mnuHelpContents_Click(sender As Object, e As EventArgs) Handles mnuHelpContents.Click
        Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click

    End Sub

End Class
