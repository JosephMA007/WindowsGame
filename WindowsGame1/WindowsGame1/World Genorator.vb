Public Class World_Genorator


    Public Shared Sub Genorate(ByRef b As System.Collections.Generic.List(Of Block))

        'make a line of blocks

        For index = 0 To Block.blockSize * 15 Step Block.blockSize
            Block.addBlock(b, New Vector2(index, Block.blockSize * 6), Color.Green, False)
        Next

    End Sub

    Public Shared Sub GenorateTexturePattern(ByRef b As System.Collections.Generic.List(Of Block))

        'still need to put this in the middle

        For row = 0 To 15
            For col = 0 To 15
                Block.addBlock(b, New Vector2(col * Block.blockSize, row * Block.blockSize), Color.Green, False)
            Next
        Next

    End Sub
End Class
