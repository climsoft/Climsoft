
Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class ClsTranslations

    '''--------------------------------------------------------------------------------------------
    ''' <summary>
    '''     Attempts to translate all the text in <paramref name="clsForm"/> to the currently
    '''     configured language.
    ''' </summary>
    '''
    ''' <param name="clsForm">    The WinForm control to translate. </param>
    '''--------------------------------------------------------------------------------------------
    Public Shared Sub TranslateForm(clsForm As Form)
        'UpdateTranslationsDB()
        HandleError(TranslateWinForm.clsTranslateWinForm.TranslateForm(clsForm, GetDbPath(), GetLanguageCode()))
    End Sub

    '''--------------------------------------------------------------------------------------------
    ''' <summary>   
    '''     Returns <paramref name="strText"/> translated into the current language (e.g. French). 
    ''' </summary>
    '''
    ''' <param name="strText">  The text to translate. </param>
    '''
    ''' <returns>   <paramref name="strText"/> translated into the current language (e.g. French). 
    '''             </returns>
    '''--------------------------------------------------------------------------------------------
    Public Shared Function GetTranslation(strText As String) As String
        If String.IsNullOrEmpty(strText) Then
            Return ""
        End If

        Return TranslateWinForm.clsTranslateWinForm.GetTranslation(strText, GetDbPath(), GetLanguageCode())
    End Function


    '''--------------------------------------------------------------------------------------------
    ''' <summary>   
    '''    Displays an error message box that displays <paramref name="strErrorMsg"/>.
    '''    If <paramref name="strErrorMsg"/> is empty then does nothing.
    ''' </summary>
    '''
    ''' <param name="strErrorMsg">  The error message to display. </param>
    '''--------------------------------------------------------------------------------------------
    Private Shared Sub HandleError(strErrorMsg As String)
        If Not String.IsNullOrEmpty(strErrorMsg) Then
            MsgBox(strErrorMsg, MsgBoxStyle.Exclamation)
        End If
    End Sub

    '''--------------------------------------------------------------------------------------------
    ''' <summary>   Returns the language code for the currently configured language (e.g. 'en' for 
    '''             English, 'fr' for French etc.). </summary>
    '''
    ''' <returns>   The language code for the currently configured language (e.g. 'en' for
    '''             English, 'fr' for French etc.). </returns>
    '''--------------------------------------------------------------------------------------------
    Private Shared Function GetLanguageCode() As String
        'If IsNothing(frmMain) OrElse IsNothing(frmMain.clsInstatOptions) OrElse
        '        IsNothing(frmMain.clsInstatOptions.strLanguageCultureCode) Then
        '    Return "en"
        'End If
        'Dim arrLanguageCodes As String() = frmMain.clsInstatOptions.strLanguageCultureCode.Split(New Char() {"-"c})
        'Return arrLanguageCodes(0)

        'todo. this should come from a configuration file.
        Return "fr"
    End Function

    '''--------------------------------------------------------------------------------------------
    ''' <summary>   Returns the full path of the SQLite translations database file. </summary>
    '''
    ''' <returns>   The full path of the SQLite translations database file. </returns>
    '''--------------------------------------------------------------------------------------------
    Private Shared Function GetDbPath() As String
        'todo. this path could be set from the global data 
        Dim strDbPath As String
        strDbPath = Path.Combine(Application.StartupPath, "translations", "climsofttranslations.db")
        Return strDbPath
    End Function

    Private Shared Sub UpdateTranslationsDB()

        'update the forms_controls tables
        Dim datatableControls As DataTable = GetFormControlsDataTable()
        If SaveFormControlsTableToDB(datatableControls) = datatableControls.Rows.Count Then
            MsgBox("The form controls have been saved to the form_controls table. The application will now exit.", MsgBoxStyle.Exclamation)
        Else
            MsgBox("Developer Error: Could NOT save all form controls to the form_controls table. The application will now exit.", MsgBoxStyle.Critical)
        End If

        'update the translations table
        Dim datatableTranslations As DataTable = GetTranslationTextsTableFromControlsTable(datatableControls)
        If SaveTranslationsTableToDB(datatableTranslations) = datatableTranslations.Rows.Count Then
            MsgBox("The id texts have been saved to the translations table. The application will now exit.", MsgBoxStyle.Exclamation)
        Else
            MsgBox("Developer Error: Could NOT save all form id texts to the translations table. The application will now exit.", MsgBoxStyle.Critical)
        End If

        'This sub should only be used by developers to create the translation export files.
        'Therefore, exit the application with a message to ensure that this sub is not run 
        'accidentally in the release version. 
        Application.Exit()
    End Sub


    'some parts could be pushed to the translations library
    ''' <summary>
    ''' returns a datatable with all form controls texts to be translated
    ''' </summary>
    ''' <returns></returns>
    Private Shared Function GetFormControlsDataTable() As DataTable

        'Get list of all form classes in the application 
        '    (specifically, a list of 'Type' objects, each 'Type' object contains details about 
        '    a class)
        Dim clsAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim lstFormClasses As List(Of Type) = clsAssembly.GetTypes().Where(Function(t) t.BaseType = GetType(Form)).ToList()
        Dim datatableControls As New DataTable
        ' Create 3 columns in the DataTable.
        datatableControls.Columns.Add("form_name", GetType(String))
        datatableControls.Columns.Add("control_name", GetType(String))
        datatableControls.Columns.Add("id_text", GetType(String))

        For Each typFormClass As Type In lstFormClasses
            'Note: We know the name of each form class (see list above). We also know that 
            '      the 'My.Forms' object contains an object for each form class.
            '      Conveniently, the name of each object in 'My.Forms' is the same as the name of 
            '      the object's class. 
            '      Therefore we can use the class name as the object name in 'CallByName'.
            Dim frmTemp As Form = CallByName(My.Forms, typFormClass.Name, CallType.Get)
            FillControlsToTable(frmTemp, datatableControls)
        Next
        Return datatableControls
    End Function

    Private Shared Sub FillControlsToTable(clsControl As Control, table As DataTable)

        Dim dctComponents As Dictionary(Of String, Component) = New Dictionary(Of String, Component)
        GetDctComponentsFromControl(clsControl, dctComponents)

        For Each clsComponent In dctComponents
            Dim idText As String

            If TypeOf clsComponent.Value Is Control Then
                idText = GetActualTranslationText(DirectCast(clsComponent.Value, Control).Text)
            ElseIf TypeOf clsComponent.Value Is ToolStripItem Then
                idText = GetActualTranslationText(DirectCast(clsComponent.Value, ToolStripItem).Text)
            Else
                MsgBox("Developer Error: Translation dictionary entry (" & clsControl.Name & "," & clsComponent.Key & ") contained unexpected value type.")
                Exit For
            End If
            'form_name, control_name, id_text
            table.Rows.Add(clsControl.Name, clsComponent.Key, idText)
        Next

        'Special case for radio buttons in panels: 
        '  Before the dialog is shown, each radio button is a direct child of the dialog 
        '  (e.g. 'dlg_Augment_rdoNewDataframe'). After the dialog is shown, the raio button becomes 
        '  a direct child of its parent panel.
        '  Therefore, we need to show the dialog before we traverse the dialog's control hierarchy.
        '  Unfortunately showing the dialog means that it has to be manually closed. So we only 
        '  show the dialog for this special case to save the developer from having to manually 
        '  close too many dialogs.
        '  TODO: launch each dialog in a new thread to avoid need for manual close?
        'If strTemp.ToLower().Contains("pnl") AndAlso strTemp.ToLower().Contains("rdo") Then
        '    'frmTemp.ShowDialog()
        '    frmTemp.Show()
        '    strTemp = GetControls(frmTemp)
        '    frmTemp.Close()
        'End If


    End Sub

    'todo. can probably be improved futher to include "DoNotTranslate". Should be pushed to the translations library
    Private Shared Function GetActualTranslationText(strText As String) As String
        If String.IsNullOrEmpty(strText) OrElse
            strText.Contains(vbCr) OrElse    'multiline text
            strText.Contains(vbLf) OrElse Not Regex.IsMatch(strText, "[a-zA-Z]") Then
            'Regex.IsMatch(strText, "CheckBox\d+$") OrElse 'CheckBox1, CheckBox2 etc. normally indicates dynamic translation
            'Regex.IsMatch(strText, "Label\d+$") OrElse 'Label1, Label2 etc. normally indicates dynamic translation

            'text that doesn't contain any letters (e.g. number strings)
            Return "ReplaceWithDynamicTranslation"
        End If
        Return strText
    End Function


    'todo.  Should be pushed to the translate library
    ''' <summary>
    ''' gets the translation texts from the datatable that has the forms controls texts
    ''' </summary>
    ''' <param name="datatableControls"></param>
    ''' <param name="langCode"></param>
    ''' <returns></returns>
    Private Shared Function GetTranslationTextsTableFromControlsTable(datatableControls As DataTable, Optional langCode As String = "en") As DataTable
        'Fill translations table from the form controls table
        Dim datatableTranslations As New DataTable
        ' Create 3 columns in the DataTable.
        datatableTranslations.Columns.Add("id_text", GetType(String))
        datatableTranslations.Columns.Add("language_code", GetType(String))
        datatableTranslations.Columns.Add("translation", GetType(String))
        For Each row As DataRow In datatableControls.Rows
            'ignore "ReplaceWithDynamicTranslation" id text
            If row.Field(Of String)(2) = "ReplaceWithDynamicTranslation" Then
                Continue For
            End If
            'add id_text, language_code, translation
            datatableTranslations.Rows.Add(row.Field(Of String)(2), langCode, row.Field(Of String)(2))
            'todo. remove line below. Dummy french translation
            'datatableTranslations.Rows.Add(row.Field(Of String)(2), "fr", "fr_" & row.Field(Of String)(2))
        Next
        Return datatableTranslations
    End Function

    'todo. pending implementation. Should be pushed to translations library
    Private Shared Function GetTranslationTextsTableFromCrowdInJSONFile(strFilePath) As DataTable
        'Fill translations table from the form controls table
        Dim datatableTranslations As New DataTable

        'todo add implementation
        Return datatableTranslations
    End Function


    'todo.  Should be pushed to the translate library
    ''' <summary>
    ''' saves the datatable that has 3 columns; form_name, control_name,id_text .
    ''' to the form_controls table
    ''' </summary>
    ''' <param name="datatableControls"></param>
    ''' <returns>Number of successful inserts</returns>
    Private Shared Function SaveFormControlsTableToDB(datatableControls As DataTable) As Integer
        Dim iRowsUpdated As Integer = 0
        Try
            'connect to the database and execute the SQL command
            Dim strDbPath As String
            'strDbPath = GetDbPath() 'don't use this because we don't want the db in the 'debug' folder
            strDbPath = Directory.GetParent(Application.StartupPath).FullName
            strDbPath = Directory.GetParent(strDbPath).FullName
            strDbPath = Path.Combine(strDbPath, "translations", "climsofttranslations.db")
            Dim clsBuilder As New SQLiteConnectionStringBuilder With {
                    .FailIfMissing = True,
                    .DataSource = strDbPath}
            Using clsConnection As New SQLiteConnection(clsBuilder.ConnectionString)
                clsConnection.Open()
                'todo. do batch execution for optimal performance
                For Each row As DataRow In datatableControls.Rows

                    Dim paramFormName As New SQLiteParameter("form_name", row.Field(Of String)(0))
                    Dim paramControlName As New SQLiteParameter("control_name", row.Field(Of String)(1))
                    Dim paramIdText As New SQLiteParameter("id_text", row.Field(Of String)(2))

                    'delete record if exists first 
                    Dim sqlDeleteCommand As String = "DELETE FROM form_controls WHERE form_name = @form_name AND control_name=@control_name"
                    Using cmdDelete As New SQLiteCommand(sqlDeleteCommand, clsConnection)
                        cmdDelete.Parameters.Add(paramFormName)
                        cmdDelete.Parameters.Add(paramControlName)
                        cmdDelete.ExecuteNonQuery()
                    End Using

                    'insert the new record
                    Dim sqlInsertCommand As String = "INSERT INTO form_controls (form_name,control_name,id_text) VALUES (@form_name,@control_name,@id_text)"
                    Using cmdInsert As New SQLiteCommand(sqlInsertCommand, clsConnection)
                        cmdInsert.Parameters.Add(paramFormName)
                        cmdInsert.Parameters.Add(paramControlName)
                        cmdInsert.Parameters.Add(paramIdText)
                        iRowsUpdated += cmdInsert.ExecuteNonQuery()
                    End Using
                Next

                clsConnection.Close()
            End Using

            'called to update the controls that should not be updated
            SetTranslateIgnore()
        Catch e As Exception
            MsgBox(e.Message)
        End Try

        Return iRowsUpdated
    End Function

    'todo.  Should be pushed to the translate library
    ''' <summary>
    ''' saves the datatable that has 3 columns; id_text, language_code,translation.
    ''' to the translations table
    ''' </summary>
    ''' <param name="datatableTranslations"></param>
    ''' <returns>Number of successful inserts</returns>
    Private Shared Function SaveTranslationsTableToDB(datatableTranslations As DataTable) As Integer
        Dim iRowsUpdated As Integer = 0
        Try
            'connect to the database and execute the SQL command
            Dim strDbPath As String
            'strDbPath = GetDbPath() 'don't use this because we don't want the db in the 'debug' folder
            strDbPath = Directory.GetParent(Application.StartupPath).FullName
            strDbPath = Directory.GetParent(strDbPath).FullName
            strDbPath = Path.Combine(strDbPath, "translations", "climsofttranslations.db")
            Dim clsBuilder As New SQLiteConnectionStringBuilder With {
                    .FailIfMissing = True,
                    .DataSource = strDbPath}
            Using clsConnection As New SQLiteConnection(clsBuilder.ConnectionString)
                clsConnection.Open()

                'todo. do batch execution for optimal performance
                For Each row As DataRow In datatableTranslations.Rows

                    Dim paramIdText As New SQLiteParameter("id_text", row.Field(Of String)(0))
                    Dim paramLangcode As New SQLiteParameter("language_code", row.Field(Of String)(1))
                    Dim paramTranslation As New SQLiteParameter("translation", row.Field(Of String)(2))

                    'delete record if exists first 
                    Dim sqlDeleteCommand As String = "DELETE FROM translations WHERE id_text = @id_text AND language_code=@language_code"
                    Using cmdDelete As New SQLiteCommand(sqlDeleteCommand, clsConnection)
                        cmdDelete.Parameters.Add(paramIdText)
                        cmdDelete.Parameters.Add(paramLangcode)
                        cmdDelete.ExecuteNonQuery()
                    End Using

                    'insert the new record
                    Dim sqlInsertCommand As String = "INSERT INTO translations (id_text,language_code,translation) VALUES (@id_text,@language_code,@translation)"
                    Using cmdInsert As New SQLiteCommand(sqlInsertCommand, clsConnection)
                        cmdInsert.Parameters.Add(paramIdText)
                        cmdInsert.Parameters.Add(paramLangcode)
                        cmdInsert.Parameters.Add(paramTranslation)
                        iRowsUpdated += cmdInsert.ExecuteNonQuery()
                    End Using
                Next

                clsConnection.Close()
            End Using
        Catch e As Exception
            MsgBox(e.Message)
        End Try

        Return iRowsUpdated
    End Function


    'todo. probably delete this later. Should be pushed to the translate library
    Private Shared Sub GetDctComponentsFromControl(clsControl As Control,
                                                   ByRef dctComponents As Dictionary(Of String, Component),
                                                   Optional strParentName As String = "")
        If IsNothing(clsControl) OrElse IsNothing(clsControl.Controls) OrElse IsNothing(dctComponents) Then
            Exit Sub
        End If

        'if control is valid, then add it to the dictionary
        Dim strControlName As String = ""
        If Not String.IsNullOrEmpty(clsControl.Name) Then
            strControlName = If(String.IsNullOrEmpty(strParentName), clsControl.Name, strParentName & "_" & clsControl.Name)
            If Not dctComponents.ContainsKey(strControlName) Then  'ignore components that are already in the dictionary
                dctComponents.Add(strControlName, clsControl)
            End If
        End If

        For Each ctlChild As Control In clsControl.Controls

            'Recursively process different types of menus and child controls
            If TypeOf ctlChild Is MenuStrip Then
                Dim clsMenuStrip As MenuStrip = DirectCast(ctlChild, MenuStrip)
                GetDctComponentsFromMenuItems(clsMenuStrip.Items, dctComponents)
            ElseIf TypeOf ctlChild Is ToolStrip Then
                Dim clsToolStrip As ToolStrip = DirectCast(ctlChild, ToolStrip)
                GetDctComponentsFromMenuItems(clsToolStrip.Items, dctComponents)
            ElseIf TypeOf ctlChild Is Control Then
                GetDctComponentsFromControl(ctlChild, dctComponents, strControlName)
            End If

        Next
    End Sub

    'todo. probably delete this later. Should be pushed to the translate library
    Private Shared Sub GetDctComponentsFromMenuItems(clsMenuItems As ToolStripItemCollection, ByRef dctComponents As Dictionary(Of String, Component))
        If IsNothing(clsMenuItems) OrElse IsNothing(dctComponents) Then
            Exit Sub
        End If

        For Each clsMenuItem As ToolStripItem In clsMenuItems

            'if menu item is valid, then add it to the dictionary
            If Not (String.IsNullOrEmpty(clsMenuItem.Name) OrElse
                    dctComponents.ContainsKey(clsMenuItem.Name)) Then 'ignore components that are already in the dictionary
                dctComponents.Add(clsMenuItem.Name, clsMenuItem)
            End If

            'Recursively process different types of sub-menu
            If TypeOf clsMenuItem Is ToolStripMenuItem Then
                Dim clsTmpMenuItem As ToolStripMenuItem = DirectCast(clsMenuItem, ToolStripMenuItem)
                If clsTmpMenuItem.HasDropDownItems Then
                    GetDctComponentsFromMenuItems(clsTmpMenuItem.DropDownItems, dctComponents)
                End If
            ElseIf TypeOf clsMenuItem Is ToolStripSplitButton Then
                Dim clsTmpMenuItem As ToolStripSplitButton = DirectCast(clsMenuItem, ToolStripSplitButton)
                If clsTmpMenuItem.HasDropDownItems Then
                    GetDctComponentsFromMenuItems(clsTmpMenuItem.DropDownItems, dctComponents)
                End If
            ElseIf TypeOf clsMenuItem Is ToolStripDropDownButton Then
                Dim clsTmpMenuItem As ToolStripDropDownButton = DirectCast(clsMenuItem, ToolStripDropDownButton)
                If clsTmpMenuItem.HasDropDownItems Then
                    GetDctComponentsFromMenuItems(clsTmpMenuItem.DropDownItems, dctComponents)
                End If
            End If

        Next
    End Sub


    'todo. the SetTranslateIgnore() can be improved

    '''--------------------------------------------------------------------------------------------
    ''' <summary>   
    '''    Updates the `TranslateWinForm` library database based on the specifications in the 
    '''    'translateIgnore.txt' file. This file provides a way to ignore specified WinForm 
    '''    controls when the application or dialog is translated into a different language.
    '''    <para>
    '''    For example, this file can be used to ensure that text that references pre-existing data 
    '''    or meta data (e.g. a file name, data frame name, column name, cell value etc.) stays the 
    '''    same, even when the rest of the dialog is translated into French or Portuguese.
    '''    </para><para>
    '''    This sub should be executed prior to each release to ensure that the `TranslateWinForm` 
    '''    database specifies all the controls to ignore during the translation.  </para>  
    ''' </summary>
    '''--------------------------------------------------------------------------------------------
    Private Shared Sub SetTranslateIgnore()
        Dim lstIgnore As New List(Of String)
        Dim lstIgnoreNegations As New List(Of String)

        'For each line in the ignore file
        Dim strPath As String
        strPath = Directory.GetParent(Application.StartupPath).FullName
        strPath = Directory.GetParent(strPath).FullName
        strPath = Path.Combine(strPath, "translations", "translate_ignore.txt")
        Using clsReader As New StreamReader(strPath)
            Do While clsReader.Peek() >= 0
                Dim strIgnoreFileLine = clsReader.ReadLine().Trim()
                If String.IsNullOrEmpty(strIgnoreFileLine) Then
                    Continue Do
                End If

                Select Case (strIgnoreFileLine(0))
                    Case "#"
                        'Ignore comment lines
                    Case "!"
                        'Add negation pattern to negation list
                        lstIgnoreNegations.Add(strIgnoreFileLine.Substring(1)) 'remove leading '!'
                    Case Else
                        'Add pattern to ignore list
                        lstIgnore.Add(strIgnoreFileLine)
                End Select
            Loop
        End Using

        'If the ignore file didn't contain any specifications, then exit
        If lstIgnore.Count <= 0 AndAlso lstIgnoreNegations.Count <= 0 Then
            MsgBox("The " & strPath & " ignore file was processed. No ignore specifications were found. " &
                   "The database was not updated. The application will now exit.", MsgBoxStyle.Exclamation)
            'Application.Exit()
        End If

        'create the SQL command to update the database
        Dim strSqlUpdate As String = "UPDATE form_controls SET id_text = 'DoNotTranslate' WHERE "

        If lstIgnore.Count > 0 Then
            strSqlUpdate &= "("
            For iListPos As Integer = 0 To lstIgnore.Count - 1
                strSqlUpdate &= If(iListPos > 0, " OR ", "")
                strSqlUpdate &= "control_name LIKE '" & lstIgnore.Item(iListPos) & "'"
            Next iListPos
            strSqlUpdate &= ")"
        End If

        If lstIgnoreNegations.Count > 0 Then
            strSqlUpdate &= If(lstIgnore.Count > 0, " AND ", "")
            strSqlUpdate &= "NOT ("
            For iListPos As Integer = 0 To lstIgnoreNegations.Count - 1
                strSqlUpdate &= If(iListPos > 0, " OR ", "")
                strSqlUpdate &= "control_name LIKE '" & lstIgnoreNegations.Item(iListPos) & "'"
            Next iListPos
            strSqlUpdate &= ")"
        End If

        'execute the SQL command
        Try
            'specify the path of the SQLite database that contains the translations (2 levels up from the execution folder)
            Dim strDbPath As String = Directory.GetParent(Application.StartupPath).FullName
            strDbPath = Directory.GetParent(strDbPath).FullName
            strDbPath = Path.Combine(strDbPath, "translations")
            strDbPath = Path.Combine(strDbPath, "climsofttranslations.db")

            'connect to the database and execute the SQL command
            Dim clsBuilder As New SQLiteConnectionStringBuilder With {
                    .FailIfMissing = True,
                    .DataSource = strDbPath}
            Using clsConnection As New SQLiteConnection(clsBuilder.ConnectionString)
                Using clsSqliteCmd As New SQLiteCommand(strSqlUpdate, clsConnection)
                    clsConnection.Open()
                    Dim iRowsUpdated As Integer = clsSqliteCmd.ExecuteNonQuery()
                    clsConnection.Close()
                    MsgBox("The " & strPath & " ignore file was processed. " &
                           iRowsUpdated & " database rows were updated. ", MsgBoxStyle.Exclamation)
                End Using
            End Using
        Catch e As Exception
            MsgBox(e.Message & Environment.NewLine & "An error occured processing ignore file: " &
                   strPath, MsgBoxStyle.Exclamation)
        End Try

        'This sub should only be used by developers to process the translation ignore file.
        'Therefore, exit the application with a message to ensure that this sub is not run 
        'accidentally in the release version. 
        'Application.Exit()
    End Sub


End Class
