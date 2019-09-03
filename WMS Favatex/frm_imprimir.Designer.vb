<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_imprimir
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CR = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CR
        '
        Me.CR.ActiveViewIndex = -1
        Me.CR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CR.Cursor = System.Windows.Forms.Cursors.Default
        Me.CR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CR.Location = New System.Drawing.Point(0, 0)
        Me.CR.Name = "CR"
        Me.CR.Size = New System.Drawing.Size(690, 513)
        Me.CR.TabIndex = 0
        '
        'frm_imprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 513)
        Me.Controls.Add(Me.CR)
        Me.Name = "frm_imprimir"
        Me.Text = "VISTA PRELIMINAR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CR As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
