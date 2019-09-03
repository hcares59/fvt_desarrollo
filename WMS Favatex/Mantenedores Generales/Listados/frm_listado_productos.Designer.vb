<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_listado_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_productos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonNueva = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkConfigurar = New System.Windows.Forms.CheckBox()
        Me.ButtonLimpiar = New System.Windows.Forms.Button()
        Me.txtCodigoInterno = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSubCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCategorias = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.cpro_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_odint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_catego = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._subcat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bul_cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doc_cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_activo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.COLIMP = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.elimina = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.grilla_det = New System.Windows.Forms.DataGridView()
        Me.col_codigointerno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombreproducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombrecategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombresubcategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_bulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fondo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidadbase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidadalto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_tipobulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_horizontal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_det, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(945, 4)
        Me.Panel4.TabIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonImprimir, Me.ToolStripSeparator4, Me.ButtonNueva, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ButtonExportar, Me.ToolStripSeparator3, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(945, 25)
        Me.ToolStrip1.TabIndex = 27
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Image = CType(resources.GetObject("ButtonImprimir.Image"), System.Drawing.Image)
        Me.ButtonImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(76, 22)
        Me.ButtonImprimir.Text = "IMPRIMIR"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNueva.Image = CType(resources.GetObject("ButtonNueva.Image"), System.Drawing.Image)
        Me.ButtonNueva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(118, 22)
        Me.ButtonNueva.Text = "NUEVO REGISTRO"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(945, 4)
        Me.Panel1.TabIndex = 29
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(945, 23)
        Me.Panel2.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "LISTADO DE PRODUCTOS"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.chkConfigurar)
        Me.Panel3.Controls.Add(Me.ButtonLimpiar)
        Me.Panel3.Controls.Add(Me.txtCodigoInterno)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.cmbSubCategoria)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbCategorias)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.chkActivo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(945, 50)
        Me.Panel3.TabIndex = 33
        '
        'chkConfigurar
        '
        Me.chkConfigurar.AutoSize = True
        Me.chkConfigurar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConfigurar.Location = New System.Drawing.Point(699, 27)
        Me.chkConfigurar.Name = "chkConfigurar"
        Me.chkConfigurar.Size = New System.Drawing.Size(176, 17)
        Me.chkConfigurar.TabIndex = 12
        Me.chkConfigurar.Text = "PENDIENTES DE VOLUMETRIA"
        Me.chkConfigurar.UseVisualStyleBackColor = True
        '
        'ButtonLimpiar
        '
        Me.ButtonLimpiar.Location = New System.Drawing.Point(881, 4)
        Me.ButtonLimpiar.Name = "ButtonLimpiar"
        Me.ButtonLimpiar.Size = New System.Drawing.Size(62, 23)
        Me.ButtonLimpiar.TabIndex = 10
        Me.ButtonLimpiar.Text = "LIMPIAR"
        Me.ButtonLimpiar.UseVisualStyleBackColor = True
        '
        'txtCodigoInterno
        '
        Me.txtCodigoInterno.Location = New System.Drawing.Point(585, 4)
        Me.txtCodigoInterno.MaxLength = 8
        Me.txtCodigoInterno.Name = "txtCodigoInterno"
        Me.txtCodigoInterno.Size = New System.Drawing.Size(89, 22)
        Me.txtCodigoInterno.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(530, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "CODIGO"
        '
        'cmbSubCategoria
        '
        Me.cmbSubCategoria.FormattingEnabled = True
        Me.cmbSubCategoria.Location = New System.Drawing.Point(348, 5)
        Me.cmbSubCategoria.Name = "cmbSubCategoria"
        Me.cmbSubCategoria.Size = New System.Drawing.Size(172, 21)
        Me.cmbSubCategoria.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(258, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "SUBCATEGORIA"
        '
        'cmbCategorias
        '
        Me.cmbCategorias.FormattingEnabled = True
        Me.cmbCategorias.Location = New System.Drawing.Point(80, 5)
        Me.cmbCategorias.Name = "cmbCategorias"
        Me.cmbCategorias.Size = New System.Drawing.Size(172, 21)
        Me.cmbCategorias.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "CATEGORIA"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(699, 6)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(157, 17)
        Me.chkActivo.TabIndex = 3
        Me.chkActivo.Text = "MOSTRAR SOLO ACTIVOS "
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 413)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(945, 22)
        Me.StatusStrip1.TabIndex = 34
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cpro_codigo, Me.pro_odint, Me.pro_nombre, Me.pro_catego, Me._subcat, Me.pro_color, Me.bul_cant, Me.doc_cant, Me.pro_activo, Me.COLIMP, Me.Column1, Me.elimina})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 106)
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
        Me.Grilla.Size = New System.Drawing.Size(945, 307)
        Me.Grilla.TabIndex = 35
        '
        'cpro_codigo
        '
        Me.cpro_codigo.HeaderText = "PRO_CODIGO"
        Me.cpro_codigo.Name = "cpro_codigo"
        Me.cpro_codigo.ReadOnly = True
        Me.cpro_codigo.Visible = False
        '
        'pro_odint
        '
        Me.pro_odint.HeaderText = "CODIGO"
        Me.pro_odint.Name = "pro_odint"
        Me.pro_odint.ReadOnly = True
        Me.pro_odint.Width = 80
        '
        'pro_nombre
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.pro_nombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.pro_nombre.HeaderText = "NOMBRE"
        Me.pro_nombre.Name = "pro_nombre"
        Me.pro_nombre.ReadOnly = True
        Me.pro_nombre.Width = 250
        '
        'pro_catego
        '
        Me.pro_catego.HeaderText = "CATEGORIA"
        Me.pro_catego.Name = "pro_catego"
        Me.pro_catego.ReadOnly = True
        Me.pro_catego.Width = 130
        '
        '_subcat
        '
        Me._subcat.HeaderText = "SUBCATEGORIA"
        Me._subcat.Name = "_subcat"
        Me._subcat.ReadOnly = True
        Me._subcat.Width = 130
        '
        'pro_color
        '
        Me.pro_color.HeaderText = "COLOR"
        Me.pro_color.Name = "pro_color"
        Me.pro_color.ReadOnly = True
        Me.pro_color.Width = 120
        '
        'bul_cant
        '
        Me.bul_cant.FillWeight = 70.0!
        Me.bul_cant.HeaderText = "BULTOS"
        Me.bul_cant.Name = "bul_cant"
        Me.bul_cant.ReadOnly = True
        Me.bul_cant.Width = 60
        '
        'doc_cant
        '
        Me.doc_cant.FillWeight = 70.0!
        Me.doc_cant.HeaderText = "BUL. ING."
        Me.doc_cant.Name = "doc_cant"
        Me.doc_cant.ReadOnly = True
        Me.doc_cant.Width = 65
        '
        'pro_activo
        '
        Me.pro_activo.HeaderText = "A"
        Me.pro_activo.Name = "pro_activo"
        Me.pro_activo.ReadOnly = True
        Me.pro_activo.Width = 25
        '
        'COLIMP
        '
        Me.COLIMP.HeaderText = "IMP"
        Me.COLIMP.Name = "COLIMP"
        Me.COLIMP.ReadOnly = True
        Me.COLIMP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.COLIMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.COLIMP.Width = 35
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "MODIFICAR"
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
        Me.elimina.Text = "ELIMINAR"
        Me.elimina.UseColumnTextForButtonValue = True
        Me.elimina.Width = 80
        '
        'grilla_det
        '
        Me.grilla_det.AllowUserToAddRows = False
        Me.grilla_det.AllowUserToDeleteRows = False
        Me.grilla_det.BackgroundColor = System.Drawing.Color.White
        Me.grilla_det.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_det.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grilla_det.ColumnHeadersHeight = 25
        Me.grilla_det.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_codigointerno, Me.col_nombreproducto, Me.col_nombrecategoria, Me.col_nombresubcategoria, Me.col_bulto, Me.col_ancho, Me.col_alto, Me.col_fondo, Me.col_cantidadbase, Me.col_cantidadalto, Me.col_tipobulto, Me.col_horizontal})
        Me.grilla_det.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grilla_det.EnableHeadersVisualStyles = False
        Me.grilla_det.GridColor = System.Drawing.SystemColors.HotTrack
        Me.grilla_det.Location = New System.Drawing.Point(0, 0)
        Me.grilla_det.Name = "grilla_det"
        Me.grilla_det.ReadOnly = True
        Me.grilla_det.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.grilla_det.RowHeadersVisible = False
        Me.grilla_det.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grilla_det.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grilla_det.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grilla_det.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.grilla_det.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.grilla_det.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_det.Size = New System.Drawing.Size(945, 435)
        Me.grilla_det.TabIndex = 37
        Me.grilla_det.Visible = False
        '
        'col_codigointerno
        '
        Me.col_codigointerno.HeaderText = "codigo interno"
        Me.col_codigointerno.Name = "col_codigointerno"
        Me.col_codigointerno.ReadOnly = True
        '
        'col_nombreproducto
        '
        Me.col_nombreproducto.HeaderText = "nombre producto"
        Me.col_nombreproducto.Name = "col_nombreproducto"
        Me.col_nombreproducto.ReadOnly = True
        '
        'col_nombrecategoria
        '
        Me.col_nombrecategoria.HeaderText = "nombre categoria"
        Me.col_nombrecategoria.Name = "col_nombrecategoria"
        Me.col_nombrecategoria.ReadOnly = True
        '
        'col_nombresubcategoria
        '
        Me.col_nombresubcategoria.HeaderText = "nombre subcategoria"
        Me.col_nombresubcategoria.Name = "col_nombresubcategoria"
        Me.col_nombresubcategoria.ReadOnly = True
        '
        'col_bulto
        '
        Me.col_bulto.HeaderText = "bulto"
        Me.col_bulto.Name = "col_bulto"
        Me.col_bulto.ReadOnly = True
        '
        'col_ancho
        '
        Me.col_ancho.HeaderText = "ancho"
        Me.col_ancho.Name = "col_ancho"
        Me.col_ancho.ReadOnly = True
        '
        'col_alto
        '
        Me.col_alto.HeaderText = "alto"
        Me.col_alto.Name = "col_alto"
        Me.col_alto.ReadOnly = True
        '
        'col_fondo
        '
        Me.col_fondo.HeaderText = "fondo"
        Me.col_fondo.Name = "col_fondo"
        Me.col_fondo.ReadOnly = True
        '
        'col_cantidadbase
        '
        Me.col_cantidadbase.HeaderText = "cantidad en base"
        Me.col_cantidadbase.Name = "col_cantidadbase"
        Me.col_cantidadbase.ReadOnly = True
        '
        'col_cantidadalto
        '
        Me.col_cantidadalto.HeaderText = "cantidad alto"
        Me.col_cantidadalto.Name = "col_cantidadalto"
        Me.col_cantidadalto.ReadOnly = True
        '
        'col_tipobulto
        '
        Me.col_tipobulto.HeaderText = "tipo bulto"
        Me.col_tipobulto.Name = "col_tipobulto"
        Me.col_tipobulto.ReadOnly = True
        '
        'col_horizontal
        '
        Me.col_horizontal.HeaderText = "horizontal"
        Me.col_horizontal.Name = "col_horizontal"
        Me.col_horizontal.ReadOnly = True
        '
        'frm_listado_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 435)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.grilla_det)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frm_listado_productos"
        Me.Text = "LISTADO DE PRODUCTOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_det, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNueva As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbCategorias As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents cmbSubCategoria As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodigoInterno As TextBox
    Friend WithEvents ButtonLimpiar As Button
    Friend WithEvents ButtonExportar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents cpro_codigo As DataGridViewTextBoxColumn
    Friend WithEvents pro_odint As DataGridViewTextBoxColumn
    Friend WithEvents pro_nombre As DataGridViewTextBoxColumn
    Friend WithEvents pro_catego As DataGridViewTextBoxColumn
    Friend WithEvents _subcat As DataGridViewTextBoxColumn
    Friend WithEvents pro_color As DataGridViewTextBoxColumn
    Friend WithEvents bul_cant As DataGridViewTextBoxColumn
    Friend WithEvents doc_cant As DataGridViewTextBoxColumn
    Friend WithEvents pro_activo As DataGridViewCheckBoxColumn
    Friend WithEvents COLIMP As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents elimina As DataGridViewButtonColumn
    Friend WithEvents chkConfigurar As CheckBox
    Friend WithEvents grilla_det As DataGridView
    Friend WithEvents col_codigointerno As DataGridViewTextBoxColumn
    Friend WithEvents col_nombreproducto As DataGridViewTextBoxColumn
    Friend WithEvents col_nombrecategoria As DataGridViewTextBoxColumn
    Friend WithEvents col_nombresubcategoria As DataGridViewTextBoxColumn
    Friend WithEvents col_bulto As DataGridViewTextBoxColumn
    Friend WithEvents col_ancho As DataGridViewTextBoxColumn
    Friend WithEvents col_alto As DataGridViewTextBoxColumn
    Friend WithEvents col_fondo As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidadbase As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidadalto As DataGridViewTextBoxColumn
    Friend WithEvents col_tipobulto As DataGridViewTextBoxColumn
    Friend WithEvents col_horizontal As DataGridViewTextBoxColumn
End Class
