Public Class HlsManager

  Private Class NativeMethods
    Public Declare Sub ColorRGBToHLS Lib "shlwapi.dll" (rgb As Integer, ByRef h As Byte, ByRef l As Byte, ByRef s As Byte)
    Public Declare Function ColorHLSToRGB Lib "shlwapi.dll" (h As Byte, l As Byte, s As Byte) As Integer
  End Class

  Public Sub New()
  End Sub

#Region "Translate Colors"

  Public Shared Function Convert(c As Color, h As Integer, l As Integer, s As Integer) As Color

    Dim vh As Byte '= 0
    Dim vl As Byte '= 0
    Dim vs As Byte '= 0
    Dim _h As Byte '= 0
    Dim _l As Byte '= 0
    Dim _s As Byte '= 0
    Dim r As Integer = c.R
    Dim g As Integer = c.G
    Dim b As Integer = c.B

    b <<= 16
    g <<= 8
    Dim rgb = b + g + r

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
    Dim clr = NativeMethods.ColorHLSToRGB(_h, _l, _s)
    Dim col = Color.FromArgb(clr)

    Return Color.FromArgb(255, col.B, col.G, col.R)

  End Function

#End Region

#Region "State: Normal"

  Public Shared Function CenterColor(c As Color) As Color
    Return Convert(c, 0, 60, 0)
  End Function

  Public Shared Function SurroundColors(c As Color) As Color()
    Return {Convert(c, 0, -17, 0)}
  End Function

  Public Shared Function DarkColor(c As Color) As Color
    Return Convert(c, 0, -80, 0)
  End Function

  Public Shared Function LightColor(c As Color) As Color
    Return Convert(c, 0, 80, 0)
  End Function

#End Region

#Region "State: MouseOver"

  Public Shared Function CenterColorLight(c As Color) As Color
    Return Convert(c, 0, 100, 0)
  End Function

  Public Shared Function SurroundColorsLight(c As Color) As Color()
    Return {Convert(c, 0, -5, 0)}
  End Function

#End Region

#Region "State: Pressed"

  Public Shared Function CenterColorDark(c As Color) As Color
    Return Convert(c, 0, 60, 0)
  End Function

  Public Shared Function SurroundColorsDark(c As Color) As Color()
    Return {Convert(c, 0, -30, 0)}
  End Function

#End Region

#Region "State: Disabled"

  Public Shared Function CenterColorD(c As Color) As Color
    Return Convert(c, 0, 20, 0)
  End Function

  Public Shared Function SurroundColorsD(c As Color) As Color()
    Return {Convert(c, 0, -20, 0)}
  End Function

  Public Shared Function DarkColorD(c As Color) As Color
    Return Convert(c, 0, -80, 0)
  End Function

  Public Shared Function LightColorD(c As Color) As Color
    Return Convert(c, 0, 40, 0)
  End Function

#End Region

#Region "State: Normal Flat"

  Public Shared Function ColorFlat1(c As Color) As Color
    Return Convert(c, 0, 17, 0)
  End Function

  Public Shared Function ColorFlat2(c As Color) As Color
    Return Convert(c, 0, -10, 0)
  End Function

  Public Shared Function ColorFlat3(c As Color) As Color
    Return Convert(c, 0, 65, 0)
  End Function

  Public Shared Function ColorFlat4(c As Color) As Color
    Return Convert(c, 0, -65, 0)
  End Function

#End Region

#Region "State: MouseOver Flat"

  Public Shared Function ColorLightFlat(c As Color) As Color
    Return Convert(c, 0, 10, 0)
  End Function

#End Region

#Region "State: Pressed Flat"

  Public Shared Function ColorDarkFlat(c As Color) As Color
    Return Convert(c, 0, -20, 0)
  End Function

#End Region

#Region "State: Disabled Flat"

  Public Shared Function ColorFlat1D(c As Color) As Color
    Return Convert(c, 0, 5, 0)
  End Function

  Public Shared Function ColorFlat2D(c As Color) As Color
    Return Convert(c, 0, -20, 0)
  End Function

  Public Shared Function ColorFlat3D(c As Color) As Color
    Return Convert(c, 0, 33, 0)
  End Function

  Public Shared Function ColorFlat4D(c As Color) As Color
    Return Convert(c, 0, -65, 0)
  End Function

#End Region

#Region "Test"

  Public Shared Function TestCenterColor(c As Color) As Color
    Return Convert(c, -1, 74 + 20, 16)
  End Function

  Public Shared Function TestSurroundColors(c As Color) As Color()
    Return {Convert(c, 5, -4, 16)}
  End Function

#End Region

End Class