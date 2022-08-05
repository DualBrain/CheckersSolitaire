Option Explicit On
Option Strict On
Option Infer On

Friend Class About
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
  Friend WithEvents AcceptActionButton As System.Windows.Forms.Button
  Friend WithEvents ProductLabel As System.Windows.Forms.Label
  Friend WithEvents VersionLabel As System.Windows.Forms.Label
  Friend WithEvents CopyrightLabel As System.Windows.Forms.Label
  Friend WithEvents DevelopedByLabel As System.Windows.Forms.Label
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
    Me.AcceptActionButton = New System.Windows.Forms.Button()
    Me.ProductLabel = New System.Windows.Forms.Label()
    Me.VersionLabel = New System.Windows.Forms.Label()
    Me.CopyrightLabel = New System.Windows.Forms.Label()
    Me.DevelopedByLabel = New System.Windows.Forms.Label()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'AcceptActionButton
    '
    Me.AcceptActionButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.AcceptActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.AcceptActionButton.Location = New System.Drawing.Point(259, 148)
    Me.AcceptActionButton.Name = "AcceptActionButton"
    Me.AcceptActionButton.Size = New System.Drawing.Size(90, 28)
    Me.AcceptActionButton.TabIndex = 0
    Me.AcceptActionButton.Text = "&OK"
    '
    'ProductLabel
    '
    Me.ProductLabel.Location = New System.Drawing.Point(77, 20)
    Me.ProductLabel.Name = "ProductLabel"
    Me.ProductLabel.Size = New System.Drawing.Size(201, 28)
    Me.ProductLabel.TabIndex = 1
    Me.ProductLabel.Text = "Solitaire Checkers"
    '
    'VersionLabel
    '
    Me.VersionLabel.Location = New System.Drawing.Point(77, 49)
    Me.VersionLabel.Name = "VersionLabel"
    Me.VersionLabel.Size = New System.Drawing.Size(278, 29)
    Me.VersionLabel.TabIndex = 2
    Me.VersionLabel.Text = "Version [version] (Build [build])"
    '
    'CopyrightLabel
    '
    Me.CopyrightLabel.Location = New System.Drawing.Point(77, 79)
    Me.CopyrightLabel.Name = "CopyrightLabel"
    Me.CopyrightLabel.Size = New System.Drawing.Size(278, 28)
    Me.CopyrightLabel.TabIndex = 3
    Me.CopyrightLabel.Text = "Copyright © 2005-2022 Cory Smith"
    '
    'DevelopedByLabel
    '
    Me.DevelopedByLabel.Location = New System.Drawing.Point(77, 108)
    Me.DevelopedByLabel.Name = "DevelopedByLabel"
    Me.DevelopedByLabel.Size = New System.Drawing.Size(278, 29)
    Me.DevelopedByLabel.TabIndex = 4
    Me.DevelopedByLabel.Text = "Developed by Cory Smith"
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(10, 20)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureBox1.TabIndex = 5
    Me.PictureBox1.TabStop = False
    '
    'About
    '
    Me.AcceptButton = Me.AcceptActionButton
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
    Me.ClientSize = New System.Drawing.Size(359, 184)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.DevelopedByLabel)
    Me.Controls.Add(Me.CopyrightLabel)
    Me.Controls.Add(Me.VersionLabel)
    Me.Controls.Add(Me.ProductLabel)
    Me.Controls.Add(Me.AcceptActionButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "About"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "About Solitaire Checkers"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim version = New Version(Application.ProductVersion)
    VersionLabel.Text = VersionLabel.Text.Replace("[version]", $"{version.Major}.{version.Minor}") _
                                         .Replace("[build]", $"{version.Build}")
  End Sub

End Class