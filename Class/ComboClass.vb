Imports System.Runtime.InteropServices
Public Class ComboClass

    Private comboBox As BBBNOVA.BNComboBox
    Private handle As IntPtr
#Region "P/Invokes"
    Const CB_GETDROPPEDWIDTH As Integer = 351
    Const CB_SETDROPPEDWIDTH As Integer = 352
    Const CB_SHOWDROPDOWN As Integer = 335
    <DllImport("user32.dll")> _
    Private Shared Function GetCapture() As IntPtr
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
#End Region
    Public Sub New(ByVal comboBox As BBBNOVA.BNComboBox)
        Me.comboBox = comboBox
        ' Get native handle
        Me.comboBox.Capture = True
        Me.handle = GetCapture()
        Me.comboBox.Capture = False
    End Sub
    Public Property DropDownWidth() As Integer
        Get
            Return GetDropDownWidth()
        End Get
        Set(ByVal value As Integer)
            SetDropDownWidth(value)
        End Set
    End Property
    Public Property SetShowDropDown() As Integer
        Get
            Return GetDropDownWidth()
        End Get
        Set(ByVal value As Integer)
            ShowDropDown(value)
        End Set
    End Property
    Private Sub SetDropDownWidth(ByVal width As Integer)
        SendMessage(handle, CB_SETDROPPEDWIDTH, width, 0)
    End Sub
    Private Function GetDropDownWidth() As Integer
        Return SendMessage(handle, CB_GETDROPPEDWIDTH, 0, 0)
    End Function
    Private Sub ShowDropDown(ByVal Options As Integer)
        SendMessage(handle, CB_SHOWDROPDOWN, Options, 0)
    End Sub
End Class

