Public Class Text1
    Public font1 As SpriteFont
    Public fontPos As Vector2
    Public spriteBatch As New SpriteBatch(graphics.GraphicsDevice)
    Public text As String = "Hello World"

    Public Sub New(ByRef content As Content.ContentManager)
        font1 = content.Load(Of SpriteFont)("Andy")
        fontPos = New Vector2(50, 570)

    End Sub

    Public Sub setText(str As String)
        text = str
    End Sub

    Public Sub draw()
        spriteBatch.Begin()

        Dim FontOrigin As Vector2 = fontPos ' font1.MeasureString(text) / 2

        spriteBatch.DrawString(font1, text, fontPos, Color.White, _
            0, FontOrigin, 1.0F, SpriteEffects.None, 0.5F)

        spriteBatch.End()
    End Sub
End Class
