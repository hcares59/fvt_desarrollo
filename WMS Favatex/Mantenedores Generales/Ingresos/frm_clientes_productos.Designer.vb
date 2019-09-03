<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_clientes_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_clientes_productos))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.cm_limpiar = New System.Windows.Forms.Button()
        Me.cmd_guardar = New System.Windows.Forms.Button()
        Me.rdAmbos = New System.Windows.Forms.RadioButton()
        Me.rdInternet = New System.Windows.Forms.RadioButton()
        Me.rdCadema = New System.Windows.Forms.RadioButton()
        Me.txtPublico = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.BtnBuscaDoc = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigoFav = New System.Windows.Forms.TextBox()
        Me.txtNombreSku = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSku = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButtonLimpiar = New System.Windows.Forms.Button()
        Me.txtBuscaNombre = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBuscaSku = New System.Windows.Forms.TextBox()
        Me.colprocod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_cartera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_cartera_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_codint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.elimina = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_homo_sv = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(766, 4)
        Me.Panel1.TabIndex = 31
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(766, 25)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(64, 22)
        Me.ButtonNuevo.Text = "NUEVO"
        Me.ButtonNuevo.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'ButtonGurdar
        '
        Me.ButtonGurdar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGurdar.Image = CType(resources.GetObject("ButtonGurdar.Image"), System.Drawing.Image)
        Me.ButtonGurdar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonGurdar.Name = "ButtonGurdar"
        Me.ButtonGurdar.Size = New System.Drawing.Size(79, 22)
        Me.ButtonGurdar.Text = "GUARDAR"
        Me.ButtonGurdar.Visible = False
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(766, 4)
        Me.Panel2.TabIndex = 33
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(756, 44)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione"
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(95, 15)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(568, 21)
        Me.cmbCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CLIENTE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkActivo)
        Me.GroupBox2.Controls.Add(Me.cm_limpiar)
        Me.GroupBox2.Controls.Add(Me.cmd_guardar)
        Me.GroupBox2.Controls.Add(Me.rdAmbos)
        Me.GroupBox2.Controls.Add(Me.rdInternet)
        Me.GroupBox2.Controls.Add(Me.rdCadema)
        Me.GroupBox2.Controls.Add(Me.txtPublico)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtVenta)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtNombre)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaDoc)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCodigoFav)
        Me.GroupBox2.Controls.Add(Me.txtNombreSku)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSku)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(756, 129)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Area de ingreso"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Location = New System.Drawing.Point(95, 102)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 17)
        Me.chkActivo.TabIndex = 174
        Me.chkActivo.Text = "ACTIVO"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'cm_limpiar
        '
        Me.cm_limpiar.Location = New System.Drawing.Point(609, 97)
        Me.cm_limpiar.Name = "cm_limpiar"
        Me.cm_limpiar.Size = New System.Drawing.Size(54, 25)
        Me.cm_limpiar.TabIndex = 12
        Me.cm_limpiar.Text = "NUEVO"
        Me.cm_limpiar.UseVisualStyleBackColor = True
        '
        'cmd_guardar
        '
        Me.cmd_guardar.Location = New System.Drawing.Point(536, 97)
        Me.cmd_guardar.Name = "cmd_guardar"
        Me.cmd_guardar.Size = New System.Drawing.Size(67, 25)
        Me.cmd_guardar.TabIndex = 11
        Me.cmd_guardar.Text = "GUARDAR"
        Me.cmd_guardar.UseVisualStyleBackColor = True
        '
        'rdAmbos
        '
        Me.rdAmbos.AutoSize = True
        Me.rdAmbos.Location = New System.Drawing.Point(541, 74)
        Me.rdAmbos.Name = "rdAmbos"
        Me.rdAmbos.Size = New System.Drawing.Size(123, 17)
        Me.rdAmbos.TabIndex = 10
        Me.rdAmbos.Text = "CADENA /INTERNET"
        Me.rdAmbos.UseVisualStyleBackColor = True
        '
        'rdInternet
        '
        Me.rdInternet.AutoSize = True
        Me.rdInternet.Location = New System.Drawing.Point(465, 74)
        Me.rdInternet.Name = "rdInternet"
        Me.rdInternet.Size = New System.Drawing.Size(73, 17)
        Me.rdInternet.TabIndex = 9
        Me.rdInternet.Text = "INTERNET"
        Me.rdInternet.UseVisualStyleBackColor = True
        '
        'rdCadema
        '
        Me.rdCadema.AutoSize = True
        Me.rdCadema.Checked = True
        Me.rdCadema.Location = New System.Drawing.Point(394, 74)
        Me.rdCadema.Name = "rdCadema"
        Me.rdCadema.Size = New System.Drawing.Size(68, 17)
        Me.rdCadema.TabIndex = 8
        Me.rdCadema.TabStop = True
        Me.rdCadema.Text = "CADENA"
        Me.rdCadema.UseVisualStyleBackColor = True
        '
        'txtPublico
        '
        Me.txtPublico.Location = New System.Drawing.Point(290, 73)
        Me.txtPublico.MaxLength = 6
        Me.txtPublico.Name = "txtPublico"
        Me.txtPublico.Size = New System.Drawing.Size(98, 22)
        Me.txtPublico.TabIndex = 7
        Me.txtPublico.Text = "0"
        Me.txtPublico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(199, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "$ VTA. PUBLICO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "$ VENTA"
        '
        'txtVenta
        '
        Me.txtVenta.Location = New System.Drawing.Point(95, 73)
        Me.txtVenta.MaxLength = 6
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.Size = New System.Drawing.Size(98, 22)
        Me.txtVenta.TabIndex = 6
        Me.txtVenta.Text = "0"
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(247, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "NOM."
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(290, 45)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(373, 22)
        Me.txtNombre.TabIndex = 163
        '
        'BtnBuscaDoc
        '
        Me.BtnBuscaDoc.Location = New System.Drawing.Point(195, 44)
        Me.BtnBuscaDoc.Name = "BtnBuscaDoc"
        Me.BtnBuscaDoc.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscaDoc.TabIndex = 5
        Me.BtnBuscaDoc.Text = "..."
        Me.BtnBuscaDoc.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "COD. FAVATEX"
        '
        'txtCodigoFav
        '
        Me.txtCodigoFav.Location = New System.Drawing.Point(95, 45)
        Me.txtCodigoFav.MaxLength = 15
        Me.txtCodigoFav.Name = "txtCodigoFav"
        Me.txtCodigoFav.Size = New System.Drawing.Size(98, 22)
        Me.txtCodigoFav.TabIndex = 4
        '
        'txtNombreSku
        '
        Me.txtNombreSku.Location = New System.Drawing.Point(290, 17)
        Me.txtNombreSku.Name = "txtNombreSku"
        Me.txtNombreSku.Size = New System.Drawing.Size(373, 22)
        Me.txtNombreSku.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "SKU NOMBRE"
        '
        'txtSku
        '
        Me.txtSku.Location = New System.Drawing.Point(95, 17)
        Me.txtSku.MaxLength = 15
        Me.txtSku.Name = "txtSku"
        Me.txtSku.Size = New System.Drawing.Size(98, 22)
        Me.txtSku.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SKU CLIENTE"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 516)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(766, 22)
        Me.StatusStrip1.TabIndex = 36
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.ColumnHeadersHeight = 25
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colprocod, Me.sku_cartera, Me.sku_cartera_nombre, Me.pro_codint, Me.pro_nombre, Me.Column2, Me.Column3, Me.Column4, Me.Column1, Me.elimina, Me.col_homo_sv})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 252)
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
        Me.Grilla.Size = New System.Drawing.Size(766, 264)
        Me.Grilla.TabIndex = 80
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonLimpiar)
        Me.GroupBox3.Controls.Add(Me.txtBuscaNombre)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtBuscaSku)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 203)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(756, 43)
        Me.GroupBox3.TabIndex = 81
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Area de busqueda"
        '
        'ButtonLimpiar
        '
        Me.ButtonLimpiar.Location = New System.Drawing.Point(609, 15)
        Me.ButtonLimpiar.Name = "ButtonLimpiar"
        Me.ButtonLimpiar.Size = New System.Drawing.Size(54, 25)
        Me.ButtonLimpiar.TabIndex = 15
        Me.ButtonLimpiar.Text = "LIMPIA"
        Me.ButtonLimpiar.UseVisualStyleBackColor = True
        '
        'txtBuscaNombre
        '
        Me.txtBuscaNombre.Location = New System.Drawing.Point(290, 15)
        Me.txtBuscaNombre.Name = "txtBuscaNombre"
        Me.txtBuscaNombre.Size = New System.Drawing.Size(313, 22)
        Me.txtBuscaNombre.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(207, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "SKU NOMBRE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "SKU CLIENTE"
        '
        'txtBuscaSku
        '
        Me.txtBuscaSku.Location = New System.Drawing.Point(95, 15)
        Me.txtBuscaSku.Name = "txtBuscaSku"
        Me.txtBuscaSku.Size = New System.Drawing.Size(98, 22)
        Me.txtBuscaSku.TabIndex = 13
        '
        'colprocod
        '
        Me.colprocod.HeaderText = "colprocod"
        Me.colprocod.Name = "colprocod"
        Me.colprocod.ReadOnly = True
        Me.colprocod.Visible = False
        Me.colprocod.Width = 5
        '
        'sku_cartera
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.sku_cartera.DefaultCellStyle = DataGridViewCellStyle6
        Me.sku_cartera.HeaderText = "SKU"
        Me.sku_cartera.Name = "sku_cartera"
        Me.sku_cartera.ReadOnly = True
        Me.sku_cartera.Width = 80
        '
        'sku_cartera_nombre
        '
        Me.sku_cartera_nombre.HeaderText = "SKU NOMBRE"
        Me.sku_cartera_nombre.Name = "sku_cartera_nombre"
        Me.sku_cartera_nombre.ReadOnly = True
        Me.sku_cartera_nombre.Width = 200
        '
        'pro_codint
        '
        Me.pro_codint.HeaderText = "COD FAV."
        Me.pro_codint.Name = "pro_codint"
        Me.pro_codint.ReadOnly = True
        Me.pro_codint.Width = 80
        '
        'pro_nombre
        '
        Me.pro_nombre.HeaderText = "PRODUCTO"
        Me.pro_nombre.Name = "pro_nombre"
        Me.pro_nombre.ReadOnly = True
        Me.pro_nombre.Width = 200
        '
        'Column2
        '
        Me.Column2.HeaderText = "CANAL"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 115
        '
        'Column3
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column3.HeaderText = "$ VENTA"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column4.HeaderText = "$ VENTA PUB"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 90
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
        Me.elimina.Text = "ELIMINA"
        Me.elimina.UseColumnTextForButtonValue = True
        Me.elimina.Width = 70
        '
        'col_homo_sv
        '
        Me.col_homo_sv.HeaderText = "homo_sv"
        Me.col_homo_sv.Name = "col_homo_sv"
        Me.col_homo_sv.ReadOnly = True
        Me.col_homo_sv.Visible = False
        '
        'frm_clientes_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 538)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_clientes_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLIENTES PRODUCTOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodigoFav As TextBox
    Friend WithEvents txtNombreSku As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSku As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnBuscaDoc As Button
    Friend WithEvents txtPublico As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVenta As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents cm_limpiar As Button
    Friend WithEvents cmd_guardar As Button
    Friend WithEvents rdAmbos As RadioButton
    Friend WithEvents rdInternet As RadioButton
    Friend WithEvents rdCadema As RadioButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ButtonLimpiar As Button
    Friend WithEvents txtBuscaNombre As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBuscaSku As TextBox
    Friend WithEvents colprocod As DataGridViewTextBoxColumn
    Friend WithEvents sku_cartera As DataGridViewTextBoxColumn
    Friend WithEvents sku_cartera_nombre As DataGridViewTextBoxColumn
    Friend WithEvents pro_codint As DataGridViewTextBoxColumn
    Friend WithEvents pro_nombre As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents elimina As DataGridViewButtonColumn
    Friend WithEvents col_homo_sv As DataGridViewCheckBoxColumn
End Class
