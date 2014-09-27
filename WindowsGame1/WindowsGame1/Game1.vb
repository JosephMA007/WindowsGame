Imports System.Collections.Generic
''' <summary>
''' This is the main type for your game
''' </summary>
Public Class Game1
    Inherits Microsoft.Xna.Framework.Game

    Private WithEvents spriteBatch As SpriteBatch
    'Private blocks(3 - 1) As Block
    Private blocks As List(Of Block)
    Private myText As Text1

    Public Sub New()
        graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
        graphics.PreferredBackBufferWidth = 1280
        graphics.PreferredBackBufferHeight = 1000
        IsMouseVisible = True
    End Sub

    ''' <summary>
    ''' Allows the game to perform any initialization it needs to before starting to run.
    ''' This is where it can query for any required services and load any non-graphic
    ''' related content.  Calling MyBase.Initialize will enumerate through any components
    ''' and initialize them as well.
    ''' </summary>
    Protected Overrides Sub Initialize()
        ' TODO: Add your initialization logic here
        MyBase.Initialize()
    End Sub

    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
    Protected Overrides Sub LoadContent()
        ' Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = New SpriteBatch(GraphicsDevice)
        blocks = New List(Of Block)
        'For i = 0 To 2
        '    blocks.Add(New Block)
        'Next
        ' TODO: use Me.Content to load your game content here

        myText = New Text1(Content)
    End Sub

    ''' <summary>
    ''' UnloadContent will be called once per game and is the place to unload
    ''' all content.
    ''' </summary>
    Protected Overrides Sub UnloadContent()
        ' TODO: Unload any non ContentManager content here
    End Sub

    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Dim mouseColor As Color = Color.Wheat
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        ' Allows the game to exit
        If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed Then
            Me.Exit()
        End If

        myText.text = "Blocks: " & blocks.Count

        Dim mousePos As Vector2 = New Vector2(Math.Round(Mouse.GetState.X / 16) * 16, Math.Round(Mouse.GetState.Y / 16) * 16)

        If Mouse.GetState.LeftButton = ButtonState.Pressed Then
            Block.addBlock(blocks, mousePos, mouseColor, True)
        End If

        For Each b As Block In blocks
            If b.Gravity Then
                b.fall()
            End If
        Next

        If Keyboard.GetState.IsKeyDown(Keys.NumPad1) Then
            Dim mouseColor As Color = Color.Pink
        End If

        If Keyboard.GetState.IsKeyDown(Keys.C) Then
            blocks.Clear()
        End If

        '        For i = 0 To blocks.Count - 2
        '            If blocks(blocks.Count - 1).blockPos = blocks(i).blockPos Then
        '                blocks.RemoveAt(blocks.Count - 1)
        '                GoTo end_of_for
        '            End If
        '        Next
        'end_of_for:
        ' TODO: Add your update logic here
        MyBase.Update(gameTime)
    End Sub

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        GraphicsDevice.Clear(Color.CornflowerBlue)

        spriteBatch.Begin()

        For i = 0 To blocks.Count - 1
            spriteBatch.Draw(blocks(i).blocktex, blocks(i).blockPos, Color.White)
        Next

        spriteBatch.End()

        myText.draw()

        ' TODO: Add your drawing code here
        MyBase.Draw(gameTime)
    End Sub

End Class
