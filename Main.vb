Option Explicit On
Option Strict On
Option Infer On

Public Class Main
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
  Private WithEvents Board1 As Board
  Friend WithEvents StatusBar1 As System.Windows.Forms.StatusStrip
  Friend WithEvents StatusBarPanel1 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents StatusBarPanel2 As System.Windows.Forms.ToolStripStatusLabel
  Private WithEvents MenuStrip1 As MenuStrip
  Private WithEvents GameToolStripMenuItem As ToolStripMenuItem
  Private WithEvents NewGameToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator As ToolStripSeparator
  Private WithEvents SaveHistoryToolStripMenuItem As ToolStripMenuItem
  Private WithEvents LoadHistoryToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
  Private WithEvents UndoToolStripMenuItem As ToolStripMenuItem
  Private WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
  Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
  Private WithEvents ViewToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HintsToolStripMenuItem As ToolStripMenuItem
  Private WithEvents StatusBarToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
  Private WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
  Private WithEvents ReplayToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HelpToolStripMenuItem As ToolStripMenuItem
  Private WithEvents HowToPlayToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
  Private WithEvents AboutToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents StatusBarPanel3 As System.Windows.Forms.ToolStripStatusLabel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
    Me.Board1 = New CheckersSolitaire.Board()
    Me.StatusBar1 = New System.Windows.Forms.StatusStrip()
    Me.StatusBarPanel1 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.StatusBarPanel2 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.StatusBarPanel3 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
    Me.SaveHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.LoadHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.HintsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ReplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.HowToPlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatusBar1.SuspendLayout()
    Me.MenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Board1
    '
    Me.Board1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Board1.Columns = 8
    Me.Board1.Depth = 2
    Me.Board1.Location = New System.Drawing.Point(12, 27)
    Me.Board1.Name = "Board1"
    Me.Board1.ReplayDelay = 1
    Me.Board1.Rows = 8
    Me.Board1.ShowHints = False
    Me.Board1.Size = New System.Drawing.Size(420, 393)
    Me.Board1.TabIndex = 0
    Me.Board1.TabStop = False
    '
    'StatusBar1
    '
    Me.StatusBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
    Me.StatusBar1.Location = New System.Drawing.Point(0, 423)
    Me.StatusBar1.Name = "StatusBar1"
    Me.StatusBar1.Size = New System.Drawing.Size(439, 22)
    Me.StatusBar1.TabIndex = 1
    Me.StatusBar1.Text = "StatusBar1"
    '
    'StatusBarPanel1
    '
    Me.StatusBarPanel1.Name = "StatusBarPanel1"
    Me.StatusBarPanel1.Size = New System.Drawing.Size(0, 17)
    '
    'StatusBarPanel2
    '
    Me.StatusBarPanel2.Name = "StatusBarPanel2"
    Me.StatusBarPanel2.Size = New System.Drawing.Size(0, 17)
    '
    'StatusBarPanel3
    '
    Me.StatusBarPanel3.Name = "StatusBarPanel3"
    Me.StatusBarPanel3.Size = New System.Drawing.Size(0, 17)
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(439, 24)
    Me.MenuStrip1.TabIndex = 2
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'GameToolStripMenuItem
    '
    Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ToolStripSeparator, Me.SaveHistoryToolStripMenuItem, Me.LoadHistoryToolStripMenuItem, Me.ToolStripSeparator1, Me.UndoToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
    Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
    Me.GameToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
    Me.GameToolStripMenuItem.Text = "&Game"
    '
    'NewGameToolStripMenuItem
    '
    Me.NewGameToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
    Me.NewGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
    Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
    Me.NewGameToolStripMenuItem.Text = "&New Game"
    '
    'ToolStripSeparator
    '
    Me.ToolStripSeparator.Name = "ToolStripSeparator"
    Me.ToolStripSeparator.Size = New System.Drawing.Size(148, 6)
    '
    'SaveHistoryToolStripMenuItem
    '
    Me.SaveHistoryToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.SaveHistoryToolStripMenuItem.Name = "SaveHistoryToolStripMenuItem"
    Me.SaveHistoryToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
    Me.SaveHistoryToolStripMenuItem.Text = "&Save History..."
    '
    'LoadHistoryToolStripMenuItem
    '
    Me.LoadHistoryToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.LoadHistoryToolStripMenuItem.Name = "LoadHistoryToolStripMenuItem"
    Me.LoadHistoryToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
    Me.LoadHistoryToolStripMenuItem.Text = "&Load History..."
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(148, 6)
    '
    'UndoToolStripMenuItem
    '
    Me.UndoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
    Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
    Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
    Me.UndoToolStripMenuItem.Text = "&Undo"
    '
    'OptionsToolStripMenuItem
    '
    Me.OptionsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
    Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
    Me.OptionsToolStripMenuItem.Text = "&Options..."
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(148, 6)
    '
    'ExitToolStripMenuItem
    '
    Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
    Me.ExitToolStripMenuItem.Text = "E&xit"
    '
    'ViewToolStripMenuItem
    '
    Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HintsToolStripMenuItem, Me.StatusBarToolStripMenuItem, Me.ToolStripSeparator3, Me.HistoryToolStripMenuItem, Me.ReplayToolStripMenuItem})
    Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
    Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
    Me.ViewToolStripMenuItem.Text = "&View"
    '
    'HintsToolStripMenuItem
    '
    Me.HintsToolStripMenuItem.Name = "HintsToolStripMenuItem"
    Me.HintsToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
    Me.HintsToolStripMenuItem.Text = "&Hints"
    '
    'StatusBarToolStripMenuItem
    '
    Me.StatusBarToolStripMenuItem.Checked = True
    Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
    Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
    Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
    Me.StatusBarToolStripMenuItem.Text = "Status &Bar"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(123, 6)
    '
    'HistoryToolStripMenuItem
    '
    Me.HistoryToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
    Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
    Me.HistoryToolStripMenuItem.Text = "&History"
    '
    'ReplayToolStripMenuItem
    '
    Me.ReplayToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ReplayToolStripMenuItem.Name = "ReplayToolStripMenuItem"
    Me.ReplayToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
    Me.ReplayToolStripMenuItem.Text = "&Replay"
    Me.ReplayToolStripMenuItem.Visible = False
    '
    'HelpToolStripMenuItem
    '
    Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToPlayToolStripMenuItem, Me.ToolStripSeparator5, Me.AboutToolStripMenuItem})
    Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
    Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
    Me.HelpToolStripMenuItem.Text = "&Help"
    '
    'HowToPlayToolStripMenuItem
    '
    Me.HowToPlayToolStripMenuItem.Name = "HowToPlayToolStripMenuItem"
    Me.HowToPlayToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
    Me.HowToPlayToolStripMenuItem.Text = "&How to play..."
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(144, 6)
    '
    'AboutToolStripMenuItem
    '
    Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
    Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
    Me.AboutToolStripMenuItem.Text = "&About..."
    '
    'Main
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
    Me.ClientSize = New System.Drawing.Size(439, 445)
    Me.Controls.Add(Me.StatusBar1)
    Me.Controls.Add(Me.MenuStrip1)
    Me.Controls.Add(Me.Board1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MinimumSize = New System.Drawing.Size(240, 305)
    Me.Name = "Main"
    Me.Text = "Checkers Solitaire"
    Me.StatusBar1.ResumeLayout(False)
    Me.StatusBar1.PerformLayout()
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private m_settings As Settings

  Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    m_settings = Settings.Load()

    If Not m_settings.Location.Equals(Point.Empty) AndAlso Not m_settings.Size.Equals(Drawing.Size.Empty) Then
      Me.Location = m_settings.Location
      'HACK: shorten the size by 20, somehow we are growing in height.
      'Dim size As New Size(m_settings.Size.Width, m_settings.Size.Height - 20)
      Me.Size = m_settings.Size
    Else
      'TODO: should probably validate that the coordinates are visible on the screen.
      Dim x As Integer = (Screen.PrimaryScreen.WorkingArea.Width - Me.Size.Width) \ 2
      Dim y As Integer = (Screen.PrimaryScreen.WorkingArea.Height - Me.Size.Height) \ 2
      Me.Location = New Point(x, y)
    End If

    If Not m_settings.StatusBar Then
      StatusBarToolStripMenuItem.Checked = False
      StatusBar1.Visible = False
      Board1.Height += StatusBar1.Height
    End If

    If m_settings.Hints Then
      HintsToolStripMenuItem.Checked = True
      Board1.ShowHints = True
    End If

    Board1.Rows = m_settings.BoardRows
    Board1.Columns = m_settings.BoardColumns
    Board1.Depth = m_settings.BoardDepth

    UndoToolStripMenuItem.Enabled = False
    HistoryToolStripMenuItem.Enabled = False

    StatusBar1.Items(1).Text = Board1.Count.ToString & " pieces left."

  End Sub

  Private Sub Board1_PieceMoved(sender As Object, e As Board.MoveEventArgs) Handles Board1.PieceMoved
    UndoToolStripMenuItem.Enabled = (Board1.History.Count > 0)
    HistoryToolStripMenuItem.Enabled = UndoToolStripMenuItem.Enabled
    StatusBar1.Items(1).Text = Board1.Count.ToString & " pieces left."
  End Sub

  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    Close()
  End Sub

  Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
    UndoToolStripMenuItem.Enabled = False
    HistoryToolStripMenuItem.Enabled = False
    Board1.Reset()
  End Sub

  Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

    Dim dialog As New Options(Board1.Rows, Board1.Columns, Board1.Depth)
    If dialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
      Board1.Rows = dialog.Rows
      Board1.Columns = dialog.Columns
      Board1.Depth = dialog.Depth
      StatusBar1.Items(1).Text = Board1.Count.ToString & " pieces left."
    End If
    dialog.Close()

  End Sub

  Private Sub HintsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HintsToolStripMenuItem.Click
    HintsToolStripMenuItem.Checked = Not HintsToolStripMenuItem.Checked
    Board1.ShowHints = HintsToolStripMenuItem.Checked
  End Sub

  Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
    Board1.Undo()
    UndoToolStripMenuItem.Enabled = (Board1.History.Count > 0)
    HistoryToolStripMenuItem.Enabled = UndoToolStripMenuItem.Enabled
    StatusBar1.Items(1).Text = Board1.Count.ToString & " pieces left."
  End Sub

  Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
    Using dialog As New About
      dialog.ShowDialog(Me)
    End Using
  End Sub

  Private Sub StatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.Click
    StatusBarToolStripMenuItem.Checked = Not StatusBarToolStripMenuItem.Checked
    If StatusBarToolStripMenuItem.Checked Then
      StatusBar1.Visible = True
      Board1.Height -= StatusBar1.Height
    Else
      StatusBar1.Visible = False
      Board1.Height += StatusBar1.Height
    End If
  End Sub

  Private Sub Me_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.FormClosing

    Board1.CancelReplay()

    m_settings.Location = Location
    m_settings.Size = Size

    m_settings.Hints = HintsToolStripMenuItem.Checked
    m_settings.StatusBar = StatusBarToolStripMenuItem.Checked

    m_settings.BoardRows = Board1.Rows
    m_settings.BoardColumns = Board1.Columns
    m_settings.BoardDepth = Board1.Depth

    Settings.Persist(m_settings)

  End Sub

  Private Sub HowToPlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowToPlayToolStripMenuItem.Click
    Using dialog As New Help
      dialog.ShowDialog(Me)
    End Using
  End Sub

  Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click

    Using dialog As New ViewHistory

      dialog.Rows = Board1.Rows
      dialog.Columns = Board1.Columns
      dialog.Depth = Board1.Depth

      Dim move = 1
      For Each history As History In Board1.History
        Dim item As ListViewItem = dialog.HistoryListView.Items.Add(move.ToString)
        item.SubItems.Add((history.Source.Row + 1).ToString)
        item.SubItems.Add((history.Source.Column + 1).ToString)
        item.SubItems.Add("-->")
        item.SubItems.Add((history.Destination.Row + 1).ToString)
        item.SubItems.Add((history.Destination.Column + 1).ToString)
        move += 1
      Next

      dialog.ShowDialog(Me)

    End Using

  End Sub

  Private Sub ReplayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplayToolStripMenuItem.Click

    If Board1.History IsNot Nothing AndAlso Board1.History.Count > 0 Then

      Dim history As New List(Of History)

      For Each item As History In Board1.History
        history.Add(New History(item.Source, item.Destination))
      Next

      Board1.Replay(history)

    End If

  End Sub

  Private Sub Main_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    If e.KeyCode = Keys.Escape Then
      Board1.CancelReplay()
    End If
  End Sub

  Private Sub Board1_ReplayBegin(sender As Object, e As EventArgs) Handles Board1.ReplayBegin
    StatusBar1.Items(2).Text = "Replay"
  End Sub

  Private Sub Board1_ReplayFinish(sender As Object, e As EventArgs) Handles Board1.ReplayFinish
    StatusBar1.Items(2).Text = ""
  End Sub

  Private Sub SaveHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveHistoryToolStripMenuItem.Click

    Using dialog As New SaveFileDialog With {.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                                             .FilterIndex = 1,
                                             .RestoreDirectory = True,
                                             .OverwritePrompt = True,
                                             .AddExtension = True}
      If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
        Using stream As New IO.StreamWriter(dialog.OpenFile())
          If stream IsNot Nothing Then
            stream.WriteLine($"""Checkers Solitaire"",""{Application.ProductVersion}"",""{Board1.Rows}"",""{Board1.Columns}"",""{Board1.Depth}""")
            stream.WriteLine("""Move #"",""Start Row"",""Start Column"",""Destination Row"",""Destination Column""")
            Dim move = 1
            For Each item As History In Board1.History
              Dim line = $"{move},{item.Source.Row + 1},{item.Source.Column + 1},{item.Destination.Row + 1},{item.Destination.Column + 1}"
              stream.WriteLine(line)
              move += 1
            Next
          End If
        End Using
      End If
    End Using

  End Sub

  Private Sub LoadHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadHistoryToolStripMenuItem.Click

    Dim history As List(Of History) = Nothing

    Dim rows = 8
    Dim columns = 8
    Dim depth = 2

    Using dialog As New OpenFileDialog With {.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                                             .FilterIndex = 1,
                                             .RestoreDirectory = True,
                                             .CheckFileExists = True}
      If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
        Using stream As New IO.StreamReader(dialog.OpenFile())
          Dim header = """Move #"",""Start Row"",""Start Column"",""Destination Row"",""Destination Column"""
          If stream IsNot Nothing Then
            Dim valid = False
            Dim line = stream.ReadLine
            If line.IndexOf("Checkers Solitaire") > -1 Then
              Dim line2 = stream.ReadLine
              If line2 = header Then
                valid = True
                Dim elements = Split(line.Replace(Chr(34), ""), ",")
                rows = CInt(elements(2))
                columns = CInt(elements(3))
                depth = CInt(elements(4))
              End If
            ElseIf line = header Then
              ' valid file for an 8x8x2 game.
              valid = True
              rows = 8
              columns = 8
              depth = 2
            End If
            If valid Then
              ' Assume the file is good.
              history = New List(Of History)
              Do
                line = stream.ReadLine
                If line IsNot Nothing Then
                  Dim values() = Split(line, ","c)
                  If values.Length = 5 Then
                    Dim source = New Board.RowColumn(CInt(values(1)) - 1, CInt(values(2)) - 1)
                    Dim destination = New Board.RowColumn(CInt(values(3)) - 1, CInt(values(4)) - 1)
                    history.Add(New History(source, destination))
                  End If
                Else
                  Exit Do
                End If
              Loop
            End If
          End If
        End Using
      End If
    End Using

    If history IsNot Nothing AndAlso
       history.Count > 0 Then

      Board1.Rows = rows
      Board1.Columns = columns
      Board1.Depth = depth

      Dim delay = 1
      Using replay As New ReplayDialog
        If replay.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
          If IsNumeric(replay.DelayTextBox.Text) Then
            delay = CInt(replay.DelayTextBox.Text)
            If delay < 1 Then
              delay = 1
            End If
          End If
          Board1.ReplayDelay = delay
        Else
          delay = -1
        End If
      End Using

      Board1.Replay(history, Not delay = -1)

    End If

  End Sub

End Class