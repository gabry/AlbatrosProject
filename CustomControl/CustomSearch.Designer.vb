<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomSearch
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CBlendItems1 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems2 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems3 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems4 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems5 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems6 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems7 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems8 As gLabel.cBlendItems = New gLabel.cBlendItems
        Dim CBlendItems9 As gLabel.cBlendItems = New gLabel.cBlendItems
        Me.GLabel2 = New gLabel.gLabel
        Me.GLabel3 = New gLabel.gLabel
        Me.GLabel4 = New gLabel.gLabel
        Me.txtRif = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.GLabel5 = New gLabel.gLabel
        Me.GLabel6 = New gLabel.gLabel
        Me.GLabel7 = New gLabel.gLabel
        Me.GLabel8 = New gLabel.gLabel
        Me.GLabel1 = New gLabel.gLabel
        Me.cmbOrdine = New BBBNOVA.BNComboBox
        Me.cmbSimulProvince = New AlbatrosProject.ComboboxSimul
        Me.cmbSimulcontratto = New AlbatrosProject.ComboboxSimul
        Me.cmbCategoria = New BBBNOVA.BNComboBox
        Me.cmbSimulCategoria = New AlbatrosProject.ComboboxSimul
        Me.cmbProvince = New BBBNOVA.BNComboBox
        Me.cmbcontratto = New BBBNOVA.BNComboBox
        Me.cmbTipologia = New BBBNOVA.BNComboBox
        Me.GLabel9 = New gLabel.gLabel
        Me.cmbSimulTipologia = New AlbatrosProject.ComboboxSimul
        Me.SuspendLayout()
        '
        'GLabel2
        '
        Me.GLabel2.BorderWidth = 1.0!
        Me.GLabel2.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel2.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel2.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems1.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel2.ForeColorBlend = CBlendItems1
        Me.GLabel2.Glow = 8
        Me.GLabel2.GlowColor = System.Drawing.Color.LightSteelBlue
        Me.GLabel2.Location = New System.Drawing.Point(0, 0)
        Me.GLabel2.MouseOver = False
        Me.GLabel2.Name = "GLabel2"
        Me.GLabel2.PulseSpeed = 25
        Me.GLabel2.Size = New System.Drawing.Size(91, 21)
        Me.GLabel2.TabIndex = 2
        Me.GLabel2.Text = "Contratto"
        Me.GLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel3
        '
        Me.GLabel3.BorderWidth = 1.0!
        Me.GLabel3.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel3.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel3.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems2.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel3.ForeColorBlend = CBlendItems2
        Me.GLabel3.Glow = 8
        Me.GLabel3.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel3.Location = New System.Drawing.Point(0, 70)
        Me.GLabel3.MouseOver = False
        Me.GLabel3.Name = "GLabel3"
        Me.GLabel3.PulseSpeed = 25
        Me.GLabel3.Size = New System.Drawing.Size(92, 21)
        Me.GLabel3.TabIndex = 4
        Me.GLabel3.Text = "Categoria"
        Me.GLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel4
        '
        Me.GLabel4.BorderWidth = 1.0!
        Me.GLabel4.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel4.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel4.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems3.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel4.ForeColorBlend = CBlendItems3
        Me.GLabel4.Glow = 8
        Me.GLabel4.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel4.Location = New System.Drawing.Point(0, 210)
        Me.GLabel4.MouseOver = False
        Me.GLabel4.Name = "GLabel4"
        Me.GLabel4.PulseSpeed = 25
        Me.GLabel4.Size = New System.Drawing.Size(85, 21)
        Me.GLabel4.TabIndex = 6
        Me.GLabel4.Text = "Province"
        Me.GLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRif
        '
        Me.txtRif.Location = New System.Drawing.Point(204, 280)
        Me.txtRif.Name = "txtRif"
        Me.txtRif.Size = New System.Drawing.Size(279, 20)
        Me.txtRif.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(204, 350)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(279, 20)
        Me.TextBox2.TabIndex = 5
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(204, 420)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(91, 20)
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Tag = "Half_1"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(391, 420)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(92, 20)
        Me.TextBox4.TabIndex = 7
        Me.TextBox4.Tag = "Half_2"
        '
        'GLabel5
        '
        Me.GLabel5.BorderWidth = 1.0!
        Me.GLabel5.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel5.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel5.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems4.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel5.ForeColorBlend = CBlendItems4
        Me.GLabel5.Glow = 8
        Me.GLabel5.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel5.Location = New System.Drawing.Point(0, 490)
        Me.GLabel5.MouseOver = False
        Me.GLabel5.Name = "GLabel5"
        Me.GLabel5.PulseSpeed = 25
        Me.GLabel5.Size = New System.Drawing.Size(66, 21)
        Me.GLabel5.TabIndex = 12
        Me.GLabel5.Text = "Ordine"
        Me.GLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel6
        '
        Me.GLabel6.BorderWidth = 1.0!
        Me.GLabel6.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel6.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel6.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems5.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems5.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel6.ForeColorBlend = CBlendItems5
        Me.GLabel6.Glow = 8
        Me.GLabel6.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel6.Location = New System.Drawing.Point(0, 350)
        Me.GLabel6.MouseOver = False
        Me.GLabel6.Name = "GLabel6"
        Me.GLabel6.PulseSpeed = 25
        Me.GLabel6.Size = New System.Drawing.Size(51, 21)
        Me.GLabel6.TabIndex = 13
        Me.GLabel6.Text = "Zona"
        Me.GLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel7
        '
        Me.GLabel7.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GLabel7.BorderWidth = 3.0!
        Me.GLabel7.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel7.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel7.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems6.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems6.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel7.ForeColorBlend = CBlendItems6
        Me.GLabel7.Glow = 8
        Me.GLabel7.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel7.Location = New System.Drawing.Point(0, 280)
        Me.GLabel7.MouseOver = False
        Me.GLabel7.Name = "GLabel7"
        Me.GLabel7.PulseSpeed = 25
        Me.GLabel7.Size = New System.Drawing.Size(114, 21)
        Me.GLabel7.TabIndex = 14
        Me.GLabel7.Text = "Rif."
        Me.GLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel8
        '
        Me.GLabel8.BorderWidth = 1.0!
        Me.GLabel8.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel8.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel8.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems7.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems7.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel8.ForeColorBlend = CBlendItems7
        Me.GLabel8.Glow = 8
        Me.GLabel8.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel8.Location = New System.Drawing.Point(0, 420)
        Me.GLabel8.MouseOver = False
        Me.GLabel8.Name = "GLabel8"
        Me.GLabel8.PulseSpeed = 25
        Me.GLabel8.Size = New System.Drawing.Size(93, 21)
        Me.GLabel8.TabIndex = 15
        Me.GLabel8.Text = "Prezzo da"
        Me.GLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLabel1
        '
        Me.GLabel1.BorderWidth = 1.0!
        Me.GLabel1.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel1.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel1.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems8.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems8.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel1.ForeColorBlend = CBlendItems8
        Me.GLabel1.Glow = 8
        Me.GLabel1.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel1.Location = New System.Drawing.Point(423, 420)
        Me.GLabel1.MouseOver = False
        Me.GLabel1.Name = "GLabel1"
        Me.GLabel1.PulseSpeed = 25
        Me.GLabel1.Size = New System.Drawing.Size(25, 21)
        Me.GLabel1.TabIndex = 21
        Me.GLabel1.Text = "a"
        Me.GLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbOrdine
        '
        Me.cmbOrdine.BackColor = System.Drawing.Color.White
        Me.cmbOrdine.Color1 = System.Drawing.Color.White
        Me.cmbOrdine.Color2 = System.Drawing.Color.Gainsboro
        Me.cmbOrdine.Color3 = System.Drawing.Color.White
        Me.cmbOrdine.Color4 = System.Drawing.Color.PaleGoldenrod
        Me.cmbOrdine.DrawMode = System.Windows.Forms.DrawMode.Normal
        Me.cmbOrdine.DropControl = Nothing
        Me.cmbOrdine.DropDownHeight = 200
        Me.cmbOrdine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrdine.DropDownWidth = 279
        Me.cmbOrdine.IsDroppedDown = False
        Me.cmbOrdine.Location = New System.Drawing.Point(204, 490)
        Me.cmbOrdine.MaxDropDownItems = 8
        Me.cmbOrdine.Name = "cmbOrdine"
        Me.cmbOrdine.PercentageAdd = 0
        Me.cmbOrdine.SelectedIndex = -1
        Me.cmbOrdine.SelectedItem = Nothing
        Me.cmbOrdine.Size = New System.Drawing.Size(279, 21)
        Me.cmbOrdine.Soreted = False
        Me.cmbOrdine.TabIndex = 25
        Me.cmbOrdine.Text = "BnComboBox4"
        '
        'cmbSimulProvince
        '
        Me.cmbSimulProvince.KeySelected = Nothing
        Me.cmbSimulProvince.Location = New System.Drawing.Point(291, 527)
        Me.cmbSimulProvince.Name = "cmbSimulProvince"
        Me.cmbSimulProvince.Size = New System.Drawing.Size(279, 53)
        Me.cmbSimulProvince.TabIndex = 29
        Me.cmbSimulProvince.Visible = False
        '
        'cmbSimulcontratto
        '
        Me.cmbSimulcontratto.KeySelected = Nothing
        Me.cmbSimulcontratto.Location = New System.Drawing.Point(291, 515)
        Me.cmbSimulcontratto.Name = "cmbSimulcontratto"
        Me.cmbSimulcontratto.Size = New System.Drawing.Size(279, 53)
        Me.cmbSimulcontratto.TabIndex = 28
        Me.cmbSimulcontratto.Visible = False
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BackColor = System.Drawing.Color.White
        Me.cmbCategoria.Color1 = System.Drawing.Color.White
        Me.cmbCategoria.Color2 = System.Drawing.Color.Gainsboro
        Me.cmbCategoria.Color3 = System.Drawing.Color.White
        Me.cmbCategoria.Color4 = System.Drawing.Color.PaleGoldenrod
        Me.cmbCategoria.DrawMode = System.Windows.Forms.DrawMode.Normal
        Me.cmbCategoria.DropControl = Me.cmbSimulCategoria
        Me.cmbCategoria.DropDownHeight = 200
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.DropDownWidth = 279
        Me.cmbCategoria.IsDroppedDown = False
        Me.cmbCategoria.Location = New System.Drawing.Point(204, 70)
        Me.cmbCategoria.MaxDropDownItems = 8
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.PercentageAdd = 0
        Me.cmbCategoria.SelectedIndex = -1
        Me.cmbCategoria.SelectedItem = Nothing
        Me.cmbCategoria.Size = New System.Drawing.Size(279, 21)
        Me.cmbCategoria.Soreted = False
        Me.cmbCategoria.TabIndex = 27
        Me.cmbCategoria.Text = "BnComboBox1"
        '
        'cmbSimulCategoria
        '
        Me.cmbSimulCategoria.KeySelected = Nothing
        Me.cmbSimulCategoria.Location = New System.Drawing.Point(301, 515)
        Me.cmbSimulCategoria.Name = "cmbSimulCategoria"
        Me.cmbSimulCategoria.Size = New System.Drawing.Size(279, 53)
        Me.cmbSimulCategoria.TabIndex = 26
        Me.cmbSimulCategoria.Visible = False
        '
        'cmbProvince
        '
        Me.cmbProvince.BackColor = System.Drawing.Color.White
        Me.cmbProvince.Color1 = System.Drawing.Color.White
        Me.cmbProvince.Color2 = System.Drawing.Color.Gainsboro
        Me.cmbProvince.Color3 = System.Drawing.Color.White
        Me.cmbProvince.Color4 = System.Drawing.Color.PaleGoldenrod
        Me.cmbProvince.DrawMode = System.Windows.Forms.DrawMode.Normal
        Me.cmbProvince.DropControl = Me.cmbSimulProvince
        Me.cmbProvince.DropDownHeight = 200
        Me.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvince.DropDownWidth = 279
        Me.cmbProvince.IsDroppedDown = False
        Me.cmbProvince.Location = New System.Drawing.Point(204, 210)
        Me.cmbProvince.MaxDropDownItems = 8
        Me.cmbProvince.Name = "cmbProvince"
        Me.cmbProvince.PercentageAdd = 0
        Me.cmbProvince.SelectedIndex = -1
        Me.cmbProvince.SelectedItem = Nothing
        Me.cmbProvince.Size = New System.Drawing.Size(279, 21)
        Me.cmbProvince.Soreted = False
        Me.cmbProvince.TabIndex = 24
        Me.cmbProvince.Text = "BnComboBox3"
        '
        'cmbcontratto
        '
        Me.cmbcontratto.BackColor = System.Drawing.Color.White
        Me.cmbcontratto.Color1 = System.Drawing.Color.White
        Me.cmbcontratto.Color2 = System.Drawing.Color.Gainsboro
        Me.cmbcontratto.Color3 = System.Drawing.Color.White
        Me.cmbcontratto.Color4 = System.Drawing.Color.PaleGoldenrod
        Me.cmbcontratto.DrawMode = System.Windows.Forms.DrawMode.Normal
        Me.cmbcontratto.DropControl = Me.cmbSimulcontratto
        Me.cmbcontratto.DropDownHeight = 200
        Me.cmbcontratto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcontratto.DropDownWidth = 279
        Me.cmbcontratto.IsDroppedDown = False
        Me.cmbcontratto.Location = New System.Drawing.Point(204, 3)
        Me.cmbcontratto.MaxDropDownItems = 8
        Me.cmbcontratto.Name = "cmbcontratto"
        Me.cmbcontratto.PercentageAdd = 0
        Me.cmbcontratto.SelectedIndex = -1
        Me.cmbcontratto.SelectedItem = Nothing
        Me.cmbcontratto.Size = New System.Drawing.Size(279, 21)
        Me.cmbcontratto.Soreted = False
        Me.cmbcontratto.TabIndex = 23
        '
        'cmbTipologia
        '
        Me.cmbTipologia.BackColor = System.Drawing.Color.White
        Me.cmbTipologia.Color1 = System.Drawing.Color.White
        Me.cmbTipologia.Color2 = System.Drawing.Color.Gainsboro
        Me.cmbTipologia.Color3 = System.Drawing.Color.White
        Me.cmbTipologia.Color4 = System.Drawing.Color.PaleGoldenrod
        Me.cmbTipologia.DrawMode = System.Windows.Forms.DrawMode.Normal
        Me.cmbTipologia.DropControl = Me.cmbSimulTipologia
        Me.cmbTipologia.DropDownHeight = 200
        Me.cmbTipologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipologia.DropDownWidth = 279
        Me.cmbTipologia.IsDroppedDown = False
        Me.cmbTipologia.Location = New System.Drawing.Point(207, 140)
        Me.cmbTipologia.MaxDropDownItems = 8
        Me.cmbTipologia.Name = "cmbTipologia"
        Me.cmbTipologia.PercentageAdd = 0
        Me.cmbTipologia.SelectedIndex = -1
        Me.cmbTipologia.SelectedItem = Nothing
        Me.cmbTipologia.Size = New System.Drawing.Size(279, 21)
        Me.cmbTipologia.Soreted = False
        Me.cmbTipologia.TabIndex = 31
        Me.cmbTipologia.Text = "BnComboBox1"
        '
        'GLabel9
        '
        Me.GLabel9.BorderWidth = 1.0!
        Me.GLabel9.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel9.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel9.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel9.ForeColor = System.Drawing.Color.AliceBlue
        CBlendItems9.iColor = New System.Drawing.Color() {System.Drawing.Color.AliceBlue, System.Drawing.Color.RoyalBlue, System.Drawing.Color.Navy}
        CBlendItems9.iPoint = New Single() {0.0!, 0.5!, 1.0!}
        Me.GLabel9.ForeColorBlend = CBlendItems9
        Me.GLabel9.Glow = 8
        Me.GLabel9.GlowColor = System.Drawing.Color.CornflowerBlue
        Me.GLabel9.Location = New System.Drawing.Point(2, 140)
        Me.GLabel9.MouseOver = False
        Me.GLabel9.Name = "GLabel9"
        Me.GLabel9.PulseSpeed = 25
        Me.GLabel9.Size = New System.Drawing.Size(92, 21)
        Me.GLabel9.TabIndex = 30
        Me.GLabel9.Text = "Tipologia"
        Me.GLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSimulTipologia
        '
        Me.cmbSimulTipologia.KeySelected = Nothing
        Me.cmbSimulTipologia.Location = New System.Drawing.Point(194, 527)
        Me.cmbSimulTipologia.Name = "cmbSimulTipologia"
        Me.cmbSimulTipologia.Size = New System.Drawing.Size(154, 78)
        Me.cmbSimulTipologia.TabIndex = 32
        '
        'CustomSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.Controls.Add(Me.cmbSimulTipologia)
        Me.Controls.Add(Me.cmbTipologia)
        Me.Controls.Add(Me.GLabel9)
        Me.Controls.Add(Me.cmbSimulProvince)
        Me.Controls.Add(Me.cmbSimulcontratto)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.cmbSimulCategoria)
        Me.Controls.Add(Me.cmbOrdine)
        Me.Controls.Add(Me.cmbProvince)
        Me.Controls.Add(Me.cmbcontratto)
        Me.Controls.Add(Me.GLabel1)
        Me.Controls.Add(Me.GLabel8)
        Me.Controls.Add(Me.GLabel7)
        Me.Controls.Add(Me.GLabel6)
        Me.Controls.Add(Me.GLabel5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtRif)
        Me.Controls.Add(Me.GLabel4)
        Me.Controls.Add(Me.GLabel3)
        Me.Controls.Add(Me.GLabel2)
        Me.Name = "CustomSearch"
        Me.Size = New System.Drawing.Size(501, 583)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GLabel2 As gLabel.gLabel
    Friend WithEvents GLabel3 As gLabel.gLabel
    Friend WithEvents GLabel4 As gLabel.gLabel
    Friend WithEvents txtRif As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents GLabel5 As gLabel.gLabel
    Friend WithEvents GLabel6 As gLabel.gLabel
    Friend WithEvents GLabel7 As gLabel.gLabel
    Friend WithEvents GLabel8 As gLabel.gLabel
    Friend WithEvents GLabel1 As gLabel.gLabel
    Friend WithEvents cmbcontratto As BBBNOVA.BNComboBox
    Friend WithEvents cmbProvince As BBBNOVA.BNComboBox
    Friend WithEvents cmbOrdine As BBBNOVA.BNComboBox
    Friend WithEvents cmbSimulCategoria As AlbatrosProject.ComboboxSimul
    Friend WithEvents cmbCategoria As BBBNOVA.BNComboBox
    Friend WithEvents cmbSimulcontratto As AlbatrosProject.ComboboxSimul
    Friend WithEvents cmbSimulProvince As AlbatrosProject.ComboboxSimul
    Friend WithEvents cmbTipologia As BBBNOVA.BNComboBox
    Friend WithEvents GLabel9 As gLabel.gLabel
    Friend WithEvents cmbSimulTipologia As AlbatrosProject.ComboboxSimul

End Class
