Public Class Block
    Inherits Unit
    Public Shared Sub addBlock(ByRef b As System.Collections.Generic.List(Of Block), pos As Vector2, c As Color, Optional g As Boolean = False)
        Dim x As Block = b.Find(Function(y) y.unitPos = pos)
        Dim z As New Block
        z.setColor(c)
        z.unitPos = pos
        z.Gravity = g
        If IsNothing(x) Then
            b.Add(z)
        Else
            b.Remove(x)
            b.Add(z)
        End If
    End Sub
End Class