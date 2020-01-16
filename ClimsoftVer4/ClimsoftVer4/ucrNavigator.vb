Public Class ucrNavigator
    Private bFirstLoad As Boolean = True
    Private ucrLinkedForm As ucrForm
    Public Event evtValueChanged(sender As Object, e As EventArgs)
    'Stores the number of the maximum rows in a data table
    Public iMaxRows As Integer
    'Stores the current row
    Public iCurrRow As Integer
    'Stores the sort by querry
    Public strSortCol As String = ""
    Public clsapi As New clsAPI


    Private Sub ucrNavigator_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            txtRecNum.ReadOnly = True
            txtRecNum.TextAlign = HorizontalAlignment.Center
            bFirstLoad = False
        End If
    End Sub

    Public Sub PopulateControl()
        If clsDataConnection.IsInDesignMode() Then
            Exit Sub ' temporary code to remove the bugs thrown during design time
        End If
        ' This is the cause of slow loading - getting all records into dtbRecords is slow.
        'MyBase.PopulateControl()

        iMaxRows = clsapi.GetDataStructureRecordsCount()
        iCurrRow = 0
        'currentRowDataPos = -1
        'currentRowData = New Dictionary(Of String, String)
        'If strSortCol <> "" AndAlso dtbRecords.Columns.Contains(strSortCol) Then
        '    dtbRecords.DefaultView.Sort = strSortCol & " ASC"
        'End If
        displayRecordNumber()
        'UpdateKeyControls()
        OnevtValueChanged(Me, Nothing)
    End Sub

    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        If iCurrRow = -1 Then
            txtRecNum.Text = "New Record"
            'disable navigation buttons
            EnableNavigationButtons(False)
        ElseIf iMaxRows = 0 Then
            txtRecNum.Text = "No Records"
            'disable navigation buttons
            EnableNavigationButtons(False)
        ElseIf iCurrRow >= 0 AndAlso iCurrRow < iMaxRows Then
            txtRecNum.Text = "Record " & iCurrRow + 1 & " of " & iMaxRows
            'enable navigation buttons
            EnableNavigationButtons(True)
        Else
            txtRecNum.Text = "New Record"
            'disable navigation buttons
            EnableNavigationButtons(False)
        End If

    End Sub

    Private Sub EnableNavigationButtons(bEnableState As Boolean)
        btnMoveFirst.Enabled = bEnableState
        btnMoveLast.Enabled = bEnableState
        btnMoveNext.Enabled = bEnableState
        btnMovePrevious.Enabled = bEnableState
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        iCurrRow = 0
        displayRecordNumber()
        'UpdateKeyControls()
        OnevtValueChanged(Me, Nothing)
    End Sub
    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        If iCurrRow > 0 Then
            iCurrRow = iCurrRow - 1
            displayRecordNumber()
            'OnevtValueChanged(sender, e)
            'UpdateKeyControls()
            OnevtValueChanged(Me, Nothing)
        Else
            MessageBox.Show("No more previous record!", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        If iCurrRow < (iMaxRows - 1) Then
            iCurrRow = iCurrRow + 1
            displayRecordNumber()
            ' UpdateKeyControls()
            OnevtValueChanged(Me, Nothing)
        Else
            MessageBox.Show("No more next record!", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        MoveLast()
    End Sub

    Private Sub MoveLast()
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        iCurrRow = iMaxRows - 1
        displayRecordNumber()
        'UpdateKeyControls()
        OnevtValueChanged(Me, Nothing)
    End Sub

    Public Sub GoToNewRecord()
        'We could repopulate entirely or add a the last added record from the datatabase
        PopulateControl()
        MoveLast()
    End Sub

    Public Sub RemoveRecord()
        PopulateControl()
    End Sub



    Public Sub OnevtValueChanged(sender As Object, e As EventArgs)
        ' If Not bSuppressChangedEvents Then
        RaiseEvent evtValueChanged(sender, e)
        'End If
    End Sub

    Public Sub SetForm(ucrNewLinkedForm As ucrForm)
        ucrLinkedForm = ucrNewLinkedForm

    End Sub

End Class
