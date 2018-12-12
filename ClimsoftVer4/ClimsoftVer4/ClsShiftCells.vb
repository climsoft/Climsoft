Public Class ClsShiftCells
    Private vfpContextMenuStrip As ContextMenuStrip
    Private lstOrderedVfpControls As New List(Of ucrValueView)

    ''' <summary>
    ''' initialise the class with controls ordered by tab index
    ''' </summary>
    ''' <param name="lstOrderedControls"></param>
    Public Sub New(lstOrderedControls As IOrderedEnumerable(Of ucrBaseDataLink))
        For Each ctr As ucrBaseDataLink In lstOrderedControls
            Me.lstOrderedVfpControls.Add(ctr)
        Next
        SetUpContextMenuStrip()
    End Sub

    Public Sub New(lstOrderedControls As List(Of ucrBaseDataLink))
        For Each ctr As ucrBaseDataLink In lstOrderedControls
            Me.lstOrderedVfpControls.Add(ctr)
        Next
        SetUpContextMenuStrip()
    End Sub

    Public Sub New(lstOrderedControls As IOrderedEnumerable(Of ucrValueFlagPeriod))
        For Each ctr As ucrValueFlagPeriod In lstOrderedControls
            Me.lstOrderedVfpControls.Add(ctr)
        Next
        SetUpContextMenuStrip()
    End Sub

    Public Sub New(lstOrderedControls As IOrderedEnumerable(Of ucrDirectionSpeedFlag))
        For Each ctr As ucrDirectionSpeedFlag In lstOrderedControls
            Me.lstOrderedVfpControls.Add(ctr)
        Next
        SetUpContextMenuStrip()
    End Sub

    Public Function GetVFPContextMenu() As ContextMenuStrip
        Return vfpContextMenuStrip
    End Function

    Private Sub SetUpContextMenuStrip()
        Dim menuItemInsertCell As New ToolStripMenuItem("Insert Cell")
        Dim menuItemDeleteCell As New ToolStripMenuItem("Delete Cell")

        vfpContextMenuStrip = New ContextMenuStrip

        vfpContextMenuStrip.Items.Add(menuItemInsertCell)
        vfpContextMenuStrip.Items.Add(menuItemDeleteCell)


        'Add functionality for ToolStripMenuItem1 (Maximize) click
        AddHandler menuItemDeleteCell.Click, AddressOf menuItemDeleteCell_Click

        'Add functionality for ToolStripMenuItem2 (Exit) click
        AddHandler menuItemInsertCell.Click, AddressOf menuItemInsertCell_Click

    End Sub

    Private Sub menuItemInsertCell_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf Me.vfpContextMenuStrip.SourceControl Is TextBox Then
            'for ucrValueFlagPeriod and ucrDirectionSpeedFlag
            Dim control = Me.vfpContextMenuStrip.SourceControl.Parent.Parent

            If (TypeOf control Is ucrValueFlagPeriod) OrElse (TypeOf control Is ucrDirectionSpeedFlag) Then
                'Start the shifting downwards
                Dim currentIndex As Integer = control.TabIndex
                Dim lstControls As New List(Of ucrValueView)
                Dim lstValues As New List(Of Object)

                'get the values to shift and the respective controls
                For Each ctr As ucrValueView In lstOrderedVfpControls
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
        If TypeOf Me.vfpContextMenuStrip.SourceControl Is TextBox Then
            'for ucrValueFlagPeriod and ucrDirectionSpeedFlag
            Dim control = Me.vfpContextMenuStrip.SourceControl.Parent.Parent

            If (TypeOf control Is ucrValueFlagPeriod) OrElse (TypeOf control Is ucrDirectionSpeedFlag) Then
                'Start the shifting upwards
                Dim currentIndex As Integer = control.TabIndex
                Dim lstControls As New List(Of ucrValueView)
                Dim lstValues As New List(Of Object)

                'get the values to shift and the respective controls
                For Each ctr As ucrValueView In lstOrderedVfpControls
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
