<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ingreso_usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ingreso_usuarios))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCargo = New System.Windows.Forms.ComboBox()
        Me.chkContraseña = New System.Windows.Forms.CheckBox()
        Me.txtRut = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkDespacha = New System.Windows.Forms.CheckBox()
        Me.chkFactura = New System.Windows.Forms.CheckBox()
        Me.chkProcesa = New System.Windows.Forms.CheckBox()
        Me.chkAsigna = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkDiseno = New System.Windows.Forms.CheckBox()
        Me.chkComercial = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkEjecutaRecepcion = New System.Windows.Forms.CheckBox()
        Me.chkAsignaRecepcion = New System.Windows.Forms.CheckBox()
        Me.chkEsUsuario = New System.Windows.Forms.CheckBox()
        Me.chkEsBodega = New System.Windows.Forms.CheckBox()
        Me.chkEsChofer = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(405, 4)
        Me.Panel1.TabIndex = 28
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(405, 25)
        Me.ToolStrip1.TabIndex = 29
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
        Me.Panel2.Size = New System.Drawing.Size(405, 4)
        Me.Panel2.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbCargo)
        Me.GroupBox1.Controls.Add(Me.chkContraseña)
        Me.GroupBox1.Controls.Add(Me.txtRut)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.txtContrasena)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 138)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS GENERALES"
        '
        'cmbCargo
        '
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Location = New System.Drawing.Point(96, 79)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(285, 21)
        Me.cmbCargo.TabIndex = 107
        '
        'chkContraseña
        '
        Me.chkContraseña.AutoSize = True
        Me.chkContraseña.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkContraseña.Checked = True
        Me.chkContraseña.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkContraseña.Location = New System.Drawing.Point(137, 110)
        Me.chkContraseña.Name = "chkContraseña"
        Me.chkContraseña.Size = New System.Drawing.Size(151, 17)
        Me.chkContraseña.TabIndex = 4
        Me.chkContraseña.Text = "CONTRASEÑA GENERICA"
        Me.chkContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkContraseña.UseVisualStyleBackColor = True
        '
        'txtRut
        '
        Me.txtRut.Location = New System.Drawing.Point(96, 21)
        Me.txtRut.MaxLength = 45
        Me.txtRut.Name = "txtRut"
        Me.txtRut.Size = New System.Drawing.Size(94, 22)
        Me.txtRut.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 23)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "RUT USUARIO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Location = New System.Drawing.Point(266, 23)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(114, 17)
        Me.chkActivo.TabIndex = 2
        Me.chkActivo.Text = "USUARIO ACTIVO"
        Me.chkActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(295, 107)
        Me.txtContrasena.MaxLength = 5
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasena.Size = New System.Drawing.Size(85, 22)
        Me.txtContrasena.TabIndex = 5
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(96, 49)
        Me.txtNombre.MaxLength = 45
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(285, 22)
        Me.txtNombre.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 23)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "NOMBRE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDespacha)
        Me.GroupBox2.Controls.Add(Me.chkFactura)
        Me.GroupBox2.Controls.Add(Me.chkProcesa)
        Me.GroupBox2.Controls.Add(Me.chkAsigna)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 180)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 72)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CONFIGURACIONES"
        '
        'chkDespacha
        '
        Me.chkDespacha.AutoSize = True
        Me.chkDespacha.Location = New System.Drawing.Point(182, 44)
        Me.chkDespacha.Name = "chkDespacha"
        Me.chkDespacha.Size = New System.Drawing.Size(125, 17)
        Me.chkDespacha.TabIndex = 9
        Me.chkDespacha.Text = "DESPACHA PICKING"
        Me.chkDespacha.UseVisualStyleBackColor = True
        Me.chkDespacha.Visible = False
        '
        'chkFactura
        '
        Me.chkFactura.AutoSize = True
        Me.chkFactura.Location = New System.Drawing.Point(182, 21)
        Me.chkFactura.Name = "chkFactura"
        Me.chkFactura.Size = New System.Drawing.Size(118, 17)
        Me.chkFactura.TabIndex = 7
        Me.chkFactura.Text = "FACTURA PICKING"
        Me.chkFactura.UseVisualStyleBackColor = True
        '
        'chkProcesa
        '
        Me.chkProcesa.AutoSize = True
        Me.chkProcesa.Location = New System.Drawing.Point(26, 44)
        Me.chkProcesa.Name = "chkProcesa"
        Me.chkProcesa.Size = New System.Drawing.Size(118, 17)
        Me.chkProcesa.TabIndex = 8
        Me.chkProcesa.Text = "PROCESA PICKING"
        Me.chkProcesa.UseVisualStyleBackColor = True
        '
        'chkAsigna
        '
        Me.chkAsigna.AutoSize = True
        Me.chkAsigna.Location = New System.Drawing.Point(26, 21)
        Me.chkAsigna.Name = "chkAsigna"
        Me.chkAsigna.Size = New System.Drawing.Size(110, 17)
        Me.chkAsigna.TabIndex = 6
        Me.chkAsigna.Text = "ASIGNA PICKING"
        Me.chkAsigna.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkDiseno)
        Me.GroupBox3.Controls.Add(Me.chkComercial)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 257)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(392, 49)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ROLES DE EDICION DE PRODUCTOS"
        '
        'chkDiseno
        '
        Me.chkDiseno.AutoSize = True
        Me.chkDiseno.Location = New System.Drawing.Point(182, 22)
        Me.chkDiseno.Name = "chkDiseno"
        Me.chkDiseno.Size = New System.Drawing.Size(65, 17)
        Me.chkDiseno.TabIndex = 1
        Me.chkDiseno.Text = "DISEÑO"
        Me.chkDiseno.UseVisualStyleBackColor = True
        '
        'chkComercial
        '
        Me.chkComercial.AutoSize = True
        Me.chkComercial.Location = New System.Drawing.Point(26, 22)
        Me.chkComercial.Name = "chkComercial"
        Me.chkComercial.Size = New System.Drawing.Size(86, 17)
        Me.chkComercial.TabIndex = 0
        Me.chkComercial.Text = "COMERCIAL"
        Me.chkComercial.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkEjecutaRecepcion)
        Me.GroupBox4.Controls.Add(Me.chkAsignaRecepcion)
        Me.GroupBox4.Controls.Add(Me.chkEsUsuario)
        Me.GroupBox4.Controls.Add(Me.chkEsBodega)
        Me.GroupBox4.Controls.Add(Me.chkEsChofer)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 311)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(391, 95)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "OTROS ROLES"
        '
        'chkEjecutaRecepcion
        '
        Me.chkEjecutaRecepcion.AutoSize = True
        Me.chkEjecutaRecepcion.Location = New System.Drawing.Point(179, 67)
        Me.chkEjecutaRecepcion.Name = "chkEjecutaRecepcion"
        Me.chkEjecutaRecepcion.Size = New System.Drawing.Size(130, 17)
        Me.chkEjecutaRecepcion.TabIndex = 4
        Me.chkEjecutaRecepcion.Text = "EJECUTA RECEPCIÓN"
        Me.chkEjecutaRecepcion.UseVisualStyleBackColor = True
        '
        'chkAsignaRecepcion
        '
        Me.chkAsignaRecepcion.AutoSize = True
        Me.chkAsignaRecepcion.Location = New System.Drawing.Point(179, 44)
        Me.chkAsignaRecepcion.Name = "chkAsignaRecepcion"
        Me.chkAsignaRecepcion.Size = New System.Drawing.Size(209, 17)
        Me.chkAsignaRecepcion.TabIndex = 3
        Me.chkAsignaRecepcion.Text = "ASIGNA ORDEN PARA RECEPCIONAR"
        Me.chkAsignaRecepcion.UseVisualStyleBackColor = True
        '
        'chkEsUsuario
        '
        Me.chkEsUsuario.AutoSize = True
        Me.chkEsUsuario.Location = New System.Drawing.Point(25, 44)
        Me.chkEsUsuario.Name = "chkEsUsuario"
        Me.chkEsUsuario.Size = New System.Drawing.Size(135, 17)
        Me.chkEsUsuario.TabIndex = 2
        Me.chkEsUsuario.Text = "ES USUARIO SISTEMA"
        Me.chkEsUsuario.UseVisualStyleBackColor = True
        '
        'chkEsBodega
        '
        Me.chkEsBodega.AutoSize = True
        Me.chkEsBodega.Location = New System.Drawing.Point(179, 22)
        Me.chkEsBodega.Name = "chkEsBodega"
        Me.chkEsBodega.Size = New System.Drawing.Size(157, 17)
        Me.chkEsBodega.TabIndex = 1
        Me.chkEsBodega.Text = "ES OPERARIO DE BODEGA"
        Me.chkEsBodega.UseVisualStyleBackColor = True
        '
        'chkEsChofer
        '
        Me.chkEsChofer.AutoSize = True
        Me.chkEsChofer.Location = New System.Drawing.Point(26, 22)
        Me.chkEsChofer.Name = "chkEsChofer"
        Me.chkEsChofer.Size = New System.Drawing.Size(83, 17)
        Me.chkEsChofer.TabIndex = 0
        Me.chkEsChofer.Text = "ES CHOFER"
        Me.chkEsChofer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 23)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "CARGO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_ingreso_usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 412)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ingreso_usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENEDOR DE USUARIOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkContraseña As CheckBox
    Friend WithEvents txtRut As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkDespacha As CheckBox
    Friend WithEvents chkFactura As CheckBox
    Friend WithEvents chkProcesa As CheckBox
    Friend WithEvents chkAsigna As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkDiseno As CheckBox
    Friend WithEvents chkComercial As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents chkEsChofer As CheckBox
    Friend WithEvents chkEsUsuario As CheckBox
    Friend WithEvents chkEsBodega As CheckBox
    Friend WithEvents chkAsignaRecepcion As CheckBox
    Friend WithEvents chkEjecutaRecepcion As CheckBox
    Friend WithEvents cmbCargo As ComboBox
    Friend WithEvents Label1 As Label
End Class
