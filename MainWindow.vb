Public Class MainWindow

  Private m_settings As Settings

  Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    m_settings = Settings.Load()

    If Not m_settings.Location.Equals(Point.Empty) AndAlso Not m_settings.Size.Equals(Drawing.Size.Empty) Then
      Location = m_settings.Location
      'HACK: shorten the size by 20, somehow we are growing in height.
      'Dim size As New Size(m_settings.Size.Width, m_settings.Size.Height - 20)
      Size = m_settings.Size
    Else
      'TODO: should probably validate that the coordinates are visible on the screen.
      Dim x = (Screen.PrimaryScreen.WorkingArea.Width - Size.Width) \ 2
      Dim y = (Screen.PrimaryScreen.WorkingArea.Height - Size.Height) \ 2
      Location = New Point(x, y)
    End If

    If Not m_settings.StatusBar Then
      StatusBarToolStripMenuItem.Checked = False
      StatusBar1.Visible = False
      Board.Height += StatusBar1.Height
    End If

    If m_settings.Hints Then
      HintsToolStripMenuItem.Checked = True
      Board.ShowHints = True
    End If

    Board.Rows = m_settings.BoardRows
    Board.Columns = m_settings.BoardColumns
    Board.Depth = m_settings.BoardDepth

    UndoToolStripMenuItem.Enabled = False
    HistoryToolStripMenuItem.Enabled = False

    StatusBar1.Items(1).Text = Board.Count.ToString & " pieces left."

  End Sub

  Private Sub Board1_PieceMoved(sender As Object, e As GameBoard.MoveEventArgs) Handles Board.PieceMoved
    UndoToolStripMenuItem.Enabled = (Board.History.Count > 0)
    HistoryToolStripMenuItem.Enabled = UndoToolStripMenuItem.Enabled
    StatusBar1.Items(1).Text = Board.Count.ToString & " pieces left."
  End Sub

  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    Close()
  End Sub

  Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
    UndoToolStripMenuItem.Enabled = False
    HistoryToolStripMenuItem.Enabled = False
    Board.Reset()
  End Sub

  Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

    Dim dialog As New OptionsDialog(Board.Rows, Board.Columns, Board.Depth)
    If dialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      Board.Rows = dialog.Rows
      Board.Columns = dialog.Columns
      Board.Depth = dialog.Depth
      StatusBar1.Items(1).Text = Board.Count.ToString & " pieces left."
    End If
    dialog.Close()

  End Sub

  Private Sub HintsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HintsToolStripMenuItem.Click
    HintsToolStripMenuItem.Checked = Not HintsToolStripMenuItem.Checked
    Board.ShowHints = HintsToolStripMenuItem.Checked
  End Sub

  Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
    Board.Undo()
    UndoToolStripMenuItem.Enabled = (Board.History.Count > 0)
    HistoryToolStripMenuItem.Enabled = UndoToolStripMenuItem.Enabled
    StatusBar1.Items(1).Text = Board.Count.ToString & " pieces left."
  End Sub

  Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
    Using dialog As New AboutDialog
      dialog.ShowDialog(Me)
    End Using
  End Sub

  Private Sub StatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.Click
    StatusBarToolStripMenuItem.Checked = Not StatusBarToolStripMenuItem.Checked
    If StatusBarToolStripMenuItem.Checked Then
      StatusBar1.Visible = True
      Board.Height -= StatusBar1.Height
    Else
      StatusBar1.Visible = False
      Board.Height += StatusBar1.Height
    End If
  End Sub

  Private Sub Me_Closing(sender As Object, e As ComponentModel.CancelEventArgs)

    Board.CancelReplay()

    m_settings.Location = Location
    m_settings.Size = Size

    m_settings.Hints = HintsToolStripMenuItem.Checked
    m_settings.StatusBar = StatusBarToolStripMenuItem.Checked

    m_settings.BoardRows = Board.Rows
    m_settings.BoardColumns = Board.Columns
    m_settings.BoardDepth = Board.Depth

    Settings.Persist(m_settings)

  End Sub

  Private Sub HowToPlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowToPlayToolStripMenuItem.Click
    Using dialog As New HelpDialog
      dialog.ShowDialog(Me)
    End Using
  End Sub

  Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click

    Using dialog As New HistoryDialog

      dialog.Rows = Board.Rows
      dialog.Columns = Board.Columns
      dialog.Depth = Board.Depth

      Dim move = 1
      For Each history In Board.History
        Dim item = dialog.HistoryListView.Items.Add(move.ToString)
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

    If Board.History IsNot Nothing AndAlso Board.History.Count > 0 Then

      Dim history As New List(Of GameHistory)

      For Each item As GameHistory In Board.History
        history.Add(New GameHistory(item.Source, item.Destination))
      Next

      Board.Replay(history)

    End If

  End Sub

  Private Sub Me_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    If e.KeyCode = Keys.Escape Then
      Board.CancelReplay()
    End If
  End Sub

  Private Sub Board1_ReplayBegin(sender As Object, e As EventArgs) Handles Board.ReplayBegin
    StatusBar1.Items(2).Text = "Replay"
  End Sub

  Private Sub Board1_ReplayFinish(sender As Object, e As EventArgs) Handles Board.ReplayFinish
    StatusBar1.Items(2).Text = ""
  End Sub

  Private Sub SaveHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveHistoryToolStripMenuItem.Click

    Using dialog As New SaveFileDialog With {.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                                             .FilterIndex = 1,
                                             .RestoreDirectory = True,
                                             .OverwritePrompt = True,
                                             .AddExtension = True}
      If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        Using stream As New IO.StreamWriter(dialog.OpenFile())
          If stream IsNot Nothing Then
            stream.WriteLine($"""Checkers Solitaire"",""{Application.ProductVersion}"",""{Board.Rows}"",""{Board.Columns}"",""{Board.Depth}""")
            stream.WriteLine("""Move #"",""Start Row"",""Start Column"",""Destination Row"",""Destination Column""")
            Dim move = 1
            For Each item As GameHistory In Board.History
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

    Dim history As List(Of GameHistory) = Nothing

    Dim rows = 8
    Dim columns = 8
    Dim depth = 2

    Using dialog As New OpenFileDialog With {.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                                             .FilterIndex = 1,
                                             .RestoreDirectory = True,
                                             .CheckFileExists = True}
      If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
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
              history = New List(Of GameHistory)
              Do
                line = stream.ReadLine
                If line IsNot Nothing Then
                  Dim values = Split(line, ","c)
                  If values.Length = 5 Then
                    Dim source = New GameBoard.RowColumn(CInt(values(1)) - 1, CInt(values(2)) - 1)
                    Dim destination = New GameBoard.RowColumn(CInt(values(3)) - 1, CInt(values(4)) - 1)
                    history.Add(New GameHistory(source, destination))
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

      Board.Rows = rows
      Board.Columns = columns
      Board.Depth = depth

      Dim delay = 1
      Using replay As New ReplayDialog
        If replay.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
          If IsNumeric(replay.DelayTextBox.Text) Then
            delay = CInt(replay.DelayTextBox.Text)
            If delay < 1 Then
              delay = 1
            End If
          End If
          Board.ReplayDelay = delay
        Else
          delay = -1
        End If
      End Using

      Board.Replay(history, Not delay = -1)

    End If

  End Sub

End Class