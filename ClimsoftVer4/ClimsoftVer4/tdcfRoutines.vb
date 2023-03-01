Public Class tdcfRoutines

    Function Binary_Decimal(BinN As String, ByRef BinD As Long) As Boolean

        Dim siz As Integer
        Dim dgt As String
        Dim posval As Integer
        Dim kount As Integer

        Try
            siz = Len(BinN)

            Binary_Decimal = True
            BinD = 0
            For kount = 0 To siz - 1
                dgt = Mid(BinN, siz - kount, 1)
                If IsNumeric(dgt) Then
                    posval = Int(dgt)
                    BinD = BinD + posval * 2 ^ kount
                End If
            Next kount
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function Decimal_Binary(DecN As Integer, bts As Integer) As String

        Dim r As Integer
        Dim s As Integer
        Dim x As String
        Dim binstr As String

        x = DecN
        binstr = 0

        Try
            ' Build a Zeros bitstring to the size of data width. Binary converted data will replace the Zoreos from right side 
            For i = 2 To bts
                binstr = binstr & "0"
            Next

            s = 0 ' Initialize the bits counter
            Do While bts > s
                r = DecN Mod 2

                ' Replace the Zero bit with the remainder value from division by 2
                Mid(binstr, bts - s, 1) = r

                If r = 1 Then
                    DecN = DecN / 2 - 0.5
                Else
                    DecN = DecN / 2
                End If
                s = s + 1
            Loop

            Return binstr

        Catch ex As Exception
            Return binstr
        End Try
    End Function

    Function CCITT_Binary(dat As String, DataWidth As Integer) As String
        Dim cconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim dacc As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dscc As New DataSet

        Dim binstr, dat1, chr1, chr2, sql As String
        Dim kount As Integer

        Try
            cconn.ConnectionString = frmLogin.txtusrpwd.Text
            cconn.Open()
            sql = "Select * FROM ccitt ;"

            dacc = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, cconn)
            dacc.SelectCommand.CommandTimeout = 0
            cconn.Close()

            dscc.Clear()
            dacc.Fill(dscc, "ccitt")

            ' Add leading zeroes to short data strings
            CCITT_Binary = ""
            binstr = ""
            If Len(dat) < DataWidth / 8 Then
                For kount = 1 To DataWidth - Len(dat) * 8
                    binstr = binstr & "0"
                Next kount
            Else
                dat = Strings.Left(dat, DataWidth / 8)
            End If

            ' Loop the entire data string

            For kount = 1 To Len(dat)

                With dscc.Tables("ccitt")

                    For i = 0 To .Rows.Count - 1
                        dat1 = Mid(dat, kount, 1)
                        If dat1 = " " Then dat1 = "SP"
                        If dat1 = .Rows(i).Item("Characters") Then
                            chr1 = .Rows(i).Item("MostSignificant")
                            chr2 = .Rows(i).Item("LeastSignificant")
                            binstr = binstr & Decimal_Binary(Val(chr1), 4) & Decimal_Binary(Val(chr2), 4)
                            Exit For
                        End If
                    Next

                End With
            Next kount

            CCITT_Binary = binstr
        Catch ex As Exception
            MsgBox(ex.Message)
            CCITT_Binary = ""
        End Try
    End Function
    Public Function WSI_data(stnid As String, ByRef WSI_section4 As String) As Boolean
        Dim wconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim daw As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsw As New DataSet
        Dim WSI, sql As String
        Dim seriesID, issuerID, issuerNo, localID As String
        Dim WSIsplit As Array
        Dim kount As Integer

        'WSI_section4 = ""

        Try
            wconn.ConnectionString = frmLogin.txtusrpwd.Text
            wconn.Open()
            sql = "Select wsi,gtsWSI FROM station WHERE stationId = '" & stnid & "';"

            daw = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, wconn)
            daw.SelectCommand.CommandTimeout = 0
            wconn.Close()

            dsw.Clear()
            daw.Fill(dsw, "wsi")

            With dsw.Tables("wsi")
                If .Rows.Count = 1 And .Rows(0).Item(1) = 1 Then
                    WSI = .Rows(0).Item(0)

                    WSIsplit = Strings.Split(WSI, "-")
                    kount = WSIsplit.Length - 1

                    'Check for the validity of the retrieved WSI
                    If kount = 3 Then
                        ' Check for existence of the 4 components of WSI struecture
                        For i = 0 To 3
                            If Len(WSIsplit(i)) = 0 Then Return False
                        Next
                        ' Compute binary data WSI
                        seriesID = Decimal_Binary(WSIsplit(0), 4)
                        issuerID = Decimal_Binary(WSIsplit(1), 16)
                        issuerNo = Decimal_Binary(WSIsplit(2), 16)
                        localID = CCITT_Binary(WSIsplit(3), 128)

                        WSI_section4 = seriesID & issuerID & issuerNo & localID

                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End With
        Catch ex As Exception
            wconn.Close()
            Return False
        End Try
    End Function

    Function WSI_Sequence(ByRef WSI_section3 As String) As Boolean

        Dim seq_desc, f, X, Y As String

        Try
            ' Compute binary WSI Sequence Descriptor "301150"
            seq_desc = "301150"

            ' Perform binary conversion
            f = Decimal_Binary(Strings.Left(seq_desc, 1), 2)
            X = Decimal_Binary(Strings.Mid(seq_desc, 2, 2), 6)
            Y = Decimal_Binary(Strings.Mid(seq_desc, 4, 3), 8)

            WSI_section3 = f & X & Y
            Return True

        Catch ex As Exception
            'Log_Errors(ex.Message)
            Return False
        End Try

    End Function
    Function FTP_Put(fl As String) As Boolean
        Dim fconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim fda As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim rf As New DataSet
        Dim ftp_host, Lflder, Rflder, Drv, ftpmode, usr, pwd, ftpscript, ftpbatch, binFile, sql As String

        Try

            fconn.ConnectionString = frmLogin.txtusrpwd.Text
            fconn.Open()

            sql = "SELECT * FROM aws_mss where foldertype = 'binary';"
            fda = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, fconn)
            fda.SelectCommand.CommandTimeout = 0
            fconn.Close()

            fda = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, fconn)
            fda.SelectCommand.CommandTimeout = 0
            fconn.Close()

            rf.Clear()
            fda.Fill(rf, "mss")

            With rf.Tables("mss") ' Only one message switch. Get its details
                If .Rows.Count = 0 Then
                    MsgBox("No Message Switch available")
                    Return False
                Else
                    ftp_host = .Rows(0).Item("ftpId")
                    Rflder = .Rows(0).Item("inputFolder")
                    ftpmode = .Rows(0).Item("ftpMode")
                    usr = .Rows(0).Item("userName")
                    pwd = .Rows(0).Item("password")

                End If
            End With

            ' Create a file and write FTP scripts therein for login to message switch server and transfer the BUFR file from source folder
            Lflder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"
            Drv = System.IO.Path.GetPathRoot(Application.StartupPath)
            Drv = Strings.Left(Drv, Len(Drv) - 1)

            ftpscript = Lflder & "\ftp_putFiles.txt"
            FileOpen(111, ftpscript, OpenMode.Output)

            binFile = Strings.Replace(fl, "tmp", "f") ' Create the filename string to rename the binary file once fully transferred into MSS

            ' Get filenames without path for use in script file
            binFile = IO.Path.GetFileName(binFile)
            fl = IO.Path.GetFileName(fl)

            If ftpmode = "FTP" Then
                Print(111, "open ftp://" & usr & ":" & pwd & "@" & ftp_host & Chr(13) & Chr(10))
            ElseIf ftpmode = "SFTP" Then
                Print(111, "open sftp://" & usr & ":" & pwd & "@" & ftp_host & Chr(13) & Chr(10))
            End If
            Print(111, "cd " & Rflder & Chr(13) & Chr(10))
            Print(111, "bin" & Chr(13) & Chr(10))
            Print(111, "put" & " " & IO.Path.GetFileName(fl) & Chr(13) & Chr(10))
            'Print(111, "mv" & " " & IO.Path.GetFileName(fl) & " " & IO.Path.GetFileName(binFile) & Chr(13) & Chr(10))
            Print(111, "mv" & " " & fl & " " & binFile & Chr(13) & Chr(10))
            Print(111, "close" & Chr(13) & Chr(10))
            Print(111, "exit" & Chr(13) & Chr(10))
            FileClose(111)

            ' Create batch file to execute FTP script file
            ftpbatch = Lflder & "\ftp_putFiles.bat"

            FileOpen(112, ftpbatch, OpenMode.Output)

            Print(112, "echo off" & Chr(13) & Chr(10))
            Print(112, Drv & Chr(13) & Chr(10))
            Print(112, "CD " & Lflder & Chr(13) & Chr(10))

            Print(112, Chr(34) & IO.Path.GetFullPath(Application.StartupPath) & "\WinSCP.com" & Chr(34) & " /ini=nul /script=" & IO.Path.GetFileName(ftpscript) & Chr(13) & Chr(10))
            Print(112, "echo on" & Chr(13) & Chr(10))
            Print(112, "close" & Chr(13) & Chr(10))
            Print(112, "exit" & Chr(13) & Chr(10))

            FileClose(112)

            ' Execute the batch file to transfer BUFR files
            'Shell(ftpbatch, vbMinimizedNoFocus)
            Interaction.Shell(ftpbatch, vbMinimizedNoFocus, Wait:=True)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message & " at FTP_put")
            FileClose(111)
            FileClose(112)
            Return False
        End Try

    End Function
    Function AWS_BUFR_Code(message_header As String, yy As String, mm As String, dd As String, hh As String, min As String, ss As String, binary_data As String, Optional WSId As Boolean = False) As Boolean

        ' Set message header according to the hour category 
        If Val(hh) Mod 6 = 0 Then
            Mid(message_header, 3, 1) = "M"
        ElseIf Val(hh) Mod 6 = 3 Then
            Mid(message_header, 3, 1) = "I"
        Else
            Mid(message_header, 3, 1) = "N"
        End If

        AWS_BUFR_Code = False

        Try

            'Dim octets As String
            'Dim section0 As String
            'Dim section1 As String
            'Dim section2 As String
            'Dim section3 As String
            'Dim section4 As String
            'Dim section5 As String
            'Dim dbase As String
            'Dim bufr As DataSet
            'Dim Dat_Sec As String
            'Dim rs1 As DataSet
            'Dim kount As Integer
            'Dim dy As String
            'Dim hr As String

            'dy = dd
            'hr = hh

            'Process_Status("Composing the BUFR message")

            'rs1 = GetDataSet("ccitt", "SELECT * FROM ccitt")

            '' Encode Section 1 - Identification Section
            'section1 = ""
            'octets = "00000000"
            '' Octet 1 through 3. Length of section 1 - . There are 24 octets as per version 12 onwards
            'section1 = Decimal_Binary(24, 24)
            '' Octet 4. BURF Master table. It is Zero for Meteorology maintained by WMO
            'section1 = section1 & Decimal_Binary(0, 8)
            '' Octet 5 - 6. Identification of originating centre / generating center (defined in common table C-11)
            'section1 = section1 & Decimal_Binary(Val(txtOriginatingCentre.Text), 16)
            '' Octet 7 and 8. Identification of originating centre / generating sub_center (defined in common table C-12)
            'section1 = section1 & Decimal_Binary(Val(txtOriginatingSubcentre.Text), 16)
            '' Octet 9. Update sequence number (Zero for original BUFR message; incremented for updates)
            'section1 = section1 & Decimal_Binary(Val(txtUpdateSequence.Text), 8)
            '' Octet 10. Status for optional section. Bit 1=0 No option section; =1 Option section. Bit 2-8 set to zero (reserved)
            'If chkOptionalSection.Checked = True Then
            '    section1 = section1 & "10000000"
            'Else
            '    section1 = section1 & "00000000"
            'End If

            '' Octet 11. Data category
            'section1 = section1 & Decimal_Binary(Val(txtDataCategory.Text), 8)
            '' Octet 12. International data sub-category (defined in table C-13)
            'section1 = section1 & Decimal_Binary(Val(txtInternationalSubcategory.Text), 8)
            '' Octet 13. Local data sub-category (defined locally by ADP centers)
            'section1 = section1 & Decimal_Binary(Val(txtLocalSubcategory.Text), 8)
            '' Octet 14. Version number of master table currently (Currently 12 for WMO BUFR FM 94 BUFR tables)
            'section1 = section1 & Decimal_Binary(Val(txtMastertableVersion.Text), 8)
            '' Octet 15. Version number of local tables used to augment master table in use
            'section1 = section1 & Decimal_Binary(Val(txtLocaltableVersion.Text), 8)
            '' Octet 16 - 17. Year (4 digits)

            'section1 = section1 & Decimal_Binary(yy, 16)

            '' Octet 18. Month
            'section1 = section1 & Decimal_Binary(mm, 8)
            '' Octet 19. Day
            'section1 = section1 & Decimal_Binary(dd, 8)
            '' Octet 20. Hour
            'section1 = section1 & Decimal_Binary(hh, 8)
            '' Octet 21. Minute
            'section1 = section1 & Decimal_Binary(min, 8)
            '' Octet 22. Second
            'section1 = section1 & Decimal_Binary(ss, 8)
            '' Octet 23. Reserved for local use by ADP Centre
            'section1 = section1 & Decimal_Binary(0, 8)
            '' Octet 24. Set to zero
            'section1 = section1 & Decimal_Binary(0, 8)

            '' Compute Section 2 - Optional section if it exist
            'section2 = ""
            '' Octet 1 - 3. Length of section
            '' Octet 4 Set to Zero (Reserved)
            '' Octet 5 onwards. Reserved for use by ADP centres

            '' Compute Section 3 - Data Description Section.
            'Dim data_descriptors As String
            'Dim Octtets As Integer

            'section3 = ""

            'data_descriptors = Desc_Bits
            'Octtets = 7 + Len(data_descriptors) / 8

            'If Octtets Mod 2 <> 0 Then Octtets = Octtets + 1

            '' Octet 1 - 3. Length of section. Total of 9 Octets. 1 Octet to be added to make them even
            '' section3 = section3 & Decimal_Binary(10, 24)

            'section3 = section3 & Decimal_Binary(Octtets, 24)

            '' Octet 4. Reserved (Set to Zero)
            'section3 = section3 & Decimal_Binary(0, 8)
            '' Octet 5 - 6. Number of Subsets
            '' section3 = section3 & Decimal_Binary(Val(subsets), 16)
            'section3 = section3 & Decimal_Binary(Val(Bufr_Subst), 16)
            '' Octet 7. Type of data. Bit 1, = 1 observed = 0 Other. Bit 2 = 1 Compressed, = 0 non-compressed. Bit 3-8 reserved (set to zero)
            'octets = "00000000"
            'Mid(octets, 1) = 1
            'Mid(octets, 2) = 0
            'section3 = section3 & octets
            '' Octet 8 onwards
            'section3 = section3 & data_descriptors
            '' Octet 10. An extra octet to make total octets even

            'If Len(section3) / 8 Mod 2 <> 0 Then section3 = section3 & "00000000"

            ''Compute Section 4 - Data Section
            'Dim xtrbits As Integer
            'Dim siz As Integer

            'section4 = ""

            '' Compute the extra bits required to have complete octets

            'xtrbits = Len(binary_data) Mod 8

            'If xtrbits = 0 Then
            '    siz = (Len(binary_data) - xtrbits) / 8
            'Else
            '    For kount = 1 To 8 - xtrbits
            '        binary_data = binary_data & "0"
            '    Next kount
            '    siz = Len(binary_data) / 8
            'End If

            '' Complete the data section with even number of octets
            'If siz Mod 2 <> 0 Then
            '    siz = siz + 1
            '    binary_data = binary_data & "00000000"
            'End If

            '' Octet 1-3. Lenth of section - Octet 1, 2, 3, 4(reserved) and binary data stream
            'section4 = section4 & Decimal_Binary(4 + siz, 24)
            '' Octet 4. Reserved (set to zero)
            'section4 = section4 & "00000000"
            '' Octet 5 onwards
            'section4 = section4 & binary_data

            '' Compute section 5 - End Section
            'section5 = ""
            '' Octet 1-4 "7777" (coded according to CCITT International Alphabet No. 5)
            ''section5 = section5 & CCITT_Binary(rs1, "7777", 32)
            'section5 = section5 & CCITT_Binary("7777", 32)

            '' Compute the BUFR message less section 0
            'Dim BUFR_Message As String
            'BUFR_Message = section1 & section2 & section3 & section4 & section5

            '' Encode Section 0 - Indicator Section
            'section0 = ""
            '' Octet 1 - 4.  "BUFR" (coded according to CCITT International Alphabet No. 5)
            ''section0 = section0 & CCITT_Binary(rs1, "BUFR", 32)
            'section0 = section0 & CCITT_Binary("BUFR", 32)

            ''Log_Errors("BUFR = " & section0)
            '' Octet 5-7 Total length of BUFR message, in octets (including Section 0). Section 0 has 8 octets
            'siz = (Len(BUFR_Message) + 64) / 8
            'section0 = section0 & Decimal_Binary(siz, 24)
            '' Octet 8 - Bufr edition number
            'section0 = section0 & Decimal_Binary(Val(txtBufrEdition.Text), 8)

            '' Define communications controls for BUFR message in FTP GTS structure

            'Dim nnn As String
            'Dim SOH As String
            'Dim CR As String
            'Dim LF As String
            'Dim SP As String
            'Dim ETX As String
            'Dim Format_Id0 As String
            'Dim Format_Id1 As String
            'Dim dummy_msg As String
            'Dim nulls As String
            'Dim brfile As String

            ''nnn = CCITT_Binary(rs1, "001", 24)
            'nnn = CCITT_Binary("001", 24)

            'SOH = "00000001" ' Start Of Header
            'CR = "00001101" ' Carriage Return
            'LF = "00001010" ' Line Feed
            'SP = "00100000" ' SPace
            'ETX = "00000011" ' End of TeXt
            'Format_Id0 = "0011000000110000"
            'Format_Id1 = "0011000000110001"
            'dummy_msg = "0011000000110000001100000011000000110000001100000011000000110000"
            'nulls = "00000000"

            '' Compute message communication header in CCITT A5
            'Dim comms_header As String
            'Dim message_length As String
            'Dim Bufr_Message_With_Controls As String

            ''comms_header = CCITT_Binary(rs1, message_header, Len(message_header) * 8)
            'comms_header = CCITT_Binary(message_header, Len(message_header) * 8)

            ''Case where Format Identifier 00 is used
            'BUFR_Message = section0 & section1 & section2 & section3 & section4 & section5
            'Bufr_Message_With_Controls = SOH & CR & CR & LF & nnn & CR & CR & LF & comms_header & CR & CR & LF & BUFR_Message & CR & CR & LF & ETX

            'message_length = Format(Str(Len(Bufr_Message_With_Controls) / 8), "00000000")

            ''mm = String.Format("{0:00}", DateAndTime.Month(Now()))
            'message_length = String.Format("{0:00000000}", Strings.Len(Bufr_Message_With_Controls) / 8)
            ''msgbox("New " & message_length)
            ''BUFR_Message = CCITT_Binary(rs1, message_length, 64) & Format_Id0 & Bufr_Message_With_Controls & dummy_msg
            'BUFR_Message = CCITT_Binary(message_length, 64) & Format_Id0 & Bufr_Message_With_Controls & dummy_msg

            ''Delete the file to get rid of the previous data
            'brfile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr.txt"

            'If IO.File.Exists(brfile) Then IO.File.Delete(brfile)

            'FileOpen(2, brfile, OpenMode.Output)

            ''Print #2, BUFR_Message 
            'PrintLine(2, BUFR_Message) ' Put the BUFR binary digit message into a text file
            'FileClose(2)
            'FileClose(1)

            'msg_file = Strings.Right(msg_header, 4) & dy & hr & min ' Format(dy, "00") & Format(hr, "00")

            'msg_file = Strings.Right(msg_header, 4) & dy.PadLeft(2, "0"c) & hr.PadLeft(2, "0"c) & min.PadLeft(2, "0"c)
            'If WSId Then msg_file = msg_file & "_WSI"
            ''Construct and open Bufr output text file based on the message header

            'Dim fserial As Long
            'Dim AWS_BUFR_File, BUFR_octet_File As String
            'Dim ValidFile As Boolean
            'fserial = 0
            'ValidFile = False

            'AWS_BUFR_File = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & msg_file & ".tmp"

            'BUFR_octet_File = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr_octets.txt"

            'FileOpen(1, BUFR_octet_File, OpenMode.Output)

            'If IO.File.Exists(AWS_BUFR_File) Then IO.File.Delete(AWS_BUFR_File)

            ''Open AWS_BUFR_File For Binary As #2
            'FileOpen(2, AWS_BUFR_File, OpenMode.Binary)

            ''Output BUFR data into binary and text file
            'Dim byt As Long
            'Dim kounter As Long

            'byt = 0
            'kounter = 1

            'For i = 1 To Len(BUFR_Message) Step 8
            '    If Binary_Decimal(Strings.Mid(BUFR_Message, i, 8), byt) Then
            '        FilePut(2, byt, kounter)
            '    Else
            '        MsgBox("Coding Error")
            '    End If

            '    PrintLine(1, kounter & "," & Strings.Mid(BUFR_Message, i, 8))

            '    kounter = kounter + 1

            'Next

            'FileClose(1)
            'FileClose(2)

            'FileClose(1)

            ''' Message transmission
            ''Dim bufr_filename As String
            ''Process_Status("Transmitting message")

            ''bufr_filename = (System.IO.Path.GetFileName(AWS_BUFR_File)) ' Get the filename without path

            ''If Not FTP_Put(bufr_filename) Then Exit Function

            ''AWS_BUFR_Code = True

        Catch ex As Exception
            If ex.Message = "" Then
                MsgBox("BUFR Coding Error")
            Else
                MsgBox(ex.HResult & ": " & ex.Message & " at AWS_BUFR_Code")
            End If
            FileClose(1)
            FileClose(2)
        End Try
    End Function
End Class
