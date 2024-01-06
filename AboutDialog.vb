Public Class AboutDialog

  Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim ver = Application.ProductVersion
    If ver.Contains("+"c) Then ver = ver.Substring(0, ver.IndexOf("+"c))
    Dim version = New Version(ver)
    VersionLabel.Text = VersionLabel.Text.Replace("[version]", $"{version.Major}.{version.Minor}") _
                                         .Replace("[build]", $"{version.Build}")
  End Sub

End Class