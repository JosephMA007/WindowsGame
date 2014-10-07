Imports ColourLovers
Imports System.Collections.Generic
Public Class World_Genorator


    Public Shared Sub Genorate(ByRef b As List(Of Block))

        'make a line of blocks

        For index = 0 To Block.blockSize * 15 Step Block.blockSize
            Block.addBlock(b, New Vector2(index, Block.blockSize * 6), Color.Green, False)
        Next

    End Sub

    Public Shared Sub GenorateTexturePattern(ByRef b As List(Of Block))
        Dim w As Integer = graphics.PreferredBackBufferWidth
        Dim h As Integer = graphics.PreferredBackBufferHeight

        'still need to put this in the middle
        Dim spotsW As Integer = Math.Round(w / Block.blockSize, 0)
        Dim spotsH As Integer = Math.Round(h / Block.blockSize, 0)

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

    Public Shared Sub colorPicker(ByRef blocks As List(Of Block))
        'Dim c As New ColorChart
        '"instead of that use color lovers api provided on github"
        Dim pals As Model.Palette.PaletteCollection = getColors()
        If Not IsNothing(pals) Then
            Dim row As Integer
            For Each pal As Model.Palette.Palette In pals.Palettes
                Dim col As Integer
                For Each c As Drawing.Color In pal.ToColors
                    Dim xColor As Color = New Color(c.R, c.G, c.B)
                    Block.addBlock(blocks, New Vector2(col * Block.blockSize, row * Block.blockSize), xColor, False)
                    col += 1
                Next
                row += 1
            Next
        Else
            Block.addBlock(blocks, New Vector2(0 * Block.blockSize, 0 * Block.blockSize), Color.Black, False)
        End If
    End Sub

    Public Shared Function getColors(Optional offset As Integer = 0) As Model.Palette.PaletteCollection
        'I am probably going to need to put this in a tread, so i am not waiting for the server
        Dim colorLover As New ColourLoversRepository
        Dim req As New ColourLovers.SearchRequest.PalettesSearchRequest
        req.NumResults = 5
        req.ResultOffset = offset
        Dim paletCollection As Model.Palette.PaletteCollection = colorLover.Palettes.GetPalettes(req)
        If paletCollection.TotalResults > 0 Then
            Return paletCollection
        Else
            Return Nothing
        End If
        'For Each pal As ColourLovers.Model.Palette.Palette In paletCollection.Palettes
        '    For Each c As System.Drawing.Color In pal.ToColors()

        '    Next
        'Next
    End Function


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
            base = 255
        End Sub

        Public Sub nextColor()
            Select Case myStep
                Case enumStep.r
                    r += 16
                    If r > 256 Then
                        r = base
                        base -= 8
                        myStep = enumStep.g
                    End If
                Case enumStep.g
                    g += 16
                    If g > 256 Then
                        g = base
                        base -= 8
                        myStep = enumStep.b
                    End If
                Case enumStep.b
                    b += 16
                    If b > 256 Then
                        b = base
                        base -= 8
                        myStep = enumStep.r
                    End If
            End Select
            If base < 0 Then base = 255
            c = New Color(r, g, b)
        End Sub

    End Class
End Class
