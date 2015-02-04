Option Explicit On 
Option Strict On

Public Class Main
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
  Friend WithEvents Board1 As CheckersSolitaire.Board
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
  Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
  Friend WithEvents GameUndoMenuItem As System.Windows.Forms.MenuItem
  Friend WithEvents ViewHints As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
  Friend WithEvents ViewStatusBar As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
  Friend WithEvents ViewHistoryMenuItem As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
  Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
  Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
  Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
  Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Main))
    Me.Board1 = New CheckersSolitaire.Board
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.MenuItem1 = New System.Windows.Forms.MenuItem
    Me.MenuItem4 = New System.Windows.Forms.MenuItem
    Me.MenuItem11 = New System.Windows.Forms.MenuItem
    Me.MenuItem13 = New System.Windows.Forms.MenuItem
    Me.GameUndoMenuItem = New System.Windows.Forms.MenuItem
    Me.MenuItem6 = New System.Windows.Forms.MenuItem
    Me.MenuItem12 = New System.Windows.Forms.MenuItem
    Me.MenuItem2 = New System.Windows.Forms.MenuItem
    Me.MenuItem3 = New System.Windows.Forms.MenuItem
    Me.ViewHints = New System.Windows.Forms.MenuItem
    Me.ViewStatusBar = New System.Windows.Forms.MenuItem
    Me.MenuItem8 = New System.Windows.Forms.MenuItem
    Me.ViewHistoryMenuItem = New System.Windows.Forms.MenuItem
    Me.MenuItem14 = New System.Windows.Forms.MenuItem
    Me.MenuItem9 = New System.Windows.Forms.MenuItem
    Me.MenuItem7 = New System.Windows.Forms.MenuItem
    Me.MenuItem5 = New System.Windows.Forms.MenuItem
    Me.MenuItem10 = New System.Windows.Forms.MenuItem
    Me.StatusBar1 = New System.Windows.Forms.StatusBar
    Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
    Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
    Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel
    Me.MenuItem15 = New System.Windows.Forms.MenuItem
    Me.MenuItem16 = New System.Windows.Forms.MenuItem
    CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Board1
    '
    Me.Board1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Board1.Columns = 8
    Me.Board1.Depth = 2
    Me.Board1.Location = New System.Drawing.Point(8, 8)
    Me.Board1.Name = "Board1"
    Me.Board1.Rows = 8
    Me.Board1.ShowHints = False
    Me.Board1.Size = New System.Drawing.Size(416, 387)
    Me.Board1.TabIndex = 0
    Me.Board1.TabStop = False
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem3, Me.MenuItem9})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem15, Me.MenuItem16, Me.MenuItem11, Me.MenuItem13, Me.GameUndoMenuItem, Me.MenuItem6, Me.MenuItem12, Me.MenuItem2})
    Me.MenuItem1.Text = "&Game"
    '
    'MenuItem4
    '
    Me.MenuItem4.Index = 0
    Me.MenuItem4.Shortcut = System.Windows.Forms.Shortcut.F2
    Me.MenuItem4.Text = "&New Game"
    '
    'MenuItem11
    '
    Me.MenuItem11.Index = 3
    Me.MenuItem11.Text = "&Load History..."
    '
    'MenuItem13
    '
    Me.MenuItem13.Index = 4
    Me.MenuItem13.Text = "-"
    '
    'GameUndoMenuItem
    '
    Me.GameUndoMenuItem.Enabled = False
    Me.GameUndoMenuItem.Index = 5
    Me.GameUndoMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
    Me.GameUndoMenuItem.Text = "&Undo"
    '
    'MenuItem6
    '
    Me.MenuItem6.Index = 6
    Me.MenuItem6.Text = "&Options..."
    '
    'MenuItem12
    '
    Me.MenuItem12.Index = 7
    Me.MenuItem12.Text = "-"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 8
    Me.MenuItem2.Text = "E&xit"
    '
    'MenuItem3
    '
    Me.MenuItem3.Index = 1
    Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewHints, Me.ViewStatusBar, Me.MenuItem8, Me.ViewHistoryMenuItem, Me.MenuItem14})
    Me.MenuItem3.Text = "&View"
    '
    'ViewHints
    '
    Me.ViewHints.Index = 0
    Me.ViewHints.Text = "&Hints"
    '
    'ViewStatusBar
    '
    Me.ViewStatusBar.Checked = True
    Me.ViewStatusBar.Index = 1
    Me.ViewStatusBar.Text = "Status &Bar"
    '
    'MenuItem8
    '
    Me.MenuItem8.Index = 2
    Me.MenuItem8.Text = "-"
    '
    'ViewHistoryMenuItem
    '
    Me.ViewHistoryMenuItem.Index = 3
    Me.ViewHistoryMenuItem.Text = "&History"
    '
    'MenuItem14
    '
    Me.MenuItem14.Index = 4
    Me.MenuItem14.Text = "&Replay"
    Me.MenuItem14.Visible = False
    '
    'MenuItem9
    '
    Me.MenuItem9.Index = 2
    Me.MenuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.MenuItem5, Me.MenuItem10})
    Me.MenuItem9.Text = "&Help"
    '
    'MenuItem7
    '
    Me.MenuItem7.Index = 0
    Me.MenuItem7.Text = "&How to play..."
    '
    'MenuItem5
    '
    Me.MenuItem5.Index = 1
    Me.MenuItem5.Text = "-"
    '
    'MenuItem10
    '
    Me.MenuItem10.Index = 2
    Me.MenuItem10.Text = "&About..."
    '
    'StatusBar1
    '
    Me.StatusBar1.Location = New System.Drawing.Point(0, 403)
    Me.StatusBar1.Name = "StatusBar1"
    Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
    Me.StatusBar1.ShowPanels = True
    Me.StatusBar1.Size = New System.Drawing.Size(432, 22)
    Me.StatusBar1.TabIndex = 1
    Me.StatusBar1.Text = "StatusBar1"
    '
    'StatusBarPanel1
    '
    Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.StatusBarPanel1.Width = 216
    '
    'MenuItem15
    '
    Me.MenuItem15.Index = 1
    Me.MenuItem15.Text = "-"
    '
    'MenuItem16
    '
    Me.MenuItem16.Index = 2
    Me.MenuItem16.Text = "&Save History..."
    '
    'Main
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 425)
    Me.Controls.Add(Me.StatusBar1)
    Me.Controls.Add(Me.Board1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Menu = Me.MainMenu1
    Me.MinimumSize = New System.Drawing.Size(200, 248)
    Me.Name = "Main"
    Me.Text = "Checkers Solitaire"
    CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_settings As Settings

  Shared Sub Main()
    Application.EnableVisualStyles()
    Application.DoEvents()
    Application.Run(New Main)
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
      ViewStatusBar.Checked = False
      StatusBar1.Visible = False
      Board1.Height += StatusBar1.Height
    End If

    If m_settings.Hints Then
      ViewHints.Checked = True
      Board1.ShowHints = True
    End If

    Board1.Rows = m_settings.BoardRows
    Board1.Columns = m_settings.BoardColumns
    Board1.Depth = m_settings.BoardDepth

    GameUndoMenuItem.Enabled = False
    ViewHistoryMenuItem.Enabled = False

    StatusBar1.Panels(1).Text = Board1.Count.ToString & " pieces left."

  End Sub

  Private Sub Board1_PieceMoved(ByVal sender As Object, ByVal e As Board.MoveEventArgs) Handles Board1.PieceMoved
    GameUndoMenuItem.Enabled = (Board1.History.Count > 0)
    ViewHistoryMenuItem.Enabled = GameUndoMenuItem.Enabled
    StatusBar1.Panels(1).Text = Board1.Count.ToString & " pieces left."
  End Sub

  Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
    Me.Close()
  End Sub

  Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
    GameUndoMenuItem.Enabled = False
    ViewHistoryMenuItem.Enabled = False
    Board1.Reset()
  End Sub

  Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click

    Dim dialog As New Options(Board1.Rows, Board1.Columns, Board1.Depth)
    If dialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
      Board1.Rows = dialog.Rows
      Board1.Columns = dialog.Columns
      Board1.Depth = dialog.Depth
      StatusBar1.Panels(1).Text = Board1.Count.ToString & " pieces left."
    End If
    dialog.Close()

  End Sub

  Private Sub ViewHints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewHints.Click
    ViewHints.Checked = Not ViewHints.Checked
    Board1.ShowHints = ViewHints.Checked
  End Sub

  Private Sub GameUndoMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameUndoMenuItem.Click
    Board1.Undo()
    GameUndoMenuItem.Enabled = (Board1.History.Count > 0)
    ViewHistoryMenuItem.Enabled = GameUndoMenuItem.Enabled
    StatusBar1.Panels(1).Text = Board1.Count.ToString & " pieces left."
  End Sub

  Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
    Dim dialog As New About
    dialog.ShowDialog(Me)
    dialog.Close()
  End Sub

  Private Sub ViewStatusBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewStatusBar.Click
    ViewStatusBar.Checked = Not ViewStatusBar.Checked
    If ViewStatusBar.Checked Then
      StatusBar1.Visible = True
      Board1.Height -= StatusBar1.Height
    Else
      StatusBar1.Visible = False
      Board1.Height += StatusBar1.Height
    End If
  End Sub

  Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    Board1.CancelReplay()

    m_settings.Location = Me.Location
    m_settings.Size = Me.Size

    m_settings.Hints = ViewHints.Checked
    m_settings.StatusBar = ViewStatusBar.Checked

    m_settings.BoardRows = Board1.Rows
    m_settings.BoardColumns = Board1.Columns
    m_settings.BoardDepth = Board1.Depth

    Settings.Persist(m_settings)

  End Sub

  Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
    Dim dialog As New Help
    dialog.ShowDialog(Me)
    dialog.Close()
  End Sub

  Private Sub ViewHistoryMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewHistoryMenuItem.Click

    Dim dialog As New ViewHistory
    dialog.Rows = Board1.Rows
    dialog.Columns = Board1.Columns
    dialog.Depth = Board1.Depth

    Dim move As Integer = 1
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

  End Sub

  Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click

    Dim history As HistoryCollection = Nothing

    Dim rows As Integer
    Dim columns As Integer
    Dim depth As Integer

    Dim dialog As New OpenFileDialog
    dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
    dialog.FilterIndex = 1
    dialog.RestoreDirectory = True
    dialog.CheckFileExists = True
    If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
      Dim stream As New System.IO.StreamReader(dialog.OpenFile())
      Dim header As String = """Move #"",""Start Row"",""Start Column"",""Destination Row"",""Destination Column"""
      'Dim version As String = Nothing
      If Not (stream Is Nothing) Then
        Dim valid As Boolean
        Dim line As String = stream.ReadLine
        If line.IndexOf("Checkers Solitaire") > -1 Then
          Dim line2 As String = stream.ReadLine
          If line2 = header Then
            valid = True
            Dim elements As String() = Split(line.Replace(Chr(34), ""), ",")
            'version = elements(1)
            rows = CInt(elements(2))
            columns = CInt(elements(3))
            depth = CInt(elements(4))
          End If
        ElseIf line = header Then
          ' valid file for an 8x8x2 game.
          valid = True
          'version = "0.1.6"
          rows = 8
          columns = 8
          depth = 2
        End If
        If valid Then
          ' Assume the file is good.
          history = New HistoryCollection
          Do
            line = stream.ReadLine
            If Not line Is Nothing Then
              Dim values() As String = Split(line, ","c)
              If values.Length = 5 Then
                Dim source As New Board.RowColumn(CInt(values(1)) - 1, CInt(values(2)) - 1)
                Dim destination As New Board.RowColumn(CInt(values(3)) - 1, CInt(values(4)) - 1)
                history.Add(New History(source, destination))
              End If
            Else
              Exit Do
            End If
          Loop
        End If
      End If
      stream.Close()
    End If

    If Not history Is Nothing AndAlso history.Count > 0 Then

      Board1.Rows = rows
      Board1.Columns = columns
      Board1.Depth = depth

      Dim delay As Integer = 1
      Dim replay As New ReplayDialog
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

      'Try
      If delay = -1 Then
        Board1.Replay(history, False)
      Else
        Board1.Replay(history)
      End If
      'Catch ex As Exception
      '  MsgBox(ex.ToString)
      'End Try

    End If

  End Sub

  Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click

    If Not Board1.History Is Nothing AndAlso Board1.History.Count > 0 Then

      Dim history As New HistoryCollection

      For Each item As History In Board1.History
        history.Add(New History(item.Source, item.Destination))
      Next

      'Try
      Board1.Replay(history)
      'Catch ex As Exception
      ' MsgBox(ex.ToString)
      'End Try

    End If

  End Sub

  Private Sub Main_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
    If e.KeyCode = Keys.Escape Then
      Board1.CancelReplay()
    End If
  End Sub

  Private Sub Board1_ReplayBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Board1.ReplayBegin
    StatusBar1.Panels(2).Text = "Replay"
  End Sub

  Private Sub Board1_ReplayFinish(ByVal sender As Object, ByVal e As System.EventArgs) Handles Board1.ReplayFinish
    StatusBar1.Panels(2).Text = ""
  End Sub

  Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click

    'Dim history As HistoryCollection

    Dim dialog As New SaveFileDialog
    dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
    dialog.FilterIndex = 1
    dialog.RestoreDirectory = True
    dialog.OverwritePrompt = True
    dialog.AddExtension = True
    If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
      Dim stream As New System.IO.StreamWriter(dialog.OpenFile())
      If Not (stream Is Nothing) Then
        Dim line As String
        Dim tag As String = """Checkers Solitaire"",""" & Application.ProductVersion & """,""" & Board1.Rows.ToString & """,""" & Board1.Columns.ToString & """,""" & Board1.Depth.ToString & """"
        Dim header As String = """Move #"",""Start Row"",""Start Column"",""Destination Row"",""Destination Column"""
        stream.WriteLine(tag)
        stream.WriteLine(header)
        Dim move As Integer = 1
        For Each item As History In Board1.History
          line = move.ToString & "," & (item.Source.Row + 1).ToString & "," & (item.Source.Column + 1).ToString & "," & (item.Destination.Row + 1).ToString & "," & (item.Destination.Column + 1).ToString
          stream.WriteLine(line)
          move += 1
        Next
      End If
      stream.Close()
    End If

  End Sub

End Class