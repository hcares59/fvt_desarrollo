<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ingreso_cartera
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ingreso_cartera))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonProductos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkAutonumerico = New System.Windows.Forms.CheckBox()
        Me.chkIncluye = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optGD = New System.Windows.Forms.RadioButton()
        Me.OptFactura = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.optAmbos = New System.Windows.Forms.RadioButton()
        Me.optProveedor = New System.Windows.Forms.RadioButton()
        Me.optcliente = New System.Windows.Forms.RadioButton()
        Me.txtDiasplazo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFono = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbComunas = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbRegion = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRut = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkVV = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 4)
        Me.Panel1.TabIndex = 32
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonProductos, Me.ToolStripSeparator3, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(481, 25)
        Me.ToolStrip1.TabIndex = 33
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(64, 22)
        Me.ButtonNuevo.Text = "NUEVO"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonGurdar
        '
        Me.ButtonGurdar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGurdar.Image = CType(resources.GetObject("ButtonGurdar.Image"), System.Drawing.Image)
        Me.ButtonGurdar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonGurdar.Name = "ButtonGurdar"
        Me.ButtonGurdar.Size = New System.Drawing.Size(79, 22)
        Me.ButtonGurdar.Text = "GUARDAR"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonProductos
        '
        Me.ButtonProductos.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonProductos.Image = CType(resources.GetObject("ButtonProductos.Image"), System.Drawing.Image)
        Me.ButtonProductos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonProductos.Name = "ButtonProductos"
        Me.ButtonProductos.Size = New System.Drawing.Size(126, 22)
        Me.ButtonProductos.Text = "ASOCIA PRODUCTO"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSalir.Image = CType(resources.GetObject("ButtonSalir.Image"), System.Drawing.Image)
        Me.ButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(55, 22)
        Me.ButtonSalir.Text = "SALIR"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(481, 4)
        Me.Panel2.TabIndex = 34
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkVV)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.chkAutonumerico)
        Me.GroupBox1.Controls.Add(Me.chkIncluye)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.optAmbos)
        Me.GroupBox1.Controls.Add(Me.optProveedor)
        Me.GroupBox1.Controls.Add(Me.optcliente)
        Me.GroupBox1.Controls.Add(Me.txtDiasplazo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtFono)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbComunas)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCiudad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbRegion)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRut)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 289)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos generales"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(-7, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "O. DE COMPRA"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkAutonumerico
        '
        Me.chkAutonumerico.AutoSize = True
        Me.chkAutonumerico.Location = New System.Drawing.Point(101, 228)
        Me.chkAutonumerico.Name = "chkAutonumerico"
        Me.chkAutonumerico.Size = New System.Drawing.Size(163, 17)
        Me.chkAutonumerico.TabIndex = 73
        Me.chkAutonumerico.Text = "NUMERO AUTONUMERICO"
        Me.chkAutonumerico.UseVisualStyleBackColor = True
        '
        'chkIncluye
        '
        Me.chkIncluye.AutoSize = True
        Me.chkIncluye.Location = New System.Drawing.Point(303, 162)
        Me.chkIncluye.Name = "chkIncluye"
        Me.chkIncluye.Size = New System.Drawing.Size(135, 17)
        Me.chkIncluye.TabIndex = 72
        Me.chkIncluye.Text = "INCLUYE EN GRAFICO"
        Me.chkIncluye.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optGD)
        Me.GroupBox2.Controls.Add(Me.OptFactura)
        Me.GroupBox2.Location = New System.Drawing.Point(95, 185)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 39)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        '
        'optGD
        '
        Me.optGD.AutoSize = True
        Me.optGD.Checked = True
        Me.optGD.Location = New System.Drawing.Point(84, 16)
        Me.optGD.Name = "optGD"
        Me.optGD.Size = New System.Drawing.Size(110, 17)
        Me.optGD.TabIndex = 69
        Me.optGD.TabStop = True
        Me.optGD.Text = "GUIA DESPACHO"
        Me.optGD.UseVisualStyleBackColor = True
        '
        'OptFactura
        '
        Me.OptFactura.AutoSize = True
        Me.OptFactura.Location = New System.Drawing.Point(6, 16)
        Me.OptFactura.Name = "OptFactura"
        Me.OptFactura.Size = New System.Drawing.Size(71, 17)
        Me.OptFactura.TabIndex = 68
        Me.OptFactura.Text = "FACTURA"
        Me.OptFactura.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(0, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 20)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "DESPACHA CON"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(303, 140)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 17)
        Me.chkActivo.TabIndex = 66
        Me.chkActivo.Text = "ACTIVO"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'optAmbos
        '
        Me.optAmbos.AutoSize = True
        Me.optAmbos.Location = New System.Drawing.Point(359, 28)
        Me.optAmbos.Name = "optAmbos"
        Me.optAmbos.Size = New System.Drawing.Size(64, 17)
        Me.optAmbos.TabIndex = 65
        Me.optAmbos.Text = "AMBOS"
        Me.optAmbos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optAmbos.UseVisualStyleBackColor = True
        '
        'optProveedor
        '
        Me.optProveedor.AutoSize = True
        Me.optProveedor.Location = New System.Drawing.Point(260, 28)
        Me.optProveedor.Name = "optProveedor"
        Me.optProveedor.Size = New System.Drawing.Size(90, 17)
        Me.optProveedor.TabIndex = 64
        Me.optProveedor.Text = "PROVEEDOR"
        Me.optProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optProveedor.UseVisualStyleBackColor = True
        '
        'optcliente
        '
        Me.optcliente.AutoSize = True
        Me.optcliente.Checked = True
        Me.optcliente.Location = New System.Drawing.Point(184, 28)
        Me.optcliente.Name = "optcliente"
        Me.optcliente.Size = New System.Drawing.Size(65, 17)
        Me.optcliente.TabIndex = 63
        Me.optcliente.TabStop = True
        Me.optcliente.Text = "CLIENTE"
        Me.optcliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optcliente.UseVisualStyleBackColor = True
        '
        'txtDiasplazo
        '
        Me.txtDiasplazo.Location = New System.Drawing.Point(373, 109)
        Me.txtDiasplazo.MaxLength = 5
        Me.txtDiasplazo.Name = "txtDiasplazo"
        Me.txtDiasplazo.Size = New System.Drawing.Size(81, 22)
        Me.txtDiasplazo.TabIndex = 59
        Me.txtDiasplazo.Text = "0"
        Me.txtDiasplazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(299, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 17)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "DIAZ PLAZO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFono
        '
        Me.txtFono.Location = New System.Drawing.Point(373, 81)
        Me.txtFono.MaxLength = 10
        Me.txtFono.Name = "txtFono"
        Me.txtFono.Size = New System.Drawing.Size(81, 22)
        Me.txtFono.TabIndex = 57
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(299, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "TELEFONO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(94, 163)
        Me.txtCalle.MaxLength = 50
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(201, 22)
        Me.txtCalle.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "DIRECCION"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "COMUNA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbComunas
        '
        Me.cmbComunas.FormattingEnabled = True
        Me.cmbComunas.Location = New System.Drawing.Point(94, 136)
        Me.cmbComunas.Name = "cmbComunas"
        Me.cmbComunas.Size = New System.Drawing.Size(201, 21)
        Me.cmbComunas.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "CIUDAD"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCiudad
        '
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(94, 109)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(201, 21)
        Me.cmbCiudad.TabIndex = 50
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "REGION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbRegion
        '
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(94, 82)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(201, 21)
        Me.cmbRegion.TabIndex = 48
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(94, 54)
        Me.txtNombre.MaxLength = 45
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(360, 22)
        Me.txtNombre.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "NOMBRE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRut
        '
        Me.txtRut.Location = New System.Drawing.Point(94, 26)
        Me.txtRut.MaxLength = 10
        Me.txtRut.Name = "txtRut"
        Me.txtRut.Size = New System.Drawing.Size(81, 22)
        Me.txtRut.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "RUT"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkVV
        '
        Me.chkVV.AutoSize = True
        Me.chkVV.Location = New System.Drawing.Point(270, 228)
        Me.chkVV.Name = "chkVV"
        Me.chkVV.Size = New System.Drawing.Size(99, 17)
        Me.chkVV.TabIndex = 75
        Me.chkVV.Text = "FUNCIONA VV"
        Me.chkVV.UseVisualStyleBackColor = True
        '
        'frm_ingreso_cartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 331)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ingreso_cartera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENEDOR DE CARTERA"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents optAmbos As RadioButton
    Friend WithEvents optProveedor As RadioButton
    Friend WithEvents optcliente As RadioButton
    Friend WithEvents txtDiasplazo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFono As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCalle As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbComunas As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCiudad As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbRegion As ComboBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRut As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonProductos As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents optGD As RadioButton
    Friend WithEvents OptFactura As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkIncluye As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents chkAutonumerico As CheckBox
    Friend WithEvents chkVV As CheckBox
End Class
