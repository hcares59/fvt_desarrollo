<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_listado_asignaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_asignaciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
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
        Me.chkDesdeRecepcion = New System.Windows.Forms.CheckBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOCompra = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRec = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaOCDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaOCHasta = New System.Windows.Forms.DateTimePicker()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.COL_ABRIR = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.COL_NOM_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_COD_ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_OC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_PROV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD_CAR_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_COD_ASI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(860, 4)
        Me.Panel4.TabIndex = 17
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNueva, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ButtonExportar, Me.ToolStripSeparator3, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(860, 25)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNueva.Image = CType(resources.GetObject("ButtonNueva.Image"), System.Drawing.Image)
        Me.ButtonNueva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(123, 22)
        Me.ButtonNueva.Text = "NUEVA RECEPCIÓN"
        Me.ButtonNueva.Visible = False
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
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(860, 4)
        Me.Panel1.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(860, 23)
        Me.Panel2.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(271, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "LISTADO DE ASIGNACIONES DE UBICACION"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.chkDesdeRecepcion)
        Me.Panel3.Controls.Add(Me.cmbEstado)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtOCompra)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtRec)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.dtpFechaOCDesde)
        Me.Panel3.Controls.Add(Me.dtpFechaOCHasta)
        Me.Panel3.Controls.Add(Me.cmbProveedor)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.chkFecha)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(860, 62)
        Me.Panel3.TabIndex = 46
        '
        'chkDesdeRecepcion
        '
        Me.chkDesdeRecepcion.AutoSize = True
        Me.chkDesdeRecepcion.Checked = True
        Me.chkDesdeRecepcion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesdeRecepcion.Location = New System.Drawing.Point(595, 37)
        Me.chkDesdeRecepcion.Name = "chkDesdeRecepcion"
        Me.chkDesdeRecepcion.Size = New System.Drawing.Size(203, 17)
        Me.chkDesdeRecepcion.TabIndex = 34
        Me.chkDesdeRecepcion.Text = "ASIGNACIONES DESDE RECEPCIÓN"
        Me.chkDesdeRecepcion.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(595, 6)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(203, 21)
        Me.cmbEstado.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(542, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "ESTADO"
        '
        'txtOCompra
        '
        Me.txtOCompra.Location = New System.Drawing.Point(429, 7)
        Me.txtOCompra.Name = "txtOCompra"
        Me.txtOCompra.Size = New System.Drawing.Size(78, 22)
        Me.txtOCompra.TabIndex = 31
        Me.txtOCompra.Text = "0"
        Me.txtOCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(374, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "N° O. C."
        '
        'txtRec
        '
        Me.txtRec.Location = New System.Drawing.Point(429, 33)
        Me.txtRec.Name = "txtRec"
        Me.txtRec.Size = New System.Drawing.Size(78, 22)
        Me.txtRec.TabIndex = 26
        Me.txtRec.Text = "0"
        Me.txtRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(366, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "N° RECEP."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "HASTA"
        '
        'dtpFechaOCDesde
        '
        Me.dtpFechaOCDesde.Enabled = False
        Me.dtpFechaOCDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOCDesde.Location = New System.Drawing.Point(118, 33)
        Me.dtpFechaOCDesde.Name = "dtpFechaOCDesde"
        Me.dtpFechaOCDesde.Size = New System.Drawing.Size(82, 22)
        Me.dtpFechaOCDesde.TabIndex = 23
        '
        'dtpFechaOCHasta
        '
        Me.dtpFechaOCHasta.Enabled = False
        Me.dtpFechaOCHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOCHasta.Location = New System.Drawing.Point(251, 34)
        Me.dtpFechaOCHasta.Name = "dtpFechaOCHasta"
        Me.dtpFechaOCHasta.Size = New System.Drawing.Size(82, 22)
        Me.dtpFechaOCHasta.TabIndex = 22
        '
        'cmbProveedor
        '
        Me.cmbProveedor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(118, 6)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(215, 21)
        Me.cmbProveedor.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "PROVEEDOR"
        '
        'chkFecha
        '
        Me.chkFecha.AutoSize = True
        Me.chkFecha.Location = New System.Drawing.Point(22, 36)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(97, 17)
        Me.chkFecha.TabIndex = 24
        Me.chkFecha.Text = "FECHA DESDE"
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 476)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(860, 22)
        Me.StatusStrip1.TabIndex = 47
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_COD_ASI, Me.COD_CAR_CODIGO, Me.COL_PROV, Me.COL_FECHA, Me.COL_OC, Me.COL_REC, Me.COL_COD_ESTADO, Me.COL_NOM_ESTADO, Me.COL_ABRIR})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 118)
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
        Me.Grilla.Size = New System.Drawing.Size(860, 358)
        Me.Grilla.TabIndex = 48
        '
        'COL_ABRIR
        '
        Me.COL_ABRIR.HeaderText = ""
        Me.COL_ABRIR.Name = "COL_ABRIR"
        Me.COL_ABRIR.ReadOnly = True
        Me.COL_ABRIR.Text = "ABRIR"
        Me.COL_ABRIR.UseColumnTextForButtonValue = True
        '
        'COL_NOM_ESTADO
        '
        Me.COL_NOM_ESTADO.HeaderText = "ESTADO"
        Me.COL_NOM_ESTADO.Name = "COL_NOM_ESTADO"
        Me.COL_NOM_ESTADO.ReadOnly = True
        '
        'COL_COD_ESTADO
        '
        Me.COL_COD_ESTADO.HeaderText = "COD_ESTADO"
        Me.COL_COD_ESTADO.Name = "COL_COD_ESTADO"
        Me.COL_COD_ESTADO.ReadOnly = True
        '
        'COL_REC
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_REC.DefaultCellStyle = DataGridViewCellStyle4
        Me.COL_REC.HeaderText = "N° RECP"
        Me.COL_REC.Name = "COL_REC"
        Me.COL_REC.ReadOnly = True
        '
        'COL_OC
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_OC.DefaultCellStyle = DataGridViewCellStyle3
        Me.COL_OC.HeaderText = "N°OC"
        Me.COL_OC.Name = "COL_OC"
        Me.COL_OC.ReadOnly = True
        '
        'COL_FECHA
        '
        Me.COL_FECHA.HeaderText = "FECHA"
        Me.COL_FECHA.Name = "COL_FECHA"
        Me.COL_FECHA.ReadOnly = True
        '
        'COL_PROV
        '
        Me.COL_PROV.HeaderText = "PROVEEDOR"
        Me.COL_PROV.Name = "COL_PROV"
        Me.COL_PROV.ReadOnly = True
        '
        'COD_CAR_CODIGO
        '
        Me.COD_CAR_CODIGO.HeaderText = "CAR_CODIGO"
        Me.COD_CAR_CODIGO.Name = "COD_CAR_CODIGO"
        Me.COD_CAR_CODIGO.ReadOnly = True
        Me.COD_CAR_CODIGO.Visible = False
        '
        'COL_COD_ASI
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_COD_ASI.DefaultCellStyle = DataGridViewCellStyle2
        Me.COL_COD_ASI.HeaderText = "N° ASIGNACION"
        Me.COL_COD_ASI.Name = "COL_COD_ASI"
        Me.COL_COD_ASI.ReadOnly = True
        '
        'frm_listado_asignaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 498)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_listado_asignaciones"
        Me.Text = "LISTADO DE ASIGNACIONES"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNueva As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonExportar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtOCompra As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtRec As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaOCDesde As DateTimePicker
    Friend WithEvents dtpFechaOCHasta As DateTimePicker
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkFecha As CheckBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents chkDesdeRecepcion As CheckBox
    Friend WithEvents COL_COD_ASI As DataGridViewTextBoxColumn
    Friend WithEvents COD_CAR_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_PROV As DataGridViewTextBoxColumn
    Friend WithEvents COL_FECHA As DataGridViewTextBoxColumn
    Friend WithEvents COL_OC As DataGridViewTextBoxColumn
    Friend WithEvents COL_REC As DataGridViewTextBoxColumn
    Friend WithEvents COL_COD_ESTADO As DataGridViewTextBoxColumn
    Friend WithEvents COL_NOM_ESTADO As DataGridViewTextBoxColumn
    Friend WithEvents COL_ABRIR As DataGridViewButtonColumn
End Class
