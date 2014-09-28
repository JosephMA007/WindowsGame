Public Class Unit
    Public unittex As Texture2D
    Public unitPos As Vector2
    Public Gravity As Boolean
    Public data(255) As Color
    Public Sub New()
        unitPos = New Vector2(20, 20)
        unittex = New Texture2D(graphics.GraphicsDevice, 16, 16)
        setColor(Color.Black)
    End Sub

    Public Sub setColor(c As Color)
        For i As Integer = 0 To data.Length - 1
            data(i) = c
        Next
        unittex.SetData(data)
    End Sub

    Public Sub fall(ByRef b As System.Collections.Generic.List(Of Unit))
        Dim pos As Vector2 = unitPos
        pos += New Vector2(0, 16)
        Dim x As Unit = b.Find(Function(y) y.unitPos = pos And y.Gravity = False)
        Dim n As Unit = b.Find(Function(y) y.unitPos = pos And y.Gravity = True)
        If IsNothing(x) Then
            unitPos += New Vector2(0, 4)
        End If
        If IsNothing(n) Then
        Else
            unitPos -= New Vector2(0, 4)
        End If
    End Sub
End Class
