Public Class frmTDCFindicators
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString, sql As String
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet

    Dim kount As Integer
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Dim optsection As Integer

        Try
            'dbConnectionString = frmLogin.txtusrpwd.Text
            'dbconn.ConnectionString = dbConnectionString
            'dbconn.Open()

            ' set value for the optional section
            If chkOptionalSectionInclusion.Checked() = True Then
                optsection = 1
            Else
                optsection = 0
            End If

            sql = "INSERT INTO bufr_indicators (Tmplate,Msg_Header,BUFR_Edition,Originating_Centre,Originating_SubCentre,Update_Sequence,Optional_Section,Data_Category,Intenational_Data_SubCategory,Local_Data_SubCategory,Master_table,Local_Table) VALUES('" & cboTemplate.Text & "','" & txtMsgHeader.Text & "','" & txtBUFREditionNumber.Text & "','" & txtOriginatingGeneratingCentre.Text & "','" & txtOriginatingGeneratingSubCentre.Text & "','" & txtUpdateSequenceNumber.Text & "','" & optsection & "','" & txtDataCategory.Text & "','" & txtInternationalDataSubCategory.Text & "','" & txtLocalDataSubCategory.Text & "','" & txtMastersTableVersionNumber.Text & "','" & txtLocalTableVersionNumber.Text & "');"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ' Remove timeout requirement
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "indicators")
            Kount = ds.Tables("bufr_indicators").Rows.Count

            'MsgBox(sql)

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

            'Execute query
            objCmd.ExecuteNonQuery()
            dbconn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
        dbconn.Close()
    End Sub

    Private Sub cmdUpadate_Click(sender As Object, e As EventArgs) Handles cmdUpadate.Click
        Dim sql As String
        Dim optsection As Integer

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()

            ' set value for the optional section
            If chkOptionalSectionInclusion.Checked() = True Then
                optsection = 1
            Else
                optsection = 0
            End If

            sql = "Update bufr_indicators set Msg_Header= '" & txtMsgHeader.Text & "',BUFR_Edition= '" & txtBUFREditionNumber.Text & "',Originating_Centre= '" & txtOriginatingGeneratingCentre.Text & "',Originating_SubCentre= '" & txtOriginatingGeneratingSubCentre.Text & "',Update_Sequence= '" & txtUpdateSequenceNumber.Text & "',Optional_Section= '" & optsection & "',Data_Category= '" & txtDataCategory.Text & "',Intenational_Data_SubCategory= '" & txtInternationalDataSubCategory.Text & "',Local_Data_SubCategory= '" & txtLocalDataSubCategory.Text & "',Master_table= '" & txtMastersTableVersionNumber.Text & "',Local_Table= '" & txtLocalTableVersionNumber.Text & _
                "' where tmplate= '" & cboTemplate.Text & "';"
            'MsgBox(sql)

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

            'Execute query
            objCmd.ExecuteNonQuery()
            dbconn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Dim ctl As Control

        cboTemplate.Text = ""
        txtMsgHeader.Text = ""
        For Each ctl In Me.grpIndicators.Controls
            If Strings.Left(ctl.Name, 3) = "txt" Then ctl.Text = ""
        Next
        ' Clear form
    End Sub

    Private Sub frmTDCFindicators_Load(sender As Object, e As EventArgs) Handles Me.Load

        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()

        Try
            sql = "select * from bufr_indicators;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ' Remove timeout requirement
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "indicators")
            kount = ds.Tables("indicators").Rows.Count

            For i = 0 To kount - 1
                cboTemplate.Items.Add(ds.Tables("indicators").Rows(i).Item("Tmplate"))
            Next
            cboTemplate.Text = ds.Tables("indicators").Rows(0).Item("Tmplate")

            dbconn.Close()

            ClsTranslations.TranslateForm(Me)

        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
    End Sub


    Private Sub cboTemplate_TextChanged(sender As Object, e As EventArgs) Handles cboTemplate.TextChanged

        If Len(cboTemplate.Text) <> 0 Then
            Try
                dbconn.Close()
                dbConnectionString = frmLogin.txtusrpwd.Text
                dbconn.ConnectionString = dbConnectionString
                dbconn.Open()

                sql = "select * from bufr_indicators where Tmplate = '" & cboTemplate.Text & "';"
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
                ' Remove timeout requirement
                da.SelectCommand.CommandTimeout = 0

                ds.Clear()
                da.Fill(ds, "indicators")

                txtMsgHeader.Text = ds.Tables("indicators").Rows(0).Item("Msg_Header")
                txtBUFREditionNumber.Text = ds.Tables("indicators").Rows(0).Item("BUFR_Edition")
                txtOriginatingGeneratingCentre.Text = ds.Tables("indicators").Rows(0).Item("Originating_Centre")
                txtOriginatingGeneratingSubCentre.Text = ds.Tables("indicators").Rows(0).Item("Originating_SubCentre")
                txtUpdateSequenceNumber.Text = ds.Tables("indicators").Rows(0).Item("Update_Sequence")
                chkOptionalSectionInclusion.Checked = ds.Tables("indicators").Rows(0).Item("Optional_Section")
                txtDataCategory.Text = ds.Tables("indicators").Rows(0).Item("Data_Category")
                txtInternationalDataSubCategory.Text = ds.Tables("indicators").Rows(0).Item("Intenational_Data_SubCategory")
                txtLocalDataSubCategory.Text = ds.Tables("indicators").Rows(0).Item("Local_Data_SubCategory")
                txtMastersTableVersionNumber.Text = ds.Tables("indicators").Rows(0).Item("Master_table")
                txtLocalTableVersionNumber.Text = ds.Tables("indicators").Rows(0).Item("Local_Table")
                dbconn.Close()

            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cboTemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTemplate.SelectedIndexChanged

    End Sub
End Class