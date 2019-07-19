Imports System.Linq.Dynamic

Public Class ucrHourlyWind
    Private strDirectionFieldName As String = "elem_112_"
    Private strSpeedFieldName As String = "elem_111_"
    Private strFlagFieldName As String = "ddflag"

    Private Sub ucrHourlyWind_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then
            'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
            Dim allVFP = From vfp In Me.Controls.OfType(Of ucrDirectionSpeedFlag)() Order By vfp.TabIndex
            Dim shiftCells As New ClsShiftCells()
            shiftCells.SetUpShiftCellsMenuStrips(New ContextMenuStrip, allVFP)

            'set up the value flag period first
            Dim ucrVFP As ucrDirectionSpeedFlag
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrDirectionSpeedFlag)
                    ucrVFP.SetInnerControlsFieldNames(strDirectionFieldName & ucrVFP.FieldName, strSpeedFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_hourlywind")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonth, ucrMonth.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrDay, ucrDay.FieldName, "=", strLinkedFieldName:="Day", bForceValuesAsString:=False)


            'set up the navigation control
            ucrNavigation.SetTableEntryAndKeyControls(Me)

            bFirstLoad = False

            'populate the values
            ucrNavigation.PopulateControl()
            SaveEnable()
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            ucrNavigation.NewSequencerRecord(txtSequencer.Text, {"mm", "dd"}, {ucrMonth, ucrDay}, ucrYear:=ucrYearSelector)
            'SaveEnable()
            ucrDirectionSpeedFlag0.Focus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'TODO. Proceed from here
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql As String
        Dim userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_monthly"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_monthly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy;"
        Else
            sql = "SELECT * FROM form_monthly ORDER by stationId,elementId,yyyy;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_monthly")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If MessageBox.Show("Are you sure you want to upload these records?", "Upload Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            UploadAllRecords()
            'MessageBox.Show("Records have been uploaded sucessfully", "Upload Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



End Class