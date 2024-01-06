Public Class GameHistory

  Public Sub New(source As GameBoard.RowColumn, destination As GameBoard.RowColumn)
    Me.Source = source
    Me.Destination = destination
  End Sub

  Public ReadOnly Property Source() As GameBoard.RowColumn
  Public ReadOnly Property Destination() As GameBoard.RowColumn

End Class