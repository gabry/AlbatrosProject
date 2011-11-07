<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TitleSearch
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
        Me.GLabel1 = New gLabel.gLabel
        Me.CustomSearch1 = New AlbatrosProject.CustomSearch
        Me.SuspendLayout()
        '
        'GLabel1
        '
        Me.GLabel1.BorderWidth = 1.0!
        Me.GLabel1.FillType = gLabel.gLabel.eFillType.Solid
        Me.GLabel1.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GLabel1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GLabel1.ForeColor = System.Drawing.Color.Orange
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.White}
        CBlendItems1.iPoint = New Single() {0.0!, 0.03202847!, 1.0!}
        Me.GLabel1.ForeColorBlend = CBlendItems1
        Me.GLabel1.Glow = 8
        Me.GLabel1.GlowColor = System.Drawing.Color.White
        Me.GLabel1.Location = New System.Drawing.Point(3, 1)
        Me.GLabel1.MouseOver = False
        Me.GLabel1.Name = "GLabel1"
        Me.GLabel1.PulseSpeed = 25
        Me.GLabel1.Size = New System.Drawing.Size(146, 23)
        Me.GLabel1.TabIndex = 1
        Me.GLabel1.Text = "RICERCA"
        Me.GLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CustomSearch1
        '
        Me.CustomSearch1.BackColor = System.Drawing.Color.Black
        Me.CustomSearch1.Location = New System.Drawing.Point(0, 27)
        Me.CustomSearch1.Name = "CustomSearch1"
        Me.CustomSearch1.Size = New System.Drawing.Size(497, 380)
        Me.CustomSearch1.TabIndex = 2
        '
        'TitleSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CustomSearch1)
        Me.Controls.Add(Me.GLabel1)
        Me.Name = "TitleSearch"
        Me.Size = New System.Drawing.Size(500, 430)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GLabel1 As gLabel.gLabel
    Friend WithEvents CustomSearch1 As AlbatrosProject.CustomSearch

End Class
