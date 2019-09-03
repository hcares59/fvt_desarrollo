<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ingreso_citas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ingreso_citas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrillaFechas = New System.Windows.Forms.DataGridView()
        Me.COL_COD_PICKING = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_fecha_p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fec_ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_esabierta = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkTipoOrden = New System.Windows.Forms.CheckBox()
        Me.txtNumerocita = New System.Windows.Forms.TextBox()
        Me.txtFechaCita = New System.Windows.Forms.DateTimePicker()
        Me.txtHora = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaOrdenCompra = New System.Windows.Forms.TextBox()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GrillaFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(504, 30)
        Me.Panel2.TabIndex = 5
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(504, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(65, 22)
        Me.ButtonNuevo.Text = "NUEVO"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonGurdar
        '
        Me.ButtonGurdar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGurdar.Image = CType(resources.GetObject("ButtonGurdar.Image"), System.Drawing.Image)
        Me.ButtonGurdar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonGurdar.Name = "ButtonGurdar"
        Me.ButtonGurdar.Size = New System.Drawing.Size(79, 22)
        Me.ButtonGurdar.Text = "GUARDAR"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbltitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 31)
        Me.Panel1.TabIndex = 6
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.BackColor = System.Drawing.Color.Transparent
        Me.lbltitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.White
        Me.lbltitulo.Location = New System.Drawing.Point(3, -1)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(248, 30)
        Me.lbltitulo.TabIndex = 0
        Me.lbltitulo.Text = "MANTENEDOR DE CITAS"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.cmbCliente)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 61)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(504, 28)
        Me.Panel4.TabIndex = 11
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(125, 3)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(237, 21)
        Me.cmbCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SELECCIONE CLIENTE"
        '
        'GrillaFechas
        '
        Me.GrillaFechas.AllowUserToAddRows = False
        Me.GrillaFechas.AllowUserToDeleteRows = False
        Me.GrillaFechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrillaFechas.BackgroundColor = System.Drawing.Color.White
        Me.GrillaFechas.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaFechas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaFechas.ColumnHeadersHeight = 25
        Me.GrillaFechas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_COD_PICKING, Me.col_fecha_p, Me.col_fec_ingreso, Me.col_esabierta})
        Me.GrillaFechas.EnableHeadersVisualStyles = False
        Me.GrillaFechas.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaFechas.Location = New System.Drawing.Point(4, 94)
        Me.GrillaFechas.Name = "GrillaFechas"
        Me.GrillaFechas.ReadOnly = True
        Me.GrillaFechas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaFechas.RowHeadersVisible = False
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaFechas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaFechas.Size = New System.Drawing.Size(219, 229)
        Me.GrillaFechas.TabIndex = 12
        '
        'COL_COD_PICKING
        '
        Me.COL_COD_PICKING.HeaderText = "S"
        Me.COL_COD_PICKING.Name = "COL_COD_PICKING"
        Me.COL_COD_PICKING.ReadOnly = True
        Me.COL_COD_PICKING.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.COL_COD_PICKING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.COL_COD_PICKING.Visible = False
        Me.COL_COD_PICKING.Width = 30
        '
        'col_fecha_p
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_fecha_p.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_fecha_p.HeaderText = "O. COMPRA"
        Me.col_fecha_p.Name = "col_fecha_p"
        Me.col_fecha_p.ReadOnly = True
        Me.col_fecha_p.Width = 110
        '
        'col_fec_ingreso
        '
        Me.col_fec_ingreso.HeaderText = "FECHA"
        Me.col_fec_ingreso.Name = "col_fec_ingreso"
        Me.col_fec_ingreso.ReadOnly = True
        Me.col_fec_ingreso.Width = 90
        '
        'col_esabierta
        '
        Me.col_esabierta.HeaderText = "es abierta"
        Me.col_esabierta.Name = "col_esabierta"
        Me.col_esabierta.ReadOnly = True
        Me.col_esabierta.Visible = False
        Me.col_esabierta.Width = 40
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkTipoOrden)
        Me.GroupBox1.Controls.Add(Me.txtNumerocita)
        Me.GroupBox1.Controls.Add(Me.txtFechaCita)
        Me.GroupBox1.Controls.Add(Me.txtHora)
        Me.GroupBox1.Controls.Add(Me.txtFechaOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(232, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 230)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información general de la cita"
        '
        'chkTipoOrden
        '
        Me.chkTipoOrden.AutoSize = True
        Me.chkTipoOrden.Enabled = False
        Me.chkTipoOrden.Location = New System.Drawing.Point(20, 169)
        Me.chkTipoOrden.Name = "chkTipoOrden"
        Me.chkTipoOrden.Size = New System.Drawing.Size(98, 17)
        Me.chkTipoOrden.TabIndex = 18
        Me.chkTipoOrden.Text = "Orden abierta"
        Me.chkTipoOrden.UseVisualStyleBackColor = True
        '
        'txtNumerocita
        '
        Me.txtNumerocita.Location = New System.Drawing.Point(136, 136)
        Me.txtNumerocita.Name = "txtNumerocita"
        Me.txtNumerocita.Size = New System.Drawing.Size(100, 22)
        Me.txtNumerocita.TabIndex = 6
        Me.txtNumerocita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaCita
        '
        Me.txtFechaCita.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaCita.Location = New System.Drawing.Point(137, 81)
        Me.txtFechaCita.Name = "txtFechaCita"
        Me.txtFechaCita.Size = New System.Drawing.Size(99, 22)
        Me.txtFechaCita.TabIndex = 4
        '
        'txtHora
        '
        Me.txtHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHora.BackColor = System.Drawing.Color.White
        Me.txtHora.Location = New System.Drawing.Point(136, 108)
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(100, 22)
        Me.txtHora.TabIndex = 5
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHora.ValidatingType = GetType(Date)
        '
        'txtFechaOrdenCompra
        '
        Me.txtFechaOrdenCompra.Enabled = False
        Me.txtFechaOrdenCompra.Location = New System.Drawing.Point(136, 53)
        Me.txtFechaOrdenCompra.Name = "txtFechaOrdenCompra"
        Me.txtFechaOrdenCompra.Size = New System.Drawing.Size(100, 22)
        Me.txtFechaOrdenCompra.TabIndex = 3
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Enabled = False
        Me.txtOrdenCompra.Location = New System.Drawing.Point(136, 25)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(100, 22)
        Me.txtOrdenCompra.TabIndex = 2
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "NUMERO CITA"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "HORA CITA"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "FECHA CITA"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "FECHA O. COMPRA"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ORDEN DE COMPRA"
        '
        'frm_ingreso_citas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 332)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrillaFechas)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ingreso_citas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENEDOR DE CITAS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.GrillaFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbltitulo As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents GrillaFechas As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFechaOrdenCompra As TextBox
    Friend WithEvents txtOrdenCompra As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents txtNumerocita As TextBox
    Friend WithEvents txtFechaCita As DateTimePicker
    Friend WithEvents txtHora As MaskedTextBox
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents COL_COD_PICKING As DataGridViewCheckBoxColumn
    Friend WithEvents col_fecha_p As DataGridViewTextBoxColumn
    Friend WithEvents col_fec_ingreso As DataGridViewTextBoxColumn
    Friend WithEvents col_esabierta As DataGridViewCheckBoxColumn
    Friend WithEvents chkTipoOrden As CheckBox
End Class
