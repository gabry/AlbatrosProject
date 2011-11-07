<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKeyboard
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Keyboardcontrol1 = New KeyboardClassLibrary.Keyboardcontrol()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Keyboardcontrol1
        '
        Me.Keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Standard
        Me.Keyboardcontrol1.Location = New System.Drawing.Point(12, -2)
        Me.Keyboardcontrol1.Name = "Keyboardcontrol1"
        Me.Keyboardcontrol1.Size = New System.Drawing.Size(962, 288)
        Me.Keyboardcontrol1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1026, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 1
        '
        'FormKeyboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 274)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Keyboardcontrol1)
        Me.Name = "FormKeyboard"
        Me.Opacity = 0.0R
        Me.Text = "FormKeyboard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Keyboardcontrol1 As KeyboardClassLibrary.Keyboardcontrol
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
