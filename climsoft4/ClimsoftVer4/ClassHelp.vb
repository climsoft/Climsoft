Public Class ClassHelp
    ' Module modHelp
   
    '--- The HTMLHelp function starts HTML Help and passes additional data
    '--- If the function succeeds, the return value is nonzero.
    '--- If the function fails, the return value is zero.

    Public Const HH_DISPLAY_TOPIC As Short = &H0    ' select last opened tab, [display a specified topic]
    Public Const HH_DISPLAY_TOC As Short = &H1      ' select contents tab, [display a specified topic]
    Public Const HH_DISPLAY_INDEX As Short = &H2    ' select index tab and searches for a keyword
    Public Const HH_DISPLAY_SEARCH As Short = &H3   ' select search tab and perform a search

    Public Const HH_HELP_CONTEXT As Short = &HF     ' display mapped numeric value in dwData

    '--- The parameters of the API call MUST be an Integer type
    '--- old VB6 definition of the parameters was 'As Long'
    '*** hWnd is the handle of the window requesting help
    '****lpHelpFile is a string containing path, name of the helpfile
    '               [optional]: file of the specific topic
    '               [optional]: name of a secondary window
    '*** uCommand specifies the type of help requested
    '               see some Help Command Constants above
    '*** dwData specifies additional data. The value used despends on the value of uCommand
    '               VB6 declaration is 'As Any' or 'As Long' !!!

    '  ********** Changes  **********
    ' (VB.net):  Integer => IntPtr
    ' (VB.net):  Long => Int32
    ' (VB.net):  Long => Int32

    Public Declare Function HTMLHelp_BaseCall Lib "hhctrl.ocx" Alias "HtmlHelpA" _
    (ByVal hWnd As IntPtr, ByVal lpHelpFile As String, ByVal uCommand As Int32, ByVal dwData As Int32) As Int32

End Class
