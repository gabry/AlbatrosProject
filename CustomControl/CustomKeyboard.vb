Public Class CustomKeyboard
    Private _ControlToWrite As Control
    Private _fRatio As Single
    Private _fstep As Single
    Private _offSet As SizeF
    Private _oStep As SizeF
    Private _Expand As Boolean = False
    Private _oorigin As Point
    Private _bMove As Boolean = False
    Public Property OriginLocation() As Point
        Get
            Return _oorigin
        End Get
        Set(ByVal value As Point)
            _oorigin = value
        End Set
    End Property

    Public Property SetStep() As Single
        Get
            Return _fstep
        End Get
        Set(ByVal value As Single)
            _fstep = value
        End Set
    End Property
    Public Sub SetControlToWrite(ByRef _cnt As Control)
        _ControlToWrite = _cnt
    End Sub


    Private Sub Keyboardcontrol1_UserKeyPressed(ByVal sender As System.Object, ByVal e As KeyboardClassLibrary.KeyboardEventArgs) Handles Keyboardcontrol1.UserKeyPressed
        _ControlToWrite.Focus()
        SendKeys.Send(e.KeyboardKeyPressed)
    End Sub

    Public Sub slide()

        _Expand = Not _Expand
        tmrFadeIn.Start()
    End Sub
    Private Sub tmrFadeIn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFadeIn.Tick
        _bMove = True
        If _Expand Then
            _fRatio += _fstep
            _offSet += _oStep
            If _fRatio >= 1 Then
                tmrFadeIn.Stop()
            End If
        Else
            _fRatio -= _fstep
            _offSet -= _oStep
            If _fRatio <= 0 Then
                tmrFadeIn.Stop()
            End If
        End If
        SetSlideLocation()
        SetLocation()

    End Sub
    Private Sub SetLocation()
        Location = _oorigin + _offSet.ToSize()
    End Sub
    Private Sub SetSlideLocation()

        ' _oorigin = New Point()
        'Select Case _eSlideDirection
        '    Case SLIDE_DIRECTION.BOTTOM
        '        _oorigin.X = _oOwner.Location.X
        '        _oorigin.Y = _oOwner.Location.Y + _oOwner.Height - Height
        '        Width = _oOwner.Width
        '        _oStep = New SizeF(0, Height * _fstep)
        '        Exit Select
        '    Case SLIDE_DIRECTION.LEFT
        '        _oorigin = _oOwner.Location
        '        _oStep = New SizeF(-Width * _fstep, 0)
        '        Height = _oOwner.Height
        '        Exit Select
        'Case SLIDE_DIRECTION.TOP


        _oStep = New SizeF(0, -Height * _fstep)
        'Exit Select
        '    Case SLIDE_DIRECTION.RIGHT
        '_oorigin.X = _oOwner.Location.X + _oOwner.Width - Width
        '_oorigin.Y = _oOwner.Location.Y
        '_oStep = New SizeF(Width * _fstep, 0)
        'Height = _oOwner.Height
        'Exit Select
        'End Select
        'End If
    End Sub


    'Private Sub CustomKeyboard_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    SetSlideLocation()
    '    SetLocation()
    'End Sub
    'Protected Overloads Overrides Sub OnLoad(ByVal e As System.EventArgs)
    '    SetSlideLocation()
    '    SetLocation()


    'End Sub

End Class
