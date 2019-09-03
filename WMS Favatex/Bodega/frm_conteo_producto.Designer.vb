<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_conteo_producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_conteo_producto))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonLimpiar = New System.Windows.Forms.Button()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbx_tipubicacion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbmBodegas = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.col_fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bod_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bod_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_tubi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_uni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_codi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_bul = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_canti = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_disp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.Panel4.Size = New System.Drawing.Size(986, 4)
        Me.Panel4.TabIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonSalir, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(986, 25)
        Me.ToolStrip1.TabIndex = 41
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(986, 4)
        Me.Panel1.TabIndex = 42
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Location = New System.Drawing.Point(0, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(986, 31)
        Me.Panel3.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(353, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FORMATO DE CONTEO DE PRODUCTOS"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(986, 24)
        Me.StatusStrip1.TabIndex = 44
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotal
        '
        Me.lblTotal.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblTotal.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(124, 19)
        Me.lblTotal.Text = "ToolStripStatusLabel1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ButtonLimpiar)
        Me.Panel2.Controls.Add(Me.TxtCodigo)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cbx_tipubicacion)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cbmBodegas)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 64)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(986, 30)
        Me.Panel2.TabIndex = 45
        '
        'ButtonLimpiar
        '
        Me.ButtonLimpiar.Location = New System.Drawing.Point(738, 3)
        Me.ButtonLimpiar.Name = "ButtonLimpiar"
        Me.ButtonLimpiar.Size = New System.Drawing.Size(104, 23)
        Me.ButtonLimpiar.TabIndex = 145
        Me.ButtonLimpiar.Text = "LIMPIAR FILTROS"
        Me.ButtonLimpiar.UseVisualStyleBackColor = True
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(652, 4)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(79, 22)
        Me.TxtCodigo.TabIndex = 144
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(596, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 18)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "CODIGO"
        '
        'cbx_tipubicacion
        '
        Me.cbx_tipubicacion.FormattingEnabled = True
        Me.cbx_tipubicacion.Location = New System.Drawing.Point(393, 4)
        Me.cbx_tipubicacion.Name = "cbx_tipubicacion"
        Me.cbx_tipubicacion.Size = New System.Drawing.Size(185, 21)
        Me.cbx_tipubicacion.TabIndex = 142
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(297, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 18)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "TIPO UBICACION"
        '
        'cbmBodegas
        '
        Me.cbmBodegas.FormattingEnabled = True
        Me.cbmBodegas.Location = New System.Drawing.Point(66, 4)
        Me.cbmBodegas.Name = "cbmBodegas"
        Me.cbmBodegas.Size = New System.Drawing.Size(220, 21)
        Me.cbmBodegas.TabIndex = 140
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 18)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = "BODEGA"
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_fecha, Me.bod_codigo, Me.bod_nombre, Me.col_tubi, Me.col_uni, Me.pro_codi, Me.pro_nom, Me.pro_bul, Me.col_canti, Me.col_cantres, Me.col_disp})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 94)
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
        Me.Grilla.Size = New System.Drawing.Size(986, 346)
        Me.Grilla.TabIndex = 48
        '
        'col_fecha
        '
        Me.col_fecha.HeaderText = "FECHA"
        Me.col_fecha.Name = "col_fecha"
        Me.col_fecha.ReadOnly = True
        '
        'bod_codigo
        '
        Me.bod_codigo.HeaderText = "BOD_CODIGO"
        Me.bod_codigo.Name = "bod_codigo"
        Me.bod_codigo.ReadOnly = True
        Me.bod_codigo.Visible = False
        '
        'bod_nombre
        '
        Me.bod_nombre.HeaderText = "BODEGA"
        Me.bod_nombre.Name = "bod_nombre"
        Me.bod_nombre.ReadOnly = True
        Me.bod_nombre.Width = 190
        '
        'col_tubi
        '
        Me.col_tubi.HeaderText = "TIPO UBICACION"
        Me.col_tubi.Name = "col_tubi"
        Me.col_tubi.ReadOnly = True
        '
        'col_uni
        '
        Me.col_uni.HeaderText = "UBICACION"
        Me.col_uni.Name = "col_uni"
        Me.col_uni.ReadOnly = True
        '
        'pro_codi
        '
        Me.pro_codi.HeaderText = "CODIGO"
        Me.pro_codi.Name = "pro_codi"
        Me.pro_codi.ReadOnly = True
        '
        'pro_nom
        '
        Me.pro_nom.HeaderText = "NOMBRE PRODUCTO"
        Me.pro_nom.Name = "pro_nom"
        Me.pro_nom.ReadOnly = True
        '
        'pro_bul
        '
        Me.pro_bul.HeaderText = "BULTO"
        Me.pro_bul.Name = "pro_bul"
        Me.pro_bul.ReadOnly = True
        '
        'col_canti
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_canti.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_canti.HeaderText = "CANTIDAD"
        Me.col_canti.Name = "col_canti"
        Me.col_canti.ReadOnly = True
        '
        'col_cantres
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_cantres.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_cantres.HeaderText = "CANT. RESER."
        Me.col_cantres.Name = "col_cantres"
        Me.col_cantres.ReadOnly = True
        '
        'col_disp
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col_disp.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_disp.HeaderText = "CANT. DISPO."
        Me.col_disp.Name = "col_disp"
        Me.col_disp.ReadOnly = True
        '
        'frm_conteo_producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 464)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_conteo_producto"
        Me.Text = "FORMATO DE CONTEO DE PRODUCTOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cbx_tipubicacion As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbmBodegas As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonLimpiar As Button
    Friend WithEvents col_fecha As DataGridViewTextBoxColumn
    Friend WithEvents bod_codigo As DataGridViewTextBoxColumn
    Friend WithEvents bod_nombre As DataGridViewTextBoxColumn
    Friend WithEvents col_tubi As DataGridViewTextBoxColumn
    Friend WithEvents col_uni As DataGridViewTextBoxColumn
    Friend WithEvents pro_codi As DataGridViewTextBoxColumn
    Friend WithEvents pro_nom As DataGridViewTextBoxColumn
    Friend WithEvents pro_bul As DataGridViewTextBoxColumn
    Friend WithEvents col_canti As DataGridViewTextBoxColumn
    Friend WithEvents col_cantres As DataGridViewTextBoxColumn
    Friend WithEvents col_disp As DataGridViewTextBoxColumn
End Class
