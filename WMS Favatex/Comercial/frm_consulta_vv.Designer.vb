<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_vv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_vv))
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.chkCompromiso = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpCompromisoHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpCompromisoDesde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotRegistro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.COL_RUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_EPC_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_comuna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_mail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELEFONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CO_PROD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAR_CO0DIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_COD_FVT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEC_DESPACHO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_car_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(766, 4)
        Me.Panel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator7, Me.ButtonSalir, Me.ToolStripSeparator8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(766, 25)
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
        Me.ToolStripButton1.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripButton1.Text = "EXPORTAR"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(766, 4)
        Me.Panel2.TabIndex = 42
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
        Me.Panel4.Size = New System.Drawing.Size(766, 23)
        Me.Panel4.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CONSUTA DE CLIENTES DE VENTA EN VERDE"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(766, 54)
        Me.Panel3.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Seleccione cliente"
        '
        'cmbCliente
        '
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(109, 16)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(227, 21)
        Me.cmbCliente.TabIndex = 13
        '
        'chkCompromiso
        '
        Me.chkCompromiso.AutoSize = True
        Me.chkCompromiso.ForeColor = System.Drawing.Color.Black
        Me.chkCompromiso.Location = New System.Drawing.Point(351, 17)
        Me.chkCompromiso.Name = "chkCompromiso"
        Me.chkCompromiso.Size = New System.Drawing.Size(172, 17)
        Me.chkCompromiso.TabIndex = 14
        Me.chkCompromiso.Text = "Fecha de compromiso desde"
        Me.chkCompromiso.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(611, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Hasta"
        '
        'dtpCompromisoHasta
        '
        Me.dtpCompromisoHasta.Enabled = False
        Me.dtpCompromisoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromisoHasta.Location = New System.Drawing.Point(656, 15)
        Me.dtpCompromisoHasta.Name = "dtpCompromisoHasta"
        Me.dtpCompromisoHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpCompromisoHasta.TabIndex = 18
        '
        'dtpCompromisoDesde
        '
        Me.dtpCompromisoDesde.Enabled = False
        Me.dtpCompromisoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromisoDesde.Location = New System.Drawing.Point(523, 15)
        Me.dtpCompromisoDesde.Name = "dtpCompromisoDesde"
        Me.dtpCompromisoDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpCompromisoDesde.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpCompromisoHasta)
        Me.GroupBox1.Controls.Add(Me.cmbCliente)
        Me.GroupBox1.Controls.Add(Me.dtpCompromisoDesde)
        Me.GroupBox1.Controls.Add(Me.chkCompromiso)
        Me.GroupBox1.Location = New System.Drawing.Point(7, -3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(753, 50)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotRegistro})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 437)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(766, 24)
        Me.StatusStrip1.TabIndex = 47
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotRegistro
        '
        Me.lblTotRegistro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblTotRegistro.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblTotRegistro.Name = "lblTotRegistro"
        Me.lblTotRegistro.Size = New System.Drawing.Size(124, 19)
        Me.lblTotRegistro.Text = "ToolStripStatusLabel1"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grilla.CausesValidation = False
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.Grilla.ColumnHeadersHeight = 25
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_RUT, Me.COL_NOMBRE, Me.COL_EPC_NOMBRE, Me.col_comuna, Me.col_mail, Me.TELEFONO, Me.COL_CO_PROD, Me.col_prod, Me.CAR_CO0DIGO, Me.COL_COD_FVT, Me.pro_nombre, Me.FEC_DESPACHO, Me.col_car_codigo, Me.col_cliente})
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
        Me.Grilla.Size = New System.Drawing.Size(766, 327)
        Me.Grilla.TabIndex = 48
        '
        'COL_RUT
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_RUT.DefaultCellStyle = DataGridViewCellStyle17
        Me.COL_RUT.HeaderText = "Rut"
        Me.COL_RUT.Name = "COL_RUT"
        Me.COL_RUT.ReadOnly = True
        Me.COL_RUT.Width = 70
        '
        'COL_NOMBRE
        '
        Me.COL_NOMBRE.HeaderText = "Nombre"
        Me.COL_NOMBRE.Name = "COL_NOMBRE"
        Me.COL_NOMBRE.ReadOnly = True
        Me.COL_NOMBRE.Width = 120
        '
        'COL_EPC_NOMBRE
        '
        Me.COL_EPC_NOMBRE.HeaderText = "Dirección"
        Me.COL_EPC_NOMBRE.Name = "COL_EPC_NOMBRE"
        Me.COL_EPC_NOMBRE.ReadOnly = True
        Me.COL_EPC_NOMBRE.Width = 120
        '
        'col_comuna
        '
        Me.col_comuna.HeaderText = "Comuna"
        Me.col_comuna.Name = "col_comuna"
        Me.col_comuna.ReadOnly = True
        Me.col_comuna.Width = 70
        '
        'col_mail
        '
        Me.col_mail.HeaderText = "E-mail"
        Me.col_mail.Name = "col_mail"
        Me.col_mail.ReadOnly = True
        Me.col_mail.Width = 70
        '
        'TELEFONO
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TELEFONO.DefaultCellStyle = DataGridViewCellStyle18
        Me.TELEFONO.HeaderText = "Teléfono"
        Me.TELEFONO.Name = "TELEFONO"
        Me.TELEFONO.ReadOnly = True
        Me.TELEFONO.Width = 70
        '
        'COL_CO_PROD
        '
        Me.COL_CO_PROD.HeaderText = "SKU Cliente"
        Me.COL_CO_PROD.Name = "COL_CO_PROD"
        Me.COL_CO_PROD.ReadOnly = True
        '
        'col_prod
        '
        Me.col_prod.HeaderText = "SKU Nombre"
        Me.col_prod.Name = "col_prod"
        Me.col_prod.ReadOnly = True
        Me.col_prod.Width = 130
        '
        'CAR_CO0DIGO
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CAR_CO0DIGO.DefaultCellStyle = DataGridViewCellStyle19
        Me.CAR_CO0DIGO.HeaderText = "Cantidad"
        Me.CAR_CO0DIGO.Name = "CAR_CO0DIGO"
        Me.CAR_CO0DIGO.ReadOnly = True
        Me.CAR_CO0DIGO.Width = 90
        '
        'COL_COD_FVT
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_COD_FVT.DefaultCellStyle = DataGridViewCellStyle20
        Me.COL_COD_FVT.HeaderText = "Cod. Favatex"
        Me.COL_COD_FVT.Name = "COL_COD_FVT"
        Me.COL_COD_FVT.ReadOnly = True
        Me.COL_COD_FVT.Width = 90
        '
        'pro_nombre
        '
        Me.pro_nombre.HeaderText = "Nombre Favatex"
        Me.pro_nombre.Name = "pro_nombre"
        Me.pro_nombre.ReadOnly = True
        Me.pro_nombre.Width = 130
        '
        'FEC_DESPACHO
        '
        Me.FEC_DESPACHO.HeaderText = "F. Compromiso"
        Me.FEC_DESPACHO.Name = "FEC_DESPACHO"
        Me.FEC_DESPACHO.ReadOnly = True
        Me.FEC_DESPACHO.Width = 90
        '
        'col_car_codigo
        '
        Me.col_car_codigo.HeaderText = "car_codigo"
        Me.col_car_codigo.Name = "col_car_codigo"
        Me.col_car_codigo.ReadOnly = True
        Me.col_car_codigo.Visible = False
        '
        'col_cliente
        '
        Me.col_cliente.HeaderText = "Cliente Retail"
        Me.col_cliente.Name = "col_cliente"
        Me.col_cliente.ReadOnly = True
        '
        'frm_consulta_vv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 461)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_consulta_vv"
        Me.Text = "CONSUTA DE CLIENTES DE VENTA EN VERDE"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpCompromisoHasta As DateTimePicker
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents dtpCompromisoDesde As DateTimePicker
    Friend WithEvents chkCompromiso As CheckBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotRegistro As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents COL_RUT As DataGridViewTextBoxColumn
    Friend WithEvents COL_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_EPC_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents col_comuna As DataGridViewTextBoxColumn
    Friend WithEvents col_mail As DataGridViewTextBoxColumn
    Friend WithEvents TELEFONO As DataGridViewTextBoxColumn
    Friend WithEvents COL_CO_PROD As DataGridViewTextBoxColumn
    Friend WithEvents col_prod As DataGridViewTextBoxColumn
    Friend WithEvents CAR_CO0DIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_COD_FVT As DataGridViewTextBoxColumn
    Friend WithEvents pro_nombre As DataGridViewTextBoxColumn
    Friend WithEvents FEC_DESPACHO As DataGridViewTextBoxColumn
    Friend WithEvents col_car_codigo As DataGridViewTextBoxColumn
    Friend WithEvents col_cliente As DataGridViewTextBoxColumn
End Class
