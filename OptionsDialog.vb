Public Class OptionsDialog

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub

  Public Sub New(rows As Integer, columns As Integer, depth As Integer)
    Me.New()
    Me.Rows = rows
    Me.Columns = columns
    Me.Depth = depth
  End Sub

  Public Property Rows() As Integer
    Get
      Return CInt(RowsComboBox.SelectedItem)
    End Get
    Set(Value As Integer)
      For index = 0 To RowsComboBox.Items.Count - 1
        If CInt(RowsComboBox.Items(index)) = Value Then
          RowsComboBox.SelectedIndex = index
          Exit For
        End If
      Next
    End Set
  End Property

  Public Property Columns() As Integer
    Get
      Return CInt(ColumnsComboBox.SelectedItem)
    End Get
    Set(Value As Integer)
      For index = 0 To ColumnsComboBox.Items.Count - 1
        If CInt(ColumnsComboBox.Items(index)) = Value Then
          ColumnsComboBox.SelectedIndex = index
          Exit For
        End If
      Next
    End Set
  End Property

  Public Property Depth() As Integer
    Get
      Return CInt(PiecesComboBox.SelectedItem)
    End Get
    Set(Value As Integer)
      For index = 0 To PiecesComboBox.Items.Count - 1
        If CInt(PiecesComboBox.Items(index)) = Value Then
          PiecesComboBox.SelectedIndex = index
          Exit For
        End If
      Next
    End Set
  End Property

End Class