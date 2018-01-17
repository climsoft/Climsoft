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
Public Class ucrBaseDataLink
    Private clsDataDefinition As New DataCall

    ' ucrBaseDataLink is a base control for a control to connect to the database
    ' Infomation about how the control connects to the database will be here
    ' Including: reading/writing, which tables/fields/records to connect to

    ' Inherited controls:
    ' textbox, nud, checkbox, combobox, listbox etc.

    ' Inherited from these can be controls for common fields:
    ' station selector, element selector, tmax entry etc.

    ' 
    Public Sub SetField()

    End Sub
End Class