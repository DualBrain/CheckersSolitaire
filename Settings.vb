Option Explicit On 
Option Strict On

Imports System.Environment
Imports System.IO
Imports System.IO.IsolatedStorage

Public Enum Scoring
  None
  Standard
  Vegas
  VegasCumulative
End Enum

Public Class Settings

  Private Const DefaultFileName As String = "settings.xml"
  Private Const DefaultUseIsolatedStorage As Boolean = False

  Private m_position As Point ' Location of the main window.
  Private m_size As Size ' Size of the main window.

  Private m_hints As Boolean '= False
  Private m_statusBar As Boolean = True

  Private m_rows As Integer = 8
  Private m_columns As Integer = 8
  Private m_depth As Integer = 2

#Region "Loading and Saving"

  Overloads Shared Function GetFileStreamForWriting() As IO.Stream
    Return GetFileStreamForWriting(DefaultFileName, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForWriting(ByVal filename As String) As IO.Stream
    Return GetFileStreamForWriting(filename, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForWriting(ByVal filename As String, ByVal useIsolatedStorage As Boolean) As IO.Stream
    If useIsolatedStorage Then
      Dim isf As IsolatedStorageFile
      isf = IsolatedStorageFile.GetUserStoreForAssembly()
      Dim file As New IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, isf)
      isf.Close()
      Return file
    Else
      Dim workingPath As String
      workingPath = IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = IO.Path.Combine(workingPath, Application.ProductName)
      If Not IO.Directory.Exists(workingPath) Then
        Directory.CreateDirectory(workingPath)
      End If
      workingPath = IO.Path.Combine(workingPath, filename)
      Return New FileStream(workingPath, FileMode.Create, FileAccess.Write, FileShare.None)
    End If
  End Function

  Overloads Shared Function GetFileStreamForReading() As IO.Stream
    Return GetFileStreamForReading(DefaultFileName, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForReading(ByVal filename As String) As IO.Stream
    Return GetFileStreamForReading(filename, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForReading(ByVal filename As String, ByVal useIsolatedStorage As Boolean) As IO.Stream
    If useIsolatedStorage Then
      Dim isf As IO.IsolatedStorage.IsolatedStorageFile
      isf = IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly()
      Dim file As New IO.IsolatedStorage.IsolatedStorageFileStream(filename, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read, isf)
      isf.Close()
      Return file
    Else
      Dim workingPath As String
      workingPath = IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = IO.Path.Combine(workingPath, Application.ProductName)
      If Not IO.Directory.Exists(workingPath) Then
        Directory.CreateDirectory(workingPath)
      End If
      workingPath = IO.Path.Combine(workingPath, filename)
      Return New IO.FileStream(workingPath, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
    End If
  End Function

  Shared Sub Persist(ByVal settings As Settings)
    Try
      Dim outputStream As IO.Stream = GetFileStreamForWriting()
      Persist(settings, outputStream)
    Catch ex As Exception
      Dim e As New IOException("Could not save Settings", ex)
      Throw e
    End Try
  End Sub

  Shared Sub Persist(ByVal settings As Settings, ByVal outputStream As IO.Stream)
    Dim xs As New Xml.Serialization.XmlSerializer(GetType(Settings))
    xs.Serialize(outputStream, settings)
    outputStream.Close()
  End Sub

  Public Sub PersistMe()
    Settings.Persist(Me)
  End Sub

  Public Sub PersistMe(ByVal stream As IO.Stream)
    Settings.Persist(Me, stream)
  End Sub

  Shared Function Load() As Settings
    Try
      Dim inputStream As IO.Stream = GetFileStreamForReading()
      Return Load(inputStream)
    Catch ex As Exception
      Dim e As New IOException("Could not load Settings", ex)
      Throw e
    End Try
  End Function

  Shared Function Load(ByVal stream As IO.Stream) As Settings
    Dim result As Settings
    If stream.Length = 0 Then
      result = New Settings
    Else
      Dim xs As New Xml.Serialization.XmlSerializer(GetType(Settings))
      result = CType(xs.Deserialize(stream), Settings)
    End If
    stream.Close()
    Return result
  End Function

#End Region

  Public Property Location() As Point
    Get
      Return m_position
    End Get
    Set(ByVal Value As Point)
      m_position = Value
    End Set
  End Property

  Public Property Size() As Size
    Get
      Return m_size
    End Get
    Set(ByVal Value As Size)
      m_size = Value
    End Set
  End Property

  Public Property Hints() As Boolean
    Get
      Return m_hints
    End Get
    Set(ByVal Value As Boolean)
      m_hints = Value
    End Set
  End Property

  Public Property StatusBar() As Boolean
    Get
      Return m_statusBar
    End Get
    Set(ByVal Value As Boolean)
      m_statusBar = Value
    End Set
  End Property

  Public Property BoardRows() As Integer
    Get
      Return m_rows
    End Get
    Set(ByVal Value As Integer)
      m_rows = Value
    End Set
  End Property

  Public Property BoardColumns() As Integer
    Get
      Return m_columns
    End Get
    Set(ByVal Value As Integer)
      m_columns = Value
    End Set
  End Property

  Public Property BoardDepth() As Integer
    Get
      Return m_depth
    End Get
    Set(ByVal Value As Integer)
      m_depth = Value
    End Set
  End Property

End Class