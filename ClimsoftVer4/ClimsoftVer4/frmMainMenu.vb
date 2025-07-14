' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
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

    Public HTMLHelp As New clsHelp

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrName, usrRole As String
        Dim i, maxRows As Integer
        'Dim usr As Boolean = False
        usrRole = ""

        Try
            usrName = frmLogin.txtUsername.Text
            maxRows = dsClimsoftUserRoles.Tables("userRoles").Rows.Count

            'Get the role for the logged in user from the climsoftusers table
            If maxRows > 0 Then
                For i = 0 To maxRows - 1
                    If dsClimsoftUserRoles.Tables("userRoles").Rows(i).Item("userName") = usrName Then
                        'usr = True
                        usrRole = dsClimsoftUserRoles.Tables("userRoles").Rows(i).Item("userRole")
                        userGroup = usrRole
                    End If
                Next i

                'Disable controls that do not correspond to the user role
                If usrRole = "ClimsoftOperator" Or usrRole = "ClimsoftOperatorSupervisor" Or usrRole = "ClimsoftRainfall" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    mnuProducts.Enabled = False
                    btnMainDataTransfer.Enabled = False
                    btnMainSettingsAWS.Enabled = False
                    btnMainUserManagement.Enabled = False
                    btnMainQC.Enabled = False
                    btnMainProducts.Enabled = False
                    btnMainMetadata.Enabled = False
                    '
                ElseIf usrRole = "ClimsoftQC" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuProducts.Enabled = False
                    btnMainDataTransfer.Enabled = False
                    btnMainSettingsAWS.Enabled = False
                    btnMainUserManagement.Enabled = False
                    btnMainProducts.Enabled = False
                    btnMainUserManagement.Enabled = False

                ElseIf usrRole = "ClimsoftMetadata" Then
                    mnuProducts.Enabled = False
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    btnMainDataTransfer.Enabled = False
                    btnMainSettingsAWS.Enabled = False
                    btnMainUserManagement.Enabled = False
                    btnMainQC.Enabled = False
                    btnMainProducts.Enabled = False
                    btnMainDataEntry.Enabled = False
                    btnMainPaperArchive.Enabled = False

                ElseIf usrRole = "ClimsoftProducts" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    mnuProducts.Enabled = False
                    btnMainDataTransfer.Enabled = False
                    btnMainSettingsAWS.Enabled = False
                    btnMainUserManagement.Enabled = False
                    btnMainQC.Enabled = False
                    btnMainDataEntry.Enabled = False
                    btnMainPaperArchive.Enabled = False

                ElseIf usrRole = "ClimsoftTranslator" Then
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    mnuProducts.Enabled = False
                    btnMainDataTransfer.Enabled = False
                    btnMainSettingsAWS.Enabled = False
                    btnMainUserManagement.Enabled = False
                    btnMainQC.Enabled = False
                    btnMainDataEntry.Enabled = False
                    btnMainPaperArchive.Enabled = False
                    btnMainProducts.Enabled = False
                    btnMainMetadata.Enabled = False

                ElseIf usrRole = "ClimsoftInventory" Then
                    mnuInput.Enabled = False
                    mnuAccessoriesXMLOutput.Enabled = False
                    UserRecordsToolStripMenuItem1.Enabled = False
                    MnuInventory.Enabled = True
                    mnuAdministration.Enabled = False
                    mnuTools.Enabled = False
                    mnuQC.Enabled = False
                    mnuProducts.Enabled = False
                    btnMainDataTransfer.Enabled = False
                    btnMainSettingsAWS.Enabled = False
                    btnMainUserManagement.Enabled = False
                    btnMainQC.Enabled = False
                    btnMainDataEntry.Enabled = False
                    btnMainPaperArchive.Enabled = False
                    btnMainProducts.Enabled = False
                    btnMainMetadata.Enabled = False
                    btnMainDataTransfer.Enabled = False
                End If
            End If

            Me.CenterToScreen()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        HTMLHelp.HelpPage = "welcome.htm"

        'autoTranslate(Me)
        ClsTranslations.TranslateForm(Me)

    End Sub


    Private Sub cmdKeyEntry_Click(sender As Object, e As EventArgs) Handles btnMainDataEntry.Click
        ' The icon has been changed
        frmDataEntry.ShowDialog()

    End Sub

    Private Sub cmdPaperArchive_Click(sender As Object, e As EventArgs) Handles btnMainPaperArchive.Click
        formPaperArchive.Show()
    End Sub

    Private Sub cmdDataTransfer_Click(sender As Object, e As EventArgs) Handles btnMainDataTransfer.Click
        frmDBUtilities.ShowDialog()
    End Sub

    Private Sub cmdQC_Click(sender As Object, e As EventArgs) Handles btnMainQC.Click
        frmQC.ShowDialog()
    End Sub

    Private Sub cmdProducts_Click(sender As Object, e As EventArgs) Handles btnMainProducts.Click
        frmProducts.ShowDialog()
    End Sub

    Private Sub cmdUserManagement_Click(sender As Object, e As EventArgs) Handles btnMainUserManagement.Click
        'frmUsers.Show()
        frmUserManagement.Show()
    End Sub

    Private Sub cmdMetadata_Click(sender As Object, e As EventArgs) Handles btnMainMetadata.Click
        'frmLaunchPad.ShowDialog()
        formMetadata.Show()
    End Sub

    Private Sub cmdSettingsAWS_Click(sender As Object, e As EventArgs) Handles btnMainSettingsAWS.Click
        formAWSRealTime.Show()
    End Sub

    Private Sub cmdRedCloseButton_Click(sender As Object, e As EventArgs) Handles btnMainClose.Click
        Me.Close()
    End Sub


    ' Methods for menu items.

    ' Input Menu items
    Private Sub mnuInputKeyEntry_Click(sender As Object, e As EventArgs) Handles mnuInputKeyEntry.Click
        frmDataEntry.ShowDialog()
    End Sub

    Private Sub mnuInputPaperArchive_Click(sender As Object, e As EventArgs) Handles mnuInputPaperArchive.Click
        formPaperArchive.Show()
    End Sub

    ' Accessories Menu items
    Private Sub mnuAccessoriesDewPointRH_Click(sender As Object, e As EventArgs) Handles mnuAccessoriesDewPointRH.Click
        FrmConversionDewPointRh.Show()
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

    Private Sub SelectLanguageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectLanguageToolStripMenuItem.Click
        frmLanguage.ShowDialog()
        'When dialog is closed - update language in this window (will any other windows also be open?)
        ClsTranslations.TranslateForm(Me)
    End Sub

    ' Help Menu Items
    Private Sub mnuHelpContents_Click(sender As Object, e As EventArgs) Handles mnuHelpContents.Click
        'HTMLHelp.HelpPage = "aboutclimsoft4.htm"
        Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
    End Sub

    Private Sub DataFormsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataFormsToolStripMenuItem.Click
        frmDataForms.Show()
    End Sub

    Private Sub GenerlSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerlSettingsToolStripMenuItem.Click
        frmGeneralSettings.Show()
    End Sub

    Private Sub seqHourlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles seqHourlyToolStripMenuItem.Click
        frmElementSequencerHourly.Show()
    End Sub

    Private Sub FormHourlyTimeSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormHourlyTimeSelectionToolStripMenuItem.Click
        frmHourlyTimeSelection.Show()
    End Sub

    Private Sub seqDailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles seqDailyToolStripMenuItem.Click
        frmElementSequencerDaily.Show()
    End Sub

    Private Sub seqHourly2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles seqHourly2ToolStripMenuItem.Click
        frmHourly2Sequencer.Show()
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

    Private Sub mnuTools_Click(sender As Object, e As EventArgs) Handles mnuTools.Click

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

    Private Sub ConfigurationForTDCFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurationForTDCFToolStripMenuItem.Click
        'With frmSynopTDCF
        '    .TabProcessing.SelectedTab = .TabSettings
        '    .TabProcess.Hide()
        '    .Show()
        '    '.TabProcess.Refresh()
        'End With

        frmTDCFindicators.Show()
    End Sub


    Private Sub MetadataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MetadataToolStripMenuItem.Click
        formMetadata.Show()
    End Sub

    Private Sub UpdateObservationsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UpdateObservationsToolStripMenuItem1.Click
        'frmModifyObservations.Show()
        frmObsView.Show()
    End Sub

    Private Sub OpeartionsMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpeartionsMonitoringToolStripMenuItem.Click
        frmMonitoring.Show()
    End Sub

    Private Sub UserRecordsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UserRecordsToolStripMenuItem1.Click
        With frmMonitoring
            .grpPerformance.Enabled = False
            .grpVerify.Enabled = False
            .grpSettings.Enabled = False
            .optAll.Enabled = False
            .cboUser.Enabled = False
            .cboUser.Text = frmLogin.txtUsername.Text
            .optUsers.Enabled = False
            .Show()
        End With

    End Sub

    Private Sub frmMainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        clsDataConnection.closeConnection()
        End
    End Sub

    Private Sub MonthlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles seqMonthlyToolStripMenuItem.Click
        frmElementSequencerMonthly.Show()
    End Sub

    Private Sub EmptyKeyEntryTablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmptyKeyEntryTablesToolStripMenuItem.Click
        frmEntryForms.Show()
    End Sub

    Private Sub CreateModifyKeyEntryFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateModifyKeyEntryFormToolStripMenuItem.Click
        frmCreateEntryForm.Show()
    End Sub

    Private Sub FormSynopticTimeSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormSynopticTimeSelectionToolStripMenuItem.Click
        frmSynopticTimeSelection.Show()
    End Sub

    Private Sub MnuInventory_Click(sender As Object, e As EventArgs) Handles MnuInventory.Click
        With formProductsSelectCriteria
            .Show()
            .lblProductType.Text = "Inventory"
        End With
    End Sub

    Private Sub UpdateScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateScriptToolStripMenuItem1.Click
        'Load_local_Files()
        'Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim sqlFile, sqlText, sqlStatements(), errfl As String
        Dim sqlconn As New MySqlConnector.MySqlConnection
        Dim qry As MySqlConnector.MySqlCommand
        Dim fll As MySqlConnector.MySqlBulkLoader

        Try
            frmImportDaily.dlgOpenImportFile.Filter = "Script File|*.sql"
            frmImportDaily.dlgOpenImportFile.Title = ClsTranslations.GetTranslation("Open Script File")
            frmImportDaily.dlgOpenImportFile.ShowDialog()
            errfl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\errUpgrade.txt"
            FileOpen(111, errfl, OpenMode.Output)
            Me.Cursor = Cursors.WaitCursor
            sqlFile = frmImportDaily.dlgOpenImportFile.FileName
            sqlText = IO.File.ReadAllText(sqlFile)
            sqlStatements = Strings.Split(sqlText, ";")
            'sqlconn.ConnectionString = frmLogin.txtusrpwd.Text & ";AllowLoadLocalInfile=true;SslMode=VerifyCA"
            'sqlconn.ConnectionString = frmLogin.txtusrpwd.Text & ";AllowLoadLocalInfile=true"
            sqlconn.ConnectionString = frmLogin.txtusrpwd.Text
            'MsgBox(sqlconn.ConnectionString)
            sqlconn.Open()
            Me.Cursor = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox(ex.Message & " - Operation Cancelled")
            sqlconn.Close()
            FileClose(111)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        'MsgBox(sqlconn.ConnectionString)


        Try
            Me.Cursor = Cursors.WaitCursor

            For i = 0 To sqlStatements.Count - 1
                'MsgBox(sqlStatements(i))
                qry = New MySqlConnector.MySqlCommand(sqlStatements(i) & ";", sqlconn)
                qry.CommandTimeout = 0

                Try
                    'Execute query
                    qry.ExecuteNonQuery()

                Catch x As Exception
                    If x.HResult <> -2147467259 Then MsgBox(x.Message)

                    PrintLine(111, i & "," & sqlStatements(i) & "," & x.Message)
                End Try
            Next
            sqlconn.Close()
            MsgBox("Finished updating the database")
            sqlconn.Close()
            FileClose(111)
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            sqlconn.Close()
            FileClose(111)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "aboutclimsoft4.htm")
    End Sub

    Private Sub verTlStripMenuItem_Click(sender As Object, e As EventArgs) Handles verTlStripMenuItem.Click
        MsgBox("Climsft " & frmSplashScreen.lblVersion.Text,, "Version Details")
    End Sub


    Sub Load_local_Files()
        Dim lconn As New MySqlConnector.MySqlConnection
        ' Dim cmd As MySqlConnector.MySqlCommand
        Dim fl As MySqlConnector.MySqlBulkLoader
        ' Dim rws As Long
        lconn.ConnectionString = frmLogin.txtusrpwd.Text & ";AllowLoadLocalInfile=true"

        Try
            lconn.Open()
            fl = New MySqlConnector.MySqlBulkLoader(lconn)
            fl.FileName = "C:/Climsoft Project/NMHS/Djibouti/AWS/vaisala_combined/dj_vaisala112.csv"
            fl.TableName = "dj_vaisala112"
            fl.EscapeCharacter = "UTFB"
            fl.NumberOfLinesToSkip = 0
            fl.FieldTerminator = ","

            'fl.FieldQuotationCharacter = '"'
            'fl.FieldQuotationOptional ='True',
            fl.Local = True

            fl.Load()
            lconn.Close()
        Catch ex As Exception
            lconn.Close()
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
