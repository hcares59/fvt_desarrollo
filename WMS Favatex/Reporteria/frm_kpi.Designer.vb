<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_kpi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_kpi))
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonImprime = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optPorPeriodo = New System.Windows.Forms.RadioButton()
        Me.optEntrePeriodos = New System.Windows.Forms.RadioButton()
        Me.optEntreFecha = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButtonSDesmarcar = New System.Windows.Forms.Button()
        Me.ButtonSMarcar = New System.Windows.Forms.Button()
        Me.GrillaSinInc = New System.Windows.Forms.DataGridView()
        Me.bu_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pro_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButtonADesmarcar = New System.Windows.Forms.Button()
        Me.ButtonAMarcar = New System.Windows.Forms.Button()
        Me.GrillaConInc = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_deselecciona = New System.Windows.Forms.Button()
        Me.btn_selecciona = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbInformes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.boxEntreFechas = New System.Windows.Forms.Panel()
        Me.txtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.boxEntrePeriodos = New System.Windows.Forms.Panel()
        Me.cmbPeriodoHastaMes = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodoDesdeMes = New System.Windows.Forms.ComboBox()
        Me.txtPeriodoHastaAno = New System.Windows.Forms.TextBox()
        Me.txtPeriodoDesdeAno = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.boxPeriodo = New System.Windows.Forms.Panel()
        Me.cmbPeriodoMes = New System.Windows.Forms.ComboBox()
        Me.txtPeriodoAno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GrillaSinInc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GrillaConInc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.boxEntreFechas.SuspendLayout()
        Me.boxEntrePeriodos.SuspendLayout()
        Me.boxPeriodo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 4)
        Me.Panel1.TabIndex = 32
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ButtonNuevo, Me.ToolStripSeparator1, Me.ButtonImprime, Me.ToolStripSeparator4, Me.ButtonSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(666, 25)
        Me.ToolStrip1.TabIndex = 33
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(64, 22)
        Me.ButtonNuevo.Text = "NUEVO"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonImprime
        '
        Me.ButtonImprime.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImprime.Image = CType(resources.GetObject("ButtonImprime.Image"), System.Drawing.Image)
        Me.ButtonImprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonImprime.Name = "ButtonImprime"
        Me.ButtonImprime.Size = New System.Drawing.Size(81, 22)
        Me.ButtonImprime.Text = "IMPRIMIR"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSalir.Image = CType(resources.GetObject("ButtonSalir.Image"), System.Drawing.Image)
        Me.ButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(57, 22)
        Me.ButtonSalir.Text = "SALIR"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 4)
        Me.Panel2.TabIndex = 34
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optPorPeriodo)
        Me.GroupBox1.Controls.Add(Me.optEntrePeriodos)
        Me.GroupBox1.Controls.Add(Me.optEntreFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(133, 74)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        '
        'optPorPeriodo
        '
        Me.optPorPeriodo.AutoSize = True
        Me.optPorPeriodo.Location = New System.Drawing.Point(18, 52)
        Me.optPorPeriodo.Name = "optPorPeriodo"
        Me.optPorPeriodo.Size = New System.Drawing.Size(86, 17)
        Me.optPorPeriodo.TabIndex = 2
        Me.optPorPeriodo.Text = "Por periodo"
        Me.optPorPeriodo.UseVisualStyleBackColor = True
        '
        'optEntrePeriodos
        '
        Me.optEntrePeriodos.AutoSize = True
        Me.optEntrePeriodos.Location = New System.Drawing.Point(18, 31)
        Me.optEntrePeriodos.Name = "optEntrePeriodos"
        Me.optEntrePeriodos.Size = New System.Drawing.Size(101, 17)
        Me.optEntrePeriodos.TabIndex = 1
        Me.optEntrePeriodos.Text = "Entre periodos"
        Me.optEntrePeriodos.UseVisualStyleBackColor = True
        '
        'optEntreFecha
        '
        Me.optEntreFecha.AutoSize = True
        Me.optEntreFecha.Checked = True
        Me.optEntreFecha.Location = New System.Drawing.Point(18, 11)
        Me.optEntreFecha.Name = "optEntreFecha"
        Me.optEntreFecha.Size = New System.Drawing.Size(88, 17)
        Me.optEntreFecha.TabIndex = 0
        Me.optEntreFecha.TabStop = True
        Me.optEntreFecha.Text = "Entre fechas"
        Me.optEntreFecha.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 472)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(666, 22)
        Me.StatusStrip1.TabIndex = 37
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonSDesmarcar)
        Me.GroupBox3.Controls.Add(Me.ButtonSMarcar)
        Me.GroupBox3.Controls.Add(Me.GrillaSinInc)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 153)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(311, 316)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Clientes sin asociar"
        '
        'ButtonSDesmarcar
        '
        Me.ButtonSDesmarcar.Location = New System.Drawing.Point(95, 18)
        Me.ButtonSDesmarcar.Name = "ButtonSDesmarcar"
        Me.ButtonSDesmarcar.Size = New System.Drawing.Size(111, 23)
        Me.ButtonSDesmarcar.TabIndex = 126
        Me.ButtonSDesmarcar.Text = "Desmarcar todos"
        Me.ButtonSDesmarcar.UseVisualStyleBackColor = True
        '
        'ButtonSMarcar
        '
        Me.ButtonSMarcar.Location = New System.Drawing.Point(6, 18)
        Me.ButtonSMarcar.Name = "ButtonSMarcar"
        Me.ButtonSMarcar.Size = New System.Drawing.Size(86, 23)
        Me.ButtonSMarcar.TabIndex = 125
        Me.ButtonSMarcar.Text = "Marcar todos"
        Me.ButtonSMarcar.UseVisualStyleBackColor = True
        '
        'GrillaSinInc
        '
        Me.GrillaSinInc.AllowUserToAddRows = False
        Me.GrillaSinInc.AllowUserToDeleteRows = False
        Me.GrillaSinInc.BackgroundColor = System.Drawing.Color.White
        Me.GrillaSinInc.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaSinInc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.GrillaSinInc.ColumnHeadersHeight = 25
        Me.GrillaSinInc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bu_codigo, Me.pro_seleccion, Me.pro_nombre})
        Me.GrillaSinInc.EnableHeadersVisualStyles = False
        Me.GrillaSinInc.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaSinInc.Location = New System.Drawing.Point(6, 47)
        Me.GrillaSinInc.Name = "GrillaSinInc"
        Me.GrillaSinInc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaSinInc.RowHeadersVisible = False
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaSinInc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaSinInc.Size = New System.Drawing.Size(299, 261)
        Me.GrillaSinInc.TabIndex = 123
        '
        'bu_codigo
        '
        Me.bu_codigo.HeaderText = "pro_codigo"
        Me.bu_codigo.Name = "bu_codigo"
        Me.bu_codigo.Visible = False
        '
        'pro_seleccion
        '
        Me.pro_seleccion.HeaderText = "S"
        Me.pro_seleccion.Name = "pro_seleccion"
        Me.pro_seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pro_seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.pro_seleccion.Width = 30
        '
        'pro_nombre
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.pro_nombre.DefaultCellStyle = DataGridViewCellStyle18
        Me.pro_nombre.HeaderText = "NOMBRE"
        Me.pro_nombre.Name = "pro_nombre"
        Me.pro_nombre.Width = 250
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButtonADesmarcar)
        Me.GroupBox4.Controls.Add(Me.ButtonAMarcar)
        Me.GroupBox4.Controls.Add(Me.GrillaConInc)
        Me.GroupBox4.Location = New System.Drawing.Point(349, 153)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(311, 316)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Clientes asociados"
        '
        'ButtonADesmarcar
        '
        Me.ButtonADesmarcar.Location = New System.Drawing.Point(95, 18)
        Me.ButtonADesmarcar.Name = "ButtonADesmarcar"
        Me.ButtonADesmarcar.Size = New System.Drawing.Size(111, 23)
        Me.ButtonADesmarcar.TabIndex = 133
        Me.ButtonADesmarcar.Text = "Desmarcar todos"
        Me.ButtonADesmarcar.UseVisualStyleBackColor = True
        '
        'ButtonAMarcar
        '
        Me.ButtonAMarcar.Location = New System.Drawing.Point(6, 18)
        Me.ButtonAMarcar.Name = "ButtonAMarcar"
        Me.ButtonAMarcar.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAMarcar.TabIndex = 132
        Me.ButtonAMarcar.Text = "Marcar todos"
        Me.ButtonAMarcar.UseVisualStyleBackColor = True
        '
        'GrillaConInc
        '
        Me.GrillaConInc.AllowUserToAddRows = False
        Me.GrillaConInc.AllowUserToDeleteRows = False
        Me.GrillaConInc.BackgroundColor = System.Drawing.Color.White
        Me.GrillaConInc.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaConInc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.GrillaConInc.ColumnHeadersHeight = 25
        Me.GrillaConInc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.GrillaConInc.EnableHeadersVisualStyles = False
        Me.GrillaConInc.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaConInc.Location = New System.Drawing.Point(6, 47)
        Me.GrillaConInc.Name = "GrillaConInc"
        Me.GrillaConInc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaConInc.RowHeadersVisible = False
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaConInc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaConInc.Size = New System.Drawing.Size(299, 261)
        Me.GrillaConInc.TabIndex = 123
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "pro_codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "S"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTextBoxColumn2.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'btn_deselecciona
        '
        Me.btn_deselecciona.Location = New System.Drawing.Point(316, 288)
        Me.btn_deselecciona.Name = "btn_deselecciona"
        Me.btn_deselecciona.Size = New System.Drawing.Size(31, 25)
        Me.btn_deselecciona.TabIndex = 133
        Me.btn_deselecciona.Text = "<<"
        Me.btn_deselecciona.UseVisualStyleBackColor = True
        '
        'btn_selecciona
        '
        Me.btn_selecciona.Location = New System.Drawing.Point(316, 257)
        Me.btn_selecciona.Name = "btn_selecciona"
        Me.btn_selecciona.Size = New System.Drawing.Size(31, 25)
        Me.btn_selecciona.TabIndex = 132
        Me.btn_selecciona.Text = ">>"
        Me.btn_selecciona.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbInformes)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 34)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(656, 42)
        Me.GroupBox5.TabIndex = 134
        Me.GroupBox5.TabStop = False
        '
        'cmbInformes
        '
        Me.cmbInformes.FormattingEnabled = True
        Me.cmbInformes.Location = New System.Drawing.Point(215, 14)
        Me.cmbInformes.Name = "cmbInformes"
        Me.cmbInformes.Size = New System.Drawing.Size(268, 21)
        Me.cmbInformes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Indicador clave de rendimiento (KPI)"
        '
        'boxEntreFechas
        '
        Me.boxEntreFechas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.boxEntreFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxEntreFechas.Controls.Add(Me.txtFechaHasta)
        Me.boxEntreFechas.Controls.Add(Me.Label3)
        Me.boxEntreFechas.Controls.Add(Me.txtFechaDesde)
        Me.boxEntreFechas.Controls.Add(Me.Label2)
        Me.boxEntreFechas.Location = New System.Drawing.Point(142, 81)
        Me.boxEntreFechas.Name = "boxEntreFechas"
        Me.boxEntreFechas.Size = New System.Drawing.Size(518, 66)
        Me.boxEntreFechas.TabIndex = 135
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaHasta.Location = New System.Drawing.Point(97, 32)
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(107, 22)
        Me.txtFechaHasta.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha hasta"
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaDesde.Location = New System.Drawing.Point(97, 4)
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(107, 22)
        Me.txtFechaDesde.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha desde"
        '
        'boxEntrePeriodos
        '
        Me.boxEntrePeriodos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.boxEntrePeriodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxEntrePeriodos.Controls.Add(Me.cmbPeriodoHastaMes)
        Me.boxEntrePeriodos.Controls.Add(Me.cmbPeriodoDesdeMes)
        Me.boxEntrePeriodos.Controls.Add(Me.txtPeriodoHastaAno)
        Me.boxEntrePeriodos.Controls.Add(Me.txtPeriodoDesdeAno)
        Me.boxEntrePeriodos.Controls.Add(Me.Label4)
        Me.boxEntrePeriodos.Controls.Add(Me.Label5)
        Me.boxEntrePeriodos.Location = New System.Drawing.Point(142, 81)
        Me.boxEntrePeriodos.Name = "boxEntrePeriodos"
        Me.boxEntrePeriodos.Size = New System.Drawing.Size(518, 66)
        Me.boxEntrePeriodos.TabIndex = 136
        '
        'cmbPeriodoHastaMes
        '
        Me.cmbPeriodoHastaMes.FormattingEnabled = True
        Me.cmbPeriodoHastaMes.Location = New System.Drawing.Point(146, 31)
        Me.cmbPeriodoHastaMes.Name = "cmbPeriodoHastaMes"
        Me.cmbPeriodoHastaMes.Size = New System.Drawing.Size(129, 21)
        Me.cmbPeriodoHastaMes.TabIndex = 12
        '
        'cmbPeriodoDesdeMes
        '
        Me.cmbPeriodoDesdeMes.FormattingEnabled = True
        Me.cmbPeriodoDesdeMes.Location = New System.Drawing.Point(146, 4)
        Me.cmbPeriodoDesdeMes.Name = "cmbPeriodoDesdeMes"
        Me.cmbPeriodoDesdeMes.Size = New System.Drawing.Size(129, 21)
        Me.cmbPeriodoDesdeMes.TabIndex = 11
        '
        'txtPeriodoHastaAno
        '
        Me.txtPeriodoHastaAno.Location = New System.Drawing.Point(100, 30)
        Me.txtPeriodoHastaAno.Name = "txtPeriodoHastaAno"
        Me.txtPeriodoHastaAno.Size = New System.Drawing.Size(43, 22)
        Me.txtPeriodoHastaAno.TabIndex = 10
        Me.txtPeriodoHastaAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeriodoDesdeAno
        '
        Me.txtPeriodoDesdeAno.Location = New System.Drawing.Point(100, 4)
        Me.txtPeriodoDesdeAno.Name = "txtPeriodoDesdeAno"
        Me.txtPeriodoDesdeAno.Size = New System.Drawing.Size(43, 22)
        Me.txtPeriodoDesdeAno.TabIndex = 9
        Me.txtPeriodoDesdeAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Periodo hasta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Periodo desde"
        '
        'boxPeriodo
        '
        Me.boxPeriodo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.boxPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxPeriodo.Controls.Add(Me.cmbPeriodoMes)
        Me.boxPeriodo.Controls.Add(Me.txtPeriodoAno)
        Me.boxPeriodo.Controls.Add(Me.Label7)
        Me.boxPeriodo.Location = New System.Drawing.Point(142, 81)
        Me.boxPeriodo.Name = "boxPeriodo"
        Me.boxPeriodo.Size = New System.Drawing.Size(518, 66)
        Me.boxPeriodo.TabIndex = 139
        '
        'cmbPeriodoMes
        '
        Me.cmbPeriodoMes.FormattingEnabled = True
        Me.cmbPeriodoMes.Location = New System.Drawing.Point(114, 22)
        Me.cmbPeriodoMes.Name = "cmbPeriodoMes"
        Me.cmbPeriodoMes.Size = New System.Drawing.Size(129, 21)
        Me.cmbPeriodoMes.TabIndex = 8
        '
        'txtPeriodoAno
        '
        Me.txtPeriodoAno.Location = New System.Drawing.Point(68, 22)
        Me.txtPeriodoAno.Name = "txtPeriodoAno"
        Me.txtPeriodoAno.Size = New System.Drawing.Size(43, 22)
        Me.txtPeriodoAno.TabIndex = 7
        Me.txtPeriodoAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Periodo"
        '
        'frm_kpi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 494)
        Me.Controls.Add(Me.boxPeriodo)
        Me.Controls.Add(Me.boxEntrePeriodos)
        Me.Controls.Add(Me.boxEntreFechas)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btn_deselecciona)
        Me.Controls.Add(Me.btn_selecciona)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_kpi"
        Me.Text = "INDICADORES CLAVE DE RENDIMIENTO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GrillaSinInc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GrillaConInc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.boxEntreFechas.ResumeLayout(False)
        Me.boxEntreFechas.PerformLayout()
        Me.boxEntrePeriodos.ResumeLayout(False)
        Me.boxEntrePeriodos.PerformLayout()
        Me.boxPeriodo.ResumeLayout(False)
        Me.boxPeriodo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonImprime As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents optPorPeriodo As RadioButton
    Friend WithEvents optEntrePeriodos As RadioButton
    Friend WithEvents optEntreFecha As RadioButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GrillaSinInc As DataGridView
    Friend WithEvents bu_codigo As DataGridViewTextBoxColumn
    Friend WithEvents pro_seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents pro_nombre As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GrillaConInc As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents ButtonSMarcar As Button
    Friend WithEvents ButtonADesmarcar As Button
    Friend WithEvents ButtonAMarcar As Button
    Friend WithEvents btn_deselecciona As Button
    Friend WithEvents btn_selecciona As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cmbInformes As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonSDesmarcar As Button
    Friend WithEvents boxEntreFechas As Panel
    Friend WithEvents txtFechaHasta As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFechaDesde As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents boxEntrePeriodos As Panel
    Friend WithEvents cmbPeriodoHastaMes As ComboBox
    Friend WithEvents cmbPeriodoDesdeMes As ComboBox
    Friend WithEvents txtPeriodoHastaAno As TextBox
    Friend WithEvents txtPeriodoDesdeAno As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents boxPeriodo As Panel
    Friend WithEvents cmbPeriodoMes As ComboBox
    Friend WithEvents txtPeriodoAno As TextBox
    Friend WithEvents Label7 As Label
End Class
