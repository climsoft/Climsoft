Public Class ucrPage
    Protected bFirstLoad As Boolean = True
    Protected lstUcrValues As New List(Of ucrValue)
    Protected ucrNavigator As ucrNavigator
    Protected WithEvents btnAddNew As Button
    Protected WithEvents btnSave As Button
    Protected WithEvents btnUpdate As Button
    Protected WithEvents btnDelete As Button
    Protected WithEvents btnClear As Button
    Protected WithEvents btnCancel As Button
    Protected WithEvents btnView As Button
    Protected WithEvents btnUpload As Button

    Private Sub ucrPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            SetValueControlsList()
            'bFirstLoad = False
        End If
    End Sub

    Public Sub SetUpButtonAddNew(newBtn As Button)
        btnAddNew = newBtn
    End Sub

    Public Sub SetUpButtonSave(newBtn As Button)
        btnSave = newBtn
    End Sub

    Public Sub SetUpButtonUpdate(newBtn As Button)
        btnUpdate = newBtn
    End Sub

    Public Sub SetUpButtonDelete(newBtn As Button)
        btnDelete = newBtn
    End Sub

    Public Sub SetUpButtonClear(newBtn As Button)
        btnClear = newBtn
    End Sub

    Public Sub SetUpButtonCancel(newBtn As Button)
        btnCancel = newBtn
    End Sub

    Public Sub SetUpButtonView(newBtn As Button)
        btnView = newBtn
    End Sub

    Public Sub SetUpButtonUpload(newBtn As Button)
        btnUpload = newBtn
    End Sub

    Public Sub SetUpNavigator(newUcrNavigator As ucrNavigator)
        ucrNavigator = newUcrNavigator
        'todo. setup the datastructure to the navigator . 
    End Sub

    Public Sub SetValueControlsList()
        lstUcrValues.Clear()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValue Then
                lstUcrValues.Add(DirectCast(ctr, ucrValue))
            End If
        Next
    End Sub

    Public Sub SetDataIdentifier(objDataIdentifier As Object)
        'specifies the identifier that would be usd by the datastructure to get the data 
    End Sub

    Public Sub SetUpValueControls()
        For Each ctr As ucrValue In lstUcrValues
            AddHandler ctr.evtKeyDown, AddressOf GoToNextChildControl
            'todo. set up the properties of the child controls and the defination of the data structure
            'the properties will be field name... 
        Next
    End Sub

    Protected Sub InitialiseDatastructure()
        'todo. initilise the datastructure object and set it's defaults
    End Sub


    'this will be the event handler that listens to changes to record in the datastructure
    Private Sub ChangesToRecordInDataStructure(sender As Object, e As EventArgs)
        UpdateDisplay()
    End Sub

    Public Sub UpdateDisplay()
        'called 
        'also call upon the populating of the form by the datastructure
    End Sub


    Public Overridable Sub AddNewRecord()
        'todo. add new record
    End Sub
    Public Overridable Sub SaveRecord()
        'todo. calls the save record method of the datastructure
    End Sub
    Public Overridable Sub UpdateRecord()
        'todo. calls the update record method of the datastructure
    End Sub
    Public Overridable Sub DeleteRecord()
        'todo. calls the delete record method of the datastructure
    End Sub
    Public Overridable Sub Cancel()
        'todo. cancel the entry of the records and goes back to the record that was previously selected
    End Sub

    Public Overridable Sub Clear()
        'Either clear the controls which will clear the datastrucre 
        'or call the datastructure clear function which will inturn clear the controls

    End Sub

    Public Overridable Sub Close()
        'todo. check if you have unsaved changes to determine warn the user beforee closing the form
        FindForm.Close()
    End Sub
    Public Overridable Sub Upload()
        'todo. call the datastructure method
    End Sub

    Public Overridable Sub View()
        'todo. call the datastructure method
    End Sub

    Private Sub GoToNextChildControl(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If TypeOf sender Is ucrValue Then
                'on enter only go next if what has been typed in is valid
                If DirectCast(sender, ucrValue).ValidateValue() Then
                    Me.SelectNextControl(sender, True, True, True, True)
                End If
                'this handles the "noise" on  return key down
                e.SuppressKeyPress = True
            End If
        End If

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddNewRecord()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveRecord()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateRecord()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteRecord()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Cancel()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        View()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Upload()
    End Sub
End Class
