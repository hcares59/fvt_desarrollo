<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rec_orden_compra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rec_orden_compra))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonPaletizar = New System.Windows.Forms.ToolStripButton()
        Me.sepPaletiza = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonEnvio = New System.Windows.Forms.ToolStripButton()
        Me.sepAsignacion = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnRecepcion = New System.Windows.Forms.ToolStripButton()
        Me.sepRecepcion = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkTipoOrden = New System.Windows.Forms.CheckBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaArribo = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNomOC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaOC = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.col_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_codigointerno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_preciounitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_totalfila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clo_fila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quitar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbAsignarA = New System.Windows.Forms.ComboBox()
        Me.lblAsignarA = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtIva = New System.Windows.Forms.TextBox()
        Me.txtTotalNeto = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtValorFlete = New System.Windows.Forms.TextBox()
        Me.txtFechaPagoTransporte = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaVectoTransporte = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtNumeroImportacion = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtNumeroTransporte = New System.Windows.Forms.TextBox()
        Me.txtFechaEmbarque = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbEmpresaTransporte = New System.Windows.Forms.ComboBox()
        Me.txtFacturaTransporte = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbCondicionPago = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbPagoFacturas = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbDiasPago = New System.Windows.Forms.ComboBox()
        Me.txtProforma = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtFechaDescarga = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbEmpresaDescarga = New System.Windows.Forms.ComboBox()
        Me.txtFacturaDescarga = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtFechaVencimientoCredito = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbDiasPagoCredito = New System.Windows.Forms.ComboBox()
        Me.txtFechaAperturaCC = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtCertificadoSeguro = New System.Windows.Forms.TextBox()
        Me.txtFacturaImportacion = New System.Windows.Forms.TextBox()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmbAgencia = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrillaAdjunto = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colarchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colse = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNombreArchivo = New System.Windows.Forms.TextBox()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.cmdSelecMulti = New System.Windows.Forms.Button()
        Me.txtMultRuta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GrillaAdjunto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(691, 4)
        Me.Panel1.TabIndex = 34
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonPaletizar, Me.sepPaletiza, Me.ButtonEnvio, Me.sepAsignacion, Me.BtnRecepcion, Me.sepRecepcion, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(691, 25)
        Me.ToolStrip1.TabIndex = 35
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
        Me.ButtonNuevo.Visible = False
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
        'ButtonPaletizar
        '
        Me.ButtonPaletizar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPaletizar.Image = CType(resources.GetObject("ButtonPaletizar.Image"), System.Drawing.Image)
        Me.ButtonPaletizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonPaletizar.Name = "ButtonPaletizar"
        Me.ButtonPaletizar.Size = New System.Drawing.Size(154, 22)
        Me.ButtonPaletizar.Text = "PALETIZACIÓN ESTIMADA"
        '
        'sepPaletiza
        '
        Me.sepPaletiza.Name = "sepPaletiza"
        Me.sepPaletiza.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonEnvio
        '
        Me.ButtonEnvio.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEnvio.Image = CType(resources.GetObject("ButtonEnvio.Image"), System.Drawing.Image)
        Me.ButtonEnvio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonEnvio.Name = "ButtonEnvio"
        Me.ButtonEnvio.Size = New System.Drawing.Size(84, 22)
        Me.ButtonEnvio.Text = "ASIGNA OC"
        Me.ButtonEnvio.Visible = False
        '
        'sepAsignacion
        '
        Me.sepAsignacion.Name = "sepAsignacion"
        Me.sepAsignacion.Size = New System.Drawing.Size(6, 25)
        Me.sepAsignacion.Visible = False
        '
        'BtnRecepcion
        '
        Me.BtnRecepcion.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRecepcion.Image = CType(resources.GetObject("BtnRecepcion.Image"), System.Drawing.Image)
        Me.BtnRecepcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRecepcion.Name = "BtnRecepcion"
        Me.BtnRecepcion.Size = New System.Drawing.Size(130, 22)
        Me.BtnRecepcion.Text = "GENERA RECEPCIÓN"
        Me.BtnRecepcion.Visible = False
        '
        'sepRecepcion
        '
        Me.sepRecepcion.Name = "sepRecepcion"
        Me.sepRecepcion.Size = New System.Drawing.Size(6, 25)
        Me.sepRecepcion.Visible = False
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
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(691, 4)
        Me.Panel2.TabIndex = 36
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.chkTipoOrden)
        Me.Panel3.Controls.Add(Me.txtTipoCambio)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtFechaArribo)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtNomOC)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtFechaOC)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbProveedor)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(691, 58)
        Me.Panel3.TabIndex = 38
        '
        'chkTipoOrden
        '
        Me.chkTipoOrden.AutoSize = True
        Me.chkTipoOrden.Location = New System.Drawing.Point(493, 8)
        Me.chkTipoOrden.Name = "chkTipoOrden"
        Me.chkTipoOrden.Size = New System.Drawing.Size(164, 17)
        Me.chkTipoOrden.TabIndex = 10
        Me.chkTipoOrden.Text = "Orden de compra Nacional"
        Me.chkTipoOrden.UseVisualStyleBackColor = True
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(587, 29)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(93, 22)
        Me.txtTipoCambio.TabIndex = 9
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(490, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Tipo de cambio"
        '
        'txtFechaArribo
        '
        Me.txtFechaArribo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaArribo.Location = New System.Drawing.Point(188, 29)
        Me.txtFechaArribo.Name = "txtFechaArribo"
        Me.txtFechaArribo.Size = New System.Drawing.Size(93, 22)
        Me.txtFechaArribo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "ETA (Fecha posible de arribo)"
        '
        'txtNomOC
        '
        Me.txtNomOC.Location = New System.Drawing.Point(371, 4)
        Me.txtNomOC.Name = "txtNomOC"
        Me.txtNomOC.Size = New System.Drawing.Size(93, 22)
        Me.txtNomOC.TabIndex = 5
        Me.txtNomOC.Text = "0"
        Me.txtNomOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(327, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "N° OC"
        '
        'txtFechaOC
        '
        Me.txtFechaOC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaOC.Location = New System.Drawing.Point(371, 29)
        Me.txtFechaOC.Name = "txtFechaOC"
        Me.txtFechaOC.Size = New System.Drawing.Size(93, 22)
        Me.txtFechaOC.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(309, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha OC"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(72, 4)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(209, 21)
        Me.cmbProveedor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Proveedor"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 473)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(691, 22)
        Me.StatusStrip1.TabIndex = 39
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla.ColumnHeadersHeight = 25
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_codigo, Me.pro_codigointerno, Me.col_nombre, Me.col_cantidad, Me.col_preciounitario, Me.col_totalfila, Me.clo_fila, Me.quitar})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(3, 3)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Grilla.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(677, 232)
        Me.Grilla.TabIndex = 40
        '
        'col_codigo
        '
        Me.col_codigo.HeaderText = "PRO_CODIGO"
        Me.col_codigo.Name = "col_codigo"
        Me.col_codigo.Visible = False
        '
        'pro_codigointerno
        '
        Me.pro_codigointerno.HeaderText = "Código"
        Me.pro_codigointerno.Name = "pro_codigointerno"
        Me.pro_codigointerno.Width = 70
        '
        'col_nombre
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.col_nombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_nombre.HeaderText = "Nombre del producto"
        Me.col_nombre.Name = "col_nombre"
        Me.col_nombre.ReadOnly = True
        Me.col_nombre.Width = 250
        '
        'col_cantidad
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_cantidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_cantidad.HeaderText = "Cantidad"
        Me.col_cantidad.Name = "col_cantidad"
        Me.col_cantidad.Width = 70
        '
        'col_preciounitario
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_preciounitario.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_preciounitario.HeaderText = "Precio FOB"
        Me.col_preciounitario.Name = "col_preciounitario"
        Me.col_preciounitario.Width = 80
        '
        'col_totalfila
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_totalfila.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_totalfila.HeaderText = "Total"
        Me.col_totalfila.Name = "col_totalfila"
        Me.col_totalfila.ReadOnly = True
        Me.col_totalfila.Width = 80
        '
        'clo_fila
        '
        Me.clo_fila.HeaderText = "FILA"
        Me.clo_fila.Name = "clo_fila"
        Me.clo_fila.ReadOnly = True
        Me.clo_fila.Visible = False
        '
        'quitar
        '
        Me.quitar.HeaderText = ""
        Me.quitar.Name = "quitar"
        Me.quitar.Text = "QUITAR"
        Me.quitar.UseColumnTextForButtonValue = True
        Me.quitar.Width = 60
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmbAsignarA)
        Me.Panel4.Controls.Add(Me.lblAsignarA)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(691, 33)
        Me.Panel4.TabIndex = 41
        '
        'cmbAsignarA
        '
        Me.cmbAsignarA.FormattingEnabled = True
        Me.cmbAsignarA.Location = New System.Drawing.Point(492, 5)
        Me.cmbAsignarA.Name = "cmbAsignarA"
        Me.cmbAsignarA.Size = New System.Drawing.Size(187, 21)
        Me.cmbAsignarA.TabIndex = 3
        Me.cmbAsignarA.Visible = False
        '
        'lblAsignarA
        '
        Me.lblAsignarA.AutoSize = True
        Me.lblAsignarA.ForeColor = System.Drawing.Color.Black
        Me.lblAsignarA.Location = New System.Drawing.Point(426, 9)
        Me.lblAsignarA.Name = "lblAsignarA"
        Me.lblAsignarA.Size = New System.Drawing.Size(63, 13)
        Me.lblAsignarA.TabIndex = 2
        Me.lblAsignarA.Text = "ASIGNAR A"
        Me.lblAsignarA.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ORDEN DE COMPRA PROVEEDOR"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.txtTotal)
        Me.Panel5.Controls.Add(Me.txtIva)
        Me.Panel5.Controls.Add(Me.txtTotalNeto)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 388)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(691, 85)
        Me.Panel5.TabIndex = 42
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(526, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Total"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(536, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "IVA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(500, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Total Neto"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(565, 56)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 22)
        Me.txtTotal.TabIndex = 2
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIva
        '
        Me.txtIva.Enabled = False
        Me.txtIva.Location = New System.Drawing.Point(565, 31)
        Me.txtIva.Name = "txtIva"
        Me.txtIva.Size = New System.Drawing.Size(100, 22)
        Me.txtIva.TabIndex = 1
        Me.txtIva.Text = "0"
        Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.Enabled = False
        Me.txtTotalNeto.Location = New System.Drawing.Point(565, 6)
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.Size = New System.Drawing.Size(100, 22)
        Me.txtTotalNeto.TabIndex = 0
        Me.txtTotalNeto.Text = "0"
        Me.txtTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 124)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(691, 264)
        Me.TabControl1.TabIndex = 43
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grilla)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(683, 238)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle de la OC"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(683, 238)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Transporte"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtValorFlete)
        Me.GroupBox3.Controls.Add(Me.txtFechaPagoTransporte)
        Me.GroupBox3.Controls.Add(Me.txtFechaVectoTransporte)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtNumeroImportacion)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtNumeroTransporte)
        Me.GroupBox3.Controls.Add(Me.txtFechaEmbarque)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.cmbEmpresaTransporte)
        Me.GroupBox3.Controls.Add(Me.txtFacturaTransporte)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(671, 233)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'txtValorFlete
        '
        Me.txtValorFlete.Location = New System.Drawing.Point(452, 101)
        Me.txtValorFlete.Name = "txtValorFlete"
        Me.txtValorFlete.Size = New System.Drawing.Size(165, 22)
        Me.txtValorFlete.TabIndex = 18
        Me.txtValorFlete.Text = "0"
        Me.txtValorFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaPagoTransporte
        '
        Me.txtFechaPagoTransporte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaPagoTransporte.Location = New System.Drawing.Point(452, 45)
        Me.txtFechaPagoTransporte.Name = "txtFechaPagoTransporte"
        Me.txtFechaPagoTransporte.Size = New System.Drawing.Size(165, 22)
        Me.txtFechaPagoTransporte.TabIndex = 17
        '
        'txtFechaVectoTransporte
        '
        Me.txtFechaVectoTransporte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaVectoTransporte.Location = New System.Drawing.Point(452, 73)
        Me.txtFechaVectoTransporte.Name = "txtFechaVectoTransporte"
        Me.txtFechaVectoTransporte.Size = New System.Drawing.Size(165, 22)
        Me.txtFechaVectoTransporte.TabIndex = 16
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(367, 103)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(78, 13)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Valor del flete"
        '
        'txtNumeroImportacion
        '
        Me.txtNumeroImportacion.Enabled = False
        Me.txtNumeroImportacion.Location = New System.Drawing.Point(452, 18)
        Me.txtNumeroImportacion.Name = "txtNumeroImportacion"
        Me.txtNumeroImportacion.Size = New System.Drawing.Size(165, 22)
        Me.txtNumeroImportacion.TabIndex = 14
        Me.txtNumeroImportacion.Text = "0"
        Me.txtNumeroImportacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(347, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 13)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "N° de importación"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(14, 102)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(118, 13)
        Me.Label22.TabIndex = 12
        Me.Label22.Text = "N°Transporte (CTR/BL)"
        '
        'txtNumeroTransporte
        '
        Me.txtNumeroTransporte.Location = New System.Drawing.Point(136, 101)
        Me.txtNumeroTransporte.Name = "txtNumeroTransporte"
        Me.txtNumeroTransporte.Size = New System.Drawing.Size(165, 22)
        Me.txtNumeroTransporte.TabIndex = 11
        Me.txtNumeroTransporte.Text = "0"
        Me.txtNumeroTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaEmbarque
        '
        Me.txtFechaEmbarque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaEmbarque.Location = New System.Drawing.Point(136, 73)
        Me.txtFechaEmbarque.Name = "txtFechaEmbarque"
        Me.txtFechaEmbarque.Size = New System.Drawing.Size(165, 22)
        Me.txtFechaEmbarque.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(22, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Fecha de embarque"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(365, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Fecha de pago"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(330, 75)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Fecha de vencimiento"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "N°Factura transporte"
        '
        'cmbEmpresaTransporte
        '
        Me.cmbEmpresaTransporte.FormattingEnabled = True
        Me.cmbEmpresaTransporte.Location = New System.Drawing.Point(136, 19)
        Me.cmbEmpresaTransporte.Name = "cmbEmpresaTransporte"
        Me.cmbEmpresaTransporte.Size = New System.Drawing.Size(165, 21)
        Me.cmbEmpresaTransporte.TabIndex = 3
        '
        'txtFacturaTransporte
        '
        Me.txtFacturaTransporte.Location = New System.Drawing.Point(136, 45)
        Me.txtFacturaTransporte.Name = "txtFacturaTransporte"
        Me.txtFacturaTransporte.Size = New System.Drawing.Size(165, 22)
        Me.txtFacturaTransporte.TabIndex = 2
        Me.txtFacturaTransporte.Text = "0"
        Me.txtFacturaTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(123, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Empresa de transporte"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(683, 238)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Factura"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaPago)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbCondicionPago)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmbPagoFacturas)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbDiasPago)
        Me.GroupBox1.Controls.Add(Me.txtProforma)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 233)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtFechaPago
        '
        Me.txtFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaPago.Location = New System.Drawing.Point(136, 128)
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.Size = New System.Drawing.Size(165, 22)
        Me.txtFechaPago.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(43, 132)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 13)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Fecha de pago"
        '
        'cmbCondicionPago
        '
        Me.cmbCondicionPago.FormattingEnabled = True
        Me.cmbCondicionPago.Location = New System.Drawing.Point(136, 101)
        Me.cmbCondicionPago.Name = "cmbCondicionPago"
        Me.cmbCondicionPago.Size = New System.Drawing.Size(165, 21)
        Me.cmbCondicionPago.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Condición de pago"
        '
        'cmbPagoFacturas
        '
        Me.cmbPagoFacturas.FormattingEnabled = True
        Me.cmbPagoFacturas.Location = New System.Drawing.Point(136, 73)
        Me.cmbPagoFacturas.Name = "cmbPagoFacturas"
        Me.cmbPagoFacturas.Size = New System.Drawing.Size(165, 21)
        Me.cmbPagoFacturas.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(38, 76)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Pago de factura"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(67, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Días pago"
        '
        'cmbDiasPago
        '
        Me.cmbDiasPago.FormattingEnabled = True
        Me.cmbDiasPago.Location = New System.Drawing.Point(136, 46)
        Me.cmbDiasPago.Name = "cmbDiasPago"
        Me.cmbDiasPago.Size = New System.Drawing.Size(165, 21)
        Me.cmbDiasPago.TabIndex = 3
        '
        'txtProforma
        '
        Me.txtProforma.Location = New System.Drawing.Point(136, 18)
        Me.txtProforma.Name = "txtProforma"
        Me.txtProforma.Size = New System.Drawing.Size(165, 22)
        Me.txtProforma.TabIndex = 2
        Me.txtProforma.Text = "0"
        Me.txtProforma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "N°Factura Proforma"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBox4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(683, 238)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Descarga"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtFechaDescarga)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.cmbEmpresaDescarga)
        Me.GroupBox4.Controls.Add(Me.txtFacturaDescarga)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(671, 233)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'txtFechaDescarga
        '
        Me.txtFechaDescarga.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaDescarga.Location = New System.Drawing.Point(136, 75)
        Me.txtFechaDescarga.Name = "txtFechaDescarga"
        Me.txtFechaDescarga.Size = New System.Drawing.Size(165, 22)
        Me.txtFechaDescarga.TabIndex = 10
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(28, 78)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(102, 13)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Fecha de descarga"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(73, 50)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 13)
        Me.Label28.TabIndex = 4
        Me.Label28.Text = "N°Factura"
        '
        'cmbEmpresaDescarga
        '
        Me.cmbEmpresaDescarga.FormattingEnabled = True
        Me.cmbEmpresaDescarga.Location = New System.Drawing.Point(136, 20)
        Me.cmbEmpresaDescarga.Name = "cmbEmpresaDescarga"
        Me.cmbEmpresaDescarga.Size = New System.Drawing.Size(165, 21)
        Me.cmbEmpresaDescarga.TabIndex = 3
        '
        'txtFacturaDescarga
        '
        Me.txtFacturaDescarga.Location = New System.Drawing.Point(136, 47)
        Me.txtFacturaDescarga.Name = "txtFacturaDescarga"
        Me.txtFacturaDescarga.Size = New System.Drawing.Size(165, 22)
        Me.txtFacturaDescarga.TabIndex = 2
        Me.txtFacturaDescarga.Text = "0"
        Me.txtFacturaDescarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(14, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(115, 13)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "Empresa de descarga"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.GroupBox5)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(683, 238)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Crédito"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtFechaVencimientoCredito)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.cmbDiasPagoCredito)
        Me.GroupBox5.Controls.Add(Me.txtFechaAperturaCC)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.cmbBanco)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(671, 233)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'txtFechaVencimientoCredito
        '
        Me.txtFechaVencimientoCredito.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaVencimientoCredito.Location = New System.Drawing.Point(136, 102)
        Me.txtFechaVencimientoCredito.Name = "txtFechaVencimientoCredito"
        Me.txtFechaVencimientoCredito.Size = New System.Drawing.Size(165, 22)
        Me.txtFechaVencimientoCredito.TabIndex = 13
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(13, 105)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(118, 13)
        Me.Label31.TabIndex = 12
        Me.Label31.Text = "Fecha de vencimiento"
        '
        'cmbDiasPagoCredito
        '
        Me.cmbDiasPagoCredito.FormattingEnabled = True
        Me.cmbDiasPagoCredito.Location = New System.Drawing.Point(136, 75)
        Me.cmbDiasPagoCredito.Name = "cmbDiasPagoCredito"
        Me.cmbDiasPagoCredito.Size = New System.Drawing.Size(165, 21)
        Me.cmbDiasPagoCredito.TabIndex = 11
        '
        'txtFechaAperturaCC
        '
        Me.txtFechaAperturaCC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaAperturaCC.Location = New System.Drawing.Point(136, 47)
        Me.txtFechaAperturaCC.Name = "txtFechaAperturaCC"
        Me.txtFechaAperturaCC.Size = New System.Drawing.Size(165, 22)
        Me.txtFechaAperturaCC.TabIndex = 10
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(14, 50)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(117, 13)
        Me.Label26.TabIndex = 9
        Me.Label26.Text = "Fecha de apertura CC"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(55, 76)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(75, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Dias de pago"
        '
        'cmbBanco
        '
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(136, 20)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(165, 21)
        Me.cmbBanco.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(28, 23)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(102, 13)
        Me.Label30.TabIndex = 1
        Me.Label30.Text = "Nombre del banco"
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.GroupBox6)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(683, 238)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Agencia aduana"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtCertificadoSeguro)
        Me.GroupBox6.Controls.Add(Me.txtFacturaImportacion)
        Me.GroupBox6.Controls.Add(Me.txtDNI)
        Me.GroupBox6.Controls.Add(Me.Label32)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.cmbAgencia)
        Me.GroupBox6.Controls.Add(Me.Label35)
        Me.GroupBox6.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(671, 233)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'txtCertificadoSeguro
        '
        Me.txtCertificadoSeguro.Location = New System.Drawing.Point(136, 102)
        Me.txtCertificadoSeguro.Name = "txtCertificadoSeguro"
        Me.txtCertificadoSeguro.Size = New System.Drawing.Size(165, 22)
        Me.txtCertificadoSeguro.TabIndex = 15
        Me.txtCertificadoSeguro.Text = "0"
        Me.txtCertificadoSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFacturaImportacion
        '
        Me.txtFacturaImportacion.Location = New System.Drawing.Point(136, 75)
        Me.txtFacturaImportacion.Name = "txtFacturaImportacion"
        Me.txtFacturaImportacion.Size = New System.Drawing.Size(165, 22)
        Me.txtFacturaImportacion.TabIndex = 14
        Me.txtFacturaImportacion.Text = "0"
        Me.txtFacturaImportacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(136, 47)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(165, 22)
        Me.txtDNI.TabIndex = 13
        Me.txtDNI.Text = "0"
        Me.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(3, 105)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(130, 13)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "N°Certificado de seguro"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(61, 50)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 9
        Me.Label33.Text = "Número DNI"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(9, 78)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(122, 13)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "N°Factura importación"
        '
        'cmbAgencia
        '
        Me.cmbAgencia.FormattingEnabled = True
        Me.cmbAgencia.Location = New System.Drawing.Point(136, 20)
        Me.cmbAgencia.Name = "cmbAgencia"
        Me.cmbAgencia.Size = New System.Drawing.Size(165, 21)
        Me.cmbAgencia.TabIndex = 3
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(26, 23)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(107, 13)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "Nombre de agencia"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GrillaAdjunto)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(683, 238)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Documentos adjuntos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GrillaAdjunto
        '
        Me.GrillaAdjunto.AllowUserToAddRows = False
        Me.GrillaAdjunto.AllowUserToDeleteRows = False
        Me.GrillaAdjunto.BackgroundColor = System.Drawing.Color.White
        Me.GrillaAdjunto.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaAdjunto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GrillaAdjunto.ColumnHeadersHeight = 25
        Me.GrillaAdjunto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn3, Me.colarchivo, Me.colse, Me.DataGridViewButtonColumn1, Me.DataGridViewButtonColumn2})
        Me.GrillaAdjunto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GrillaAdjunto.EnableHeadersVisualStyles = False
        Me.GrillaAdjunto.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaAdjunto.Location = New System.Drawing.Point(3, 73)
        Me.GrillaAdjunto.Name = "GrillaAdjunto"
        Me.GrillaAdjunto.ReadOnly = True
        Me.GrillaAdjunto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaAdjunto.RowHeadersVisible = False
        Me.GrillaAdjunto.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaAdjunto.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaAdjunto.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaAdjunto.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaAdjunto.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaAdjunto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaAdjunto.Size = New System.Drawing.Size(677, 162)
        Me.GrillaAdjunto.TabIndex = 53
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "fila"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'colarchivo
        '
        Me.colarchivo.HeaderText = "ARCHIVO"
        Me.colarchivo.Name = "colarchivo"
        Me.colarchivo.ReadOnly = True
        Me.colarchivo.Width = 150
        '
        'colse
        '
        Me.colse.HeaderText = ""
        Me.colse.Name = "colse"
        Me.colse.ReadOnly = True
        Me.colse.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colse.Text = "SELECCION"
        Me.colse.UseColumnTextForButtonValue = True
        Me.colse.Width = 80
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Text = "ABRIR ADJUNTO"
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.HeaderText = ""
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.ReadOnly = True
        Me.DataGridViewButtonColumn2.Text = "ELIMINAR"
        Me.DataGridViewButtonColumn2.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn2.Width = 80
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtNombreArchivo)
        Me.GroupBox2.Controls.Add(Me.btnAdjuntar)
        Me.GroupBox2.Controls.Add(Me.cmdSelecMulti)
        Me.GroupBox2.Controls.Add(Me.txtMultRuta)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(6, -2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(671, 69)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 13)
        Me.Label13.TabIndex = 163
        Me.Label13.Text = "Ingrese nombre"
        '
        'txtNombreArchivo
        '
        Me.txtNombreArchivo.Location = New System.Drawing.Point(114, 39)
        Me.txtNombreArchivo.MaxLength = 50
        Me.txtNombreArchivo.Name = "txtNombreArchivo"
        Me.txtNombreArchivo.Size = New System.Drawing.Size(515, 22)
        Me.txtNombreArchivo.TabIndex = 162
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.Image = CType(resources.GetObject("btnAdjuntar.Image"), System.Drawing.Image)
        Me.btnAdjuntar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdjuntar.Location = New System.Drawing.Point(544, 11)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(85, 25)
        Me.btnAdjuntar.TabIndex = 161
        Me.btnAdjuntar.Text = "    Adjuntar"
        Me.btnAdjuntar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        '
        'cmdSelecMulti
        '
        Me.cmdSelecMulti.Location = New System.Drawing.Point(518, 11)
        Me.cmdSelecMulti.Name = "cmdSelecMulti"
        Me.cmdSelecMulti.Size = New System.Drawing.Size(24, 25)
        Me.cmdSelecMulti.TabIndex = 160
        Me.cmdSelecMulti.Text = "..."
        Me.cmdSelecMulti.UseVisualStyleBackColor = True
        '
        'txtMultRuta
        '
        Me.txtMultRuta.Enabled = False
        Me.txtMultRuta.Location = New System.Drawing.Point(114, 13)
        Me.txtMultRuta.MaxLength = 5
        Me.txtMultRuta.Name = "txtMultRuta"
        Me.txtMultRuta.Size = New System.Drawing.Size(403, 22)
        Me.txtMultRuta.TabIndex = 159
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Seleccione archivo"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(421, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 37)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'rec_orden_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 495)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "rec_orden_compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ORDEN DE COMPRA PROVEEDOR"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.GrillaAdjunto, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtNomOC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFechaOC As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTipoCambio As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFechaArribo As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents chkTipoOrden As CheckBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtIva As TextBox
    Friend WithEvents txtTotalNeto As TextBox
    Friend WithEvents ButtonPaletizar As ToolStripButton
    Friend WithEvents sepPaletiza As ToolStripSeparator
    Friend WithEvents cmbAsignarA As ComboBox
    Friend WithEvents lblAsignarA As Label
    Friend WithEvents ButtonEnvio As ToolStripButton
    Friend WithEvents sepAsignacion As ToolStripSeparator
    Friend WithEvents BtnRecepcion As ToolStripButton
    Friend WithEvents sepRecepcion As ToolStripSeparator
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GrillaAdjunto As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents colarchivo As DataGridViewTextBoxColumn
    Friend WithEvents colse As DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn2 As DataGridViewButtonColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNombreArchivo As TextBox
    Friend WithEvents btnAdjuntar As Button
    Friend WithEvents cmdSelecMulti As Button
    Friend WithEvents txtMultRuta As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents col_codigo As DataGridViewTextBoxColumn
    Friend WithEvents pro_codigointerno As DataGridViewTextBoxColumn
    Friend WithEvents col_nombre As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents col_preciounitario As DataGridViewTextBoxColumn
    Friend WithEvents col_totalfila As DataGridViewTextBoxColumn
    Friend WithEvents clo_fila As DataGridViewTextBoxColumn
    Friend WithEvents quitar As DataGridViewButtonColumn
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFechaPago As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbCondicionPago As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbPagoFacturas As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbDiasPago As ComboBox
    Friend WithEvents txtProforma As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtValorFlete As TextBox
    Friend WithEvents txtFechaPagoTransporte As DateTimePicker
    Friend WithEvents txtFechaVectoTransporte As DateTimePicker
    Friend WithEvents Label24 As Label
    Friend WithEvents txtNumeroImportacion As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtNumeroTransporte As TextBox
    Friend WithEvents txtFechaEmbarque As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbEmpresaTransporte As ComboBox
    Friend WithEvents txtFacturaTransporte As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtFechaDescarga As DateTimePicker
    Friend WithEvents Label25 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents cmbEmpresaDescarga As ComboBox
    Friend WithEvents txtFacturaDescarga As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtFechaVencimientoCredito As DateTimePicker
    Friend WithEvents Label31 As Label
    Friend WithEvents cmbDiasPagoCredito As ComboBox
    Friend WithEvents txtFechaAperturaCC As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents cmbBanco As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtCertificadoSeguro As TextBox
    Friend WithEvents txtFacturaImportacion As TextBox
    Friend WithEvents txtDNI As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents cmbAgencia As ComboBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Button1 As Button
End Class
