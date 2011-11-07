Public Class Usercontrol
    Private _sFileImage As String
    Public _Height As Integer
    Public _Width As Integer

    Private Sub CustomDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If _sFileImage.Length > 0 Then
        '    LoadInformation()
        'End If


    End Sub
    Public Sub LoadInformation(ByVal sFileName As String, ByVal sKey As String)

        Dim bm_source As New Bitmap(sFileName)
        Dim bm_dest As New Bitmap(CInt(AnimationControl1.Width - 10), CInt(_Height))
        Dim sSql As String
        Dim ds As DataSet
        Dim dataRowCurrent As DataRowView
        Dim dw As DataView
    


        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

        ' Display the result.
        '  Pctbox.Image = bm_dest
        ' Pctbox.BackColor = Color.Transparent
        'AnimationControl1.AnimatedImage =

        Dim Type As AnimationTypes = RandomEnum(Of AnimationTypes)()
        AnimationControl1.AnimationType = Type
        AnimationControl1.Animate(50)
        AnimationControl1.AnimatedImage = bm_dest

        DbObject.DirTextDB = ApplicationDir
        sSql = "SELECT * FROM [DbDati.txt] where ChiaveImmobile='" & sKey & "'"
        ds = DbObject.GetFileTxtDataset(sSql)

        dw = New DataView(ds.Tables(0))
        For Each dataRowCurrent In dw
            lblInformation.Text = "Comune " & dataRowCurrent("Comune").ToString().Trim() & " Via " & dataRowCurrent("Indirizzo").ToString().Trim() & " N° " & dataRowCurrent("Civico").ToString().Trim()
        Next

    End Sub
    Public Sub StartTimer()
        btnClose.Left = _Width - 30 '- btnClose.Width
        pnlDescr.Width = _Width - 35
        TimerLoad.Enabled = True
    End Sub
    Private Sub TimerLoad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLoad.Tick
        If Width < _Width Then
            Width += 80
            'Opacity += 0.25

        End If
        If Height < _Height Then
            Height += 80
        End If
    End Sub
    Public Sub Hidecontrol()
        Me.Width = 1
        Me.Height = 1
        Refresh()
    End Sub

    Public Function RandomEnum(Of T)() As T
        Dim values As T() = DirectCast([Enum].GetValues(GetType(T)), T())
        Return values(New Random().[Next](0, values.Length))
    End Function

End Class
