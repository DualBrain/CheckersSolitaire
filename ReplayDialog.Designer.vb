<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReplayDialog
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
    Label2 = New Label()
    DelayTextBox = New TextBox()
    Label1 = New Label()
    AcceptActionButton = New Button()
    SuspendLayout()
    ' 
    ' CancelActionButton
    ' 
    CancelActionButton.DialogResult = DialogResult.Cancel
    CancelActionButton.FlatStyle = FlatStyle.System
    CancelActionButton.Location = New Point(181, 54)
    CancelActionButton.Name = "CancelActionButton"
    CancelActionButton.Size = New Size(90, 28)
    CancelActionButton.TabIndex = 5
    CancelActionButton.Text = "&Cancel"
    ' 
    ' Label2
    ' 
    Label2.FlatStyle = FlatStyle.System
    Label2.Location = New Point(105, 15)
    Label2.Name = "Label2"
    Label2.Size = New Size(172, 28)
    Label2.TabIndex = 3
    Label2.Text = "second(s) between moves."
    Label2.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' DelayTextBox
    ' 
    DelayTextBox.Location = New Point(57, 15)
    DelayTextBox.MaxLength = 2
    DelayTextBox.Name = "DelayTextBox"
    DelayTextBox.Size = New Size(38, 23)
    DelayTextBox.TabIndex = 2
    DelayTextBox.Text = "1"
    ' 
    ' Label1
    ' 
    Label1.FlatStyle = FlatStyle.System
    Label1.Location = New Point(9, 15)
    Label1.Name = "Label1"
    Label1.Size = New Size(48, 28)
    Label1.TabIndex = 0
    Label1.Text = "Delay"
    Label1.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' AcceptActionButton
    ' 
    AcceptActionButton.DialogResult = DialogResult.OK
    AcceptActionButton.FlatStyle = FlatStyle.System
    AcceptActionButton.Location = New Point(76, 54)
    AcceptActionButton.Name = "AcceptActionButton"
    AcceptActionButton.Size = New Size(90, 28)
    AcceptActionButton.TabIndex = 4
    AcceptActionButton.Text = "&OK"
    ' 
    ' ReplayWindow
    ' 
    AcceptButton = AcceptActionButton
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    CancelButton = CancelActionButton
    ClientSize = New Size(286, 97)
    Controls.Add(CancelActionButton)
    Controls.Add(Label2)
    Controls.Add(DelayTextBox)
    Controls.Add(Label1)
    Controls.Add(AcceptActionButton)
    FormBorderStyle = FormBorderStyle.FixedDialog
    MaximizeBox = False
    MinimizeBox = False
    Name = "ReplayWindow"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    Text = "Replay"
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private WithEvents CancelActionButton As Button
  Private WithEvents Label2 As Label
  Friend WithEvents DelayTextBox As TextBox
  Private WithEvents Label1 As Label
  Private WithEvents AcceptActionButton As Button
End Class
