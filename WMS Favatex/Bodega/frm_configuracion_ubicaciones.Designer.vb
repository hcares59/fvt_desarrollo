<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_configuracion_ubicaciones
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbRack = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPosMarcar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAltMarcar = New System.Windows.Forms.Button()
        Me.grillaAltura = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.ubi_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UBI_CHECK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ubi_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_ALTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_LARGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_FONDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_SEGMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_PROCEEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_editar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.grillaPosicion = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.BtnPosicion = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grillaAltura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaPosicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1001, 4)
        Me.Panel1.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Location = New System.Drawing.Point(0, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1001, 23)
        Me.Panel2.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CONFIGURACIÓN DE UBICACIONES"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 27)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1001, 4)
        Me.Panel3.TabIndex = 32
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 599)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1001, 22)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbRack)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 45)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione Rack"
        '
        'cmbRack
        '
        Me.cmbRack.FormattingEnabled = True
        Me.cmbRack.Location = New System.Drawing.Point(17, 17)
        Me.cmbRack.Name = "cmbRack"
        Me.cmbRack.Size = New System.Drawing.Size(148, 21)
        Me.cmbRack.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPosMarcar)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 327)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione posiciones"
        '
        'btnPosMarcar
        '
        Me.btnPosMarcar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPosMarcar.Location = New System.Drawing.Point(7, 19)
        Me.btnPosMarcar.Name = "btnPosMarcar"
        Me.btnPosMarcar.Size = New System.Drawing.Size(175, 23)
        Me.btnPosMarcar.TabIndex = 43
        Me.btnPosMarcar.Text = "SELECCIONAR TODO"
        Me.btnPosMarcar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnAltMarcar)
        Me.GroupBox3.Controls.Add(Me.grillaAltura)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 409)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(189, 187)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seleccione alturas"
        '
        'btnAltMarcar
        '
        Me.btnAltMarcar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAltMarcar.Location = New System.Drawing.Point(6, 18)
        Me.btnAltMarcar.Name = "btnAltMarcar"
        Me.btnAltMarcar.Size = New System.Drawing.Size(175, 23)
        Me.btnAltMarcar.TabIndex = 44
        Me.btnAltMarcar.Text = "SELECCIONAR TODO"
        Me.btnAltMarcar.UseVisualStyleBackColor = True
        '
        'grillaAltura
        '
        Me.grillaAltura.AllowUserToAddRows = False
        Me.grillaAltura.AllowUserToDeleteRows = False
        Me.grillaAltura.BackgroundColor = System.Drawing.Color.White
        Me.grillaAltura.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaAltura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaAltura.ColumnHeadersHeight = 25
        Me.grillaAltura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn4})
        Me.grillaAltura.EnableHeadersVisualStyles = False
        Me.grillaAltura.GridColor = System.Drawing.SystemColors.HotTrack
        Me.grillaAltura.Location = New System.Drawing.Point(6, 45)
        Me.grillaAltura.Name = "grillaAltura"
        Me.grillaAltura.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.grillaAltura.RowHeadersVisible = False
        Me.grillaAltura.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grillaAltura.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grillaAltura.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grillaAltura.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue
        Me.grillaAltura.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.grillaAltura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaAltura.Size = New System.Drawing.Size(176, 135)
        Me.grillaAltura.TabIndex = 42
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "alt_codigo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.HeaderText = "S"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn2.Width = 30
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "ALTURA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla.ColumnHeadersHeight = 25
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ubi_codigo, Me.UBI_CHECK, Me.ubi_nombre, Me.COL_ALTO, Me.COL_LARGO, Me.COL_FONDO, Me.COL_SEGMENTO, Me.COL_PROCEEDOR, Me.col_editar})
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(203, 64)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Grilla.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(792, 532)
        Me.Grilla.TabIndex = 40
        '
        'ubi_codigo
        '
        Me.ubi_codigo.HeaderText = "ubi_codigo"
        Me.ubi_codigo.Name = "ubi_codigo"
        Me.ubi_codigo.Visible = False
        '
        'UBI_CHECK
        '
        Me.UBI_CHECK.HeaderText = "S"
        Me.UBI_CHECK.Name = "UBI_CHECK"
        Me.UBI_CHECK.ReadOnly = True
        Me.UBI_CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UBI_CHECK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.UBI_CHECK.Width = 30
        '
        'ubi_nombre
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ubi_nombre.DefaultCellStyle = DataGridViewCellStyle4
        Me.ubi_nombre.HeaderText = "UBICACIÓN"
        Me.ubi_nombre.Name = "ubi_nombre"
        Me.ubi_nombre.Width = 90
        '
        'COL_ALTO
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_ALTO.DefaultCellStyle = DataGridViewCellStyle5
        Me.COL_ALTO.HeaderText = "ALTO"
        Me.COL_ALTO.Name = "COL_ALTO"
        Me.COL_ALTO.Width = 60
        '
        'COL_LARGO
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_LARGO.DefaultCellStyle = DataGridViewCellStyle6
        Me.COL_LARGO.HeaderText = "LARGO"
        Me.COL_LARGO.Name = "COL_LARGO"
        Me.COL_LARGO.Width = 60
        '
        'COL_FONDO
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_FONDO.DefaultCellStyle = DataGridViewCellStyle7
        Me.COL_FONDO.HeaderText = "FONDO"
        Me.COL_FONDO.Name = "COL_FONDO"
        Me.COL_FONDO.Width = 60
        '
        'COL_SEGMENTO
        '
        Me.COL_SEGMENTO.HeaderText = "SEGMENTO"
        Me.COL_SEGMENTO.Name = "COL_SEGMENTO"
        Me.COL_SEGMENTO.Width = 130
        '
        'COL_PROCEEDOR
        '
        Me.COL_PROCEEDOR.HeaderText = "PROVEEDOR POR DEFECTO"
        Me.COL_PROCEEDOR.Name = "COL_PROCEEDOR"
        Me.COL_PROCEEDOR.Width = 220
        '
        'col_editar
        '
        Me.col_editar.HeaderText = ""
        Me.col_editar.Name = "col_editar"
        Me.col_editar.Text = "EDITAR"
        Me.col_editar.UseColumnTextForButtonValue = True
        Me.col_editar.Width = 90
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(892, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 23)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "EDICIÓN MASIVA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(203, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 23)
        Me.Button2.TabIndex = 42
        Me.Button2.Text = "GENERAR UBICACIONES"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'grillaPosicion
        '
        Me.grillaPosicion.AllowUserToAddRows = False
        Me.grillaPosicion.AllowUserToDeleteRows = False
        Me.grillaPosicion.BackgroundColor = System.Drawing.Color.White
        Me.grillaPosicion.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPosicion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaPosicion.ColumnHeadersHeight = 25
        Me.grillaPosicion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.grillaPosicion.EnableHeadersVisualStyles = False
        Me.grillaPosicion.GridColor = System.Drawing.SystemColors.HotTrack
        Me.grillaPosicion.Location = New System.Drawing.Point(15, 126)
        Me.grillaPosicion.Name = "grillaPosicion"
        Me.grillaPosicion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.grillaPosicion.RowHeadersVisible = False
        Me.grillaPosicion.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grillaPosicion.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grillaPosicion.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.grillaPosicion.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue
        Me.grillaPosicion.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.grillaPosicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaPosicion.Size = New System.Drawing.Size(176, 271)
        Me.grillaPosicion.TabIndex = 41
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "pos_codigo"
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn2.HeaderText = "POSICIÓN"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(347, 36)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(123, 23)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "SELECCIONAR TODO"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(473, 36)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 23)
        Me.Button4.TabIndex = 45
        Me.Button4.Text = "DESMARCAR TODO"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'BtnPosicion
        '
        Me.BtnPosicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPosicion.Location = New System.Drawing.Point(593, 36)
        Me.BtnPosicion.Name = "BtnPosicion"
        Me.BtnPosicion.Size = New System.Drawing.Size(116, 23)
        Me.BtnPosicion.TabIndex = 46
        Me.BtnPosicion.Text = "ELIMINA POSICIÓN"
        Me.BtnPosicion.UseVisualStyleBackColor = True
        '
        'frm_configuracion_ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 621)
        Me.Controls.Add(Me.BtnPosicion)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.grillaPosicion)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_configuracion_ubicaciones"
        Me.Text = "CONFIGURACIÓN DE UBICACIONES"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grillaAltura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaPosicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbRack As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents grillaPosicion As DataGridView
    Friend WithEvents grillaAltura As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents btnPosMarcar As Button
    Friend WithEvents btnAltMarcar As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ubi_codigo As DataGridViewTextBoxColumn
    Friend WithEvents UBI_CHECK As DataGridViewCheckBoxColumn
    Friend WithEvents ubi_nombre As DataGridViewTextBoxColumn
    Friend WithEvents COL_ALTO As DataGridViewTextBoxColumn
    Friend WithEvents COL_LARGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_FONDO As DataGridViewTextBoxColumn
    Friend WithEvents COL_SEGMENTO As DataGridViewTextBoxColumn
    Friend WithEvents COL_PROCEEDOR As DataGridViewTextBoxColumn
    Friend WithEvents col_editar As DataGridViewButtonColumn
    Friend WithEvents Button4 As Button
    Friend WithEvents BtnPosicion As Button
End Class
