Public Class ucrNavigator
    Private bFirstLoad As Boolean = True
    Private bNavigationEnabled As Boolean = True

    Private Sub ucrNavigator_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            bFirstLoad = False
        End If
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        MoveFirst() 'moves to the first record
    End Sub
    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        MovePrevious()  'moves to the previous viewed record
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        MoveNext() 'moves to the next record
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        MoveLast() 'moves to the last record
    End Sub

    'this will be the event handler that listens to changes to record in the datastructure
    Private Sub ChangesToRecordInDataStructure(sender As Object, e As EventArgs)
        UpdateDisplayAndNavigation()
    End Sub

    Public Sub MoveFirst()
        If bNavigationEnabled Then
            'todo. prompt the datastructure to go to the first record
        End If
    End Sub

    Public Sub MovePrevious()
        If bNavigationEnabled Then
            'todo. prompt the data structure to go to the previous record
        End If
    End Sub

    Public Sub MoveNext()
        If bNavigationEnabled Then
            'todo. prompt the data structure to go to the next record
        End If
    End Sub

    Public Sub MoveLast()
        If bNavigationEnabled Then
            'todo. prompt the data structure to go to the last record
        End If
    End Sub

    'this gets implictly called everytime there is change in the data structure record
    Public Sub UpdateDisplayAndNavigation()
        Dim iMaxRows As Integer = 0
        Dim iCurrRow As Integer = 0

        'todo. get from the datastructure Number of records and store the value in iMaxRows
        'todo. get from the datastructure position of record and store the value in iCurrRow

        If iCurrRow = -1 Then
            txtRecNum.Text = "New Record"
            EnableNavigation(False)
        ElseIf iMaxRows = 0 Then
            txtRecNum.Text = "No Records"
            EnableNavigation(False)
        ElseIf iCurrRow >= 0 AndAlso iCurrRow < iMaxRows Then
            txtRecNum.Text = "Record " & iCurrRow + 1 & " of " & iMaxRows
            EnableNavigation(True)
        End If

    End Sub

    Public Sub EnableNavigation(bEnableState As Boolean)
        'enables and disables navigation buttons
        btnMoveFirst.Enabled = bEnableState
        btnMoveLast.Enabled = bEnableState
        btnMoveNext.Enabled = bEnableState
        btnMovePrevious.Enabled = bEnableState
        bNavigationEnabled = bEnableState
    End Sub
End Class
