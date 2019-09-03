<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ubicacion_asocia_producto_bulto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ubicacion_asocia_producto_bulto))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDetalle = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblSinRelacionar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GrillaSinAsoc = New System.Windows.Forms.DataGridView()
        Me.pro_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_pro_bul = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.lblConRelacionar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GrillaConAsoc = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_bul = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_deselecciona = New System.Windows.Forms.Button()
        Me.btn_selecciona = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.GrillaSinAsoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        CType(Me.GrillaConAsoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(789, 4)
        Me.Panel2.TabIndex = 41
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(789, 25)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(789, 4)
        Me.Panel1.TabIndex = 43
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDetalle)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(801, 44)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        '
        'lblDetalle
        '
        Me.lblDetalle.Location = New System.Drawing.Point(5, 13)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(609, 23)
        Me.lblDetalle.TabIndex = 61
        Me.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonBuscar)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.StatusStrip1)
        Me.GroupBox2.Controls.Add(Me.GrillaSinAsoc)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 400)
        Me.GroupBox2.TabIndex = 125
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Proveedores sin asociar"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(231, 18)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 24)
        Me.ButtonBuscar.TabIndex = 128
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(126, 19)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigo.TabIndex = 127
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Selecciona producto"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSinRelacionar})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 375)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(362, 22)
        Me.StatusStrip1.TabIndex = 125
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblSinRelacionar
        '
        Me.lblSinRelacionar.Name = "lblSinRelacionar"
        Me.lblSinRelacionar.Size = New System.Drawing.Size(0, 17)
        '
        'GrillaSinAsoc
        '
        Me.GrillaSinAsoc.AllowUserToAddRows = False
        Me.GrillaSinAsoc.AllowUserToDeleteRows = False
        Me.GrillaSinAsoc.BackgroundColor = System.Drawing.Color.White
        Me.GrillaSinAsoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaSinAsoc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaSinAsoc.ColumnHeadersHeight = 25
        Me.GrillaSinAsoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pro_codigo, Me.pro_seleccion, Me.col_prod, Me.col_pro_bul})
        Me.GrillaSinAsoc.EnableHeadersVisualStyles = False
        Me.GrillaSinAsoc.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaSinAsoc.Location = New System.Drawing.Point(8, 47)
        Me.GrillaSinAsoc.Name = "GrillaSinAsoc"
        Me.GrillaSinAsoc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaSinAsoc.RowHeadersVisible = False
        Me.GrillaSinAsoc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaSinAsoc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaSinAsoc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaSinAsoc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaSinAsoc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaSinAsoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaSinAsoc.Size = New System.Drawing.Size(352, 325)
        Me.GrillaSinAsoc.TabIndex = 122
        '
        'pro_codigo
        '
        Me.pro_codigo.HeaderText = "pro_codigo"
        Me.pro_codigo.Name = "pro_codigo"
        Me.pro_codigo.Visible = False
        '
        'pro_seleccion
        '
        Me.pro_seleccion.HeaderText = "S"
        Me.pro_seleccion.Name = "pro_seleccion"
        Me.pro_seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pro_seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.pro_seleccion.Width = 30
        '
        'col_prod
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.col_prod.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_prod.HeaderText = "Código"
        Me.col_prod.Name = "col_prod"
        '
        'col_pro_bul
        '
        Me.col_pro_bul.HeaderText = "Bulto"
        Me.col_pro_bul.Name = "col_pro_bul"
        Me.col_pro_bul.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.StatusStrip2)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.GrillaConAsoc)
        Me.GroupBox3.Location = New System.Drawing.Point(416, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(368, 400)
        Me.GroupBox3.TabIndex = 136
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Proveedores sin asociar"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblConRelacionar})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 375)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(362, 22)
        Me.StatusStrip2.TabIndex = 125
        '
        'lblConRelacionar
        '
        Me.lblConRelacionar.Name = "lblConRelacionar"
        Me.lblConRelacionar.Size = New System.Drawing.Size(0, 17)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(97, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 124
        Me.Button1.Text = "Desmarcar todos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(8, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 23)
        Me.Button2.TabIndex = 123
        Me.Button2.Text = "Marcar todos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GrillaConAsoc
        '
        Me.GrillaConAsoc.AllowUserToAddRows = False
        Me.GrillaConAsoc.AllowUserToDeleteRows = False
        Me.GrillaConAsoc.BackgroundColor = System.Drawing.Color.White
        Me.GrillaConAsoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaConAsoc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GrillaConAsoc.ColumnHeadersHeight = 25
        Me.GrillaConAsoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.col_bul})
        Me.GrillaConAsoc.EnableHeadersVisualStyles = False
        Me.GrillaConAsoc.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaConAsoc.Location = New System.Drawing.Point(8, 47)
        Me.GrillaConAsoc.Name = "GrillaConAsoc"
        Me.GrillaConAsoc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaConAsoc.RowHeadersVisible = False
        Me.GrillaConAsoc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaConAsoc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaConAsoc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaConAsoc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaConAsoc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaConAsoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaConAsoc.Size = New System.Drawing.Size(352, 326)
        Me.GrillaConAsoc.TabIndex = 122
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "pro_codigo"
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'col_bul
        '
        Me.col_bul.HeaderText = "Bulto"
        Me.col_bul.Name = "col_bul"
        Me.col_bul.ReadOnly = True
        '
        'btn_deselecciona
        '
        Me.btn_deselecciona.Location = New System.Drawing.Point(380, 243)
        Me.btn_deselecciona.Name = "btn_deselecciona"
        Me.btn_deselecciona.Size = New System.Drawing.Size(31, 25)
        Me.btn_deselecciona.TabIndex = 139
        Me.btn_deselecciona.Text = "<<"
        Me.btn_deselecciona.UseVisualStyleBackColor = True
        '
        'btn_selecciona
        '
        Me.btn_selecciona.Location = New System.Drawing.Point(380, 212)
        Me.btn_selecciona.Name = "btn_selecciona"
        Me.btn_selecciona.Size = New System.Drawing.Size(31, 25)
        Me.btn_selecciona.TabIndex = 138
        Me.btn_selecciona.Text = ">>"
        Me.btn_selecciona.UseVisualStyleBackColor = True
        '
        'frm_ubicacion_asocia_producto_bulto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 480)
        Me.Controls.Add(Me.btn_deselecciona)
        Me.Controls.Add(Me.btn_selecciona)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ubicacion_asocia_producto_bulto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UBICACIÓN ASOCIA A BULTO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.GrillaSinAsoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        CType(Me.GrillaConAsoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblDetalle As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblSinRelacionar As ToolStripStatusLabel
    Friend WithEvents GrillaSinAsoc As DataGridView
    Friend WithEvents pro_codigo As DataGridViewTextBoxColumn
    Friend WithEvents pro_seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents col_prod As DataGridViewTextBoxColumn
    Friend WithEvents col_pro_bul As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents lblConRelacionar As ToolStripStatusLabel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GrillaConAsoc As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents col_bul As DataGridViewTextBoxColumn
    Friend WithEvents btn_deselecciona As Button
    Friend WithEvents btn_selecciona As Button
End Class
