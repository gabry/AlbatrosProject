Public Class FormKeyboard
    Private _TextborRef As TextBox
  
    Public Sub New(ByRef Txtbox As TextBox)
        InitializeComponent()
        _TextborRef = Txtbox
        Timer1.Enabled = True
    End Sub

    Private Sub FormKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()
       
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim opacityFade As Single

        For opacityFade = 0 To 1 Step 0.01
            Me.Opacity = opacityFade
            Me.Refresh()
            System.Threading.Thread.Sleep(10)
        Next opacityFade
        Me.Opacity = 1

        Timer1.Enabled = False
    End Sub
    Private Sub keyboardcontrol1_UserKeyPressed(ByVal sender As Object, ByVal e As KeyboardClassLibrary.KeyboardEventArgs)
    
    End Sub
    Public Sub Starttimer()
        Timer1.Enabled = True

    End Sub

    Private Sub Keyboardcontrol1_UserKeyPressed_1(ByVal sender As System.Object, ByVal e As KeyboardClassLibrary.KeyboardEventArgs) Handles Keyboardcontrol1.UserKeyPressed
        _TextborRef.Focus()
        SendKeys.Send(e.KeyboardKeyPressed)
    End Sub
End Class