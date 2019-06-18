Public Class Form1


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridView1.Columns.Add("JanWin", "Win")
        Me.DataGridView1.Columns.Add("JanLoss", "Loss")
        Me.DataGridView1.Columns.Add("FebWin", "Win")
        Me.DataGridView1.Columns.Add("FebLoss", "Loss")
        Me.DataGridView1.Columns.Add("MarWin", "Win")
        Me.DataGridView1.Columns.Add("MarLoss", "Loss")
        Me.DataGridView1.Columns.Add("AprWin", "Win")
        Me.DataGridView1.Columns.Add("AprLoss", "Loss")
        Me.DataGridView1.Rows.Add("1", "2", "3", "2", "2", "2", "4", "2")
        For j As Integer = 0 To Me.DataGridView1.ColumnCount - 1
            Me.DataGridView1.Columns(j).Width = 45
        Next
        Me.DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.DataGridView1.ColumnHeadersHeight = Me.DataGridView1.ColumnHeadersHeight * 2
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter






    End Sub
    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex > -1 Then
            Dim r2 As Rectangle = e.CellBounds
            r2.Y += e.CellBounds.Height / 2
            r2.Height = e.CellBounds.Height / 2
            e.PaintBackground(r2, True)
            e.PaintContent(r2)
            e.Handled = True
        End If

        If e.RowIndex = -1 Then ' AndAlso e.ColumnIndex = 1 Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(270)
            e.Graphics.DrawString(e.FormattedValue, e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
        End If

    End Sub
    Private Sub DataGridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged
        Dim rtHeader As Rectangle = Me.DataGridView1.DisplayRectangle
        rtHeader.Height = Me.DataGridView1.ColumnHeadersHeight / 2
        Me.DataGridView1.Invalidate(rtHeader)
    End Sub
    Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
        Dim monthes As String() = {"January", "February", "March", "April"}
        Dim j As Integer = 0
        While j < 8
            Dim r1 As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(j, -1, True)
            Dim w2 As Integer = Me.DataGridView1.GetCellDisplayRectangle(j + 1, -1, True).Width
            r1.X += 1
            r1.Y += 1
            r1.Width = r1.Width + w2 - 2
            r1.Height = r1.Height / 2 - 2
            e.Graphics.FillRectangle(New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1)
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(monthes(j \ 2), Me.DataGridView1.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
            j += 2
        End While
    End Sub
    'Private Sub dataGridView1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles DataGridView1.Paint
    '    Try
    '        Dim colList = "Mon,tues,wed"
    '        Dim clst As String() = colList.ToString.Split(",")
    '        Dim j As Integer = 0

    '        While j < DataGridView1.ColumnCount - 1 '10
    '            Dim r1 As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(j, -1, True) 'see -1 that is row=-1 means header cell
    '            Dim w2 As Integer = Me.DataGridView1.GetCellDisplayRectangle(j + 1, -1, True).Width
    '            r1.X += 0
    '            r1.Y += 0
    '            '            r1.Width = r1.Width + w2 -2
    '            r1.Width = ((DataGridView1.ColumnCount / clst.Count) * w2)
    '            r1.Height = r1.Height / 2

    '            e.Graphics.FillRectangle(New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1)
    '            Dim format As New StringFormat()
    '            format.Alignment = StringAlignment.Center
    '            format.LineAlignment = StringAlignment.Center

    '            e.Graphics.DrawString(clst(j / ((DataGridView1.ColumnCount / (clst.Count + 1)) + 1)), Me.DataGridView1.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
    '            j += (DataGridView1.ColumnCount / clst.Count)
    '        End While
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub DataGridView1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
        Dim rtHeader As Rectangle = Me.DataGridView1.DisplayRectangle
        rtHeader.Height = Me.DataGridView1.ColumnHeadersHeight / 2
        Me.DataGridView1.Invalidate(rtHeader)
    End Sub
End Class