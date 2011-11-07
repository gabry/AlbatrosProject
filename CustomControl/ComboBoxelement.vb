Public Class ComboBoxelement
    Private _IsSelected As Boolean
    Private _Key As String
    Public Property Key() As String
        Get
            Return _Key
        End Get
        Set(ByVal value As String)
            _Key = value
        End Set
    End Property
    Public Property IsSelected() As Boolean
        Get
            Return _IsSelected
        End Get
        Set(ByVal value As Boolean)
            _IsSelected = value
        End Set
    End Property
    Private Sub ComboBoxelement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        ' Declare a variable of type Graphics named formGraphics.

        ' Assign the address (reference) of this forms Graphics object

        '' to the formGraphics variable.

        'Dim formGraphics As Graphics = e.Graphics

        '' Declare a variable of type LinearGradientBrush named gradientBrush.

        '' Use a LinearGradientBrush constructor to create a new LinearGradientBrush object.

        '' Assign the address (reference) of the new object

        '' to the gradientBrush variable.

        ''Dim gradientBrush As New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.White, Color.FromArgb(&H43, &H53, &H7A))

        'Dim gradientBrush As New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.FromArgb(0, Color.FromArgb(&H43, &H53, &H7A)), Color.Black)

        '' Here are two more examples that create different gradients.

        '' Comment the Dim statement immediately above and uncomment one of these

        '' Dim statements to see how varying the two colors changes the gradient result.

        '' Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.Chartreuse, Color.SteelBlue)

        '' Dim gradientBrush As New LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.White, Color.SteelBlue)



        'formGraphics.FillRectangle(gradientBrush, ClientRectangle)

    End Sub

    Public Sub SelectMe()

        lblTitle.ForeColor = Color.White
        Me.BackColor = Color.LightBlue
    End Sub
    Public Sub DeSelectMe()

        lblTitle.ForeColor = Color.Black
        Me.BackColor = Color.White
    End Sub
End Class
