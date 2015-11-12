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

Public Class frmDataSelector
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim count As Integer
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim maxRows As Integer
    Dim rInterface As New clsRInterface
    Dim sql As String


    Private Sub frmDataSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()

            sql = "SELECT stationId, stationName FROM station ORDER BY stationName"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "station")
            ' conn.Close()
            maxRows = ds.Tables("station").Rows.Count

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        For count = 0 To maxRows - 1
            cboStation.Items.Add(ds.Tables("station").Rows(count).Item("stationName"))
        Next

        sql = "SELECT elementId, description FROM obselement ORDER BY description"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "obselement")
        ' conn.Close()
        maxRows = ds.Tables("obselement").Rows.Count

        For count = 0 To maxRows - 1
            cboElement.Items.Add(ds.Tables("obselement").Rows(count).Item("description"))
        Next

        lvwStation.Columns.Clear()
        lvwStation.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        lvwStation.Columns.Add("Station Name", 400, HorizontalAlignment.Left)
        lvwElement.Columns.Clear()
        lvwElement.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
        lvwElement.Columns.Add("Element Details", 400, HorizontalAlignment.Left)
    End Sub

    Private Sub cboStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStation.SelectedIndexChanged
        For Each row In ds.Tables("station").Select("stationName='" & cboStation.Text & "'")
            lvwStation.Items.Add(New ListViewItem({row.Item("stationId"), row.Item("stationName")}))
        Next
    End Sub

    Private Sub cboElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboElement.SelectedIndexChanged
        For Each row In ds.Tables("obselement").Select("description='" & cboElement.Text & "'")
            lvwElement.Items.Add(New ListViewItem({row.Item("elementId"), row.Item("description")}))
        Next
    End Sub

    Private Sub cmdDeleteStation_Click(sender As Object, e As EventArgs) Handles cmdDeleteStation.Click
        For i = 0 To lvwStation.Items.Count - 1
            If lvwStation.Items(i).Selected Then
                lvwStation.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub cmdClearAllStation_Click(sender As Object, e As EventArgs) Handles cmdClearAllStation.Click
        For Each item In lvwStation.Items
            item.Remove()
        Next
    End Sub

    Private Sub cmdDeleteElement_Click(sender As Object, e As EventArgs) Handles cmdDeleteElement.Click
        For i = 0 To lvwElement.Items.Count - 1
            If lvwElement.Items(i).Selected Then
                lvwElement.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub cmdClearAllElement_Click(sender As Object, e As EventArgs) Handles cmdClearAllElement.Click
        For Each item In lvwElement.Items
            item.Remove()
        Next
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim stations As String = ""
        Dim elements As String = ""
        Dim dateStart As String = dtpStartDate.Value.ToString("yyyy-MM-dd")
        Dim dateEnd As String = dtpEndDate.Value.ToString("yyyy-MM-dd")
        Dim sql As String
        Dim where As String = ""

        If lvwStation.Items.Count > 0 Then
            stations = String.Format("recordedFrom='{0}'", lvwStation.Items(0).Text)
            For i = 1 To lvwStation.Items.Count - 1
                stations = stations & String.Format(" OR recordedFrom='{0}'", lvwStation.Items(i).Text)
            Next
        End If

        If lvwElement.Items.Count > 0 Then
            elements = String.Format("describedBy={0}", lvwElement.Items(0).Text)
            For i = 1 To lvwElement.Items.Count - 1
                elements = elements & String.Format(" OR describedBy={0}", lvwElement.Items(i).Text)
            Next
        End If

        If stations <> "" OrElse elements <> "" Then
            where = "WHERE {0} {1} {2}"
            If stations <> "" AndAlso elements <> "" Then
                where = String.Format(where, String.Format("({0})", stations), "AND", String.Format("({0})", elements))
            ElseIf stations <> "" Then
                where = String.Format(where, String.Format("({0})", stations), "", "")
            Else
                where = String.Format(where, "", "", String.Format("({0})", elements))
            End If
        End If

        If where <> "" Then
            where = where & " AND "
        Else
            where = "WHERE "
        End If
        where = where & String.Format("(obsDatetime > '{0}' AND obsDatetime < '{1}')", dateStart, dateEnd)

        sql = String.Format("SELECT * FROM observationfinal {0}", where)
        'MsgBox(sql)

        'Try
        rInterface.createClimateObjectFromSQL(sql)
        '    rInterface.engine.Evaluate("CO$plot_missing_values_rain()")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        frmProductsClimateObj.ShowDialog()
        Me.Close()
    End Sub
End Class