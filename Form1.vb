Public Class FormMain
    
    Public cd As New Usercontrol()
    Dim _oslideform As FormKeyBoard

    'Public Sub New()
    '    InitializeComponent()


    'End Sub

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nTimer As Long


        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)

        ConfigOpt.Initialize(Application.StartupPath & "\Configclient.cfg")

        Select Case ConfigOpt.GetOption("TipoFrequenza")
            Case "S"
                nTimer = 1000

            Case "M"
                nTimer = 60000
            Case "O"
                nTimer = 360000
        End Select

        tmrLoad.Interval = ConfigOpt.GetOption("FqrUpdate") * nTimer
        tmrLoad.Enabled = True

        Me.BackColor = Color.Black
        Me.Width = ScreenWidth
        Me.Height = ScreenHeight
        Me.CenterToScreen()
        LoadImage()
        ResizeControl()

      

        '_oslideform = New FormKeyBoard(Me, 0.1F)

        '_oslideform.Xposition = Search.Location.X + Search.Width
        '_oslideform.Xposition = Search.Location.Y
    End Sub
  

    Private Sub LoadImage()


        Dim sSql As String
        Dim ds As DataSet
        Dim dataRowCurrent As DataRowView
        Dim dw As DataView
        Dim nTop As Integer
        Dim sNameImage As String
        Dim sFile() As String
        Dim i As Integer

        DbObject.DirTextDB = ApplicationDir

        sSql = "SELECT * FROM [FOTO.txt] where ORDINAMENTO='1'"

        DbObject.DirTextDB = ApplicationDir '& "\Dbdati.txt"

        ds = DbObject.GetFileTxtDataset(sSql)

        dw = New DataView(ds.Tables(0))

        ReDim sFile(dw.Count - 1)



    End Sub
    Public Sub ResizeControl()
        'Dim sLogo As String = PathImage & "logo.jpg"
        'Dim bm_source As New Bitmap(sLogo)

        'pctLogo.Width = (ScreenWidth / 100) * 20
        'pctLogo.Height = (Height / 100) * 20

        'Dim bm_dest As New Bitmap(CInt(pctLogo.Width - 10), CInt(pctLogo.Height))

        '' Make a Graphics object for the result Bitmap.
        'Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        '' Copy the source image into the destination bitmap.
        'gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

        '' Display the result.
        'pctLogo.Image = bm_dest

      

        Search.Height = (ScreenHeight / 100) * 70
        Search.Width = (ScreenWidth / 100) * 36
        'Search.ResizeControl()

        Search.CustomSearch1.Height = Search.Height
        Search.CustomSearch1.Width = Search.Width
        Search.CustomSearch1.ResizeControl(Search.CustomSearch1.Height, Search.Width)
        'cd.Width = ScreenWidth
        'cd.Height = 552
        cd.Width = 1
        cd.Height = 1
        cd.Left = 50
        cd.Top = pctLogo.Height + 50

        cd.Visible = False
        AddHandler cd.btnClose.Click, AddressOf Chiudi


        AddHandler Search.CustomSearch1.txtRif.Click, AddressOf SlideKeyboard
        AddHandler Search.CustomSearch1.txtRif.LostFocus, AddressOf HideKeyboard


        Me.Controls.Add(cd)

        CustomKeyboard1.Width = (ScreenWidth / 100) * 64
        CustomKeyboard1.Keyboardcontrol1.Width = CustomKeyboard1.Width
        CustomKeyboard1.Height = (Search.Height / 100) * 50
        CustomKeyboard1.Keyboardcontrol1.Height = CustomKeyboard1.Height

        CustomKeyboard1.Left = Search.CustomSearch1.Location.X + Search.CustomSearch1.Width
        CustomKeyboard1.Top = Me.Height
        CustomKeyboard1.OriginLocation = CustomKeyboard1.Location
    End Sub
    Private Sub hideKeyboard(ByVal sender As Object, ByVal e As System.EventArgs)
        CustomKeyboard1.slide()
    End Sub
    Private Sub SlideKeyboard(ByVal sender As Object, ByVal e As System.EventArgs)
        '_oslideform.SlideDirection = SlideDialog.SlideDialog.SLIDE_DIRECTION.RIGHT
        '_oslideform.Slide()
        'CustomKeyboard1.Visible = True
        'CustomKeyboard1.StartTimerFadeIn()

        'Dialog(New FormKeyboard(Search.CustomSearch1.txtRif))
        'Dim frmKeyboard As New FormKeyboard(Search.CustomSearch1.txtRif)

        'frmKeyboard.Show()

        Dim cntsender As TextBox

        cntsender = CType(sender, TextBox)

        CustomKeyboard1.SetStep = 0.1F

        CustomKeyboard1.SetControlToWrite(cntsender)
        CustomKeyboard1.slide()
    End Sub
    Private Sub Chiudi(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Controls.Remove(cd)
        cd.Visible = False
        cd.Hidecontrol()

    End Sub
    ' Override the OnPaint event for this form.

    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

    '    ' Declare a variable of type Graphics named formGraphics.

    '    ' Assign the address (reference) of this forms Graphics object

    '    ' to the formGraphics variable.

    '    Dim formGraphics As Graphics = e.Graphics

    '    ' Declare a variable of type LinearGradientBrush named gradientBrush.

    '    ' Use a LinearGradientBrush constructor to create a new LinearGradientBrush object.

    '    ' Assign the address (reference) of the new object

    '    ' to the gradientBrush variable.

    '    'Dim gradientBrush As New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.White, Color.FromArgb(&H43, &H53, &H7A))

    '    Dim gradientBrush As New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.FromArgb(0, Color.FromArgb(&H43, &H53, &H7A)), Color.SteelBlue)

    '    ' Here are two more examples that create different gradients.

    '    ' Comment the Dim statement immediately above and uncomment one of these

    '    ' Dim statements to see how varying the two colors changes the gradient result.

    '    ' Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.Chartreuse, Color.SteelBlue)

    '    ' Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.White, Color.SteelBlue)



    '    formGraphics.FillRectangle(gradientBrush, ClientRectangle)

    'End Sub


    Private Sub tmrLoad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLoad.Tick
        tmrLoad.Enabled = False
        LoadImage()
        tmrLoad.Enabled = True
    End Sub

End Class
