<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_listado_orden_compra_proveedor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_orden_compra_proveedor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNueva = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpArriboHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpArriboDesde = New System.Windows.Forms.DateTimePicker()
        Me.chkFechaArribo = New System.Windows.Forms.CheckBox()
        Me.dtpFechaOCHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.dtpFechaOCDesde = New System.Windows.Forms.DateTimePicker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.GrillaExp = New System.Windows.Forms.DataGridView()
        Me.col1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAR_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OCP_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAR_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_OC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_ORDEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDespa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colsdo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstadoR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcodestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantTran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantRecp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_empresatransportenombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_nfacturatransporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_fechaembarque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_ntransporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_nimportacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_fechapagotransporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_fechavencimientotransporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_valorflete = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_nproforma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_diaspagonombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_pagofacturanombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_condicionpagonombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_fechapago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_empresadescarganombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_nfacturadescarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_fechadescarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_banconombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_fechaaperturacc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_diaspagobanconombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_fechavencimientobanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_agenciaaduananombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_numerodni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_nfacturaimportacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_certificadoseguro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.elimina = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_paletizar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colgenerarrec = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colCierre = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrillaExp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNueva, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ButtonExportar, Me.ToolStripSeparator3, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(848, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNueva.Image = CType(resources.GetObject("ButtonNueva.Image"), System.Drawing.Image)
        Me.ButtonNueva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(167, 22)
        Me.ButtonNueva.Text = "NUEVA ORDEN DE COMPRA"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton1.Text = "BUSCAR"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExportar.Image = CType(resources.GetObject("ButtonExportar.Image"), System.Drawing.Image)
        Me.ButtonExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(124, 22)
        Me.ButtonExportar.Text = "EXPORTAR A EXCEL"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSalir.ForeColor = System.Drawing.Color.Black
        Me.ButtonSalir.Image = CType(resources.GetObject("ButtonSalir.Image"), System.Drawing.Image)
        Me.ButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(55, 22)
        Me.ButtonSalir.Text = "SALIR"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 25)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(848, 4)
        Me.Panel4.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(848, 23)
        Me.Panel1.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "LISTADO ORDEN DE COMPRA PROVEEDOR"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.cmbEstado)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dtpArriboHasta)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.dtpArriboDesde)
        Me.Panel2.Controls.Add(Me.chkFechaArribo)
        Me.Panel2.Controls.Add(Me.dtpFechaOCHasta)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmbProveedor)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.chkFecha)
        Me.Panel2.Controls.Add(Me.dtpFechaOCDesde)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(848, 58)
        Me.Panel2.TabIndex = 43
        '
        'cmbEstado
        '
        Me.cmbEstado.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(85, 30)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(201, 21)
        Me.cmbEstado.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "ESTADO"
        '
        'dtpArriboHasta
        '
        Me.dtpArriboHasta.Enabled = False
        Me.dtpArriboHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArriboHasta.Location = New System.Drawing.Point(587, 29)
        Me.dtpArriboHasta.Name = "dtpArriboHasta"
        Me.dtpArriboHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpArriboHasta.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(542, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "HASTA"
        '
        'dtpArriboDesde
        '
        Me.dtpArriboDesde.Enabled = False
        Me.dtpArriboDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArriboDesde.Location = New System.Drawing.Point(454, 29)
        Me.dtpArriboDesde.Name = "dtpArriboDesde"
        Me.dtpArriboDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpArriboDesde.TabIndex = 23
        '
        'chkFechaArribo
        '
        Me.chkFechaArribo.AutoSize = True
        Me.chkFechaArribo.Location = New System.Drawing.Point(312, 32)
        Me.chkFechaArribo.Name = "chkFechaArribo"
        Me.chkFechaArribo.Size = New System.Drawing.Size(139, 17)
        Me.chkFechaArribo.TabIndex = 22
        Me.chkFechaArribo.Text = "FECHA ARRIBO DESDE"
        Me.chkFechaArribo.UseVisualStyleBackColor = True
        '
        'dtpFechaOCHasta
        '
        Me.dtpFechaOCHasta.Enabled = False
        Me.dtpFechaOCHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOCHasta.Location = New System.Drawing.Point(587, 4)
        Me.dtpFechaOCHasta.Name = "dtpFechaOCHasta"
        Me.dtpFechaOCHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpFechaOCHasta.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(542, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "HASTA"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(85, 4)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(201, 21)
        Me.cmbProveedor.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "PROVEEDOR"
        '
        'chkFecha
        '
        Me.chkFecha.AutoSize = True
        Me.chkFecha.Checked = True
        Me.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFecha.Location = New System.Drawing.Point(312, 6)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(116, 17)
        Me.chkFecha.TabIndex = 17
        Me.chkFecha.Text = "FECHA OC DESDE"
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaOCDesde
        '
        Me.dtpFechaOCDesde.Enabled = False
        Me.dtpFechaOCDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOCDesde.Location = New System.Drawing.Point(454, 4)
        Me.dtpFechaOCDesde.Name = "dtpFechaOCDesde"
        Me.dtpFechaOCDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpFechaOCDesde.TabIndex = 9
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(848, 22)
        Me.StatusStrip1.TabIndex = 44
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotal
        '
        Me.lblTotal.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblTotal.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(4, 17)
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CAR_CODIGO, Me.OCP_CODIGO, Me.CAR_NOMBRE, Me.NUM_OC, Me.FECHA_ORDEN, Me.colDespa, Me.colsdo, Me.colEstadoR, Me.colcodestado, Me.colCantOrden, Me.colCantTran, Me.colCantRecp, Me.colMotivo, Me.cl_empresatransportenombre, Me.cl_nfacturatransporte, Me.cl_fechaembarque, Me.cl_ntransporte, Me.cl_nimportacion, Me.cl_fechapagotransporte, Me.cl_fechavencimientotransporte, Me.cl_valorflete, Me.cl_nproforma, Me.cl_diaspagonombre, Me.cl_pagofacturanombre, Me.cl_condicionpagonombre, Me.cl_fechapago, Me.cl_empresadescarganombre, Me.cl_nfacturadescarga, Me.cl_fechadescarga, Me.cl_banconombre, Me.cl_fechaaperturacc, Me.cl_diaspagobanconombre, Me.cl_fechavencimientobanco, Me.cl_agenciaaduananombre, Me.cl_numerodni, Me.cl_nfacturaimportacion, Me.cl_certificadoseguro, Me.Column1, Me.elimina, Me.col_paletizar, Me.colgenerarrec, Me.colCierre})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 110)
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
        Me.Grilla.Size = New System.Drawing.Size(848, 330)
        Me.Grilla.TabIndex = 45
        '
        'GrillaExp
        '
        Me.GrillaExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaExp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1, Me.COL2, Me.COL3, Me.COL4, Me.COL5, Me.COL6, Me.COL7, Me.COL8, Me.COL9, Me.COL10})
        Me.GrillaExp.Location = New System.Drawing.Point(7, 156)
        Me.GrillaExp.Name = "GrillaExp"
        Me.GrillaExp.Size = New System.Drawing.Size(483, 150)
        Me.GrillaExp.TabIndex = 46
        Me.GrillaExp.Visible = False
        '
        'col1
        '
        Me.col1.HeaderText = "NOMBRE PROVEEDOR"
        Me.col1.Name = "col1"
        Me.col1.ReadOnly = True
        '
        'COL2
        '
        Me.COL2.HeaderText = "N° ORDEN"
        Me.COL2.Name = "COL2"
        Me.COL2.ReadOnly = True
        '
        'COL3
        '
        Me.COL3.HeaderText = "FECHA ORDEN"
        Me.COL3.Name = "COL3"
        Me.COL3.ReadOnly = True
        '
        'COL4
        '
        Me.COL4.HeaderText = "FECHA ESTIMADA ARRIBO"
        Me.COL4.Name = "COL4"
        Me.COL4.ReadOnly = True
        '
        'COL5
        '
        Me.COL5.HeaderText = "ESTADO"
        Me.COL5.Name = "COL5"
        Me.COL5.ReadOnly = True
        '
        'COL6
        '
        Me.COL6.HeaderText = "CODIGO"
        Me.COL6.Name = "COL6"
        Me.COL6.ReadOnly = True
        '
        'COL7
        '
        Me.COL7.HeaderText = "PRODUCTO"
        Me.COL7.Name = "COL7"
        Me.COL7.ReadOnly = True
        '
        'COL8
        '
        Me.COL8.HeaderText = "CANTIDAD"
        Me.COL8.Name = "COL8"
        Me.COL8.ReadOnly = True
        '
        'COL9
        '
        Me.COL9.HeaderText = "PRECIO"
        Me.COL9.Name = "COL9"
        Me.COL9.ReadOnly = True
        '
        'COL10
        '
        Me.COL10.HeaderText = "TOTAL FILA"
        Me.COL10.Name = "COL10"
        Me.COL10.ReadOnly = True
        '
        'CAR_CODIGO
        '
        Me.CAR_CODIGO.HeaderText = "CAR_CODIGO"
        Me.CAR_CODIGO.Name = "CAR_CODIGO"
        Me.CAR_CODIGO.ReadOnly = True
        Me.CAR_CODIGO.Visible = False
        '
        'OCP_CODIGO
        '
        Me.OCP_CODIGO.HeaderText = "OCP_CODIGO"
        Me.OCP_CODIGO.Name = "OCP_CODIGO"
        Me.OCP_CODIGO.ReadOnly = True
        Me.OCP_CODIGO.Visible = False
        '
        'CAR_NOMBRE
        '
        Me.CAR_NOMBRE.HeaderText = "NOMBRE PROVEEDOR"
        Me.CAR_NOMBRE.Name = "CAR_NOMBRE"
        Me.CAR_NOMBRE.ReadOnly = True
        Me.CAR_NOMBRE.Width = 250
        '
        'NUM_OC
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NUM_OC.DefaultCellStyle = DataGridViewCellStyle2
        Me.NUM_OC.HeaderText = "N° ORDEN COMPRA"
        Me.NUM_OC.Name = "NUM_OC"
        Me.NUM_OC.ReadOnly = True
        Me.NUM_OC.Width = 130
        '
        'FECHA_ORDEN
        '
        Me.FECHA_ORDEN.HeaderText = "FECHA OC"
        Me.FECHA_ORDEN.Name = "FECHA_ORDEN"
        Me.FECHA_ORDEN.ReadOnly = True
        Me.FECHA_ORDEN.Width = 90
        '
        'colDespa
        '
        Me.colDespa.HeaderText = "FECHA ARRIBO"
        Me.colDespa.Name = "colDespa"
        Me.colDespa.ReadOnly = True
        Me.colDespa.Width = 90
        '
        'colsdo
        '
        Me.colsdo.HeaderText = "ESTADO OC"
        Me.colsdo.Name = "colsdo"
        Me.colsdo.ReadOnly = True
        Me.colsdo.Width = 150
        '
        'colEstadoR
        '
        Me.colEstadoR.HeaderText = "ESTADO RECEPCIÓN"
        Me.colEstadoR.Name = "colEstadoR"
        Me.colEstadoR.ReadOnly = True
        Me.colEstadoR.Visible = False
        Me.colEstadoR.Width = 180
        '
        'colcodestado
        '
        Me.colcodestado.HeaderText = "cod_estado"
        Me.colcodestado.Name = "colcodestado"
        Me.colcodestado.ReadOnly = True
        Me.colcodestado.Visible = False
        '
        'colCantOrden
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantOrden.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCantOrden.HeaderText = "CO"
        Me.colCantOrden.Name = "colCantOrden"
        Me.colCantOrden.ReadOnly = True
        '
        'colCantTran
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantTran.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCantTran.HeaderText = "CT"
        Me.colCantTran.Name = "colCantTran"
        Me.colCantTran.ReadOnly = True
        '
        'colCantRecp
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantRecp.DefaultCellStyle = DataGridViewCellStyle5
        Me.colCantRecp.HeaderText = "CR"
        Me.colCantRecp.Name = "colCantRecp"
        Me.colCantRecp.ReadOnly = True
        '
        'colMotivo
        '
        Me.colMotivo.HeaderText = "MOTIVO DE CIERRE"
        Me.colMotivo.Name = "colMotivo"
        Me.colMotivo.ReadOnly = True
        Me.colMotivo.Width = 150
        '
        'cl_empresatransportenombre
        '
        Me.cl_empresatransportenombre.HeaderText = "EMP. TRANSPORTE"
        Me.cl_empresatransportenombre.Name = "cl_empresatransportenombre"
        Me.cl_empresatransportenombre.ReadOnly = True
        Me.cl_empresatransportenombre.Visible = False
        '
        'cl_nfacturatransporte
        '
        Me.cl_nfacturatransporte.HeaderText = "N° FACTURA TRANSPORTE"
        Me.cl_nfacturatransporte.Name = "cl_nfacturatransporte"
        Me.cl_nfacturatransporte.ReadOnly = True
        Me.cl_nfacturatransporte.Visible = False
        '
        'cl_fechaembarque
        '
        Me.cl_fechaembarque.HeaderText = "FECHA EMBARQUE"
        Me.cl_fechaembarque.Name = "cl_fechaembarque"
        Me.cl_fechaembarque.ReadOnly = True
        Me.cl_fechaembarque.Visible = False
        '
        'cl_ntransporte
        '
        Me.cl_ntransporte.HeaderText = "N° TRANSPORTE"
        Me.cl_ntransporte.Name = "cl_ntransporte"
        Me.cl_ntransporte.ReadOnly = True
        Me.cl_ntransporte.Visible = False
        '
        'cl_nimportacion
        '
        Me.cl_nimportacion.HeaderText = "N° IMPORTACIÓN"
        Me.cl_nimportacion.Name = "cl_nimportacion"
        Me.cl_nimportacion.ReadOnly = True
        Me.cl_nimportacion.Visible = False
        '
        'cl_fechapagotransporte
        '
        Me.cl_fechapagotransporte.HeaderText = "FECHA PAGO TRANSPORTE"
        Me.cl_fechapagotransporte.Name = "cl_fechapagotransporte"
        Me.cl_fechapagotransporte.ReadOnly = True
        Me.cl_fechapagotransporte.Visible = False
        '
        'cl_fechavencimientotransporte
        '
        Me.cl_fechavencimientotransporte.HeaderText = "FECHA VENCTO. TRANSPORTE"
        Me.cl_fechavencimientotransporte.Name = "cl_fechavencimientotransporte"
        Me.cl_fechavencimientotransporte.ReadOnly = True
        Me.cl_fechavencimientotransporte.Visible = False
        '
        'cl_valorflete
        '
        Me.cl_valorflete.HeaderText = "VALOR FLETE"
        Me.cl_valorflete.Name = "cl_valorflete"
        Me.cl_valorflete.ReadOnly = True
        Me.cl_valorflete.Visible = False
        '
        'cl_nproforma
        '
        Me.cl_nproforma.HeaderText = "N° PROFORMA"
        Me.cl_nproforma.Name = "cl_nproforma"
        Me.cl_nproforma.ReadOnly = True
        Me.cl_nproforma.Visible = False
        '
        'cl_diaspagonombre
        '
        Me.cl_diaspagonombre.HeaderText = "DIAS PAGO"
        Me.cl_diaspagonombre.Name = "cl_diaspagonombre"
        Me.cl_diaspagonombre.ReadOnly = True
        Me.cl_diaspagonombre.Visible = False
        '
        'cl_pagofacturanombre
        '
        Me.cl_pagofacturanombre.HeaderText = "PAGO FACTURA"
        Me.cl_pagofacturanombre.Name = "cl_pagofacturanombre"
        Me.cl_pagofacturanombre.ReadOnly = True
        Me.cl_pagofacturanombre.Visible = False
        '
        'cl_condicionpagonombre
        '
        Me.cl_condicionpagonombre.HeaderText = "CONDICIÓN PAGO"
        Me.cl_condicionpagonombre.Name = "cl_condicionpagonombre"
        Me.cl_condicionpagonombre.ReadOnly = True
        Me.cl_condicionpagonombre.Visible = False
        '
        'cl_fechapago
        '
        Me.cl_fechapago.HeaderText = "FECHA PAGO"
        Me.cl_fechapago.Name = "cl_fechapago"
        Me.cl_fechapago.ReadOnly = True
        Me.cl_fechapago.Visible = False
        '
        'cl_empresadescarganombre
        '
        Me.cl_empresadescarganombre.HeaderText = "EMPRESA DESCARGA"
        Me.cl_empresadescarganombre.Name = "cl_empresadescarganombre"
        Me.cl_empresadescarganombre.ReadOnly = True
        Me.cl_empresadescarganombre.Visible = False
        '
        'cl_nfacturadescarga
        '
        Me.cl_nfacturadescarga.HeaderText = "N° FACTURA DESCARGA"
        Me.cl_nfacturadescarga.Name = "cl_nfacturadescarga"
        Me.cl_nfacturadescarga.ReadOnly = True
        Me.cl_nfacturadescarga.Visible = False
        '
        'cl_fechadescarga
        '
        Me.cl_fechadescarga.HeaderText = "FECHA DESCARGA"
        Me.cl_fechadescarga.Name = "cl_fechadescarga"
        Me.cl_fechadescarga.ReadOnly = True
        Me.cl_fechadescarga.Visible = False
        '
        'cl_banconombre
        '
        Me.cl_banconombre.HeaderText = "BANCO"
        Me.cl_banconombre.Name = "cl_banconombre"
        Me.cl_banconombre.ReadOnly = True
        Me.cl_banconombre.Visible = False
        '
        'cl_fechaaperturacc
        '
        Me.cl_fechaaperturacc.HeaderText = "FECHA APERTURA CC"
        Me.cl_fechaaperturacc.Name = "cl_fechaaperturacc"
        Me.cl_fechaaperturacc.ReadOnly = True
        Me.cl_fechaaperturacc.Visible = False
        '
        'cl_diaspagobanconombre
        '
        Me.cl_diaspagobanconombre.HeaderText = "DIAS PAGO"
        Me.cl_diaspagobanconombre.Name = "cl_diaspagobanconombre"
        Me.cl_diaspagobanconombre.ReadOnly = True
        Me.cl_diaspagobanconombre.Visible = False
        '
        'cl_fechavencimientobanco
        '
        Me.cl_fechavencimientobanco.HeaderText = "FECHA VENCTO. BANCO"
        Me.cl_fechavencimientobanco.Name = "cl_fechavencimientobanco"
        Me.cl_fechavencimientobanco.ReadOnly = True
        Me.cl_fechavencimientobanco.Visible = False
        '
        'cl_agenciaaduananombre
        '
        Me.cl_agenciaaduananombre.HeaderText = "AGENCIA ADUANA"
        Me.cl_agenciaaduananombre.Name = "cl_agenciaaduananombre"
        Me.cl_agenciaaduananombre.ReadOnly = True
        Me.cl_agenciaaduananombre.Visible = False
        '
        'cl_numerodni
        '
        Me.cl_numerodni.HeaderText = "NUMERO DNI"
        Me.cl_numerodni.Name = "cl_numerodni"
        Me.cl_numerodni.ReadOnly = True
        Me.cl_numerodni.Visible = False
        '
        'cl_nfacturaimportacion
        '
        Me.cl_nfacturaimportacion.HeaderText = "N° FACTURA IMPORTACIÓN"
        Me.cl_nfacturaimportacion.Name = "cl_nfacturaimportacion"
        Me.cl_nfacturaimportacion.ReadOnly = True
        Me.cl_nfacturaimportacion.Visible = False
        '
        'cl_certificadoseguro
        '
        Me.cl_certificadoseguro.HeaderText = "CERTIFICADO CEGURO"
        Me.cl_certificadoseguro.Name = "cl_certificadoseguro"
        Me.cl_certificadoseguro.ReadOnly = True
        Me.cl_certificadoseguro.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "VER ORDEN"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 80
        '
        'elimina
        '
        Me.elimina.HeaderText = ""
        Me.elimina.Name = "elimina"
        Me.elimina.ReadOnly = True
        Me.elimina.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.elimina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.elimina.Text = "ELIMINA ORDEN"
        Me.elimina.UseColumnTextForButtonValue = True
        Me.elimina.Width = 110
        '
        'col_paletizar
        '
        Me.col_paletizar.HeaderText = ""
        Me.col_paletizar.Name = "col_paletizar"
        Me.col_paletizar.ReadOnly = True
        Me.col_paletizar.Text = "PALETIZAR"
        Me.col_paletizar.UseColumnTextForButtonValue = True
        Me.col_paletizar.Visible = False
        '
        'colgenerarrec
        '
        Me.colgenerarrec.HeaderText = ""
        Me.colgenerarrec.Name = "colgenerarrec"
        Me.colgenerarrec.ReadOnly = True
        Me.colgenerarrec.Text = "GENERAR RECEPCIÓN"
        Me.colgenerarrec.UseColumnTextForButtonValue = True
        Me.colgenerarrec.Visible = False
        Me.colgenerarrec.Width = 130
        '
        'colCierre
        '
        Me.colCierre.HeaderText = ""
        Me.colCierre.Name = "colCierre"
        Me.colCierre.ReadOnly = True
        Me.colCierre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCierre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCierre.Text = "CIERRE MANUAL"
        Me.colCierre.UseColumnTextForButtonValue = True
        '
        'frm_listado_orden_compra_proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 462)
        Me.Controls.Add(Me.GrillaExp)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_listado_orden_compra_proveedor"
        Me.Text = "LISTADO ORDEN DE COMPRA PROVEEDOR"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrillaExp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNueva As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonExportar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dtpFechaOCHasta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkFecha As CheckBox
    Friend WithEvents dtpFechaOCDesde As DateTimePicker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents dtpArriboHasta As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpArriboDesde As DateTimePicker
    Friend WithEvents chkFechaArribo As CheckBox
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GrillaExp As DataGridView
    Friend WithEvents col1 As DataGridViewTextBoxColumn
    Friend WithEvents COL2 As DataGridViewTextBoxColumn
    Friend WithEvents COL3 As DataGridViewTextBoxColumn
    Friend WithEvents COL4 As DataGridViewTextBoxColumn
    Friend WithEvents COL5 As DataGridViewTextBoxColumn
    Friend WithEvents COL6 As DataGridViewTextBoxColumn
    Friend WithEvents COL7 As DataGridViewTextBoxColumn
    Friend WithEvents COL8 As DataGridViewTextBoxColumn
    Friend WithEvents COL9 As DataGridViewTextBoxColumn
    Friend WithEvents COL10 As DataGridViewTextBoxColumn
    Friend WithEvents CAR_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents OCP_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents CAR_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents NUM_OC As DataGridViewTextBoxColumn
    Friend WithEvents FECHA_ORDEN As DataGridViewTextBoxColumn
    Friend WithEvents colDespa As DataGridViewTextBoxColumn
    Friend WithEvents colsdo As DataGridViewTextBoxColumn
    Friend WithEvents colEstadoR As DataGridViewTextBoxColumn
    Friend WithEvents colcodestado As DataGridViewTextBoxColumn
    Friend WithEvents colCantOrden As DataGridViewTextBoxColumn
    Friend WithEvents colCantTran As DataGridViewTextBoxColumn
    Friend WithEvents colCantRecp As DataGridViewTextBoxColumn
    Friend WithEvents colMotivo As DataGridViewTextBoxColumn
    Friend WithEvents cl_empresatransportenombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_nfacturatransporte As DataGridViewTextBoxColumn
    Friend WithEvents cl_fechaembarque As DataGridViewTextBoxColumn
    Friend WithEvents cl_ntransporte As DataGridViewTextBoxColumn
    Friend WithEvents cl_nimportacion As DataGridViewTextBoxColumn
    Friend WithEvents cl_fechapagotransporte As DataGridViewTextBoxColumn
    Friend WithEvents cl_fechavencimientotransporte As DataGridViewTextBoxColumn
    Friend WithEvents cl_valorflete As DataGridViewTextBoxColumn
    Friend WithEvents cl_nproforma As DataGridViewTextBoxColumn
    Friend WithEvents cl_diaspagonombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_pagofacturanombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_condicionpagonombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_fechapago As DataGridViewTextBoxColumn
    Friend WithEvents cl_empresadescarganombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_nfacturadescarga As DataGridViewTextBoxColumn
    Friend WithEvents cl_fechadescarga As DataGridViewTextBoxColumn
    Friend WithEvents cl_banconombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_fechaaperturacc As DataGridViewTextBoxColumn
    Friend WithEvents cl_diaspagobanconombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_fechavencimientobanco As DataGridViewTextBoxColumn
    Friend WithEvents cl_agenciaaduananombre As DataGridViewTextBoxColumn
    Friend WithEvents cl_numerodni As DataGridViewTextBoxColumn
    Friend WithEvents cl_nfacturaimportacion As DataGridViewTextBoxColumn
    Friend WithEvents cl_certificadoseguro As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents elimina As DataGridViewButtonColumn
    Friend WithEvents col_paletizar As DataGridViewButtonColumn
    Friend WithEvents colgenerarrec As DataGridViewButtonColumn
    Friend WithEvents colCierre As DataGridViewButtonColumn
End Class
