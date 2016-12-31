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
        Dim usrName, usrRole As String
        Dim i, maxRows As Integer
        usrRole = ""
        usrName = frmLogin.txtUsername.Text
        maxRows = dsClimsoftUserRoles.Tables("userRoles").Rows.Count

        Try
            'Get the role for the logged in user from the climsoftusers table
            If maxRows > 0 Then
                For i = 0 To maxRows - 1
                    If dsClimsoftUserRoles.Tables("userRoles").Rows(i).Item("userName") = usrName Then
                        usrRole = dsClimsoftUserRoles.Tables("userRoles").Rows(i).Item("userRole")
                        userGroup = usrRole
                    End If
                Next i
                'Disable controls that do not correspond to the user role
                If usrRole = "ClimsoftOperator" Or usrRole = "ClimsoftOperatorSupervisor" Or usrRole = "ClimsoftRainfall" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuLanguageTranslation.Enabled = False
                    mnuQC.Enabled = False
                    mnuProducts.Enabled = False
                    cmdDataTransfer.Enabled = False
                    cmdSettingsAWS.Enabled = False
                    cmdUserManagement.Enabled = False
                    cmdQC.Enabled = False
                    cmdProducts.Enabled = False
                    cmdMetadata.Enabled = False
                    '
                ElseIf usrRole = "ClimsoftQC" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuLanguageTranslation.Enabled = False
                    mnuProducts.Enabled = False
                    cmdDataTransfer.Enabled = False
                    cmdSettingsAWS.Enabled = False
                    cmdUserManagement.Enabled = False
                    cmdProducts.Enabled = False
                    cmdUserManagement.Enabled = False
                    '
                ElseIf usrRole = "ClimsoftMetadata" Then
                    mnuProducts.Enabled = False
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    mnuLanguageTranslation.Enabled = False
                    cmdDataTransfer.Enabled = False
                    cmdSettingsAWS.Enabled = False
                    cmdUserManagement.Enabled = False
                    cmdQC.Enabled = False
                    cmdProducts.Enabled = False
                    cmdKeyEntry.Enabled = False
                ElseIf usrRole = "ClimsoftProducts" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    mnuLanguageTranslation.Enabled = False
                    mnuProducts.Enabled = False
                    cmdDataTransfer.Enabled = False
                    cmdSettingsAWS.Enabled = False
                    cmdUserManagement.Enabled = False
                    cmdQC.Enabled = False
                    cmdKeyEntry.Enabled = False
                ElseIf usrRole = "ClimsoftTranslator" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    mnuProducts.Enabled = False
                    cmdDataTransfer.Enabled = False
                    cmdSettingsAWS.Enabled = False
                    cmdUserManagement.Enabled = False
                    cmdQC.Enabled = False
                    cmdKeyEntry.Enabled = False
                    cmdPaperArchive.Enabled = False
                    cmdProducts.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        autoTranslate(Me)
        HTMLHelp.HelpPage = "welcome.htm"

    End Sub


    Private Sub cmdKeyEntry_Click(sender As Object, e As EventArgs) Handles cmdKeyEntry.Click
        ' The icon has been changed
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
        'frmUsers.Show()
        frmUserManagement.Show()
    End Sub

    Private Sub cmdMetadata_Click(sender As Object, e As EventArgs) Handles cmdMetadata.Click
        'frmLaunchPad.ShowDialog()
        formMetadata.Show()
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
        formPaperArchive.Show()
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
    Private Sub mnuToolsOptions_Click(sender As Object, e As EventArgs)
        formOptions.Show()
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
        'HTMLHelp.HelpPage = "aboutclimsoft4.htm"
        Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)

    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click

    End Sub

    Private Sub cmdKeyEntry_DoubleClick(sender As Object, e As EventArgs) Handles cmdKeyEntry.DoubleClick

    End Sub

    Private Sub DataFormsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataFormsToolStripMenuItem.Click
        frmDataForms.Show()
    End Sub

    Private Sub GenerlSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerlSettingsToolStripMenuItem.Click
        frmGeneralSettings.Show()
    End Sub

    Private Sub SequencerConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SequencerConfigurationToolStripMenuItem.Click

    End Sub

    Private Sub DailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyToolStripMenuItem.Click
        frmElementSequencerHourly.Show()

    End Sub

    Private Sub FormHourlyTimeSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormHourlyTimeSelectionToolStripMenuItem.Click
        frmHourlyTimeSelection.Show()
    End Sub

    Private Sub HourlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HourlyToolStripMenuItem.Click
        frmElementSequencerDaily.Show()

    End Sub

    Private Sub LanguageTranslationToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmLanguageTranslation.Show()
    End Sub

    Private Sub PasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordToolStripMenuItem.Click
        frmChangePassword.Show()
    End Sub

    Private Sub ChangeOwnPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeOwnPasswordToolStripMenuItem.Click
        frmChangeOwnPassword.Show()
    End Sub

    Private Sub ConfigureDatabaseConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigureDatabaseConnectionToolStripMenuItem.Click
        frmLogin.Server_db_port(frmLogin.cmbDatabases.Text)
    End Sub

    Private Sub mnuTools_Click(sender As Object, e As EventArgs) Handles mnuTools.Click

    End Sub

    
    Private Sub mnuLanguageTranslation_Click(sender As Object, e As EventArgs) Handles mnuLanguageTranslation.Click
        frmLanguageTranslation.Show()
    End Sub

    Private Sub UserAdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserAdminToolStripMenuItem.Click
        frmUserManagement.Show()
    End Sub

    Private Sub AWSElementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AWSElementsToolStripMenuItem.Click
        frmAWSelements.Show()
    End Sub

    Private Sub AWSStationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AWSStationsToolStripMenuItem.Click
        frmAWSstations.Show()
    End Sub
End Class
