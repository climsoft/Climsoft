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
        cboMonth.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
        cboDay.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
        cboHour.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")

        'MmTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
        'DdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
        'HhTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")
        'Display observation values in coressponding textboxes
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
        'Display flag values in corresponding textboxes
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag106")) Then txtFlag106.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag106")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag107")) Then txtFlag107.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag107")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag400")) Then txtFlag400.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag400")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag814")) Then txtFlag814.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag814")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag399")) Then txtFlag399.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag399")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")) Then txtFlag106.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag196")) Then txtFlag196.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag196")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")) Then txtFlag301.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag101")) Then txtFlag101.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag101")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag102")) Then txtFlag102.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag102")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag103")) Then txtFlag103.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag103")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag105")) Then txtFlag105.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag105")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag176")) Then txtFlag176.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag176")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag110")) Then txtFlag110.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag110")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag114")) Then txtFlag114.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag114")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag112")) Then txtFlag112.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag112")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag111")) Then txtFlag111.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag111")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag167")) Then txtFlag167.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag167")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag197")) Then txtFlag197.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag197")
        'If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag193")) Then txtFlag193.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag193")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag115")) Then txtFlag115.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag115")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag177")) Then txtFlag177.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag177")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag178")) Then txtFlag178.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag178")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag179")) Then txtFlag179.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag179")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag116")) Then txtFlag116.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag116")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag118")) Then txtFlag118.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag118")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag123")) Then txtFlag123.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag123")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag120")) Then txtFlag120.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag120")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag121")) Then txtFlag121.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag121")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag122")) Then txtFlag122.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag122")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag127")) Then txtFlag127.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag127")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag124")) Then txtFlag124.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag124")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag125")) Then txtFlag125.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag125")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag126")) Then txtFlag126.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag126")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag131")) Then txtFlag131.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag131")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag128")) Then txtFlag128.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag128")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag129")) Then txtFlag129.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag129")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag130")) Then txtFlag130.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag130")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag002")) Then txtFlag002.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag002")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag003")) Then txtFlag003.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag003")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag099")) Then txtFlag099.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag099")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag018")) Then txtFlag018.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag018")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag084")) Then txtFlag084.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag084")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag132")) Then txtFlag132.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag132")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag005")) Then txtFlag005.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag005")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag174")) Then txtFlag174.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag174")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag046")) Then txtFlag046.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag046")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag117")) Then txtFlag117.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag117")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag119")) Then txtFlag119.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag119")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag180")) Then txtFlag180.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag180")

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
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = cboMonth.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = cboDay.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = cboHour.Text

        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = MmTextBox.Text
        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = DdTextBox.Text
        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = HhTextBox.Text
        'Update textboxes for observation values
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
        'Update texboxes for observation flags
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag106") = txtFlag106.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag107") = txtFlag107.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag400") = txtFlag400.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag814") = txtFlag814.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag399") = txtFlag399.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301") = txtFlag106.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag196") = txtFlag196.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301") = txtFlag301.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag101") = txtFlag101.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag102") = txtFlag102.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag103") = txtFlag103.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag105") = txtFlag105.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag176") = txtFlag176.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag110") = txtFlag110.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag114") = txtFlag114.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag112") = txtFlag112.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag111") = txtFlag111.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag167") = txtFlag167.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag197") = txtFlag197.Text
        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag193") = txtFlag193.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag115") = txtFlag115.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag177") = txtFlag177.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag178") = txtFlag178.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag179") = txtFlag179.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag116") = txtFlag116.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag118") = txtFlag118.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag123") = txtFlag123.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag120") = txtFlag120.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag121") = txtFlag121.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag122") = txtFlag122.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag127") = txtFlag127.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag124") = txtFlag124.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag125") = txtFlag125.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag126") = txtFlag126.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag131") = txtFlag131.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag128") = txtFlag128.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag129") = txtFlag129.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag130") = txtFlag130.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag002") = txtFlag002.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag003") = txtFlag003.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag099") = txtFlag099.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag018") = txtFlag018.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag084") = txtFlag084.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag132") = txtFlag132.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag005") = txtFlag005.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag174") = txtFlag174.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag046") = txtFlag046.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag117") = txtFlag117.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag119") = txtFlag119.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag180") = txtFlag180.Text

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
        cboMonth.Text = ""
        cboDay.Text = ""
        cboHour.Text = ""

        'MmTextBox.Clear()
        'DdTextBox.Clear()
        'HhTextBox.Clear()

        'Clear textboxes for observation values
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
        ' Val_Elem107TextBox.Clear()
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
        'Clear texboxes for observation flags
        txtFlag106.Clear()
        txtFlag107.Clear()
        txtFlag400.Clear()
        txtFlag814.Clear()
        txtFlag399.Clear()
        txtFlag301.Clear()
        txtFlag196.Clear()
        txtFlag101.Clear()
        txtFlag102.Clear()
        txtFlag103.Clear()
        txtFlag105.Clear()
        txtFlag176.Clear()
        txtFlag110.Clear()
        txtFlag114.Clear()
        txtFlag112.Clear()
        txtFlag111.Clear()
        txtflag167.Clear()
        'Val_Elem107TextBox.Clear()
        txtFlag197.Clear()
        txtFlag193.Clear()
        txtFlag115.Clear()
        txtFlag177.Clear()
        txtFlag178.Clear()
        txtFlag179.Clear()
        txtFlag180.Clear()
        txtFlag119.Clear()
        txtFlag116.Clear()
        txtFlag117.Clear()
        txtFlag118.Clear()
        txtFlag123.Clear()
        txtFlag120.Clear()
        txtFlag121.Clear()
        txtFlag122.Clear()
        txtFlag127.Clear()
        txtFlag124.Clear()
        txtFlag125.Clear()
        txtFlag126.Clear()
        txtFlag131.Clear()
        txtFlag128.Clear()
        txtFlag129.Clear()
        txtFlag130.Clear()
        txtFlag002.Clear()
        txtFlag003.Clear()
        txtFlag099.Clear()
        txtFlag018.Clear()
        txtFlag084.Clear()
        txtFlag132.Clear()
        txtFlag005.Clear()
        txtFlag174.Clear()
        txtFlag046.Clear()
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
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = cboMonth.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = cboDay.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = cboHour.Text

        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = MmTextBox.Text
        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = DdTextBox.Text
        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = HhTextBox.Text
        'Commit observation values to database
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
        'Commit observation flags to database
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag106") = txtFlag106.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag107") = txtFlag107.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag400") = txtFlag400.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag814") = txtFlag814.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag399") = txtFlag399.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301") = txtFlag301.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag196") = txtFlag196.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301") = txtFlag301.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag101") = txtFlag101.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag102") = txtFlag102.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag103") = txtFlag103.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag105") = txtFlag105.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag176") = txtflag176.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag110") = txtFlag110.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag114") = txtFlag114.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag112") = txtFlag112.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag111") = txtFlag111.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag167") = txtFlag167.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag197") = txtFlag197.Text
        'ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag193") = txtFlag193.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag115") = txtFlag115.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag177") = txtFlag177.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag178") = txtFlag178.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag179") = txtFlag179.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag116") = txtFlag116.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag118") = txtFlag118.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag123") = txtFlag123.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag120") = txtFlag120.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag121") = txtFlag121.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag122") = txtFlag122.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag127") = txtFlag127.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag124") = txtFlag124.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag125") = txtFlag125.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag126") = txtFlag126.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag131") = txtFlag131.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag128") = txtFlag128.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag129") = txtFlag129.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag130") = txtFlag130.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag002") = txtFlag002.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag003") = txtFlag003.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag099") = txtFlag099.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag018") = txtFlag018.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag084") = txtFlag084.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag132") = txtFlag132.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag005") = txtFlag005.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag174") = txtFlag174.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag046") = txtFlag046.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag117") = txtFlag117.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag119") = txtFlag119.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag180") = txtFlag180.Text
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
        cboMonth.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
        cboDay.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
        cboHour.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")

        'MmTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
        'DdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
        'HhTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")

        'Initialize textboxes for observation values
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
        'Initialize textboxes for observation flags
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag106")) Then txtFlag106.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag106")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag107")) Then txtFlag107.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag107")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag400")) Then txtFlag400.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag400")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag814")) Then txtFlag814.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag814")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag399")) Then txtFlag399.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag399")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")) Then txtFlag106.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag196")) Then txtFlag196.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag196")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")) Then txtFlag301.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag301")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag101")) Then txtFlag101.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag101")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag102")) Then txtFlag102.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag102")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag103")) Then txtFlag103.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag103")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag105")) Then txtFlag105.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag105")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag176")) Then txtFlag176.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag176")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag110")) Then txtFlag110.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag110")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag114")) Then txtFlag114.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag114")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag112")) Then txtFlag112.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag112")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag111")) Then txtFlag111.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag111")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag167")) Then txtFlag167.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag167")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag197")) Then txtFlag197.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag197")
        'If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag193")) Then txtFlag193.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag193")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag115")) Then txtFlag115.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag115")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag177")) Then txtFlag177.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag177")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag178")) Then txtFlag178.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag178")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag179")) Then txtFlag179.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag179")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag116")) Then txtFlag116.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag116")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag118")) Then txtFlag118.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag118")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag123")) Then txtFlag123.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag123")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag120")) Then txtFlag120.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag120")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag121")) Then txtFlag121.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag121")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag122")) Then txtFlag122.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag122")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag127")) Then txtFlag127.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag127")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag124")) Then txtFlag124.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag124")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag125")) Then txtFlag125.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag125")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag126")) Then txtFlag126.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag126")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag131")) Then txtFlag131.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag131")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag128")) Then txtFlag128.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag128")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag129")) Then txtFlag129.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag129")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag130")) Then txtFlag130.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag130")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag002")) Then txtFlag002.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag002")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag003")) Then txtFlag003.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag003")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag099")) Then txtFlag099.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag099")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag018")) Then txtFlag018.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag018")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag084")) Then txtFlag084.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag084")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag132")) Then txtFlag132.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag132")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag005")) Then txtFlag005.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag005")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag174")) Then txtFlag174.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag174")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag046")) Then txtFlag046.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag046")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag117")) Then txtFlag117.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag117")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag119")) Then txtFlag119.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag119")
        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag180")) Then txtFlag180.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("Flag180")

        displayRecordNumber()

    End Sub

   
    Private Sub YyyyTextBox_LostFocus(sender As Object, e As EventArgs) Handles YyyyTextBox.LostFocus
        If Not IsNumeric(YyyyTextBox.Text) Then
            YyyyTextBox.BackColor = Color.Red
            MsgBox("Number expected", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub cboMonth_LostFocus(sender As Object, e As EventArgs) Handles cboMonth.LostFocus
        If cboMonth.Text > 12 Then
            cboMonth.BackColor = Color.Red
            MsgBox("Month of or range !", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Val_Elem106TextBox_LostFocus(sender As Object, e As EventArgs) Handles Val_Elem106TextBox.LostFocus
        txtFlag106.Text = Strings.Right(Val_Elem106TextBox.Text, 1)
        Val_Elem106TextBox.Text = Strings.Left(Val_Elem106TextBox.Text, Len(Val_Elem106TextBox.Text) - 1)
    End Sub
End Class
