<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_movimientos_recepcion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_movimientos_recepcion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ButtonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GrillaDetalle = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_bulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_disponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colnbulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProductos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbBodegaDestino = New System.Windows.Forms.ComboBox()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grillaUbicaciones = New System.Windows.Forms.DataGridView()
        Me.col_ubicodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_asignar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_ubirelacionada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grillaPallet = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_s = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_seriepallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrillaSerieUbicacion = New System.Windows.Forms.DataGridView()
        Me.cusu_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cserie_pallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ccantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colbut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colelimina = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ButtonGrabar = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GrillaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grillaUbicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaPallet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.GrillaSerieUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(663, 4)
        Me.Panel1.TabIndex = 3
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonGuardar, Me.ToolStripSeparator2, Me.ButtonImprimir, Me.ToolStripSeparator1, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(663, 25)
        Me.ToolStrip2.TabIndex = 4
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGuardar.Image = CType(resources.GetObject("ButtonGuardar.Image"), System.Drawing.Image)
        Me.ButtonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(79, 22)
        Me.ButtonGuardar.Text = "GUARDAR"
        Me.ButtonGuardar.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImprimir.Image = CType(resources.GetObject("ButtonImprimir.Image"), System.Drawing.Image)
        Me.ButtonImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(76, 22)
        Me.ButtonImprimir.Text = "IMPRIMIR"
        Me.ButtonImprimir.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripButton2.Text = "SALIR"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(663, 4)
        Me.Panel2.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(663, 142)
        Me.Panel3.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GrillaDetalle)
        Me.GroupBox2.Location = New System.Drawing.Point(342, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 133)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de bultos"
        '
        'GrillaDetalle
        '
        Me.GrillaDetalle.AllowUserToAddRows = False
        Me.GrillaDetalle.AllowUserToDeleteRows = False
        Me.GrillaDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrillaDetalle.BackgroundColor = System.Drawing.Color.White
        Me.GrillaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaDetalle.ColumnHeadersHeight = 25
        Me.GrillaDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.col_bulto, Me.col_cantidad, Me.col_disponible, Me.colCP, Me.colnbulto})
        Me.GrillaDetalle.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.GrillaDetalle.EnableHeadersVisualStyles = False
        Me.GrillaDetalle.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaDetalle.Location = New System.Drawing.Point(6, 21)
        Me.GrillaDetalle.Name = "GrillaDetalle"
        Me.GrillaDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaDetalle.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaDetalle.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.GrillaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaDetalle.Size = New System.Drawing.Size(294, 101)
        Me.GrillaDetalle.TabIndex = 56
        '
        'Column5
        '
        Me.Column5.HeaderText = "pro_codigo"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'col_bulto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_bulto.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_bulto.HeaderText = "BULTO"
        Me.col_bulto.Name = "col_bulto"
        Me.col_bulto.ReadOnly = True
        Me.col_bulto.Width = 70
        '
        'col_cantidad
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_cantidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_cantidad.HeaderText = "CA"
        Me.col_cantidad.Name = "col_cantidad"
        Me.col_cantidad.ReadOnly = True
        Me.col_cantidad.Width = 50
        '
        'col_disponible
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_disponible.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_disponible.HeaderText = "CS"
        Me.col_disponible.Name = "col_disponible"
        Me.col_disponible.ReadOnly = True
        Me.col_disponible.Width = 50
        '
        'colCP
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCP.DefaultCellStyle = DataGridViewCellStyle5
        Me.colCP.HeaderText = "CP"
        Me.colCP.Name = "colCP"
        Me.colCP.ReadOnly = True
        Me.colCP.Width = 50
        '
        'colnbulto
        '
        Me.colnbulto.HeaderText = "colnbulto"
        Me.colnbulto.Name = "colnbulto"
        Me.colnbulto.ReadOnly = True
        Me.colnbulto.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbProductos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbBodegaDestino)
        Me.GroupBox1.Controls.Add(Me.cmbZona)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 133)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recepción y destino"
        '
        'txtNumero
        '
        Me.txtNumero.Enabled = False
        Me.txtNumero.Location = New System.Drawing.Point(101, 21)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(214, 22)
        Me.txtNumero.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ZONA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° RECEPCIÓN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "B. DESTINO"
        '
        'cmbProductos
        '
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(101, 48)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(214, 21)
        Me.cmbProductos.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "PRODUCTO"
        '
        'cmbBodegaDestino
        '
        Me.cmbBodegaDestino.FormattingEnabled = True
        Me.cmbBodegaDestino.Location = New System.Drawing.Point(101, 74)
        Me.cmbBodegaDestino.Name = "cmbBodegaDestino"
        Me.cmbBodegaDestino.Size = New System.Drawing.Size(214, 21)
        Me.cmbBodegaDestino.TabIndex = 3
        '
        'cmbZona
        '
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(101, 101)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(214, 21)
        Me.cmbZona.TabIndex = 4
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 522)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(663, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotal
        '
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 17)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 175)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(663, 347)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grillaUbicaciones)
        Me.TabPage1.Controls.Add(Me.grillaPallet)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(655, 321)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "LISTADO DE PALEET"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grillaUbicaciones
        '
        Me.grillaUbicaciones.AllowUserToAddRows = False
        Me.grillaUbicaciones.AllowUserToDeleteRows = False
        Me.grillaUbicaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.grillaUbicaciones.BackgroundColor = System.Drawing.Color.White
        Me.grillaUbicaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaUbicaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaUbicaciones.ColumnHeadersHeight = 25
        Me.grillaUbicaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ubicodigo, Me.DataGridViewCheckBoxColumn1, Me.col_ubicacion, Me.col_asignar, Me.col_ubirelacionada, Me.col_serie})
        Me.grillaUbicaciones.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.grillaUbicaciones.EnableHeadersVisualStyles = False
        Me.grillaUbicaciones.GridColor = System.Drawing.SystemColors.HotTrack
        Me.grillaUbicaciones.Location = New System.Drawing.Point(338, 3)
        Me.grillaUbicaciones.Name = "grillaUbicaciones"
        Me.grillaUbicaciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.grillaUbicaciones.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grillaUbicaciones.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaUbicaciones.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grillaUbicaciones.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grillaUbicaciones.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grillaUbicaciones.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.grillaUbicaciones.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.grillaUbicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaUbicaciones.Size = New System.Drawing.Size(309, 312)
        Me.grillaUbicaciones.TabIndex = 57
        '
        'col_ubicodigo
        '
        Me.col_ubicodigo.HeaderText = "ubi_codigo"
        Me.col_ubicodigo.Name = "col_ubicodigo"
        Me.col_ubicodigo.ReadOnly = True
        Me.col_ubicodigo.Visible = False
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "S"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 30
        '
        'col_ubicacion
        '
        Me.col_ubicacion.HeaderText = "UBICACIÓN"
        Me.col_ubicacion.Name = "col_ubicacion"
        Me.col_ubicacion.ReadOnly = True
        Me.col_ubicacion.Width = 170
        '
        'col_asignar
        '
        Me.col_asignar.HeaderText = ""
        Me.col_asignar.Name = "col_asignar"
        Me.col_asignar.ReadOnly = True
        Me.col_asignar.Text = "ASIGNAR"
        Me.col_asignar.UseColumnTextForButtonValue = True
        Me.col_asignar.Width = 75
        '
        'col_ubirelacionada
        '
        Me.col_ubirelacionada.HeaderText = "col_ubirelacionada"
        Me.col_ubirelacionada.Name = "col_ubirelacionada"
        Me.col_ubirelacionada.ReadOnly = True
        Me.col_ubirelacionada.Visible = False
        '
        'col_serie
        '
        Me.col_serie.HeaderText = "serie"
        Me.col_serie.Name = "col_serie"
        Me.col_serie.ReadOnly = True
        Me.col_serie.Visible = False
        '
        'grillaPallet
        '
        Me.grillaPallet.AllowUserToAddRows = False
        Me.grillaPallet.AllowUserToDeleteRows = False
        Me.grillaPallet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grillaPallet.BackgroundColor = System.Drawing.Color.White
        Me.grillaPallet.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPallet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grillaPallet.ColumnHeadersHeight = 25
        Me.grillaPallet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.col_s, Me.col_seriepallet, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5})
        Me.grillaPallet.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.grillaPallet.EnableHeadersVisualStyles = False
        Me.grillaPallet.GridColor = System.Drawing.SystemColors.HotTrack
        Me.grillaPallet.Location = New System.Drawing.Point(3, 3)
        Me.grillaPallet.Name = "grillaPallet"
        Me.grillaPallet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.grillaPallet.RowHeadersVisible = False
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grillaPallet.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.grillaPallet.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grillaPallet.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grillaPallet.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grillaPallet.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.grillaPallet.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.grillaPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaPallet.Size = New System.Drawing.Size(315, 312)
        Me.grillaPallet.TabIndex = 56
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "pro_codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'col_s
        '
        Me.col_s.HeaderText = "S"
        Me.col_s.Name = "col_s"
        Me.col_s.Visible = False
        Me.col_s.Width = 30
        '
        'col_seriepallet
        '
        Me.col_seriepallet.HeaderText = "SERIE PALLET"
        Me.col_seriepallet.Name = "col_seriepallet"
        Me.col_seriepallet.ReadOnly = True
        Me.col_seriepallet.Width = 160
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn2.HeaderText = "BULTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn3.HeaderText = "CA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "colnbulto"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GrillaSerieUbicacion)
        Me.TabPage2.Controls.Add(Me.ButtonGrabar)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(655, 321)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "UBICACIONES SELECCIONADA"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GrillaSerieUbicacion
        '
        Me.GrillaSerieUbicacion.AllowUserToAddRows = False
        Me.GrillaSerieUbicacion.AllowUserToDeleteRows = False
        Me.GrillaSerieUbicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrillaSerieUbicacion.BackgroundColor = System.Drawing.Color.White
        Me.GrillaSerieUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaSerieUbicacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.GrillaSerieUbicacion.ColumnHeadersHeight = 25
        Me.GrillaSerieUbicacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cusu_codigo, Me.cserie_pallet, Me.ccantidad, Me.colubicacion, Me.colbut, Me.colelimina})
        Me.GrillaSerieUbicacion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.GrillaSerieUbicacion.EnableHeadersVisualStyles = False
        Me.GrillaSerieUbicacion.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaSerieUbicacion.Location = New System.Drawing.Point(5, 33)
        Me.GrillaSerieUbicacion.Name = "GrillaSerieUbicacion"
        Me.GrillaSerieUbicacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaSerieUbicacion.RowHeadersVisible = False
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaSerieUbicacion.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.GrillaSerieUbicacion.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaSerieUbicacion.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaSerieUbicacion.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaSerieUbicacion.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.GrillaSerieUbicacion.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.GrillaSerieUbicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaSerieUbicacion.Size = New System.Drawing.Size(645, 282)
        Me.GrillaSerieUbicacion.TabIndex = 59
        '
        'cusu_codigo
        '
        Me.cusu_codigo.HeaderText = "usu_codigo"
        Me.cusu_codigo.Name = "cusu_codigo"
        Me.cusu_codigo.ReadOnly = True
        Me.cusu_codigo.Visible = False
        '
        'cserie_pallet
        '
        Me.cserie_pallet.HeaderText = "SERIE PALLET"
        Me.cserie_pallet.Name = "cserie_pallet"
        Me.cserie_pallet.ReadOnly = True
        Me.cserie_pallet.Width = 200
        '
        'ccantidad
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ccantidad.DefaultCellStyle = DataGridViewCellStyle14
        Me.ccantidad.HeaderText = "CANTIDAD"
        Me.ccantidad.Name = "ccantidad"
        Me.ccantidad.ReadOnly = True
        Me.ccantidad.Width = 70
        '
        'colubicacion
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colubicacion.DefaultCellStyle = DataGridViewCellStyle15
        Me.colubicacion.HeaderText = "UBICACION"
        Me.colubicacion.Name = "colubicacion"
        Me.colubicacion.ReadOnly = True
        Me.colubicacion.Width = 270
        '
        'colbut
        '
        Me.colbut.HeaderText = "colbut"
        Me.colbut.Name = "colbut"
        Me.colbut.ReadOnly = True
        Me.colbut.Visible = False
        '
        'colelimina
        '
        Me.colelimina.HeaderText = ""
        Me.colelimina.Name = "colelimina"
        Me.colelimina.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colelimina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colelimina.Text = "ELIMINA"
        Me.colelimina.UseColumnTextForButtonValue = True
        Me.colelimina.Width = 70
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Location = New System.Drawing.Point(6, 4)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGrabar.TabIndex = 58
        Me.ButtonGrabar.Text = "GUARDAR"
        Me.ButtonGrabar.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(593, 5)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(60, 22)
        Me.txtCantidad.TabIndex = 9
        '
        'frm_movimientos_recepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 544)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_movimientos_recepcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOVIMIENTO DESDE RECEPCIÓN"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GrillaDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grillaUbicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaPallet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.GrillaSerieUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ButtonGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents cmbBodegaDestino As ComboBox
    Friend WithEvents cmbProductos As ComboBox
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GrillaDetalle As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents grillaPallet As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents col_s As DataGridViewCheckBoxColumn
    Friend WithEvents col_seriepallet As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents grillaUbicaciones As DataGridView
    Friend WithEvents col_ubicodigo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents col_ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents col_asignar As DataGridViewButtonColumn
    Friend WithEvents col_ubirelacionada As DataGridViewTextBoxColumn
    Friend WithEvents col_serie As DataGridViewTextBoxColumn
    Friend WithEvents ButtonGrabar As Button
    Friend WithEvents GrillaSerieUbicacion As DataGridView
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents col_bulto As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents col_disponible As DataGridViewTextBoxColumn
    Friend WithEvents colCP As DataGridViewTextBoxColumn
    Friend WithEvents colnbulto As DataGridViewTextBoxColumn
    Friend WithEvents cusu_codigo As DataGridViewTextBoxColumn
    Friend WithEvents cserie_pallet As DataGridViewTextBoxColumn
    Friend WithEvents ccantidad As DataGridViewTextBoxColumn
    Friend WithEvents colubicacion As DataGridViewTextBoxColumn
    Friend WithEvents colbut As DataGridViewTextBoxColumn
    Friend WithEvents colelimina As DataGridViewButtonColumn
    Friend WithEvents txtCantidad As TextBox
End Class
