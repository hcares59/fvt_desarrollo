<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ingreso_agenda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ingreso_agenda))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonConfirmar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkPorconfirmar = New System.Windows.Forms.CheckBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrillaFechas = New System.Windows.Forms.DataGridView()
        Me.COL_COD_PICKING = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_fecha_p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fec_ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colmonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_esabierta = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkConfirmar = New System.Windows.Forms.CheckBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkTipoOrden = New System.Windows.Forms.CheckBox()
        Me.txtFechaCita = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaOrdenCompra = New System.Windows.Forms.TextBox()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grillaDetalle = New System.Windows.Forms.DataGridView()
        Me.colOCnumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFCons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CNOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CSKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CNOMBRECLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLPRECIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLCANTIDADR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLDPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GrillaFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grillaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(991, 32)
        Me.Panel2.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonConfirmar, Me.ToolStripSeparator3, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(991, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(65, 22)
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
        'ButtonConfirmar
        '
        Me.ButtonConfirmar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonConfirmar.Image = CType(resources.GetObject("ButtonConfirmar.Image"), System.Drawing.Image)
        Me.ButtonConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonConfirmar.Name = "ButtonConfirmar"
        Me.ButtonConfirmar.Size = New System.Drawing.Size(91, 22)
        Me.ButtonConfirmar.Text = "CONFIRMAR"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 23)
        Me.Panel1.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(20, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "INGRESO DE AGENDA"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.chkPorconfirmar)
        Me.Panel4.Controls.Add(Me.cmbCliente)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 55)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(991, 28)
        Me.Panel4.TabIndex = 12
        '
        'chkPorconfirmar
        '
        Me.chkPorconfirmar.AutoSize = True
        Me.chkPorconfirmar.Location = New System.Drawing.Point(702, 5)
        Me.chkPorconfirmar.Name = "chkPorconfirmar"
        Me.chkPorconfirmar.Size = New System.Drawing.Size(95, 17)
        Me.chkPorconfirmar.TabIndex = 2
        Me.chkPorconfirmar.Text = "Por confirmar"
        Me.chkPorconfirmar.UseVisualStyleBackColor = True
        Me.chkPorconfirmar.Visible = False
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(117, 3)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(313, 21)
        Me.cmbCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione cliente"
        '
        'GrillaFechas
        '
        Me.GrillaFechas.AllowUserToAddRows = False
        Me.GrillaFechas.AllowUserToDeleteRows = False
        Me.GrillaFechas.BackgroundColor = System.Drawing.Color.White
        Me.GrillaFechas.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaFechas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaFechas.ColumnHeadersHeight = 25
        Me.GrillaFechas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_COD_PICKING, Me.col_fecha_p, Me.col_fec_ingreso, Me.colmonto, Me.col_esabierta, Me.Column2})
        Me.GrillaFechas.EnableHeadersVisualStyles = False
        Me.GrillaFechas.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaFechas.Location = New System.Drawing.Point(7, 21)
        Me.GrillaFechas.Name = "GrillaFechas"
        Me.GrillaFechas.ReadOnly = True
        Me.GrillaFechas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaFechas.RowHeadersVisible = False
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaFechas.Size = New System.Drawing.Size(360, 159)
        Me.GrillaFechas.TabIndex = 13
        '
        'COL_COD_PICKING
        '
        Me.COL_COD_PICKING.HeaderText = "S"
        Me.COL_COD_PICKING.Name = "COL_COD_PICKING"
        Me.COL_COD_PICKING.ReadOnly = True
        Me.COL_COD_PICKING.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.COL_COD_PICKING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.COL_COD_PICKING.Visible = False
        Me.COL_COD_PICKING.Width = 30
        '
        'col_fecha_p
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_fecha_p.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_fecha_p.HeaderText = "Orden Compra"
        Me.col_fecha_p.Name = "col_fecha_p"
        Me.col_fecha_p.ReadOnly = True
        Me.col_fecha_p.Width = 110
        '
        'col_fec_ingreso
        '
        Me.col_fec_ingreso.HeaderText = "Fecha"
        Me.col_fec_ingreso.Name = "col_fec_ingreso"
        Me.col_fec_ingreso.ReadOnly = True
        Me.col_fec_ingreso.Width = 90
        '
        'colmonto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colmonto.DefaultCellStyle = DataGridViewCellStyle3
        Me.colmonto.HeaderText = "Monto"
        Me.colmonto.Name = "colmonto"
        Me.colmonto.ReadOnly = True
        '
        'col_esabierta
        '
        Me.col_esabierta.HeaderText = "es abierta"
        Me.col_esabierta.Name = "col_esabierta"
        Me.col_esabierta.ReadOnly = True
        Me.col_esabierta.Visible = False
        Me.col_esabierta.Width = 40
        '
        'Column2
        '
        Me.Column2.HeaderText = "es_porconfimar"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ChkConfirmar)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkTipoOrden)
        Me.GroupBox1.Controls.Add(Me.txtFechaCita)
        Me.GroupBox1.Controls.Add(Me.txtFechaOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(389, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 190)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información general de la cita"
        '
        'ChkConfirmar
        '
        Me.ChkConfirmar.AutoSize = True
        Me.ChkConfirmar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkConfirmar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkConfirmar.Location = New System.Drawing.Point(120, 133)
        Me.ChkConfirmar.Name = "ChkConfirmar"
        Me.ChkConfirmar.Size = New System.Drawing.Size(110, 17)
        Me.ChkConfirmar.TabIndex = 21
        Me.ChkConfirmar.Text = "Conformar todo"
        Me.ChkConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkConfirmar.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.Enabled = False
        Me.txtMonto.Location = New System.Drawing.Point(120, 74)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 22)
        Me.txtMonto.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(62, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Monto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkTipoOrden
        '
        Me.chkTipoOrden.AutoSize = True
        Me.chkTipoOrden.Enabled = False
        Me.chkTipoOrden.Location = New System.Drawing.Point(691, 129)
        Me.chkTipoOrden.Name = "chkTipoOrden"
        Me.chkTipoOrden.Size = New System.Drawing.Size(98, 17)
        Me.chkTipoOrden.TabIndex = 18
        Me.chkTipoOrden.Text = "Orden abierta"
        Me.chkTipoOrden.UseVisualStyleBackColor = True
        Me.chkTipoOrden.Visible = False
        '
        'txtFechaCita
        '
        Me.txtFechaCita.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaCita.Location = New System.Drawing.Point(121, 103)
        Me.txtFechaCita.Name = "txtFechaCita"
        Me.txtFechaCita.Size = New System.Drawing.Size(99, 22)
        Me.txtFechaCita.TabIndex = 4
        '
        'txtFechaOrdenCompra
        '
        Me.txtFechaOrdenCompra.Enabled = False
        Me.txtFechaOrdenCompra.Location = New System.Drawing.Point(120, 46)
        Me.txtFechaOrdenCompra.Name = "txtFechaOrdenCompra"
        Me.txtFechaOrdenCompra.Size = New System.Drawing.Size(100, 22)
        Me.txtFechaOrdenCompra.TabIndex = 3
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Enabled = False
        Me.txtOrdenCompra.Location = New System.Drawing.Point(120, 18)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(100, 22)
        Me.txtOrdenCompra.TabIndex = 2
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Fecha agenda"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(1, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha O. Compra"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Orden de Compra"
        '
        'grillaDetalle
        '
        Me.grillaDetalle.AllowUserToAddRows = False
        Me.grillaDetalle.AllowUserToDeleteRows = False
        Me.grillaDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaDetalle.BackgroundColor = System.Drawing.Color.White
        Me.grillaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaDetalle.ColumnHeadersHeight = 25
        Me.grillaDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOCnumero, Me.colFCons, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.CNOM, Me.CSKU, Me.CNOMBRECLIENTE, Me.CLPRECIO, Me.CLCANTIDADR, Me.CLDPE, Me.Column1, Me.CCAG})
        Me.grillaDetalle.EnableHeadersVisualStyles = False
        Me.grillaDetalle.GridColor = System.Drawing.SystemColors.HotTrack
        Me.grillaDetalle.Location = New System.Drawing.Point(0, 283)
        Me.grillaDetalle.Name = "grillaDetalle"
        Me.grillaDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.grillaDetalle.RowHeadersVisible = False
        Me.grillaDetalle.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grillaDetalle.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grillaDetalle.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grillaDetalle.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.grillaDetalle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.grillaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grillaDetalle.Size = New System.Drawing.Size(991, 314)
        Me.grillaDetalle.TabIndex = 15
        '
        'colOCnumero
        '
        Me.colOCnumero.HeaderText = "OC"
        Me.colOCnumero.Name = "colOCnumero"
        Me.colOCnumero.ReadOnly = True
        Me.colOCnumero.Visible = False
        '
        'colFCons
        '
        Me.colFCons.HeaderText = "FILA CONSO"
        Me.colFCons.Name = "colFCons"
        Me.colFCons.ReadOnly = True
        Me.colFCons.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn1.HeaderText = "PRO_CODIGO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 110
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "C. Interno"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'CNOM
        '
        Me.CNOM.HeaderText = "Nombre Favatex"
        Me.CNOM.Name = "CNOM"
        Me.CNOM.ReadOnly = True
        Me.CNOM.Width = 180
        '
        'CSKU
        '
        Me.CSKU.HeaderText = "Sku Cliente"
        Me.CSKU.Name = "CSKU"
        Me.CSKU.ReadOnly = True
        '
        'CNOMBRECLIENTE
        '
        Me.CNOMBRECLIENTE.HeaderText = "Nombre Cliente"
        Me.CNOMBRECLIENTE.Name = "CNOMBRECLIENTE"
        Me.CNOMBRECLIENTE.ReadOnly = True
        Me.CNOMBRECLIENTE.Width = 180
        '
        'CLPRECIO
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CLPRECIO.DefaultCellStyle = DataGridViewCellStyle6
        Me.CLPRECIO.HeaderText = "Precio"
        Me.CLPRECIO.Name = "CLPRECIO"
        Me.CLPRECIO.ReadOnly = True
        Me.CLPRECIO.Width = 80
        '
        'CLCANTIDADR
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CLCANTIDADR.DefaultCellStyle = DataGridViewCellStyle7
        Me.CLCANTIDADR.HeaderText = "Cantidad"
        Me.CLCANTIDADR.Name = "CLCANTIDADR"
        Me.CLCANTIDADR.ReadOnly = True
        Me.CLCANTIDADR.Width = 70
        '
        'CLDPE
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CLDPE.DefaultCellStyle = DataGridViewCellStyle8
        Me.CLDPE.HeaderText = "Pendiente"
        Me.CLDPE.Name = "CLDPE"
        Me.CLDPE.ReadOnly = True
        Me.CLDPE.Width = 75
        '
        'Column1
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column1.HeaderText = "Total Agendado"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 110
        '
        'CCAG
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CCAG.DefaultCellStyle = DataGridViewCellStyle10
        Me.CCAG.HeaderText = "C. Agendada"
        Me.CCAG.Name = "CCAG"
        Me.CCAG.Width = 90
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GrillaFechas)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 87)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(377, 190)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ordenes de compra"
        '
        'frm_ingreso_agenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 597)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grillaDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frm_ingreso_agenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENEDOR DE AGENDA"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.GrillaFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grillaDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GrillaFechas As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkTipoOrden As CheckBox
    Friend WithEvents txtFechaCita As DateTimePicker
    Friend WithEvents txtFechaOrdenCompra As TextBox
    Friend WithEvents txtOrdenCompra As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grillaDetalle As DataGridView
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ChkConfirmar As CheckBox
    Friend WithEvents chkPorconfirmar As CheckBox
    Friend WithEvents ButtonConfirmar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Label6 As Label
    Friend WithEvents COL_COD_PICKING As DataGridViewCheckBoxColumn
    Friend WithEvents col_fecha_p As DataGridViewTextBoxColumn
    Friend WithEvents col_fec_ingreso As DataGridViewTextBoxColumn
    Friend WithEvents colmonto As DataGridViewTextBoxColumn
    Friend WithEvents col_esabierta As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents colOCnumero As DataGridViewTextBoxColumn
    Friend WithEvents colFCons As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents CNOM As DataGridViewTextBoxColumn
    Friend WithEvents CSKU As DataGridViewTextBoxColumn
    Friend WithEvents CNOMBRECLIENTE As DataGridViewTextBoxColumn
    Friend WithEvents CLPRECIO As DataGridViewTextBoxColumn
    Friend WithEvents CLCANTIDADR As DataGridViewTextBoxColumn
    Friend WithEvents CLDPE As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents CCAG As DataGridViewTextBoxColumn
End Class
