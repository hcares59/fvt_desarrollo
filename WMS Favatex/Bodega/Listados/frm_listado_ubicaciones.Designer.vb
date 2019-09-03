<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_listado_ubicaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_ubicaciones))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNueva = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.cmbAltura = New System.Windows.Forms.ComboBox()
        Me.chkEstado = New System.Windows.Forms.CheckBox()
        Me.chkAltura = New System.Windows.Forms.CheckBox()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.chkZona = New System.Windows.Forms.CheckBox()
        Me.chktipoUbicacion = New System.Windows.Forms.CheckBox()
        Me.chkBodega = New System.Windows.Forms.CheckBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.cmbBodegas = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.ubi_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_bodcodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_BODNOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CODTIPOUBICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_NOMBREUBICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CODZONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_NOMBREZONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALT_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ALT_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_UBICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_EUBCODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_EUBNOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_ACTIVO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_abrir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
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
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(835, 4)
        Me.Panel4.TabIndex = 15
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNueva, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(835, 25)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me.Panel1.Size = New System.Drawing.Size(835, 4)
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
        Me.Panel2.Size = New System.Drawing.Size(835, 23)
        Me.Panel2.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "LISTADO DE UBICACIONES"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.cmbEstado)
        Me.Panel3.Controls.Add(Me.cmbAltura)
        Me.Panel3.Controls.Add(Me.chkEstado)
        Me.Panel3.Controls.Add(Me.chkAltura)
        Me.Panel3.Controls.Add(Me.cmbZona)
        Me.Panel3.Controls.Add(Me.chkZona)
        Me.Panel3.Controls.Add(Me.chktipoUbicacion)
        Me.Panel3.Controls.Add(Me.chkBodega)
        Me.Panel3.Controls.Add(Me.cmbTipo)
        Me.Panel3.Controls.Add(Me.cmbBodegas)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(835, 92)
        Me.Panel3.TabIndex = 31
        '
        'cmbEstado
        '
        Me.cmbEstado.Enabled = False
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(484, 35)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(221, 21)
        Me.cmbEstado.TabIndex = 36
        '
        'cmbAltura
        '
        Me.cmbAltura.Enabled = False
        Me.cmbAltura.FormattingEnabled = True
        Me.cmbAltura.Location = New System.Drawing.Point(484, 7)
        Me.cmbAltura.Name = "cmbAltura"
        Me.cmbAltura.Size = New System.Drawing.Size(221, 21)
        Me.cmbAltura.TabIndex = 35
        '
        'chkEstado
        '
        Me.chkEstado.AutoSize = True
        Me.chkEstado.Location = New System.Drawing.Point(395, 36)
        Me.chkEstado.Name = "chkEstado"
        Me.chkEstado.Size = New System.Drawing.Size(66, 17)
        Me.chkEstado.TabIndex = 33
        Me.chkEstado.Text = "ESTADO"
        Me.chkEstado.UseVisualStyleBackColor = True
        '
        'chkAltura
        '
        Me.chkAltura.AutoSize = True
        Me.chkAltura.Location = New System.Drawing.Point(395, 9)
        Me.chkAltura.Name = "chkAltura"
        Me.chkAltura.Size = New System.Drawing.Size(64, 17)
        Me.chkAltura.TabIndex = 32
        Me.chkAltura.Text = "ALTURA"
        Me.chkAltura.UseVisualStyleBackColor = True
        '
        'cmbZona
        '
        Me.cmbZona.Enabled = False
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(128, 61)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(221, 21)
        Me.cmbZona.TabIndex = 30
        '
        'chkZona
        '
        Me.chkZona.AutoSize = True
        Me.chkZona.Location = New System.Drawing.Point(13, 62)
        Me.chkZona.Name = "chkZona"
        Me.chkZona.Size = New System.Drawing.Size(56, 17)
        Me.chkZona.TabIndex = 29
        Me.chkZona.Text = "ZONA"
        Me.chkZona.UseVisualStyleBackColor = True
        '
        'chktipoUbicacion
        '
        Me.chktipoUbicacion.AutoSize = True
        Me.chktipoUbicacion.Location = New System.Drawing.Point(13, 36)
        Me.chktipoUbicacion.Name = "chktipoUbicacion"
        Me.chktipoUbicacion.Size = New System.Drawing.Size(111, 17)
        Me.chktipoUbicacion.TabIndex = 28
        Me.chktipoUbicacion.Text = "TIPO UBICACION"
        Me.chktipoUbicacion.UseVisualStyleBackColor = True
        '
        'chkBodega
        '
        Me.chkBodega.AutoSize = True
        Me.chkBodega.Location = New System.Drawing.Point(13, 10)
        Me.chkBodega.Name = "chkBodega"
        Me.chkBodega.Size = New System.Drawing.Size(71, 17)
        Me.chkBodega.TabIndex = 27
        Me.chkBodega.Text = "BODEGA"
        Me.chkBodega.UseVisualStyleBackColor = True
        '
        'cmbTipo
        '
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(128, 34)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(221, 21)
        Me.cmbTipo.TabIndex = 26
        '
        'cmbBodegas
        '
        Me.cmbBodegas.Enabled = False
        Me.cmbBodegas.FormattingEnabled = True
        Me.cmbBodegas.Location = New System.Drawing.Point(128, 7)
        Me.cmbBodegas.Name = "cmbBodegas"
        Me.cmbBodegas.Size = New System.Drawing.Size(221, 21)
        Me.cmbBodegas.TabIndex = 24
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 465)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(835, 22)
        Me.StatusStrip1.TabIndex = 32
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla.ColumnHeadersHeight = 25
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ubi_codigo, Me.col_bodcodigo, Me.COL_BODNOMBRE, Me.COL_CODTIPOUBICACION, Me.COL_NOMBREUBICACION, Me.COL_CODZONA, Me.COL_NOMBREZONA, Me.ALT_CODIGO, Me.ALT_NOMBRE, Me.COL_UBICACION, Me.COL_EUBCODIGO, Me.COL_EUBNOMBRE, Me.COL_ACTIVO, Me.col_abrir, Me.col_eliminar})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 148)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Grilla.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(835, 317)
        Me.Grilla.TabIndex = 47
        '
        'ubi_codigo
        '
        Me.ubi_codigo.HeaderText = "UBI_CODIGO"
        Me.ubi_codigo.Name = "ubi_codigo"
        Me.ubi_codigo.ReadOnly = True
        Me.ubi_codigo.Visible = False
        '
        'col_bodcodigo
        '
        Me.col_bodcodigo.HeaderText = "BOD_CODIGO"
        Me.col_bodcodigo.Name = "col_bodcodigo"
        Me.col_bodcodigo.ReadOnly = True
        Me.col_bodcodigo.Visible = False
        '
        'COL_BODNOMBRE
        '
        Me.COL_BODNOMBRE.HeaderText = "NOMBRE BODEGA"
        Me.COL_BODNOMBRE.Name = "COL_BODNOMBRE"
        Me.COL_BODNOMBRE.ReadOnly = True
        Me.COL_BODNOMBRE.Width = 180
        '
        'COL_CODTIPOUBICACION
        '
        Me.COL_CODTIPOUBICACION.HeaderText = "COL_CODTIPOUBICACION"
        Me.COL_CODTIPOUBICACION.Name = "COL_CODTIPOUBICACION"
        Me.COL_CODTIPOUBICACION.ReadOnly = True
        Me.COL_CODTIPOUBICACION.Visible = False
        '
        'COL_NOMBREUBICACION
        '
        Me.COL_NOMBREUBICACION.HeaderText = "T. UBICACION"
        Me.COL_NOMBREUBICACION.Name = "COL_NOMBREUBICACION"
        Me.COL_NOMBREUBICACION.ReadOnly = True
        Me.COL_NOMBREUBICACION.Width = 110
        '
        'COL_CODZONA
        '
        Me.COL_CODZONA.HeaderText = "COL_CODZONA"
        Me.COL_CODZONA.Name = "COL_CODZONA"
        Me.COL_CODZONA.ReadOnly = True
        Me.COL_CODZONA.Visible = False
        '
        'COL_NOMBREZONA
        '
        Me.COL_NOMBREZONA.HeaderText = "ZONA"
        Me.COL_NOMBREZONA.Name = "COL_NOMBREZONA"
        Me.COL_NOMBREZONA.ReadOnly = True
        Me.COL_NOMBREZONA.Width = 90
        '
        'ALT_CODIGO
        '
        Me.ALT_CODIGO.HeaderText = "ALT_CODIGO"
        Me.ALT_CODIGO.Name = "ALT_CODIGO"
        Me.ALT_CODIGO.ReadOnly = True
        Me.ALT_CODIGO.Visible = False
        '
        'ALT_NOMBRE
        '
        Me.ALT_NOMBRE.HeaderText = "ALTURA"
        Me.ALT_NOMBRE.Name = "ALT_NOMBRE"
        Me.ALT_NOMBRE.ReadOnly = True
        '
        'COL_UBICACION
        '
        Me.COL_UBICACION.HeaderText = "UBICACION"
        Me.COL_UBICACION.Name = "COL_UBICACION"
        Me.COL_UBICACION.ReadOnly = True
        '
        'COL_EUBCODIGO
        '
        Me.COL_EUBCODIGO.HeaderText = "COL_EUBCODIGO"
        Me.COL_EUBCODIGO.Name = "COL_EUBCODIGO"
        Me.COL_EUBCODIGO.ReadOnly = True
        Me.COL_EUBCODIGO.Visible = False
        '
        'COL_EUBNOMBRE
        '
        Me.COL_EUBNOMBRE.HeaderText = "ESTADO"
        Me.COL_EUBNOMBRE.Name = "COL_EUBNOMBRE"
        Me.COL_EUBNOMBRE.ReadOnly = True
        '
        'COL_ACTIVO
        '
        Me.COL_ACTIVO.HeaderText = "A"
        Me.COL_ACTIVO.Name = "COL_ACTIVO"
        Me.COL_ACTIVO.ReadOnly = True
        '
        'col_abrir
        '
        Me.col_abrir.HeaderText = ""
        Me.col_abrir.Name = "col_abrir"
        Me.col_abrir.ReadOnly = True
        Me.col_abrir.Text = "ABRIR"
        Me.col_abrir.UseColumnTextForButtonValue = True
        '
        'col_eliminar
        '
        Me.col_eliminar.HeaderText = ""
        Me.col_eliminar.Name = "col_eliminar"
        Me.col_eliminar.ReadOnly = True
        Me.col_eliminar.Text = "ELIMINAR"
        Me.col_eliminar.UseColumnTextForButtonValue = True
        '
        'frm_listado_ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 487)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_listado_ubicaciones"
        Me.Text = "LISTADO DE UBICACIONES"
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
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents cmbBodegas As ComboBox
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents cmbAltura As ComboBox
    Friend WithEvents chkEstado As CheckBox
    Friend WithEvents chkAltura As CheckBox
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents chkZona As CheckBox
    Friend WithEvents chktipoUbicacion As CheckBox
    Friend WithEvents chkBodega As CheckBox
    Friend WithEvents ubi_codigo As DataGridViewTextBoxColumn
    Friend WithEvents col_bodcodigo As DataGridViewTextBoxColumn
    Friend WithEvents COL_BODNOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_CODTIPOUBICACION As DataGridViewTextBoxColumn
    Friend WithEvents COL_NOMBREUBICACION As DataGridViewTextBoxColumn
    Friend WithEvents COL_CODZONA As DataGridViewTextBoxColumn
    Friend WithEvents COL_NOMBREZONA As DataGridViewTextBoxColumn
    Friend WithEvents ALT_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents ALT_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_UBICACION As DataGridViewTextBoxColumn
    Friend WithEvents COL_EUBCODIGO As DataGridViewTextBoxColumn
    Friend WithEvents COL_EUBNOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents COL_ACTIVO As DataGridViewCheckBoxColumn
    Friend WithEvents col_abrir As DataGridViewButtonColumn
    Friend WithEvents col_eliminar As DataGridViewButtonColumn
End Class
