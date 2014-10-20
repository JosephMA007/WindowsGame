Imports System.IO
Public Class Filer
    Public Shared Sub Save(theFile As myFile)
        File.WriteAllText(theFile.path & "\" & theFile.fileNames.ToString, theFile.text)
    End Sub
    Public Shared Sub Open(ByRef theFile As myFile)
        If File.Exists(theFile.path & "\" & theFile.fileNames.ToString) Then
            theFile.text = File.ReadAllText(theFile.path & "\" & theFile.fileNames.ToString)
        End If
    End Sub

    Public Class myFile
        Public path As String
        Public fileNames As enumFileNames
        Public text As String
        Public Enum enumFileNames
            pallets = 1

        End Enum
        Public Sub New(inName As enumFileNames, Optional inPath As String = "")
            If String.IsNullOrEmpty(inPath) Then
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\BlockIT"
            Else
                path = inPath
            End If
            fileNames = inName
        End Sub
    End Class
End Class
