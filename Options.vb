Public Class Options
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
  Friend WithEvents AcceptActionButton As System.Windows.Forms.Button
  Friend WithEvents CancelActionButton As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents PiecesComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents BoardGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents RowsComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents ColumnsComboBox As System.Windows.Forms.ComboBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.AcceptActionButton = New System.Windows.Forms.Button
    Me.CancelActionButton = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.RowsComboBox = New System.Windows.Forms.ComboBox
    Me.ColumnsComboBox = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.PiecesComboBox = New System.Windows.Forms.ComboBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.BoardGroupBox = New System.Windows.Forms.GroupBox
    Me.BoardGroupBox.SuspendLayout()
    Me.SuspendLayout()
    '
    'AcceptActionButton
    '
    Me.AcceptActionButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.AcceptActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.AcceptActionButton.Location = New System.Drawing.Point(24, 136)
    Me.AcceptActionButton.Name = "AcceptActionButton"
    Me.AcceptActionButton.TabIndex = 1
    Me.AcceptActionButton.Text = "&OK"
    '
    'CancelActionButton
    '
    Me.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.CancelActionButton.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.CancelActionButton.Location = New System.Drawing.Point(112, 136)
    Me.CancelActionButton.Name = "CancelActionButton"
    Me.CancelActionButton.TabIndex = 2
    Me.CancelActionButton.Text = "&Cancel"
    '
    'Label1
    '
    Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label1.Location = New System.Drawing.Point(8, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Number of rows:"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'RowsComboBox
    '
    Me.RowsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.RowsComboBox.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "20", "22", "24", "26", "28", "30"})
    Me.RowsComboBox.Location = New System.Drawing.Point(120, 24)
    Me.RowsComboBox.Name = "RowsComboBox"
    Me.RowsComboBox.Size = New System.Drawing.Size(56, 21)
    Me.RowsComboBox.TabIndex = 1
    '
    'ColumnsComboBox
    '
    Me.ColumnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ColumnsComboBox.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "20", "22", "24", "26", "28", "30"})
    Me.ColumnsComboBox.Location = New System.Drawing.Point(120, 56)
    Me.ColumnsComboBox.Name = "ColumnsComboBox"
    Me.ColumnsComboBox.Size = New System.Drawing.Size(56, 21)
    Me.ColumnsComboBox.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label2.Location = New System.Drawing.Point(8, 56)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(112, 23)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Number of columns:"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'PiecesComboBox
    '
    Me.PiecesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.PiecesComboBox.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10"})
    Me.PiecesComboBox.Location = New System.Drawing.Point(120, 88)
    Me.PiecesComboBox.Name = "PiecesComboBox"
    Me.PiecesComboBox.Size = New System.Drawing.Size(56, 21)
    Me.PiecesComboBox.TabIndex = 5
    '
    'Label3
    '
    Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Label3.Location = New System.Drawing.Point(8, 88)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(112, 23)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Piece depth:"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'BoardGroupBox
    '
    Me.BoardGroupBox.Controls.Add(Me.Label2)
    Me.BoardGroupBox.Controls.Add(Me.RowsComboBox)
    Me.BoardGroupBox.Controls.Add(Me.Label1)
    Me.BoardGroupBox.Controls.Add(Me.PiecesComboBox)
    Me.BoardGroupBox.Controls.Add(Me.Label3)
    Me.BoardGroupBox.Controls.Add(Me.ColumnsComboBox)
    Me.BoardGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.BoardGroupBox.Location = New System.Drawing.Point(8, 8)
    Me.BoardGroupBox.Name = "BoardGroupBox"
    Me.BoardGroupBox.Size = New System.Drawing.Size(192, 120)
    Me.BoardGroupBox.TabIndex = 0
    Me.BoardGroupBox.TabStop = False
    Me.BoardGroupBox.Text = "Board Settings"
    '
    'Options
    '
    Me.AcceptButton = Me.AcceptActionButton
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.CancelButton = Me.CancelActionButton
    Me.ClientSize = New System.Drawing.Size(210, 168)
    Me.Controls.Add(Me.BoardGroupBox)
    Me.Controls.Add(Me.CancelActionButton)
    Me.Controls.Add(Me.AcceptActionButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Options"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Options"
    Me.BoardGroupBox.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Public Sub New(ByVal rows As Integer, ByVal columns As Integer, ByVal depth As Integer)
    Me.New()
    Me.Rows = rows
    Me.Columns = columns
    Me.Depth = depth
  End Sub

  Public Property Rows() As Integer
    Get
      Return CInt(RowsComboBox.SelectedItem)
    End Get
    Set(ByVal Value As Integer)
      For index As Integer = 0 To RowsComboBox.Items.Count - 1
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
    Set(ByVal Value As Integer)
      For index As Integer = 0 To ColumnsComboBox.Items.Count - 1
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
    Set(ByVal Value As Integer)
      For index As Integer = 0 To PiecesComboBox.Items.Count - 1
        If CInt(PiecesComboBox.Items(index)) = Value Then
          PiecesComboBox.SelectedIndex = index
          Exit For
        End If
      Next
    End Set
  End Property

End Class
