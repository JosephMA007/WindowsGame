Imports System.Collections.Generic
''' <summary>
''' This is the main type for your game
''' </summary>
Public Class Game1
    Inherits Microsoft.Xna.Framework.Game

    Private WithEvents spriteBatch As SpriteBatch
    'Private blocks(3 - 1) As Block
    Private blocks As List(Of Block)
    Private myPlayer As Player
    Private myText As Text1
    Private gameMode As gameModeEnum
    Enum gameModeEnum
        normal = 1
        textureCreator = 2

    End Enum

    Public Sub New()
        graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
        graphics.PreferredBackBufferWidth = 1024
        graphics.PreferredBackBufferHeight = 500
        graphics.IsFullScreen = False
        IsMouseVisible = True
        gameMode = gameModeEnum.normal
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
        myPlayer = New Player

        'World_Genorator.GenorateTexturePattern(blocks)

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
    Private mouseColor As Color = Color.Black
    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        If (Me.IsActive) Then
            Dim mousePos As Vector2 = Block.BlockPos(Mouse.GetState.X, Mouse.GetState.Y)

            myText.setText("Debugging Info:")
            myText.addText("Blocks: " & blocks.Count)
            'block under mouse
            Dim b1 As Block = blocks.Find(Function(x) x.unitPos = mousePos)
            If Not IsNothing(b1) Then
                myText.addText("Block under mouse: " & b1.id)
            End If

            myText.addText("Mouse Pos (" & Mouse.GetState.X & "," & Mouse.GetState.Y & ") Block Calc (" & mousePos.X & "," & mousePos.Y & ")")

            If gameMode = gameModeEnum.normal Then
                ' Allows the game to exit
                If Keyboard.GetState.IsKeyDown(Keys.Escape) Then
                    'Me.Exit()
                End If

                If Mouse.GetState.RightButton = ButtonState.Pressed Then
                    Block.addBlock(blocks, mousePos, mouseColor, True)
                End If

                If Mouse.GetState.LeftButton = ButtonState.Pressed Then
                    Block.addBlock(blocks, mousePos, mouseColor, False)
                End If

                For Each b As Block In blocks
                    If b.Gravity Then
                        b.fall(blocks)
                    End If
                Next

                If Keyboard.GetState.IsKeyDown(Keys.NumPad1) Then
                    mouseColor = Color.Black
                End If

                If Keyboard.GetState.IsKeyDown(Keys.NumPad2) Then
                    mouseColor = Color.Blue
                End If

                If Keyboard.GetState.IsKeyDown(Keys.NumPad3) Then
                    mouseColor = Color.Red
                End If

                If Keyboard.GetState.IsKeyDown(Keys.NumPad4) Then
                    mouseColor = Color.Yellow
                End If

                If Keyboard.GetState.IsKeyDown(Keys.NumPad5) Then
                    mouseColor = Color.Green
                End If

                If Keyboard.GetState.IsKeyDown(Keys.C) Then
                    blocks.Clear()
                End If

                If Keyboard.GetState.IsKeyDown(Keys.T) Then
                    blocks.Clear()
                    World_Genorator.GenorateTexturePattern(blocks)
                    gameMode = gameModeEnum.textureCreator
                End If

                If Keyboard.GetState.IsKeyDown(Keys.W) Then
                    myPlayer.Move(Player.direction.up)
                End If

                If Keyboard.GetState.IsKeyDown(Keys.S) Then
                    myPlayer.Move(Player.direction.down)
                End If

                If Keyboard.GetState.IsKeyDown(Keys.D) Then
                    myPlayer.Move(Player.direction.right)
                End If

                If Keyboard.GetState.IsKeyDown(Keys.A) Then
                    myPlayer.Move(Player.direction.left)
                End If

                If Keyboard.GetState.IsKeyDown(Keys.F) Then
                    If graphics.IsFullScreen = True Then
                        graphics.IsFullScreen = False
                    Else
                        graphics.IsFullScreen = True
                    End If
                End If
                '        For i = 0 To blocks.Count - 2
                '            If blocks(blocks.Count - 1).blockPos = blocks(i).blockPos Then
                '                blocks.RemoveAt(blocks.Count - 1)
                '                GoTo end_of_for
                '            End If
                '        Next
                'end_of_for:
            Else
                'gameMode Texture
                If Keyboard.GetState.IsKeyDown(Keys.Escape) Then
                    blocks.Clear()
                    gameMode = gameModeEnum.normal
                End If
            End If
            MyBase.Update(gameTime)
        End If 'is active
    End Sub

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        If Me.IsActive Then
            GraphicsDevice.Clear(Color.CornflowerBlue)

            spriteBatch.Begin()

            For i = 0 To blocks.Count - 1
                spriteBatch.Draw(blocks(i).unittex, blocks(i).unitPos, Color.White)
            Next

            spriteBatch.Draw(myPlayer.unittex, myPlayer.unitPos, Color.White)


            spriteBatch.End()

            myText.draw()

            ' TODO: Add your drawing code here
            MyBase.Draw(gameTime)
        End If
    End Sub

End Class
