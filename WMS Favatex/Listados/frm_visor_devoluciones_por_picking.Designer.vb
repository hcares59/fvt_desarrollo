<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visor_devoluciones_por_picking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_visor_devoluciones_por_picking))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpCompromisoHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpCompromisoDesde = New System.Windows.Forms.DateTimePicker()
        Me.chkCompromiso = New System.Windows.Forms.CheckBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotRegistro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.COL_PIC_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_COD_PICKING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNPK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fec_ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CAR_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CAL_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CANT_UNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAbrir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnImprimir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Gril_Dev_Detalles = New System.Windows.Forms.DataGridView()
        Me.dev_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colnk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colgd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLFI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gril_Dev_Detalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonExportar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(925, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(172, 22)
        Me.ButtonNuevo.Text = "CREAR NUEVA DEVOLUCIÓN"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExportar.ForeColor = System.Drawing.Color.Black
        Me.ButtonExportar.Image = CType(resources.GetObject("ButtonExportar.Image"), System.Drawing.Image)
        Me.ButtonExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(124, 22)
        Me.ButtonExportar.Text = "EXPORTAR A EXCEL"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(925, 31)
        Me.Panel1.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(444, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DEVOLUCION DE PRODUCTOS POR PICKING "
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.ButtonBuscar)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.dtpCompromisoHasta)
        Me.Panel3.Controls.Add(Me.dtpCompromisoDesde)
        Me.Panel3.Controls.Add(Me.chkCompromiso)
        Me.Panel3.Controls.Add(Me.cmbCliente)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(925, 34)
        Me.Panel3.TabIndex = 18
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonBuscar.Location = New System.Drawing.Point(731, 5)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 17
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(596, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "HASTA"
        '
        'dtpCompromisoHasta
        '
        Me.dtpCompromisoHasta.Enabled = False
        Me.dtpCompromisoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromisoHasta.Location = New System.Drawing.Point(641, 6)
        Me.dtpCompromisoHasta.Name = "dtpCompromisoHasta"
        Me.dtpCompromisoHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpCompromisoHasta.TabIndex = 15
        '
        'dtpCompromisoDesde
        '
        Me.dtpCompromisoDesde.Enabled = False
        Me.dtpCompromisoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromisoDesde.Location = New System.Drawing.Point(508, 6)
        Me.dtpCompromisoDesde.Name = "dtpCompromisoDesde"
        Me.dtpCompromisoDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpCompromisoDesde.TabIndex = 14
        '
        'chkCompromiso
        '
        Me.chkCompromiso.AutoSize = True
        Me.chkCompromiso.Checked = True
        Me.chkCompromiso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompromiso.ForeColor = System.Drawing.Color.Black
        Me.chkCompromiso.Location = New System.Drawing.Point(357, 8)
        Me.chkCompromiso.Name = "chkCompromiso"
        Me.chkCompromiso.Size = New System.Drawing.Size(152, 17)
        Me.chkCompromiso.TabIndex = 13
        Me.chkCompromiso.Text = "FECHA DE DEVOCUCIÓN"
        Me.chkCompromiso.UseVisualStyleBackColor = True
        '
        'cmbCliente
        '
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(129, 6)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(209, 21)
        Me.cmbCliente.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "SELECCIONE CLIENTE"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotRegistro})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 494)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(925, 24)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotRegistro
        '
        Me.lblTotRegistro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblTotRegistro.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblTotRegistro.Name = "lblTotRegistro"
        Me.lblTotRegistro.Size = New System.Drawing.Size(124, 19)
        Me.lblTotRegistro.Text = "ToolStripStatusLabel1"
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_PIC_CODIGO, Me.COL_COD_PICKING, Me.colNPK, Me.Column3, Me.Column4, Me.col_fec_ingreso, Me.Column2, Me.COL_CAR_CODIGO, Me.Column1, Me.COL_CAL_NOMBRE, Me.COL_CANT_UNI, Me.btnAbrir, Me.btnImprimir})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 90)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Grilla.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(925, 404)
        Me.Grilla.TabIndex = 20
        '
        'COL_PIC_CODIGO
        '
        Me.COL_PIC_CODIGO.HeaderText = "dev_codigo"
        Me.COL_PIC_CODIGO.Name = "COL_PIC_CODIGO"
        Me.COL_PIC_CODIGO.ReadOnly = True
        Me.COL_PIC_CODIGO.Visible = False
        '
        'COL_COD_PICKING
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_COD_PICKING.DefaultCellStyle = DataGridViewCellStyle2
        Me.COL_COD_PICKING.HeaderText = "N° DEV."
        Me.COL_COD_PICKING.Name = "COL_COD_PICKING"
        Me.COL_COD_PICKING.ReadOnly = True
        Me.COL_COD_PICKING.Width = 70
        '
        'colNPK
        '
        Me.colNPK.HeaderText = "N°PICKING"
        Me.colNPK.Name = "colNPK"
        Me.colNPK.ReadOnly = True
        Me.colNPK.Width = 150
        '
        'Column3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "FACTURA"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        Me.Column3.Width = 150
        '
        'Column4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column4.HeaderText = "GUIA DESP."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        Me.Column4.Width = 150
        '
        'col_fec_ingreso
        '
        Me.col_fec_ingreso.HeaderText = "FECHA DE INGRESO"
        Me.col_fec_ingreso.Name = "col_fec_ingreso"
        Me.col_fec_ingreso.ReadOnly = True
        Me.col_fec_ingreso.Width = 120
        '
        'Column2
        '
        Me.Column2.HeaderText = "FECHA DEV."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'COL_CAR_CODIGO
        '
        Me.COL_CAR_CODIGO.HeaderText = "CAR_CODIGO"
        Me.COL_CAR_CODIGO.Name = "COL_CAR_CODIGO"
        Me.COL_CAR_CODIGO.ReadOnly = True
        Me.COL_CAR_CODIGO.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "CLIENTE"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 180
        '
        'COL_CAL_NOMBRE
        '
        Me.COL_CAL_NOMBRE.HeaderText = "OBSERVACION"
        Me.COL_CAL_NOMBRE.Name = "COL_CAL_NOMBRE"
        Me.COL_CAL_NOMBRE.ReadOnly = True
        Me.COL_CAL_NOMBRE.Width = 250
        '
        'COL_CANT_UNI
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_CANT_UNI.DefaultCellStyle = DataGridViewCellStyle5
        Me.COL_CANT_UNI.HeaderText = "CANT. PROD."
        Me.COL_CANT_UNI.Name = "COL_CANT_UNI"
        Me.COL_CANT_UNI.ReadOnly = True
        '
        'btnAbrir
        '
        Me.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAbrir.HeaderText = ""
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.ReadOnly = True
        Me.btnAbrir.Text = "ABRIR DEV."
        Me.btnAbrir.UseColumnTextForButtonValue = True
        Me.btnAbrir.Width = 70
        '
        'btnImprimir
        '
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImprimir.HeaderText = ""
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.ReadOnly = True
        Me.btnImprimir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnImprimir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnImprimir.Text = "IMPRIMIR"
        Me.btnImprimir.UseColumnTextForButtonValue = True
        Me.btnImprimir.Width = 70
        '
        'Gril_Dev_Detalles
        '
        Me.Gril_Dev_Detalles.AllowUserToAddRows = False
        Me.Gril_Dev_Detalles.AllowUserToDeleteRows = False
        Me.Gril_Dev_Detalles.BackgroundColor = System.Drawing.Color.White
        Me.Gril_Dev_Detalles.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Gril_Dev_Detalles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Gril_Dev_Detalles.ColumnHeadersHeight = 25
        Me.Gril_Dev_Detalles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dev_codigo, Me.DataGridViewTextBoxColumn2, Me.colnk, Me.colf, Me.colgd, Me.DataGridViewTextBoxColumn5, Me.COLFI, Me.Column5, Me.Column6, Me.Column7, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn8, Me.COLM, Me.DataGridViewTextBoxColumn9})
        Me.Gril_Dev_Detalles.EnableHeadersVisualStyles = False
        Me.Gril_Dev_Detalles.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Gril_Dev_Detalles.Location = New System.Drawing.Point(153, 155)
        Me.Gril_Dev_Detalles.Name = "Gril_Dev_Detalles"
        Me.Gril_Dev_Detalles.ReadOnly = True
        Me.Gril_Dev_Detalles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Gril_Dev_Detalles.RowHeadersVisible = False
        Me.Gril_Dev_Detalles.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Gril_Dev_Detalles.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gril_Dev_Detalles.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Gril_Dev_Detalles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.Gril_Dev_Detalles.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Gril_Dev_Detalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Gril_Dev_Detalles.Size = New System.Drawing.Size(702, 253)
        Me.Gril_Dev_Detalles.TabIndex = 21
        Me.Gril_Dev_Detalles.Visible = False
        '
        'dev_codigo
        '
        Me.dev_codigo.HeaderText = "dev_codigo"
        Me.dev_codigo.Name = "dev_codigo"
        Me.dev_codigo.ReadOnly = True
        Me.dev_codigo.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn2.HeaderText = "N° DEV."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 70
        '
        'colnk
        '
        Me.colnk.HeaderText = "N°PICKING"
        Me.colnk.Name = "colnk"
        Me.colnk.ReadOnly = True
        '
        'colf
        '
        Me.colf.HeaderText = "FACTURA"
        Me.colf.Name = "colf"
        Me.colf.ReadOnly = True
        '
        'colgd
        '
        Me.colgd.HeaderText = "GUIA DESPACHO"
        Me.colgd.Name = "colgd"
        Me.colgd.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn5.HeaderText = "O/C"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'COLFI
        '
        Me.COLFI.HeaderText = "FECHA INGRESO"
        Me.COLFI.Name = "COLFI"
        Me.COLFI.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "FECHA DEV."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "CODIGO"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "PRODUCTO"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn10.HeaderText = "CANT. PROD."
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 180
        '
        'COLM
        '
        Me.COLM.HeaderText = "MOTIVO"
        Me.COLM.Name = "COLM"
        Me.COLM.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "OBSERVACION"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 250
        '
        'frm_visor_devoluciones_por_picking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 518)
        Me.Controls.Add(Me.Gril_Dev_Detalles)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_visor_devoluciones_por_picking"
        Me.Text = "DEVOLUCION DE PRODUCTOS POR PICKING"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gril_Dev_Detalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonExportar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpCompromisoHasta As DateTimePicker
    Friend WithEvents dtpCompromisoDesde As DateTimePicker
    Friend WithEvents chkCompromiso As CheckBox
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotRegistro As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents COL_PIC_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_COD_PICKING As DataGridViewTextBoxColumn
    Friend WithEvents colNPK As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents col_fec_ingreso As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents COL_CAR_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents COL_CAL_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_CANT_UNI As DataGridViewTextBoxColumn
    Friend WithEvents btnAbrir As DataGridViewButtonColumn
    Friend WithEvents btnImprimir As DataGridViewButtonColumn
    Friend WithEvents Gril_Dev_Detalles As DataGridView
    Friend WithEvents dev_codigo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents colnk As DataGridViewTextBoxColumn
    Friend WithEvents colf As DataGridViewTextBoxColumn
    Friend WithEvents colgd As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents COLFI As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents COLM As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
End Class
