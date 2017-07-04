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

Public Class dataEntryGlobalRoutines

    Public Sub messageBoxNoPreviousRecord()
        MsgBox("No more previous record!", MsgBoxStyle.Exclamation)
    End Sub
    Public Sub messageBoxNoNextRecord()
        MsgBox("No more next record!", MsgBoxStyle.Exclamation)
    End Sub
    Public Sub messageBoxOperationCancelled()
        MsgBox("Operation cancelled!", MsgBoxStyle.Information)
    End Sub
    Public Sub messageBoxRecordedUpdated()
        MsgBox("Record updated successfully!", MsgBoxStyle.Information)
    End Sub
    Public Sub messageBoxCommit()
        MsgBox("New record added to database table!", MsgBoxStyle.Information)
    End Sub
    Public Function getFlagTexboxSuffix(ByVal strVal As String, ByRef ctl As Control) As String
        'Locates the texbox for the flag corresponding to the value texbox
        Dim obsValColIndex As Integer, flagColIndex As Integer
        Dim flagTextBoxSuffix As String
        'flagTextBoxSuffix = ""
        'Get observation value column index from texbox name. For form_synoptic_2_ra1 table, the names of texboxes for observation values
        ' have a suffix similar to the suffix of the name of the corresponding value field in the data table. The same applies to the suffixes
        'for flag texbox names. In both cases the suffixes have three digits, with trailing zeros where the numeric value of the 
        'suffix is less than 100.  And for this particular form the numeric value of the suffix gives the column index in the data table.
        obsValColIndex = Val(Strings.Right(ctl.Name, 3))
        'Get flag column index from observation value index. For form_synoptic_2_ra1 table,the difference between a flag column
        ' and the column of the associated flag is 49. 
        'To make this function applicable to other key-entry forms, further development work should get this figure from the data_forms table.
        flagColIndex = obsValColIndex + 49
        flagTextBoxSuffix = flagColIndex
        If Strings.Len(flagTextBoxSuffix) = 1 Then
            flagTextBoxSuffix = "00" & flagTextBoxSuffix
        ElseIf Strings.Len(flagTextBoxSuffix) = 2 Then
            flagTextBoxSuffix = "0" & flagTextBoxSuffix
        End If

        getFlagTexboxSuffix = flagTextBoxSuffix

    End Function
    Public Function calculateDewpoint(ByVal dryBulb As String, ByVal wetBulb As String) As String
        Dim Td_Fahrenheit As Object
        Dim Ed As Object

        Dim Tw_Fahrenheit As Object
        Dim Ew As Object
        Dim Ea As Object
        'Dim Tp As Object
        Dim Tp_Fahrenheit As Object
        Dim Tp_Celcius As Object
       
        Td_Fahrenheit = 9 / 5 * dryBulb + 32
        '2.71828183= natural number (e)
        Ed = 6.1078 * 2.71828183 ^ ((9.5939 * [Td_Fahrenheit] - 307.004) / (0.556 * [Td_Fahrenheit] + 219.522))
        Tw_Fahrenheit = 9 / 5 * wetBulb + 32
        Ew = 6.1078 * 2.71828183 ^ ((9.5939 * [Tw_Fahrenheit] - 307.004) / (0.556 * [Tw_Fahrenheit] + 219.522))
        Ea = [Ew] - 0.35 * ([Td_Fahrenheit] - [Tw_Fahrenheit])
        Tp_Fahrenheit = -1 * (Math.Log([Ea] / 6.1078) * 219.522 + 307.004) / (Math.Log([Ea] / 6.1078) * 0.556 - 9.59539)
        Tp_Celcius = 5 / 9 * ([Tp_Fahrenheit] - 32)
        
        '* Td in this case is Temperature drybulb,Tw wetbulb and Tp is dewpoint temperature
        'E is saturation vapour pressure(s.v.p.), hence Ed is s.v.p. over drybulb and Ew s.v.p. over wetbulb, Ea actual s.v.p.

        Tp_Celcius = Math.Round(Tp_Celcius, 0)
        calculateDewpoint = Tp_Celcius
    End Function
    Public Function calculateRH(ByVal dewPoint As String, ByVal dryBulb As String) As String
        Dim svp1 As Object
        Dim svp2 As Object
        'svp => saturation vapour pressure
        Dim RH As String
        'RH= svp(dewpoint)/svp(drybulb)
        svp1 = 6.11 * 10 ^ (7.5 * dewPoint / (237.3 + dewPoint))
        svp2 = 6.11 * 10 ^ (7.5 * dryBulb / (237.3 + dryBulb))
        RH = Math.Round((svp1 / svp2) * 100, 0)
        calculateRH = RH
    End Function
    Public Function calculateGeopotential(ppp As String, dryBulb As String, elevation As String, gpmStdLevel As String) As String
        Dim geoPotential As String, g As VariantType, R As VariantType, gamma As VariantType, K As VariantType
        '0.0065 is dry adiabatic lapse rate
        '9.80665 is acceleration due to gravity
        '287.04 is universal gas constant
        '273.15 is zero Kelvin
        gamma = 0.0065
        g = 9.80665
        R = 287.04
        K = dryBulb + 273.15
        geoPotential = Math.Round((elevation + (R / g) * Math.Log(ppp / gpmStdLevel) * (K + ((gamma / 2) * elevation))) / (1 + (R / g) * Math.Log(ppp / gpmStdLevel) * (gamma / 2)))
        calculateGeopotential = geoPotential
    End Function
    Public Function calculateMSLppp(ppp As String, dryBulb As String, elevation As String) As String
        Dim MSLppp As VariantType
       
        MSLppp = (ppp * (1 - 0.0065 * elevation / (dryBulb + 0.0065 * elevation + 273.15)) ^ -5.257) * 10
        '0.0065 is dry adiabatic lapse rate
        calculateMSLppp = MSLppp
    End Function
    Public Function checkIsNumeric(ByVal strVal As String, ctl As Control) As Boolean
        If IsNumeric(strVal) Then
            checkIsNumeric = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkIsNumeric = False
            ctl.BackColor = Color.Red
            MsgBox("Number expected!", MsgBoxStyle.Critical)        
        End If
    End Function
    Public Function checkLowerLimit(ctl As Control, ByVal obsVal As String, ByVal valLowerLimit As String) As Boolean
        If Val(valLowerLimit) <= Val(obsVal) Then
            checkLowerLimit = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkLowerLimit = False
            ctl.BackColor = Color.Cyan
            MsgBox("Value lower than lowerlimit of: " & valLowerLimit, MsgBoxStyle.Exclamation)
        End If
    End Function
    Public Function checkUpperLimit(ctl As Control, ByVal obsVal As String, ByVal valUpperLimit As String) As Boolean
        If Val(obsVal) <= Val(valUpperLimit) Then
            checkUpperLimit = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkUpperLimit = False
            ctl.BackColor = Color.Cyan
            MsgBox("Value higher than upperlimit of: " & valUpperLimit, MsgBoxStyle.Exclamation)
        End If
    End Function
    Public Function checkValidHour(ByVal strVal As String, ctl As Control) As Boolean
        If Val(strVal) >= 0 And Val(strVal) <= 23 Then
            checkValidHour = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkValidHour = False
            ctl.BackColor = Color.Red
            MsgBox("Invalid Hour!", MsgBoxStyle.Critical)
        End If
    End Function
    Public Function checkValidDay(ByVal strVal As String, ctl As Control) As Boolean
        If Val(strVal) >= 1 And Val(strVal) <= 31 Then
            checkValidDay = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkValidDay = False
            ctl.BackColor = Color.Red
            MsgBox("Invalid Day!", MsgBoxStyle.Critical)
        End If
    End Function
    Public Function checkValidMonth(ByVal strVal As String, ctl As Control) As Boolean
        If Val(strVal) >= 1 And Val(strVal) <= 12 Then
            checkValidMonth = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkValidMonth = False
            ctl.BackColor = Color.Red
            MsgBox("Invalid month!", MsgBoxStyle.Critical)
        End If
    End Function
   
    Public Function checkValidYear(ByVal strVal As String, ctl As Control) As Boolean
        If Val(strVal) >= 1000 And Val(strVal) <= 9999 Then
            checkValidYear = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkValidYear = False
            ctl.BackColor = Color.Red
            MsgBox("Invalid Year! Year must be between 1000 and 9999", MsgBoxStyle.Critical)
        End If
    End Function
    Public Function checkValidDate(ByVal dd As String, ByVal mm As String, ByVal yyyy As String, ctl As Control) As Boolean
        If IsDate(dd & "/" & mm & "/" & yyyy) Then
            checkValidDate = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkValidDate = False
            ctl.BackColor = Color.Red
            MsgBox("Invalid Date!", MsgBoxStyle.Critical)
        End If
    End Function
    Public Function checkFutureDate(ByVal dd As String, ByVal mm As String, ByVal yyyy As String, ctl As Control) As Boolean
        If DateValue(dd & "/" & mm & "/" & yyyy) <= Now() Then
            checkFutureDate = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkFutureDate = False
            ctl.BackColor = Color.Red
            MsgBox("Dates greater than today not accepted!", MsgBoxStyle.Critical)
        End If
    End Function
    Public Function checkExists(ByVal itemFound As Boolean, ctl As Control) As Boolean
        If itemFound = True Then
            checkExists = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkExists = False
            ctl.BackColor = Color.Red
            MsgBox("Item not found!", MsgBoxStyle.Critical)
        End If
    End Function
    Public Function checkPositiveValue(ByVal strVal As String, ctl As Control) As Boolean
        If Val(strVal) >= 0 Then
            checkPositiveValue = True
            ctl.BackColor = Color.White
            My.Computer.Keyboard.SendKeys("{TAB}")
        Else
            checkPositiveValue = False
            ctl.BackColor = Color.Red
            MsgBox("Negative value not accepted!", MsgBoxStyle.Critical)
        End If
    End Function
End Class
