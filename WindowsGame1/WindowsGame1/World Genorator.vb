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

        colorPicker(b)
    End Sub

    Public Shared Sub colorPicker(ByRef blocks As System.Collections.Generic.List(Of Block))
        Dim c As New ColorChart
        "instead of that use color lovers api provided on github"
        For row = 0 To 31
            For col = 0 To 15
                Block.addBlock(blocks, New Vector2(col * Block.blockSize, row * Block.blockSize), c.c, False)
                c.nextColor()
            Next
        Next
    End Sub

    Class ColorChart
        Public r, g, b As Integer
        Public myStep As enumStep
        Public c As Color
        Public Enum enumStep
            r = 1
            g = 2
            b = 3
        End Enum
        Private base As Integer
        Public Sub New()
            myStep = enumStep.r
            c = New Color(r, g, b)
        End Sub

        Public Sub nextColor()
            Select Case myStep
                Case enumStep.r
                    r += 16
                    If r > 256 Then
                        r = base
                        base += 8
                        myStep = enumStep.g
                    End If
                Case enumStep.g
                    g += 16
                    If g > 256 Then
                        g = base
                        base += 8
                        myStep = enumStep.b
                    End If
                Case enumStep.b
                    b += 16
                    If b > 256 Then
                        b = base
                        base += 8
                        myStep = enumStep.r
                    End If
            End Select
            If base > 256 Then base = 0
            c = New Color(r, g, b)
        End Sub
    End Class
End Class
