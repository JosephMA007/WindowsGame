Public Class Block
    Public blocktex As Texture2D
    Public blockPos As Vector2
    Public Gravity As Boolean
    Public data(255) As Color
    Public Sub New()
        blockPos = New Vector2(20, 20)
        blocktex = New Texture2D(graphics.GraphicsDevice, 16, 16)
        setColor(Color.Black)
    End Sub

    Public Sub setColor(c As Color)
        For i As Integer = 0 To data.Length - 1
            data(i) = c
        Next
        blocktex.SetData(data)
    End Sub

    Public Shared Sub addBlock(ByRef b As System.Collections.Generic.List(Of Block), pos As Vector2, c As Color, Optional g As Boolean = False)
        Dim x As Block = b.Find(Function(y) y.blockPos = pos)
        Dim z As New Block
        z.setColor(c)
        z.blockPos = pos
        z.Gravity = g
        If IsNothing(x) Then
            b.Add(z)
        Else
            b.Remove(x)
            b.Add(z)
        End If
    End Sub

    Public Sub fall(ByRef b As System.Collections.Generic.List(Of Block))
        Dim pos As Vector2 = blockPos
        pos += New Vector2(0, 16)
        Dim x As Block = b.Find(Function(y) y.blockPos = pos And y.Gravity = False)
        Dim n As Block = b.Find(Function(y) y.blockPos = pos And y.Gravity = True)
        If IsNothing(x) Then
            blockPos += New Vector2(0, 4)
        End If
        If Else IsNothing(n) Then
        Else
            blockPos -= New Vector2(0, 4)
        End If
    End Sub
End Class