Option Explicit On
Option Strict On
Option Infer On

Imports System.Drawing.Drawing2D

Public Class Board
  Inherits UserControl

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
  Public Event PieceMoved As EventHandler(Of MoveEventArgs)

  Private m_columns As Integer = 8
  Private m_rows As Integer = 8
  Private m_depth As Integer = 2
  Private m_rowColumn As RowColumn
  Private m_mouseDown As Point
  Private m_pieces(,) As State
  Private m_pieceCount As Integer
  Private m_showHints As Boolean

  Private WithEvents ReplayTimer As Timer

  Private m_history As List(Of History)

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

    Public Property Row() As Integer
    Public Property Column() As Integer

    Public Sub New(row As Integer, column As Integer)
      Me.Row = row
      Me.Column = column
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
      If TypeOf obj Is RowColumn Then
        Dim r = CType(obj, RowColumn)
        Return Row = r.Row AndAlso Column = r.Column
      Else
        Return False
      End If
    End Function

    Public Shared Operator =(left As RowColumn, right As RowColumn) As Boolean
      Return left.Equals(right)
    End Operator

    Public Shared Operator <>(left As RowColumn, right As RowColumn) As Boolean
      Return Not left = right
    End Operator

    Public Overrides Function GetHashCode() As Integer
      Throw New NotImplementedException()
    End Function

  End Structure

  Public ReadOnly Property History() As List(Of History)
    Get
      Return m_history
    End Get
  End Property

  Public ReadOnly Property Pieces() As State(,)
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
    Set(Value As Integer)
      m_columns = Value
      Reset()
      Invalidate()
    End Set
  End Property

  Public Property Rows() As Integer
    Get
      Return m_rows
    End Get
    Set(Value As Integer)
      m_rows = Value
      Reset()
      Invalidate()
    End Set
  End Property

  Public Property Depth() As Integer
    Get
      Return m_depth
    End Get
    Set(Value As Integer)
      m_depth = Value
      Reset()
      Invalidate()
    End Set
  End Property

  Public Property ShowHints() As Boolean
    Get
      Return m_showHints
    End Get
    Set(Value As Boolean)
      m_showHints = Value
      SetColors()
      Invalidate()
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
    Set(Value As Integer)
      If Value > 0 AndAlso Value < 100 Then
        m_replayDelay = Value
      Else
        Throw New ArgumentException("Values specificed for ReplayDelay is out of range (valid between 1 and 99).")
      End If
    End Set
  End Property

  Public Sub Replay(history As List(Of History))
    Replay(history, True)
  End Sub

  Private m_replay As Boolean
  Private m_replayIndex As Integer
  Private m_replayHistory As List(Of History)

  Public Sub Replay(history As List(Of History), wait As Boolean)

    m_replay = True
    m_replayIndex = 0
    m_replayHistory = history
    m_cancelReplay = Not wait
    Reset()
    RaiseEvent ReplayBegin(Me, EventArgs.Empty)
    ReplayTimer = New Timer With {.Interval = 1, .Enabled = True}

  End Sub

  Private Async Function MovePiece(source As RowColumn, destination As RowColumn, Optional animate As Boolean = True) As Task

    If m_pieces(source.Row, source.Column) <> State.None Then
      If m_pieces(destination.Row, destination.Column) = State.None Then

        Dim jumped = DetermineJumpedPiece(source, destination)

        If jumped.Row > -1 Then

          If m_pieces(jumped.Row, jumped.Column) <> State.None Then

            If animate Then

              ' take the source piece... animate it moving to the destination location.
              Dim sx = DisplayRectangle.Width \ m_columns
              Dim sy = DisplayRectangle.Height \ m_rows
              Dim x = source.Column * sx + (sx \ 2)
              Dim y = source.Row * sy + (sy \ 2)
              Dim dx = destination.Column * sx + (sx \ 2)
              Dim dy = destination.Row * sy + (sy \ 2)

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

                Invalidate()
                Await Task.Delay(5)

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
    Invalidate()

  End Function

  Public Sub Undo()

    If m_history.Count > 0 Then
      ' Undo the last move.
      Dim source = m_history.Item(m_history.Count - 1).Source
      Dim destination = m_history.Item(m_history.Count - 1).Destination
      ' Remove the piece from the destination location.
      m_pieces(destination.Row, destination.Column) = State.None
      ' Place a piece at the source.
      m_pieces(source.Row, source.Column) = State.Active
      ' Figure out where to put the piece in the middle.
      m_rowColumn = source
      Dim jumped = DetermineJumpedPiece(destination)
      m_pieces(jumped.Row, jumped.Column) = State.Active
      ' Remove this history element.
      m_history.RemoveAt(m_history.Count - 1)
      m_pieceCount += 1
      Hint()
      Invalidate()
    End If

  End Sub

  Public Sub Reset()

    ' Reset the game pieces.

    ReDim m_pieces(m_rows, m_columns)

    Dim count = 0

    ' Populate the first two and last two rows.
    For column = 0 To m_columns - 1
      For row = 0 To m_depth - 1
        m_pieces(row, column) = State.Active
        m_pieces(m_rows - row - 1, column) = State.Active
        count += 2
      Next
    Next

    ' Populate the first two and last two columns (minus the first two and last two rows).
    For row = 2 To m_rows - 3
      For column = 0 To m_depth - 1
        m_pieces(row, column) = State.Active
        m_pieces(row, m_columns - column - 1) = State.Active
        count += 2
      Next
    Next

    m_pieceCount = count

    Hint()

    SetColors()

    If m_history Is Nothing Then
      m_history = New List(Of History)
    End If
    m_history.Clear()

    Invalidate()

  End Sub

  Private Sub SetColors()

    Dim colorBright = Color.FromArgb(0, 200, 0)
    Dim colorNormal = If(m_showHints, Color.Silver, Color.FromArgb(0, 200, 0))
    Dim colorDisabled = BackColor

    m_colorNormalCenter = HlsManager.CenterColor(colorNormal)
    m_colorNormalSurround = HlsManager.SurroundColors(colorNormal)
    m_colorNormalDark = HlsManager.DarkColor(colorNormal)
    m_colorNormalLight = HlsManager.LightColor(colorNormal)

    m_colorBrightCenter = HlsManager.CenterColor(colorBright)
    m_colorBrightSurround = HlsManager.SurroundColors(colorBright)
    m_colorBrightDark = HlsManager.DarkColor(colorBright)
    m_colorBrightLight = HlsManager.LightColor(colorBright)

    m_colorDisabledCenter = HlsManager.CenterColor(colorDisabled)
    m_colorDisabledSurround = HlsManager.SurroundColors(colorDisabled)
    m_colorDisabledDark = HlsManager.DarkColor(colorDisabled)
    m_colorDisabledLight = HlsManager.LightColor(colorDisabled)

  End Sub

  Private Sub Hint()

    RemoveHints()

    For row = 0 To m_rows - 1
      For column = 0 To m_columns - 1
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
    For row = 0 To m_rows - 1
      For column = 0 To m_columns - 1
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

  Protected Overrides Sub OnPaint(e As PaintEventArgs)
    MyBase.OnPaint(e)

    'e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

    ' Calculate the size of the squares.
    Dim sx = DisplayRectangle.Width \ m_columns
    Dim sy = DisplayRectangle.Height \ m_rows
    ' Calculate the size of the pieces.
    Dim w = CInt(sx * 0.8)
    Dim h = CInt(sy * 0.8)
    ' Make the width and height equal to the smaller of the two.
    If w > h Then
      w = h
    ElseIf h > w Then
      h = w
    End If

    ' Draw the board.
    e.Graphics.DrawRectangle(Pens.Black, 0, 0, DisplayRectangle.Width - 1, DisplayRectangle.Height - 1)
    For x = sx To Me.Width - sx Step sx
      e.Graphics.DrawLine(Pens.Black, x, 0, x, DisplayRectangle.Height)
    Next
    For y = sy To Me.Height - sy Step sy
      e.Graphics.DrawLine(Pens.Black, 0, y, DisplayRectangle.Width, y)
    Next

    ' Draw the active pices.
    For row = 0 To m_rows - 1
      For column = 0 To m_columns - 1
        ' For testing purposes, draw the row, column numbers.
        'g.DrawString(column.ToString & "," & row.ToString, Me.Font, Brushes.Black, column * sx, row * sy)
        If m_pieces(row, column) = State.Active OrElse m_pieces(row, column) = State.Movable Then
          ' Figure out where to start drawing the piece.
          Dim cx = ((column * sx) + (sx \ 2)) - (w \ 2)
          Dim cy = ((row * sy) + (sy \ 2)) - (h \ 2)
          ' Draw the piece.
          If m_showHints Then
            If m_pieces(row, column) = State.Active Then
              DrawPiece(e.Graphics, cx, cy, w, 1)
            Else
              DrawPiece(e.Graphics, cx, cy, w, 2)
            End If
          Else
            DrawPiece(e.Graphics, cx, cy, w, 1)
          End If
        End If
      Next
    Next

    If Not m_mouseDown.Equals(Point.Empty) Then

      If m_mouseDown.X > -1 AndAlso
       m_mouseDown.Y > -1 AndAlso
       m_mouseDown.X < DisplayRectangle.Width AndAlso
       m_mouseDown.Y < DisplayRectangle.Height Then

        Dim x = m_mouseDown.X - (w \ 2)
        Dim y = m_mouseDown.Y - (h \ 2)

        Dim valid As Boolean

        Dim drop = New RowColumn(m_mouseDown.Y \ sy, m_mouseDown.X \ sx)
        If drop.Row = m_rowColumn.Row AndAlso drop.Column = m_rowColumn.Column Then
          valid = True
        ElseIf m_pieces(drop.Row, drop.Column) = State.None Then
          Dim jumped = DetermineJumpedPiece(drop)
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
            DrawPiece(e.Graphics, x, y, w, 2)
          Else
            DrawPiece(e.Graphics, x, y, w, 1)
          End If
        Else
          ' Invalid drop point.
          DrawPiece(e.Graphics, x, y, w, 0)
        End If

      End If

    End If

  End Sub

  Private Sub DrawPiece(g As Graphics, x As Integer, y As Integer, size As Integer, color As Integer)

    ' Create the path to be used.
    Using path = New GraphicsPath

      path.AddEllipse(x, y, size, size)

      ' Figure out where the lighted center will be.
      Dim pt = New PointF(x + (size \ 7), y + (size \ 7) - 1)

      ' Create a path gradient brush for filling the area.
      Using pthGrBrush = New PathGradientBrush(path) With {.CenterPoint = pt}

        ' Create the pen for drawing the border.
        Dim brush As LinearGradientBrush = Nothing

        Try

          ' Specify the rectangle area that will be used.
          Dim rect = New Rectangle(x, y, size, size)

          Select Case color
            Case 0
              pthGrBrush.CenterColor = m_colorDisabledCenter
              pthGrBrush.SurroundColors = m_colorDisabledSurround
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
              Return
          End Select

          Using nPen As New Pen(brush, 1)

            ' Draw the filled portion of the piece.
            g.SmoothingMode = SmoothingMode.HighSpeed
            g.FillPath(pthGrBrush, path)
            ' Draw the gradient border.
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.DrawEllipse(nPen, x, y, size, size)
            g.SmoothingMode = SmoothingMode.Default

          End Using

        Finally
          If brush IsNot Nothing Then brush.Dispose()
        End Try

      End Using

    End Using

  End Sub

  Protected Overrides Sub OnResize(e As EventArgs)
    MyBase.OnResize(e)
    Invalidate()
  End Sub

  Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
    If m_replay Then Exit Sub
    ' Figure out what square we are in.
    Dim sx = DisplayRectangle.Width \ m_columns
    Dim sy = DisplayRectangle.Height \ m_rows
    Dim column = e.X \ sx
    Dim row = e.Y \ sy
    If m_pieces(row, column) = State.Movable Then
      m_mouseDown = New Point(e.X, e.Y)
      m_pieces(row, column) = State.Selected
      m_rowColumn = New RowColumn(row, column)
      Invalidate()
    End If
  End Sub

  Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
    If m_replay Then Exit Sub
    If Not m_mouseDown.Equals(Point.Empty) Then
      m_mouseDown = New Point(e.X, e.Y)
      Invalidate()
    End If
  End Sub

  Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
    If m_replay Then
      Exit Sub
    End If
    If m_pieces(m_rowColumn.Row, m_rowColumn.Column) = State.Selected Then
      Dim sx = DisplayRectangle.Width \ m_columns
      Dim sy = DisplayRectangle.Height \ m_rows
      Dim drop = New RowColumn(m_mouseDown.Y \ sy, m_mouseDown.X \ sx)
      If m_mouseDown.X > -1 AndAlso m_mouseDown.Y > -1 AndAlso
         m_mouseDown.X < DisplayRectangle.Width AndAlso m_mouseDown.Y < DisplayRectangle.Height Then
        If m_pieces(drop.Row, drop.Column) = State.None Then
          Dim jumped = DetermineJumpedPiece(drop)
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
    Invalidate()
    Hint()
  End Sub

#End Region

#Region "Private Methods"

  Private Overloads Function DetermineDirection(source As RowColumn, destination As RowColumn) As Direction
    If destination.Row > -1 AndAlso destination.Row < m_rows AndAlso destination.Column > -1 AndAlso destination.Column < m_columns Then
      If destination.Row = source.Row - 2 Then
        If destination.Column = source.Column - 2 Then
          Return Direction.NorthWest
        ElseIf destination.Column = source.Column + 2 Then
          Return Direction.NorthEast
        ElseIf destination.Column = source.Column Then
        End If
      ElseIf destination.Row = source.Row Then
        If destination.Column = source.Column - 2 Then
        ElseIf destination.Column = source.Column + 2 Then
        End If
      ElseIf destination.Row = source.Row + 2 Then
        If destination.Column = source.Column - 2 Then
          Return Direction.SouthWest
        ElseIf destination.Column = source.Column + 2 Then
          Return Direction.SouthEast
        ElseIf destination.Column = source.Column Then
        End If
      End If
    End If
    Return Direction.None
  End Function

  Private Overloads Function DetermineDirection(row As Integer, column As Integer) As Direction
    If row > -1 AndAlso row < m_rows AndAlso column > -1 AndAlso column < m_columns Then
      If row = m_rowColumn.Row - 2 Then
        If column = m_rowColumn.Column - 2 Then
          Return Direction.NorthWest
        ElseIf column = m_rowColumn.Column + 2 Then
          Return Direction.NorthEast
        ElseIf column = m_rowColumn.Column Then
        End If
      ElseIf row = m_rowColumn.Row Then
        If column = m_rowColumn.Column - 2 Then
        ElseIf column = m_rowColumn.Column + 2 Then
        End If
      ElseIf row = m_rowColumn.Row + 2 Then
        If column = m_rowColumn.Column - 2 Then
          Return Direction.SouthWest
        ElseIf column = m_rowColumn.Column + 2 Then
          Return Direction.SouthEast
        ElseIf column = m_rowColumn.Column Then
        End If
      End If
    End If
    Return Direction.None
  End Function

  Private Overloads Function DetermineJumpedPiece(source As RowColumn, destination As RowColumn) As RowColumn

    Select Case DetermineDirection(source, destination)
      Case Direction.North : Return New RowColumn(destination.Row + 1, destination.Column)
      Case Direction.NorthEast : Return New RowColumn(destination.Row + 1, destination.Column - 1)
      Case Direction.East : Return New RowColumn(destination.Row, destination.Column - 1)
      Case Direction.SouthEast : Return New RowColumn(destination.Row - 1, destination.Column - 1)
      Case Direction.South : Return New RowColumn(destination.Row - 1, destination.Column)
      Case Direction.SouthWest : Return New RowColumn(destination.Row - 1, destination.Column + 1)
      Case Direction.West : Return New RowColumn(destination.Row, destination.Column + 1)
      Case Direction.NorthWest : Return New RowColumn(destination.Row + 1, destination.Column + 1)
      Case Else
        Return New RowColumn(-1, -1)
    End Select

  End Function

  Private Overloads Function DetermineJumpedPiece(rowColumn As RowColumn) As RowColumn

    Select Case DetermineDirection(rowColumn.Row, rowColumn.Column)
      Case Direction.North : Return New RowColumn(rowColumn.Row + 1, rowColumn.Column)
      Case Direction.NorthEast : Return New RowColumn(rowColumn.Row + 1, rowColumn.Column - 1)
      Case Direction.East : Return New RowColumn(rowColumn.Row, rowColumn.Column - 1)
      Case Direction.SouthEast : Return New RowColumn(rowColumn.Row - 1, rowColumn.Column - 1)
      Case Direction.South : Return New RowColumn(rowColumn.Row - 1, rowColumn.Column)
      Case Direction.SouthWest : Return New RowColumn(rowColumn.Row - 1, rowColumn.Column + 1)
      Case Direction.West : Return New RowColumn(rowColumn.Row, rowColumn.Column + 1)
      Case Direction.NorthWest : Return New RowColumn(rowColumn.Row + 1, rowColumn.Column + 1)
      Case Else
        Return New RowColumn(-1, -1)
    End Select

  End Function

#End Region

  Public Class MoveEventArgs
    Inherits EventArgs

    Public Sub New(source As RowColumn, destination As RowColumn)
      Me.Source = source
      Me.Destination = destination
    End Sub

    Public ReadOnly Property Source() As RowColumn
    Public ReadOnly Property Destination() As RowColumn

  End Class

  Private Async Sub ReplayTimer_Tick(sender As Object, e As EventArgs) Handles ReplayTimer.Tick

    ReplayTimer.Enabled = False

    If m_replayIndex < m_replayHistory.Count Then
      Await MovePiece(m_replayHistory.Item(m_replayIndex).Source, m_replayHistory.Item(m_replayIndex).Destination, Not m_cancelReplay)
      ReplayTimer.Interval = If(Not m_cancelReplay, m_replayDelay * 1000, 1)
      m_replayIndex += 1
      If m_replayIndex > m_replayHistory.Count - 1 Then
        ' done.
        RaiseEvent ReplayFinish(Me, EventArgs.Empty)
        m_replay = False
      Else
        ReplayTimer.Enabled = True
      End If
    End If

  End Sub

End Class

Public Class History

  Public Sub New(source As Board.RowColumn, destination As Board.RowColumn)
    Me.Source = source
    Me.Destination = destination
  End Sub

  Public ReadOnly Property Source() As Board.RowColumn
  Public ReadOnly Property Destination() As Board.RowColumn

End Class