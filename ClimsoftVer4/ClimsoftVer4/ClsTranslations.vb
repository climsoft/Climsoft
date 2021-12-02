
Imports System.Reflection

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
        Return "fr"
    End Function

    '''--------------------------------------------------------------------------------------------
    ''' <summary>   Returns the full path of the SQLite translations database file. </summary>
    '''
    ''' <returns>   The full path of the SQLite translations database file. </returns>
    '''--------------------------------------------------------------------------------------------
    Private Shared Function GetDbPath() As String
        'todo. this path could be set from the global data
        Dim strTranslationsPath As String = String.Concat(Application.StartupPath, "\translations")
        Dim strDbFile As String = "climsofttranslations.db"
        Dim strDbPath As String = IO.Path.Combine(strTranslationsPath, strDbFile)
        Return strDbPath
    End Function


    '''--------------------------------------------------------------------------------------------
    ''' <summary>   
    '''    Writes a CSV file that can be imported into the `TranslateWinForm` library database. 
    '''    This sub should be executed prior to each release to ensure that the `TranslateWinForm` 
    '''    database contains all the translatable text for the new release.
    '''    <para>
    '''    The CSV file contains the identifiers and associated text of each form, control and menu 
    '''    item in the application.     Please note that `ucrCheck` and `ucrInput` controls are 
    '''    specifically excluded. This is because the text for these controls is set dynamically 
    '''    at runtime.
    '''    </para><para>
    '''    This sub uses the `Reflection` package to automatically identify and traverse all the 
    '''    forms, menus and controls in the current release. This information can also be found by 
    '''    parsing the application source code files (e.g. the `resx` or `xlf` files). However, 
    '''    we considered the `Reflection` package to be a simpler and less error-prone solution.
    '''    </para>
    ''' </summary>
    '''--------------------------------------------------------------------------------------------
    Private Shared Sub WriteCsvFile()

        'Get list of all form classes in the application 
        '    (specifically, a list of 'Type' objects, each 'Type' object contains details about 
        '    a class)
        Dim clsAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim lstFormClasses As List(Of Type) = clsAssembly.GetTypes().Where(Function(t) t.BaseType = GetType(Form)).ToList()

        'Populate the csv string for each form in the project
        'Note: We know the name of each form class (see list above). We also know that 
        '      the 'My.Forms' object contains an object for each form class.
        '      Conveniently, the name of each object in 'My.Forms' is the same as the name of 
        '      the object's class. 
        '      Therefore we can use the class name as the object name in 'CallByName'.
        Dim strControlsAsCsv As String = ""
        For Each typFormClass As Type In lstFormClasses
            Dim frmTemp As Form = CallByName(My.Forms, typFormClass.Name, CallType.Get)
            Dim strTemp = TranslateWinForm.clsTranslateWinForm.GetControlsAsCsv(frmTemp)

            'Special case for radio buttons in panels: 
            '  Before the dialog is shown, each radio button is a direct child of the dialog 
            '  (e.g. 'dlg_Augment_rdoNewDataframe'). After the dialog is shown, the raio button becomes 
            '  a direct child of its parent panel.
            '  Therefore, we need to show the dialog before we traverse the dialog's control hierarchy.
            '  Unfortunately showing the dialog means that it has to be manually closed. So we only 
            '  show the dialog for this special case to save the developer from having to manually 
            '  close too many dialogs.
            '  TODO: launch each dialog in a new thread to avoid need for manual close?
            If strTemp.ToLower().Contains("pnl") AndAlso strTemp.ToLower().Contains("rdo") Then
                frmTemp.ShowDialog()
                strTemp = TranslateWinForm.clsTranslateWinForm.GetControlsAsCsv(frmTemp)
            End If

            strControlsAsCsv &= strTemp
        Next

        'The right mouse button menus for the 6 output windows are not accessible via 
        '    the control lists. Therefore, add these manually to the CSV file
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrOutput, frmMain.ucrOutput.UcrOutputPages.tsButtons.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrColumnMeta, frmMain.ucrColumnMeta.cellContextMenuStrip.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrColumnMeta, frmMain.ucrColumnMeta.columnContextMenuStrip.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrColumnMeta, frmMain.ucrColumnMeta.statusColumnMenu.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrDataFrameMeta, frmMain.ucrDataFrameMeta.cellContextMenuStrip.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrDataFrameMeta, frmMain.ucrDataFrameMeta.rowRightClickMenu.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrLogWindow, frmMain.ucrLogWindow.mnuContextLogFile.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrScriptWindow, frmMain.ucrScriptWindow.mnuContextScript.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrDataViewer, frmMain.ucrDataViewer.RowContextMenu.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrDataViewer, frmMain.ucrDataViewer.ColumnContextMenu.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrDataViewer, frmMain.ucrDataViewer.CellContextMenu.Items)
        'strControlsAsCsv &= TranslateWinForm.clsTranslateWinForm.GetMenuItemsAsCsv(frmMain.ucrDataViewer, frmMain.ucrDataViewer.SheetTabContextMenu.Items)

        'Write the csv file
        'Dim strDesktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        'Dim strFileName As String = "form_controls.csv"
        'Dim strPath As String = System.IO.Path.Combine(strDesktopPath, strFileName)



        Dim strDesktopPath As String = String.Concat(Application.StartupPath, "\translations")
        Dim strFileName As String = "form_controls.csv"
        Dim strPath As String = System.IO.Path.Combine(strDesktopPath, strFileName)


        Using sw As New System.IO.StreamWriter(strPath)
            Console.WriteLine(strControlsAsCsv)
            sw.WriteLine(strControlsAsCsv)
            sw.Flush()
            sw.Close()
        End Using

        'This sub should only be used by developers to create the translation export files.
        'Therefore, exit the application with a message to ensure that this sub is not run 
        'accidentally in the release version. 
        MsgBox("The form controls' translation text was written to: " & strPath &
               ". The application will now exit.", MsgBoxStyle.Exclamation)
        System.Windows.Forms.Application.Exit()
    End Sub




End Class
