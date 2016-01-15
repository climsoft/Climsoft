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

Imports RDotNet
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public Class clsRInterface
    ' R interface class. Each instance of the class has its own REngine instance
    Dim climateObjectPath As String = "static/ClimateObject/" ' Location of ClimateObject library
    Dim engine As REngine


    Sub New()
        ' Each clsRInterface instance has it's own REngine. The engine is only initialised once per instance
        Dim climsoftSettings = New clsClimsoftSettings ' TODO: move environment setUp to CLIMSOFT initialisation
        climsoftSettings.rEnvironmentSetUp()

        ' When a new clsRInterface is created, and R engine is started
        engine = REngine.GetInstance()
        engine.Initialize()

        ' TODO: Add destructor to dispose of engine, see https://msdn.microsoft.com/en-us/library/2z08e49e%28v=vs.90%29.aspx
        ' You should always dispose of the REngine properly.
        ' After disposing of the engine, you cannot reinitialize nor reuse it
        ' engine.Dispose()
    End Sub


    Sub productCDTExample()
        ' The following (temporary) example demonstrate how to interface with R.
        ' This procedure is currently being called by selecting Special Products > CPT
        ' from the Products section option in CLIMSOFT
        ' Note that data selection is hard-coded here instead of being selected by the user
        Dim ds As DataSet
        Dim saveFileDialog As New SaveFileDialog()
        Dim saveFileLocation As String

        ' warning: temporary creation of a test DataSet
        ds = testDataSet("observationfinal", "precip")
        precipDataFrame(Me.engine, ds) ' df dataframe in R engine contains precip data
        Me.createClimateObject(ds, "precip")

        ' A save dialog is used to select where CDT output should be written
        saveFileDialog.Filter = "Text|*.txt"
        saveFileDialog.Title = "Save CDT data as text file"
        saveFileDialog.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog.FileName <> "" Then
            ' Warning: the code below assumes that createClimateObject has already been
            ' called and that a ClimateObject called `CO` is known to the R engine
            saveFileLocation = Replace(saveFileDialog.FileName, "\", "/")
            engine.Evaluate(String.Format("CO$output_for_CDT(filename=""{0}"", interested_variables=rain_label)", saveFileLocation))
        End If
    End Sub


    Sub productHistogramExample()
        ' The following (temporary) examples demonstrate how to interface with R.
        ' This procedure is currently being called by selecting Graphics > Histograms
        ' from the Products section option in CLIMSOFT
        ' Note that data slection is hard-coded here instead of being selected by the user
        Dim ds As DataSet
        ' warning: temporary creation of a test DataSet
        ds = testDataSet("observationfinal", "precip")

        'windRoseDataFrame(Me.engine, ds)
        precipDataFrame(Me.engine, ds) ' df dataframe in R engine contains precip data

        Me.createClimateObject(ds, "precip")
        'myInterface.engine.Evaluate("CO$cumulative_exceedance_graphs(interest_var=rain_label)")   ' ""rain""
        Me.engine.Evaluate("CO$plot_missing_values_rain()")
        Me.engine.Evaluate("CO$graphics_frontend()")
    End Sub


    Public Sub createClimateObject(ds As DataSet, dataRequired As String)
        ' Before calling createClimateObject myInterface.engine must contain a valid dataframe

        ' Update this method to check for the existance of a valid dataframe (or pass dataframe by name)
        ' If using wind data then if looks like this
        '            stationId,          obsDatetime,  windSpeed, windDirection
        '             67774010,  21/11/2005 09:00:00,          6,            12
        Dim message As String()
        Try
            ' The ClimateObject codebase contains a SourcingScript that is used access the ClimateObject via R.Net
            message = engine.Evaluate("source('" & climateObjectPath & "R/SourcingScript.R')").AsCharacter().ToArray()

            If dataRequired = "wind" Then
                message = engine.Evaluate("ClimateCO(data_tables=list(df),data_tables_variables=list(list(station=""stationId"" , date_asstring=""obsDatetime"" , wind_speed=""windSpeed"" , wind_direction=""windDirection"" )))").AsCharacter().ToArray()
                'MsgBox(String.Format("R answered: '{0}'", message(0)))
                'engine.Evaluate("CO$windrose()")
            ElseIf dataRequired = "precip" Then
                'message = engine.Evaluate("ClimateCO(data_tables=list(df),data_tables_meta_data=list(list(season_start_day=183)))").AsCharacter().ToArray()
                message = engine.Evaluate("ClimateCO(data_tables=list(df))").AsCharacter().ToArray()
                'MsgBox(String.Format("R answered: '{0}'", message(0)))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Function genericDataFrame(ds As DataSet, dataFrameName As String) As Integer ' RDotNet.DataFrame
        ' This method is currently incomplete and is not being used.
        ' genericDataFrame will take any DataSet object and generate the appropriate corresponding R DataFrame

        ' Ideally we would use df = engine.CreateDataFrame(columnArray), but here we use a simplier method
        '    System.Data.DataColumnCollection --> System.Collections.IEnumerable()

        ' Given a DataSet, ds, containing one or more tables, construct and return the corresponding
        ' data frame(s)
        Dim table As DataTable
        Dim maxRows As Integer
        Dim columnNames As New ArrayList()
        Dim columnArray As New ArrayList()

        If ds.Tables.Count = 0 Then
            MsgBox("Unable to create products, the data set does not contain any tables")
        End If
        'If ds.Tables.Count > 1 Then
        '    MsgBox("Unable to create products, the data set contains too many tables. Currently only data sets with a single table are supported")
        'End If

        engine = Me.engine

        For Each table In ds.Tables
            ' Loop to support multiple tables in the future. Use table.TableName
            If table.TableName <> "observationfinal" Then
                Continue For
            End If

            maxRows = table.Rows.Count
            Dim data(maxRows) As ArrayList
            Dim columnData(table.Columns.Count)
            ' We'll want to pass column names to CreateDataFrame
            For Each column In table.Columns
                columnNames.Add(column.ColumnName)
                'Dim statement = String.Format("ColumnName1 = '{0}'", column.columnName)
                'Dim rows() As DataRow = table.Select(statement)
                'MsgBox(rows.Count)

                'Dim eg As System.Data.DataColumn
                '                   eg.Container.
                MsgBox(column.ColumnName & " " & column.DataType.FullName)
                'MsgBox()
                'MsgBox(TypeName(column))
            Next column
            'MsgBox(TypeName(columnArray))
            'MsgBox(TypeName(columnArray(0)))

        Next table

        ' Return DataFrame
        Return 0
    End Function

End Class


' The following code is temporary and will not form part of clsRInterface
Module TemporaryInterfaceCode

    Function testDataSet(tableName As String, dataRequired As String) As DataSet
        ' A test function that returns a test DataSet object
        Dim ds As New DataSet
        Dim sql As String

        If dataRequired = "wind" Then
            ' Select wind data
            sql = " SELECT recordedFrom as StationId, obsDatetime," & _
                    "        MAX(IF(describedBy = '111', value, NULL)) AS '111', " & _
                    "        MAX(IF(describedBy = '112', value, NULL)) AS '112' " & _
                    " FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value" & _
                    "       FROM observationfinal" & _
                    "       WHERE (RecordedFrom = '67774010') AND (describedBy = '111' OR describedBy = '112')" & _
                    " ORDER BY recordedFrom, obsDatetime) t" & _
                    " GROUP BY StationId, obsDatetime;"
        ElseIf dataRequired = "precip" Then
            ' Select precip data (use old CLIMSOFT names recognised by the ClimateObject)
            sql = "SELECT recordedFrom as Station_id, obsDatetime AS Recorded_at, obsValue AS Prec" & _
                  " FROM observationfinal" & _
                  " WHERE (RecordedFrom = '67774010') AND (describedBy = 5)" & _
                  " ORDER BY recordedFrom, obsDatetime"
        Else
            sql = ""
        End If

        Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim MyConnectionString As String = "server=127.0.0.1; uid=root; pwd=admin; database=mariadb_climsoft_db_v4"
        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, tableName)
            'MsgBox(ds.Tables(tableName).Rows.Count)

            conn.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        Return ds
    End Function


    Sub precipDataFrame(engine As REngine, ds As DataSet)
        ' This is a temporary method to create the dataframe that is required to create a windrose product. This
        ' method will be replaced by genericDataFrame() which can be called with any input and will return the
        ' comparable dataframe.

        ' Oddly, if the tableName does not exist the current thread of execution ceases without error
        Dim table = ds.Tables("observationfinal")
        Dim maxRows = table.Rows.Count
        ' MsgBox(maxRows)
        Dim stationIds(maxRows - 1) As String
        Dim obsDatetime(maxRows - 1) As String
        Dim obs5Value(maxRows - 1) As Double

        For rowNumber As Integer = 0 To maxRows - 1
            stationIds(rowNumber) = table.Rows(rowNumber).Item("Station_id")
            obsDatetime(rowNumber) = table.Rows(rowNumber).Item("Recorded_at")
            obs5Value(rowNumber) = table.Rows(rowNumber).Item("Prec")
        Next

        Dim v1 As CharacterVector = engine.CreateCharacterVector(stationIds)
        Dim v2 As CharacterVector = engine.CreateCharacterVector(obsDatetime)
        Dim v3 As NumericVector = engine.CreateNumericVector(obs5Value)
        engine.SetSymbol("v1", v1)
        engine.SetSymbol("v2", v2)
        engine.SetSymbol("v3", v3)

        ' Create the data frame in the R engine directly
        Try
            Dim Message = engine.Evaluate("df<-data.frame(""Station_id"" = v1, ""Recorded_at"" = v2, ""Prec"" = v3, stringsAsFactors=FALSE)").AsCharacter().ToArray()
            ' Display a column from the data frame
            'MsgBox(Message(2))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Sub windRoseDataFrame(engine As REngine, ds As DataSet)
        ' This is a temporary method to create the dataframe that is required to create a windrose product. This
        ' method will be replaced by genericDataFrame() which can be called with any input and will return the
        ' comparable dataframe.

        ' Oddly, if the tableName does not exist the current thread of execution ceases without error
        Dim table = ds.Tables("observationfinal")
        Dim maxRows = table.Rows.Count
        ' MsgBox(maxRows) ' 49 rows
        Dim stationIds(maxRows - 1) As String
        Dim obsDatetime(maxRows - 1) As String
        Dim obs111Value(maxRows - 1) As Double
        Dim obs112Value(maxRows - 1) As Double

        For rowNumber As Integer = 0 To maxRows - 1
            stationIds(rowNumber) = table.Rows(rowNumber).Item("StationId")
            obsDatetime(rowNumber) = table.Rows(rowNumber).Item("obsDatetime")
            obs111Value(rowNumber) = table.Rows(rowNumber).Item("111")
            obs112Value(rowNumber) = table.Rows(rowNumber).Item("112")
        Next

        'Dim charVec As CharacterVector = engine.CreateCharacterVector({"Hello, R world!, .NET speaking"})
        MsgBox(stationIds(2))
        Dim v1 As CharacterVector = engine.CreateCharacterVector(stationIds)
        Dim v2 As CharacterVector = engine.CreateCharacterVector(obsDatetime)
        Dim v3 As NumericVector = engine.CreateNumericVector(obs111Value)
        Dim v4 As NumericVector = engine.CreateNumericVector(obs112Value)
        engine.SetSymbol("v1", v1)
        engine.SetSymbol("v2", v2)
        engine.SetSymbol("v3", v3)
        engine.SetSymbol("v4", v4)

        ' Create the data frame in the R engine directly
        Try
            Dim Message = engine.Evaluate("df<-data.frame(""stationId"" = v1, ""obsDatetime"" = v2, ""windSpeed"" = v3, ""windDirection"" = v4, stringsAsFactors=FALSE)").AsCharacter().ToArray()
            MsgBox(Message(0))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        ' Alternative (old) method: create the required R.dataframe function
        If False Then
            Dim rLibrary As String = Application.StartupPath().Replace("ClimsoftVer4\bin\Debug", "rVbClimsoft.R")
            ' escape backslash or replace with forward slash
            rLibrary = rLibrary.Replace("\", "/")
            ' If the file is not found the the current execution ceases without error
            engine.Evaluate("source('" & rLibrary & "')")
            Dim resultNew As DataFrame = engine.Evaluate("R.dataframe(v1,v2,v3,v4)").AsDataFrame
            ' to push a dataframe to R you need to use SetSymbol
            engine.SetSymbol("df", resultNew)
            MsgBox(stationIds(0) & " " & obsDatetime(0) & " " & obs111Value(0) & " " & obs112Value(0))
        End If
    End Sub

End Module