<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomKeyboard
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
        Me.Keyboardcontrol1 = New KeyboardClassLibrary.Keyboardcontrol
        Me.tmrFadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Keyboardcontrol1
        '
        Me.Keyboardcontrol1.KeyboardType = KeyboardClassLibrary.BoW.Standard
        Me.Keyboardcontrol1.Location = New System.Drawing.Point(2, 0)
        Me.Keyboardcontrol1.Name = "Keyboardcontrol1"
        Me.Keyboardcontrol1.Size = New System.Drawing.Size(993, 221)
        Me.Keyboardcontrol1.TabIndex = 0
        '
        'tmrFadeIn
        '
        '
        'CustomKeyboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.Keyboardcontrol1)
        Me.Name = "CustomKeyboard"
        Me.Size = New System.Drawing.Size(996, 225)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Keyboardcontrol1 As KeyboardClassLibrary.Keyboardcontrol
    Friend WithEvents tmrFadeIn As System.Windows.Forms.Timer

End Class
