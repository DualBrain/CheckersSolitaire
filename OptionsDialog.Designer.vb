<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsDialog
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
    CancelActionButton = New Button()
    AcceptActionButton = New Button()
    Label2 = New Label()
    RowsComboBox = New ComboBox()
    Label1 = New Label()
    PiecesComboBox = New ComboBox()
    Label3 = New Label()
    ColumnsComboBox = New ComboBox()
    BoardGroupBox = New GroupBox()
    BoardGroupBox.SuspendLayout()
    SuspendLayout()
    ' 
    ' CancelActionButton
    ' 
    CancelActionButton.DialogResult = DialogResult.Cancel
    CancelActionButton.FlatStyle = FlatStyle.System
    CancelActionButton.Location = New Point(136, 168)
    CancelActionButton.Name = "CancelActionButton"
    CancelActionButton.Size = New Size(90, 29)
    CancelActionButton.TabIndex = 2
    CancelActionButton.Text = "&Cancel"
    ' 
    ' AcceptActionButton
    ' 
    AcceptActionButton.DialogResult = DialogResult.OK
    AcceptActionButton.FlatStyle = FlatStyle.System
    AcceptActionButton.Location = New Point(31, 168)
    AcceptActionButton.Name = "AcceptActionButton"
    AcceptActionButton.Size = New Size(90, 29)
    AcceptActionButton.TabIndex = 1
    AcceptActionButton.Text = "&OK"
    ' 
    ' Label2
    ' 
    Label2.FlatStyle = FlatStyle.System
    Label2.Location = New Point(10, 69)
    Label2.Name = "Label2"
    Label2.Size = New Size(134, 28)
    Label2.TabIndex = 2
    Label2.Text = "Number of columns:"
    Label2.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' RowsComboBox
    ' 
    RowsComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    RowsComboBox.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "20", "22", "24", "26", "28", "30"})
    RowsComboBox.Location = New Point(144, 30)
    RowsComboBox.Name = "RowsComboBox"
    RowsComboBox.Size = New Size(67, 23)
    RowsComboBox.TabIndex = 1
    ' 
    ' Label1
    ' 
    Label1.FlatStyle = FlatStyle.System
    Label1.Location = New Point(10, 30)
    Label1.Name = "Label1"
    Label1.Size = New Size(120, 28)
    Label1.TabIndex = 0
    Label1.Text = "Number of rows:"
    Label1.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' PiecesComboBox
    ' 
    PiecesComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    PiecesComboBox.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10"})
    PiecesComboBox.Location = New Point(144, 108)
    PiecesComboBox.Name = "PiecesComboBox"
    PiecesComboBox.Size = New Size(67, 23)
    PiecesComboBox.TabIndex = 5
    ' 
    ' Label3
    ' 
    Label3.FlatStyle = FlatStyle.System
    Label3.Location = New Point(10, 108)
    Label3.Name = "Label3"
    Label3.Size = New Size(134, 29)
    Label3.TabIndex = 4
    Label3.Text = "Piece depth:"
    Label3.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' ColumnsComboBox
    ' 
    ColumnsComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    ColumnsComboBox.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "20", "22", "24", "26", "28", "30"})
    ColumnsComboBox.Location = New Point(144, 69)
    ColumnsComboBox.Name = "ColumnsComboBox"
    ColumnsComboBox.Size = New Size(67, 23)
    ColumnsComboBox.TabIndex = 3
    ' 
    ' BoardGroupBox
    ' 
    BoardGroupBox.Controls.Add(Label2)
    BoardGroupBox.Controls.Add(RowsComboBox)
    BoardGroupBox.Controls.Add(Label1)
    BoardGroupBox.Controls.Add(PiecesComboBox)
    BoardGroupBox.Controls.Add(Label3)
    BoardGroupBox.Controls.Add(ColumnsComboBox)
    BoardGroupBox.FlatStyle = FlatStyle.System
    BoardGroupBox.Location = New Point(12, 11)
    BoardGroupBox.Name = "BoardGroupBox"
    BoardGroupBox.Size = New Size(230, 148)
    BoardGroupBox.TabIndex = 0
    BoardGroupBox.TabStop = False
    BoardGroupBox.Text = "Board Settings"
    ' 
    ' OptionsDialog
    ' 
    AcceptButton = AcceptActionButton
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    CancelButton = CancelActionButton
    ClientSize = New Size(255, 208)
    Controls.Add(CancelActionButton)
    Controls.Add(AcceptActionButton)
    Controls.Add(BoardGroupBox)
    FormBorderStyle = FormBorderStyle.FixedDialog
    MaximizeBox = False
    MinimizeBox = False
    Name = "OptionsDialog"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    Text = "Options"
    BoardGroupBox.ResumeLayout(False)
    ResumeLayout(False)
  End Sub

  Private WithEvents CancelActionButton As Button
  Private WithEvents AcceptActionButton As Button
  Private WithEvents Label2 As Label
  Private WithEvents RowsComboBox As ComboBox
  Private WithEvents Label1 As Label
  Private WithEvents PiecesComboBox As ComboBox
  Private WithEvents Label3 As Label
  Private WithEvents ColumnsComboBox As ComboBox
  Private WithEvents BoardGroupBox As GroupBox
End Class
