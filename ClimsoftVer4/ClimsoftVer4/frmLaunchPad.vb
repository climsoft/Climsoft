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

Public Class frmLaunchPad

    Private Sub btnStationInformation_Click(sender As Object, e As EventArgs) Handles btnStationInformation.Click
        formStation.Show()
    End Sub

    Private Sub btnSynopticData_Click(sender As Object, e As EventArgs) Handles btnSynopticData.Click
        formSynopRA1.Show()
    End Sub

    Private Sub btnElementInformation_Click(sender As Object, e As EventArgs) Handles btnElementInformation.Click
        formElement.Show()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FormLaunchPad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class