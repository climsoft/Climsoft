VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.1#0"; "Mscomctl.ocx"
Object = "{67397AA1-7FB1-11D0-B148-00A0C922E820}#6.0#0"; "Msadodc.ocx"
Object = "{F0D2F211-CCB0-11D0-A316-00AA00688B10}#1.0#0"; "Msdatlst.ocx"
Begin VB.Form frm_synop_bufr_crex 
   BorderStyle     =   1  'Fixed Single
   ClientHeight    =   10290
   ClientLeft      =   4230
   ClientTop       =   780
   ClientWidth     =   11190
   Icon            =   "frm_synop_bufr_crex.frx":0000
   LinkTopic       =   "Form3"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   10290
   ScaleWidth      =   11190
   Begin VB.Frame frame_crex 
      Caption         =   "Indicators"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3855
      Left            =   1080
      TabIndex        =   15
      Top             =   2160
      Width           =   3615
      Begin VB.TextBox ppp 
         Height          =   285
         Left            =   2685
         TabIndex        =   100
         Text            =   "000"
         Top             =   2760
         Width           =   615
      End
      Begin VB.TextBox nnn 
         Height          =   285
         Left            =   2685
         TabIndex        =   97
         Text            =   "000"
         Top             =   1680
         Width           =   615
      End
      Begin VB.TextBox ww 
         Height          =   285
         Left            =   2685
         TabIndex        =   95
         Text            =   "00"
         Top             =   1320
         Width           =   615
      End
      Begin VB.TextBox bb 
         Height          =   285
         Left            =   2685
         TabIndex        =   93
         Text            =   "13"
         Top             =   960
         Width           =   615
      End
      Begin VB.TextBox vv 
         Height          =   285
         Left            =   2685
         TabIndex        =   91
         Text            =   "04"
         Top             =   600
         Width           =   615
      End
      Begin VB.TextBox ee 
         Height          =   285
         Left            =   2685
         TabIndex        =   89
         Text            =   "02"
         Top             =   240
         Width           =   615
      End
      Begin VB.TextBox sss 
         Height          =   285
         Left            =   2685
         TabIndex        =   87
         Text            =   "001"
         Top             =   3480
         Width           =   615
      End
      Begin VB.TextBox mmm 
         Height          =   285
         Left            =   2685
         TabIndex        =   32
         Text            =   "002"
         Top             =   2040
         Width           =   615
      End
      Begin VB.TextBox ooooo 
         Height          =   285
         Left            =   2685
         TabIndex        =   19
         Text            =   "00014"
         Top             =   2400
         Width           =   615
      End
      Begin VB.TextBox uu 
         Height          =   285
         Left            =   2685
         TabIndex        =   18
         Text            =   "00"
         Top             =   3120
         Width           =   615
      End
      Begin VB.Label Label39 
         Caption         =   "Originating/Generating sub-centre"
         Height          =   195
         Left            =   120
         TabIndex        =   99
         Top             =   2805
         Width           =   2535
      End
      Begin VB.Label Label11 
         Caption         =   "Data Category "
         Height          =   195
         Left            =   120
         TabIndex        =   98
         Top             =   1725
         Width           =   2535
      End
      Begin VB.Label Label38 
         Caption         =   "Local Tables Version number"
         Height          =   195
         Left            =   120
         TabIndex        =   96
         Top             =   1365
         Width           =   2295
      End
      Begin VB.Label Label37 
         Caption         =   "BUFR master table version number"
         Height          =   255
         Left            =   120
         TabIndex        =   94
         Top             =   960
         Width           =   2535
      End
      Begin VB.Label Label36 
         Caption         =   "CREX table version number "
         Height          =   255
         Left            =   120
         TabIndex        =   92
         Top             =   615
         Width           =   2415
      End
      Begin VB.Label Label35 
         Caption         =   "CREX Editions number"
         Height          =   255
         Left            =   120
         TabIndex        =   90
         Top             =   255
         Width           =   2415
      End
      Begin VB.Label Label34 
         Caption         =   "Number of Sebsets"
         Height          =   195
         Left            =   120
         TabIndex        =   88
         Top             =   3525
         Width           =   1935
      End
      Begin VB.Label ldcategory 
         Caption         =   "Data Category-Sub Category"
         Height          =   195
         Left            =   120
         TabIndex        =   33
         Top             =   2085
         Width           =   2535
      End
      Begin VB.Label Label10 
         Caption         =   "Sequence Number"
         Height          =   195
         Left            =   120
         TabIndex        =   17
         Top             =   3165
         Width           =   2415
      End
      Begin VB.Label Label9 
         Caption         =   "Originating/Generating Centre"
         Height          =   195
         Left            =   120
         TabIndex        =   16
         Top             =   2445
         Width           =   2535
      End
   End
   Begin VB.TextBox output_file 
      BackColor       =   &H8000000F&
      Height          =   285
      Left            =   6120
      Locked          =   -1  'True
      TabIndex        =   101
      Top             =   5708
      Width           =   4905
   End
   Begin VB.Frame frame_binary 
      Caption         =   "Binary Message"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1455
      Left            =   4800
      TabIndex        =   81
      Top             =   4200
      Width           =   6255
      Begin VB.TextBox txt_coded 
         Appearance      =   0  'Flat
         BackColor       =   &H8000000F&
         BorderStyle     =   0  'None
         Height          =   1095
         Left            =   120
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   82
         Top             =   240
         Width           =   6015
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "Character Message"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3855
      Left            =   120
      TabIndex        =   42
      Top             =   6000
      Width           =   10935
      Begin VB.CheckBox check_uncoded 
         Caption         =   "Attach uncoded data"
         Height          =   200
         Left            =   1750
         TabIndex        =   110
         Top             =   3120
         Value           =   1  'Checked
         Width           =   2295
      End
      Begin VB.Frame Frame1 
         Caption         =   "Sending Options"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1500
         Left            =   120
         TabIndex        =   107
         Top             =   2280
         Width           =   1560
         Begin VB.OptionButton OptEmail 
            Caption         =   "Email"
            Enabled         =   0   'False
            Height          =   255
            Left            =   240
            TabIndex        =   109
            Top             =   360
            Width           =   1095
         End
         Begin VB.OptionButton OptFTP 
            Caption         =   "FTP"
            Enabled         =   0   'False
            Height          =   255
            Left            =   240
            TabIndex        =   108
            Top             =   990
            Width           =   735
         End
      End
      Begin VB.Frame framemail 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   975
         Left            =   1750
         TabIndex        =   44
         Top             =   2160
         Width           =   9100
         Begin VB.TextBox email_subject 
            Enabled         =   0   'False
            Height          =   285
            Left            =   2100
            TabIndex        =   49
            Top             =   600
            Width           =   6360
         End
         Begin VB.TextBox email_address 
            BackColor       =   &H00FFFFFF&
            CausesValidation=   0   'False
            Enabled         =   0   'False
            Height          =   285
            Left            =   2100
            TabIndex        =   48
            Top             =   210
            Width           =   6360
         End
         Begin VB.CommandButton mail_send 
            Caption         =   "&Send"
            Height          =   375
            Left            =   8400
            TabIndex        =   50
            Top             =   360
            Width           =   615
         End
         Begin VB.ListBox mails_list 
            Enabled         =   0   'False
            Height          =   450
            ItemData        =   "frm_synop_bufr_crex.frx":030A
            Left            =   120
            List            =   "frm_synop_bufr_crex.frx":0314
            TabIndex        =   45
            Top             =   360
            Width           =   1215
         End
         Begin VB.Label Label17 
            Alignment       =   1  'Right Justify
            Caption         =   "To:"
            Height          =   285
            Left            =   1560
            TabIndex        =   51
            Top             =   210
            Width           =   495
         End
         Begin VB.Label Label19 
            Alignment       =   1  'Right Justify
            Caption         =   "Subject:"
            Height          =   285
            Left            =   1440
            TabIndex        =   47
            Top             =   600
            Width           =   615
         End
         Begin VB.Label Label14 
            Caption         =   "Mail Applications"
            Height          =   255
            Left            =   120
            TabIndex        =   46
            Top             =   120
            Width           =   1335
         End
      End
      Begin VB.TextBox txt_message 
         Height          =   1935
         Left            =   120
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   43
         Top             =   240
         Width           =   10695
      End
      Begin VB.CheckBox Checkftp 
         Caption         =   "FTP"
         Enabled         =   0   'False
         Height          =   255
         Left            =   6240
         TabIndex        =   103
         Top             =   3480
         Visible         =   0   'False
         Width           =   735
      End
      Begin VB.Frame frmftp 
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   600
         Left            =   1750
         TabIndex        =   104
         Top             =   3220
         Width           =   3375
         Begin VB.CommandButton cmdftp_settings 
            Caption         =   "Settings"
            Height          =   300
            Left            =   1920
            TabIndex        =   106
            Top             =   240
            Width           =   855
         End
         Begin VB.CommandButton cmdftp_send 
            Caption         =   "Send"
            Height          =   300
            Left            =   360
            TabIndex        =   105
            Top             =   240
            Width           =   855
         End
      End
   End
   Begin VB.Frame Frame4 
      Height          =   2175
      Left            =   1080
      TabIndex        =   20
      Top             =   0
      Width           =   8775
      Begin VB.TextBox txtminute 
         Height          =   315
         Left            =   4584
         TabIndex        =   84
         Top             =   1080
         Width           =   855
      End
      Begin VB.TextBox txtsecond 
         Height          =   315
         Left            =   5640
         TabIndex        =   83
         Top             =   1080
         Visible         =   0   'False
         Width           =   855
      End
      Begin VB.ComboBox txtBBB 
         Height          =   315
         ItemData        =   "frm_synop_bufr_crex.frx":0329
         Left            =   1800
         List            =   "frm_synop_bufr_crex.frx":0339
         TabIndex        =   55
         Top             =   1680
         Width           =   1215
      End
      Begin VB.TextBox msg_header 
         Height          =   315
         Left            =   360
         TabIndex        =   54
         Top             =   1680
         Width           =   1335
      End
      Begin VB.ComboBox txttemplate 
         Height          =   360
         ItemData        =   "frm_synop_bufr_crex.frx":034C
         Left            =   6120
         List            =   "frm_synop_bufr_crex.frx":0365
         TabIndex        =   40
         Text            =   "TM_307081"
         Top             =   1680
         Width           =   2295
      End
      Begin VB.CheckBox check_digit 
         Caption         =   "Include Check Digit"
         Height          =   195
         Left            =   3720
         TabIndex        =   31
         Top             =   1740
         Visible         =   0   'False
         Width           =   1695
      End
      Begin VB.TextBox txthour 
         Height          =   315
         Left            =   3528
         TabIndex        =   30
         Top             =   1080
         Width           =   855
      End
      Begin VB.TextBox txtday 
         Height          =   315
         Left            =   2472
         TabIndex        =   29
         Top             =   1080
         Width           =   855
      End
      Begin VB.TextBox txtyear 
         Height          =   315
         Left            =   360
         TabIndex        =   28
         Top             =   1080
         Width           =   855
      End
      Begin VB.TextBox txtmonth 
         Height          =   315
         Left            =   1416
         TabIndex        =   27
         Top             =   1080
         Width           =   855
      End
      Begin MSDataListLib.DataCombo txtstation 
         Bindings        =   "frm_synop_bufr_crex.frx":03B6
         DataSource      =   "lookup_station"
         Height          =   315
         Left            =   360
         TabIndex        =   0
         Top             =   480
         Width           =   7815
         _ExtentX        =   13785
         _ExtentY        =   556
         _Version        =   393216
         ListField       =   "name"
         BoundColumn     =   "id"
         Text            =   ""
      End
      Begin VB.Label Label33 
         Alignment       =   2  'Center
         Caption         =   "Minute"
         Height          =   180
         Left            =   4680
         TabIndex        =   86
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label32 
         Alignment       =   2  'Center
         Caption         =   "Second"
         Height          =   180
         Left            =   5640
         TabIndex        =   85
         Top             =   840
         Visible         =   0   'False
         Width           =   855
      End
      Begin VB.Label Label20 
         Alignment       =   2  'Center
         Caption         =   "BBB"
         Height          =   200
         Left            =   1800
         TabIndex        =   56
         Top             =   1440
         Width           =   1095
      End
      Begin VB.Label Label12 
         Alignment       =   2  'Center
         Caption         =   "Template"
         Height          =   255
         Left            =   6120
         TabIndex        =   41
         Top             =   1440
         Width           =   2295
      End
      Begin VB.Label Label6 
         Caption         =   "Message Header"
         Height          =   200
         Left            =   360
         TabIndex        =   26
         Tag             =   "535"
         Top             =   1440
         Width           =   1335
      End
      Begin VB.Label Label5 
         Alignment       =   2  'Center
         Caption         =   "Hour"
         Height          =   180
         Left            =   3600
         TabIndex        =   25
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label4 
         Alignment       =   2  'Center
         Caption         =   "Day"
         Height          =   180
         Left            =   2520
         TabIndex        =   24
         Tag             =   "177"
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         Caption         =   "Station"
         Height          =   255
         Left            =   360
         TabIndex        =   23
         Tag             =   "165"
         Top             =   240
         Width           =   7815
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Caption         =   "Year"
         Height          =   180
         Left            =   360
         TabIndex        =   22
         Tag             =   "179"
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Month"
         Height          =   180
         Left            =   1440
         TabIndex        =   21
         Tag             =   "178"
         Top             =   840
         Width           =   855
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Instrument Types"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2055
      Left            =   7920
      TabIndex        =   6
      Top             =   2160
      Width           =   1935
      Begin VB.TextBox txtwi 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1200
         TabIndex        =   8
         Text            =   "14"
         Top             =   675
         Width           =   400
      End
      Begin VB.TextBox txtit 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1200
         TabIndex        =   7
         Text            =   "1"
         Top             =   240
         Width           =   400
      End
      Begin VB.Label Label18 
         Caption         =   "Wind"
         Height          =   180
         Left            =   120
         TabIndex        =   10
         Top             =   720
         Width           =   495
      End
      Begin VB.Label txtet 
         Caption         =   "Evaporation"
         Height          =   195
         Left            =   120
         TabIndex        =   9
         Top             =   240
         Width           =   975
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "Sensors Height From Ground (M)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2055
      Left            =   4800
      TabIndex        =   1
      Top             =   2160
      Width           =   3015
      Begin VB.TextBox txtrh 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1560
         TabIndex        =   38
         Text            =   "0.25"
         Top             =   1329
         Width           =   400
      End
      Begin VB.TextBox txtbr 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1560
         TabIndex        =   36
         Text            =   "1.25"
         Top             =   285
         Width           =   400
      End
      Begin VB.TextBox txtth 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1560
         TabIndex        =   35
         Text            =   "1.25"
         Top             =   633
         Width           =   400
      End
      Begin VB.TextBox txtwh 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1560
         TabIndex        =   34
         Text            =   "10"
         Top             =   1680
         Width           =   400
      End
      Begin VB.TextBox txtvh 
         Alignment       =   1  'Right Justify
         Height          =   285
         Left            =   1560
         TabIndex        =   2
         Text            =   "1.5"
         Top             =   981
         Width           =   400
      End
      Begin VB.Label Label8 
         Caption         =   "Precipitation"
         Height          =   180
         Left            =   315
         TabIndex        =   39
         Top             =   1381
         Width           =   975
      End
      Begin VB.Label Label7 
         Caption         =   "Pressure"
         Height          =   180
         Left            =   315
         TabIndex        =   37
         Top             =   330
         Width           =   975
      End
      Begin VB.Label Label16 
         Caption         =   "Wind"
         Height          =   180
         Left            =   315
         TabIndex        =   5
         Top             =   1732
         Width           =   975
      End
      Begin VB.Label Label15 
         Caption         =   "Visibility"
         Height          =   195
         Left            =   315
         TabIndex        =   4
         Top             =   1026
         Width           =   975
      End
      Begin VB.Label Label13 
         Caption         =   "Temperature"
         Height          =   180
         Left            =   315
         TabIndex        =   3
         Top             =   660
         Width           =   975
      End
   End
   Begin MSComctlLib.Toolbar Toolbar1 
      Align           =   2  'Align Bottom
      Height          =   420
      Left            =   0
      TabIndex        =   11
      Top             =   9870
      Width           =   11190
      _ExtentX        =   19738
      _ExtentY        =   741
      ButtonWidth     =   609
      ButtonHeight    =   582
      Appearance      =   1
      _Version        =   393216
      Begin VB.CommandButton cmd_view 
         Caption         =   "&View Descriptors"
         Enabled         =   0   'False
         Height          =   375
         Left            =   4200
         TabIndex        =   53
         Tag             =   "343"
         Top             =   0
         Width           =   1335
      End
      Begin VB.CommandButton myhelp 
         Caption         =   "&Help"
         Height          =   375
         Left            =   8760
         TabIndex        =   14
         Tag             =   "117"
         Top             =   0
         Width           =   735
      End
      Begin VB.CommandButton cancel 
         Caption         =   "&Close"
         Height          =   375
         Left            =   7440
         TabIndex        =   13
         Tag             =   "594"
         Top             =   0
         Width           =   855
      End
      Begin VB.CommandButton cmd_encode 
         Caption         =   "&Encode"
         Height          =   375
         Left            =   2640
         TabIndex        =   52
         Top             =   0
         Width           =   975
      End
      Begin VB.CommandButton cmdreset 
         Caption         =   "&Reset"
         Height          =   375
         Left            =   6000
         TabIndex        =   12
         Tag             =   "192"
         Top             =   0
         Width           =   1095
      End
   End
   Begin MSAdodcLib.Adodc lookup_station 
      Height          =   375
      Left            =   4200
      Top             =   600
      Visible         =   0   'False
      Width           =   2775
      _ExtentX        =   4895
      _ExtentY        =   661
      ConnectMode     =   0
      CursorLocation  =   3
      IsolationLevel  =   -1
      ConnectionTimeout=   15
      CommandTimeout  =   30
      CursorType      =   3
      LockType        =   3
      CommandType     =   2
      CursorOptions   =   0
      CacheSize       =   50
      MaxRecords      =   0
      BOFAction       =   0
      EOFAction       =   0
      ConnectStringType=   1
      Appearance      =   1
      BackColor       =   -2147483643
      ForeColor       =   -2147483640
      Orientation     =   0
      Enabled         =   -1
      Connect         =   ""
      OLEDBString     =   ""
      OLEDBFile       =   ""
      DataSourceName  =   ""
      OtherAttributes =   ""
      UserName        =   ""
      Password        =   ""
      RecordSource    =   "qry_lookup_station"
      Caption         =   "lookup_station"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _Version        =   393216
   End
   Begin VB.Frame frame_bufr 
      Caption         =   "Indicators"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3855
      Left            =   1080
      TabIndex        =   58
      Top             =   2160
      Width           =   3615
      Begin VB.TextBox update_sequence 
         Height          =   285
         Left            =   2685
         TabIndex        =   69
         Text            =   "0"
         Top             =   1155
         Width           =   615
      End
      Begin VB.CheckBox optional_section 
         Height          =   255
         Left            =   2685
         TabIndex        =   68
         Top             =   1485
         Width           =   495
      End
      Begin VB.TextBox data_category 
         Height          =   285
         Left            =   2685
         TabIndex        =   67
         Text            =   "0"
         Top             =   1800
         Width           =   615
      End
      Begin VB.TextBox international_subcategory 
         Height          =   285
         Left            =   2685
         TabIndex        =   66
         Text            =   "0"
         Top             =   2130
         Width           =   615
      End
      Begin VB.TextBox local_subcategory 
         Height          =   285
         Left            =   2685
         TabIndex        =   65
         Text            =   "0"
         Top             =   2460
         Width           =   615
      End
      Begin VB.TextBox mastertable_version 
         Height          =   285
         Left            =   2685
         TabIndex        =   64
         Text            =   "13"
         Top             =   2805
         Width           =   615
      End
      Begin VB.TextBox localtable_version 
         Height          =   285
         Left            =   2685
         TabIndex        =   63
         Text            =   "0"
         Top             =   3135
         Width           =   615
      End
      Begin VB.TextBox subsets 
         Height          =   285
         Left            =   2685
         TabIndex        =   62
         Text            =   "1"
         Top             =   3480
         Width           =   615
      End
      Begin VB.TextBox originating_subcentre 
         Height          =   285
         Left            =   2685
         TabIndex        =   61
         Text            =   "0"
         Top             =   810
         Width           =   615
      End
      Begin VB.TextBox originating_centre 
         Height          =   285
         Left            =   2685
         TabIndex        =   60
         Text            =   "14"
         Top             =   480
         Width           =   615
      End
      Begin VB.TextBox bufr_edition 
         Height          =   285
         Left            =   2685
         TabIndex        =   59
         Text            =   "4"
         Top             =   150
         Width           =   615
      End
      Begin VB.Label Label31 
         Caption         =   "Originating/Generating centre"
         Height          =   195
         Left            =   120
         TabIndex        =   80
         Top             =   525
         Width           =   2535
      End
      Begin VB.Label Label30 
         Caption         =   "Update Sequence number"
         Height          =   195
         Left            =   120
         TabIndex        =   79
         Top             =   1200
         Width           =   2535
      End
      Begin VB.Label Label27 
         Caption         =   "Optional Section Inclusion"
         Height          =   195
         Left            =   120
         TabIndex        =   78
         Top             =   1515
         Width           =   2175
      End
      Begin VB.Label Label26 
         Caption         =   "Originating/Generating sub-centre"
         Height          =   195
         Left            =   120
         TabIndex        =   77
         Top             =   855
         Width           =   2535
      End
      Begin VB.Label Label21 
         Caption         =   "Data Category "
         Height          =   195
         Left            =   120
         TabIndex        =   76
         Top             =   1845
         Width           =   1575
      End
      Begin VB.Label Label22 
         Caption         =   "International Data sub-category "
         Height          =   195
         Left            =   120
         TabIndex        =   75
         Top             =   2175
         Width           =   2295
      End
      Begin VB.Label Label23 
         Caption         =   "Local Data sub-category "
         Height          =   195
         Left            =   120
         TabIndex        =   74
         Top             =   2505
         Width           =   2295
      End
      Begin VB.Label Label24 
         Caption         =   "Master Tables Version number"
         Height          =   195
         Left            =   120
         TabIndex        =   73
         Top             =   2850
         Width           =   2295
      End
      Begin VB.Label Label25 
         Caption         =   "Local Tables Version number"
         Height          =   195
         Left            =   120
         TabIndex        =   72
         Top             =   3180
         Width           =   2295
      End
      Begin VB.Label Label28 
         Caption         =   "Number of Sebsets"
         Height          =   195
         Left            =   120
         TabIndex        =   71
         Top             =   3525
         Width           =   2295
      End
      Begin VB.Label Label29 
         Caption         =   "BUFR Edition Number"
         Height          =   195
         Left            =   120
         TabIndex        =   70
         Top             =   240
         Width           =   2535
      End
   End
   Begin VB.Label Label49 
      Caption         =   "Coded Output File"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   180
      Left            =   4800
      TabIndex        =   102
      Top             =   5760
      Width           =   1215
   End
   Begin VB.Label lmsg 
      Height          =   1215
      Left            =   9960
      TabIndex        =   57
      Top             =   1800
      Width           =   975
   End
End
Attribute VB_Name = "frm_synop_bufr_crex"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public tbl As String
Public erain As Boolean
Public Trace24hr As Boolean
Public Trace3hr As Boolean
Dim mailtype As String
'Dim eupp As New EuApplication [--commended out 2010/05/05

'Dim subsets As String

Private Sub cancel_Click()
Unload Me
End Sub



Private Sub Checkftp_Click()
'If Checkftp.value = 1 Then
'   frmftp.Enabled = True
'   framemail.Enabled = False
'  Else
'   frmftp.Enabled = False
'   framemail.Enabled = True
'End If
End Sub

Private Sub cmd_view_Click()
' Display Decomposed descriptors in EXCEL sheet
 Select Case Me.Caption
   Case "CREX Synop"
    If Not ViewExcel(fso.GetParentFolderName(App.Path) & "\data\crex_code.csv") Then Exit Sub
   Case "BUFR Synop"
    If Not ViewExcel(fso.GetParentFolderName(App.Path) & "\data\bufr.csv") Then Exit Sub
End Select
End Sub

Private Sub cmdftp_send_Click()
If Not FTP_Execute(output_file, Me.Caption) Then
   MsgBox "Can't send file"
 Else
   MsgBox "File " & output_file & " Successfully transfered"
End If
End Sub

Private Sub cmdftp_settings_Click()
frm_ftp.Show
End Sub

Private Sub cmdreset_Click()
'Delete content of the sebsets files
Open fso.GetParentFolderName(App.Path) & "\data\crex_subsets.txt" For Output As #3
Open fso.GetParentFolderName(App.Path) & "\data\bufr_subsets.txt" For Output As #4
Close #3
Close #4
txt_message = ""
txt_coded = ""
End Sub



Private Sub Command1_Click()

End Sub

Private Sub email_address_KeyPress(keyAscii As Integer)
If keyAscii = 13 Then email_subject.SetFocus
End Sub

Private Sub email_subject_KeyPress(keyAscii As Integer)
If keyAscii = 13 Then mail_send.SetFocus
End Sub



Private Sub Form_Unload(cancel As Integer)
Close #10
End Sub

Private Sub mails_list_Click()
Dim itm As Integer
itm = mails_list.ListIndex
mailtype = mails_list.List(mails_list.ListIndex)
If txt_message <> "" Then
    email_address.Enabled = True
    email_subject.Enabled = True
  Else
    email_address.Enabled = False
    email_subject.Enabled = False
 End If
email_address.SetFocus
 If Me.Caption = "BUFR Synop" Then
    email_subject = "BUFR SYNOP " & txtstation & " " & txtyear & " " & txtmonth & " " & txtday & " " & Left(txthour, 2)
   Else
    email_subject = "CREX SYNOP " & txtstation & " " & txtyear & " " & txtmonth & " " & txtday & " " & Left(txthour, 2)
 End If
End Sub

'Private Sub mail_send_Click()
' On Error GoTo Err
' Dim attachfile As String
'  attachfile = output_file
' If email_address = "" Then Exit Sub
'     Select Case mailtype
'       Case "Eudora"
'         If Me.Caption = "BUFR Synop" Then
'           eupp.QueueMessage email_address, email_subject, "", "", attachfile, txt_message 'Recordview, "", "", backupfile, Recordview
'          Else
'           eupp.QueueMessage email_address, email_subject, "", "", "", txt_message 'Recordview, "", "", backupfile, Recordview
'         End If
'         eupp.SendQueuedMessages
'       Case "Outlook"
'        Dim OL As New Outlook.Application
'        Dim OlMail As Outlook.MailItem
'       Set OlMail = OL.CreateItem(olMailItem)
'        With OlMail
'          .To = email_address
'          .Subject = email_subject
'          If Me.Caption = "BUFR Synop" Then
'            .Attachments.Add attachfile
'            .Body = txt_message 'txt_coded
'           Else
'            .Body = txt_message
'          End If
'          .Send
'        End With
'      End Select
'  Exit Sub
'Err:
'MsgBox Err.description
'End Sub


Private Sub mail_send_Click()
 On Error GoTo Err
 Dim F_coded As String
 Dim F_uncoded As String
 Dim attached As String
 
 F_coded = output_file ' fso.GetParentFolderName(App.Path) & "\data\bufr.f"
 
If Not Uncoded_Data_File(tbl, F_uncoded, subsetrs(tbl, txtyear, txtmonth, txtday, txthour)) Then
   attached = F_coded
  Else
   attached = F_coded & "; " & F_uncoded
 End If

 If email_address = "" Then Exit Sub
     Select Case mailtype
       Case "Eudora"
         If Me.Caption = "BUFR Synop" Then ' Bufr Message sending
           If check_uncoded.value = 1 Then
              eupp.QueueMessage email_address, email_subject, "", "", attached, "" 'RecordView.Name, "", "", backupfile, RecordView.Name
             Else
              eupp.QueueMessage email_address, email_subject, "", "", F_coded, "" 'RecordView.Name, "", "", backupfile, RecordView.Name
            End If
          Else   ' CREX message sending
            If check_uncoded.value = 1 Then
              eupp.QueueMessage email_address, email_subject, "", "", F_uncoded, txt_message 'RecordView.Name, "", "", backupfile, RecordView.Name
             Else
              eupp.QueueMessage email_address, email_subject, "", "", "", txt_message 'RecordView.Name, "", "", backupfile, RecordView.Name
            End If
         End If
         eupp.SendQueuedMessages
       Case "Outlook"
        Dim OL As New Outlook.Application
        Dim OlMail As Outlook.MailItem
       Set OlMail = OL.CreateItem(olMailItem)
        With OlMail
          .To = email_address
          .Subject = email_subject
          If Me.Caption = "BUFR Synop" Then ' Bufr message
            If check_uncoded.value = 1 Then
               .Attachments.Add F_uncoded ' attached
               .Attachments.Add F_coded
             Else
               .Attachments.Add F_coded
            End If
'            .Body = txt_message
           Else  ' CREX message
            If check_uncoded.value = 1 Then .Attachments.Add F_uncoded
            .Body = txt_message
          End If
          .send
        End With
      End Select
  Exit Sub
Err:
MsgBox Err.description
End Sub

Private Sub cmd_encode_click()

On Error GoTo Err
txthour_Change
' All data must be provided

If txtstation = "" Or txtyear = "" Or txtmonth = "" Or txtday = "" Or txthour = "" Or txtbr = "" Then
 MsgBox "One or more values not entered, Please Confirm.", vbInformation, "Missing Value(s)"
 Exit Sub
End If

'On Error Resume Next 'GoTo Err
Dim dbase As String
Dim qry As QueryDef
Dim db As dao.Database
Dim rs As dao.Recordset
Dim rsbx As dao.Recordset
Dim rsbx1 As dao.Recordset
Dim vals As String
Dim sql As String
Dim rep1 As Integer
Dim rep2 As Integer
Dim Bufr_DataSection As String

'dbase = frm_keyentry.datafile

If Not clicom.read_registry("key05", dbase) Then Exit Sub

Set db = dao.OpenDatabase(dbase)


If Not clicom.table_exist(txttemplate, dbase) Then
  MsgBox "Template " & txttemplate & " not found"
  Exit Sub
End If
'sql = "SELECT " & txttemplate & ".order, " & txttemplate & ".Crex_Descriptor0, " & txttemplate & ".Crex_Descriptor1, " & txttemplate & ".Crex_Descriptor, " & txttemplate & ".Crex_Element, " & txttemplate & ".Climsoft_Element, " & txttemplate & ".Element_Description, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & txttemplate & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data INTO bufr_crex_data FROM " & txttemplate & " INNER JOIN bufr_crex_master ON " & txttemplate & ".Crex_Element = bufr_crex_master.Crex_Fxxyyy ORDER BY " & txttemplate & ".order;"
'sql = "SELECT " & "TM_307081.order, TM_307081.Bufr_Template, TM_307081.Crex_Template, TM_307081.Sequence_Descriptor1, TM_307081.Sequence_Descriptor0, TM_307081.Bufr_Element, TM_307081.Crex_Element, TM_307081.Climsoft_Element, TM_307081.Element_Description, TM_307081.synop_code, TM_307081.unit, TM_307081.scale, TM_307081.width, TM_307081.units_length_scale, TM_307081.data_type, TM_307081.selected, TM_307081.observation, TM_307081.Crex_Data, TM_307081.Bufr_Data from TM_307081 ORDER BY TM_307081.order;"

sql = "SELECT " & txttemplate & ".order, " & txttemplate & ".Bufr_Template, " & txttemplate & ".Crex_Template, " & txttemplate & ".Sequence_Descriptor1," & txttemplate & ".Sequence_Descriptor0," & txttemplate & ".Bufr_Element, " & txttemplate & ".Crex_Element, " & txttemplate & ".Climsoft_Element, " & txttemplate & ".Element_Name, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & txttemplate & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data INTO bufr_crex_data FROM " & txttemplate & " INNER JOIN bufr_crex_master ON " & txttemplate & ".Crex_Element = bufr_crex_master.Crex_Fxxyyy ORDER BY " & txttemplate & ".order;"

If clicom.table_exist("bufr_crex_data", dbase) Then db.TableDefs.delete "bufr_crex_data"
If clicom.query_exist("qry_template", dbase) Then db.QueryDefs.delete ("qry_template")
Set qry = db.CreateQueryDef("qry_template", sql)
qry.Execute

Set rsbx = db.OpenRecordset("bufr_crex_data")
Bufr_Crex_Initialize db  'Set all values to missing

'Set rs = db.OpenRecordset(tbl)

Dim substs As Integer

'Set recordset rs to the subsets query
Set rs = db.OpenRecordset("qry_subsets")
rs.MoveLast

' Get the number of subsets
substs = rs.RecordCount

sss = Format(substs, "000")
subsets = Format(substs, "000")

rs.MoveFirst
Open fso.GetParentFolderName(App.Path) & "\data\crex_subsets.txt" For Append As #10
Open fso.GetParentFolderName(App.Path) & "\data\bufr_subsets.txt" For Output As #20

''' Refresh the CREX table
'
'sql = "UPDATE bufr_crex_data SET bufr_crex_data.observation = ""/"", bufr_crex_data.Crex_Data = """";" ', bufr_crex_data.Bufr_Data = """";"
'
'If clicom.query_exist("qry_crex_refresh", dbase) Then db.QueryDefs.delete ("qry_crex_refresh")
'Set qry = db.CreateQueryDef("qry_crex_refresh", sql)
'qry.Execute

' Loop through the subsets
Do While rs.EOF = False
substs = substs - 1

' Set the replicated elements according to observations per subset

Set_Replications db, rs


' Update Station name to enable retrieval of the station details from the climsoft station lookup table

rsbx.MoveFirst
Do While rsbx.EOF = False
If rsbx.Fields("Climsoft_Element") = "station_name" Then
   rsbx.Edit
   rsbx.Fields("Observation") = txtstation
   rsbx.update
 Exit Do
 End If
 rsbx.MoveNext
Loop

'Exit Sub


sql = "SELECT lookup_station.id, lookup_station.station_name AS observation, Left([id_alias],2) AS block, Right([id_alias],3) AS [number], IIf([qualifier]=""AUTOMATIC"",2 Or [qualifier]<>""AUTOMATIC"",1) AS type, lookup_location.latitude AS lat, lookup_location.longitude AS lon, lookup_location.elevation AS height FROM (lookup_station INNER JOIN lookup_stationid_alias ON lookup_station.id = lookup_stationid_alias.refers_to) INNER JOIN lookup_location ON lookup_station.id = lookup_location.occupied_by " & _
      "WHERE (((lookup_station.station_name)=""" & rs.Fields("station_name") & """) AND ((lookup_stationid_alias.belongs_to)=""wmo_id""));"

If clicom.query_exist("qry_crex_location", dbase) Then db.QueryDefs.delete ("qry_crex_location")
Set qry = db.CreateQueryDef("qry_crex_location", sql)

' Set the recordset to the location query
Set rsbx1 = db.OpenRecordset("qry_crex_location")

'The following statement helps to skip a record without location. But it has been found to work similarly with resume next on empty record error
'If rsbx1.RecordCount = 0 Then GoTo NextSubset

' Determine whether it a is sysnoptic station
If IsNull(rsbx1.Fields("block")) Then
 MsgBox "Can't Code. WMO Station Number not found"
 Exit Sub
' If MsgBox("Not a Synoptic station. Continue?", vbYesNo, "Synop Crex") = vbNo Then Exit Sub
End If

'Update Data with the synop_crex form
With rsbx
.MoveFirst
  Do While .EOF = False
    ' Update Station Name, Observation times and Instrument parameters from the synop interface form
        .Edit
     Select Case .Fields("Climsoft_Element")
'        Case "station_WMO_bloc"
'           .Fields("Observation") = rsbx1.Fields("bloc")
'        Case "station_WMO_number"
'           .Fields("Observation") = rsbx1.Fields("number")
        Case "station_name"
          .Fields("Observation") = rs.Fields("station_name") 'txtstation
        Case "datetime_year"
          .Fields("observation") = Format(rs.Fields("yyyy"), "0000") 'Format(txtyear, "0000")
        Case "datetime_month"
          .Fields("observation") = Format(rs.Fields("mm"), "00") 'Format(txtmonth, "00")
        Case "datetime_day"
          .Fields("observation") = Format(rs.Fields("dd"), "00") 'Format(txtday, "00")
        Case "datetime_hour"
           .Fields("observation") = Format(rs.Fields("hh"), "00") 'Format(txthour, "00")
        Case "datetime_minute"
           .Fields("observation") = Format(txtminute, "00")
'        Case "5"
        Case "Temp_SH" ' Sensor height for temperature measurement
           If txtth = "" Then
              .Fields("observation") = "/"
             Else
              .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "TEMP_I", "instal_level")  'txtth
           End If
        Case "Vis_SH" ' Sensor height for visibility measurement
            If txtvh = "" Then
              .Fields("observation") = "/"
             Else
              .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "VISIB_I", "instal_level") 'txtvh
            End If
        Case "R24_SH" ' Sensor height for precipitation measurement
            If txtrh = "" Then
              .Fields("observation") = "/"
             Else
              .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "PRECIP_I", "instal_level") 'txtrh
            End If
        Case "xt_SH" ' Sensor height for extreme temperature measurement
             If txtth = "" Then
              .Fields("observation") = "/"
             Else
              .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "TEMP_I", "instal_level") 'txtth
             End If
        Case "w_SH" ' Sensor height for wind measurement
             If txtwh = "" Then
              .Fields("observation") = "/"
             Else
              .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "WIND_I", "instal_level") 'txtwh
             End If
        Case "ww_TP" ' Time Period for Past and Present Weather
             If CLng(hour(txthour)) Mod 6 = 0 Then
               .Fields("observation") = -6
              Else
               .Fields("observation") = -3
             End If
        Case "tR_TP" ' Time Period for precipitation replication 1
           .Fields("observation") = Rain_Diplacement(CInt(Left(txthour, 2))) '-24
        Case "tr_TP"  ' Time Period for precipitation replication 2
           .Fields("observation") = -3
        Case "evap_TP" ' Time Period for evaporation
           .Fields("observation") = -24
        Case "evap_I"
           .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "EVAP_I", "instrument_type") 'txtit
        Case "SSS_TP" ' Time Period for sunshine replication 1
           .Fields("observation") = -24
        Case "SS_TP" ' Time Period for sunshine replication 2
            .Fields("observation") = -1
        Case "RR_SH" ' Sensor height for precipitation for the replications
           If txtrh = "" Then
              .Fields("observation") = "/"
             Else
              .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "PRECIP_I", "instal_level") 'txtrh
           End If
'        Case "w_SH"
'           .Fields("observation") = txtwh
        Case "w_I"
           .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "WIND_I", "instrument_type") ' txtwi  Get_Instrument("station_instrument", rs, "BARO_I", "instal_level")
        Case "xt_TP" ' Time Period for maximum temperature
           .Fields("observation") = -12
        Case "xt0_TP" ' Time Period for maximum temperature ending at nominal time of the report
           .Fields("observation") = 0
        Case "nt_TP" ' Time Period for minimum teperature
           .Fields("observation") = -12
        Case "nt0_TP" ' Time Period for minimum teperature ending at nominal time of the report
           .Fields("observation") = -0
        Case "w_TS" ' Time Significance for wind
          .Fields("observation") = 2
        Case "w_TP" ' Time Period for wind
           .Fields("observation") = -10
        Case "evap_SH" ' Sensor height for Evaporation/Evatranspiration
           If txtrh = "" Then
              .Fields("observation") = "/"
             Else
              .Fields("observation") = txtrh
           End If
        Case "rad1_TP"
           .Fields("observation") = -1
        Case "rad2_TP"
           .Fields("observation") = -24
        Case "tempc_t" ' Time Period for Past and Present Weather
             If CLng(hour(txthour)) Mod 6 = 0 Then
               .Fields("observation") = -6
              Else
               .Fields("observation") = -3
             End If
     End Select
        .update

  ' Update with entered observations for each subset
    For i = 0 To rs.Fields.count - 1
      obsv = ""
      If rs.Fields(i).name = rsbx.Fields("Climsoft_Element") Then
         obsv = rs.Fields(i)
         
         ' Scaling pressure and Radiation values
         If rs.Fields(i).name = "137" And obsv <> "" Then obsv = obsv & "000000"
         If rs.Fields(i).name = "106" Or rs.Fields(i).name = "107" Or rs.Fields(i).name = "399" Or rs.Fields(i).name = "301" Or rs.Fields(i).name = "400" Then
            If obsv <> "" Then
               obsv = CLng(rs.Fields(i)) * 100
            End If
         End If
         
        .Edit
        .Fields("observation") = obsv
        .update
    End If
Nexxt:
    Next i

   .MoveNext
  Loop
  
' Compute cloud layers replication factor
rep1 = 0
rp2 = 0
.MoveFirst
Do While .EOF = False
  Select Case .Fields("Climsoft_Element")
  ' Cloud layers above station level
   Case "116"  'Cloud amount; first layer present
     If .Fields("observation") <> "" Then rep1 = rep1 + 1
   Case "120"  'Cloud amount; second second layer present
     If .Fields("observation") <> "" Then rep1 = rep1 + 1
   Case "124"  'Cloud amount; third layer present
     If .Fields("observation") <> "" Then rep1 = rep1 + 1
   Case "128"  'Cloud amount; fourth layer present
     If .Fields("observation") <> "" Then rep1 = rep1 + 1
     
  ' Cloud layers below station level
   Case "612"  'Cloud amount; first layer present
     If .Fields("observation") <> "" Then rep2 = rep2 + 1
   Case "622"  'Cloud amount; second second layer present
     If .Fields("observation") <> "" Then rep2 = rep2 + 1
   Case "632"  'Cloud amount; third layer present
     If .Fields("observation") <> "" Then rep2 = rep2 + 1
   Case "642"  'Cloud amount; fourth layer present
     If .Fields("observation") <> "" Then rep2 = rep2 + 1
   End Select
  .MoveNext
 Loop

' Update station location, elevation, pressure change characteristic and clouds replication factors
Dim vertical_sig  As String
.MoveFirst
rsbx1.MoveFirst
Do While .EOF = False
   vertical_sig = ""
   .Edit
     Select Case .Fields("Climsoft_Element")
        Case "station_WMO_bloc"
          .Fields("observation") = rsbx1.Fields("block")
        Case "station_WMO_number"
          .Fields("observation") = rsbx1.Fields("number")
        Case "station_qualifier"
          .Fields("observation") = rsbx1.Fields("type")
        Case "station_deglatitude"
          .Fields("observation") = rsbx1.Fields("lat")
        Case "station_deglongitude"
           .Fields("observation") = rsbx1.Fields("lon")
        Case "station_elevation"
           .Fields("observation") = rsbx1.Fields("height")
        Case "station_pressure_height"
           .Fields("observation") = Val(rsbx1.Fields("height")) + Val(Get_Instrument("station_instrument", rs.Fields("station_id"), "BARO_I", "instal_level")) 'CInt(txtbr)
        Case "cloud_rep1"
           .Fields("observation") = rep1
        Case "cloud_rep2"
           .Fields("observation") = rep2
        Case "532"
           If Not IsNull(.Fields("observation")) Then .Fields("observation") = CInt(.Fields("observation")) * 60 'Sunshine minutes
        Case "114"
           If Not IsNull(.Fields("observation")) Then .Fields("observation") = Val(.Fields("observation")) * 12.5 'Total Cloud Cover
     End Select
    .update
.MoveNext
Loop

' Format for Trace rainfall if it exist

' Trace for 24 Hour Precipation
   .MoveFirst
    Do While .EOF = False
       If .Fields("Climsoft_Element") = "5" And Trace24hr = True Then
          .Edit
            .Fields("observation") = -1
          .update
       End If
     .MoveNext
    Loop

 ' Trace for 3 Hour Precipation
     .MoveFirst
    Do While .EOF = False
       If .Fields("Climsoft_Element") = "174" And Trace3hr = True Then
          .Edit
            .Fields("observation") = -1
          .update
       End If
     .MoveNext
    Loop

' Update Precipitation characteristic
Dim ChrR As String

 ChrR = Precip_Char(rsbx)
.MoveFirst
   Do While .EOF = False
    .Edit
    If .Fields("Climsoft_Element") = "505" Then
        .Fields("observation") = ChrR
        .update
       ElseIf .Fields("Climsoft_Element") = "506" Then
        .Fields("observation") = 9
        .update
    End If
    .MoveNext
   Loop

' Encode data ////////////////////////////////////////////////

.MoveFirst

Dim miss As Boolean
Dim dats As String


Do While .EOF = False
 If .Fields("observation") <> "" Then
    .Edit
    .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), .Fields("Observation"), ScaleFactor(.Fields("Climsoft_Element"), db))
    .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), .Fields("Observation"), ScaleFactor(.Fields("Climsoft_Element"), db), db)
    .update
 End If
.MoveNext
Loop

' Convert Special Cloud data to CREX code
.MoveFirst

Dim N As String
Dim cl As String
Dim CM As String
Dim CH As String

Do While .EOF = False
 .Edit
   Select Case .Fields("Climsoft_Element")
'    Case "114" ' N
'      If .Fields("observation") <> "" Then N = .Fields("observation")
'      If .Fields("observation") <> "/" And .Fields("observation") <> "" Then .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CDbl(.Fields("observation")) * 12.5, ScaleFactor(.Fields("Climsoft_Element"), db))  'val (.Fields("observation")) * 12.5
    Case "169" 'Cloud type CL
      If .Fields("observation") <> "" Then
        cl = .Fields("observation")
        If N = "0" Then
           cl = 30
          ElseIf N = "9" Or N = "/" Or cl = "/" Or cl = "" Then
           cl = 62
          Else 'ElseIf CH <> "/" And CH <> "" Then
          cl = CDbl(.Fields("observation")) ' + 30
        End If
       .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), cl, ScaleFactor(.Fields("Climsoft_Element"), db))
       .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), cl, ScaleFactor(.Fields("Climsoft_Element"), db), db)
     End If
    Case "170" 'Cloud type CM
     If .Fields("observation") <> "" Then
       CM = .Fields("observation")
       If N = "0" Then
           CM = 20
         ElseIf N = "9" Or N = "/" Or CM = "/" Or CM = "" Then
           CM = 61
         Else 'ElseIf CH <> "/" And CH <> "" Then
           CM = CDbl(.Fields("observation")) '+ 20
       End If
      .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CM, ScaleFactor(.Fields("Climsoft_Element"), db))
      .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), CM, ScaleFactor(.Fields("Climsoft_Element"), db), db)
    End If
   Case "171" 'Cloud type CH
     If .Fields("observation") <> "" Then
       CH = .Fields("observation")
       If N = "0" Then
           CH = 10
         ElseIf N = "9" Or N = "/" Or CH = "/" Or CH = "" Then
           CH = 60
         Else 'ElseIf CH <> "/" And CH <> "" Then
           CH = CDbl(.Fields("observation")) ' + 10
       End If
     .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CH, ScaleFactor(.Fields("Climsoft_Element"), db))
     .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), CH, ScaleFactor(.Fields("Climsoft_Element"), db), db)
    End If
 End Select
 .update
.MoveNext
Loop
End With

' Coded message output

Dim message_header As String

sql = "SELECT bufr_crex_data.order, bufr_crex_data.Bufr_Template, bufr_crex_data.Crex_Template, bufr_crex_data.Sequence_Descriptor1, bufr_crex_data.Sequence_Descriptor0, bufr_crex_data.Bufr_Element, bufr_crex_data.Crex_Element, bufr_crex_data.Climsoft_Element, bufr_crex_data.Element_Name, bufr_crex_data.Crex_Unit, bufr_crex_data.Crex_Scale, bufr_crex_data.Crex_DataWidth, bufr_crex_data.Bufr_Unit, bufr_crex_data.Bufr_Scale, bufr_crex_data.Bufr_RefValue, bufr_crex_data.Bufr_DataWidth_Bits, bufr_crex_data.selected, bufr_crex_data.Observation, bufr_crex_data.Crex_Data, bufr_crex_data.Bufr_Data FROM bufr_crex_data " & _
      "WHERE ((bufr_crex_data.selected)=True) ORDER BY bufr_crex_data.order;"
   
message_header = msg_header & " " & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00")  '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)

' Include BBB if present
If txtBBB <> "" Then message_header = msg_header & " " & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00") & " " & txtBBB '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)

' Structure the output file name in format CCCCNNNNNNNN.ext
msg_file = Right(msg_header, 4) & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00") & Format(txtsecond, "00")

Select Case Me.Caption
 Case "CREX Synop"
   If Not CREX_Code(sql, message_header, crex_indicators, check_digit.value, substs) Then MsgBox "CREX Coding error"
 Case "BUFR Synop"
   If Not Bufr_Section4(sql, Bufr_DataSection) Then MsgBox "Error in encoding Data Section"
End Select


' Coded message output

'Dim message_header As String
'
'sql = "SELECT bufr_crex_data.order, bufr_crex_data.Bufr_Template, bufr_crex_data.Crex_Template, bufr_crex_data.Sequence_Descriptor1, bufr_crex_data.Sequence_Descriptor0, bufr_crex_data.Bufr_Element, bufr_crex_data.Crex_Element, bufr_crex_data.Climsoft_Element, bufr_crex_data.Element_Name, bufr_crex_data.Crex_Unit, bufr_crex_data.Crex_Scale, bufr_crex_data.Crex_DataWidth, bufr_crex_data.Bufr_Unit, bufr_crex_data.Bufr_Scale, bufr_crex_data.Bufr_RefValue, bufr_crex_data.Bufr_DataWidth_Bits, bufr_crex_data.selected, bufr_crex_data.Observation, bufr_crex_data.Crex_Data, bufr_crex_data.Bufr_Data FROM bufr_crex_data " & _
'      "WHERE ((bufr_crex_data.selected)=True) ORDER BY bufr_crex_data.order;"
'
'message_header = msg_header & " " & Format(day(Date), "00") & Format(txthour, "00") & Format(txtminute, "00") & " " & txtBBB '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)
'
'Select Case Me.Caption
' Case "CREX Synop"
'   If Not CREX_Code(sql, message_header, crex_indicators, check_digit.value, substs) Then MsgBox "CREX Coding error"
' Case "BUFR Synop"
'   If Not Bufr_Section4(sql, Bufr_DataSection) Then MsgBox "Error in encoding Data Section"
'End Select
'
NextSubset:
rs.MoveNext
Loop

' Show encoded message
Select Case Me.Caption
 Case "CREX Synop"
   Dim msg As String
   msg = ""
'   MsgBox msg_file
   Open msg_file For Input As #1

   Do While EOF(1) = False
     Input #1, msg
     txt_message = txt_message & msg & Chr(13) & Chr(10)
   Loop
   output_file = msg_file
   Close #1
 Case "BUFR Synop"

 If bufr_edition = 3 Then ' BUFR up to edition 3
      If Not BUFR_Code_ver3(sql, message_header, Me, db, Bufr_DataSection) Then MsgBox "BUFR Coding error"
    Else ' BUFR up to edition 4
      If Not BUFR_Code(sql, message_header, Me, db, Bufr_DataSection) Then MsgBox "BUFR Coding error"
 End If
End Select

Close #10
Close #20
Screen.MousePointer = vbDefault
Exit Sub
Err:
Resume Next
If Err.Number = 3021 Then Resume Next ' Skip Subset without data
MsgBox Err.Number & " " & Err.description
Close #10
Close #20
Screen.MousePointer = vbDefault

End Sub

Private Sub Form_Load()
Dim dbase_path As String
Dim strPwd As String

On Error GoTo Err:

If Not clicom.read_registry("key05", dbase_path) Then Exit Sub

lookup_station.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase_path & ";Persist Security Info=False"

lookup_station.Refresh

'Update captions of this form
LoadResStrings Me

'subsets = ""
Data_Description_Section = ""
Open fso.GetParentFolderName(App.Path) & "\data\crex_subsets.txt" For Output As #10
Close #10
If Not Load_Indicators(Me) Then Exit Sub
Exit Sub
Err:
 MsgBox Err.description
End Sub

Private Sub lookup_station_Error(ByVal ErrorNumber As Long, description As String, ByVal Scode As Long, ByVal Source As String, ByVal helpfile As String, ByVal HelpContext As Long, fCancelDisplay As Boolean)
    'Ignore any error messages. This suppresses the ODBC connectionstring error
    fCancelDisplay = True
End Sub

Private Sub myhelp_Click()
If Me.Caption = "BUFR Synop" Then
   GetHtmlHelpTopic App.helpfile, "bufr_synop.htm" '"crex.htm"
      Else
       GetHtmlHelpTopic App.helpfile, "crex_synop.htm"
 End If
End Sub

Private Sub ok0_Click()

End Sub

Private Sub station_Click(Area As Integer)
If Len(station.Text) >= 1 And Len(txtyear.Text) >= 1 And Len(txtmonth.Text) >= 1 And Len(txthour.Text) >= 1 Then
   ok.Enabled = True
End If
End Sub


Private Sub ooooo_Change()
If IsNumeric(ooooo) Then Update_Indicator "09", "crex", ooooo
End Sub

Private Sub OptEmail_Click()
If OptEmail.value = True Then
   framemail.Enabled = True
   frmftp.Enabled = False
   mails_list.Enabled = True
'  Else
'   framemail.Enabled = False
'   frmftp.Enabled = True
End If
End Sub

Private Sub OptFTP_Click()
If OptFTP.value = True Then
   frmftp.Enabled = True
   framemail.Enabled = False
   mails_list.Enabled = False
'  Else
'   frmftp.Enabled = False
'   framemail.Enabled = True
End If
End Sub

Private Sub originating_centre_Change()
If IsNumeric(originating_centre) Then Update_Indicator "09", "bufr", originating_centre
End Sub

Private Sub originating_subcentre_Change()
If IsNumeric(ppp) Then Update_Indicator "10", "bufr", originating_subcentre
End Sub

Private Sub ppp_Change()
If IsNumeric(ppp) Then Update_Indicator "10", "crex", ppp
End Sub

Private Sub txt_message_Change()
If txt_message <> "" Then
'    email_address.Enabled = True
'    email_subject.Enabled = True
''    email_domain.Visible = True
    OptEmail.Enabled = True
    OptFTP.Enabled = True
'    mails_list.Enabled = True
    cmd_view.Enabled = True
'    Checkftp.Enabled = True
'    frmftp.Enabled = True
  Else
'    email_address.Enabled = False
'    email_subject.Enabled = False
''    email_domain.Visible = False
    OptEmail.Enabled = False
    OptFTP.Enabled = False
'    mails_list.Enabled = False
    cmd_view.Enabled = False
'    Checkftp.Enabled = False
'    frmftp.Enabled = False
 End If
End Sub

Private Sub txtBBB_Change()
'If Len(txtBBB) <> 3 Then
' MsgBox "Incorrect Entry"
' txtBBB = ""
'End If
End Sub

Private Sub txtBBB_LostFocus()
If Len(txtBBB) <> 3 And txtBBB <> "" Then
 MsgBox "Incorrect Entry"
 txtBBB = ""
End If
End Sub



Private Sub txtbr_Change()
If IsNumeric(txtbr) Then Update_Instrument "station_instrument", Me, "BARO_I", "instal_level", txtbr
End Sub

Private Sub txtbr_LostFocus()
Update_Instrument "station_instrument", Me, "BARO_I", "instal_level", txtbr
End Sub

Private Sub txtit_Change()
If IsNumeric(txtit) Then Update_Instrument "station_instrument", Me, "EVAP_I", "instrument_type", txtit
End Sub

Private Sub txtit_LostFocus()
Update_Instrument "station_instrument", Me, "EVAP_I", "instrument_type", txtit
End Sub

Private Sub txtmonth_Change()
If Len(txtstation) >= 1 And Len(txtyear.Text) >= 1 And Len(txtmonth.Text) >= 1 And Len(txthour.Text) >= 1 Then
   ok.Enabled = True
End If
End Sub



Private Sub txthour_Change()
 Dim hh As Variant
 Dim msghd As String
 hh = Val(txthour)
 C$ = hh Mod 6
 clicom.read_registry "key15", msghd
'  MsgBox msghd
 If Me.Caption = "CREX Synop" Then
  If txthour <> "" And hh <= 21 Then
      Select Case C$ Mod 6
       Case 0
    '    Main Hour
         msg_header = msghd
         mmm = "002"
       Case 3
    '    Intermediate Hour
         Mid(msghd, 3, 1) = "I"
          msg_header = msghd
         mmm = "001"
       Case Else
    '    Other Hours
         mmm = "000"
         Mid(msghd, 3, 1) = "N"
          msg_header = msghd
      End Select
  End If
End If

If Me.Caption = "BUFR Synop" Then
 If txthour <> "" And hh <= 21 Then
      Select Case C$ Mod 6
       Case 0
    '    Main Hour
         Mid(msghd, 1) = "I" ' = "ISMH40 HKNC"
         msg_header = msghd
         mmm = "002"
       Case 3
    '    Intermediate Hour
         Mid(msghd, 1) = "I"
         Mid(msghd, 3) = "I"
         msg_header = msghd
         mmm = "001"
       Case Else
    '    Other Hours
         Mid(msghd, 1) = "I"
         Mid(msghd, 3) = "N"
         msg_header = msghd
         mmm = "000"
      End Select
  End If
End If

End Sub




Private Sub txtrh_Change()
If IsNumeric(txtrh) Then Update_Instrument "station_instrument", Me, "PRECIP_I", "instal_level", txtrh
End Sub

Private Sub txtrh_LostFocus()
Update_Instrument "station_instrument", Me, "PRECIP_I", "instal_level", txtrh
End Sub

Private Sub txtstation_Change()
txthour_Change
Load_Instrument
End Sub

Private Sub txtth_Change()
If IsNumeric(txtth) Then Update_Instrument "station_instrument", Me, "TEMP_I", "instal_level", txtth
End Sub

Private Sub txtth_LostFocus()
Update_Instrument "station_instrument", Me, "TEMP_I", "instal_level", txtth
End Sub



Private Sub txtvh_Change()
If IsNumeric(txtvh) Then Update_Instrument "station_instrument", Me, "VISIB_I", "instal_level", txtvh
End Sub

Private Sub txtvh_LostFocus()
Update_Instrument "station_instrument", Me, "VISIB_I", "instal_level", txtvh
End Sub



Private Sub txtwh_Change()
If IsNumeric(txtwh) Then Update_Instrument "station_instrument", Me, "WIND_I", "instal_level", txtwh
End Sub

Private Sub txtwh_LostFocus()
Update_Instrument "station_instrument", Me, "WIND_I", "instal_level", txtwh
End Sub

Private Sub txtwi_Change()
If IsNumeric(txtwi) Then Update_Instrument "station_instrument", Me, "WIND_I", "instrument_type", txtwi
End Sub

Private Sub txtwi_LostFocus()
Update_Instrument "station_instrument", Me, "WIND_I", "instrument_type", txtwi
End Sub



'Private Sub txttime_Change()
'If Len(station.Text) >= 1 And Len(txtyear.Text) >= 1 And Len(txtmonth.Text) >= 1 And Len(txttime.Text) >= 1 Then
'   ok.Enabled = True
'End If
'' Rainfall Time displacement
'If Not IsNull(txttime) Then Rain_Diplacement val(Left(txttime, 2))
'End Sub

Private Sub txtyear_Change()
If Len(txtstation) >= 1 And Len(txtyear.Text) >= 1 And Len(txtmonth.Text) >= 1 And Len(txthour.Text) >= 1 Then
   cmd_encode.Enabled = True
End If
End Sub

Function set_24hr_obsv(hr As String, db As dao.Database) As Boolean
On Error GoTo Err
set_24hr_obsv = True
Dim obsv_hr As String
Dim tt As Integer
Dim mxtt As Integer

' Get the 24hr observation time
obsv_hr = GetSetting("Climsoft", "Options", "obs_time")

' Get the observation time for Tmax


' observation time for 6 hourly precipitation duration and Tmin

If (Val(Left(obsv_hr, 2)) - Val(Left(hr, 2))) Mod 3 = 0 Then
  Enable_Xrex_Element 5, db
  Enable_Xrex_Element 504, db
 Else
'  MsgBox hr
  disable_Xrex_Element 5, db
  disable_Xrex_Element 504, db
End If

' observation time for 24hr  Tmin
If hr = obsv_hr Then
  Enable_Xrex_Element 3, db
 Else
'  MsgBox hr
  disable_Xrex_Element 3, db
End If
 
' observation time for Tmax
mxtt = CInt(Left(obsv_hr, 2)) + 12
tt = CInt(Left(hr, 2))
If mxtt = tt Then
  Enable_Xrex_Element 2, db
 Else
  disable_Xrex_Element 2, db
End If

Exit Function
Err:
set_24hr_obsv = False
MsgBox Err.description
End Function


Sub Enable_Xrex_Element(element As String, db As dao.Database)
 Dim crex As dao.Recordset
' MsgBox element
 Set crex = db.OpenRecordset("txttemplate")
 With crex
  Do While .EOF = False
   If Not IsNull(.Fields("Climsoft_Element")) Then
    If .Fields("Climsoft_Element") = element Then
'    MsgBox .Fields("Selected")
     .Edit
     .Fields("Selected") = True
     .update
     Exit Do
    End If
   End If
  .MoveNext
  Loop
 
 End With

End Sub

Sub disable_Xrex_Element(element As String, db As dao.Database)
 On Error GoTo Err
Dim crex As dao.Recordset
' MsgBox element
 Set crex = db.OpenRecordset("txttemplate")
 With crex
  .MoveFirst
'  MsgBox .Fields("Climsoft_Element") & " " & .Fields("Selected")
  Do While .EOF = False
   If Not IsNull(.Fields("Climsoft_Element")) Then
'    MsgBox .Fields("Climsoft_Element") & " " & .Fields("Selected")
    If .Fields("Climsoft_Element") = element Then
'     MsgBox .Fields("Selected")
     .Edit
     .Fields("Selected") = False
     .update
     Exit Do
    End If
   End If
   
  .MoveNext
  Loop
 
 End With
Exit Sub
Err:
MsgBox Err.description
End Sub

Function ScaleFactor(code As String, db As dao.Database) As Variant

ScaleFactor = 1

On Error GoTo Err
Dim rs As dao.Recordset
Set rs = db.OpenRecordset("lookup_element")

With rs
 .MoveFirst
 Do While .EOF = False
    If .Fields("code") = code Then
     ScaleFactor = Val(.Fields("element_scale"))
'     If Code = 5 Then MsgBox "Scale factor = " & ScaleFactor
     Exit Function
    End If
  .MoveNext
 Loop
End With
Exit Function
Err:
 Resume Next
End Function

Function Rain_Diplacement(hr As Integer) As Integer
On Error GoTo Err
Rain_Diplacement = 0
 Select Case hr
   Case 0
     Rain_Diplacement = -6
   Case 3
     Rain_Diplacement = -3
   Case 6
     Rain_Diplacement = -24
   Case 9
     Rain_Diplacement = -3
   Case 12
     Rain_Diplacement = -6
   Case 15
     Rain_Diplacement = -3
   Case 18
     Rain_Diplacement = -12
   Case 21
     Rain_Diplacement = -3
End Select
Exit Function
Err:
MsgBox Err.description
End Function

Function Cloud_Sig(crx As dao.Recordset) As String

Dim cl As String
Dim CM As String
Dim CH As String
Dim N As String
Dim count As Integer
Dim cod As String

Cloud_Sig = ""
cl = "/"
CM = "/"
CH = "/"
N = "/"

count = 0

With crx
.MoveFirst
Do While .EOF = False
 If .Fields("observation") <> "" And .Fields("observation") <> "/" Then
   Select Case .Fields("Climsoft_Element")
    Case 178
     N = .Fields("observation")
   Case 178
     cl = .Fields("observation")
     count = count + 1
   Case 179
     CM = .Fields("observation")
     count = count + 1
   Case 180
     CH = .Fields("observation")
     count = count + 1
  End Select
 End If
  .MoveNext
Loop

End With

Select Case N
  Case 9
   Cloud_Sig = 5
   Exit Function
 Case "/"
   Cloud_Sig = "/"
   Exit Function
End Select

If count > 1 Then
  Cloud_Sig = 0
  Exit Function
End If

If cl <> "/" Then
   Cloud_Sig = 7
 ElseIf CM <> "/" Then
   Cloud_Sig = 8
 ElseIf CH <> "/" Then
   Cloud_Sig = 9
End If
End Function

Function Cloud_Sig1(crx As dao.Recordset) As String
Cloud_Sig1 = 1
With crx
.MoveFirst
Do While .EOF = False
   Select Case .Fields("Climsoft_Element")
    Case 116
     If Val(.Fields("observation")) = 4 Then ' N=9
         Cloud_Sig1 = 5
         Exit Do
        ElseIf .Fields("observation") = "/" Then
          Cloud_Sig1 = "/"
          Exit Do
     End If
     
    Case 117
      If Val(.Fields("observation")) = 4 Then ' CB cloud present
           Cloud_Sig1 = 4
           Exit Do
         Else
           Cloud_Sig1 = 1
           Exit Do
      End If
  End Select

  .MoveNext
Loop
End With
End Function

Function Cloud_Sig2(crx As dao.Recordset) As String
With crx
.MoveFirst
Do While .EOF = False
 If .Fields("Climsoft_Element") = 121 Then
   If Val(.Fields("observation")) = 4 Then  ' CB cloud present
      Cloud_Sig2 = 4
     Else
      Cloud_Sig2 = 2
    End If
  Exit Do
 End If
 .MoveNext
 Loop
End With
End Function


Function Cloud_Sig3(crx As dao.Recordset) As String
With crx
.MoveFirst
Do While .EOF = False
 If .Fields("Climsoft_Element") = 125 Then
   If Val(.Fields("observation")) = 4 Then  ' CB cloud present
      Cloud_Sig3 = 4
     Else
      Cloud_Sig3 = 3
    End If
  Exit Do
 End If
 .MoveNext
 Loop
End With
End Function

Function Cloud_Sig4(crx As dao.Recordset) As String
With crx
.MoveFirst
Do While .EOF = False
 If .Fields("Climsoft_Element") = 129 Then
   Cloud_Sig4 = Val(.Fields("observation"))
'   If val(.Fields("observation")) = 4 Then Cloud_Sig4 = 4 ' CB cloud present
  Exit Do
 End If
 .MoveNext
 Loop
End With
End Function


Function Trace_Rain(db As dao.Database, rs As dao.Recordset, pos As Variant) As Boolean

Trace_Rain = False
On Error GoTo Err
Dim dfr As dao.Recordset
Dim st As Integer
Dim Ed As Integer
Dim flg As Integer

Set dfr = db.OpenRecordset("data_forms")

With dfr
Do While .EOF = False
 If .Fields("table_name") = tbl Then
  st = .Fields("val_start_position")
   Ed = .Fields("val_end_position")
   flg = Ed + (pos - st) + 1
   If rs.Fields(flg) = "T" Then Trace_Rain = True
  Exit Do
 End If
.MoveNext
Loop
End With
Exit Function
Err:
End Function

Function crex_indicators() As String

crex_indicators = ""
'If Template "TM_307089" for manual encoding is selected then set its indicators accordingly

If txttemplate = "TM_307089" Then
 crex_indicators = "T000104 A000"
 Exit Function
End If

Dim Ttteevvbbww As String ' Tables Editions-Versions, tt=0 for WMO CREX Master Table
Dim Annnmmm As String     ' Data Category and Sub-Category
Dim Poooooppp As String   ' Message Originating Center and Sub-Center
Dim Uuu As String         ' Message Sequence Number
Dim Ssss As String        ' Number of Subsets in the report
Dim Yyyyymmdd As String   ' The typical Year, Month and Day for the message
Dim Hhhnn As String       ' Hour and Minutes

''Ttteevvbbww = crextable
'Annnmmm = data_category
'Poooooppp = originating_center
'Uuu = sequence_number
'Ssss = "S000"
Hhhnn = Format(Left(txthour, 2), "00") & Format(Right(txtminute, 2), "00")

Yyyyymmdd = txtyear & Format(txtmonth, "00") & Format(txtday, "00") '"H" & Format(Left(txthour, 2), "00") & Format(Right(txthour, 2), "00")

header = msg_header & " " & Format(day(Date), "00") & Format(Left(txthour, 2), "00") & "00" '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)

'crex_indicators = Ttteevvbbww & " " & Annnmmm & " " & Poooooppp & " " & Uuu & " " & Ssss & " " & Yyyyymmdd & " " & Hhhnn
crex_indicators = "T00" & ee & vv & bb & ww & " A" & nnn & mmm & " P" & ooooo & ppp & " U" & uu & " S" & sss & " Y" & Yyyyymmdd & " H" & Hhhnn
End Function

Sub Bufr_Crex_Initialize(db As dao.Database)
  On Error GoTo Err
  Dim rs As dao.Recordset
  Dim rsct As dao.Recordset
  Dim crex_siz As Integer
  Dim bufr_siz As Integer
  Dim InitValue As String
  Dim i As Integer
  Set rs = db.OpenRecordset("bufr_crex_data")
  Set rsct = db.OpenRecordset("FlagTable")
  ' Clear previously encoded data
  With rs
  .MoveFirst
    Do While .EOF = False
    .Edit
    .Fields("Crex_Data") = ""
    .Fields("Bufr_Data") = ""
    .update
   .MoveNext
  Loop
  
  ' Initialized with missing data character
  .MoveFirst
  Do While .EOF = False
   
   If .Fields("Crex_DataWidth") <> "" Then crex_siz = .Fields("Crex_DataWidth")
   If .Fields("Bufr_DataWidth_Bits") <> "" Then bufr_siz = .Fields("Bufr_DataWidth_Bits")
   
   .Edit
'   Initialize crex data as missing
     InitValue = "/"
     For i = 2 To crex_siz
       InitValue = InitValue & "/"
     Next i
     .Fields("Crex_Data") = InitValue
'   Initialize bufr data as missing
     InitValue = "1"
     For i = 2 To bufr_siz
       InitValue = InitValue & "1"
     Next i
     .Fields("Bufr_Data") = InitValue
 '   Update data
      .update
    
   .MoveNext
  Loop
  
  
 ' Initialize crex code table data with the approriate code figure for missing data
  .MoveFirst
  Do While .EOF = False

   If .Fields("Crex_Unit") = "Code table" Then
    rsct.MoveFirst
    Do While rsct.EOF = False
      If rsct.Fields("Crex_Descriptor") = .Fields("Crex_Element") Then
        .Edit
          .Fields("Crex_Data") = rsct.Fields("Missing")
          .Fields("Bufr_Data") = Decimal_Binary(rsct.Fields("Missing"), .Fields("Bufr_DataWidth_Bits"))
        .update
        Exit Do
      End If
     rsct.MoveNext
    Loop
   End If
  .MoveNext
  Loop
  
 End With
 
 Exit Sub
Err:
 MsgBox Err.description
End Sub

Sub Set_Replications(db As dao.Database, rs As dao.Recordset)
 Dim rx As dao.Recordset

' Set rx = db.OpenRecordset("txttemplate")
Set rx = db.OpenRecordset("bufr_crex_data")
' Initialize the replicatable cloud layers to FALSE
Initialize_Cloud_Replications rx, "119", 4, "cloud_rep1" 'Delayed replication of cloud layers above station level 4 times for a maximum of 4 layers
Initialize_Cloud_Replications rx, "611", 5, "cloud_rep2" 'Delayed replication of cloud layers below station level 4 times for a maximum of 5 layers

' Set the replicated cloud layers to TRUE if observations made
With rs

' .Index = "Identification"
' .Seek "=", StationNb(Me), txtyear.Text, txtmonth.Text, txtday.Text, txthour.Text & ":" & txtminute.Text
' If .NoMatch Then Exit Sub

  For i = 0 To .Fields.count - 1
   Select Case .Fields(i).name
    ' Clouds layers above station level
     Case "119"
       If .Fields(i) <> "" Then Select_Descriptor rx, "119", 4, "cloud_rep1"
     Case "123"
       If .Fields(i) <> "" Then Select_Descriptor rx, "123", 4, "cloud_rep1"
     Case "127"
       If .Fields(i) <> "" Then Select_Descriptor rx, "127", 4, "cloud_rep1"
     Case "131"
       If .Fields(i) <> "" Then Select_Descriptor rx, "131", 4, "cloud_rep1"
    
    ' Clouds layers below station level
     Case "611"
       If .Fields(i) <> "" Then Select_Descriptor rx, "611", 5, "cloud_rep2"
     Case "621"
       If .Fields(i) <> "" Then Select_Descriptor rx, "621", 5, "cloud_rep2"
     Case "631"
       If .Fields(i) <> "" Then Select_Descriptor rx, "631", 5, "cloud_rep2"
     Case "641"
       If .Fields(i) <> "" Then Select_Descriptor rx, "641", 5, "cloud_rep2"
   End Select
  Next i
   
End With
End Sub

Sub Set_Replications1(db As dao.Database, rs As dao.Recordset)
 Dim rx As dao.Recordset

' Set rx = db.OpenRecordset("txttemplate")
Set rx = db.OpenRecordset("bufr_crex_data")
' Initialize the replicatable cloud layers to FALSE
Initialize_Cloud_Replications rx, "119", 4, "cloud_rep1" 'Delayed replication of cloud layers above station level 4 times for a maximum of 4 layers
Initialize_Cloud_Replications rx, "611", 5, "cloud_rep2" 'Delayed replication of cloud layers below station level 4 times for a maximum of 5 layers

' Set the replicated cloud layers to TRUE if observations made
With rs

 .Index = "Identification"
 .Seek "=", StationNb(Me), txtyear.Text, txtmonth.Text, txtday.Text, txthour.Text & ":" & txtminute.Text
 If .NoMatch Then Exit Sub

  For i = 0 To .Fields.count - 1
   Select Case .Fields(i).name
    ' Clouds layers above station level
     Case "119"
       If .Fields(i) <> "" Then Select_Descriptor rx, "119", 4, "cloud_rep1"
     Case "123"
       If .Fields(i) <> "" Then Select_Descriptor rx, "123", 4, "cloud_rep1"
     Case "127"
       If .Fields(i) <> "" Then Select_Descriptor rx, "127", 4, "cloud_rep1"
     Case "131"
       If .Fields(i) <> "" Then Select_Descriptor rx, "131", 4, "cloud_rep1"
    
    ' Clouds layers below station level
     Case "611"
       If .Fields(i) <> "" Then Select_Descriptor rx, "611", 5, "cloud_rep2"
     Case "621"
       If .Fields(i) <> "" Then Select_Descriptor rx, "621", 5, "cloud_rep2"
     Case "631"
       If .Fields(i) <> "" Then Select_Descriptor rx, "631", 5, "cloud_rep2"
     Case "641"
       If .Fields(i) <> "" Then Select_Descriptor rx, "641", 5, "cloud_rep2"
   End Select
  Next i
   
End With
End Sub

Sub Initialize_Cloud_Replications(rx As dao.Recordset, StartElement As String, Rep_Factor As Variant, typ As String)
 
' ' Initialize replication factors
' rx.MoveFirst
' Do While rx.EOF = False
'    If rx.Fields("Climsoft_Element") = typ Then
'       rx.Edit
'       rx.Fields("selected") = True ' Incase by a mistake they are not selected
'       rx.update
'       rx.MoveNext
'     Exit Do
'    End If
'    rx.MoveNext
'  Loop
 
' Initialize cloud layers by setting them to FALSE so that they are not selected if observations not made
 rx.MoveFirst
  Do While rx.EOF = False
    If rx.Fields("Climsoft_Element") = StartElement Then
     For i = 1 To Rep_Factor * 4
       rx.Edit
       rx.Fields("selected") = False
       rx.update
       rx.MoveNext
     Next i
     Exit Do
    End If
    rx.MoveNext
  Loop
End Sub


Sub Select_Descriptor(rx As dao.Recordset, elm As String, layrs As Integer, typ As String)

' Select replication factors
  rx.MoveFirst
  Do While rx.EOF = False
    If rx.Fields("Climsoft_Element") = typ Then
       rx.Edit
       rx.Fields("Selected") = True
       rx.update
       rx.MoveNext
     Exit Do
    End If
    rx.MoveNext
  Loop
  
  ' Select cloud layers
  rx.MoveFirst
  Do While rx.EOF = False
    If rx.Fields("Climsoft_Element") = elm Then
     For i = 1 To layrs
       rx.Edit
       rx.Fields("Selected") = True
       rx.update
       rx.MoveNext
     Next i
     Exit Do
    End If
    rx.MoveNext
  Loop
End Sub

Function Precip_Char(rx As dao.Recordset) As String

Dim Tot As String
With rx
.MoveFirst
   Do While .EOF = False
    If .Fields("Climsoft_Element") = "5" And Not (IsNull(.Fields("observation").value)) Then
      Tot = .Fields("observation")
      If Tot = "" Then
           Precip_Char = 15
          ElseIf Tot = "0" Then
            Precip_Char = 0
          ElseIf Val(Tot) > 0 And Val(Tot) <= 100 Then
            Precip_Char = 1
          ElseIf Val(Tot) > 100 And Val(Tot) <= 500 Then
            Precip_Char = 2
          ElseIf Val(Tot) > 500 Then
            Precip_Char = 3
        End If
      Exit Do
    End If
    .MoveNext
   Loop
 End With
End Function

Sub Load_Instrument()
txtbr = Get_Instrument("station_instrument", StationNb(Me), "BARO_I", "instal_level")
txtth = Get_Instrument("station_instrument", StationNb(Me), "TEMP_I", "instal_level")
txtvh = Get_Instrument("station_instrument", StationNb(Me), "VISIB_I", "instal_level")
txtrh = Get_Instrument("station_instrument", StationNb(Me), "PRECIP_I", "instal_level")
txtwh = Get_Instrument("station_instrument", StationNb(Me), "WIND_I", "instal_level")
txtit = Get_Instrument("station_instrument", StationNb(Me), "EVAP_I", "instrument_type")
txtwi = Get_Instrument("station_instrument", StationNb(Me), "WIND_I", "instrument_type")

End Sub

'
'Sub Update_Indicator(I_code As String, I_type As String, I_txt As String)
'On Error GoTo Err
'Dim db As dao.Database
'Dim rs As dao.Recordset
'Dim dbase As String
'
'If Not clicom.read_registry("key05", dbase) Then Exit Sub
'Set db = dao.OpenDatabase(dbase)
'Set rs = db.OpenRecordset("TDCF_Indicators")
'
'With rs
'  .Index = "PrimaryKey"
'  .Seek "=", I_code
'  If Not .NoMatch Then
'   ' Update Indicator details
'     .Edit
'       .Fields(I_type) = I_txt
'     .update
'     End If
' End With
'Exit Sub
'Err:
'MsgBox Err.description
'End Sub
'
'Sub Load_Indicators()
'
'' Load Bufr and Crex Indicators
'ooooo = Format(Read_Indicator("09", "crex"), "00000") ' Originating Centre for Crex
'originating_centre = Read_Indicator("09", "bufr") ' Originating Centre for
'ppp = Format(Read_Indicator("10", "crex"), "000") ' Originating Sub Centre for Crex
'originating_subcentre = Read_Indicator("10", "bufr") ' Originating Sub Centre for Bufr
'
'End Sub
'Function Read_Indicator(I_code As String, I_type As String) As String
'On Error GoTo Err
'Dim db As dao.Database
'Dim rs As dao.Recordset
'Dim dbase As String
'
'If Not clicom.read_registry("key05", dbase) Then Exit Function
'Set db = dao.OpenDatabase(dbase)
'Set rs = db.OpenRecordset("TDCF_Indicators")
'
'With rs
'  .Index = "PrimaryKey"
'  .Seek "=", I_code
'  If Not .NoMatch Then Read_Indicator = .Fields(I_type)
' End With
'Exit Function
'Err:
'MsgBox Err.description
'End Function


