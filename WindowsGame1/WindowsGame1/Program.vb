#If WINDOWS Or XBOX Then

Module Program
    Public WithEvents graphics As GraphicsDeviceManager
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    ''' 
    Public unitIds As Integer
    Sub Main(ByVal args As String())
        Using game As New Game1()
            unitIds = 0
            game.Run()
        End Using
    End Sub
End Module

#End If
