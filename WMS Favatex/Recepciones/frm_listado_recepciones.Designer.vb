<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_listado_recepciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_recepciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOCompra = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaOCDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaOCHasta = New System.Windows.Forms.DateTimePicker()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.colnrec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clcarcodgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colfecharec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coloc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colnumf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colnumGuia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMuestra = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colVale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.volverm = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colImprimir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colMov = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.elimina = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colcodestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cpu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNueva, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ButtonExportar, Me.ToolStripSeparator3, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(954, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNueva.Image = CType(resources.GetObject("ButtonNueva.Image"), System.Drawing.Image)
        Me.ButtonNueva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(123, 22)
        Me.ButtonNueva.Text = "NUEVA RECEPCIÓN"
        Me.ButtonNueva.Visible = False
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
        Me.Panel4.Size = New System.Drawing.Size(954, 4)
        Me.Panel4.TabIndex = 16
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
        Me.Panel1.Size = New System.Drawing.Size(954, 23)
        Me.Panel1.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "LISTADO DE RECEPCIONES"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbEstado)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtOCompra)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtGuia)
        Me.Panel2.Controls.Add(Me.txtFactura)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dtpFechaOCDesde)
        Me.Panel2.Controls.Add(Me.dtpFechaOCHasta)
        Me.Panel2.Controls.Add(Me.cmbProveedor)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.chkFecha)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(954, 62)
        Me.Panel2.TabIndex = 44
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LemonChiffon
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Location = New System.Drawing.Point(749, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(175, 22)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "CON UBICACIÓN PENDIENTE O PARCIAL"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbEstado
        '
        Me.cmbEstado.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(626, 33)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(117, 21)
        Me.cmbEstado.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(573, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "ESTADO"
        '
        'txtOCompra
        '
        Me.txtOCompra.Location = New System.Drawing.Point(626, 7)
        Me.txtOCompra.Name = "txtOCompra"
        Me.txtOCompra.Size = New System.Drawing.Size(117, 22)
        Me.txtOCompra.TabIndex = 31
        Me.txtOCompra.Text = "0"
        Me.txtOCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(537, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "N° O. COMPRA"
        '
        'txtGuia
        '
        Me.txtGuia.Location = New System.Drawing.Point(429, 33)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(78, 22)
        Me.txtGuia.TabIndex = 26
        Me.txtGuia.Text = "0"
        Me.txtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(429, 6)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(78, 22)
        Me.txtFactura.TabIndex = 29
        Me.txtFactura.Text = "0"
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "N° FACTURA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(375, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "N° GUIA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "HASTA"
        '
        'dtpFechaOCDesde
        '
        Me.dtpFechaOCDesde.Enabled = False
        Me.dtpFechaOCDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOCDesde.Location = New System.Drawing.Point(118, 33)
        Me.dtpFechaOCDesde.Name = "dtpFechaOCDesde"
        Me.dtpFechaOCDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpFechaOCDesde.TabIndex = 23
        '
        'dtpFechaOCHasta
        '
        Me.dtpFechaOCHasta.Enabled = False
        Me.dtpFechaOCHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOCHasta.Location = New System.Drawing.Point(251, 34)
        Me.dtpFechaOCHasta.Name = "dtpFechaOCHasta"
        Me.dtpFechaOCHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpFechaOCHasta.TabIndex = 22
        '
        'cmbProveedor
        '
        Me.cmbProveedor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(118, 6)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(215, 21)
        Me.cmbProveedor.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "PROVEEDOR"
        '
        'chkFecha
        '
        Me.chkFecha.AutoSize = True
        Me.chkFecha.Location = New System.Drawing.Point(22, 36)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(97, 17)
        Me.chkFecha.TabIndex = 24
        Me.chkFecha.Text = "FECHA DESDE"
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 485)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(954, 22)
        Me.StatusStrip1.TabIndex = 45
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colnrec, Me.clcarcodgo, Me.colNombreProveedor, Me.colfecharec, Me.coloc, Me.colnumf, Me.colnumGuia, Me.COLESTADO, Me.colMuestra, Me.colVale, Me.volverm, Me.Column1, Me.colImprimir, Me.colMov, Me.elimina, Me.colcodestado, Me.col_cpu})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 114)
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
        Me.Grilla.Size = New System.Drawing.Size(954, 371)
        Me.Grilla.TabIndex = 46
        '
        'colnrec
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colnrec.DefaultCellStyle = DataGridViewCellStyle2
        Me.colnrec.HeaderText = "N° REC"
        Me.colnrec.Name = "colnrec"
        Me.colnrec.ReadOnly = True
        Me.colnrec.Width = 80
        '
        'clcarcodgo
        '
        Me.clcarcodgo.HeaderText = "CAR_CODIGO"
        Me.clcarcodgo.Name = "clcarcodgo"
        Me.clcarcodgo.ReadOnly = True
        Me.clcarcodgo.Visible = False
        '
        'colNombreProveedor
        '
        Me.colNombreProveedor.HeaderText = "NOMBRE PROVEEDOR"
        Me.colNombreProveedor.Name = "colNombreProveedor"
        Me.colNombreProveedor.ReadOnly = True
        Me.colNombreProveedor.Width = 250
        '
        'colfecharec
        '
        Me.colfecharec.HeaderText = "FEC. RECP."
        Me.colfecharec.Name = "colfecharec"
        Me.colfecharec.ReadOnly = True
        '
        'coloc
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.coloc.DefaultCellStyle = DataGridViewCellStyle3
        Me.coloc.HeaderText = "N° OC"
        Me.coloc.Name = "coloc"
        Me.coloc.ReadOnly = True
        '
        'colnumf
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colnumf.DefaultCellStyle = DataGridViewCellStyle4
        Me.colnumf.HeaderText = "N°FACTURA"
        Me.colnumf.Name = "colnumf"
        Me.colnumf.ReadOnly = True
        '
        'colnumGuia
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colnumGuia.DefaultCellStyle = DataGridViewCellStyle5
        Me.colnumGuia.HeaderText = "N°GUIA"
        Me.colnumGuia.Name = "colnumGuia"
        Me.colnumGuia.ReadOnly = True
        '
        'COLESTADO
        '
        Me.COLESTADO.HeaderText = "ESTADO"
        Me.COLESTADO.Name = "COLESTADO"
        Me.COLESTADO.ReadOnly = True
        '
        'colMuestra
        '
        Me.colMuestra.HeaderText = "MUESTRA"
        Me.colMuestra.Name = "colMuestra"
        Me.colMuestra.ReadOnly = True
        '
        'colVale
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colVale.DefaultCellStyle = DataGridViewCellStyle6
        Me.colVale.HeaderText = "V. TRAS."
        Me.colVale.Name = "colVale"
        Me.colVale.ReadOnly = True
        Me.colVale.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colVale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'volverm
        '
        Me.volverm.HeaderText = ""
        Me.volverm.Name = "volverm"
        Me.volverm.ReadOnly = True
        Me.volverm.Text = "VER MUESTRA"
        Me.volverm.UseColumnTextForButtonValue = True
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "VER RECEPCIÓN"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 40
        '
        'colImprimir
        '
        Me.colImprimir.HeaderText = ""
        Me.colImprimir.Name = "colImprimir"
        Me.colImprimir.ReadOnly = True
        Me.colImprimir.Text = "IMPRIMIR REC"
        Me.colImprimir.UseColumnTextForButtonValue = True
        '
        'colMov
        '
        Me.colMov.HeaderText = ""
        Me.colMov.Name = "colMov"
        Me.colMov.ReadOnly = True
        Me.colMov.Text = "MOV. RECEPCIÓN"
        Me.colMov.UseColumnTextForButtonValue = True
        Me.colMov.Visible = False
        Me.colMov.Width = 110
        '
        'elimina
        '
        Me.elimina.HeaderText = ""
        Me.elimina.Name = "elimina"
        Me.elimina.ReadOnly = True
        Me.elimina.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.elimina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.elimina.Text = "ELIMINA REC"
        Me.elimina.UseColumnTextForButtonValue = True
        Me.elimina.Visible = False
        Me.elimina.Width = 60
        '
        'colcodestado
        '
        Me.colcodestado.HeaderText = "cod_estado"
        Me.colcodestado.Name = "colcodestado"
        Me.colcodestado.ReadOnly = True
        Me.colcodestado.Visible = False
        '
        'col_cpu
        '
        Me.col_cpu.HeaderText = "col_cpu"
        Me.col_cpu.Name = "col_cpu"
        Me.col_cpu.ReadOnly = True
        Me.col_cpu.Visible = False
        '
        'frm_listado_recepciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 507)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_listado_recepciones"
        Me.Text = "LISTADO DE RECEPCIONES"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFechaOCHasta As DateTimePicker
    Friend WithEvents dtpFechaOCDesde As DateTimePicker
    Friend WithEvents chkFecha As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtGuia As TextBox
    Friend WithEvents txtFactura As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtOCompra As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents colnrec As DataGridViewTextBoxColumn
    Friend WithEvents clcarcodgo As DataGridViewTextBoxColumn
    Friend WithEvents colNombreProveedor As DataGridViewTextBoxColumn
    Friend WithEvents colfecharec As DataGridViewTextBoxColumn
    Friend WithEvents coloc As DataGridViewTextBoxColumn
    Friend WithEvents colnumf As DataGridViewTextBoxColumn
    Friend WithEvents colnumGuia As DataGridViewTextBoxColumn
    Friend WithEvents COLESTADO As DataGridViewTextBoxColumn
    Friend WithEvents colMuestra As DataGridViewCheckBoxColumn
    Friend WithEvents colVale As DataGridViewTextBoxColumn
    Friend WithEvents volverm As DataGridViewButtonColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents colImprimir As DataGridViewButtonColumn
    Friend WithEvents colMov As DataGridViewButtonColumn
    Friend WithEvents elimina As DataGridViewButtonColumn
    Friend WithEvents colcodestado As DataGridViewTextBoxColumn
    Friend WithEvents col_cpu As DataGridViewTextBoxColumn
End Class
