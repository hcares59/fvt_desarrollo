<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_movimiento_de_pallet
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblUbicacionActual = New System.Windows.Forms.Label()
        Me.chkMantener = New System.Windows.Forms.CheckBox()
        Me.cmbPallet = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPallet2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblBultoCantidad = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbmBodegas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblBultoCantidad2 = New System.Windows.Forms.Label()
        Me.lblNombre2 = New System.Windows.Forms.Label()
        Me.lblCodigo2 = New System.Windows.Forms.Label()
        Me.chkUbicacionVacia = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUbicacionActual)
        Me.GroupBox1.Controls.Add(Me.chkMantener)
        Me.GroupBox1.Controls.Add(Me.cmbPallet)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SELECCIONE PALLET"
        '
        'lblUbicacionActual
        '
        Me.lblUbicacionActual.AutoSize = True
        Me.lblUbicacionActual.Location = New System.Drawing.Point(175, 67)
        Me.lblUbicacionActual.Name = "lblUbicacionActual"
        Me.lblUbicacionActual.Size = New System.Drawing.Size(11, 13)
        Me.lblUbicacionActual.TabIndex = 25
        Me.lblUbicacionActual.Text = "-"
        '
        'chkMantener
        '
        Me.chkMantener.AutoSize = True
        Me.chkMantener.Location = New System.Drawing.Point(17, 67)
        Me.chkMantener.Name = "chkMantener"
        Me.chkMantener.Size = New System.Drawing.Size(129, 17)
        Me.chkMantener.TabIndex = 24
        Me.chkMantener.Text = "Mantener ubicación"
        Me.chkMantener.UseVisualStyleBackColor = True
        '
        'cmbPallet
        '
        Me.cmbPallet.FormattingEnabled = True
        Me.cmbPallet.Location = New System.Drawing.Point(15, 39)
        Me.cmbPallet.Name = "cmbPallet"
        Me.cmbPallet.Size = New System.Drawing.Size(269, 21)
        Me.cmbPallet.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "DIGITE SERIE DEL PALLET"
        '
        'cmbPallet2
        '
        Me.cmbPallet2.Enabled = False
        Me.cmbPallet2.FormattingEnabled = True
        Me.cmbPallet2.Location = New System.Drawing.Point(18, 38)
        Me.cmbPallet2.Name = "cmbPallet2"
        Me.cmbPallet2.Size = New System.Drawing.Size(269, 21)
        Me.cmbPallet2.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "DIGITE SERIE DEL PALLET 2"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblBultoCantidad)
        Me.GroupBox2.Controls.Add(Me.lblNombre)
        Me.GroupBox2.Controls.Add(Me.lblCodigo)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(294, 128)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DETALLE DEL PALLET"
        '
        'lblBultoCantidad
        '
        Me.lblBultoCantidad.AutoSize = True
        Me.lblBultoCantidad.Location = New System.Drawing.Point(26, 97)
        Me.lblBultoCantidad.Name = "lblBultoCantidad"
        Me.lblBultoCantidad.Size = New System.Drawing.Size(11, 13)
        Me.lblBultoCantidad.TabIndex = 25
        Me.lblBultoCantidad.Text = "-"
        '
        'lblNombre
        '
        Me.lblNombre.Location = New System.Drawing.Point(26, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(258, 46)
        Me.lblNombre.TabIndex = 24
        Me.lblNombre.Text = "-"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(26, 20)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(11, 13)
        Me.lblCodigo.TabIndex = 23
        Me.lblCodigo.Text = "-"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cbmBodegas)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cmbUbicacion)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 232)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(594, 75)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "UBICACIÓN DESTINO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "UBICACIÓN"
        '
        'cbmBodegas
        '
        Me.cbmBodegas.Enabled = False
        Me.cbmBodegas.FormattingEnabled = True
        Me.cbmBodegas.Location = New System.Drawing.Point(82, 19)
        Me.cbmBodegas.Name = "cbmBodegas"
        Me.cbmBodegas.Size = New System.Drawing.Size(300, 21)
        Me.cbmBodegas.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "BODEGA"
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.Enabled = False
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.Location = New System.Drawing.Point(82, 46)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(300, 21)
        Me.cmbUbicacion.TabIndex = 24
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkUbicacionVacia)
        Me.GroupBox4.Controls.Add(Me.btnCancelar)
        Me.GroupBox4.Controls.Add(Me.btnAceptar)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 305)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(595, 45)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(511, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(430, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbPallet2)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Location = New System.Drawing.Point(303, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(294, 90)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "SELECCIONE PALLET"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(175, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "-"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblBultoCantidad2)
        Me.GroupBox6.Controls.Add(Me.lblNombre2)
        Me.GroupBox6.Controls.Add(Me.lblCodigo2)
        Me.GroupBox6.Location = New System.Drawing.Point(304, 99)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(294, 128)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "DETALLE DEL PALLET 2"
        '
        'lblBultoCantidad2
        '
        Me.lblBultoCantidad2.AutoSize = True
        Me.lblBultoCantidad2.Location = New System.Drawing.Point(26, 97)
        Me.lblBultoCantidad2.Name = "lblBultoCantidad2"
        Me.lblBultoCantidad2.Size = New System.Drawing.Size(11, 13)
        Me.lblBultoCantidad2.TabIndex = 25
        Me.lblBultoCantidad2.Text = "-"
        '
        'lblNombre2
        '
        Me.lblNombre2.Location = New System.Drawing.Point(26, 42)
        Me.lblNombre2.Name = "lblNombre2"
        Me.lblNombre2.Size = New System.Drawing.Size(258, 46)
        Me.lblNombre2.TabIndex = 24
        Me.lblNombre2.Text = "-"
        '
        'lblCodigo2
        '
        Me.lblCodigo2.AutoSize = True
        Me.lblCodigo2.Location = New System.Drawing.Point(26, 20)
        Me.lblCodigo2.Name = "lblCodigo2"
        Me.lblCodigo2.Size = New System.Drawing.Size(11, 13)
        Me.lblCodigo2.TabIndex = 23
        Me.lblCodigo2.Text = "-"
        '
        'chkUbicacionVacia
        '
        Me.chkUbicacionVacia.AutoSize = True
        Me.chkUbicacionVacia.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUbicacionVacia.Location = New System.Drawing.Point(20, 20)
        Me.chkUbicacionVacia.Name = "chkUbicacionVacia"
        Me.chkUbicacionVacia.Size = New System.Drawing.Size(105, 17)
        Me.chkUbicacionVacia.TabIndex = 2
        Me.chkUbicacionVacia.Text = "Ubicación vacía"
        Me.chkUbicacionVacia.UseVisualStyleBackColor = True
        '
        'frm_movimiento_de_pallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 352)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_movimiento_de_pallet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOVIMIENTO DE PALLET"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbPallet As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblBultoCantidad As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmbUbicacion As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cbmBodegas As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUbicacionActual As Label
    Friend WithEvents chkMantener As CheckBox
    Friend WithEvents cmbPallet2 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents lblBultoCantidad2 As Label
    Friend WithEvents lblNombre2 As Label
    Friend WithEvents lblCodigo2 As Label
    Friend WithEvents chkUbicacionVacia As CheckBox
End Class
