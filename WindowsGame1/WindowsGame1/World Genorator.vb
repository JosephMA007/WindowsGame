Public Class World_Genorator


    Public Shared Sub Genorate(ByRef b As System.Collections.Generic.List(Of Block))

        'make a line of blocks

        For index = 0 To Block.blockSize * 15 Step Block.blockSize
            Block.addBlock(b, New Vector2(index, Block.blockSize * 6), Color.Green, False)
        Next

    End Sub

    Public Shared Sub GenorateTexturePattern(ByRef b As System.Collections.Generic.List(Of Block))
        Dim w As Integer = graphics.PreferredBackBufferWidth
        Dim h As Integer = graphics.PreferredBackBufferHeight

        'still need to put this in the middle
        Dim spotsW As Integer = Math.Round(w / 16, 0)
        Dim spotsH As Integer = Math.Round(h / 16, 0)

        Dim startW As Integer = (spotsW - Block.blockSize) / 2
        Dim startH As Integer = (spotsH - Block.blockSize) / 2
        If startW < 0 Then startW = 0
        If startH < 0 Then startH = 0

        Dim c As Color = Color.White
        Dim lastRowColor As Color = Color.White

        For row = startH To Block.blockSize - 1 + startH
            For col = startW To Block.blockSize - 1 + startW
                Block.addBlock(b, New Vector2(col * Block.blockSize, row * Block.blockSize), c, False)
                If c = Color.White Then
                    c = Color.Gray
                Else
                    c = Color.White
                End If
            Next
            If lastRowColor = Color.White Then
                c = Color.Gray
                lastRowColor = Color.Gray
            Else
                c = Color.White
                lastRowColor = Color.White
            End If
        Next

    End Sub
End Class
