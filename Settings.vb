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

  Private Const DEFAUILT_FILENAME As String = "settings.xml"
  Private Const DEFAULT_USE_ISOLATED_STORAGE As Boolean = False

#Region "Loading and Saving"

  Overloads Shared Function GetFileStreamForWriting() As Stream
    Return GetFileStreamForWriting(DEFAUILT_FILENAME, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForWriting(filename As String) As Stream
    Return GetFileStreamForWriting(filename, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForWriting(filename As String, useIsolatedStorage As Boolean) As Stream
    If useIsolatedStorage Then
      Using isf = IsolatedStorageFile.GetUserStoreForAssembly()
        Using file As New IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, isf)
          isf.Close()
          Return file
        End Using
      End Using
    Else
      Dim workingPath = IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = IO.Path.Combine(workingPath, Application.ProductName)
      If Not IO.Directory.Exists(workingPath) Then
        Directory.CreateDirectory(workingPath)
      End If
      workingPath = IO.Path.Combine(workingPath, filename)
      Return New FileStream(workingPath, FileMode.Create, FileAccess.Write, FileShare.None)
    End If
  End Function

  Overloads Shared Function GetFileStreamForReading() As Stream
    Return GetFileStreamForReading(DEFAUILT_FILENAME, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForReading(filename As String) As Stream
    Return GetFileStreamForReading(filename, DEFAULT_USE_ISOLATED_STORAGE)
  End Function

  Overloads Shared Function GetFileStreamForReading(filename As String, useIsolatedStorage As Boolean) As Stream
    If useIsolatedStorage Then
      Using isf = IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly()
        Using file As New IsolatedStorageFileStream(filename, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read, isf)
          isf.Close()
          Return file
        End Using
      End Using
    Else
      Dim workingPath = IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), Application.CompanyName)
      workingPath = IO.Path.Combine(workingPath, Application.ProductName)
      If Not IO.Directory.Exists(workingPath) Then
        Directory.CreateDirectory(workingPath)
      End If
      workingPath = IO.Path.Combine(workingPath, filename)
      Return New FileStream(workingPath, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
    End If
  End Function

  Shared Sub Persist(settings As Settings)
    Try
      Using outputStream = GetFileStreamForWriting()
        Persist(settings, outputStream)
      End Using
    Catch ex As Exception
      Dim e As New IOException("Could not save Settings", ex)
      Throw e
    End Try
  End Sub

  Shared Sub Persist(settings As Settings, outputStream As Stream)
    Dim xs As New Xml.Serialization.XmlSerializer(GetType(Settings))
    xs.Serialize(outputStream, settings)
    outputStream.Close()
  End Sub

  Public Sub PersistMe()
    Settings.Persist(Me)
  End Sub

  Public Sub PersistMe(stream As Stream)
    Settings.Persist(Me, stream)
  End Sub

  Shared Function Load() As Settings
    Try
      Using inputStream = GetFileStreamForReading()
        Return Load(inputStream)
      End Using
    Catch ex As Exception
      Dim e As New IOException("Could not load Settings", ex)
      Throw e
    End Try
  End Function

  Shared Function Load(stream As Stream) As Settings
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

  Public Property Location() As Point ' Location of the main window.
  Public Property Size() As Size ' Size of the main window.
  Public Property Hints() As Boolean
  Public Property StatusBar() As Boolean
  Public Property BoardRows() As Integer = 8
  Public Property BoardColumns() As Integer = 8
  Public Property BoardDepth() As Integer = 2

End Class