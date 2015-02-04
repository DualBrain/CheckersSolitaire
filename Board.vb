Option Explicit On 
Option Strict On

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class Board
  Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call
    Me.SetStyle(ControlStyles.DoubleBuffer, True)
    Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    Me.SetStyle(ControlStyles.UserPaint, True)

  End Sub

  'UserControl overrides dispose to clean up the component list.
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '
    'Board
    '
    Me.Name = "Board"
    Me.Size = New System.Drawing.Size(344, 248)

  End Sub

#End Region

  Public Event ReplayBegin As EventHandler
  Public Event ReplayFinish As EventHandler
  Public Event PieceMoved As EventHandler(Of MoveEventArgs) '(ByVal sender As Object, ByVal e As MoveEventArgs)

  Private m_columns As Integer = 8
  Private m_rows As Integer = 8
  Private m_depth As Integer = 2
  Private m_rowColumn As RowColumn
  Private m_mouseDown As Point
  <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="Member")> Private m_pieces(,) As State
  Private m_pieceCount As Integer
  Private m_showHints As Boolean

  Private WithEvents m_replayTimer As System.Windows.Forms.Timer

  Private m_history As HistoryCollection

  Public Enum State
    None
    Active
    Movable
    Selected
  End Enum

  Private Enum Direction
    None
    North
    NorthEast
    East
    SouthEast
    South
    SouthWest
    West
    NorthWest
  End Enum

  Public Structure RowColumn
    Private m_row As Integer
    Public Property Row() As Integer
      Get
        Return m_row
      End Get
      Set(ByVal value As Integer)
        m_row = value
      End Set
    End Property

    Private m_column As Integer
    Public Property Column() As Integer
      Get
        Return m_column
      End Get
      Set(ByVal value As Integer)
        m_column = value
      End Set
    End Property

    Public Sub New(ByVal row As Integer, ByVal column As Integer)
      Me.Row = row
      Me.Column = column
    End Sub

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
      If TypeOf obj Is RowColumn Then
        Dim r As RowColumn = CType(obj, RowColumn)
        If Me.Row = r.Row AndAlso Me.Column = r.Column Then
          Return True
        Else
          Return False
        End If
      Else
        Return False
      End If
    End Function
  End Structure

  Public ReadOnly Property History() As HistoryCollection
    Get
      Return m_history
    End Get
  End Property

  <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="Member")> Public ReadOnly Property Pieces() As State(,)
    Get
      Return m_pieces
    End Get
  End Property

  Public ReadOnly Property Count() As Integer
    Get
      Return m_pieceCount
    End Get
  End Property

  Public Property Columns() As Integer
    Get
      Return m_columns
    End Get
    Set(ByVal Value As Integer)
      m_columns = Value
      Reset()
      Me.Invalidate()
    End Set
  End Property

  Public Property Rows() As Integer
    Get
      Return m_rows
    End Get
    Set(ByVal Value As Integer)
      m_rows = Value
      Reset()
      Me.Invalidate()
    End Set
  End Property

  Public Property Depth() As Integer
    Get
      Return m_depth
    End Get
    Set(ByVal Value As Integer)
      m_depth = Value
      Reset()
      Me.Invalidate()
    End Set
  End Property

  Public Property ShowHints() As Boolean
    Get
      Return m_showHints
    End Get
    Set(ByVal Value As Boolean)
      m_showHints = Value
      SetColors()
      Me.Invalidate()
    End Set
  End Property

  Private m_cancelReplay As Boolean
  Private m_replayDelay As Integer = 1

  Public Sub CancelReplay()
    m_cancelReplay = True
  End Sub

  Public Property ReplayDelay() As Integer
    Get
      Return m_replayDelay
    End Get
    Set(ByVal Value As Integer)
      If Value > 0 AndAlso Value < 100 Then
        m_replayDelay = Value
      Else
        Throw New ArgumentException("Values specificed for ReplayDelay is out of range (valid between 1 and 99).")
      End If
    End Set
  End Property

  Public Sub Replay(ByVal history As HistoryCollection)
    Replay(history, True)
  End Sub

  Private m_replay As Boolean
  Private m_replayIndex As Integer
  Private m_replayHistory As HistoryCollection

  Public Sub Replay(ByVal history As HistoryCollection, ByVal wait As Boolean)

    m_replay = True
    m_replayIndex = 0
    m_replayHistory = history
    m_cancelReplay = Not wait
    Me.Reset()
    RaiseEvent ReplayBegin(Me, EventArgs.Empty)
    m_replayTimer = New System.Windows.Forms.Timer
    m_replayTimer.Interval = 1
    m_replayTimer.Enabled = True

    'm_replay = True
    'm_cancelReplay = Not wait

    'Me.Reset()

    'RaiseEvent ReplayBegin(Me, EventArgs.Empty)

    'For Each item As History In history
    '  MovePiece(item.Source, item.Destination, Not m_cancelReplay)
    '  Dim waitTill As Date = DateAdd(DateInterval.Second, m_replayDelay, Now)
    '  If Not m_cancelReplay Then
    '    Do Until Now > waitTill OrElse m_cancelReplay
    '      Application.DoEvents()
    '      'System.Threading.Thread.CurrentThread.Sleep(0)
    '    Loop
    '  Else
    '    'System.Threading.Thread.CurrentThread.Sleep(0)
    '    Application.DoEvents()
    '  End If
    'Next

    'RaiseEvent ReplayFinish(Me, EventArgs.Empty)

    'm_replay = False

  End Sub

  Private Sub MovePiece(ByVal source As RowColumn, ByVal destination As RowColumn, Optional ByVal animate As Boolean = True)

    'MsgBox("(" & (source.Row + 1).ToString & "," & (source.Column + 1).ToString & "->" & (destination.Row + 1).ToString & "," & (destination.Column + 1).ToString & ")")

    If m_pieces(source.Row, source.Column) <> State.None Then
      If m_pieces(destination.Row, destination.Column) = State.None Then
        Dim jumped As RowColumn = DetermineJumpedPiece(source, destination)
        If jumped.Row > -1 Then
          'If jumped.Row <> destination.Row OrElse jumped.Column <> destination.Column Then
          If m_pieces(jumped.Row, jumped.Column) <> State.None Then

            If animate Then
              ' take the source piece... animate it moving to the destination location.
              Dim sx As Integer = DisplayRectangle.Width \ m_columns
              Dim sy As Integer = DisplayRectangle.Height \ m_rows
              Dim x As Integer = source.Column * sx + (sx \ 2)
              Dim y As Integer = source.Row * sy + (sy \ 2)
              Dim dx As Integer = destination.Column * sx + (sx \ 2)
              Dim dy As Integer = destination.Row * sy + (sy \ 2)

              m_rowColumn = source
              m_pieces(source.Row, source.Column) = State.Selected

              Do

                If jumped.Column < source.Column Then
                  If x < dx Then
                    Exit Do
                  End If
                  x -= 5
                Else
                  If x > dx Then
                    Exit Do
                  End If
                  x += 5
                End If

                If jumped.Row < source.Row Then
                  If y < dy Then
                    Exit Do
                  End If
                  y -= 5
                Else
                  If y > dy Then
                    Exit Do
                  End If
                  y += 5
                End If

                m_mouseDown = New Point(x, y)

                Me.Invalidate()
                Application.DoEvents()
                Threading.Thread.Sleep(5)

              Loop

              m_mouseDown = Point.Empty

            End If

            m_pieces(source.Row, source.Column) = State.None
            m_pieces(jumped.Row, jumped.Column) = State.None
            m_pieces(destination.Row, destination.Column) = State.Active
            m_pieceCount -= 1
            m_history.Add(New History(source, destination))
            RaiseEvent PieceMoved(Me, New MoveEventArgs(source, destination))
          Else
            Stop
          End If
          'End If
        Else
          Throw New InvalidOperationException("Invalid move attempted: (" & (source.Row + 1).ToString & "," & (source.Column + 1).ToString & "->" & (destination.Row + 1).ToString & "," & (destination.Column + 1).ToString & ").")
        End If
      Else
        Throw New InvalidOperationException("Invalid move attempted: (" & (source.Row + 1).ToString & "," & (source.Column + 1).ToString & "->" & (destination.Row + 1).ToString & "," & (destination.Column + 1).ToString & ").")
      End If
    Else
      Stop
    End If
    Hint()
    Me.Invalidate()
    Application.DoEvents()

  End Sub

  Public Sub Undo()

    If m_history.Count > 0 Then
      ' Undo the last move.
      Dim source As RowColumn = m_history.Item(m_history.Count - 1).Source
      Dim destination As RowColumn = m_history.Item(m_history.Count - 1).Destination
      ' Remove the piece from the destination location.
      m_pieces(destination.Row, destination.Column) = State.None
      ' Place a piece at the source.
      m_pieces(source.Row, source.Column) = State.Active
      ' Figure out where to put the piece in the middle.
      m_rowColumn = source
      Dim jumped As RowColumn = DetermineJumpedPiece(destination)
      m_pieces(jumped.Row, jumped.Column) = State.Active
      ' Remove this history element.
      m_history.RemoveAt(m_history.Count - 1)
      m_pieceCount += 1
      Hint()
      Me.Invalidate()
    End If

  End Sub

  <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId:="Body")> Public Sub Reset()

    ' Reset the game pieces.

    ReDim m_pieces(m_rows, m_columns)

    Dim count As Integer

    ' Populate the first two and last two rows.
    For column As Integer = 0 To m_columns - 1
      For row As Integer = 0 To m_depth - 1
        m_pieces(row, column) = State.Active
        m_pieces(m_rows - row - 1, column) = State.Active
        count += 2
      Next
    Next

    ' Populate the first two and last two columns (minus the first two and last two rows).
    For row As Integer = 2 To m_rows - 3
      For column As Integer = 0 To m_depth - 1
        m_pieces(row, column) = State.Active
        m_pieces(row, m_columns - column - 1) = State.Active
        count += 2
      Next
    Next

    m_pieceCount = count

    Hint()

    SetColors()

    If m_history Is Nothing Then
      m_history = New HistoryCollection
    End If
    m_history.Clear()

    Me.Invalidate()

  End Sub

  Private Sub SetColors()

    Dim colorBright As Color = Color.FromArgb(0, 200, 0) 'Color.FromArgb(0, 175, 0)
    Dim colorNormal As Color
    If m_showHints Then
      colorNormal = Color.Silver 'Color.FromArgb(160, 225, 160)
    Else
      colorNormal = Color.FromArgb(0, 200, 0)
    End If
    Dim colorDisabled As Color = Me.BackColor 'Color.FromArgb(30, 70, 30)

    Dim hls As New HlsManager

    m_colorNormalCenter = hls.CenterColor(colorNormal)
    m_colorNormalSurround = hls.SurroundColors(colorNormal)
    m_colorNormalDark = hls.DarkColor(colorNormal)
    m_colorNormalLight = hls.LightColor(colorNormal)

    m_colorBrightCenter = hls.CenterColor(colorBright)
    m_colorBrightSurround = hls.SurroundColors(colorBright)
    m_colorBrightDark = hls.DarkColor(colorBright)
    m_colorBrightLight = hls.LightColor(colorBright)

    m_colorDisabledCenter = hls.CenterColor(colorDisabled)
    m_colorDisabledSurround = hls.SurroundColors(colorDisabled)
    m_colorDisabledDark = hls.DarkColor(colorDisabled)
    m_colorDisabledLight = hls.LightColor(colorDisabled)

  End Sub

  Private Sub Hint()

    RemoveHints()

    For row As Integer = 0 To m_rows - 1
      For column As Integer = 0 To m_columns - 1
        If m_pieces(row, column) = State.Active Then
          If row + 2 < m_rows Then
            If column - 2 > -1 Then
              ' Test SouthWest.
              If m_pieces(row + 2, column - 2) = State.None AndAlso (m_pieces(row + 1, column - 1) = State.Active OrElse m_pieces(row + 1, column - 1) = State.Movable) Then
                m_pieces(row, column) = State.Movable
              End If
            End If
            If column + 2 < m_columns Then
              ' Test SouthEast.
              If m_pieces(row + 2, column + 2) = State.None AndAlso (m_pieces(row + 1, column + 1) = State.Active OrElse m_pieces(row + 1, column + 1) = State.Movable) Then
                m_pieces(row, column) = State.Movable
              End If
            End If
          End If
          If row - 2 > -1 Then
            If column - 2 > -1 Then
              ' Test NorthWest.
              If m_pieces(row - 2, column - 2) = State.None AndAlso (m_pieces(row - 1, column - 1) = State.Active OrElse m_pieces(row - 1, column - 1) = State.Movable) Then
                m_pieces(row, column) = State.Movable
              End If
            End If
            If column + 2 < m_columns Then
              ' Test NorthEast.
              If m_pieces(row - 2, column + 2) = State.None AndAlso (m_pieces(row - 1, column + 1) = State.Active OrElse m_pieces(row - 1, column + 1) = State.Movable) Then
                m_pieces(row, column) = State.Movable
              End If
            End If
          End If
        End If
      Next
    Next

  End Sub

  Private Sub RemoveHints()
    For row As Integer = 0 To m_rows - 1
      For column As Integer = 0 To m_columns - 1
        If m_pieces(row, column) = State.Movable Then
          m_pieces(row, column) = State.Active
        End If
      Next
    Next
  End Sub

#Region "Events (Paint, Resize, Mouse Down/Move/Up"

  Private m_colorNormalCenter As Color
  Private m_colorNormalSurround As Color()
  Private m_colorNormalDark As Color
  Private m_colorNormalLight As Color

  Private m_colorBrightCenter As Color
  Private m_colorBrightSurround As Color()
  Private m_colorBrightDark As Color
  Private m_colorBrightLight As Color

  Private m_colorDisabledCenter As Color
  Private m_colorDisabledSurround As Color()
  Private m_colorDisabledDark As Color
  Private m_colorDisabledLight As Color

  Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    MyBase.OnPaint(e)

    Dim g As Graphics = e.Graphics
    'g.SmoothingMode = SmoothingMode.AntiAlias

    ' Calculate the size of the squares.
    Dim sx As Integer = DisplayRectangle.Width \ m_columns
    Dim sy As Integer = DisplayRectangle.Height \ m_rows
    ' Calculate the size of the pieces.
    Dim w As Integer = CInt(sx * 0.8)
    Dim h As Integer = CInt(sy * 0.8)
    ' Make the width and height equal to the smaller of the two.
    If w > h Then
      w = h
    ElseIf h > w Then
      h = w
    End If

    ' Draw the board.
    g.DrawRectangle(Pens.Black, 0, 0, DisplayRectangle.Width - 1, DisplayRectangle.Height - 1)
    For x As Integer = sx To Me.Width - sx Step sx
      g.DrawLine(Pens.Black, x, 0, x, DisplayRectangle.Height)
    Next
    For y As Integer = sy To Me.Height - sy Step sy
      g.DrawLine(Pens.Black, 0, y, DisplayRectangle.Width, y)
    Next

    ' Draw the active pices.
    For row As Integer = 0 To m_rows - 1
      For column As Integer = 0 To m_columns - 1
        ' For testing purposes, draw the row, column numbers.
        'g.DrawString(column.ToString & "," & row.ToString, Me.Font, Brushes.Black, column * sx, row * sy)
        If m_pieces(row, column) = State.Active OrElse m_pieces(row, column) = State.Movable Then
          ' Figure out where to start drawing the piece.
          Dim cx As Integer = ((column * sx) + (sx \ 2)) - (w \ 2)
          Dim cy As Integer = ((row * sy) + (sy \ 2)) - (h \ 2)
          ' Draw the piece.
          If m_showHints Then
            If m_pieces(row, column) = State.Active Then
              DrawPiece(g, cx, cy, w, 1)
              'g.FillEllipse(Brushes.Black, cx, cy, w, h)
            Else
              DrawPiece(g, cx, cy, w, 2)
              'g.FillEllipse(Brushes.Green, cx, cy, w, h)
              'g.DrawEllipse(Pens.Black, cx, cy, w, h)
            End If
          Else
            DrawPiece(g, cx, cy, w, 1)
            'g.FillEllipse(Brushes.Black, cx, cy, w, h)
          End If
        End If
      Next
    Next

    If Not m_mouseDown.Equals(Point.Empty) Then

      If m_mouseDown.X > -1 AndAlso m_mouseDown.Y > -1 AndAlso _
         m_mouseDown.X < DisplayRectangle.Width AndAlso m_mouseDown.Y < DisplayRectangle.Height Then

        Dim x As Integer = m_mouseDown.X - (w \ 2)
        Dim y As Integer = m_mouseDown.Y - (h \ 2)

        ' Test whether we can drop the piece in this location.
        'Dim c As Integer = m_mouseDown.X \ sx
        'Dim r As Integer = m_mouseDown.Y \ sy

        Dim valid As Boolean

        Dim drop As RowColumn = New RowColumn(m_mouseDown.Y \ sy, m_mouseDown.X \ sx)
        If drop.Row = m_rowColumn.Row AndAlso drop.Column = m_rowColumn.Column Then
          valid = True
        ElseIf m_pieces(drop.Row, drop.Column) = State.None Then
          Dim jumped As RowColumn = DetermineJumpedPiece(drop)
          If jumped.Row > -1 Then
            If jumped.Row <> drop.Row OrElse jumped.Column <> drop.Column Then
              If m_pieces(jumped.Row, jumped.Column) = State.Active OrElse m_pieces(jumped.Row, jumped.Column) = State.Movable Then
                valid = True
              End If
            End If
          End If
        End If

        If valid OrElse m_replay Then
          If m_showHints Then
            DrawPiece(g, x, y, w, 2)
          Else
            DrawPiece(g, x, y, w, 1)
          End If
        Else
          ' Invalid drop point.
          DrawPiece(g, x, y, w, 0)
        End If

      End If

    End If

  End Sub

  Private Sub DrawPiece(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal size As Integer, ByVal color As Integer)

    ' Create an instance of the HlsManager to handle color shifting.
    'Dim hls As New HlsManager

    ' Create the path to be used.
    Dim path As GraphicsPath = New GraphicsPath
    path.AddEllipse(x, y, size, size)

    ' Specify the rectangle area that will be used.
    Dim rect As New Rectangle(x, y, size, size)

    ' Figure out where the lighted center will be.
    Dim pt As New PointF(x + (size \ 7), y + (size \ 7) - 1)

    ' Create a path gradient brush for filling the area.
    Dim pthGrBrush As New PathGradientBrush(path)
    pthGrBrush.CenterPoint = pt

    ' Create the pen for drawing the border.
    Dim brush As LinearGradientBrush

    Select Case color
      Case 0
        pthGrBrush.CenterColor = m_colorDisabledCenter 'hls.CenterColor(color)
        pthGrBrush.SurroundColors = m_colorDisabledSurround 'hls.SurroundColors(color)
        'brush = New LinearGradientBrush(rect, hls.DarkColor(color), hls.LightColor(color), 35.0F)
        brush = New LinearGradientBrush(rect, m_colorDisabledDark, m_colorDisabledLight, 35.0F)
      Case 1
        pthGrBrush.CenterColor = m_colorNormalCenter
        pthGrBrush.SurroundColors = m_colorNormalSurround
        brush = New LinearGradientBrush(rect, m_colorNormalDark, m_colorNormalLight, 35.0F)
      Case 2
        pthGrBrush.CenterColor = m_colorBrightCenter
        pthGrBrush.SurroundColors = m_colorBrightSurround
        brush = New LinearGradientBrush(rect, m_colorBrightDark, m_colorBrightLight, 35.0F)
      Case Else
        brush = Nothing
    End Select

    If Not brush Is Nothing Then
      Dim nPen As New Pen(brush, 1)
      brush.Dispose()

      ' Draw the filled portion of the piece.
      g.SmoothingMode = SmoothingMode.HighSpeed
      g.FillPath(pthGrBrush, path)
      ' Draw the gradient border.
      g.SmoothingMode = SmoothingMode.AntiAlias
      g.DrawEllipse(nPen, x, y, size, size)
      g.SmoothingMode = SmoothingMode.Default

      ' Dispose brushes, pens and path.
      nPen.Dispose()

    End If

    pthGrBrush.Dispose()
    path.Dispose()

  End Sub

  Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
    MyBase.OnResize(e)
    Me.Invalidate()
  End Sub

  Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
    If m_replay Then
      Exit Sub
    End If
    ' Figure out what square we are in.
    Dim sx As Integer = DisplayRectangle.Width \ m_columns
    Dim sy As Integer = DisplayRectangle.Height \ m_rows
    Dim column As Integer = e.X \ sx
    Dim row As Integer = e.Y \ sy
    If m_pieces(row, column) = State.Movable Then
      m_mouseDown = New Point(e.X, e.Y)
      m_pieces(row, column) = State.Selected
      m_rowColumn = New RowColumn(row, column)
      Me.Invalidate()
    End If
  End Sub

  Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
    If m_replay Then
      Exit Sub
    End If
    If Not m_mouseDown.Equals(Point.Empty) Then
      m_mouseDown = New Point(e.X, e.Y)
      Me.Invalidate()
    End If
  End Sub

  Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
    If m_replay Then
      Exit Sub
    End If
    If m_pieces(m_rowColumn.Row, m_rowColumn.Column) = State.Selected Then
      Dim sx As Integer = DisplayRectangle.Width \ m_columns
      Dim sy As Integer = DisplayRectangle.Height \ m_rows
      Dim drop As RowColumn = New RowColumn(m_mouseDown.Y \ sy, m_mouseDown.X \ sx)
      If m_mouseDown.X > -1 AndAlso m_mouseDown.Y > -1 AndAlso _
         m_mouseDown.X < DisplayRectangle.Width AndAlso m_mouseDown.Y < DisplayRectangle.Height Then
        If m_pieces(drop.Row, drop.Column) = State.None Then
          Dim jumped As RowColumn = DetermineJumpedPiece(drop)
          If jumped.Row > -1 Then
            If jumped.Row <> drop.Row OrElse jumped.Column <> drop.Column Then
              If m_pieces(jumped.Row, jumped.Column) = State.Active OrElse m_pieces(jumped.Row, jumped.Column) = State.Movable Then
                m_pieces(m_rowColumn.Row, m_rowColumn.Column) = State.None
                m_pieces(jumped.Row, jumped.Column) = State.None
                m_pieces(drop.Row, drop.Column) = State.Active
                m_pieceCount -= 1
                m_history.Add(New History(m_rowColumn, drop))
                RaiseEvent PieceMoved(Me, New MoveEventArgs(m_rowColumn, drop))
              End If
            End If
          End If
        End If
      End If
      If m_pieces(m_rowColumn.Row, m_rowColumn.Column) = State.Selected Then
        m_pieces(m_rowColumn.Row, m_rowColumn.Column) = State.Active
      End If
    End If
    m_mouseDown = Point.Empty
    Me.Invalidate()
    Hint()
  End Sub

#End Region

#Region "Private Methods"

  Private Overloads Function DetermineDirection(ByVal source As RowColumn, ByVal destination As RowColumn) As Direction
    If destination.Row > -1 AndAlso destination.Row < m_rows AndAlso destination.Column > -1 AndAlso destination.Column < m_columns Then
      If destination.Row = source.Row - 2 Then
        If destination.Column = source.Column - 2 Then
          Return Direction.NorthWest
        ElseIf destination.Column = source.Column + 2 Then
          Return Direction.NorthEast
        ElseIf destination.Column = source.Column Then
          'Return Direction.North
        End If
      ElseIf destination.Row = source.Row Then
        If destination.Column = source.Column - 2 Then
          'Return Direction.West
        ElseIf destination.Column = source.Column + 2 Then
          'Return Direction.East
        End If
      ElseIf destination.Row = source.Row + 2 Then
        If destination.Column = source.Column - 2 Then
          Return Direction.SouthWest
        ElseIf destination.Column = source.Column + 2 Then
          Return Direction.SouthEast
        ElseIf destination.Column = source.Column Then
          'Return Direction.South
        End If
      End If
    End If
    Return Direction.None
  End Function

  Private Overloads Function DetermineDirection(ByVal row As Integer, ByVal column As Integer) As Direction
    If row > -1 AndAlso row < m_rows AndAlso column > -1 AndAlso column < m_columns Then
      If row = m_rowColumn.Row - 2 Then
        If column = m_rowColumn.Column - 2 Then
          Return Direction.NorthWest
        ElseIf column = m_rowColumn.Column + 2 Then
          Return Direction.NorthEast
        ElseIf column = m_rowColumn.Column Then
          'Return Direction.North
        End If
      ElseIf row = m_rowColumn.Row Then
        If column = m_rowColumn.Column - 2 Then
          'Return Direction.West
        ElseIf column = m_rowColumn.Column + 2 Then
          'Return Direction.East
        End If
      ElseIf row = m_rowColumn.Row + 2 Then
        If column = m_rowColumn.Column - 2 Then
          Return Direction.SouthWest
        ElseIf column = m_rowColumn.Column + 2 Then
          Return Direction.SouthEast
        ElseIf column = m_rowColumn.Column Then
          'Return Direction.South
        End If
      End If
    End If
    Return Direction.None
  End Function

  Private Overloads Function DetermineJumpedPiece(ByVal source As RowColumn, ByVal destination As RowColumn) As RowColumn

    Select Case DetermineDirection(source, destination)
      Case Direction.North
        Return New RowColumn(destination.Row + 1, destination.Column)
      Case Direction.NorthEast
        Return New RowColumn(destination.Row + 1, destination.Column - 1)
      Case Direction.East
        Return New RowColumn(destination.Row, destination.Column - 1)
      Case Direction.SouthEast
        Return New RowColumn(destination.Row - 1, destination.Column - 1)
      Case Direction.South
        Return New RowColumn(destination.Row - 1, destination.Column)
      Case Direction.SouthWest
        Return New RowColumn(destination.Row - 1, destination.Column + 1)
      Case Direction.West
        Return New RowColumn(destination.Row, destination.Column + 1)
      Case Direction.NorthWest
        Return New RowColumn(destination.Row + 1, destination.Column + 1)
      Case Else
        Return New RowColumn(-1, -1)
    End Select

  End Function

  Private Overloads Function DetermineJumpedPiece(ByVal rowColumn As RowColumn) As RowColumn

    Select Case DetermineDirection(rowColumn.Row, rowColumn.Column)
      Case Direction.North
        Return New RowColumn(rowColumn.Row + 1, rowColumn.Column)
      Case Direction.NorthEast
        Return New RowColumn(rowColumn.Row + 1, rowColumn.Column - 1)
      Case Direction.East
        Return New RowColumn(rowColumn.Row, rowColumn.Column - 1)
      Case Direction.SouthEast
        Return New RowColumn(rowColumn.Row - 1, rowColumn.Column - 1)
      Case Direction.South
        Return New RowColumn(rowColumn.Row - 1, rowColumn.Column)
      Case Direction.SouthWest
        Return New RowColumn(rowColumn.Row - 1, rowColumn.Column + 1)
      Case Direction.West
        Return New RowColumn(rowColumn.Row, rowColumn.Column + 1)
      Case Direction.NorthWest
        Return New RowColumn(rowColumn.Row + 1, rowColumn.Column + 1)
      Case Else
        Return New RowColumn(-1, -1)
    End Select

  End Function

#End Region

  Public Class MoveEventArgs
    Inherits EventArgs

    Private m_source As RowColumn
    Private m_destination As RowColumn

    Public Sub New(ByVal source As RowColumn, ByVal destination As RowColumn)
      m_source = source
      m_destination = destination
    End Sub

    Public ReadOnly Property Source() As RowColumn
      Get
        Return m_source
      End Get
    End Property

    Public ReadOnly Property Destination() As RowColumn
      Get
        Return m_destination
      End Get
    End Property

  End Class

  <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Mobility", "CA1601:DoNotUseTimersThatPreventPowerStateChanges")> Private Sub m_replayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_replayTimer.Tick

    m_replayTimer.Enabled = False

    If m_replayIndex < m_replayHistory.Count Then
      MovePiece(m_replayHistory.Item(m_replayIndex).Source, m_replayHistory.Item(m_replayIndex).Destination, Not m_cancelReplay)
      If Not m_cancelReplay Then
        m_replayTimer.Interval = m_replayDelay * 1000
      Else
        m_replayTimer.Interval = 1
      End If
      m_replayIndex += 1
      If m_replayIndex > m_replayHistory.Count - 1 Then
        ' done.
        RaiseEvent ReplayFinish(Me, EventArgs.Empty)
        m_replay = False
      Else
        m_replayTimer.Enabled = True
      End If
    End If

  End Sub

End Class

Public Class HistoryCollection
  Inherits CollectionBase

  Default Public Property Item(ByVal index As Integer) As History
    Get
      Return CType(List(index), History)
    End Get
    Set(ByVal Value As History)
      List(index) = Value
    End Set
  End Property

  Public Function Add(ByVal value As History) As Integer
    Return List.Add(value)
  End Function

  Public Function IndexOf(ByVal value As History) As Integer
    Return List.IndexOf(value)
  End Function

  Public Sub Insert(ByVal index As Integer, ByVal value As History)
    List.Insert(index, value)
  End Sub

  Public Sub Remove(ByVal value As History)
    List.Remove(value)
  End Sub

  Public Function Contains(ByVal value As History) As Boolean
    Return List.Contains(value)
  End Function

  'Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As [Object])
  '  If Not value.GetType() Is Type.GetType("System.Int16") Then
  '    Throw New ArgumentException("value must be of type Int16.", "value")
  '  End If
  'End Sub

  'Protected Overrides Sub OnRemove(ByVal index As Integer, ByVal value As [Object])
  '  If Not value.GetType() Is Type.GetType("System.Int16") Then
  '    Throw New ArgumentException("value must be of type Int16.", "value")
  '  End If
  'End Sub

  'Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As [Object], ByVal newValue As [Object])
  '  If Not newValue.GetType() Is Type.GetType("System.Int16") Then
  '    Throw New ArgumentException("newValue must be of type Int16.", "newValue")
  '  End If
  'End Sub

  'Protected Overrides Sub OnValidate(ByVal value As [Object])
  '  If Not value.GetType() Is Type.GetType("System.Int16") Then
  '    Throw New ArgumentException("value must be of type Int16.")
  '  End If
  'End Sub

End Class

Public Class History

  Private m_source As Board.RowColumn
  Private m_destination As Board.RowColumn

  Public Sub New(ByVal source As Board.RowColumn, ByVal destination As Board.RowColumn)
    m_source = source
    m_destination = destination
  End Sub

  Public ReadOnly Property Source() As Board.RowColumn
    Get
      Return m_source
    End Get
  End Property

  Public ReadOnly Property Destination() As Board.RowColumn
    Get
      Return m_destination
    End Get
  End Property

End Class
