<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usercontrol
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usercontrol))
        Me.TimerLoad = New System.Windows.Forms.Timer(Me.components)
        Me.pnlDescr = New RibbonStyle.RibbonPanel
        Me.btnClose = New MyXPButton.MyXPButton
        Me.lblInformation = New System.Windows.Forms.Label
        Me.AnimationControl1 = New AlbatrosProject.AnimationControl
        Me.pnlDescr.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimerLoad
        '
        '
        'pnlDescr
        '
        Me.pnlDescr.BaseColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pnlDescr.BaseColorOn = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pnlDescr.Caption = ""
        Me.pnlDescr.Controls.Add(Me.lblInformation)
        Me.pnlDescr.Location = New System.Drawing.Point(1, 1)
        Me.pnlDescr.Name = "pnlDescr"
        Me.pnlDescr.Opacity = 255
        Me.pnlDescr.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.pnlDescr.Size = New System.Drawing.Size(871, 29)
        Me.pnlDescr.Speed = 8
        Me.pnlDescr.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.AdjustImageLocation = New System.Drawing.Point(0, 0)
        Me.btnClose.BtnShape = MyXPButton.emunType.BtnShape.Rectangle
        Me.btnClose.BtnStyle = MyXPButton.emunType.XPStyle.Silver
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(872, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 30)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Chiudi"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblInformation
        '
        Me.lblInformation.AutoSize = True
        Me.lblInformation.BackColor = System.Drawing.Color.Transparent
        Me.lblInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInformation.Location = New System.Drawing.Point(6, 6)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(55, 16)
        Me.lblInformation.TabIndex = 0
        Me.lblInformation.Text = "Label1"
        '
        'AnimationControl1
        '
        Me.AnimationControl1.AnimationType = AlbatrosProject.AnimationTypes.LeftToRight
        Me.AnimationControl1.Location = New System.Drawing.Point(3, 36)
        Me.AnimationControl1.MinimumSize = New System.Drawing.Size(100, 100)
        Me.AnimationControl1.Name = "AnimationControl1"
        Me.AnimationControl1.Size = New System.Drawing.Size(552, 509)
        Me.AnimationControl1.TabIndex = 4
        Me.AnimationControl1.Text = "AnimationControl1"
        Me.AnimationControl1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Usercontrol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.AnimationControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.pnlDescr)
        Me.Name = "Usercontrol"
        Me.Size = New System.Drawing.Size(971, 548)
        Me.pnlDescr.ResumeLayout(False)
        Me.pnlDescr.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerLoad As System.Windows.Forms.Timer
    Friend WithEvents pnlDescr As RibbonStyle.RibbonPanel
    Friend WithEvents btnClose As MyXPButton.MyXPButton
    Friend WithEvents lblInformation As System.Windows.Forms.Label
    Friend WithEvents AnimationControl1 As AlbatrosProject.AnimationControl

End Class
