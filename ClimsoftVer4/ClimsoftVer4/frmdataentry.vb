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

Public Class frmKeyEntry

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim kounts As Integer
    Dim keyentrymode As Integer


    Private Sub frmKeyEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4;"
        'TODO: This line of code loads data into the 'Dataforms.data_forms' table


        MyConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = MyConnectionString
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try
            ' Add a record for key entry mode if not exists
            sql = "ALTER TABLE `data_forms` ADD COLUMN `entry_mode` TINYINT(2) NOT NULL DEFAULT '0' AFTER `sequencer`;"
            conn.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            conn.Close()
        Catch ex As Exception
            If ex.HResult <> -2147467259 Then 'Existing record
                MsgBox(ex.HResult & " " & ex.Message)
            End If
            conn.Close()
        End Try



        'MyConnectionString = frmLogin.txtusrpwd.Text
        ListView1.Columns.Add("Form Name", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Form Details", 600, HorizontalAlignment.Left)

        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM data_forms"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")
            conn.Close()
            'MsgBox("Dataset Field !", MsgBoxStyle.Information)

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

        maxRows = ds.Tables("data_forms").Rows.Count

        Dim str(2) As String
        Dim itm As ListViewItem
        ListView1.Items.Clear()
        For kount = 0 To maxRows - 1 Step 1
            'MsgBox(ds.Tables("data_forms").Rows(kount).Item("selected"))
            If ds.Tables("data_forms").Rows(kount).Item("selected") = 1 Then
                str(0) = ds.Tables("data_forms").Rows(kount).Item("table_name")
                str(1) = ds.Tables("data_forms").Rows(kount).Item("description")
                itm = New ListViewItem(str)
                ListView1.Items.Add(itm)
            End If
        Next
        ' MsgBox(ListView1.Items.Count)
        'MsgBox((ListView1.Height - 46) / ListView1.Items.Count)

        ListView1.Height = 60 + 23 * (ListView1.Items.Count - 1)

        ' Get and list the database name
        lblDb.Text = Mid(frmLogin.cmbDatabases.Items.Item(0), 1, Len(frmLogin.cmbDatabases.Items.Item(0)) - 1)

        ''Get the key entry mode
        'Try
        '    sql = "select keyValue from regkeys where keyName='key14';"
        '    conn.Open()
        '    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ds.Clear()
        '    da.Fill(ds, "regkeys")
        '    keyentrymode = ds.Tables("regkeys").Rows(0).Item(0)
        '    conn.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    conn.Close()
        'End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        For kount = 0 To ListView1.Items.Count - 1
            If ListView1.Items(kount).Selected = True Then
                'MsgBox("Form " & ListView1.Items(kount).Text & " Selected")
                'formSynopRA1.Show()
                Open_Form(ListView1.Items(kount).Text)
            End If
        Next
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress

        For kount = 0 To ListView1.Items.Count - 1
            If ListView1.Items(kount).Selected = True Then
                Open_Form(ListView1.Items(kount).Text)

            End If
        Next

    End Sub

    Sub Open_Form(frm As String)

        Select Case frm
            Case "form_synoptic_2_ra1"
                frmNewSynopticRA1.Show()
            Case "form_daily1"
                formDaily1.Show()
            Case "form_daily2"
                frmNewFormDaily2.Show()
            Case "form_hourly"
                frmNewHourly.Show()
            Case "form_monthly"
                frmNewMonthly.Show()
            Case "form_upperair1"
                form_upperair1.Show()
            Case "form_hourlywind"
                frmNewHourlyWind.Show()
            Case "form_agro1"
                'form_agro1.Show()
                'frmNewAgroMet.Show()
                frmNewAgrometKenya.Show()
            Case "form_synoptic2_caribbean"
                formSynopticCaribbean.Show()
        End Select
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HelpProvider1.GetHelpKeyword(Me))
    End Sub




    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        For kount = 0 To ListView1.Items.Count - 1
            If ListView1.Items(kount).Selected = True Then
                Open_Form(ListView1.Items(kount).Text)
            End If
        Next
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm")
    End Sub
End Class