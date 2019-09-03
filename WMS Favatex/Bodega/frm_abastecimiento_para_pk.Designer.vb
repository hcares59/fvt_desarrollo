<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_abastecimiento_para_pk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_abastecimiento_para_pk))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonAsignar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbSubcategoria = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigoUnico = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.cols = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_subcat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_bulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantubica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantunidades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoPal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_llave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrillaAsignacion = New System.Windows.Forms.DataGridView()
        Me.col_fila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRO_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcodint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colbulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcodubi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colubipk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colpallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcodubiaba = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colubiabas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colpalletaba = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcantabas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_proceado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_ubicado = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colsinprocesar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colcantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cpl_pallet_piso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.txtObservación = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFechaOab = New System.Windows.Forms.DateTimePicker()
        Me.txtNumAsi = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnAsigna = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimeIdentificador = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFinaliza = New System.Windows.Forms.ToolStripButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GrillaAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(874, 4)
        Me.Panel2.TabIndex = 40
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator7, Me.ButtonAsignar, Me.ToolStripSeparator1, Me.ButtonSalir, Me.ToolStripSeparator8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(874, 25)
        Me.ToolStrip1.TabIndex = 41
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(69, 22)
        Me.ButtonNuevo.Text = "BUSCAR"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripButton1.Text = "IMPRIMIR"
        Me.ToolStripButton1.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator7.Visible = False
        '
        'ButtonAsignar
        '
        Me.ButtonAsignar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAsignar.Image = CType(resources.GetObject("ButtonAsignar.Image"), System.Drawing.Image)
        Me.ButtonAsignar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAsignar.Name = "ButtonAsignar"
        Me.ButtonAsignar.Size = New System.Drawing.Size(98, 22)
        Me.ButtonAsignar.Text = "SELECCIONAR"
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(874, 4)
        Me.Panel1.TabIndex = 42
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(874, 23)
        Me.Panel4.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ABASTECIMIENTO PARA PICKING"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 458)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(874, 22)
        Me.StatusStrip1.TabIndex = 48
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(874, 40)
        Me.Panel3.TabIndex = 49
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbSubcategoria)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCategoria)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCodigoUnico)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, -3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(865, 40)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbSubcategoria
        '
        Me.cmbSubcategoria.FormattingEnabled = True
        Me.cmbSubcategoria.Location = New System.Drawing.Point(563, 13)
        Me.cmbSubcategoria.Name = "cmbSubcategoria"
        Me.cmbSubcategoria.Size = New System.Drawing.Size(159, 21)
        Me.cmbSubcategoria.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(481, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "SubCategoría"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(290, 13)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(159, 21)
        Me.cmbCategoria.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Categoría"
        '
        'txtCodigoUnico
        '
        Me.txtCodigoUnico.Location = New System.Drawing.Point(111, 13)
        Me.txtCodigoUnico.Name = "txtCodigoUnico"
        Me.txtCodigoUnico.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigoUnico.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Buscar por código"
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
        Me.Grilla.ColumnHeadersHeight = 33
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cols, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.col_cat, Me.col_subcat, Me.col_bulto, Me.col_cantubica, Me.col_cantunidades, Me.colTipoPal, Me.col_llave, Me.col_marca})
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
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(860, 330)
        Me.Grilla.TabIndex = 50
        '
        'cols
        '
        Me.cols.HeaderText = "S"
        Me.cols.Name = "cols"
        Me.cols.Width = 40
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "pro_codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Producto"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'col_cat
        '
        Me.col_cat.HeaderText = "Categoría"
        Me.col_cat.Name = "col_cat"
        '
        'col_subcat
        '
        Me.col_subcat.HeaderText = "SubCategoría"
        Me.col_subcat.Name = "col_subcat"
        '
        'col_bulto
        '
        Me.col_bulto.HeaderText = "Bulto"
        Me.col_bulto.Name = "col_bulto"
        Me.col_bulto.ReadOnly = True
        '
        'col_cantubica
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_cantubica.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_cantubica.HeaderText = "Cantidad ubicaciones de PK"
        Me.col_cantubica.Name = "col_cantubica"
        Me.col_cantubica.ReadOnly = True
        Me.col_cantubica.Width = 115
        '
        'col_cantunidades
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_cantunidades.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_cantunidades.HeaderText = "Cantidad unidades"
        Me.col_cantunidades.Name = "col_cantunidades"
        Me.col_cantunidades.ReadOnly = True
        '
        'colTipoPal
        '
        Me.colTipoPal.HeaderText = "TP"
        Me.colTipoPal.Name = "colTipoPal"
        Me.colTipoPal.ReadOnly = True
        Me.colTipoPal.Visible = False
        '
        'col_llave
        '
        Me.col_llave.HeaderText = "col_llave"
        Me.col_llave.Name = "col_llave"
        Me.col_llave.ReadOnly = True
        Me.col_llave.Width = 120
        '
        'col_marca
        '
        Me.col_marca.HeaderText = "marca"
        Me.col_marca.Name = "col_marca"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(874, 362)
        Me.TabControl1.TabIndex = 51
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grilla)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(866, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Selecciona para abastecer"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GrillaAsignacion)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.ToolStrip2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(866, 336)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bultos seleccionados para abastecer"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GrillaAsignacion
        '
        Me.GrillaAsignacion.AllowUserToAddRows = False
        Me.GrillaAsignacion.AllowUserToDeleteRows = False
        Me.GrillaAsignacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrillaAsignacion.BackgroundColor = System.Drawing.Color.White
        Me.GrillaAsignacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaAsignacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GrillaAsignacion.ColumnHeadersHeight = 25
        Me.GrillaAsignacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_fila, Me.PRO_CODIGO, Me.colcodint, Me.colbulto, Me.colcodubi, Me.colubipk, Me.colpallet, Me.colcant, Me.colcodubiaba, Me.colubiabas, Me.colpalletaba, Me.colcantabas, Me.col_proceado, Me.col_ubicado, Me.colsinprocesar, Me.colcantidad, Me.cpl_pallet_piso})
        Me.GrillaAsignacion.EnableHeadersVisualStyles = False
        Me.GrillaAsignacion.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaAsignacion.Location = New System.Drawing.Point(6, 104)
        Me.GrillaAsignacion.Name = "GrillaAsignacion"
        Me.GrillaAsignacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaAsignacion.RowHeadersVisible = False
        Me.GrillaAsignacion.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaAsignacion.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaAsignacion.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaAsignacion.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaAsignacion.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaAsignacion.Size = New System.Drawing.Size(854, 226)
        Me.GrillaAsignacion.TabIndex = 49
        '
        'col_fila
        '
        Me.col_fila.HeaderText = "Fila"
        Me.col_fila.Name = "col_fila"
        Me.col_fila.ReadOnly = True
        '
        'PRO_CODIGO
        '
        Me.PRO_CODIGO.HeaderText = "PRO_CODIGO"
        Me.PRO_CODIGO.Name = "PRO_CODIGO"
        Me.PRO_CODIGO.ReadOnly = True
        Me.PRO_CODIGO.Visible = False
        '
        'colcodint
        '
        Me.colcodint.HeaderText = "Código"
        Me.colcodint.Name = "colcodint"
        '
        'colbulto
        '
        Me.colbulto.HeaderText = "Bulto"
        Me.colbulto.Name = "colbulto"
        Me.colbulto.ReadOnly = True
        '
        'colcodubi
        '
        Me.colcodubi.HeaderText = "codUbicacion"
        Me.colcodubi.Name = "colcodubi"
        Me.colcodubi.ReadOnly = True
        Me.colcodubi.Visible = False
        '
        'colubipk
        '
        Me.colubipk.HeaderText = "Ubicación PK"
        Me.colubipk.Name = "colubipk"
        Me.colubipk.ReadOnly = True
        '
        'colpallet
        '
        Me.colpallet.HeaderText = "Pallet"
        Me.colpallet.Name = "colpallet"
        Me.colpallet.ReadOnly = True
        '
        'colcant
        '
        Me.colcant.HeaderText = "Cantidad"
        Me.colcant.Name = "colcant"
        Me.colcant.ReadOnly = True
        '
        'colcodubiaba
        '
        Me.colcodubiaba.HeaderText = "codUbiAbas"
        Me.colcodubiaba.Name = "colcodubiaba"
        Me.colcodubiaba.ReadOnly = True
        Me.colcodubiaba.Visible = False
        '
        'colubiabas
        '
        Me.colubiabas.HeaderText = "Ubicación Abastecimiento"
        Me.colubiabas.Name = "colubiabas"
        Me.colubiabas.ReadOnly = True
        Me.colubiabas.Width = 150
        '
        'colpalletaba
        '
        Me.colpalletaba.HeaderText = "Pallet"
        Me.colpalletaba.Name = "colpalletaba"
        Me.colpalletaba.ReadOnly = True
        '
        'colcantabas
        '
        Me.colcantabas.HeaderText = "Cantidad"
        Me.colcantabas.Name = "colcantabas"
        Me.colcantabas.ReadOnly = True
        '
        'col_proceado
        '
        Me.col_proceado.HeaderText = "Procesado"
        Me.col_proceado.Name = "col_proceado"
        '
        'col_ubicado
        '
        Me.col_ubicado.HeaderText = ""
        Me.col_ubicado.Name = "col_ubicado"
        Me.col_ubicado.Text = "Ubicado"
        Me.col_ubicado.UseColumnTextForButtonValue = True
        '
        'colsinprocesar
        '
        Me.colsinprocesar.HeaderText = "sin_procesar"
        Me.colsinprocesar.Name = "colsinprocesar"
        Me.colsinprocesar.ReadOnly = True
        Me.colsinprocesar.Visible = False
        '
        'colcantidad
        '
        Me.colcantidad.HeaderText = "nueva cantidad"
        Me.colcantidad.Name = "colcantidad"
        Me.colcantidad.ReadOnly = True
        Me.colcantidad.Visible = False
        '
        'cpl_pallet_piso
        '
        Me.cpl_pallet_piso.HeaderText = "pallet_piso"
        Me.cpl_pallet_piso.Name = "cpl_pallet_piso"
        Me.cpl_pallet_piso.ReadOnly = True
        Me.cpl_pallet_piso.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.txtObservación)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtFechaOab)
        Me.GroupBox2.Controls.Add(Me.txtNumAsi)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(853, 70)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(253, 41)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(594, 23)
        Me.ProgressBar1.TabIndex = 35
        Me.ProgressBar1.Visible = False
        '
        'txtObservación
        '
        Me.txtObservación.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservación.Location = New System.Drawing.Point(253, 16)
        Me.txtObservación.MaxLength = 250
        Me.txtObservación.Name = "txtObservación"
        Me.txtObservación.Size = New System.Drawing.Size(594, 22)
        Me.txtObservación.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(181, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Observación"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Fecha"
        '
        'TxtFechaOab
        '
        Me.TxtFechaOab.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaOab.Location = New System.Drawing.Point(67, 42)
        Me.TxtFechaOab.Name = "TxtFechaOab"
        Me.TxtFechaOab.Size = New System.Drawing.Size(100, 22)
        Me.TxtFechaOab.TabIndex = 33
        '
        'txtNumAsi
        '
        Me.txtNumAsi.Location = New System.Drawing.Point(67, 16)
        Me.txtNumAsi.Name = "txtNumAsi"
        Me.txtNumAsi.Size = New System.Drawing.Size(100, 22)
        Me.txtNumAsi.TabIndex = 31
        Me.txtNumAsi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "N° OA"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAsigna, Me.ToolStripSeparator3, Me.btnImprimeIdentificador, Me.ToolStripSeparator4, Me.btnFinaliza})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(860, 25)
        Me.ToolStrip2.TabIndex = 42
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnAsigna
        '
        Me.btnAsigna.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnAsigna.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAsigna.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsigna.ForeColor = System.Drawing.Color.Maroon
        Me.btnAsigna.Image = CType(resources.GetObject("btnAsigna.Image"), System.Drawing.Image)
        Me.btnAsigna.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAsigna.Name = "btnAsigna"
        Me.btnAsigna.Size = New System.Drawing.Size(203, 22)
        Me.btnAsigna.Text = "GENERA ORDEN DE ABASTECIMIENTO"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnImprimeIdentificador
        '
        Me.btnImprimeIdentificador.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnImprimeIdentificador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnImprimeIdentificador.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimeIdentificador.ForeColor = System.Drawing.Color.Maroon
        Me.btnImprimeIdentificador.Image = CType(resources.GetObject("btnImprimeIdentificador.Image"), System.Drawing.Image)
        Me.btnImprimeIdentificador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimeIdentificador.Name = "btnImprimeIdentificador"
        Me.btnImprimeIdentificador.Size = New System.Drawing.Size(206, 22)
        Me.btnImprimeIdentificador.Text = "IMPRIME ORDEN DE ABASTECIMIENTO"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnFinaliza
        '
        Me.btnFinaliza.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnFinaliza.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnFinaliza.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinaliza.ForeColor = System.Drawing.Color.Maroon
        Me.btnFinaliza.Image = CType(resources.GetObject("btnFinaliza.Image"), System.Drawing.Image)
        Me.btnFinaliza.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFinaliza.Name = "btnFinaliza"
        Me.btnFinaliza.Size = New System.Drawing.Size(124, 22)
        Me.btnFinaliza.Text = "FINALIZA ASIGNACIÓN"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "iconfinder_price-tag-1_3339025.png")
        Me.ImageList1.Images.SetKeyName(1, "iconfinder_box_61760.png")
        '
        'frm_abastecimiento_para_pk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 480)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_abastecimiento_para_pk"
        Me.Text = "ABASTECIMIENTO PARA PICKING"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GrillaAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbSubcategoria As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigoUnico As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents ButtonAsignar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnAsigna As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnImprimeIdentificador As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnFinaliza As ToolStripButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNumAsi As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtFechaOab As DateTimePicker
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents GrillaAsignacion As DataGridView
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents txtObservación As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cols As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents col_cat As DataGridViewTextBoxColumn
    Friend WithEvents col_subcat As DataGridViewTextBoxColumn
    Friend WithEvents col_bulto As DataGridViewTextBoxColumn
    Friend WithEvents col_cantubica As DataGridViewTextBoxColumn
    Friend WithEvents col_cantunidades As DataGridViewTextBoxColumn
    Friend WithEvents colTipoPal As DataGridViewTextBoxColumn
    Friend WithEvents col_llave As DataGridViewTextBoxColumn
    Friend WithEvents col_marca As DataGridViewTextBoxColumn
    Friend WithEvents col_fila As DataGridViewTextBoxColumn
    Friend WithEvents PRO_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents colcodint As DataGridViewTextBoxColumn
    Friend WithEvents colbulto As DataGridViewTextBoxColumn
    Friend WithEvents colcodubi As DataGridViewTextBoxColumn
    Friend WithEvents colubipk As DataGridViewTextBoxColumn
    Friend WithEvents colpallet As DataGridViewTextBoxColumn
    Friend WithEvents colcant As DataGridViewTextBoxColumn
    Friend WithEvents colcodubiaba As DataGridViewTextBoxColumn
    Friend WithEvents colubiabas As DataGridViewTextBoxColumn
    Friend WithEvents colpalletaba As DataGridViewTextBoxColumn
    Friend WithEvents colcantabas As DataGridViewTextBoxColumn
    Friend WithEvents col_proceado As DataGridViewCheckBoxColumn
    Friend WithEvents col_ubicado As DataGridViewButtonColumn
    Friend WithEvents colsinprocesar As DataGridViewCheckBoxColumn
    Friend WithEvents colcantidad As DataGridViewTextBoxColumn
    Friend WithEvents cpl_pallet_piso As DataGridViewTextBoxColumn
End Class
