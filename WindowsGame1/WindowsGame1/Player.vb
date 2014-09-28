Public Class Player
    Inherits Unit
    Public hp As Integer
    Public speed As Integer
    Public Enum direction
        up
        down
        left
        right
    End Enum
    Public Sub New()
        hp = 5
        speed = 3
        setColor(Color.Pink)
    End Sub

    Public Sub Move(dir As direction)
        Select Case dir
            Case direction.up
                unitPos += New Vector2(0, speed)
            Case direction.down
                unitPos -= New Vector2(0, speed)
            Case direction.right
                unitPos += New Vector2(speed, 0)
            Case direction.left
                unitPos -= New Vector2(speed, 0)
        End Select
    End Sub
End Class
