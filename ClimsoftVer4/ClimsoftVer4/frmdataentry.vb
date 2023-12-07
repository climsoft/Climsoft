' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
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

Public Class frmDataEntry

    Private Sub frmDataEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dataCall As New DataCall
            Dim dataTable As DataTable
            lstViewForms.Items.Clear()
            'set the database name and columns, set the key field for updating, then add the retrieved data to the listview
            dataCall.SetTableNameAndFields("data_forms", {"form_name", "description"})
            dataCall.SetFilter("selected", "=", 1)
            dataTable = dataCall.GetDataTable()
            For Each row As DataRow In dataTable.Rows
                'lstViewForms.Items.Add(New ListViewItem({row.Item("form_name"), ClsTranslations.GetTranslation(row.Item("description"))}))
                lstViewForms.Items.Add(New ListViewItem({row.Item("form_name"), row.Item("description")}))
            Next

            If lstViewForms.Items.Count = 0 Then
                Exit Sub
            End If
            'if there are records, then adjust the height of the listview. Done this way because of climsoft operators
            If lstViewForms.Items.Count > 0 Then
                lstViewForms.Height = ((lstViewForms.Items.Count + 1) * lstViewForms.Items.Item(0).Bounds.Height) + 30
            End If

            ClsTranslations.TranslateForm(Me)
            'todo in future this will be done automatically by TranslateForms(Me)
            ClsTranslations.TranslateComponent(lstViewForms, False)

        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles lstViewForms.DoubleClick
        OpenSelectedForm()
    End Sub

    Private Sub lstViewForms_KeyDown(sender As Object, e As KeyEventArgs) Handles lstViewForms.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenSelectedForm()
        End If
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        OpenSelectedForm()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm")
    End Sub

    Private Sub OpenSelectedForm()
        Dim idx As Integer
        Dim frm As String

        Try
            'todo. code needs to be changed. texts in the list view may be translated
            If lstViewForms.SelectedItems.Count > 0 Then
                Select Case lstViewForms.SelectedItems.Item(0).Text
                    Case "formSynoptic2RA1"
                        frmNewSynopticRA1.Show()
                    Case "form_daily1"
                        formDaily1.Show()
                    Case "form_daily2"
                        frmNewFormDaily2.Show()
                    Case "form_hourly"
                        'form_hourly.Show()
                        frmNewHourly.Show()
                    Case "form_monthly"
                        frmNewMonthly.Show()
                    Case "form_upperair1"
                        formUpperAir.Show()
                    Case "form_hourlywind"
                        frmNewHourlyWind.Show()
                    Case "form_agro1"
                        formAgro1.Show()
                    Case "form_synoptic2_caribbean"
                        formSynopticCaribbean.Show()
                    Case "form_synoptic2_TDCF"
                        formSynoptic2.Show()
                    Case Else
                        frm = lstViewForms.SelectedItems.Item(0).Text
                        MsgBox(ClsTranslations.GetTranslation("Form") & " " & frm & " " & ClsTranslations.GetTranslation("not yet implemented"))
                        idx = lstViewForms.SelectedItems.Item(0).Index
                        lstViewForms.Items(idx).Remove()
                        formUnselect(frm)
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub formUnselect(frm As String)
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim sql As String
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try
            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()

            sql = "update data_forms set selected = 0  where form_name = '" & frm & "';"

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class