<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
    AboutToolStripMenuItem = New ToolStripMenuItem()
    HowToPlayToolStripMenuItem = New ToolStripMenuItem()
    HelpToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator5 = New ToolStripSeparator()
    ReplayToolStripMenuItem = New ToolStripMenuItem()
    HistoryToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator3 = New ToolStripSeparator()
    StatusBarToolStripMenuItem = New ToolStripMenuItem()
    HintsToolStripMenuItem = New ToolStripMenuItem()
    ViewToolStripMenuItem = New ToolStripMenuItem()
    ExitToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator2 = New ToolStripSeparator()
    OptionsToolStripMenuItem = New ToolStripMenuItem()
    UndoToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator1 = New ToolStripSeparator()
    LoadHistoryToolStripMenuItem = New ToolStripMenuItem()
    SaveHistoryToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator = New ToolStripSeparator()
    NewGameToolStripMenuItem = New ToolStripMenuItem()
    GameToolStripMenuItem = New ToolStripMenuItem()
    MenuStrip1 = New MenuStrip()
    StatusBarPanel3 = New ToolStripStatusLabel()
    StatusBarPanel2 = New ToolStripStatusLabel()
    StatusBarPanel1 = New ToolStripStatusLabel()
    StatusBar1 = New StatusStrip()
    Board = New GameBoard()
    MenuStrip1.SuspendLayout()
    StatusBar1.SuspendLayout()
    SuspendLayout()
    ' 
    ' AboutToolStripMenuItem
    ' 
    AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
    AboutToolStripMenuItem.Size = New Size(147, 22)
    AboutToolStripMenuItem.Text = "&About..."
    ' 
    ' HowToPlayToolStripMenuItem
    ' 
    HowToPlayToolStripMenuItem.Name = "HowToPlayToolStripMenuItem"
    HowToPlayToolStripMenuItem.Size = New Size(147, 22)
    HowToPlayToolStripMenuItem.Text = "&How to play..."
    ' 
    ' HelpToolStripMenuItem
    ' 
    HelpToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {HowToPlayToolStripMenuItem, ToolStripSeparator5, AboutToolStripMenuItem})
    HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
    HelpToolStripMenuItem.Size = New Size(44, 20)
    HelpToolStripMenuItem.Text = "&Help"
    ' 
    ' ToolStripSeparator5
    ' 
    ToolStripSeparator5.Name = "ToolStripSeparator5"
    ToolStripSeparator5.Size = New Size(144, 6)
    ' 
    ' ReplayToolStripMenuItem
    ' 
    ReplayToolStripMenuItem.ImageTransparentColor = Color.Magenta
    ReplayToolStripMenuItem.Name = "ReplayToolStripMenuItem"
    ReplayToolStripMenuItem.Size = New Size(126, 22)
    ReplayToolStripMenuItem.Text = "&Replay"
    ReplayToolStripMenuItem.Visible = False
    ' 
    ' HistoryToolStripMenuItem
    ' 
    HistoryToolStripMenuItem.ImageTransparentColor = Color.Magenta
    HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
    HistoryToolStripMenuItem.Size = New Size(126, 22)
    HistoryToolStripMenuItem.Text = "&History"
    ' 
    ' ToolStripSeparator3
    ' 
    ToolStripSeparator3.Name = "ToolStripSeparator3"
    ToolStripSeparator3.Size = New Size(123, 6)
    ' 
    ' StatusBarToolStripMenuItem
    ' 
    StatusBarToolStripMenuItem.Checked = True
    StatusBarToolStripMenuItem.CheckState = CheckState.Checked
    StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
    StatusBarToolStripMenuItem.Size = New Size(126, 22)
    StatusBarToolStripMenuItem.Text = "Status &Bar"
    ' 
    ' HintsToolStripMenuItem
    ' 
    HintsToolStripMenuItem.Name = "HintsToolStripMenuItem"
    HintsToolStripMenuItem.Size = New Size(126, 22)
    HintsToolStripMenuItem.Text = "&Hints"
    ' 
    ' ViewToolStripMenuItem
    ' 
    ViewToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {HintsToolStripMenuItem, StatusBarToolStripMenuItem, ToolStripSeparator3, HistoryToolStripMenuItem, ReplayToolStripMenuItem})
    ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
    ViewToolStripMenuItem.Size = New Size(44, 20)
    ViewToolStripMenuItem.Text = "&View"
    ' 
    ' ExitToolStripMenuItem
    ' 
    ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    ExitToolStripMenuItem.Size = New Size(151, 22)
    ExitToolStripMenuItem.Text = "E&xit"
    ' 
    ' ToolStripSeparator2
    ' 
    ToolStripSeparator2.Name = "ToolStripSeparator2"
    ToolStripSeparator2.Size = New Size(148, 6)
    ' 
    ' OptionsToolStripMenuItem
    ' 
    OptionsToolStripMenuItem.ImageTransparentColor = Color.Magenta
    OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
    OptionsToolStripMenuItem.Size = New Size(151, 22)
    OptionsToolStripMenuItem.Text = "&Options..."
    ' 
    ' UndoToolStripMenuItem
    ' 
    UndoToolStripMenuItem.ImageTransparentColor = Color.Magenta
    UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
    UndoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Z
    UndoToolStripMenuItem.Size = New Size(151, 22)
    UndoToolStripMenuItem.Text = "&Undo"
    ' 
    ' ToolStripSeparator1
    ' 
    ToolStripSeparator1.Name = "ToolStripSeparator1"
    ToolStripSeparator1.Size = New Size(148, 6)
    ' 
    ' LoadHistoryToolStripMenuItem
    ' 
    LoadHistoryToolStripMenuItem.ImageTransparentColor = Color.Magenta
    LoadHistoryToolStripMenuItem.Name = "LoadHistoryToolStripMenuItem"
    LoadHistoryToolStripMenuItem.Size = New Size(151, 22)
    LoadHistoryToolStripMenuItem.Text = "&Load History..."
    ' 
    ' SaveHistoryToolStripMenuItem
    ' 
    SaveHistoryToolStripMenuItem.ImageTransparentColor = Color.Magenta
    SaveHistoryToolStripMenuItem.Name = "SaveHistoryToolStripMenuItem"
    SaveHistoryToolStripMenuItem.Size = New Size(151, 22)
    SaveHistoryToolStripMenuItem.Text = "&Save History..."
    ' 
    ' ToolStripSeparator
    ' 
    ToolStripSeparator.Name = "ToolStripSeparator"
    ToolStripSeparator.Size = New Size(148, 6)
    ' 
    ' NewGameToolStripMenuItem
    ' 
    NewGameToolStripMenuItem.ImageTransparentColor = Color.Magenta
    NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
    NewGameToolStripMenuItem.ShortcutKeys = Keys.F2
    NewGameToolStripMenuItem.Size = New Size(151, 22)
    NewGameToolStripMenuItem.Text = "&New Game"
    ' 
    ' GameToolStripMenuItem
    ' 
    GameToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NewGameToolStripMenuItem, ToolStripSeparator, SaveHistoryToolStripMenuItem, LoadHistoryToolStripMenuItem, ToolStripSeparator1, UndoToolStripMenuItem, OptionsToolStripMenuItem, ToolStripSeparator2, ExitToolStripMenuItem})
    GameToolStripMenuItem.Name = "GameToolStripMenuItem"
    GameToolStripMenuItem.Size = New Size(50, 20)
    GameToolStripMenuItem.Text = "&Game"
    ' 
    ' MenuStrip1
    ' 
    MenuStrip1.Items.AddRange(New ToolStripItem() {GameToolStripMenuItem, ViewToolStripMenuItem, HelpToolStripMenuItem})
    MenuStrip1.Location = New Point(0, 0)
    MenuStrip1.Name = "MenuStrip1"
    MenuStrip1.Size = New Size(439, 24)
    MenuStrip1.TabIndex = 1
    MenuStrip1.Text = "MenuStrip1"
    ' 
    ' StatusBarPanel3
    ' 
    StatusBarPanel3.Name = "StatusBarPanel3"
    StatusBarPanel3.Size = New Size(0, 17)
    ' 
    ' StatusBarPanel2
    ' 
    StatusBarPanel2.Name = "StatusBarPanel2"
    StatusBarPanel2.Size = New Size(0, 17)
    ' 
    ' StatusBarPanel1
    ' 
    StatusBarPanel1.Name = "StatusBarPanel1"
    StatusBarPanel1.Size = New Size(0, 17)
    ' 
    ' StatusBar1
    ' 
    StatusBar1.Items.AddRange(New ToolStripItem() {StatusBarPanel1, StatusBarPanel2, StatusBarPanel3})
    StatusBar1.Location = New Point(0, 423)
    StatusBar1.Name = "StatusBar1"
    StatusBar1.Size = New Size(439, 22)
    StatusBar1.TabIndex = 2
    StatusBar1.Text = "StatusBar1"
    ' 
    ' Board1
    ' 
    Board.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    Board.Columns = 8
    Board.Depth = 2
    Board.Location = New Point(12, 27)
    Board.Name = "Board1"
    Board.ReplayDelay = 1
    Board.Rows = 8
    Board.ShowHints = False
    Board.Size = New Size(420, 393)
    Board.TabIndex = 0
    Board.TabStop = False
    ' 
    ' MainWindow
    ' 
    AutoScaleDimensions = New SizeF(7.0F, 15.0F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(439, 445)
    Controls.Add(MenuStrip1)
    Controls.Add(StatusBar1)
    Controls.Add(Board)
    Icon = CType(resources.GetObject("$this.Icon"), Icon)
    MinimumSize = New Size(240, 305)
    Name = "MainWindow"
    Text = "Checkers Solitaire"
    MenuStrip1.ResumeLayout(False)
    MenuStrip1.PerformLayout()
    StatusBar1.ResumeLayout(False)
    StatusBar1.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private WithEvents AboutToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HowToPlayToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HelpToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
  Private WithEvents ReplayToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
  Private WithEvents StatusBarToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HintsToolStripMenuItem As ToolStripMenuItem
  Private WithEvents ViewToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
  Private WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
  Private WithEvents UndoToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
  Private WithEvents LoadHistoryToolStripMenuItem As ToolStripMenuItem
  Private WithEvents SaveHistoryToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator As ToolStripSeparator
  Private WithEvents NewGameToolStripMenuItem As ToolStripMenuItem
  Private WithEvents GameToolStripMenuItem As ToolStripMenuItem
  Private WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents StatusBarPanel3 As ToolStripStatusLabel
  Friend WithEvents StatusBarPanel2 As ToolStripStatusLabel
  Friend WithEvents StatusBarPanel1 As ToolStripStatusLabel
  Friend WithEvents StatusBar1 As StatusStrip
  Private WithEvents Board As GameBoard
End Class
