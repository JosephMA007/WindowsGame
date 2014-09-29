Public Class World_Genorator


    Public Shared Sub Genorate(ByRef b As System.Collections.Generic.List(Of Block))

        'make a line of blocks

        For index = 0 To Block.blockSize * 15 Step Block.blockSize
            Block.addBlock(b, New Vector2(index, Block.blockSize * 6), Color.Green, False)
        Next

    End Sub
End Class
