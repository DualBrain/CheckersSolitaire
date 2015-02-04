Public Class ViewHistory
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
  Friend WithEvents CloseActionButton As System.Windows.Forms.Button
  Friend WithEvents HistoryListView As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ViewHistory))
    Me.CloseActionButton = New System.Windows.Forms.Button
    Me.HistoryListView = New System.Windows.Forms.ListView
    Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
    Me.SuspendLayout()
    '
    'CloseActionButton
    '
    Me.CloseActionButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.CloseActionButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.CloseActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.CloseActionButton.Location = New System.Drawing.Point(208, 232)
    Me.CloseActionButton.Name = "CloseActionButton"
    Me.CloseActionButton.TabIndex = 0
    Me.CloseActionButton.Text = "&Close"
    '
    'HistoryListView
    '
    Me.HistoryListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.HistoryListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
    Me.HistoryListView.FullRowSelect = True
    Me.HistoryListView.HideSelection = False
    Me.HistoryListView.Location = New System.Drawing.Point(8, 8)
    Me.HistoryListView.Name = "HistoryListView"
    Me.HistoryListView.Size = New System.Drawing.Size(272, 216)
    Me.HistoryListView.TabIndex = 1
    Me.HistoryListView.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "#"
    Me.ColumnHeader1.Width = 39
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Row"
    Me.ColumnHeader2.Width = 43
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = "Col"
    Me.ColumnHeader3.Width = 38
    '
    'ColumnHeader4
    '
    Me.ColumnHeader4.Text = ""
    Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    Me.ColumnHeader4.Width = 55
    '
    'ColumnHeader5
    '
    Me.ColumnHeader5.Text = "Row"
    Me.ColumnHeader5.Width = 41
    '
    'ColumnHeader6
    '
    Me.ColumnHeader6.Text = "Col"
    Me.ColumnHeader6.Width = 35
    '
    'ViewHistory
    '
    Me.AcceptButton = Me.CloseActionButton
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Controls.Add(Me.HistoryListView)
    Me.Controls.Add(Me.CloseActionButton)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "ViewHistory"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "History"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_rows As Integer
  Private m_columns As Integer
  Private m_depth As Integer

  Public Property Rows() As Integer
    Get
      Return m_rows
    End Get
    Set(ByVal Value As Integer)
      m_rows = Value
    End Set
  End Property

  Public Property Columns() As Integer
    Get
      Return m_columns
    End Get
    Set(ByVal Value As Integer)
      m_columns = Value
    End Set
  End Property

  Public Property Depth() As Integer
    Get
      Return m_depth
    End Get
    Set(ByVal Value As Integer)
      m_depth = Value
    End Set
  End Property

  Private Sub HistoryListView_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles HistoryListView.KeyUp
    If e.Control AndAlso e.KeyCode = Keys.C Then
      Dim tag As String = """Checkers Solitaire"",""" & Application.ProductVersion & """,""" & CStr(m_rows) & """,""" & CStr(m_columns) & """,""" & CStr(m_depth) & """" & vbCrLf
      Dim csv As String = tag & """Move #"",""Start Row"",""Start Column"",""Destination Row"",""Destination Column""" & vbCrLf
      For Each item As ListViewItem In HistoryListView.Items
        csv &= item.SubItems(0).Text & "," & item.SubItems(1).Text & "," & item.SubItems(2).Text & "," & item.SubItems(4).Text & "," & item.SubItems(5).Text & vbCrLf
      Next
      Clipboard.SetDataObject(csv, True)
    ElseIf e.Control AndAlso e.KeyCode = Keys.A Then
      For Each item As ListViewItem In HistoryListView.Items
        item.Selected = True
      Next
    End If
  End Sub

  Private Sub ViewHistory_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    If HistoryListView.CanFocus Then
      HistoryListView.Focus()
    End If
  End Sub

  Private Sub ViewHistory_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    HistoryListView.Focus()
  End Sub

End Class
