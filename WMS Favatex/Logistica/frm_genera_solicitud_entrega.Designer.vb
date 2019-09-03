<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_genera_solicitud_entrega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_genera_solicitud_entrega))
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
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GrillaFechas = New System.Windows.Forms.DataGridView()
        Me.COL_COD_PICKING = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_fec_ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fecha_p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelBodegas = New System.Windows.Forms.Panel()
        Me.GrillaBodegas = New System.Windows.Forms.DataGridView()
        Me.col_idBodega = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_nomBodega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonSeleccionar = New System.Windows.Forms.Button()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.C_SELECCIONA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.C_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_FECHA_DESPACHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_NUM_OC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_COD_UNICO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_COD_INTERNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_NOMBRE_FAVATEX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_SKU_CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_SKU_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_N_B_X_U = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_TOT_BULTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_PRECIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_DESPACHAR_NUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_DESPACHAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_CON_LOCAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_CON_LOCAL_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_RUT_CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_NOMBRE_CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_CON_OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_FILA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_PIC_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_ES_DEVOLUCION = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ButtonBod = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ButtonSelect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonDesm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGenera = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GrillaFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.PanelBodegas.SuspendLayout()
        CType(Me.GrillaBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(720, 32)
        Me.Panel2.TabIndex = 4
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(720, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbltitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 31)
        Me.Panel1.TabIndex = 5
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.BackColor = System.Drawing.Color.Transparent
        Me.lbltitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.White
        Me.lbltitulo.Location = New System.Drawing.Point(3, -1)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(427, 30)
        Me.lbltitulo.TabIndex = 0
        Me.lbltitulo.Text = "GENERACIÓN DE SOLICITUDES DE ENTRGA"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 404)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(720, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 63)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GrillaFechas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelBodegas)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grilla)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip3)
        Me.SplitContainer1.Size = New System.Drawing.Size(720, 341)
        Me.SplitContainer1.SplitterDistance = 102
        Me.SplitContainer1.TabIndex = 8
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
        Me.GrillaFechas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_COD_PICKING, Me.col_fec_ingreso, Me.col_fecha_p})
        Me.GrillaFechas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaFechas.EnableHeadersVisualStyles = False
        Me.GrillaFechas.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaFechas.Location = New System.Drawing.Point(0, 52)
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
        Me.GrillaFechas.Size = New System.Drawing.Size(102, 289)
        Me.GrillaFechas.TabIndex = 9
        '
        'COL_COD_PICKING
        '
        Me.COL_COD_PICKING.HeaderText = "S"
        Me.COL_COD_PICKING.Name = "COL_COD_PICKING"
        Me.COL_COD_PICKING.ReadOnly = True
        Me.COL_COD_PICKING.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.COL_COD_PICKING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.COL_COD_PICKING.Width = 30
        '
        'col_fec_ingreso
        '
        Me.col_fec_ingreso.HeaderText = "FECHA"
        Me.col_fec_ingreso.Name = "col_fec_ingreso"
        Me.col_fec_ingreso.ReadOnly = True
        Me.col_fec_ingreso.Width = 90
        '
        'col_fecha_p
        '
        Me.col_fecha_p.HeaderText = "# OC"
        Me.col_fecha_p.Name = "col_fecha_p"
        Me.col_fecha_p.ReadOnly = True
        Me.col_fecha_p.Width = 70
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.cmbCliente)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(102, 52)
        Me.Panel3.TabIndex = 0
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(9, 23)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(86, 21)
        Me.cmbCliente.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE CLIENTE"
        '
        'PanelBodegas
        '
        Me.PanelBodegas.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.PanelBodegas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBodegas.Controls.Add(Me.GrillaBodegas)
        Me.PanelBodegas.Controls.Add(Me.ButtonSeleccionar)
        Me.PanelBodegas.Location = New System.Drawing.Point(302, 40)
        Me.PanelBodegas.Name = "PanelBodegas"
        Me.PanelBodegas.Size = New System.Drawing.Size(241, 197)
        Me.PanelBodegas.TabIndex = 11
        Me.PanelBodegas.Visible = False
        '
        'GrillaBodegas
        '
        Me.GrillaBodegas.AllowUserToAddRows = False
        Me.GrillaBodegas.AllowUserToDeleteRows = False
        Me.GrillaBodegas.BackgroundColor = System.Drawing.Color.White
        Me.GrillaBodegas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GrillaBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaBodegas.ColumnHeadersVisible = False
        Me.GrillaBodegas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_idBodega, Me.col_nomBodega})
        Me.GrillaBodegas.Location = New System.Drawing.Point(1, 1)
        Me.GrillaBodegas.Name = "GrillaBodegas"
        Me.GrillaBodegas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.GrillaBodegas.RowHeadersVisible = False
        Me.GrillaBodegas.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaBodegas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.GrillaBodegas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.GrillaBodegas.Size = New System.Drawing.Size(237, 167)
        Me.GrillaBodegas.TabIndex = 2
        '
        'col_idBodega
        '
        Me.col_idBodega.HeaderText = "Id_Bodega"
        Me.col_idBodega.Name = "col_idBodega"
        Me.col_idBodega.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_idBodega.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_idBodega.Width = 20
        '
        'col_nomBodega
        '
        Me.col_nomBodega.HeaderText = "Bodega"
        Me.col_nomBodega.Name = "col_nomBodega"
        Me.col_nomBodega.ReadOnly = True
        Me.col_nomBodega.Width = 200
        '
        'ButtonSeleccionar
        '
        Me.ButtonSeleccionar.Location = New System.Drawing.Point(158, 170)
        Me.ButtonSeleccionar.Name = "ButtonSeleccionar"
        Me.ButtonSeleccionar.Size = New System.Drawing.Size(80, 23)
        Me.ButtonSeleccionar.TabIndex = 1
        Me.ButtonSeleccionar.Text = "Seleccionar"
        Me.ButtonSeleccionar.UseVisualStyleBackColor = True
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.ColumnHeadersHeight = 25
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_SELECCIONA, Me.C_CODIGO, Me.C_FECHA_DESPACHO, Me.C_NUM_OC, Me.C_COD_UNICO, Me.C_COD_INTERNO, Me.C_NOMBRE_FAVATEX, Me.C_SKU_CLIENTE, Me.C_SKU_NOMBRE, Me.C_CANTIDAD, Me.C_N_B_X_U, Me.C_TOT_BULTO, Me.C_PRECIO, Me.C_DESPACHAR_NUMERO, Me.C_DESPACHAR, Me.C_CON_LOCAL, Me.C_CON_LOCAL_NOMBRE, Me.C_RUT_CLIENTE, Me.C_NOMBRE_CLIENTE, Me.C_CON_OBSERVACION, Me.C_FILA, Me.C_PIC_CODIGO, Me.C_ES_DEVOLUCION})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 52)
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
        Me.Grilla.Size = New System.Drawing.Size(614, 289)
        Me.Grilla.TabIndex = 9
        '
        'C_SELECCIONA
        '
        Me.C_SELECCIONA.HeaderText = "S"
        Me.C_SELECCIONA.Name = "C_SELECCIONA"
        Me.C_SELECCIONA.ReadOnly = True
        Me.C_SELECCIONA.Width = 40
        '
        'C_CODIGO
        '
        Me.C_CODIGO.HeaderText = "COD. CLIENTE"
        Me.C_CODIGO.Name = "C_CODIGO"
        Me.C_CODIGO.ReadOnly = True
        Me.C_CODIGO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C_CODIGO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.C_CODIGO.Visible = False
        '
        'C_FECHA_DESPACHO
        '
        Me.C_FECHA_DESPACHO.HeaderText = "FECHA"
        Me.C_FECHA_DESPACHO.Name = "C_FECHA_DESPACHO"
        Me.C_FECHA_DESPACHO.ReadOnly = True
        '
        'C_NUM_OC
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.C_NUM_OC.DefaultCellStyle = DataGridViewCellStyle3
        Me.C_NUM_OC.HeaderText = "NUM. OC"
        Me.C_NUM_OC.Name = "C_NUM_OC"
        Me.C_NUM_OC.ReadOnly = True
        Me.C_NUM_OC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C_NUM_OC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'C_COD_UNICO
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.C_COD_UNICO.DefaultCellStyle = DataGridViewCellStyle4
        Me.C_COD_UNICO.HeaderText = "CODIGO UNICO"
        Me.C_COD_UNICO.Name = "C_COD_UNICO"
        Me.C_COD_UNICO.ReadOnly = True
        Me.C_COD_UNICO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.C_COD_UNICO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'C_COD_INTERNO
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.C_COD_INTERNO.DefaultCellStyle = DataGridViewCellStyle5
        Me.C_COD_INTERNO.HeaderText = "CODIGO INTERNO"
        Me.C_COD_INTERNO.Name = "C_COD_INTERNO"
        Me.C_COD_INTERNO.ReadOnly = True
        Me.C_COD_INTERNO.Width = 120
        '
        'C_NOMBRE_FAVATEX
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.C_NOMBRE_FAVATEX.DefaultCellStyle = DataGridViewCellStyle6
        Me.C_NOMBRE_FAVATEX.HeaderText = "NOMBRE FAVATEX"
        Me.C_NOMBRE_FAVATEX.Name = "C_NOMBRE_FAVATEX"
        Me.C_NOMBRE_FAVATEX.ReadOnly = True
        Me.C_NOMBRE_FAVATEX.Width = 150
        '
        'C_SKU_CLIENTE
        '
        Me.C_SKU_CLIENTE.HeaderText = "SKU CLIENTE"
        Me.C_SKU_CLIENTE.Name = "C_SKU_CLIENTE"
        Me.C_SKU_CLIENTE.ReadOnly = True
        '
        'C_SKU_NOMBRE
        '
        Me.C_SKU_NOMBRE.HeaderText = "NOMBRE CLIENTE"
        Me.C_SKU_NOMBRE.Name = "C_SKU_NOMBRE"
        Me.C_SKU_NOMBRE.ReadOnly = True
        Me.C_SKU_NOMBRE.Width = 150
        '
        'C_CANTIDAD
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.C_CANTIDAD.DefaultCellStyle = DataGridViewCellStyle7
        Me.C_CANTIDAD.HeaderText = "CANTIDAD"
        Me.C_CANTIDAD.Name = "C_CANTIDAD"
        Me.C_CANTIDAD.ReadOnly = True
        '
        'C_N_B_X_U
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.C_N_B_X_U.DefaultCellStyle = DataGridViewCellStyle8
        Me.C_N_B_X_U.HeaderText = "N° BXU"
        Me.C_N_B_X_U.Name = "C_N_B_X_U"
        Me.C_N_B_X_U.ReadOnly = True
        '
        'C_TOT_BULTO
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.C_TOT_BULTO.DefaultCellStyle = DataGridViewCellStyle9
        Me.C_TOT_BULTO.HeaderText = "TOTAL BULTOS"
        Me.C_TOT_BULTO.Name = "C_TOT_BULTO"
        Me.C_TOT_BULTO.ReadOnly = True
        '
        'C_PRECIO
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.C_PRECIO.DefaultCellStyle = DataGridViewCellStyle10
        Me.C_PRECIO.HeaderText = "PRECIO"
        Me.C_PRECIO.Name = "C_PRECIO"
        Me.C_PRECIO.ReadOnly = True
        '
        'C_DESPACHAR_NUMERO
        '
        Me.C_DESPACHAR_NUMERO.HeaderText = "DESPACHAR NUMERO"
        Me.C_DESPACHAR_NUMERO.Name = "C_DESPACHAR_NUMERO"
        Me.C_DESPACHAR_NUMERO.ReadOnly = True
        Me.C_DESPACHAR_NUMERO.Visible = False
        '
        'C_DESPACHAR
        '
        Me.C_DESPACHAR.HeaderText = "DESPACHAR A"
        Me.C_DESPACHAR.Name = "C_DESPACHAR"
        Me.C_DESPACHAR.ReadOnly = True
        Me.C_DESPACHAR.Visible = False
        '
        'C_CON_LOCAL
        '
        Me.C_CON_LOCAL.HeaderText = "NUMERO LOCAL"
        Me.C_CON_LOCAL.Name = "C_CON_LOCAL"
        Me.C_CON_LOCAL.ReadOnly = True
        Me.C_CON_LOCAL.Visible = False
        '
        'C_CON_LOCAL_NOMBRE
        '
        Me.C_CON_LOCAL_NOMBRE.HeaderText = "NOMBRE LOCAL"
        Me.C_CON_LOCAL_NOMBRE.Name = "C_CON_LOCAL_NOMBRE"
        Me.C_CON_LOCAL_NOMBRE.ReadOnly = True
        Me.C_CON_LOCAL_NOMBRE.Visible = False
        '
        'C_RUT_CLIENTE
        '
        Me.C_RUT_CLIENTE.HeaderText = "RUT CLIENTE"
        Me.C_RUT_CLIENTE.Name = "C_RUT_CLIENTE"
        Me.C_RUT_CLIENTE.ReadOnly = True
        Me.C_RUT_CLIENTE.Visible = False
        '
        'C_NOMBRE_CLIENTE
        '
        Me.C_NOMBRE_CLIENTE.HeaderText = "NOMBRE CLIENTE"
        Me.C_NOMBRE_CLIENTE.Name = "C_NOMBRE_CLIENTE"
        Me.C_NOMBRE_CLIENTE.ReadOnly = True
        Me.C_NOMBRE_CLIENTE.Visible = False
        '
        'C_CON_OBSERVACION
        '
        Me.C_CON_OBSERVACION.HeaderText = "OBSERVACIONES"
        Me.C_CON_OBSERVACION.Name = "C_CON_OBSERVACION"
        Me.C_CON_OBSERVACION.ReadOnly = True
        Me.C_CON_OBSERVACION.Visible = False
        '
        'C_FILA
        '
        Me.C_FILA.HeaderText = "FILA"
        Me.C_FILA.Name = "C_FILA"
        Me.C_FILA.ReadOnly = True
        Me.C_FILA.Visible = False
        '
        'C_PIC_CODIGO
        '
        Me.C_PIC_CODIGO.HeaderText = "PIC_CODIGO"
        Me.C_PIC_CODIGO.Name = "C_PIC_CODIGO"
        Me.C_PIC_CODIGO.ReadOnly = True
        Me.C_PIC_CODIGO.Visible = False
        '
        'C_ES_DEVOLUCION
        '
        Me.C_ES_DEVOLUCION.HeaderText = "ES_DEVOLUCION"
        Me.C_ES_DEVOLUCION.Name = "C_ES_DEVOLUCION"
        Me.C_ES_DEVOLUCION.ReadOnly = True
        Me.C_ES_DEVOLUCION.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.ButtonBod)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 25)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(614, 27)
        Me.Panel4.TabIndex = 10
        '
        'ButtonBod
        '
        Me.ButtonBod.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonBod.Location = New System.Drawing.Point(304, 2)
        Me.ButtonBod.Name = "ButtonBod"
        Me.ButtonBod.Size = New System.Drawing.Size(23, 21)
        Me.ButtonBod.TabIndex = 14
        Me.ButtonBod.Text = "..."
        Me.ButtonBod.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(303, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DETALLE ORDENES DE COMPRA -  [ SELECCIONE BODEGA ]"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonSelect, Me.ToolStripSeparator4, Me.ButtonDesm, Me.ToolStripSeparator5, Me.ButtonGenera})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(614, 25)
        Me.ToolStrip3.TabIndex = 5
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ButtonSelect
        '
        Me.ButtonSelect.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelect.Image = CType(resources.GetObject("ButtonSelect.Image"), System.Drawing.Image)
        Me.ButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSelect.Name = "ButtonSelect"
        Me.ButtonSelect.Size = New System.Drawing.Size(133, 22)
        Me.ButtonSelect.Text = "SELECCIONAR TODO"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonDesm
        '
        Me.ButtonDesm.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDesm.Image = CType(resources.GetObject("ButtonDesm.Image"), System.Drawing.Image)
        Me.ButtonDesm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDesm.Name = "ButtonDesm"
        Me.ButtonDesm.Size = New System.Drawing.Size(128, 22)
        Me.ButtonDesm.Text = "DESMARCAR TODO"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonGenera
        '
        Me.ButtonGenera.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGenera.ForeColor = System.Drawing.Color.DarkRed
        Me.ButtonGenera.Image = CType(resources.GetObject("ButtonGenera.Image"), System.Drawing.Image)
        Me.ButtonGenera.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonGenera.Name = "ButtonGenera"
        Me.ButtonGenera.Size = New System.Drawing.Size(206, 22)
        Me.ButtonGenera.Text = "GENERAR SOLICITUD DE ENTREGA"
        '
        'frm_genera_solicitud_entrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 426)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_genera_solicitud_entrega"
        Me.Text = "GENERACION DE SOLICITUDES DE ENTRGA"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GrillaFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanelBodegas.ResumeLayout(False)
        CType(Me.GrillaBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbltitulo As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents GrillaFechas As DataGridView
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents ButtonSelect As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ButtonDesm As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ButtonGenera As ToolStripButton
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonBod As Button
    Friend WithEvents COL_COD_PICKING As DataGridViewCheckBoxColumn
    Friend WithEvents col_fec_ingreso As DataGridViewTextBoxColumn
    Friend WithEvents col_fecha_p As DataGridViewTextBoxColumn
    Friend WithEvents PanelBodegas As Panel
    Friend WithEvents GrillaBodegas As DataGridView
    Friend WithEvents col_idBodega As DataGridViewCheckBoxColumn
    Friend WithEvents col_nomBodega As DataGridViewTextBoxColumn
    Friend WithEvents ButtonSeleccionar As Button
    Friend WithEvents C_SELECCIONA As DataGridViewCheckBoxColumn
    Friend WithEvents C_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents C_FECHA_DESPACHO As DataGridViewTextBoxColumn
    Friend WithEvents C_NUM_OC As DataGridViewTextBoxColumn
    Friend WithEvents C_COD_UNICO As DataGridViewTextBoxColumn
    Friend WithEvents C_COD_INTERNO As DataGridViewTextBoxColumn
    Friend WithEvents C_NOMBRE_FAVATEX As DataGridViewTextBoxColumn
    Friend WithEvents C_SKU_CLIENTE As DataGridViewTextBoxColumn
    Friend WithEvents C_SKU_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents C_CANTIDAD As DataGridViewTextBoxColumn
    Friend WithEvents C_N_B_X_U As DataGridViewTextBoxColumn
    Friend WithEvents C_TOT_BULTO As DataGridViewTextBoxColumn
    Friend WithEvents C_PRECIO As DataGridViewTextBoxColumn
    Friend WithEvents C_DESPACHAR_NUMERO As DataGridViewTextBoxColumn
    Friend WithEvents C_DESPACHAR As DataGridViewTextBoxColumn
    Friend WithEvents C_CON_LOCAL As DataGridViewTextBoxColumn
    Friend WithEvents C_CON_LOCAL_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents C_RUT_CLIENTE As DataGridViewTextBoxColumn
    Friend WithEvents C_NOMBRE_CLIENTE As DataGridViewTextBoxColumn
    Friend WithEvents C_CON_OBSERVACION As DataGridViewTextBoxColumn
    Friend WithEvents C_FILA As DataGridViewTextBoxColumn
    Friend WithEvents C_PIC_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents C_ES_DEVOLUCION As DataGridViewCheckBoxColumn
End Class
