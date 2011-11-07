<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFilter
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
        Me.mltMain = New Ai.Control.MultiColumnTree
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost
        Me.UserControl11 = New AlbatrosProject.UserControl1
        Me.SuspendLayout()
        '
        'mltMain
        '
        Me.mltMain.Culture = New System.Globalization.CultureInfo("en-US")
        Me.mltMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mltMain.Indent = -1
        Me.mltMain.Location = New System.Drawing.Point(-1, -1)
        Me.mltMain.Name = "mltMain"
        Me.mltMain.Padding = New System.Windows.Forms.Padding(1)
        Me.mltMain.SelectedNode = Nothing
        Me.mltMain.Size = New System.Drawing.Size(100, 100)
        Me.mltMain.TabIndex = 0
        '
        'ElementHost1
        '
        Me.ElementHost1.Location = New System.Drawing.Point(25, 105)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(234, 149)
        Me.ElementHost1.TabIndex = 1
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Me.UserControl11
        '
        'FormFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ElementHost1)
        Me.Controls.Add(Me.mltMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormFilter"
        Me.Text = "FormFilter"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mltMain As Ai.Control.MultiColumnTree
    Friend WithEvents ElementHost1 As System.Windows.Forms.Integration.ElementHost
    Friend UserControl11 As AlbatrosProject.UserControl1
End Class
