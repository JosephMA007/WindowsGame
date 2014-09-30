Public Class Unit
    Public unittex As Texture2D
    Public unitPos As Vector2
    Public Gravity As Boolean
    Public data() As Color
    Public moveable As Boolean
    Public Const fallSpeed As Integer = 4
    Public id As Integer
    Public Sub New(size As Integer)
        unitPos = New Vector2(20, 20)
        unittex = New Texture2D(graphics.GraphicsDevice, size, size)
        'defualt color
        ReDim data((size * size) - 1)
        setColor(Color.Black)
        moveable = False
        unitIds += 1
        id = unitIds
    End Sub

    Public Sub setColor(c As Color)
        For i As Integer = 0 To data.Length - 1
            data(i) = c
        Next
        unittex.SetData(data)
    End Sub

    Public Sub fall(ByRef b As System.Collections.Generic.List(Of Block))
        Dim pos As Vector2 = unitPos
        pos += New Vector2(0, Block.blockSize)
        Dim x As Block = b.Find(Function(y) y.unitPos = pos)
        'Dim n As Block = b.Find(Function(y) y.unitPos = pos And y.Gravity = True)
        If IsNothing(x) Then
            unitPos += New Vector2(0, fallSpeed)
        Else
            'unitPos -= New Vector2(0, fallSpeed)
            Gravity = False
            unitPos = Block.BlockPos(unitPos)
        End If

        If pos.Y > graphics.PreferredBackBufferHeight + Block.blockSize Then
            'to keep them from falling forever for now
            Gravity = False
            moveable = False
        End If
        'If IsNothing(n) Then
        'Else
        '    unitPos -= New Vector2(0, 4)
        'End If
    End Sub
End Class
