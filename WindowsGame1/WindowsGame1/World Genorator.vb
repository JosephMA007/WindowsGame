Public Class World_Genorator
    Public Const blockSize As Integer = 16

    Public Shared Sub Genorate(ByRef b As System.Collections.Generic.List(Of Block))

        'make a line of blocks

        For index = 0 To blockSize * 15 Step blockSize
            Block.addBlock(b, New Vector2(index, blockSize * 6), Color.Green, False)
        Next

    End Sub
End Class
