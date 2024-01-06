Public Class HistoryDialog

  Public Property Rows() As Integer
  Public Property Columns() As Integer
  Public Property Depth() As Integer

  Private Sub HistoryListView_KeyUp(sender As Object, e As KeyEventArgs) Handles HistoryListView.KeyUp
    If e.Control AndAlso e.KeyCode = Keys.C Then
      Dim tag = $"""Checkers Solitaire"",""{Application.ProductVersion}"",""{Rows}"",""{Columns}"",""{Depth}""{vbCrLf}"
      Dim csv = $"{tag}""Move #"",""Start Row"",""Start Column"",""Destination Row"",""Destination Column""{vbCrLf}"
      For Each item As ListViewItem In HistoryListView.Items
        csv &= $"{item.SubItems(0).Text},{item.SubItems(1).Text},{item.SubItems(2).Text},{item.SubItems(4).Text},{item.SubItems(5).Text}{vbCrLf}"
      Next
      Clipboard.SetDataObject(csv, True)
    ElseIf e.Control AndAlso e.KeyCode = Keys.A Then
      For Each item As ListViewItem In HistoryListView.Items
        item.Selected = True
      Next
    End If
  End Sub

  Private Sub ViewHistory_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
    If HistoryListView.CanFocus Then
      HistoryListView.Focus()
    End If
  End Sub

  Private Sub ViewHistory_GotFocus(sender As Object, e As EventArgs) Handles MyBase.GotFocus
    HistoryListView.Focus()
  End Sub

End Class