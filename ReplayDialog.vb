Option Explicit On 
Option Strict On

Public Class ReplayDialog
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents AcceptActionButton As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DelayTextBox As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents CancelActionButton As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.AcceptActionButton = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.DelayTextBox = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.CancelActionButton = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'AcceptActionButton
    '
    Me.AcceptActionButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.AcceptActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.AcceptActionButton.Location = New System.Drawing.Point(64, 48)
    Me.AcceptActionButton.Name = "AcceptActionButton"
    Me.AcceptActionButton.TabIndex = 0
    Me.AcceptActionButton.Text = "&OK"
    '
    'Label1
    '
    Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label1.Location = New System.Drawing.Point(8, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 23)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Delay"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'DelayTextBox
    '
    Me.DelayTextBox.Location = New System.Drawing.Point(48, 16)
    Me.DelayTextBox.MaxLength = 2
    Me.DelayTextBox.Name = "DelayTextBox"
    Me.DelayTextBox.Size = New System.Drawing.Size(32, 20)
    Me.DelayTextBox.TabIndex = 2
    Me.DelayTextBox.Text = "1"
    '
    'Label2
    '
    Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label2.Location = New System.Drawing.Point(88, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(144, 23)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "second(s) between moves."
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'CancelActionButton
    '
    Me.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.CancelActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.CancelActionButton.Location = New System.Drawing.Point(152, 48)
    Me.CancelActionButton.Name = "CancelActionButton"
    Me.CancelActionButton.TabIndex = 4
    Me.CancelActionButton.Text = "&Cancel"
    '
    'ReplayDialog
    '
    Me.AcceptButton = Me.AcceptActionButton
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.CancelButton = Me.CancelActionButton
    Me.ClientSize = New System.Drawing.Size(234, 80)
    Me.Controls.Add(Me.CancelActionButton)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DelayTextBox)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.AcceptActionButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "ReplayDialog"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Replay"
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
