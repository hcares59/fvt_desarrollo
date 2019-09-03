<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_visor_picking
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.COL_PIC_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_COD_PICKING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fec_ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fecha_p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_HORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CAR_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CAL_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_EPC_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_EPC_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CANT_UNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CANT_BULTOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_TOTAL_BULTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLdespachar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAbrir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnImprimir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colFact = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_cant_encontrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 31)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VISOR DE PICKING"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(898, 4)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 35)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(898, 105)
        Me.Panel3.TabIndex = 2
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonBuscar.Location = New System.Drawing.Point(786, 16)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 17
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(651, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "HASTA"
        '
        'dtpCompromisoHasta
        '
        Me.dtpCompromisoHasta.Enabled = False
        Me.dtpCompromisoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromisoHasta.Location = New System.Drawing.Point(696, 17)
        Me.dtpCompromisoHasta.Name = "dtpCompromisoHasta"
        Me.dtpCompromisoHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpCompromisoHasta.TabIndex = 15
        '
        'dtpCompromisoDesde
        '
        Me.dtpCompromisoDesde.Enabled = False
        Me.dtpCompromisoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromisoDesde.Location = New System.Drawing.Point(563, 17)
        Me.dtpCompromisoDesde.Name = "dtpCompromisoDesde"
        Me.dtpCompromisoDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpCompromisoDesde.TabIndex = 14
        '
        'chkCompromiso
        '
        Me.chkCompromiso.AutoSize = True
        Me.chkCompromiso.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCompromiso.ForeColor = System.Drawing.Color.Black
        Me.chkCompromiso.Location = New System.Drawing.Point(365, 19)
        Me.chkCompromiso.Name = "chkCompromiso"
        Me.chkCompromiso.Size = New System.Drawing.Size(190, 17)
        Me.chkCompromiso.TabIndex = 13
        Me.chkCompromiso.Text = "FECHA DE COMPROMISO DESDE"
        Me.chkCompromiso.UseVisualStyleBackColor = True
        '
        'cmbCliente
        '
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(137, 17)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(209, 21)
        Me.cmbCliente.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "SELECCIONE CLIENTE"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotRegistro})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 517)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(898, 24)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotRegistro
        '
        Me.lblTotRegistro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblTotRegistro.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblTotRegistro.Name = "lblTotRegistro"
        Me.lblTotRegistro.Size = New System.Drawing.Size(123, 19)
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_PIC_CODIGO, Me.COL_COD_PICKING, Me.col_fec_ingreso, Me.col_fecha_p, Me.COL_HORA, Me.COL_CAR_CODIGO, Me.COL_CAL_NOMBRE, Me.COL_EPC_CODIGO, Me.COL_EPC_NOMBRE, Me.COL_CANT_UNI, Me.COL_CANT_BULTOS, Me.COL_TOTAL_BULTO, Me.COLdespachar, Me.btnAbrir, Me.btnImprimir, Me.colFact, Me.col_cant_encontrada})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 140)
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
        Me.Grilla.Size = New System.Drawing.Size(898, 377)
        Me.Grilla.TabIndex = 9
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30000
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.PeachPuff
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Brown
        Me.Label3.Location = New System.Drawing.Point(6, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "PICKING SIN NINGUNA GESTION [GENERADO]"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(225, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(257, 20)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "PICKING EN PROCESO CON CANTIDADES INCOMPLETAS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Beige
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(486, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(193, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "PICKING CON CANTIDADES COMPLETAS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Honeydew
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label7.Location = New System.Drawing.Point(683, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(193, 20)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "PICKING FINALIZADOS"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCliente)
        Me.GroupBox1.Controls.Add(Me.chkCompromiso)
        Me.GroupBox1.Controls.Add(Me.dtpCompromisoDesde)
        Me.GroupBox1.Controls.Add(Me.dtpCompromisoHasta)
        Me.GroupBox1.Controls.Add(Me.ButtonBuscar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(882, 50)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(882, 45)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Leyenda"
        '
        'COL_PIC_CODIGO
        '
        Me.COL_PIC_CODIGO.HeaderText = "pic_codigo"
        Me.COL_PIC_CODIGO.Name = "COL_PIC_CODIGO"
        Me.COL_PIC_CODIGO.ReadOnly = True
        Me.COL_PIC_CODIGO.Visible = False
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
        Me.COL_CANT_UNI.HeaderText = "CANT. UNIDADES"
        Me.COL_CANT_UNI.Name = "COL_CANT_UNI"
        Me.COL_CANT_UNI.ReadOnly = True
        '
        'COL_CANT_BULTOS
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_CANT_BULTOS.DefaultCellStyle = DataGridViewCellStyle5
        Me.COL_CANT_BULTOS.HeaderText = "N°BULTOS POR UNIDAD"
        Me.COL_CANT_BULTOS.Name = "COL_CANT_BULTOS"
        Me.COL_CANT_BULTOS.ReadOnly = True
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
        'COLdespachar
        '
        Me.COLdespachar.HeaderText = "DESPACHAR A"
        Me.COLdespachar.Name = "COLdespachar"
        Me.COLdespachar.ReadOnly = True
        Me.COLdespachar.Width = 150
        '
        'btnAbrir
        '
        Me.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAbrir.HeaderText = ""
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.ReadOnly = True
        Me.btnAbrir.Text = "Abrir picking"
        Me.btnAbrir.UseColumnTextForButtonValue = True
        Me.btnAbrir.Width = 90
        '
        'btnImprimir
        '
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImprimir.HeaderText = ""
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.ReadOnly = True
        Me.btnImprimir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnImprimir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseColumnTextForButtonValue = True
        Me.btnImprimir.Width = 70
        '
        'colFact
        '
        Me.colFact.HeaderText = ""
        Me.colFact.Name = "colFact"
        Me.colFact.ReadOnly = True
        Me.colFact.Text = "Facturar"
        Me.colFact.UseColumnTextForButtonValue = True
        Me.colFact.Visible = False
        Me.colFact.Width = 70
        '
        'col_cant_encontrada
        '
        Me.col_cant_encontrada.HeaderText = "cant encontrada"
        Me.col_cant_encontrada.Name = "col_cant_encontrada"
        Me.col_cant_encontrada.ReadOnly = True
        Me.col_cant_encontrada.Visible = False
        '
        'frm_visor_picking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 541)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_visor_picking"
        Me.Text = "VISOR DE PICKING"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpCompromisoHasta As DateTimePicker
    Friend WithEvents dtpCompromisoDesde As DateTimePicker
    Friend WithEvents chkCompromiso As CheckBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotRegistro As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents COL_PIC_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_COD_PICKING As DataGridViewTextBoxColumn
    Friend WithEvents col_fec_ingreso As DataGridViewTextBoxColumn
    Friend WithEvents col_fecha_p As DataGridViewTextBoxColumn
    Friend WithEvents COL_HORA As DataGridViewTextBoxColumn
    Friend WithEvents COL_CAR_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_CAL_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_EPC_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_EPC_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_CANT_UNI As DataGridViewTextBoxColumn
    Friend WithEvents COL_CANT_BULTOS As DataGridViewTextBoxColumn
    Friend WithEvents COL_TOTAL_BULTO As DataGridViewTextBoxColumn
    Friend WithEvents COLdespachar As DataGridViewTextBoxColumn
    Friend WithEvents btnAbrir As DataGridViewButtonColumn
    Friend WithEvents btnImprimir As DataGridViewButtonColumn
    Friend WithEvents colFact As DataGridViewButtonColumn
    Friend WithEvents col_cant_encontrada As DataGridViewTextBoxColumn
End Class
