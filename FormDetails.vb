Public Class FormDetails

    Private Sub FormDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Opacity += 0.01

    End Sub

    Public Sub StartTimer()
        TimerShow.Enabled = True
    End Sub
    Private Sub TimerShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerShow.Tick
        If Width < 501 Then
            Width += 15
            Opacity += 0.25

        End If
    End Sub
End Class