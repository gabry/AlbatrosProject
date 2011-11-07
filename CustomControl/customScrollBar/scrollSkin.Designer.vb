<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scrollSkin
    Inherits System.Windows.Forms.Panel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.VScrollBar1 = New customScoll.VScrollBar
        Me.SuspendLayout()
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.LargeChange = 1
        Me.VScrollBar1.Location = New System.Drawing.Point(145, 0)
        Me.VScrollBar1.Maximum = 10
        Me.VScrollBar1.Minimum = 0
        Me.VScrollBar1.MinimumSize = New System.Drawing.Size(19, 15)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(19, 127)
        Me.VScrollBar1.SmallChange = 1
        Me.VScrollBar1.TabIndex = 0
        Me.VScrollBar1.Value = 10
        '
        'scrollSkin
        '
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.VScrollBar1)
        Me.Size = New System.Drawing.Size(164, 127)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VScrollBar1 As customScoll.VScrollBar

End Class
