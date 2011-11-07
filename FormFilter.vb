Public Class FormFilter
    Public Enum FilterType
        Contratto = 1
        Categoria = 2
        Province = 3
    End Enum
    Public _FltType As FilterType
    Public Sub New(ByVal fltType As FilterType)

        MyBase.New()

        InitializeComponent()

        _FltType = fltType

    End Sub
    Private Sub FormFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '  Me.CenterToScreen()
        Me.Left = ScreenWidth / 3
        Me.Top = ScreenHeight / 3
        Me.Width = (ScreenWidth * 40) / 100
        Me.Height = (ScreenHeight * 70) / 100
        Loadfilter(_FltType)

    End Sub
    Private Sub Loadfilter(ByVal fltType As FilterType)

        Dim sSql As String
        Dim ds As DataSet
        Dim dataRowCurrent As DataRowView
        Dim dw As DataView
        Dim tn As Ai.Control.TreeNode
       
        mltMain.Columns.Clear()
        mltMain.Nodes.Clear()
        mltMain.FullRowSelect = True
        mltMain.Width = Me.Width
        mltMain.Height = Me.Height
        mltMain.Font = New Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold)

        mltMain.Columns.Add("Filtro")
        mltMain.Columns(0).EnableFiltering = False
        mltMain.Columns(0).Width = Me.Width
        '      mltMain.Columns(0).
        ' mltMain.Columns(0).
        'mltMain.
        Select Case fltType
            Case FilterType.Contratto
                tn = New Ai.Control.TreeNode
                tn.Text = "AFFITTI"
                mltMain.Nodes.Add(tn)
                tn = New Ai.Control.TreeNode
                tn.Text = "COMPRA"
                mltMain.Nodes.Add(tn)
        End Select
    End Sub
End Class