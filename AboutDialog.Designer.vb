<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutDialog
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutDialog))
    PictureBox1 = New PictureBox()
    DevelopedByLabel = New Label()
    CopyrightLabel = New Label()
    VersionLabel = New Label()
    ProductLabel = New Label()
    AcceptActionButton = New Button()
    CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' PictureBox1
    ' 
    PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
    PictureBox1.Location = New Point(10, 20)
    PictureBox1.Name = "PictureBox1"
    PictureBox1.Size = New Size(50, 50)
    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    PictureBox1.TabIndex = 11
    PictureBox1.TabStop = False
    ' 
    ' DevelopedByLabel
    ' 
    DevelopedByLabel.Location = New Point(77, 108)
    DevelopedByLabel.Name = "DevelopedByLabel"
    DevelopedByLabel.Size = New Size(278, 29)
    DevelopedByLabel.TabIndex = 10
    DevelopedByLabel.Text = "Developed by Cory Smith"
    ' 
    ' CopyrightLabel
    ' 
    CopyrightLabel.Location = New Point(77, 79)
    CopyrightLabel.Name = "CopyrightLabel"
    CopyrightLabel.Size = New Size(278, 28)
    CopyrightLabel.TabIndex = 9
    CopyrightLabel.Text = "Copyright © 2005-2022 Cory Smith"
    ' 
    ' VersionLabel
    ' 
    VersionLabel.Location = New Point(77, 49)
    VersionLabel.Name = "VersionLabel"
    VersionLabel.Size = New Size(278, 29)
    VersionLabel.TabIndex = 8
    VersionLabel.Text = "Version [version] (Build [build])"
    ' 
    ' ProductLabel
    ' 
    ProductLabel.Location = New Point(77, 20)
    ProductLabel.Name = "ProductLabel"
    ProductLabel.Size = New Size(201, 28)
    ProductLabel.TabIndex = 7
    ProductLabel.Text = "Solitaire Checkers"
    ' 
    ' AcceptActionButton
    ' 
    AcceptActionButton.DialogResult = DialogResult.OK
    AcceptActionButton.FlatStyle = FlatStyle.System
    AcceptActionButton.Location = New Point(259, 148)
    AcceptActionButton.Name = "AcceptActionButton"
    AcceptActionButton.Size = New Size(90, 28)
    AcceptActionButton.TabIndex = 6
    AcceptActionButton.Text = "&OK"
    ' 
    ' AboutDialog
    ' 
    AcceptButton = AcceptActionButton
    AutoScaleDimensions = New SizeF(7.0F, 15.0F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(359, 184)
    Controls.Add(PictureBox1)
    Controls.Add(DevelopedByLabel)
    Controls.Add(CopyrightLabel)
    Controls.Add(VersionLabel)
    Controls.Add(ProductLabel)
    Controls.Add(AcceptActionButton)
    FormBorderStyle = FormBorderStyle.FixedDialog
    MaximizeBox = False
    MinimizeBox = False
    Name = "AboutDialog"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    Text = "About Checkers Solitaire"
    CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents PictureBox1 As PictureBox
  Friend WithEvents DevelopedByLabel As Label
  Friend WithEvents CopyrightLabel As Label
  Friend WithEvents VersionLabel As Label
  Friend WithEvents ProductLabel As Label
  Friend WithEvents AcceptActionButton As Button
End Class
