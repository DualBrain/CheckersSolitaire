<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistoryDialog
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoryDialog))
    HistoryListView = New ListView()
    ColumnHeader1 = New ColumnHeader()
    ColumnHeader2 = New ColumnHeader()
    ColumnHeader3 = New ColumnHeader()
    ColumnHeader4 = New ColumnHeader()
    ColumnHeader5 = New ColumnHeader()
    ColumnHeader6 = New ColumnHeader()
    CloseActionButton = New Button()
    SuspendLayout()
    ' 
    ' HistoryListView
    ' 
    HistoryListView.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    HistoryListView.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4, ColumnHeader5, ColumnHeader6})
    HistoryListView.FullRowSelect = True
    HistoryListView.Location = New Point(10, 12)
    HistoryListView.Name = "HistoryListView"
    HistoryListView.Size = New Size(268, 205)
    HistoryListView.TabIndex = 0
    HistoryListView.UseCompatibleStateImageBehavior = False
    HistoryListView.View = View.Details
    ' 
    ' ColumnHeader1
    ' 
    ColumnHeader1.Text = "#"
    ColumnHeader1.Width = 39
    ' 
    ' ColumnHeader2
    ' 
    ColumnHeader2.Text = "Row"
    ColumnHeader2.Width = 43
    ' 
    ' ColumnHeader3
    ' 
    ColumnHeader3.Text = "Col"
    ColumnHeader3.Width = 38
    ' 
    ' ColumnHeader4
    ' 
    ColumnHeader4.Text = ""
    ColumnHeader4.TextAlign = HorizontalAlignment.Center
    ColumnHeader4.Width = 55
    ' 
    ' ColumnHeader5
    ' 
    ColumnHeader5.Text = "Row"
    ColumnHeader5.Width = 41
    ' 
    ' ColumnHeader6
    ' 
    ColumnHeader6.Text = "Col"
    ColumnHeader6.Width = 35
    ' 
    ' CloseActionButton
    ' 
    CloseActionButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
    CloseActionButton.DialogResult = DialogResult.OK
    CloseActionButton.FlatStyle = FlatStyle.System
    CloseActionButton.Location = New Point(192, 227)
    CloseActionButton.Name = "CloseActionButton"
    CloseActionButton.Size = New Size(90, 28)
    CloseActionButton.TabIndex = 1
    CloseActionButton.Text = "&Close"
    ' 
    ' HistoryDialog
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(292, 266)
    Controls.Add(HistoryListView)
    Controls.Add(CloseActionButton)
    Icon = CType(resources.GetObject("$this.Icon"), Icon)
    MaximizeBox = False
    MinimizeBox = False
    Name = "HistoryDialog"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    Text = "History"
    ResumeLayout(False)
  End Sub

  Friend WithEvents HistoryListView As ListView
  Private WithEvents ColumnHeader1 As ColumnHeader
  Private WithEvents ColumnHeader2 As ColumnHeader
  Private WithEvents ColumnHeader3 As ColumnHeader
  Private WithEvents ColumnHeader4 As ColumnHeader
  Private WithEvents ColumnHeader5 As ColumnHeader
  Private WithEvents ColumnHeader6 As ColumnHeader
  Private WithEvents CloseActionButton As Button
End Class
