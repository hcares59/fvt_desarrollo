<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consolidado_picking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consolidado_picking))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSelecciona = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonDesmarcar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.CONSOLIDADODEPICKINGPARAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHoraTer = New System.Windows.Forms.MaskedTextBox()
        Me.txtHoraIni = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpCompromisoDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.COL_PIC_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.COL_COD_PICKING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fec_ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fecha_p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_HORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CAR_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CAL_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDespacharA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_EPC_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_EPC_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CANT_UNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CANT_BULTOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_TOTAL_BULTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEsImpreso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cb = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ButtonSelecciona, Me.ToolStripSeparator3, Me.ButtonDesmarcar, Me.ToolStripSeparator4, Me.ButtonImprimir, Me.ToolStripSplitButton1, Me.ToolStripSeparator2, Me.ButtonExportar, Me.ToolStripSeparator5, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1068, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
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
        'ButtonSelecciona
        '
        Me.ButtonSelecciona.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelecciona.Image = CType(resources.GetObject("ButtonSelecciona.Image"), System.Drawing.Image)
        Me.ButtonSelecciona.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSelecciona.Name = "ButtonSelecciona"
        Me.ButtonSelecciona.Size = New System.Drawing.Size(123, 22)
        Me.ButtonSelecciona.Text = "SELECCIONA TODO"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonDesmarcar
        '
        Me.ButtonDesmarcar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDesmarcar.Image = CType(resources.GetObject("ButtonDesmarcar.Image"), System.Drawing.Image)
        Me.ButtonDesmarcar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDesmarcar.Name = "ButtonDesmarcar"
        Me.ButtonDesmarcar.Size = New System.Drawing.Size(125, 22)
        Me.ButtonDesmarcar.Text = "DESMARCAR TODO"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImprimir.Image = CType(resources.GetObject("ButtonImprimir.Image"), System.Drawing.Image)
        Me.ButtonImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(76, 22)
        Me.ButtonImprimir.Text = "IMPRIMIR"
        Me.ButtonImprimir.Visible = False
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CONSOLIDADODEPICKINGPARAToolStripMenuItem, Me.CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'CONSOLIDADODEPICKINGPARAToolStripMenuItem
        '
        Me.CONSOLIDADODEPICKINGPARAToolStripMenuItem.Name = "CONSOLIDADODEPICKINGPARAToolStripMenuItem"
        Me.CONSOLIDADODEPICKINGPARAToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.CONSOLIDADODEPICKINGPARAToolStripMenuItem.Text = "CONSOLIDADO DE PICKING (PARA BUSQUEDA)"
        '
        'CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem
        '
        Me.CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem.Name = "CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem"
        Me.CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem.Text = "CONSOLIDADO DE PICKING (PARA CONTEO)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        Me.Panel4.Size = New System.Drawing.Size(1068, 5)
        Me.Panel4.TabIndex = 11
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 427)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1068, 22)
        Me.StatusStrip1.TabIndex = 13
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_PIC_CODIGO, Me.Column3, Me.COL_COD_PICKING, Me.col_fec_ingreso, Me.col_fecha_p, Me.COL_HORA, Me.COL_CAR_CODIGO, Me.COL_CAL_NOMBRE, Me.colDespacharA, Me.COL_EPC_CODIGO, Me.COL_EPC_NOMBRE, Me.COL_CANT_UNI, Me.COL_CANT_BULTOS, Me.COL_TOTAL_BULTO, Me.colEsImpreso, Me.cb, Me.Column1, Me.Column2})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 96)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Grilla.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(1068, 331)
        Me.Grilla.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtHoraTer)
        Me.Panel1.Controls.Add(Me.txtHoraIni)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpCompromisoDesde)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1068, 35)
        Me.Panel1.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(850, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 12)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "DOCUMENTO IMPRESO"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(8, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(813, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(31, 20)
        Me.Panel2.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(571, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(210, 12)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "CB : CONSOLIDADO DE PICKING (PARA BUSQUEDA)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(571, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(202, 12)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "CC : CONSOLIDADO DE PICKING (PARA CONTEO)"
        '
        'txtHoraTer
        '
        Me.txtHoraTer.BackColor = System.Drawing.Color.White
        Me.txtHoraTer.Location = New System.Drawing.Point(492, 6)
        Me.txtHoraTer.Mask = "00:00"
        Me.txtHoraTer.Name = "txtHoraTer"
        Me.txtHoraTer.Size = New System.Drawing.Size(42, 22)
        Me.txtHoraTer.TabIndex = 16
        Me.txtHoraTer.Text = "2000"
        Me.txtHoraTer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHoraTer.ValidatingType = GetType(Date)
        '
        'txtHoraIni
        '
        Me.txtHoraIni.BackColor = System.Drawing.Color.White
        Me.txtHoraIni.Location = New System.Drawing.Point(355, 6)
        Me.txtHoraIni.Mask = "00:00"
        Me.txtHoraIni.Name = "txtHoraIni"
        Me.txtHoraIni.Size = New System.Drawing.Size(42, 22)
        Me.txtHoraIni.TabIndex = 15
        Me.txtHoraIni.Text = "0800"
        Me.txtHoraIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHoraIni.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(402, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "HORA TERMINO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "HORA INICIO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "FECHA DE COMPROMISO"
        '
        'dtpCompromisoDesde
        '
        Me.dtpCompromisoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromisoDesde.Location = New System.Drawing.Point(150, 6)
        Me.dtpCompromisoDesde.Name = "dtpCompromisoDesde"
        Me.dtpCompromisoDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpCompromisoDesde.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(280, 30)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "CONSOLIDADO DE PICKING"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Location = New System.Drawing.Point(0, 30)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1068, 31)
        Me.Panel3.TabIndex = 12
        '
        'COL_PIC_CODIGO
        '
        Me.COL_PIC_CODIGO.HeaderText = "pic_codigo"
        Me.COL_PIC_CODIGO.Name = "COL_PIC_CODIGO"
        Me.COL_PIC_CODIGO.ReadOnly = True
        Me.COL_PIC_CODIGO.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "S"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 30
        '
        'COL_COD_PICKING
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_COD_PICKING.DefaultCellStyle = DataGridViewCellStyle2
        Me.COL_COD_PICKING.HeaderText = "N° PICKING"
        Me.COL_COD_PICKING.Name = "COL_COD_PICKING"
        Me.COL_COD_PICKING.ReadOnly = True
        Me.COL_COD_PICKING.Width = 80
        '
        'col_fec_ingreso
        '
        Me.col_fec_ingreso.HeaderText = "FECHA DE INGRESO"
        Me.col_fec_ingreso.Name = "col_fec_ingreso"
        Me.col_fec_ingreso.ReadOnly = True
        Me.col_fec_ingreso.Width = 120
        '
        'col_fecha_p
        '
        Me.col_fecha_p.HeaderText = "FECHA DESPACHO"
        Me.col_fecha_p.Name = "col_fecha_p"
        Me.col_fecha_p.ReadOnly = True
        Me.col_fecha_p.Width = 120
        '
        'COL_HORA
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_HORA.DefaultCellStyle = DataGridViewCellStyle3
        Me.COL_HORA.HeaderText = "HORA CITA"
        Me.COL_HORA.Name = "COL_HORA"
        Me.COL_HORA.ReadOnly = True
        Me.COL_HORA.Width = 70
        '
        'COL_CAR_CODIGO
        '
        Me.COL_CAR_CODIGO.HeaderText = "CAR_CODIGO"
        Me.COL_CAR_CODIGO.Name = "COL_CAR_CODIGO"
        Me.COL_CAR_CODIGO.ReadOnly = True
        Me.COL_CAR_CODIGO.Visible = False
        '
        'COL_CAL_NOMBRE
        '
        Me.COL_CAL_NOMBRE.HeaderText = "NOMBRE CLIENTE"
        Me.COL_CAL_NOMBRE.Name = "COL_CAL_NOMBRE"
        Me.COL_CAL_NOMBRE.ReadOnly = True
        Me.COL_CAL_NOMBRE.Width = 250
        '
        'colDespacharA
        '
        Me.colDespacharA.HeaderText = "DESPACHAR A"
        Me.colDespacharA.Name = "colDespacharA"
        Me.colDespacharA.ReadOnly = True
        '
        'COL_EPC_CODIGO
        '
        Me.COL_EPC_CODIGO.HeaderText = "EPC_ESTADO"
        Me.COL_EPC_CODIGO.Name = "COL_EPC_CODIGO"
        Me.COL_EPC_CODIGO.ReadOnly = True
        Me.COL_EPC_CODIGO.Visible = False
        '
        'COL_EPC_NOMBRE
        '
        Me.COL_EPC_NOMBRE.HeaderText = "ESTADO DE PICKING"
        Me.COL_EPC_NOMBRE.Name = "COL_EPC_NOMBRE"
        Me.COL_EPC_NOMBRE.ReadOnly = True
        Me.COL_EPC_NOMBRE.Width = 140
        '
        'COL_CANT_UNI
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_CANT_UNI.DefaultCellStyle = DataGridViewCellStyle4
        Me.COL_CANT_UNI.HeaderText = "CANT. UNI."
        Me.COL_CANT_UNI.Name = "COL_CANT_UNI"
        Me.COL_CANT_UNI.ReadOnly = True
        Me.COL_CANT_UNI.Width = 70
        '
        'COL_CANT_BULTOS
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_CANT_BULTOS.DefaultCellStyle = DataGridViewCellStyle5
        Me.COL_CANT_BULTOS.HeaderText = "N°BULTOS POR UNIDAD"
        Me.COL_CANT_BULTOS.Name = "COL_CANT_BULTOS"
        Me.COL_CANT_BULTOS.ReadOnly = True
        Me.COL_CANT_BULTOS.Visible = False
        Me.COL_CANT_BULTOS.Width = 140
        '
        'COL_TOTAL_BULTO
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_TOTAL_BULTO.DefaultCellStyle = DataGridViewCellStyle6
        Me.COL_TOTAL_BULTO.HeaderText = "TOTAL BULTOS"
        Me.COL_TOTAL_BULTO.Name = "COL_TOTAL_BULTO"
        Me.COL_TOTAL_BULTO.ReadOnly = True
        '
        'colEsImpreso
        '
        Me.colEsImpreso.HeaderText = "CC"
        Me.colEsImpreso.Name = "colEsImpreso"
        Me.colEsImpreso.ReadOnly = True
        Me.colEsImpreso.Width = 40
        '
        'cb
        '
        Me.cb.HeaderText = "CB"
        Me.cb.Name = "cb"
        Me.cb.ReadOnly = True
        Me.cb.Width = 40
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "Ver picking"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Text = "Imprimir"
        Me.Column2.UseColumnTextForButtonValue = True
        Me.Column2.Width = 70
        '
        'frm_consolidado_picking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 449)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_consolidado_picking"
        Me.Text = "CONSOLIDADO DE PICKING"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpCompromisoDesde As DateTimePicker
    Friend WithEvents ButtonImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonSelecciona As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonDesmarcar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtHoraTer As MaskedTextBox
    Friend WithEvents txtHoraIni As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ButtonExportar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents CONSOLIDADODEPICKINGPARAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CONSOLIDADODEOICKINGPARACONTEOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents COL_PIC_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewCheckBoxColumn
    Friend WithEvents COL_COD_PICKING As DataGridViewTextBoxColumn
    Friend WithEvents col_fec_ingreso As DataGridViewTextBoxColumn
    Friend WithEvents col_fecha_p As DataGridViewTextBoxColumn
    Friend WithEvents COL_HORA As DataGridViewTextBoxColumn
    Friend WithEvents COL_CAR_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_CAL_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents colDespacharA As DataGridViewTextBoxColumn
    Friend WithEvents COL_EPC_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_EPC_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_CANT_UNI As DataGridViewTextBoxColumn
    Friend WithEvents COL_CANT_BULTOS As DataGridViewTextBoxColumn
    Friend WithEvents COL_TOTAL_BULTO As DataGridViewTextBoxColumn
    Friend WithEvents colEsImpreso As DataGridViewCheckBoxColumn
    Friend WithEvents cb As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents Column2 As DataGridViewButtonColumn
End Class
