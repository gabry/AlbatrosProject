Module Globali
    'COSTANTI DA USARE IN TUTTO IL PROGRAMMA
    Public ColorSelection As Color = Color.DarkOrange
    Public ColorSelected As Color = Color.LightCyan

    Public ApplicationDir As String = Application.StartupPath  'variabile path applicazione
    Public PathImage As String = ApplicationDir & "\Images\"
    Public PathSite As String 'variabile path progetto attualmente caricato
    Public PathSiteImage As String 'variabile path immagini progetto attualmente caricato
    Public PathSiteDb As String 'variabile path per la cartella dove verranno creati i vari DB di testo
    Public DbObject As New Utilities.FileTxtDataProvider 'oggetto per usare i file di testo come db
    Public StiliDictonary As New Dictionary(Of String, String)  'stili di colore per il sito
   
    'per intercettare i tasti pigiati cn la tastiera
    Public Declare Function GetAsyncKeyState Lib "user32" Alias "GetAsyncKeyState" (ByVal vKey As Keys) As Short
    Public ScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Public ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

    'divide una stringa in base ad un carattere di divisione
    Public Function ExplodeString(ByVal StringToExplode As String, ByVal SpaceToSplit As Integer) As String()

        Dim StrExplode As String()
        Dim l As Long

        Try
            ReDim StrExplode(Len(StringToExplode) - 1)

            For l = 1 To Len(StringToExplode)
                StrExplode(l - 1) = Mid(StringToExplode, l, SpaceToSplit)
            Next

            Return StrExplode
        Catch ex As Exception

        End Try
    End Function
    Public Function Dialog(ByRef form As Form) As DialogResult

        Dim res As DialogResult
        res = form.ShowDialog()
        form.Dispose()
        form = Nothing
        Return res

    End Function
  
  
    Public Function CreateResizedImageFromFile(ByVal fileName As String, ByVal newSize As Integer) As Image
        Dim tempImage As Image

        Try
            tempImage = New Bitmap(fileName)
        Catch
            Return Nothing
        End Try

        Dim width As Integer = tempImage.Width
        Dim height As Integer = tempImage.Height

        If width >= height Then
            Dim aspectRatio As Single = CSng(width) / CSng(height)
            width = newSize
            height = CInt(Math.Truncate(CSng(width) / aspectRatio))
        Else

            Dim aspectRatio As Single = CSng(height) / CSng(width)
            height = newSize
            width = CInt(Math.Truncate(CSng(height) / aspectRatio))
        End If

        Dim resizedImage As Image = New Bitmap(width, height)
        Using graphics__1 As Graphics = Graphics.FromImage(resizedImage)
            graphics__1.DrawImage(tempImage, 0, 0, width, height)
        End Using

        'If tempImage.Equals(GlobalData.InvalidImage) = False Then
        '    tempImage.Dispose()
        'End If

        Return resizedImage
        
    End Function
    'Public Function IsVideoFile(ByVal sName As String) As Boolean

    '    If sName.EndsWith(".avi") Or sName.EndsWith(".mkv") Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function

End Module


