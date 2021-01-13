Option Explicit On
Option Strict On
Option Infer On

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

  'Private m_rows As Integer = 8
  'Private m_columns As Integer = 8
  'Private m_depth As Integer = 2

#Region "Loading and Saving"

  Overloads Shared Function GetFileStreamForWriting() As Stream
    Return GetFileStreamForWriting(DefaultFileName, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForWriting(filename As String) As Stream
    Return GetFileStreamForWriting(filename, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForWriting(filename As String, useIsolatedStorage As Boolean) As Stream
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

  Overloads Shared Function GetFileStreamForReading() As Stream
    Return GetFileStreamForReading(DefaultFileName, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForReading(filename As String) As Stream
    Return GetFileStreamForReading(filename, DefaultUseIsolatedStorage)
  End Function

  Overloads Shared Function GetFileStreamForReading(filename As String, useIsolatedStorage As Boolean) As Stream
    If useIsolatedStorage Then
      Dim isf As IsolatedStorageFile
      isf = IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly()
      Dim file As New IsolatedStorageFileStream(filename, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read, isf)
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
      Return New FileStream(workingPath, IO.FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
    End If
  End Function

  Shared Sub Persist(settings As Settings)
    Try
      Dim outputStream As Stream = GetFileStreamForWriting()
      Persist(settings, outputStream)
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
      Dim inputStream As Stream = GetFileStreamForReading()
      Return Load(inputStream)
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