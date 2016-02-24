<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formStation))
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
        resources.ApplyResources(StationIdLabel, "StationIdLabel")
        StationIdLabel.Name = "StationIdLabel"
        '
        'StationNameLabel
        '
        resources.ApplyResources(StationNameLabel, "StationNameLabel")
        StationNameLabel.Name = "StationNameLabel"
        '
        'LatitudeLabel
        '
        resources.ApplyResources(LatitudeLabel, "LatitudeLabel")
        LatitudeLabel.Name = "LatitudeLabel"
        '
        'LongitudeLabel
        '
        resources.ApplyResources(LongitudeLabel, "LongitudeLabel")
        LongitudeLabel.Name = "LongitudeLabel"
        '
        'ElevationLabel
        '
        resources.ApplyResources(ElevationLabel, "ElevationLabel")
        ElevationLabel.Name = "ElevationLabel"
        '
        'GeoLocationMethodLabel
        '
        resources.ApplyResources(GeoLocationMethodLabel, "GeoLocationMethodLabel")
        GeoLocationMethodLabel.Name = "GeoLocationMethodLabel"
        '
        'GeoLocationAccuracyLabel
        '
        resources.ApplyResources(GeoLocationAccuracyLabel, "GeoLocationAccuracyLabel")
        GeoLocationAccuracyLabel.Name = "GeoLocationAccuracyLabel"
        '
        'OpeningDatetimeLabel
        '
        resources.ApplyResources(OpeningDatetimeLabel, "OpeningDatetimeLabel")
        OpeningDatetimeLabel.Name = "OpeningDatetimeLabel"
        '
        'ClosingDatetimeLabel
        '
        resources.ApplyResources(ClosingDatetimeLabel, "ClosingDatetimeLabel")
        ClosingDatetimeLabel.Name = "ClosingDatetimeLabel"
        '
        'CountryLabel
        '
        resources.ApplyResources(CountryLabel, "CountryLabel")
        CountryLabel.Name = "CountryLabel"
        '
        'AuthorityLabel
        '
        resources.ApplyResources(AuthorityLabel, "AuthorityLabel")
        AuthorityLabel.Name = "AuthorityLabel"
        '
        'AdminRegionLabel
        '
        resources.ApplyResources(AdminRegionLabel, "AdminRegionLabel")
        AdminRegionLabel.Name = "AdminRegionLabel"
        '
        'DrainageBasinLabel
        '
        resources.ApplyResources(DrainageBasinLabel, "DrainageBasinLabel")
        DrainageBasinLabel.Name = "DrainageBasinLabel"
        '
        'CptSelectionLabel
        '
        resources.ApplyResources(CptSelectionLabel, "CptSelectionLabel")
        CptSelectionLabel.Name = "CptSelectionLabel"
        '
        'StationOperationalLabel
        '
        resources.ApplyResources(StationOperationalLabel, "StationOperationalLabel")
        StationOperationalLabel.Name = "StationOperationalLabel"
        '
        'StationIdTextBox
        '
        Me.StationIdTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        resources.ApplyResources(Me.StationIdTextBox, "StationIdTextBox")
        Me.StationIdTextBox.Name = "StationIdTextBox"
        '
        'StationNameTextBox
        '
        resources.ApplyResources(Me.StationNameTextBox, "StationNameTextBox")
        Me.StationNameTextBox.Name = "StationNameTextBox"
        '
        'LatitudeTextBox
        '
        resources.ApplyResources(Me.LatitudeTextBox, "LatitudeTextBox")
        Me.LatitudeTextBox.Name = "LatitudeTextBox"
        '
        'LongitudeTextBox
        '
        resources.ApplyResources(Me.LongitudeTextBox, "LongitudeTextBox")
        Me.LongitudeTextBox.Name = "LongitudeTextBox"
        '
        'ElevationTextBox
        '
        resources.ApplyResources(Me.ElevationTextBox, "ElevationTextBox")
        Me.ElevationTextBox.Name = "ElevationTextBox"
        '
        'GeoLocationMethodTextBox
        '
        resources.ApplyResources(Me.GeoLocationMethodTextBox, "GeoLocationMethodTextBox")
        Me.GeoLocationMethodTextBox.Name = "GeoLocationMethodTextBox"
        '
        'GeoLocationAccuracyTextBox
        '
        resources.ApplyResources(Me.GeoLocationAccuracyTextBox, "GeoLocationAccuracyTextBox")
        Me.GeoLocationAccuracyTextBox.Name = "GeoLocationAccuracyTextBox"
        '
        'OpeningDatetimeDateTimePicker
        '
        resources.ApplyResources(Me.OpeningDatetimeDateTimePicker, "OpeningDatetimeDateTimePicker")
        Me.OpeningDatetimeDateTimePicker.Name = "OpeningDatetimeDateTimePicker"
        '
        'ClosingDatetimeDateTimePicker
        '
        resources.ApplyResources(Me.ClosingDatetimeDateTimePicker, "ClosingDatetimeDateTimePicker")
        Me.ClosingDatetimeDateTimePicker.Name = "ClosingDatetimeDateTimePicker"
        '
        'CountryTextBox
        '
        resources.ApplyResources(Me.CountryTextBox, "CountryTextBox")
        Me.CountryTextBox.Name = "CountryTextBox"
        '
        'AuthorityTextBox
        '
        resources.ApplyResources(Me.AuthorityTextBox, "AuthorityTextBox")
        Me.AuthorityTextBox.Name = "AuthorityTextBox"
        '
        'AdminRegionTextBox
        '
        resources.ApplyResources(Me.AdminRegionTextBox, "AdminRegionTextBox")
        Me.AdminRegionTextBox.Name = "AdminRegionTextBox"
        '
        'DrainageBasinTextBox
        '
        resources.ApplyResources(Me.DrainageBasinTextBox, "DrainageBasinTextBox")
        Me.DrainageBasinTextBox.Name = "DrainageBasinTextBox"
        '
        'CptSelectionTextBox
        '
        resources.ApplyResources(Me.CptSelectionTextBox, "CptSelectionTextBox")
        Me.CptSelectionTextBox.Name = "CptSelectionTextBox"
        '
        'StationOperationalTextBox
        '
        resources.ApplyResources(Me.StationOperationalTextBox, "StationOperationalTextBox")
        Me.StationOperationalTextBox.Name = "StationOperationalTextBox"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMoveNext
        '
        resources.ApplyResources(Me.btnMoveNext, "btnMoveNext")
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        resources.ApplyResources(Me.recNumberTextBox, "recNumberTextBox")
        Me.recNumberTextBox.Name = "recNumberTextBox"
        '
        'btnMoveLast
        '
        resources.ApplyResources(Me.btnMoveLast, "btnMoveLast")
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        resources.ApplyResources(Me.btnMoveFirst, "btnMoveFirst")
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        resources.ApplyResources(Me.btnMovePrevious, "btnMovePrevious")
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        resources.ApplyResources(Me.btnUpdate, "btnUpdate")
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        resources.ApplyResources(Me.btnAddNew, "btnAddNew")
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        resources.ApplyResources(Me.btnCommit, "btnCommit")
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Name = "btnClear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        resources.ApplyResources(Me.btnHelp, "btnHelp")
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'formStation
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
