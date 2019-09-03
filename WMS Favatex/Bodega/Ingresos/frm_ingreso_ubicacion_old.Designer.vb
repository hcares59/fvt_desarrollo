<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ingreso_ubicacion_old
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ingreso_ubicacion_old))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUbicaciones = New System.Windows.Forms.Button()
        Me.cmbUbicacionRel = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPrioridad = New System.Windows.Forms.TextBox()
        Me.txtOcupadoPor = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCantPalletOT2 = New System.Windows.Forms.TextBox()
        Me.txtCantPalletOT1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCantPalletDoble = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCantPallet = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCapacidad = New System.Windows.Forms.ComboBox()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbBodegas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMts3 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFondo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(408, 25)
        Me.ToolStrip1.TabIndex = 37
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
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(408, 4)
        Me.Panel2.TabIndex = 38
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnUbicaciones)
        Me.GroupBox1.Controls.Add(Me.cmbUbicacionRel)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtPrioridad)
        Me.GroupBox1.Controls.Add(Me.txtOcupadoPor)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cmbZona)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCantPalletOT2)
        Me.GroupBox1.Controls.Add(Me.txtCantPalletOT1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtCantPalletDoble)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCantPallet)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbCapacidad)
        Me.GroupBox1.Controls.Add(Me.cmbProveedor)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbBodegas)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 269)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'btnUbicaciones
        '
        Me.btnUbicaciones.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUbicaciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUbicaciones.Location = New System.Drawing.Point(346, 211)
        Me.btnUbicaciones.Name = "btnUbicaciones"
        Me.btnUbicaciones.Size = New System.Drawing.Size(29, 23)
        Me.btnUbicaciones.TabIndex = 50
        Me.btnUbicaciones.Text = "..."
        Me.btnUbicaciones.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUbicaciones.UseVisualStyleBackColor = True
        '
        'cmbUbicacionRel
        '
        Me.cmbUbicacionRel.FormattingEnabled = True
        Me.cmbUbicacionRel.Location = New System.Drawing.Point(109, 211)
        Me.cmbUbicacionRel.Name = "cmbUbicacionRel"
        Me.cmbUbicacionRel.Size = New System.Drawing.Size(230, 21)
        Me.cmbUbicacionRel.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(6, 204)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 32)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "UBICACIÓN RELACIONADA"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPrioridad
        '
        Me.txtPrioridad.Enabled = False
        Me.txtPrioridad.Location = New System.Drawing.Point(311, 242)
        Me.txtPrioridad.Name = "txtPrioridad"
        Me.txtPrioridad.Size = New System.Drawing.Size(64, 22)
        Me.txtPrioridad.TabIndex = 11
        '
        'txtOcupadoPor
        '
        Me.txtOcupadoPor.Enabled = False
        Me.txtOcupadoPor.Location = New System.Drawing.Point(109, 241)
        Me.txtOcupadoPor.Name = "txtOcupadoPor"
        Me.txtOcupadoPor.Size = New System.Drawing.Size(127, 22)
        Me.txtOcupadoPor.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(239, 241)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 23)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "PRIORIDAD"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbZona
        '
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(109, 71)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(266, 21)
        Me.cmbZona.TabIndex = 3
        '
        'txtEstado
        '
        Me.txtEstado.Enabled = False
        Me.txtEstado.Location = New System.Drawing.Point(109, 152)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(266, 22)
        Me.txtEstado.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(7, 73)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 16)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "ZONA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(7, 240)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 23)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "OCUPADO POR"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(23, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 23)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "ESTADO"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActivo.Location = New System.Drawing.Point(311, 183)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 17)
        Me.chkActivo.TabIndex = 8
        Me.chkActivo.Text = "ACTIVO"
        Me.chkActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(626, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 23)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "CANT. PALLET OT 2"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCantPalletOT2
        '
        Me.txtCantPalletOT2.Location = New System.Drawing.Point(735, 180)
        Me.txtCantPalletOT2.MaxLength = 5
        Me.txtCantPalletOT2.Name = "txtCantPalletOT2"
        Me.txtCantPalletOT2.Size = New System.Drawing.Size(71, 22)
        Me.txtCantPalletOT2.TabIndex = 10
        Me.txtCantPalletOT2.Text = "0"
        Me.txtCantPalletOT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantPalletOT1
        '
        Me.txtCantPalletOT1.Location = New System.Drawing.Point(540, 183)
        Me.txtCantPalletOT1.MaxLength = 5
        Me.txtCantPalletOT1.Name = "txtCantPalletOT1"
        Me.txtCantPalletOT1.Size = New System.Drawing.Size(71, 22)
        Me.txtCantPalletOT1.TabIndex = 9
        Me.txtCantPalletOT1.Text = "0"
        Me.txtCantPalletOT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(431, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 23)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "CANT. PALLET OT 1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCantPalletDoble
        '
        Me.txtCantPalletDoble.Location = New System.Drawing.Point(735, 154)
        Me.txtCantPalletDoble.MaxLength = 5
        Me.txtCantPalletDoble.Name = "txtCantPalletDoble"
        Me.txtCantPalletDoble.Size = New System.Drawing.Size(71, 22)
        Me.txtCantPalletDoble.TabIndex = 8
        Me.txtCantPalletDoble.Text = "0"
        Me.txtCantPalletDoble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(612, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "CANT. PALLET DOBLE"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCantPallet
        '
        Me.txtCantPallet.Location = New System.Drawing.Point(540, 155)
        Me.txtCantPallet.MaxLength = 5
        Me.txtCantPallet.Name = "txtCantPallet"
        Me.txtCantPallet.Size = New System.Drawing.Size(71, 22)
        Me.txtCantPallet.TabIndex = 7
        Me.txtCantPallet.Text = "0"
        Me.txtCantPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(458, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 23)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "CANT. PALLET"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(109, 180)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(196, 22)
        Me.txtNombre.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(23, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 23)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "NOMBRE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 23)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "CAPACIDAD"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 23)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "PROVEEDOR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCapacidad
        '
        Me.cmbCapacidad.FormattingEnabled = True
        Me.cmbCapacidad.Location = New System.Drawing.Point(109, 125)
        Me.cmbCapacidad.Name = "cmbCapacidad"
        Me.cmbCapacidad.Size = New System.Drawing.Size(266, 21)
        Me.cmbCapacidad.TabIndex = 5
        '
        'cmbProveedor
        '
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(109, 98)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(266, 21)
        Me.cmbProveedor.TabIndex = 4
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(109, 43)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(266, 21)
        Me.cmbTipo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(31, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 37)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "TIPO DE UBICACIÓN"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBodegas
        '
        Me.cmbBodegas.FormattingEnabled = True
        Me.cmbBodegas.Location = New System.Drawing.Point(109, 16)
        Me.cmbBodegas.Name = "cmbBodegas"
        Me.cmbBodegas.Size = New System.Drawing.Size(266, 21)
        Me.cmbBodegas.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(41, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 23)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "BODEGA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMts3)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtFondo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtAncho)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtAlto)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(399, 72)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'txtMts3
        '
        Me.txtMts3.Location = New System.Drawing.Point(304, 43)
        Me.txtMts3.MaxLength = 5
        Me.txtMts3.Name = "txtMts3"
        Me.txtMts3.Size = New System.Drawing.Size(71, 22)
        Me.txtMts3.TabIndex = 15
        Me.txtMts3.Text = "0"
        Me.txtMts3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(222, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 23)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "MTS3"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFondo
        '
        Me.txtFondo.Location = New System.Drawing.Point(109, 42)
        Me.txtFondo.MaxLength = 5
        Me.txtFondo.Name = "txtFondo"
        Me.txtFondo.Size = New System.Drawing.Size(71, 22)
        Me.txtFondo.TabIndex = 14
        Me.txtFondo.Text = "0"
        Me.txtFondo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(27, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 23)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "FONDO"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(304, 15)
        Me.txtAncho.MaxLength = 5
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Size = New System.Drawing.Size(71, 22)
        Me.txtAncho.TabIndex = 13
        Me.txtAncho.Text = "0"
        Me.txtAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(222, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 23)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "ANCHO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAlto
        '
        Me.txtAlto.Location = New System.Drawing.Point(109, 14)
        Me.txtAlto.MaxLength = 5
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Size = New System.Drawing.Size(71, 22)
        Me.txtAlto.TabIndex = 12
        Me.txtAlto.Text = "0"
        Me.txtAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(27, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 23)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "ALTO"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_ingreso_ubicacion_old
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 373)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ingreso_ubicacion_old"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO DE UBICACIONES"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbBodegas As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCapacidad As ComboBox
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCantPalletOT2 As TextBox
    Friend WithEvents txtCantPalletOT1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCantPalletDoble As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCantPallet As TextBox
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtMts3 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtFondo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtAncho As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtAlto As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtOcupadoPor As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents txtPrioridad As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbUbicacionRel As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnUbicaciones As Button
End Class
