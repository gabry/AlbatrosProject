'
'
'
'
'
Public Class scrollSkin
    Private WithEvents _win As Windows.Forms.Control = Nothing
    Private Const WM_HSCROLL As Integer = 276
    Private Const WM_VSCROLL As Integer = 277
    Private Const SB_THUMBPOSITION As Integer = 4
    Private Const SIF_TRACKPOS As Integer = 16
    Private Const SIF_RANGE As Integer = 1
    Private Const SIF_POS As Integer = 4
    Private Const SIF_PAGE As Integer = 2
    Private Const SIF_ALL As Integer = SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS
    Declare Function SetScrollInfo Lib "user32" (ByVal hwnd As Integer, ByVal n As Integer, ByRef lpcScrollInfo As ScrollInfoStruct, ByVal bool As Boolean) As Integer
    <Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function SetScrollPos(ByVal hWnd As System.IntPtr, ByVal nBar As Integer, ByVal nPos As Integer, ByVal bRedraw As Boolean) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> _
Private Shared Function GetScrollInfo(ByVal hWnd As IntPtr, ByVal n As Integer, ByRef lpScrollInfo As ScrollInfoStruct) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function GetScrollPos(ByVal hWnd As System.IntPtr, ByVal nBar As Integer) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function PostMessageA(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, _
    ByVal wParam As Integer, ByVal lParam As Integer) As Boolean
    End Function
    '
    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="SendMessage")> _
    Private Shared Sub SendMessage( _
            ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, _
            ByVal wParam As Integer, ByVal lParam As Integer _
            )
    End Sub
    Public si As ScrollInfoStruct
    Public si2 As ScrollInfoStruct
    Public Structure ScrollInfoStruct
        Public cbSize As Integer
        Public fMask As Integer
        Public nMin As Integer
        Public nMax As Integer
        Public nPage As Integer
        Public nPos As Integer
        Public nTrackPos As Integer
    End Structure
    ''' <summary>
    ''' Drag and drop control needs this New()
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    ''' <summary>
    ''' Coded manually lets you to use this New(control)
    ''' </summary>
    ''' <param name="win"></param>
    ''' <remarks></remarks>
    Sub New(ByVal win As System.Windows.Forms.Control)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        _win = win
        Controls.Add(win)
        ' Fix the fake scrolling control to overlap the real scrollable control
        Me.VScrollBar1.Size = New System.Drawing.Size(18, _win.Height)
        Me.Size = New System.Drawing.Size(_win.Width, _win.Height)
        Me.Location = New System.Drawing.Point(_win.Left, _win.Top)
        Me.Dock = _win.Dock
        _win.Top = 0 : _win.Left = 0
        _win.SendToBack()
        Me.Name = "skin" + _win.Name

    End Sub

    ''' <summary>
    ''' Overrided to controll del scrolling of the customControl VScrollBar1
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub Wndproc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If Me.DesignMode Then Exit Sub

        If Not Me.Parent.CanFocus Or IsNothing(_win) Then Exit Sub
        si.fMask = SIF_ALL
        si.cbSize = Runtime.InteropServices.Marshal.SizeOf(si)
        GetScrollInfo(_win.Handle, 1, si)
        If (si.nMax + 0) < si.nPage Then
            Me.VScrollBar1.Visible = False
        Else
            Me.VScrollBar1.Visible = True
            If si.nPage = 0 Then Exit Sub
            VScrollBar1.Maximum = si.nMax - si.nPage + 1
            VScrollBar1.Minimum = si.nMin
            VScrollBar1.Value = si.nPos
            VScrollBar1.LargeChange = si.nMax / si.nPage
            VScrollBar1.SyncThumbPositionWithLogicalValue()
        End If



    End Sub
    ''' <summary>
    ''' Comming from the customControl
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub VScrollBar1_miScroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.miScroll
        PostMessageA(_win.Handle, WM_VSCROLL, SB_THUMBPOSITION + 65536 * VScrollBar1.Value, 0)

        'previously explored:
        'SendMessage(_win.Handle, WM_VSCROLL, e.Type, 0)
    End Sub

    ''' <summary>
    ''' Linking the Scrollable control with Me
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub scrollSkin_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        If Controls.Count = 1 Then Exit Sub
        If Not IsNothing(_win) Then Exit Sub
        _win = e.Control

    End Sub
    ''' <summary>
    ''' Almost done move and resize the Scrollable control over Me 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub win_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles _win.Resize
        Me.VScrollBar1.Size = New System.Drawing.Size(18, _win.Height)
        Me.Size = New System.Drawing.Size(_win.Width, _win.Height)
        Me.VScrollBar1.Left = _win.Right - 18
        _win.Top = 0 : _win.Left = 0
    End Sub
End Class
