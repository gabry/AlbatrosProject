<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDetails
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
        Me.TimerShow = New System.Windows.Forms.Timer(Me.components)
        Me.cd = New AlbatrosProject.Usercontrol
        Me.SuspendLayout()
        '
        'TimerShow
        '
        '
        'cd
        '
        Me.cd.Location = New System.Drawing.Point(4, 3)
        Me.cd.Name = "cd"
        Me.cd.Size = New System.Drawing.Size(1108, 552)
        Me.cd.TabIndex = 0
        '
        'FormDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 613)
        Me.Controls.Add(Me.cd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormDetails"
        Me.Text = "FormDetails"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cd As AlbatrosProject.Usercontrol
    Friend WithEvents TimerShow As System.Windows.Forms.Timer
End Class
