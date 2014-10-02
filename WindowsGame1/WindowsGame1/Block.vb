Public Class Block
    Inherits Unit
    Public Const blockSize As Integer = 16
    Public Sub New()
        MyBase.New(blockSize)
    End Sub
    Public Shared Sub addBlock(ByRef b As System.Collections.Generic.List(Of Block),
                               pos As Vector2, c As Color,
                               Optional g As Boolean = False)
        'make sure the block is only placed in the grid
        pos = BlockPos(pos)
        'see if there is already a block there
        Dim foundBlock As Block = b.Find(Function(y) BlockPos(y.unitPos) = pos)
        'start a new block
        Dim newBlock As New Block
        newBlock.setColor(c)
        newBlock.unitPos = pos
        newBlock.Gravity = g
        newBlock.moveable = g 'this will tell us if the block should fall later on
        If IsNothing(foundBlock) Then
            b.Add(newBlock)
        Else
            If Not foundBlock.Gravity Then
                b.Remove(foundBlock)
                b.Add(newBlock)
            End If
        End If
    End Sub
    Public Shared Function BlockPos(pos As Vector2) As Vector2
        Return BlockPos(pos.X, pos.Y)
    End Function
    Public Shared Function BlockPos(x As Single, y As Single) As Vector2
        Return New Vector2(Math.Truncate(x / 16) * 16, Math.Truncate(y / 16) * 16)
    End Function

End Class