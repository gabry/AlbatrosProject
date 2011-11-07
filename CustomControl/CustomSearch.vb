Public Class CustomSearch
    Private CtlArray As New ArrayList
    Dim intX, intY As Integer
    Dim Xratio, Yratio As Single
    Dim _width As Integer

    Public Function ResizeControl(ByVal nHeight As Integer, ByVal nWidth As Integer)
        Dim Ratio As Integer
        Dim c As Control

        Ratio = nHeight / 7


        'For Each c In Me.Controls
        '    If c.Top <> 0 Then
        '        c.Top = c.Top + Ratio
        '    End If


        'Next


        intX = Screen.PrimaryScreen.WorkingArea.Width
        intY = Screen.PrimaryScreen.WorkingArea.Height

        Xratio = Int(intX / nWidth)
        Yratio = intY / nHeight
        _width = nWidth

        'Get the controls on the form, including menus, but not the controls in other containers
        For Each Cnt As Control In Me.Controls

            If TypeOf Cnt Is gLabel.gLabel Then
                'Cnt.Height = (Me.Height / 100) * 20
                Cnt.Font = New Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold)
            End If

            If TypeOf Cnt Is BBBNOVA.BNComboBox Then
                Cnt.Font = New Font(FontFamily.GenericSansSerif, 40, FontStyle.Regular)
            End If
            If TypeOf Cnt Is TextBox Then
                ' cnt.Height = (Me.Height / 100) * 20
                Cnt.Font = New Font(FontFamily.GenericSansSerif, 35, FontStyle.Bold)
            End If
            CtlArray.Add(Cnt)
        Next

        'Get the children controls
        'GetTheChildren()

        'Adjust New size and position
        ResizeThem()

        'LoadDati()
        'Dim s As String() = {"1", "2", "3"}

        'ComboboxSimul1.AddElement(s)




        cmbCategoria.AddControl()
        cmbcontratto.AddControl()
        cmbProvince.AddControl()
        cmbTipologia.AddControl()
    End Function
    'Public Function LoadDati()

    '    Dim ValueContratto As New Dictionary(Of String, String)

    '    ValueContratto.Add("01", "Tutti")
    '    ValueContratto.Add("02", "Vendita")
    '    ValueContratto.Add("03", "Affitto")
    '    ValueContratto.Add("04", "Vacanza")

    '    cmbcontratto.DataSource = New BindingSource(ValueContratto, "")
    '    cmbcontratto.DisplayMember = "Value"
    '    cmbcontratto.ValueMember = "Key"
    '    cmbcontratto.Items.Add("Apple")

    'End Function
    Private Sub GetTheChildren()
        'Gets the controls inside containes like panels or tabcontrols
        'For Each ctl As Control In GetAllControls(Me.Parent)
        For Each ctl As Control In GetAllControls(Me)
            If ctl.Parent IsNot Me Then
                If TypeOf ctl.Parent Is TabPage Then
                    If ctl.Name = "" Then
                        CtlArray.Add(ctl)
                    Else
                        CtlArray.Add(ctl)
                    End If
                Else
                    If Not TypeOf (ctl) Is TabPage Then
                        If ctl.Name = "" Then
                            CtlArray.Add(ctl)
                        Else
                            CtlArray.Add(ctl)
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub ResizeThem()
        Dim i As Integer
        Dim szf As SizeF
        Dim HalfLeft As Integer = 0
        Dim LeftButton As Integer
        Dim HeightCombo As Integer
        Dim bm_source As Bitmap
        Dim bm_dest As Bitmap

        Dim addtop As Integer = _width / 7

        For i = 0 To CtlArray.Count - 1
            If TypeOf CtlArray.Item(i) Is MenuStrip Then
            Else
                If TypeOf CtlArray.Item(i) Is Panel And CtlArray.Item(i).parent IsNot Me Then
                    'SplitPanel for instance
                Else
                    CtlArray.Item(i).autosize = False
                    CtlArray.Item(i).dock = 0
                    CtlArray.Item(i).height = CtlArray.Item(i).height * Yratio + 20
                    CtlArray.Item(i).top = CtlArray.Item(i).top * Yratio
                    If TypeOf CtlArray.Item(i) Is BBBNOVA.BNComboBox Then
                        CtlArray.Item(i).left = CtlArray.Item(i).left * (Xratio / 2) '+ 20
                        LeftButton = CtlArray.Item(i).left
                        CtlArray.Item(i).width = CtlArray.Item(i).left + CtlArray.Item(i).width
                        CtlArray.Item(i).DropDownWidth = CtlArray.Item(i).width - 5

                    ElseIf TypeOf CtlArray.Item(i) Is CButtonLib.CButton Then

                        CtlArray.Item(i).left = CtlArray.Item(i).left * (Xratio / 2) '+ 20
                        LeftButton = CtlArray.Item(i).left
                        CtlArray.Item(i).width = CtlArray.Item(i).left + CtlArray.Item(i).width

                        bm_source = New Bitmap(PathImage & "DownArrow.png")
                        bm_dest = New Bitmap(CInt((CtlArray.Item(i).width / 100) * 50), CtlArray.Item(i).height)

                        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

                        ' Copy the source image into the destination bitmap.
                        gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

                        CtlArray.Item(i).Image = bm_dest
                        CtlArray.Item(i).ImageAlign = ContentAlignment.MiddleRight

                    ElseIf TypeOf CtlArray.Item(i) Is TextBox Then
                        CtlArray.Item(i).autosize = True

                        If InStr(CtlArray.Item(i).tag, "Half") = 1 Then
                            CtlArray.Item(i).width = CtlArray.Item(i).width * 2

                            If CtlArray.Item(i).tag.ToString.EndsWith("_1") Then

                                CtlArray.Item(i).left = LeftButton 'CtlArray.Item(i).left * (Xratio / 2)
                                HalfLeft = CtlArray.Item(i).left + CtlArray.Item(i).width

                            Else
                                CtlArray.Item(i).left = LeftButton + (CtlArray.Item(i).width * 1.55)
                            End If



                        Else
                            CtlArray.Item(i).left = CtlArray.Item(i).left * (Xratio / 2)
                            szf = GetSizeColumns(CtlArray.Item(i), CtlArray.Item(i).font)
                            CtlArray.Item(i).width = CtlArray.Item(i).left + CtlArray.Item(i).width
                        End If


                    ElseIf TypeOf CtlArray.Item(i) Is gLabel.gLabel Then
                        szf = GetSizeColumns(CtlArray.Item(i), CtlArray.Item(i).font)
                        CtlArray.Item(i).width = CtlArray.Item(i).width + (szf.Width / 2)
                    End If


                End If
            End If
        Next
    End Sub

    Function GetAllControls(ByVal container As Control) As Control()
        Dim al As New ArrayList
        Dim ctl As Control
        For Each ctl In container.Controls
            GetControlsWithChildren(ctl, al)
        Next
        Return al.ToArray(GetType(Control))
    End Function

    Sub GetControlsWithChildren(ByVal container As Control, ByVal al As ArrayList)
        ' add this control to the ArrayList
        al.Add(container)
        ' add all its child controls, by calling this routine recursively
        Dim ctl As Control

        For Each ctl In container.Controls
            'A TabPage is a Panel; SplitContainer is a Panel
            GetControlsWithChildren(ctl, al)
        Next

    End Sub
    'Public Function ResizeControl()
    '    Dim cnt As Control
    '    Dim szF As SizeF

    '    For Each cnt In Me.Controls
    '        If TypeOf cnt Is gLabel.gLabel Then
    '            cnt.Height = (Me.Height / 100) * 20
    '            cnt.Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
    '        End If

    '        If TypeOf cnt Is BBBNOVA.BNComboBox Then
    '            ' cnt.Height = (Me.Height / 100) * 20

    '            cnt.Font = New Font(FontFamily.GenericSansSerif, 48, FontStyle.Bold)
    '            'If cnt.Top <> 46 Then
    '            szF = GetSizeColumns(cnt, cnt.Font)
    '            cnt.Top = szF.Height * cnt.TabIndex
    '            'End If
    '        End If
    '        If TypeOf cnt Is TextBox Then
    '            ' cnt.Height = (Me.Height / 100) * 20
    '            cnt.Font = New Font(FontFamily.GenericSansSerif, 48, FontStyle.Bold)
    '            If cnt.Top <> 0 Then
    '                cnt.Top = cnt.Top + 60
    '            End If
    '        End If
    '    Next

    'End Function
    Public Function GetSizeColumns(ByRef c As Control, ByVal Fnt As Font) As SizeF
        Dim g As Graphics = CreateGraphics()
        Dim maxSize As Integer = 0
        Dim size As SizeF
        Dim sizeColumn As SizeF


        'prendo la larghezza del nome della colonna
        sizeColumn = g.MeasureString(c.Text, Fnt)

        'If bResize = True Then
        '    For Each row As DataRow In dt.Rows
        '        size = g.MeasureString(row(ColumnName).ToString(), grid.Font)

        '        If size.Width > maxSize Then
        '            maxSize = CInt(size.Width)
        '        End If
        '    Next

        '    If maxSize < sizeColumn.Width Then
        '        maxSize = sizeColumn.Width + 10
        '    End If
        'Else

        '    maxSize = sizeColumn.Width
        'End If



        Return sizeColumn
        'Return maxSize + nAdd
    End Function
    'Public Function GetSizeColumns(ByVal dt As DataTable, ByVal ColumnName As String, ByVal sHeaderText As String, ByVal grid As DataGrid, Optional ByVal bResize As Boolean = True, Optional ByVal nAdd As Integer = 10) As Integer



    'End Function

    Private Sub CButton2_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dialog(New FormFilter(FormFilter.FilterType.Contratto))

    End Sub

    'Private Sub cmbcontratto_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cmbcontratto.DrawItem

    '    'If e.Index < 0 Then
    '    '    'Don't We Have A List ¿
    '    '    e.DrawBackground()
    '    '    e.DrawFocusRectangle()
    '    '    Return
    '    'End If
    '    'Dim value As KeyValuePair(Of String, String)

    '    'value = DirectCast(cmbcontratto.Items(e.Index), KeyValuePair(Of String, String))

    '    ''Get Colour Object From Items List 
    '    'Dim CurrColour As Color = Color.Red

    '    ''Create A Rectangle To Fit New Item 
    '    'Dim ColourSize As New Rectangle(2, e.Bounds.Top + 2, e.Bounds.Width, e.Bounds.Height - 2)


    '    ''New Colour Brush To Draw With
    '    'e.DrawBackground()
    '    ''Draw Item's Background
    '    ''e.DrawFocusRectangle()
    '    ''Draw Item's Focus Rectangle
    '    ''If e.State = System.Windows.Forms.DrawItemState.Selected Then
    '    ''    'If Item Selected
    '    ''    'Change To White
    '    ''    ColourBrush = Brushes.White
    '    ''Else
    '    ''    'Change Back to Black
    '    ''    ColourBrush = Brushes.Black
    '    ''End If

    '    ''e.Graphics.DrawRectangle(New Pen(CurrColour), ColourSize)
    '    'Dim gradientBrush As New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.FromArgb(0, Color.FromArgb(&H43, &H53, &H7A)), Color.Gray)


    '    ''Draw New Item Rectangle With Current Colour
    '    'e.Graphics.FillRectangle(gradientBrush, ColourSize)
    '    ''Fill New Item rectangle With Current Colour
    '    ''Add Border Around Rectangle
    '    ''ColourSize.Inflate(1, 1)
    '    ''Border Size
    '    ''e.Graphics.DrawRectangle(Pens.Black, ColourSize)
    '    ''Draw New Border
    '    ''Draw Current Colour Name, In The Middle 
    '    'e.Graphics.DrawString(value.Value, BnComboBox1.Font, Brushes.White, e.Bounds.Height + 5, ((e.Bounds.Height - BnComboBox1.Font.Height) \ 2) + e.Bounds.Top)
    '    Dim g As Graphics = e.Graphics

    '    ' Get the bounding rectangle of the item currently being painted
    '    Dim r As Rectangle = e.Bounds
    '    Dim fn As Font = Nothing
    '    r.Width = cmbcontratto.Width
    '    If e.Index >= 0 Then
    '        ' Get the Font object, at the specifid index in the fontArray

    '        ' Get the text that we wish to display
    '        Dim value As KeyValuePair(Of String, String)

    '        value = DirectCast(cmbcontratto.Items(e.Index), KeyValuePair(Of String, String))

    '        ' Set the string format options
    '        Dim sf As New StringFormat()
    '        sf.Alignment = StringAlignment.Near
    '        Dim gradientBrush As New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(Width, 0), Color.FromArgb(0, Color.FromArgb(&H43, &H53, &H7A)), Color.Gray)


    '        ' Draw the rectangle
    '        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 2), r)

    '        If e.State = DrawItemState.None Then
    '            e.Graphics.FillRectangle(New SolidBrush(Color.White), r)
    '            e.Graphics.DrawString(value.Value, cmbCategoria.Font, New SolidBrush(Color.Black), r, sf)
    '            e.DrawFocusRectangle()
    '        Else
    '            e.Graphics.FillRectangle(New SolidBrush(Color.LightBlue), r)
    '            e.Graphics.DrawString(value.Value, cmbCategoria.Font, New SolidBrush(Color.Black), r, sf)
    '            e.DrawFocusRectangle()
    '        End If


    '        'If e.State = DrawItemState.None Then ' (DrawItemState.NoAccelerator Or DrawItemState.NoFocusRect) Then
    '        '    ' if the item is not selected draw it with a different color
    '        '    e.Graphics.FillRectangle(gradientBrush, r)
    '        '    e.Graphics.DrawString(value.Value, BnComboBox1.Font, New SolidBrush(Color.Black), r, sf)
    '        '    e.DrawFocusRectangle()
    '        'Else
    '        '    ' if the item is selected draw it with a different color
    '        '    e.Graphics.FillRectangle(gradientBrush, r)
    '        '    e.Graphics.DrawString(value.Value, BnComboBox1.Font, New SolidBrush(Color.Red), r, sf)
    '        '    e.DrawFocusRectangle()
    '        'End If
    '    End If
    'End Sub
    Public Class SeparatorItem
        Private data As Object
        Public Sub New(ByVal data As Object)
            Me.data = data
        End Sub
        Public Overloads Overrides Function ToString() As String
            If data IsNot Nothing Then
                Return data.ToString()
            End If

            Return MyBase.ToString()
        End Function

    End Class
    'Public Shared Sub SetComboScrollWidth(ByVal sender As Object)
    '    Try
    '        Dim senderComboBox As BBBNOVA.BNComboBox = DirectCast(sender, BBBNOVA.BNComboBox)
    '        Dim width As Integer = senderComboBox.Width
    '        Dim g As Graphics = senderComboBox.CreateGraphics()
    '        Dim font As Font = senderComboBox.Font

    '        'checks if a scrollbar will be displayed.
    '        'If yes, then get its width to adjust the size of the drop down list.
    '        Dim vertScrollBarWidth As Integer = IIf((senderComboBox.Items.Count > senderComboBox.MaxDropDownItems), SystemInformation.VerticalScrollBarWidth, 0)

    '        'Loop through list items and check size of each items.
    '        'set the width of the drop down list to the width of the largest item.

    '        Dim newWidth As Integer
    '        For Each s As KeyValuePair(Of String, String) In DirectCast(sender, BBBNOVA.BNComboBox).Items

    '            newWidth = CInt(g.MeasureString(s.Value, font).Width) + vertScrollBarWidth
    '            If width < newWidth Then
    '                width = newWidth
    '            End If

    '        Next
    '        senderComboBox.DropDownWidth = width
    '    Catch objException As Exception
    '        'Catch objException
    '    End Try
    'End Sub

    Public Shared Sub SetComboScrollHeight(ByVal sender As Object)
        Try
            Dim senderComboBox As BBBNOVA.BNComboBox = DirectCast(sender, BBBNOVA.BNComboBox)
            Dim cboheight As Integer = 800 'senderComboBox.Height
            Dim g As Graphics = senderComboBox.CreateGraphics()
            Dim font As Font = senderComboBox.Font

            'Loop through list items and check size of each items.
            'increment the newheight to be the size of the items
            Dim newHeight As Integer = cboheight
            For Each s As KeyValuePair(Of String, String) In DirectCast(sender, BBBNOVA.BNComboBox).Items

                newHeight += CInt(g.MeasureString(s.Value, font).Height) '+ vertScrollBarWidth

            Next
            senderComboBox.DropDownHeight = newHeight
        Catch objException As Exception
            'Catch objException
        End Try
    End Sub

    'Private Sub cmbcontratto_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles cmbcontratto.MeasureItem
    '    e.ItemHeight = cmbcontratto.Height
    '    'e.ItemWidth = cmbcontratto.Width

    'End Sub

    Private Sub CustomSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub cmbCategoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoria.Click
        Dim ValueCategoria As New Dictionary(Of String, String)

        ValueCategoria.Add("01", "Tutte")
        ValueCategoria.Add("02", "Residenziale")
        ValueCategoria.Add("03", "Commerciale")
        ValueCategoria.Add("04", "Rustici e terreni")
        ValueCategoria.Add("05", "Uffici e fondi")

        cmbSimulCategoria.AddElement(ValueCategoria, cmbCategoria.DropDownWidth, cmbCategoria)

    End Sub

   

    Private Sub cmbcontratto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcontratto.Click
        Dim Valuecontratto As New Dictionary(Of String, String)

        Valuecontratto.Add("01", "Tutti")
        Valuecontratto.Add("02", "Vendita")
        Valuecontratto.Add("03", "Affitto")
        Valuecontratto.Add("04", "Vacanza")

        cmbSimulcontratto.AddElement(Valuecontratto, cmbcontratto.DropDownWidth, cmbcontratto)


    End Sub

  
    Private Sub cmbProvince_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvince.Click
        Dim ValueProvince As New Dictionary(Of String, String)

        ValueProvince.Add("01", "Alessandria")
        ValueProvince.Add("02", "Ancona")
        ValueProvince.Add("03", "Arezzo")
        ValueProvince.Add("04", "Firenze")
        ValueProvince.Add("05", "Forli-Cesena")
        ValueProvince.Add("06", "GENOVA")
        ValueProvince.Add("07", "GROSSETO")
        ValueProvince.Add("08", "LIVORNO")
        ValueProvince.Add("09", "LUCCA")
        ValueProvince.Add("10", "MACERATA")
        ValueProvince.Add("11", "PISA")
        ValueProvince.Add("12", "LIVORNO")
        ValueProvince.Add("13", "LUCCA")
        cmbSimulProvince.AddElement(ValueProvince, cmbProvince.DropDownWidth, cmbProvince)

    End Sub

    Private Sub cmbTipologia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipologia.Click
        Dim ValueTipologie As New Dictionary(Of String, String)
        ValueTipologie.Add("18", "Agriturismo")
        ValueTipologie.Add("2", "Albergo")
        ValueTipologie.Add("43", "Annesso agricolo")
        ValueTipologie.Add("3", "Appartamento")
        ValueTipologie.Add("30", "Appartamento indipendente")
        ValueTipologie.Add("31", "Attico")
        ValueTipologie.Add("4", "Attività commerciale")
        ValueTipologie.Add("5", "Azienda agricola")
        ValueTipologie.Add("6", "Baita")
        ValueTipologie.Add("26", "Bar")
        ValueTipologie.Add("8", "Capannone industriale")
        ValueTipologie.Add("34", "Casa semi indipendente")
        ValueTipologie.Add("7", "Casa singola")
        ValueTipologie.Add("9", "Castello")
        ValueTipologie.Add("22", "Colonica")
        ValueTipologie.Add("16", "Garage")
        ValueTipologie.Add("19", "Locale commerciale")
        ValueTipologie.Add("21", "Magazzino")
        ValueTipologie.Add("14", "Negozio")
        ValueTipologie.Add("49", "Nuova costruzione")
        ValueTipologie.Add("23", "Palazzo")
        ValueTipologie.Add("41", "Pizzeria / Pub")
        ValueTipologie.Add("36", "Residence")
        ValueTipologie.Add("27", "Ristorante")
        ValueTipologie.Add("12", "Rustico casale")
        ValueTipologie.Add("17", "Stabile")
        ValueTipologie.Add("42", "Tenuta-Complesso")
        ValueTipologie.Add("24", "Terratetto")
        ValueTipologie.Add("46", "Terreno agricolo")
        ValueTipologie.Add("44", "Terreno edificabile")
        ValueTipologie.Add("13", "Ufficio")
        ValueTipologie.Add("10", "Villa")
        ValueTipologie.Add("32", "Villa a schiera")
        ValueTipologie.Add("33", "Villa bifamiliare")
        ValueTipologie.Add("29", "Villino")

        cmbSimulTipologia.AddElement(ValueTipologie, cmbTipologia.DropDownWidth, cmbTipologia)

    End Sub
End Class
