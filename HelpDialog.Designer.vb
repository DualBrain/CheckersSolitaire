<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelpDialog
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
    AcceptActionButton = New Button()
    Label1 = New Label()
    SuspendLayout()
    ' 
    ' AcceptActionButton
    ' 
    AcceptActionButton.DialogResult = DialogResult.OK
    AcceptActionButton.Location = New Point(307, 79)
    AcceptActionButton.Name = "AcceptActionButton"
    AcceptActionButton.Size = New Size(90, 28)
    AcceptActionButton.TabIndex = 3
    AcceptActionButton.Text = "&OK"
    ' 
    ' Label1
    ' 
    Label1.FlatStyle = FlatStyle.System
    Label1.Location = New Point(10, 10)
    Label1.Name = "Label1"
    Label1.Size = New Size(384, 69)
    Label1.TabIndex = 2
    Label1.Text = "The object is to remove as many pieces as possible by diagonal jumping over other pieces (as in standard checkers).  A standard game consists of an 8 by 8 playing field and 48 checkers."
    ' 
    ' HelpDialog
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(408, 118)
    Controls.Add(AcceptActionButton)
    Controls.Add(Label1)
    FormBorderStyle = FormBorderStyle.FixedDialog
    MaximizeBox = False
    MinimizeBox = False
    Name = "HelpDialog"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    Text = "How to play..."
    ResumeLayout(False)
  End Sub

  Private WithEvents AcceptActionButton As Button
  Private WithEvents Label1 As Label
End Class
