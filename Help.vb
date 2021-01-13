Option Explicit On
Option Strict On
Option Infer On

Friend Class Help
  Inherits Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private ReadOnly components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents AcceptActionButton As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label
    Me.AcceptActionButton = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(320, 56)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "The object is to remove as many pieces as possible by diagonal jumping over other" &
    " pieces (as in standard checkers).  A standard game consists of an 8 by 8 playin" &
    "g field and 48 checkers."
    '
    'AcceptActionButton
    '
    Me.AcceptActionButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.AcceptActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.AcceptActionButton.Location = New System.Drawing.Point(256, 64)
    Me.AcceptActionButton.Name = "AcceptActionButton"
    Me.AcceptActionButton.TabIndex = 1
    Me.AcceptActionButton.Text = "&OK"
    '
    'Help
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(336, 96)
    Me.Controls.Add(Me.AcceptActionButton)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Help"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "How to play..."
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
