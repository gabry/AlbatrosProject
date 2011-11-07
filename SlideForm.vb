Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace SlideDialog
    Public Class SlideDialog
        Inherits System.Windows.Forms.Form
        Private components As System.ComponentModel.IContainer
        Private timer1 As System.Windows.Forms.Timer
        Protected _oOwner As Form
        Private _Xposition As String
        Public Property Xposition() As String
            Get
                Return _Xposition
            End Get
            Set(ByVal value As String)
                _Xposition = value
            End Set
        End Property
        Private _Yposition As String
        Public Property Yposition() As String
            Get
                Return _Yposition
            End Get
            Set(ByVal value As String)
                _Yposition = value
            End Set
        End Property
        Public Enum SLIDE_DIRECTION
            TOP
            LEFT
            BOTTOM
            RIGHT
        End Enum
        Protected _eSlideDirection As SLIDE_DIRECTION
        Private _fRatio As Single
        Private _fStep As Single
        Private _bExpand As Boolean
        Private _oOffset As SizeF
        Private _oStep As SizeF
        Private _oOrigin As Point
        ''' <summary>
        ''' Return the state of the form (expanded or not)
        ''' </summary>
        Public ReadOnly Property IsExpanded() As Boolean
            Get
                Return _bExpand
            End Get
        End Property
        ''' <summary>
        ''' Direction of sliding
        ''' </summary>
        Public WriteOnly Property SlideDirection() As SLIDE_DIRECTION
            Set(ByVal value As SLIDE_DIRECTION)
                _eSlideDirection = value
            End Set
        End Property
        ''' <summary>
        ''' Slide step of the motion
        ''' </summary>
        Public WriteOnly Property SlideStep() As Single
            Set(ByVal value As Single)
                _fStep = value
            End Set
        End Property
        ''' <summary>
        ''' Default constructor
        ''' </summary>
        Public Sub New()
            Me.New(Nothing, 0)
        End Sub
        ''' <summary>
        ''' Constructor with parent window and step of sliding motion
        ''' </summary>
        Public Sub New(ByVal poOwner As Form, ByVal pfStep As Single)
            InitializeComponent()
            _oOwner = poOwner
            _fRatio = 0.0F
            SlideStep = pfStep
            If poOwner IsNot Nothing Then
                Owner = poOwner.Owner
            End If
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        ''' le contenu de cette méthode avec l'éditeur de code.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.timer1 = New System.Windows.Forms.Timer(Me.components)
            ' 
            ' timer1
            ' 
            Me.timer1.Interval = 10
            AddHandler Me.timer1.Tick, New System.EventHandler(AddressOf Me.timer1_Tick)
            ' 
            ' SlideDialog
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(320, 192)
            Me.ControlBox = False
            Me.Name = "SlideDialog"
            Me.ShowInTaskbar = False

        End Sub
#End Region
        ''' <summary>
        ''' Use this method to start the slide motion (in ou out) 
        ''' according to the slide direction
        ''' </summary>
        Public Sub Slide()
            If Not _bExpand Then
                Show()
            End If
            _oOwner.BringToFront()
            _bExpand = Not _bExpand
            timer1.Start()
        End Sub

        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            If _bExpand Then
                _fRatio += _fStep
                _oOffset += _oStep
                If _fRatio >= 1 Then
                    timer1.[Stop]()
                End If
            Else
                _fRatio -= _fStep
                _oOffset -= _oStep
                If _fRatio <= 0 Then
                    timer1.[Stop]()
                End If
            End If
            SetLocation()
        End Sub
        Private Sub SetLocation()
            Location = _oOrigin + _oOffset.ToSize()
        End Sub

        Private Sub SlideDialog_Move(ByVal sender As Object, ByVal e As System.EventArgs)
            SetSlideLocation()
            SetLocation()
        End Sub

        Private Sub SlideDialog_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
            SetSlideLocation()
            SetLocation()
        End Sub
        Private Sub SlideDialog_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
            Close()
        End Sub

        Private Sub SetSlideLocation()
            If _oOwner IsNot Nothing Then
                _oOrigin = New Point()
                Select Case _eSlideDirection
                    Case SLIDE_DIRECTION.BOTTOM
                        _oOrigin.X = _oOwner.Location.X
                        _oOrigin.Y = _oOwner.Location.Y + _oOwner.Height - Height
                        Width = _oOwner.Width
                        _oStep = New SizeF(0, Height * _fStep)
                        Exit Select
                    Case SLIDE_DIRECTION.LEFT
                        _oOrigin = _oOwner.Location
                        _oStep = New SizeF(-Width * _fStep, 0)
                        Height = _oOwner.Height
                        Exit Select
                    Case SLIDE_DIRECTION.TOP
                        _oOrigin = _oOwner.Location
                        Width = _oOwner.Width
                        _oStep = New SizeF(0, -Height * _fStep)
                        Exit Select
                    Case SLIDE_DIRECTION.RIGHT
                        _oOrigin.X = _Xposition ' _oOwner.Location.X + _oOwner.Width - Width
                        _oOrigin.Y = _Yposition '_oOwner.Location.Y
                        _oStep = New SizeF(Width * _fStep, 0)
                        Height = _oOwner.Height
                        Exit Select
                End Select
            End If
        End Sub
        Protected Overloads Overrides Sub OnLoad(ByVal e As System.EventArgs)
            SetSlideLocation()
            SetLocation()
            If _oOwner IsNot Nothing Then
                AddHandler _oOwner.LocationChanged, New System.EventHandler(AddressOf Me.SlideDialog_Move)
                AddHandler _oOwner.Resize, New System.EventHandler(AddressOf Me.SlideDialog_Resize)

                AddHandler _oOwner.Closed, New System.EventHandler(AddressOf Me.SlideDialog_Closed)
            End If
        End Sub
    End Class
End Namespace
