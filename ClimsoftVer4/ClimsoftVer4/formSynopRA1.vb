Public Class formSynopRA1
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim usrName As String
    Dim usrPwd As String
    Dim dbServer As String
    Dim dbName As String
    Dim inc As Integer
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    Private Sub navigateRecords()
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        StationIdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
        YyyyTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy")
        MmTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
        DdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
        HhTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")
        Val_Elem106TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem106")
        Val_Elem107TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem107")
        Val_Elem400TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem400")
        Val_Elem814TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem814")
        Val_Elem399TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem399")
        Val_Elem106TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301")
        Val_Elem196TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem196")
        Val_Elem301TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301")
        Val_Elem101TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem101")
        Val_Elem102TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem102")
        Val_Elem103TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem103")
        Val_Elem105TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem105")
        Val_Elem176TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem176")
        Val_Elem110TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem110")
        Val_Elem114TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem114")
        Val_Elem112TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem112")
        Val_Elem111TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem111")
        Val_Elem167TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem167")
        Val_Elem197TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem197")
        Val_Elem193TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem193")
        Val_Elem115TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem115")
        Val_Elem177TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem177")
        Val_Elem178TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem178")
        Val_Elem179TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem179")
        Val_Elem116TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem116")
        Val_Elem118TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem118")
        Val_Elem123TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem123")
        Val_Elem120TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem120")
        Val_Elem121TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem121")
        Val_Elem122TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem122")
        Val_Elem127TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem127")
        Val_Elem124TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem124")
        Val_Elem125TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem125")
        Val_Elem126TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem126")
        Val_Elem131TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem131")
        Val_Elem128TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem128")
        Val_Elem129TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem129")
        Val_Elem130TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem130")
        Val_Elem002TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem002")
        Val_Elem003TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem003")
        Val_Elem099TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem099")
        Val_Elem018TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem018")
        Val_Elem084TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem084")
        Val_Elem132TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem132")
        Val_Elem005TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem005")
        Val_Elem174TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem174")
        Val_Elem046TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem046")
        Val_Elem117TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem117")
        Val_Elem119TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem119")
        Val_Elem180TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem180")
        displayRecordNumber()
    End Sub
    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noNextRec As New dataEntryGlobalRoutines
        If inc < (maxRows - 1) Then
            inc = inc + 1
            'Call subroutine for record navigation
            navigateRecords()
        Else
            'If the record Index is equal to maximum number of rows minus one, an error message must be displayed to show that
            'there is no more next record.The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class
            'hence the need to instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noNextRec.messageBoxNoNextRecord()
        End If

    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxRows - 1
        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'In order to move to move to the first record the record index is set to zero.
        inc = 0
        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noPreviousRec As New dataEntryGlobalRoutines

        If inc > 0 Then
            inc = inc - 1
            navigateRecords()
        Else
            'If the record Index is equal to zero an error message must be displayed to show that there is no more previous record.
            'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
            'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noPreviousRec.messageBoxNoPreviousRecord()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId") = StationIdTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy") = YyyyTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = MmTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = DdTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = HhTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem106") = Val_Elem106TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem107") = Val_Elem107TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem400") = Val_Elem400TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem814") = Val_Elem814TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem399") = Val_Elem399TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301") = Val_Elem106TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem196") = Val_Elem196TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301") = Val_Elem301TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem101") = Val_Elem101TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem102") = Val_Elem102TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem103") = Val_Elem103TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem105") = Val_Elem105TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem176") = Val_Elem176TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem110") = Val_Elem110TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem114") = Val_Elem114TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem112") = Val_Elem112TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem111") = Val_Elem111TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem167") = Val_Elem167TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem197") = Val_Elem197TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem193") = Val_Elem193TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem115") = Val_Elem115TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem177") = Val_Elem177TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem178") = Val_Elem178TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem179") = Val_Elem179TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem116") = Val_Elem116TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem118") = Val_Elem118TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem123") = Val_Elem123TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem120") = Val_Elem120TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem121") = Val_Elem121TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem122") = Val_Elem122TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem127") = Val_Elem127TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem124") = Val_Elem124TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem125") = Val_Elem125TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem126") = Val_Elem126TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem131") = Val_Elem131TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem128") = Val_Elem128TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem129") = Val_Elem129TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem130") = Val_Elem130TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem002") = Val_Elem002TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem003") = Val_Elem003TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem099") = Val_Elem099TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem018") = Val_Elem018TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem084") = Val_Elem084TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem132") = Val_Elem132TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem005") = Val_Elem005TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem174") = Val_Elem174TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem046") = Val_Elem046TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem117") = Val_Elem117TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem119") = Val_Elem119TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem180") = Val_Elem180TextBox.Text

        'The data adapter is used to update the record in the data source table
        da.Update(ds, "form_synoptic_2_RA1")

        'Show message for successful updating or record.
        'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
        'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
        recUpdate.messageBoxRecordedUpdated()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'The AddNew button is for the purpose of adding a new record to the DataSet and "NOT FOR ADDING A NEW RECORD TO THE DATASOURCE TABLE".
        'It is the job of the Commit button to add the new record to the datasource table.
        'On pressing the AddNew button, disable buttons for record navigation and also the buttons for deleting, updating
        'or committing a record. This means that these buttons are not required to operate at the time of adding a new record.
        'The addNew button itself should also become disabled soon after clicking it until after the newly added recorded is committed
        'to the data source table linked to the current dataset.
        'Only the Commit button should be enabled.

        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True
        StationIdTextBox.Clear()
        YyyyTextBox.Clear()
        MmTextBox.Clear()
        DdTextBox.Clear()
        HhTextBox.Clear()
        Val_Elem106TextBox.Clear()
        Val_Elem107TextBox.Clear()
        Val_Elem400TextBox.Clear()
        Val_Elem814TextBox.Clear()
        Val_Elem399TextBox.Clear()
        Val_Elem301TextBox.Clear()
        Val_Elem196TextBox.Clear()
        Val_Elem101TextBox.Clear()
        Val_Elem102TextBox.Clear()
        Val_Elem103TextBox.Clear()
        Val_Elem105TextBox.Clear()
        Val_Elem176TextBox.Clear()
        Val_Elem110TextBox.Clear()
        Val_Elem114TextBox.Clear()
        Val_Elem112TextBox.Clear()
        Val_Elem111TextBox.Clear()
        Val_Elem167TextBox.Clear()
        Val_Elem107TextBox.Clear()
        Val_Elem197TextBox.Clear()
        Val_Elem193TextBox.Clear()
        Val_Elem115TextBox.Clear()
        Val_Elem177TextBox.Clear()
        Val_Elem178TextBox.Clear()
        Val_Elem179TextBox.Clear()
        Val_Elem180TextBox.Clear()
        Val_Elem119TextBox.Clear()
        Val_Elem116TextBox.Clear()
        Val_Elem117TextBox.Clear()
        Val_Elem118TextBox.Clear()
        Val_Elem123TextBox.Clear()
        Val_Elem120TextBox.Clear()
        Val_Elem121TextBox.Clear()
        Val_Elem122TextBox.Clear()
        Val_Elem127TextBox.Clear()
        Val_Elem124TextBox.Clear()
        Val_Elem125TextBox.Clear()
        Val_Elem126TextBox.Clear()
        Val_Elem131TextBox.Clear()
        Val_Elem128TextBox.Clear()
        Val_Elem129TextBox.Clear()
        Val_Elem130TextBox.Clear()
        Val_Elem002TextBox.Clear()
        Val_Elem003TextBox.Clear()
        Val_Elem099TextBox.Clear()
        Val_Elem018TextBox.Clear()
        Val_Elem084TextBox.Clear()
        Val_Elem132TextBox.Clear()
        Val_Elem005TextBox.Clear()
        Val_Elem174TextBox.Clear()
        Val_Elem046TextBox.Clear()


        'Set record index to last record
        inc = maxRows - 1

        'Display record position in record navigation Text Box
        recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1

    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'The "btnClear" when clicked is meant to clear the form of any new data entered after clicking the Addnew button or in other words 
        'to undo the AddNew button process before the recorded can be committed to to the datasource table linked to the DataSet.
        'So all the buttons that were disabled after the AddNew button was clicked should be enabled back again and the Commit button
        'disabled until the AddNew button is clicked

        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnDelete.Enabled = True
        btnUpdate.Enabled = True
        btnMoveFirst.Enabled = True
        btnMoveLast.Enabled = True
        btnMoveNext.Enabled = True
        btnMovePrevious.Enabled = True

        'Set Record position index to first record
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        dsNewRow = ds.Tables("form_synoptic_2_RA1").NewRow
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId") = StationIdTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy") = YyyyTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = MmTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = DdTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = HhTextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem106") = Val_Elem106TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem107") = Val_Elem107TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem400") = Val_Elem400TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem814") = Val_Elem814TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem399") = Val_Elem399TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301") = Val_Elem106TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem196") = Val_Elem196TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301") = Val_Elem301TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem101") = Val_Elem101TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem102") = Val_Elem102TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem103") = Val_Elem103TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem105") = Val_Elem105TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem176") = Val_Elem176TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem110") = Val_Elem110TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem114") = Val_Elem114TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem112") = Val_Elem112TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem111") = Val_Elem111TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem167") = Val_Elem167TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem197") = Val_Elem197TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem193") = Val_Elem193TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem115") = Val_Elem115TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem177") = Val_Elem177TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem178") = Val_Elem178TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem179") = Val_Elem179TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem116") = Val_Elem116TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem118") = Val_Elem118TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem123") = Val_Elem123TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem120") = Val_Elem120TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem121") = Val_Elem121TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem122") = Val_Elem122TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem127") = Val_Elem127TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem124") = Val_Elem124TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem125") = Val_Elem125TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem126") = Val_Elem126TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem131") = Val_Elem131TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem128") = Val_Elem128TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem129") = Val_Elem129TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem130") = Val_Elem130TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem002") = Val_Elem002TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem003") = Val_Elem003TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem099") = Val_Elem099TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem018") = Val_Elem018TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem084") = Val_Elem084TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem132") = Val_Elem132TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem005") = Val_Elem005TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem174") = Val_Elem174TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem046") = Val_Elem046TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Val_Elem117") = Val_Elem117TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem119") = Val_Elem119TextBox.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem180") = Val_Elem180TextBox.Text

        'Add a new record to the data source table
        ds.Tables("form_synoptic_2_RA1").Rows.Add(dsNewRow)
        da.Update(ds, "form_synoptic_2_RA1")

        'Display message for successful record commit to table
        recCommit.messageBoxCommit()

        btnAddNew.Enabled = True
        btnClear.Enabled = False
        btnCommit.Enabled = False
        btnDelete.Enabled = True
        btnUpdate.Enabled = True
        btnMoveFirst.Enabled = True
        btnMoveLast.Enabled = True
        btnMoveNext.Enabled = True
        btnMovePrevious.Enabled = True
        maxRows = ds.Tables("form_synoptic_2_RA1").Rows.Count
        inc = maxRows - 1

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines
        If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then

            'Display message to show that delete operation has been cancelled
            recDelete.messageBoxOperationCancelled()
            Exit Sub
        End If

        ds.Tables("form_synoptic_2_RA1").Rows(inc).Delete()
        da.Update(ds, "form_synoptic_2_RA1")
        maxRows = maxRows - 1
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub formSynopRA1_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Set the record index counter to the first row
        inc = 0

        myConnectionString = LoginForm.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM form_synoptic_2_RA1"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "form_synoptic_2_RA1")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("form_synoptic_2_RA1").Rows.Count
        StationIdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
        YyyyTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy")
        MmTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
        DdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
        HhTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")
        Val_Elem106TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem106")
        Val_Elem107TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem107")
        Val_Elem400TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem400")
        Val_Elem814TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem814")
        Val_Elem399TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem399")
        Val_Elem106TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301")
        Val_Elem196TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem196")
        Val_Elem301TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem301")
        Val_Elem101TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem101")
        Val_Elem102TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem102")
        Val_Elem103TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem103")
        Val_Elem105TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem105")
        Val_Elem176TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem176")
        Val_Elem110TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem110")
        Val_Elem114TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem114")
        Val_Elem112TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem112")
        Val_Elem111TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem111")
        Val_Elem167TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem167")
        Val_Elem197TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem197")
        Val_Elem193TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem193")
        Val_Elem115TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem115")
        Val_Elem177TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem177")
        Val_Elem178TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem178")
        Val_Elem179TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem179")
        Val_Elem116TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem116")
        Val_Elem118TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem118")
        Val_Elem123TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem123")
        Val_Elem120TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem120")
        Val_Elem121TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem121")
        Val_Elem122TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem122")
        Val_Elem127TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem127")
        Val_Elem124TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem124")
        Val_Elem125TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem125")
        Val_Elem126TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem126")
        Val_Elem131TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem131")
        Val_Elem128TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem128")
        Val_Elem129TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem129")
        Val_Elem130TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem130")
        Val_Elem002TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem002")
        Val_Elem003TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem003")
        Val_Elem099TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem099")
        Val_Elem018TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem018")
        Val_Elem084TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem084")
        Val_Elem132TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem132")
        Val_Elem005TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem005")
        Val_Elem174TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem174")
        Val_Elem046TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem046")
        Val_Elem117TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem117")
        Val_Elem119TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem119")
        Val_Elem180TextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("val_elem180")

        displayRecordNumber()

    End Sub
End Class
