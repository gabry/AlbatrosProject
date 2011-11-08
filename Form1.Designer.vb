<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.pctLogo = New System.Windows.Forms.PictureBox
        Me.tmrLoad = New System.Windows.Forms.Timer(Me.components)
        Me.CustomKeyboard1 = New AlbatrosProject.CustomKeyboard
        Me.Search = New AlbatrosProject.TitleSearch
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctLogo
        '
        Me.pctLogo.Location = New System.Drawing.Point(3, 1)
        Me.pctLogo.Name = "pctLogo"
        Me.pctLogo.Size = New System.Drawing.Size(100, 86)
        Me.pctLogo.TabIndex = 0
        Me.pctLogo.TabStop = False
        '
        'tmrLoad
        '
        '
        'CustomKeyboard1
        '
        Me.CustomKeyboard1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CustomKeyboard1.Location = New System.Drawing.Point(263, 88)
        Me.CustomKeyboard1.Name = "CustomKeyboard1"
        Me.CustomKeyboard1.OriginLocation = New System.Drawing.Point(0, 0)
        Me.CustomKeyboard1.SetStep = 0.0!
        Me.CustomKeyboard1.Size = New System.Drawing.Size(996, 222)
        Me.CustomKeyboard1.TabIndex = 2
        '
        'Search
        '
        Me.Search.BackColor = System.Drawing.Color.DarkGray
        Me.Search.Location = New System.Drawing.Point(3, 251)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(499, 378)
        Me.Search.TabIndex = 1
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1514, 714)
        Me.Controls.Add(Me.CustomKeyboard1)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.pctLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormMain"
        Me.Text = "Form1"
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pctLogo As System.Windows.Forms.PictureBox
    Friend WithEvents tmrLoad As System.Windows.Forms.Timer
    Friend WithEvents Search As AlbatrosProject.TitleSearch
    Friend WithEvents CustomKeyboard1 As AlbatrosProject.CustomKeyboard

End Class
