Public Class HlsManager

  Private Class NativeMethods
    Public Declare Sub ColorRGBToHLS Lib "shlwapi.dll" (ByVal RGB As Integer, ByRef h As Byte, ByRef l As Byte, ByRef s As Byte)
    Public Declare Function ColorHLSToRGB Lib "shlwapi.dll" (ByVal h As Byte, ByVal l As Byte, ByVal s As Byte) As Integer
  End Class

  Public Sub New()
  End Sub

#Region "Translate Colors"

  Public Shared Function Convert(ByVal c As Color, ByVal h As Integer, ByVal l As Integer, ByVal s As Integer) As Color

    Dim vh As Byte '= 0
    Dim vl As Byte '= 0
    Dim vs As Byte '= 0
    Dim _h As Byte '= 0
    Dim _l As Byte '= 0
    Dim _s As Byte '= 0
    Dim R As Integer = c.R
    Dim G As Integer = c.G
    Dim B As Integer = c.B

    B <<= 16
    G <<= 8
    Dim rgb As Integer = B + G + R

    NativeMethods.ColorRGBToHLS(rgb, vh, vl, vs)

    If vh + h > 240 Then
      _h = 240
    ElseIf vh + h < 0 Then
      _h = 1
    Else
      _h = System.Convert.ToByte(vh + h)
    End If
    If vl + l > 240 Then
      _l = 240
    ElseIf vl + l < 0 Then
      _l = 1
    Else
      _l += System.Convert.ToByte(vl + l)
    End If
    If vs + s > 240 Then
      _s = 240
    ElseIf vs + s < 0 Then
      _s = 1
    Else
      _s += System.Convert.ToByte(vs + s)
    End If
    Dim clr As Integer = NativeMethods.ColorHLSToRGB(_h, _l, _s)
    Dim col As Color = Color.FromArgb(clr)

    Return Color.FromArgb(255, col.B, col.G, col.R)

  End Function

#End Region

#Region "State: Normal"

  Public Function CenterColor(ByVal c As Color) As Color
    Return Convert(c, 0, 60, 0)
  End Function

  Public Function SurroundColors(ByVal c As Color) As Color()
    Dim colors As Color() = {Convert(c, 0, -17, 0)}
    Return colors
  End Function

  Public Function DarkColor(ByVal c As Color) As Color
    Return Convert(c, 0, -80, 0)
  End Function

  Public Function LightColor(ByVal c As Color) As Color
    Return Convert(c, 0, 80, 0)
  End Function

#End Region

#Region "State: MouseOver"

  Public Function CenterColorLight(ByVal c As Color) As Color
    Return Convert(c, 0, 100, 0)
  End Function

  Public Function SurroundColorsLight(ByVal c As Color) As Color()
    Dim colors As Color() = {Convert(c, 0, -5, 0)}
    Return colors
  End Function

#End Region

#Region "State: Pressed"

  Public Function CenterColorDark(ByVal c As Color) As Color
    Return Convert(c, 0, 60, 0)
  End Function

  Public Function SurroundColorsDark(ByVal c As Color) As Color()
    Dim colors As Color() = {Convert(c, 0, -30, 0)}
    Return colors
  End Function

#End Region

#Region "State: Disabled"

  Public Function CenterColorD(ByVal c As Color) As Color
    Return Convert(c, 0, 20, 0)
  End Function

  Public Function SurroundColorsD(ByVal c As Color) As Color()
    Dim colors As Color() = {Convert(c, 0, -20, 0)}
    Return colors
  End Function

  Public Function DarkColorD(ByVal c As Color) As Color
    Return Convert(c, 0, -80, 0)
  End Function

  Public Function LightColorD(ByVal c As Color) As Color
    Return Convert(c, 0, 40, 0)
  End Function

#End Region

#Region "State: Normal Flat"

  Public Shared Function ColorFlat1(ByVal c As Color) As Color
    Return Convert(c, 0, 17, 0)
  End Function

  Public Shared Function ColorFlat2(ByVal c As Color) As Color
    Return Convert(c, 0, -10, 0)
  End Function

  Public Shared Function ColorFlat3(ByVal c As Color) As Color
    Return Convert(c, 0, 65, 0)
  End Function

  Public Shared Function ColorFlat4(ByVal c As Color) As Color
    Return Convert(c, 0, -65, 0)
  End Function

#End Region

#Region "State: MouseOver Flat"

  Public Function ColorLightFlat(ByVal c As Color) As Color
    Return Convert(c, 0, 10, 0)
  End Function

#End Region

#Region "State: Pressed Flat"

  Public Function ColorDarkFlat(ByVal c As Color) As Color
    Return Convert(c, 0, -20, 0)
  End Function

#End Region

#Region "State: Disabled Flat"

  Public Function ColorFlat1D(ByVal c As Color) As Color
    Return Convert(c, 0, 5, 0)
  End Function

  Public Function ColorFlat2D(ByVal c As Color) As Color
    Return Convert(c, 0, -20, 0)
  End Function

  Public Function ColorFlat3D(ByVal c As Color) As Color
    Return Convert(c, 0, 33, 0)
  End Function

  Public Function ColorFlat4D(ByVal c As Color) As Color
    Return Convert(c, 0, -65, 0)
  End Function

#End Region

#Region "Test"

  Public Function TestCenterColor(ByVal c As Color) As Color
    Return Convert(c, -1, 74 + 20, 16)
  End Function

  Public Function TestSurroundColors(ByVal c As Color) As Color()
    Dim colors As Color() = {Convert(c, 5, -4, 16)}
    Return colors
  End Function

#End Region

End Class