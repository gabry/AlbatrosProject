'Thanks to:
'   http://home.tiscali.be/zoetrope
'   Copyright (C) 2006  SFJOIBSUTUFZBFSU
'
'    flyhigh 
'
'   All CodeProject's members...
' No copyright, free for all of us
'
'

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.IO

Namespace customScoll

    Enum ArrowDirections
        Left
        Up
        Right
        Down
    End Enum
    ''' <summary>
    ''' This class do the hard part of painting (but OnPaint is on the superclass ScrollBar
    ''' </summary>
    ''' <remarks></remarks>
    Class ControlPaint
        Public Shared Sub DrawArrow(ByVal g As Graphics, ByVal r As Rectangle, ByVal dir As ArrowDirections, ByVal raised As Boolean)
            Dim w As Int32 = r.Width
            Dim h As Int32 = r.Height

            If w <= 0 OrElse h <= 0 Then
                Return
            End If
            If dir = ArrowDirections.Down Then
                ScrollBar.imArrow.RotateFlip(RotateFlipType.Rotate180FlipX)
            End If
            r.Inflate(1, 1)
            Dim tmp As Region = g.Clip
            Dim clip As New Region(r)
            g.Clip = clip
            g.DrawImage(ScrollBar.imArrow, r)
            'g.DrawImageUnscaledAndClipped(arrow, r)
            'g.DrawImage(arrow, r)
            clip.Dispose()
            g.Clip = tmp
            If dir = ArrowDirections.Down Then
                ScrollBar.imArrow.RotateFlip(RotateFlipType.Rotate180FlipX)
            End If

        End Sub

        Public Shared Sub DrawBorder(ByVal g As Graphics, ByVal r As Rectangle, ByVal inset As Boolean)
            'Exit Sub
            Dim topleft As Color = IIf(inset, MotifColors.ControlDarkDark, MotifColors.ControlLightLight)
            Dim rightbottom As Color = IIf(inset, MotifColors.ControlLightLight, MotifColors.ControlDarkDark)

            Dim pen As New Pen(topleft)

            g.DrawLine(pen, r.X, r.Y, r.Right - 1, r.Y)
            g.DrawLine(pen, r.X, r.Y + 1, r.Right - 1, r.Y + 1)

            g.DrawLine(pen, r.X, r.Y, r.X, r.Bottom - 1)
            g.DrawLine(pen, r.X + 1, r.Y, r.X + 1, r.Bottom - 2)
            'le quito el 3D
            ' pen = New Pen(rightbottom)

            g.DrawLine(pen, r.X + 2, r.Bottom - 2, r.Right - 1, r.Bottom - 2)
            g.DrawLine(pen, r.X + 1, r.Bottom - 1, r.Right - 1, r.Bottom - 1)

            g.DrawLine(pen, r.Right - 1, r.Y + 1, r.Right - 1, r.Bottom - 1)
            g.DrawLine(pen, r.Right - 2, r.Y + 2, r.Right - 2, r.Bottom - 1)

            pen.Dispose()
        End Sub

    End Class
    Enum ScrollBarAction
        SmallDecrement
        SmallIncrement
        LargeDecrement
        LargeIncrement
        ThumbPosition
        ThumbTrack
        First
        Last
        EndScroll
        None
    End Enum

    ''' <summary>
    ''' CustomControl give the guide and the base for VScroll
    ''' </summary>
    ''' <remarks></remarks>
    MustInherit Class ScrollBar
        Inherits UserControl
        Protected _minimum As Int32 = 0
        Protected _maximum As Int32 = 100
        Protected _value As Int32 = 0
        Protected _smallchange As Int32 = 1
        Protected _largechange As Int32 = 10
        Protected _thumbpos As Int32 = 0
        Protected _diffmousedownthumboffset As Int32
        Protected _sba As ScrollBarAction = ScrollBarAction.None
        Protected _sbaflag As Boolean = False
        Protected _thumbvisible As Boolean = True
        Protected _timer As Timer
        Protected _mousex As Int32
        Protected _mousey As Int32
        Public Shared imArrow As Bitmap
        Public Shared imThumb As Bitmap
        Public Shared imFondoScroll As Bitmap
        Friend Shared imEndThumb As Bitmap

        Protected Sub New()

            Dim spath As String = "C:\dev\AlbatrosProject\AlbatrosProject\CustomControl\customScrollBar\Images\"
            SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
            imArrow = Image.FromFile(spath & "arrow.bmp") '  GetEmbeddedImage("arrow.bmp")
            imThumb = Image.FromFile(spath & "thumb.bmp")
            imFondoScroll = Image.FromFile(spath & "fondoScroll.bmp")

            imEndThumb = Image.FromFile(spath & "thumbbot.bmp")
        End Sub
        'Private Function GetEmbeddedImage(ByVal name$) As Bitmap
        '    Dim myAssembly As Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        '    Dim myStream As Stream = myAssembly.GetManifestResourceStream("IPEuropa." & name)
        '    Dim tImage As Bitmap = New Bitmap(myStream)
        '    Return tImage

        'End Function

        ' The pixel domain is the number of pixels the thumb can actually move.

        Protected MustOverride ReadOnly Property SmallDecrementRectangle() As Rectangle
        Protected MustOverride ReadOnly Property LargeDecrementRectangle() As Rectangle
        Protected MustOverride ReadOnly Property ThumbRectangle() As Rectangle
        Protected MustOverride ReadOnly Property ThumbBarRectangle() As Rectangle
        Protected MustOverride ReadOnly Property LargeIncrementRectangle() As Rectangle
        Protected MustOverride ReadOnly Property SmallIncrementRectangle() As Rectangle
        Protected MustOverride ReadOnly Property SmallDecrementArrowDirection() As ArrowDirections
        Protected MustOverride ReadOnly Property SmallIncrementArrowDirection() As ArrowDirections
        Protected MustOverride ReadOnly Property PixelDomain() As Int32

        Public Property Minimum() As Int32
            Get
                Return _minimum
            End Get
            Set(ByVal value As Int32)
                If value > _maximum Then
                    Throw New ArgumentOutOfRangeException("Minimum", "Minimum cannot be greater than Maximum.")
                End If
                _minimum = value
                Invalidate()
            End Set
        End Property

        Public Property Maximum() As Int32
            Get
                Return _maximum
            End Get
            Set(ByVal value As Int32)
                If value < _minimum Then
                    Throw New ArgumentOutOfRangeException("Maximum", "Maximum cannot be less than Minimum.")
                End If
                _maximum = value
                Invalidate()
            End Set
        End Property

        Public Property Value() As Int32
            Get
                Return _value
            End Get
            Set(ByVal value As Int32)
                If value < _minimum OrElse value > _maximum Then
                    Throw New ArgumentOutOfRangeException("Value", "Value must be in range [Minimum,Maximum].")
                End If

                If _value <> value Then
                    _value = value

                    ' Do not invalidate arrows.
                    Invalidate(Me.ThumbBarRectangle)
                    OnValueChanged(EventArgs.Empty)
                End If
            End Set
        End Property

        Public Property SmallChange() As Int32
            Get
                Return _smallchange
            End Get
            Set(ByVal value As Int32)
                If value < 0 Then
                    Throw New ArgumentOutOfRangeException("SmallChange", [String].Format("Value must be in range [0,{0}].", Int32.MaxValue))
                End If
                _smallchange = value
            End Set
        End Property

        Public Property LargeChange() As Int32
            Get
                Return _largechange
            End Get
            Set(ByVal value As Int32)
                If value < 0 Then
                    Throw New ArgumentOutOfRangeException("LargeChange", [String].Format("Value must be in range [0,{0}].", Int32.MaxValue))
                End If
                _largechange = value
            End Set
        End Property

        ' The thumb position is used when the thumb is moved with the mouse.
        ' It is not possible to directly calculate the new Value and then
        ' invalidate the thumb bar because the thumb could be moved a bit to
        ' the left or to the right. So, we keep the actual position the user
        ' has moved the thumb in a separate variable.

        Private Property ThumbPosition() As Int32
            Get
                Return _thumbpos
            End Get
            Set(ByVal value As Int32)
                _thumbpos = value
                Dim pixeldomain As Int32 = Me.PixelDomain

                If value < 0 Then
                    _thumbpos = 0
                End If
                If value > pixeldomain Then
                    _thumbpos = pixeldomain

                End If

                ' Translate thumb position to logical value.

                Dim domain As Double = _maximum - _minimum
                If domain > 0 Then
                    Me.Value = _thumbpos / pixeldomain * domain
                Else
                    Me.Value = _minimum
                End If

            End Set
        End Property

        Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            'The back of the scroll
            Dim brush As New TextureBrush(imFondoScroll, WrapMode.TileFlipY, New Rectangle(0, 0, 16, 4))
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
            'The border 
            ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, True)
            'Both arrows
            ControlPaint.DrawArrow(e.Graphics, Me.SmallDecrementRectangle, Me.SmallDecrementArrowDirection, Not ((_sba = ScrollBarAction.SmallDecrement) AndAlso _sbaflag))
            ControlPaint.DrawArrow(e.Graphics, Me.SmallIncrementRectangle, Me.SmallIncrementArrowDirection, Not ((_sba = ScrollBarAction.SmallIncrement) AndAlso _sbaflag))

            If _thumbvisible Then
                ' Draw thumb.

                Dim r As Rectangle = Me.ThumbRectangle
                'brush = New SolidBrush(MotifColors.Control)

                r.Inflate(1, 1)
                Dim tmp As Region = e.Graphics.Clip
                Dim clip As New Region(r)
                e.Graphics.Clip = clip
                r.Height = r.Height - 3
                'e.Graphics.DrawImageUnscaled(imThumb, r)
                e.Graphics.FillRectangle(New TextureBrush(imThumb, WrapMode.TileFlipY, New Rectangle(0, 0, 16, 4)), r)
                imEndThumb.RotateFlip(RotateFlipType.Rotate180FlipX)
                e.Graphics.DrawImage(imEndThumb, r.Left, r.Bottom - 3)
                imEndThumb.RotateFlip(RotateFlipType.Rotate180FlipX)
                e.Graphics.DrawImage(imEndThumb, r.Left, r.Top)


                clip.Dispose()
                e.Graphics.Clip = tmp

            End If

            brush.Dispose()
        End Sub

        Public Sub SyncThumbPositionWithLogicalValue()
            Dim domain As Double = _maximum - _minimum
            If domain > 0 Then
                _thumbpos = (_value / domain * Me.PixelDomain)
            Else
                _thumbpos = 0
            End If
            Invalidate()
        End Sub

        Private Sub SmallIncrement()
            Dim newvalue As Int32 = _value + _smallchange
            If newvalue > _maximum Then
                newvalue = _maximum
            End If
            Me.Value = newvalue
            SyncThumbPositionWithLogicalValue()
            RaiseEvent miScroll(Me, New ScrollEventArgs(ScrollEventType.SmallIncrement, 1))

        End Sub

        Private Sub SmallDecrement()
            Dim newvalue As Int32 = _value - _smallchange
            If newvalue < _minimum Then
                newvalue = _minimum
            End If
            Me.Value = newvalue
            SyncThumbPositionWithLogicalValue()

        End Sub

        Private Sub LargeIncrement()
            Dim newvalue As Int32 = _value + _largechange
            If newvalue > _maximum Then
                newvalue = _maximum
            End If
            Me.Value = newvalue
            SyncThumbPositionWithLogicalValue()
        End Sub

        Private Sub LargeDecrement()
            Dim newvalue As Int32 = _value - _largechange
            If newvalue < _minimum Then
                newvalue = _minimum
            End If
            Me.Value = newvalue
            SyncThumbPositionWithLogicalValue()

        End Sub

        Private Sub StartTimer()
            If _timer Is Nothing Then
                _timer = New Timer()
                AddHandler _timer.Tick, AddressOf OnTimerTick
            End If
            _timer.Interval = 250
            _timer.Start()
        End Sub

        Protected Overloads Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If e.Button = MouseButtons.Left Then
                Dim r As Rectangle = Me.ThumbRectangle
                If _thumbvisible AndAlso _largechange < _maximum AndAlso r.Contains(e.X, e.Y) Then

                    ' Thumb clicked.
                    If TypeOf Me Is HScrollBar Then
                        _diffmousedownthumboffset = e.X - r.Left
                    Else
                        _diffmousedownthumboffset = e.Y - r.Top
                    End If
                    Me.Capture = True

                    _sba = ScrollBarAction.ThumbTrack
                Else
                    r = Me.SmallDecrementRectangle
                    If r.Contains(e.X, e.Y) Then

                        ' Left arrow clicked.
                        Me.Capture = True
                        _sba = ScrollBarAction.SmallDecrement
                        _sbaflag = True
                        Invalidate(r)

                        If _value <> _minimum Then

                            ' Decrement one SmallChange.
                            SmallDecrement()

                            ' Start timer for repeated decrements.

                            StartTimer()

                        End If
                    Else
                        r = Me.SmallIncrementRectangle
                        If r.Contains(e.X, e.Y) Then

                            ' Right arrow clicked.
                            Me.Capture = True
                            _sba = ScrollBarAction.SmallIncrement
                            _sbaflag = True
                            Invalidate(r)

                            If _value <> _maximum Then

                                ' Increment one SmallChange
                                SmallIncrement()

                                ' Start timer for repeated increments.

                                StartTimer()

                            End If
                        Else
                            r = Me.LargeDecrementRectangle
                            If r.Contains(e.X, e.Y) Then

                                ' Left page clicked.
                                Me.Capture = True
                                _sba = ScrollBarAction.LargeDecrement
                                _sbaflag = True
                                _mousex = e.X
                                _mousey = e.Y

                                If _value <> _minimum Then

                                    ' Decrement one LargeChange.
                                    LargeDecrement()

                                    ' Start timer for repeated decrements.

                                    StartTimer()

                                End If
                            Else
                                r = Me.LargeIncrementRectangle
                                If r.Contains(e.X, e.Y) Then

                                    ' Right page clicked.
                                    Me.Capture = True
                                    _sba = ScrollBarAction.LargeIncrement
                                    _sbaflag = True
                                    _mousex = e.X
                                    _mousey = e.Y

                                    If _value <> _maximum Then

                                        ' Increment one LargeChange.
                                        LargeIncrement()

                                        ' Start timer for repeated increments.

                                        StartTimer()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                RaiseEvent miScroll(Me, New ScrollEventArgs(_sba, _value))
                'Debug.WriteIf(_sba = ScrollBarAction.ThumbTrack, _value)
            End If
        End Sub

        Protected Overloads Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            If e.Button = MouseButtons.Left Then
                If _sba = ScrollBarAction.ThumbTrack Then
                    If _thumbvisible Then
                        If TypeOf Me Is HScrollBar Then
                            Me.ThumbPosition = (e.X - _diffmousedownthumboffset) - (2 + Me.SmallDecrementRectangle.Width + 1)
                        Else
                            Me.ThumbPosition = (e.Y - _diffmousedownthumboffset) - (2 + Me.SmallDecrementRectangle.Height + 1)
                        End If
                        RaiseEvent miScroll(Me, New ScrollEventArgs(_sba, _value))

                    End If
                ElseIf _sba = ScrollBarAction.SmallDecrement Then
                    Dim r As Rectangle = Me.SmallDecrementRectangle
                    _sbaflag = r.Contains(e.X, e.Y)
                    Invalidate(r)
                    If _timer IsNot Nothing Then
                        _timer.Enabled = _sbaflag
                    End If
                ElseIf _sba = ScrollBarAction.SmallIncrement Then
                    Dim r As Rectangle = Me.SmallIncrementRectangle
                    _sbaflag = r.Contains(e.X, e.Y)
                    Invalidate(r)
                    If _timer IsNot Nothing Then
                        _timer.Enabled = _sbaflag
                    End If
                ElseIf _sba = ScrollBarAction.LargeDecrement Then
                    Dim r As Rectangle = Me.LargeDecrementRectangle
                    If _timer IsNot Nothing Then
                        _timer.Enabled = r.Contains(e.X, e.Y)
                    End If
                    _mousex = e.X
                    _mousey = e.Y
                ElseIf _sba = ScrollBarAction.LargeIncrement Then
                    Dim r As Rectangle = Me.LargeIncrementRectangle
                    If _timer IsNot Nothing Then
                        _timer.Enabled = r.Contains(e.X, e.Y)
                    End If
                    _mousex = e.X
                    _mousey = e.Y
                End If
            End If
        End Sub

        Protected Overloads Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)

            If e.Button = MouseButtons.Left Then
                Me.Capture = False
                _sba = ScrollBarAction.None
                _sbaflag = False
                Invalidate()
                If _timer IsNot Nothing Then
                    _timer.Dispose()
                    _timer = Nothing
                End If
            End If
        End Sub

        Private Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
            If _timer.Interval = 250 Then
                _timer.Interval = 50
                ' inital delay
            End If
            ' repeated delay
            If _sba = ScrollBarAction.SmallDecrement Then
                If _value <> _minimum Then
                    SmallDecrement()
                End If
            ElseIf _sba = ScrollBarAction.SmallIncrement Then
                If _value <> _maximum Then
                    SmallIncrement()
                End If
            ElseIf _sba = ScrollBarAction.LargeDecrement Then
                Dim r As Rectangle = Me.LargeDecrementRectangle
                If r.Contains(_mousex, _mousey) Then
                    If _value <> _minimum Then
                        LargeDecrement()
                    End If
                End If
            ElseIf _sba = ScrollBarAction.LargeIncrement Then
                Dim r As Rectangle = Me.LargeIncrementRectangle
                If r.Contains(_mousex, _mousey) Then
                    If _value <> _maximum Then
                        LargeIncrement()
                    End If
                End If
            End If
            RaiseEvent miScroll(Me, New ScrollEventArgs(_sba, 1))

        End Sub

        Protected Overloads Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)

            SyncThumbPositionWithLogicalValue()
        End Sub

        Public Event ValueChanged As EventHandler

        Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
            RaiseEvent ValueChanged(Me, e)
        End Sub

        Public Event miScroll As ScrollEventHandler

        'Protected Overloads Sub OnScroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
        '    RaiseEvent Scroll(Me, e)
        'End Sub

    End Class

    '''///////////////////////////////////////////////////////////////////////////

    Class HScrollBar
        Inherits ScrollBar



        Public Sub New()
            Me.Height = 15
        End Sub

        Protected Overloads Overrides ReadOnly Property SmallDecrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle

                x = 2
                y = 2
                w = r.Height - 2 - 2
                If w > (r.Width - 2 - 2) / 2 Then
                    w = (r.Width - 2 - 2) / 2
                End If
                h = r.Height - 2 - 2

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property SmallIncrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle

                y = 2
                h = r.Height - 2 - 2
                w = r.Height - 2 - 2
                If w > (r.Width - 2 - 2) / 2 Then
                    w = (r.Width - 2 - 2) / 2
                    If (r.Width And 1) = 1 Then
                        w += 1
                    End If
                End If
                x = r.Right - (w + 2)

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property LargeDecrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle

                x = r.Height - 2 + 1
                y = 2
                w = _thumbpos
                h = Me.Height - 2 - 2

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property LargeIncrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle
                Dim thumb As Rectangle = Me.ThumbRectangle

                x = thumb.X + thumb.Width
                y = 2
                w = r.Right - (r.Height - 2) - x
                h = Me.Height - 2 - 2

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property ThumbRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle
                Dim arrowrect As Rectangle = Me.SmallDecrementRectangle

                ' We have to add 1 because when Minimum = 0 and Maximum = 0,
                ' we want a thumb which is half the size of the bar.
                Dim domain As Double = _maximum - _minimum + 1

                ' If LargeChange >= Maximum, we want a full thumb.
                If _largechange >= _maximum Then
                    w = Me.Width - (2 + Me.SmallDecrementRectangle.Width + 1) * 2
                Else
                    w = ((Me.Width - (2 + Me.SmallDecrementRectangle.Width + 1) * 2) / (domain / _largechange))
                End If

                ' Minimum size of thumb is 6 pixels.
                If w < 6 Then
                    w = 6
                End If

                y = 2
                h = r.Height - 2 - 2
                x = (2 + arrowrect.Width + 1) + _thumbpos

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property ThumbBarRectangle() As Rectangle
            Get
                Dim arrow As Rectangle = Me.SmallDecrementRectangle
                Return New Rectangle(2 + arrow.Width + 1, 2, Me.Width - (2 + arrow.Width + 1) * 2, Me.Height - 2 - 2)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property SmallDecrementArrowDirection() As ArrowDirections
            Get
                Return ArrowDirections.Left
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property SmallIncrementArrowDirection() As ArrowDirections
            Get
                Return ArrowDirections.Right
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property PixelDomain() As Int32
            Get
                Return (Me.Width - (2 + Me.SmallDecrementRectangle.Width + 1) * 2) - Me.ThumbRectangle.Width
            End Get
        End Property

        Protected Overloads Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)

            _thumbvisible = Me.Width - (2 + Me.SmallDecrementRectangle.Width + 1) * 2 >= 6
        End Sub
    End Class

    '''///////////////////////////////////////////////////////////////////////////

    Class VScrollBar
        Inherits ScrollBar
        Public Sub New()
            Me.Width = 15
        End Sub

        Protected Overloads Overrides ReadOnly Property SmallDecrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle

                x = 2
                y = 2
                w = r.Width - 2 - 2
                h = r.Width - 2 - 2
                If h > (r.Height - 2 - 2) / 2 Then
                    h = (r.Height - 2 - 2) / 2
                End If

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property SmallIncrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle

                x = 2
                h = r.Width - 2 - 2
                If h > (r.Height - 2 - 2) / 2 Then
                    h = (r.Height - 2 - 2) / 2
                    If (r.Height And 1) = 1 Then
                        h += 1
                    End If
                End If
                w = r.Width - 2 - 2
                y = r.Bottom - (h + 2)

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property LargeDecrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle

                x = 2
                y = r.Width - 2 + 1
                w = Me.Width - 2 - 2
                h = _thumbpos

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property LargeIncrementRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle
                Dim thumb As Rectangle = Me.ThumbRectangle

                x = 2
                y = thumb.Y + thumb.Height
                w = Me.Width - 2 - 2
                h = r.Bottom - (r.Width - 2) - y

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property ThumbRectangle() As Rectangle
            Get
                Dim x As Int32, y As Int32, w As Int32, h As Int32
                Dim r As Rectangle = Me.ClientRectangle
                Dim arrowrect As Rectangle = Me.SmallDecrementRectangle

                ' We have to add 1 because when Minimum = 0 and Maximum = 0,
                ' we want a thumb which is half the size of the bar.
                Dim domain As Double = _maximum - _minimum + 1

                ' If LargeChange > Maximum, we want a full thumb.
                If _largechange > _maximum Then
                    h = Me.Height - (2 + Me.SmallDecrementRectangle.Height + 1) * 2
                Else
                    h = ((Me.Height - (2 + Me.SmallDecrementRectangle.Height + 1) * 2) / (domain / _largechange))
                End If

                ' Minimum size of thumb is 6 pixels.
                If h < 6 Then
                    h = 6
                End If

                x = 2
                w = r.Width - 2 - 2
                y = ((2 + arrowrect.Height + 1) + _thumbpos)

                Return New Rectangle(x, y, w, h)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property ThumbBarRectangle() As Rectangle
            Get
                Dim arrow As Rectangle = Me.SmallDecrementRectangle
                Return New Rectangle(2, 2 + arrow.Height + 1, Me.Width - 2 - 2, Me.Height - (2 + arrow.Height + 1) * 2)
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property SmallDecrementArrowDirection() As ArrowDirections
            Get
                Return ArrowDirections.Up
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property SmallIncrementArrowDirection() As ArrowDirections
            Get
                Return ArrowDirections.Down
            End Get
        End Property

        Protected Overloads Overrides ReadOnly Property PixelDomain() As Int32
            Get
                Return (Me.Height - (2 + Me.SmallDecrementRectangle.Height + 1) * 2) - Me.ThumbRectangle.Height
            End Get
        End Property

        Protected Overloads Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)

            _thumbvisible = Me.Height - (2 + Me.SmallDecrementRectangle.Height + 1) * 2 >= 6
        End Sub

    End Class
    ''' <summary>
    ''' Themed  color, could be in properties...
    ''' </summary>
    ''' <remarks></remarks>
    Class MotifColors
        Public Shared ReadOnly Control As Color = Color.FromArgb(216, 220, 216)
        Public Shared ReadOnly ControlDarkDark As Color = Color.CornflowerBlue '.Color.FromArgb(120, 124, 120)
        Public Shared ReadOnly ControlLightLight As Color = Color.Lavender '.FromArgb(232, 240, 232)
        'this is subtituted with a bitmap brush
        Public Shared ReadOnly ScrollBar As Color = Color.Silver '.Gainsboro '.FromArgb(184, 188, 184)
        Public Shared ReadOnly Window As Color = Color.FromArgb(216, 220, 216)
    End Class
End Namespace
' namespace



