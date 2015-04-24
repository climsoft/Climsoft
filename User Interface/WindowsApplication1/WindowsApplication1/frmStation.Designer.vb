<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStation
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
        Me.SuspendLayout()
        '
        'frmStation
        '
        Me.ClientSize = New System.Drawing.Size(379, 261)
        Me.Name = "frmStation"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Mysql_climsoft_db_v4StationDataSet As WindowsApplication1.mysql_climsoft_db_v4StationDataSet
    Friend WithEvents StationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StationTableAdapter As WindowsApplication1.mysql_climsoft_db_v4StationDataSetTableAdapters.stationTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.mysql_climsoft_db_v4StationDataSetTableAdapters.TableAdapterManager
    Friend WithEvents StationBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StationBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents StationIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StationNameTextBox As System.Windows.Forms.TextBox
End Class
