Public Class ComboboxSimul
    Private oldpos As Integer
    Private _Parentcombo As BBBNOVA.BNComboBox
    Private _KeySelected As String
    Public Property KeySelected() As String
        Get
            Return _KeySelected
        End Get
        Set(ByVal value As String)
            _KeySelected = value
        End Set
    End Property

    Public Sub AddElement(ByVal Value As Dictionary(Of String, String), ByVal nWidth As Integer, ByRef ParentCombo As BBBNOVA.BNComboBox)

        Dim i As Integer = 0
        Dim _Top As Integer = 0
        Dim element As ComboBoxelement
        Dim heigthElement As Integer
        Dim Vocielement As New Bornander.UI.SmoothListbox


        _Parentcombo = ParentCombo

        ' Loop over entries.
        Dim pair As KeyValuePair(Of String, String)
        For Each pair In Value
            element = New ComboBoxelement
            element.lblTitle.Text = pair.Value
            element.Key = pair.Key
            element.Height = 100
            element.Width = nWidth ' (nWidth / 100) * 90
            element.BackColor = Color.White
            ''element.Top = _Top
            ''_Top = _Top + 100
            heigthElement = element.Height
            Vocielement.AddItem(element)
            AddHandler (element.Click), AddressOf ColorElement
            AddHandler (element.lblTitle.Click), AddressOf ColorElement
            Me.Controls.Add(Vocielement)
        Next
        


        Me.Height = heigthElement * 2
        Vocielement.BackColor = Color.Black
        Vocielement.Width = nWidth ' (nWidth / 100) * 100
        Vocielement.Top = 0
        Vocielement.Height = Me.Height



    End Sub
    Private Sub ColorElement(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ce As ComboBoxelement
        Dim c, cson As Control
        Dim ceTemp As ComboBoxelement
        Dim lblTemp As Label
        Dim pnl As Panel


        If TypeOf sender Is Label Then
            lblTemp = CType(sender, Label)
            For Each c In Me.Controls
                If TypeOf c Is Bornander.UI.SmoothListbox Then

                    For Each cson In c.Controls
                        If TypeOf cson Is Panel Then


                            pnl = cson
                            For Each ceTemp In pnl.Controls
                                If lblTemp.Text = ceTemp.lblTitle.Text Then
                                    ceTemp.SelectMe()
                                    _KeySelected = ceTemp.Key
                                    _Parentcombo.Text = ceTemp.lblTitle.Text
                                    _Parentcombo.Refresh()

                                Else
                                    ceTemp.DeSelectMe()

                                End If
                            Next
                            'ceTemp = CType(cson, ComboBoxelement)


                        End If

                    Next
                End If

            Next

        ElseIf TypeOf sender Is ComboBoxelement Then
            ce = CType(sender, ComboBoxelement)


            For Each c In Me.Controls

                If TypeOf c Is Bornander.UI.SmoothListbox Then

                    For Each cson In c.Controls
                        If TypeOf cson Is Panel Then


                            pnl = cson
                            For Each ceTemp In pnl.Controls
                                If ceTemp.Equals(ce) Then
                                    ceTemp.SelectMe()
                                    _KeySelected = ceTemp.Key
                                    _Parentcombo.Text = ceTemp.lblTitle.Text
                                    _Parentcombo.Refresh()

                                Else
                                    ceTemp.DeSelectMe()

                                End If
                            Next
                            'ceTemp = CType(cson, ComboBoxelement)


                        End If

                    Next
                End If

            Next
        End If


      


        'If Not TypeOf c Is CustomControls.CustomScrollbar Then

        '    ceTemp = CType(c, ComboBoxelement)

        '    If ceTemp.Equals(ce) Then
        '        ceTemp.SelectMe()
        '    Else
        '        ceTemp.DeSelectMe()

        '    End If
        'End If


    End Sub

    Private Sub ComboboxSimul_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        'Me.UserControl11 = New scrollSkin(TextBox1)


        'ScrollSkin1 = New scrollSkin(ListBox1)
        'e.UserControl12.TabIndex = 1


        'Me.Controls.Add(Me.UserControl12)

    End Sub

    Private Sub CustomScrollbar1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub scrollbar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim c As Control


    '    Me.SuspendLayout()

    '    For Each c In Me.Controls
    '        If Not TypeOf c Is CustomControls.CustomScrollbar Then
    '            c.Top = c.Top + oldpos - ScrollBar.Value
    '        End If


    '    Next
    '    oldpos = ScrollBar.Value

    '    Me.ResumeLayout()
    'End Sub
End Class
