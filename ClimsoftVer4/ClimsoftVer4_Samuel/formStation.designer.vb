﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim StationIdLabel As System.Windows.Forms.Label
        Dim StationNameLabel As System.Windows.Forms.Label
        Dim LatitudeLabel As System.Windows.Forms.Label
        Dim LongitudeLabel As System.Windows.Forms.Label
        Dim ElevationLabel As System.Windows.Forms.Label
        Dim GeoLocationMethodLabel As System.Windows.Forms.Label
        Dim GeoLocationAccuracyLabel As System.Windows.Forms.Label
        Dim OpeningDatetimeLabel As System.Windows.Forms.Label
        Dim ClosingDatetimeLabel As System.Windows.Forms.Label
        Dim CountryLabel As System.Windows.Forms.Label
        Dim AuthorityLabel As System.Windows.Forms.Label
        Dim AdminRegionLabel As System.Windows.Forms.Label
        Dim DrainageBasinLabel As System.Windows.Forms.Label
        Dim CptSelectionLabel As System.Windows.Forms.Label
        Dim StationOperationalLabel As System.Windows.Forms.Label
        Me.StationIdTextBox = New System.Windows.Forms.TextBox()
        Me.StationNameTextBox = New System.Windows.Forms.TextBox()
        Me.LatitudeTextBox = New System.Windows.Forms.TextBox()
        Me.LongitudeTextBox = New System.Windows.Forms.TextBox()
        Me.ElevationTextBox = New System.Windows.Forms.TextBox()
        Me.GeoLocationMethodTextBox = New System.Windows.Forms.TextBox()
        Me.GeoLocationAccuracyTextBox = New System.Windows.Forms.TextBox()
        Me.OpeningDatetimeDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ClosingDatetimeDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.AuthorityTextBox = New System.Windows.Forms.TextBox()
        Me.AdminRegionTextBox = New System.Windows.Forms.TextBox()
        Me.DrainageBasinTextBox = New System.Windows.Forms.TextBox()
        Me.CptSelectionTextBox = New System.Windows.Forms.TextBox()
        Me.StationOperationalTextBox = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.recNumberTextBox = New System.Windows.Forms.TextBox()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        StationIdLabel = New System.Windows.Forms.Label()
        StationNameLabel = New System.Windows.Forms.Label()
        LatitudeLabel = New System.Windows.Forms.Label()
        LongitudeLabel = New System.Windows.Forms.Label()
        ElevationLabel = New System.Windows.Forms.Label()
        GeoLocationMethodLabel = New System.Windows.Forms.Label()
        GeoLocationAccuracyLabel = New System.Windows.Forms.Label()
        OpeningDatetimeLabel = New System.Windows.Forms.Label()
        ClosingDatetimeLabel = New System.Windows.Forms.Label()
        CountryLabel = New System.Windows.Forms.Label()
        AuthorityLabel = New System.Windows.Forms.Label()
        AdminRegionLabel = New System.Windows.Forms.Label()
        DrainageBasinLabel = New System.Windows.Forms.Label()
        CptSelectionLabel = New System.Windows.Forms.Label()
        StationOperationalLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'StationIdLabel
        '
        StationIdLabel.AutoSize = True
        StationIdLabel.Location = New System.Drawing.Point(76, 37)
        StationIdLabel.Name = "StationIdLabel"
        StationIdLabel.Size = New System.Drawing.Size(55, 13)
        StationIdLabel.TabIndex = 1
        StationIdLabel.Text = "Station Id:"
        '
        'StationNameLabel
        '
        StationNameLabel.AutoSize = True
        StationNameLabel.Location = New System.Drawing.Point(290, 40)
        StationNameLabel.Name = "StationNameLabel"
        StationNameLabel.Size = New System.Drawing.Size(74, 13)
        StationNameLabel.TabIndex = 3
        StationNameLabel.Text = "Station Name:"
        '
        'LatitudeLabel
        '
        LatitudeLabel.AutoSize = True
        LatitudeLabel.Location = New System.Drawing.Point(85, 84)
        LatitudeLabel.Name = "LatitudeLabel"
        LatitudeLabel.Size = New System.Drawing.Size(48, 13)
        LatitudeLabel.TabIndex = 5
        LatitudeLabel.Text = "Latitude:"
        '
        'LongitudeLabel
        '
        LongitudeLabel.AutoSize = True
        LongitudeLabel.Location = New System.Drawing.Point(309, 84)
        LongitudeLabel.Name = "LongitudeLabel"
        LongitudeLabel.Size = New System.Drawing.Size(57, 13)
        LongitudeLabel.TabIndex = 7
        LongitudeLabel.Text = "Longitude:"
        '
        'ElevationLabel
        '
        ElevationLabel.AutoSize = True
        ElevationLabel.Location = New System.Drawing.Point(557, 87)
        ElevationLabel.Name = "ElevationLabel"
        ElevationLabel.Size = New System.Drawing.Size(54, 13)
        ElevationLabel.TabIndex = 9
        ElevationLabel.Text = "Elevation:"
        '
        'GeoLocationMethodLabel
        '
        GeoLocationMethodLabel.AutoSize = True
        GeoLocationMethodLabel.Location = New System.Drawing.Point(24, 258)
        GeoLocationMethodLabel.Name = "GeoLocationMethodLabel"
        GeoLocationMethodLabel.Size = New System.Drawing.Size(113, 13)
        GeoLocationMethodLabel.TabIndex = 11
        GeoLocationMethodLabel.Text = "Geo Location Method:"
        '
        'GeoLocationAccuracyLabel
        '
        GeoLocationAccuracyLabel.AutoSize = True
        GeoLocationAccuracyLabel.Location = New System.Drawing.Point(324, 258)
        GeoLocationAccuracyLabel.Name = "GeoLocationAccuracyLabel"
        GeoLocationAccuracyLabel.Size = New System.Drawing.Size(122, 13)
        GeoLocationAccuracyLabel.TabIndex = 13
        GeoLocationAccuracyLabel.Text = "Geo Location Accuracy:"
        '
        'OpeningDatetimeLabel
        '
        OpeningDatetimeLabel.AutoSize = True
        OpeningDatetimeLabel.Location = New System.Drawing.Point(252, 170)
        OpeningDatetimeLabel.Name = "OpeningDatetimeLabel"
        OpeningDatetimeLabel.Size = New System.Drawing.Size(95, 13)
        OpeningDatetimeLabel.TabIndex = 15
        OpeningDatetimeLabel.Text = "Opening Datetime:"
        '
        'ClosingDatetimeLabel
        '
        ClosingDatetimeLabel.AutoSize = True
        ClosingDatetimeLabel.Location = New System.Drawing.Point(252, 210)
        ClosingDatetimeLabel.Name = "ClosingDatetimeLabel"
        ClosingDatetimeLabel.Size = New System.Drawing.Size(89, 13)
        ClosingDatetimeLabel.TabIndex = 17
        ClosingDatetimeLabel.Text = "Closing Datetime:"
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(565, 43)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(46, 13)
        CountryLabel.TabIndex = 19
        CountryLabel.Text = "Country:"
        '
        'AuthorityLabel
        '
        AuthorityLabel.AutoSize = True
        AuthorityLabel.Location = New System.Drawing.Point(85, 124)
        AuthorityLabel.Name = "AuthorityLabel"
        AuthorityLabel.Size = New System.Drawing.Size(51, 13)
        AuthorityLabel.TabIndex = 21
        AuthorityLabel.Text = "Authority:"
        '
        'AdminRegionLabel
        '
        AdminRegionLabel.AutoSize = True
        AdminRegionLabel.Location = New System.Drawing.Point(287, 127)
        AdminRegionLabel.Name = "AdminRegionLabel"
        AdminRegionLabel.Size = New System.Drawing.Size(76, 13)
        AdminRegionLabel.TabIndex = 23
        AdminRegionLabel.Text = "Admin Region:"
        '
        'DrainageBasinLabel
        '
        DrainageBasinLabel.AutoSize = True
        DrainageBasinLabel.Location = New System.Drawing.Point(500, 124)
        DrainageBasinLabel.Name = "DrainageBasinLabel"
        DrainageBasinLabel.Size = New System.Drawing.Size(82, 13)
        DrainageBasinLabel.TabIndex = 25
        DrainageBasinLabel.Text = "Drainage Basin:"
        '
        'CptSelectionLabel
        '
        CptSelectionLabel.AutoSize = True
        CptSelectionLabel.Location = New System.Drawing.Point(63, 213)
        CptSelectionLabel.Name = "CptSelectionLabel"
        CptSelectionLabel.Size = New System.Drawing.Size(78, 13)
        CptSelectionLabel.TabIndex = 29
        CptSelectionLabel.Text = "CPT Selection:"
        '
        'StationOperationalLabel
        '
        StationOperationalLabel.AutoSize = True
        StationOperationalLabel.Location = New System.Drawing.Point(37, 173)
        StationOperationalLabel.Name = "StationOperationalLabel"
        StationOperationalLabel.Size = New System.Drawing.Size(100, 13)
        StationOperationalLabel.TabIndex = 31
        StationOperationalLabel.Text = "Station Operational:"
        '
        'StationIdTextBox
        '
        Me.StationIdTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.StationIdTextBox.Location = New System.Drawing.Point(141, 34)
        Me.StationIdTextBox.Name = "StationIdTextBox"
        Me.StationIdTextBox.Size = New System.Drawing.Size(100, 20)
        Me.StationIdTextBox.TabIndex = 0
        '
        'StationNameTextBox
        '
        Me.StationNameTextBox.Location = New System.Drawing.Point(368, 37)
        Me.StationNameTextBox.Name = "StationNameTextBox"
        Me.StationNameTextBox.Size = New System.Drawing.Size(175, 20)
        Me.StationNameTextBox.TabIndex = 1
        '
        'LatitudeTextBox
        '
        Me.LatitudeTextBox.Location = New System.Drawing.Point(141, 81)
        Me.LatitudeTextBox.Name = "LatitudeTextBox"
        Me.LatitudeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LatitudeTextBox.TabIndex = 3
        '
        'LongitudeTextBox
        '
        Me.LongitudeTextBox.Location = New System.Drawing.Point(368, 81)
        Me.LongitudeTextBox.Name = "LongitudeTextBox"
        Me.LongitudeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LongitudeTextBox.TabIndex = 4
        '
        'ElevationTextBox
        '
        Me.ElevationTextBox.Location = New System.Drawing.Point(616, 84)
        Me.ElevationTextBox.Name = "ElevationTextBox"
        Me.ElevationTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElevationTextBox.TabIndex = 5
        '
        'GeoLocationMethodTextBox
        '
        Me.GeoLocationMethodTextBox.Location = New System.Drawing.Point(141, 255)
        Me.GeoLocationMethodTextBox.Name = "GeoLocationMethodTextBox"
        Me.GeoLocationMethodTextBox.Size = New System.Drawing.Size(100, 20)
        Me.GeoLocationMethodTextBox.TabIndex = 13
        '
        'GeoLocationAccuracyTextBox
        '
        Me.GeoLocationAccuracyTextBox.Location = New System.Drawing.Point(459, 255)
        Me.GeoLocationAccuracyTextBox.Name = "GeoLocationAccuracyTextBox"
        Me.GeoLocationAccuracyTextBox.Size = New System.Drawing.Size(109, 20)
        Me.GeoLocationAccuracyTextBox.TabIndex = 14
        '
        'OpeningDatetimeDateTimePicker
        '
        Me.OpeningDatetimeDateTimePicker.CustomFormat = """MM dd yyyy hh mm ss"""
        Me.OpeningDatetimeDateTimePicker.Location = New System.Drawing.Point(368, 166)
        Me.OpeningDatetimeDateTimePicker.Name = "OpeningDatetimeDateTimePicker"
        Me.OpeningDatetimeDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.OpeningDatetimeDateTimePicker.TabIndex = 10
        '
        'ClosingDatetimeDateTimePicker
        '
        Me.ClosingDatetimeDateTimePicker.Location = New System.Drawing.Point(368, 206)
        Me.ClosingDatetimeDateTimePicker.Name = "ClosingDatetimeDateTimePicker"
        Me.ClosingDatetimeDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ClosingDatetimeDateTimePicker.TabIndex = 12
        '
        'CountryTextBox
        '
        Me.CountryTextBox.Location = New System.Drawing.Point(616, 40)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CountryTextBox.TabIndex = 2
        '
        'AuthorityTextBox
        '
        Me.AuthorityTextBox.Location = New System.Drawing.Point(141, 121)
        Me.AuthorityTextBox.Name = "AuthorityTextBox"
        Me.AuthorityTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AuthorityTextBox.TabIndex = 6
        '
        'AdminRegionTextBox
        '
        Me.AdminRegionTextBox.Location = New System.Drawing.Point(368, 124)
        Me.AdminRegionTextBox.Name = "AdminRegionTextBox"
        Me.AdminRegionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AdminRegionTextBox.TabIndex = 7
        '
        'DrainageBasinTextBox
        '
        Me.DrainageBasinTextBox.Location = New System.Drawing.Point(616, 121)
        Me.DrainageBasinTextBox.Name = "DrainageBasinTextBox"
        Me.DrainageBasinTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DrainageBasinTextBox.TabIndex = 8
        '
        'CptSelectionTextBox
        '
        Me.CptSelectionTextBox.Location = New System.Drawing.Point(141, 210)
        Me.CptSelectionTextBox.Name = "CptSelectionTextBox"
        Me.CptSelectionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CptSelectionTextBox.TabIndex = 11
        '
        'StationOperationalTextBox
        '
        Me.StationOperationalTextBox.Location = New System.Drawing.Point(141, 170)
        Me.StationOperationalTextBox.Name = "StationOperationalTextBox"
        Me.StationOperationalTextBox.Size = New System.Drawing.Size(100, 20)
        Me.StationOperationalTextBox.TabIndex = 9
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(527, 364)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 33
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(477, 327)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(38, 23)
        Me.btnMoveNext.TabIndex = 34
        Me.btnMoveNext.Text = ">>"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        Me.recNumberTextBox.Location = New System.Drawing.Point(330, 329)
        Me.recNumberTextBox.Name = "recNumberTextBox"
        Me.recNumberTextBox.Size = New System.Drawing.Size(141, 20)
        Me.recNumberTextBox.TabIndex = 35
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(521, 327)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(32, 23)
        Me.btnMoveLast.TabIndex = 36
        Me.btnMoveLast.Text = ">>|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(231, 327)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 37
        Me.btnMoveFirst.Text = "|<<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(278, 327)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(46, 23)
        Me.btnMovePrevious.TabIndex = 38
        Me.btnMovePrevious.Text = "<<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(284, 364)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 39
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(119, 364)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 40
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(365, 364)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 41
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(200, 364)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 42
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(446, 364)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 43
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(608, 364)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 44
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'formStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnMovePrevious)
        Me.Controls.Add(Me.btnMoveFirst)
        Me.Controls.Add(Me.btnMoveLast)
        Me.Controls.Add(Me.recNumberTextBox)
        Me.Controls.Add(Me.btnMoveNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(StationOperationalLabel)
        Me.Controls.Add(Me.StationOperationalTextBox)
        Me.Controls.Add(CptSelectionLabel)
        Me.Controls.Add(Me.CptSelectionTextBox)
        Me.Controls.Add(DrainageBasinLabel)
        Me.Controls.Add(Me.DrainageBasinTextBox)
        Me.Controls.Add(AdminRegionLabel)
        Me.Controls.Add(Me.AdminRegionTextBox)
        Me.Controls.Add(AuthorityLabel)
        Me.Controls.Add(Me.AuthorityTextBox)
        Me.Controls.Add(CountryLabel)
        Me.Controls.Add(Me.CountryTextBox)
        Me.Controls.Add(ClosingDatetimeLabel)
        Me.Controls.Add(Me.ClosingDatetimeDateTimePicker)
        Me.Controls.Add(OpeningDatetimeLabel)
        Me.Controls.Add(Me.OpeningDatetimeDateTimePicker)
        Me.Controls.Add(GeoLocationAccuracyLabel)
        Me.Controls.Add(Me.GeoLocationAccuracyTextBox)
        Me.Controls.Add(GeoLocationMethodLabel)
        Me.Controls.Add(Me.GeoLocationMethodTextBox)
        Me.Controls.Add(ElevationLabel)
        Me.Controls.Add(Me.ElevationTextBox)
        Me.Controls.Add(LongitudeLabel)
        Me.Controls.Add(Me.LongitudeTextBox)
        Me.Controls.Add(LatitudeLabel)
        Me.Controls.Add(Me.LatitudeTextBox)
        Me.Controls.Add(StationNameLabel)
        Me.Controls.Add(Me.StationNameTextBox)
        Me.Controls.Add(StationIdLabel)
        Me.Controls.Add(Me.StationIdTextBox)
        Me.MaximizeBox = False
        Me.Name = "formStation"
        Me.Text = "Station Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StationIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StationNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LatitudeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongitudeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElevationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GeoLocationMethodTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GeoLocationAccuracyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpeningDatetimeDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ClosingDatetimeDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AuthorityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdminRegionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DrainageBasinTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CptSelectionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StationOperationalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMoveNext As System.Windows.Forms.Button
    Friend WithEvents recNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnMoveLast As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents btnMovePrevious As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
