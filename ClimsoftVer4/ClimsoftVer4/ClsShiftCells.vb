Public Class ClsShiftCells
    Private ctrContextMenuStrip As ContextMenuStrip
    Private lstOrderedControls As New List(Of ucrValueView)

    Public Sub New()

    End Sub


    'left here temporary
    Public Sub New(lstOrderedControls As IOrderedEnumerable(Of ucrValueFlagPeriod))
        SetUpContextMenuStrip(New ContextMenuStrip)
        For Each ctr As ucrValueFlagPeriod In lstOrderedControls
            Me.lstOrderedControls.Add(ctr)
        Next

    End Sub

    'left here temporary
    Public Sub New(lstOrderedControls As IOrderedEnumerable(Of ucrDirectionSpeedFlag))
        SetUpContextMenuStrip(New ContextMenuStrip)
        For Each ctr As ucrDirectionSpeedFlag In lstOrderedControls
            Me.lstOrderedControls.Add(ctr)
        Next
    End Sub

    Public Function GetVFPContextMenu() As ContextMenuStrip
        Return ctrContextMenuStrip
    End Function

    'todo optimise
    Public Sub SetUpShiftCellsMenuStrips(ctrContextMenuStrip As ContextMenuStrip, lstNewOrderedControls As IOrderedEnumerable(Of ucrValueFlagPeriod))
        SetUpContextMenuStrip(ctrContextMenuStrip)
        For Each ctr As ucrValueFlagPeriod In lstNewOrderedControls
            Me.lstOrderedControls.Add(ctr)
            ctr.SetContextMenuStrip(ctrContextMenuStrip)
        Next
    End Sub

    'todo. optimise
    Public Sub SetUpShiftCellsMenuStrips(ctrContextMenuStrip As ContextMenuStrip, lstNewOrderedControls As IOrderedEnumerable(Of ucrDirectionSpeedFlag))
        SetUpContextMenuStrip(ctrContextMenuStrip)
        For Each ctr As ucrDirectionSpeedFlag In lstNewOrderedControls
            Me.lstOrderedControls.Add(ctr)
            ctr.SetContextMenuStrip(Me.ctrContextMenuStrip)
        Next
    End Sub

    Private Sub SetUpContextMenuStrip(ctrNewContextMenuStrip As ContextMenuStrip)
        Dim menuItemInsertCell As New ToolStripMenuItem("Insert Cell")
        Dim menuItemDeleteCell As New ToolStripMenuItem("Delete Cell")

        Me.ctrContextMenuStrip = ctrNewContextMenuStrip

        Me.ctrContextMenuStrip.Items.Add(menuItemInsertCell)
        Me.ctrContextMenuStrip.Items.Add(menuItemDeleteCell)

        'Add functionality for ToolStripMenuItem1 (Maximize) click
        AddHandler menuItemDeleteCell.Click, AddressOf menuItemDeleteCell_Click

        'Add functionality for ToolStripMenuItem2 (Exit) click
        AddHandler menuItemInsertCell.Click, AddressOf menuItemInsertCell_Click

    End Sub

    Private Sub menuItemInsertCell_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf Me.ctrContextMenuStrip.SourceControl Is TextBox Then
            'for ucrValueFlagPeriod and ucrDirectionSpeedFlag
            Dim control = Me.ctrContextMenuStrip.SourceControl.Parent.Parent

            If (TypeOf control Is ucrValueFlagPeriod) OrElse (TypeOf control Is ucrDirectionSpeedFlag) Then
                'Start the shifting downwards
                Dim currentIndex As Integer = control.TabIndex
                Dim lstControls As New List(Of ucrValueView)
                Dim lstValues As New List(Of Object)

                'get the values to shift and the respective controls
                For Each ctr As ucrValueView In lstOrderedControls
                    If ctr.TabIndex >= currentIndex AndAlso ctr.Enabled Then
                        lstControls.Add(ctr)
                        lstValues.Add(ctr.GetValue)
                    End If
                Next

                For i As Integer = 0 To lstControls.Count - 2
                    lstControls.Item(i + 1).SetValue(lstValues.Item(i))
                Next

                DirectCast(control, ucrBaseDataLink).Clear()

            End If
        End If

    End Sub

    Private Sub menuItemDeleteCell_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf Me.ctrContextMenuStrip.SourceControl Is TextBox Then
            'for ucrValueFlagPeriod and ucrDirectionSpeedFlag
            Dim control = Me.ctrContextMenuStrip.SourceControl.Parent.Parent

            If (TypeOf control Is ucrValueFlagPeriod) OrElse (TypeOf control Is ucrDirectionSpeedFlag) Then
                'Start the shifting upwards
                Dim currentIndex As Integer = control.TabIndex
                Dim lstControls As New List(Of ucrValueView)
                Dim lstValues As New List(Of Object)

                'get the values to shift and the respective controls
                For Each ctr As ucrValueView In lstOrderedControls
                    If ctr.TabIndex >= currentIndex AndAlso ctr.Enabled Then
                        lstControls.Add(ctr)
                        lstValues.Add(ctr.GetValue)
                    End If
                Next

                For i As Integer = lstControls.Count - 1 To 1 Step -1
                    lstControls.Item(i - 1).SetValue(lstValues.Item(i))
                Next

                If lstControls.Count > 0 Then
                    lstControls.Item(lstControls.Count - 1).Clear()
                End If

            End If
        End If
    End Sub


End Class
