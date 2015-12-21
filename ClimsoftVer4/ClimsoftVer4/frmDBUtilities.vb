' CLIMSOFT - Climate Database Management System
' Copyright (C) 2015
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

Imports System.Windows.Forms

Public Class frmDBUtilities
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ToolStripContainer1_TopToolStripPanel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub formDbUtilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Dim col As String
        Dim itm As New ListViewItem

        ListViewDbUtil.Visible = True
        cmdUpload.Visible = True
        conn.Close()
        ListViewDbUtil.Clear()
        ListViewDbUtil.Columns.Clear()

        'ListViewDbUtil.Columns.Add("Form Name", 100, HorizontalAlignment.Left)
        ListViewDbUtil.Columns.Add("Select Form to upload", 600, HorizontalAlignment.Left)
        Try
            MyConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = MyConnectionString
            conn.Open()

            Sql = "SELECT selected,form_name, description FROM data_forms;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")

            For i = 0 To ds.Tables("data_forms").Rows.Count - 1
                'col(0) = ds.Tables("data_forms").Rows(i).Item(1)
                If ds.Tables("data_forms").Rows(i).Item(0) = 1 Then
                    col = ds.Tables("data_forms").Rows(i).Item(2)
                    itm = New ListViewItem(col)
                    ListViewDbUtil.Items.Add(itm)
                End If
                'If ds.Tables("data_forms").Rows(i).Item(0) = 1 Then lstvForms.Items(i).Checked = True
            Next
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
