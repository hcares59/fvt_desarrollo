<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_asocia_producto_de_reemplazo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_asocia_producto_de_reemplazo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbmProductos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbCategoria2 = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblSinRelacionar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ButtonSDesmarcar = New System.Windows.Forms.Button()
        Me.ButtonSMarcar = New System.Windows.Forms.Button()
        Me.GrillaSinInc = New System.Windows.Forms.DataGridView()
        Me.bu_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pro_codint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.lblRelacionados = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ButtonADesmarcar = New System.Windows.Forms.Button()
        Me.ButtonAMarcar = New System.Windows.Forms.Button()
        Me.GrillaConInc = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_deselecciona = New System.Windows.Forms.Button()
        Me.btn_selecciona = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.GrillaSinInc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        CType(Me.GrillaConInc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(934, 4)
        Me.Panel1.TabIndex = 32
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(934, 25)
        Me.ToolStrip1.TabIndex = 33
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me.Panel2.Size = New System.Drawing.Size(934, 4)
        Me.Panel2.TabIndex = 34
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbmProductos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCategoria)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(925, 69)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        '
        'cbmProductos
        '
        Me.cbmProductos.FormattingEnabled = True
        Me.cbmProductos.Location = New System.Drawing.Point(144, 40)
        Me.cbmProductos.Name = "cbmProductos"
        Me.cbmProductos.Size = New System.Drawing.Size(310, 21)
        Me.cbmProductos.TabIndex = 128
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "SELECCIONE PRODUCTO"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(144, 14)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(310, 21)
        Me.cmbCategoria.TabIndex = 126
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE CATEGORÍA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbCategoria2)
        Me.GroupBox2.Controls.Add(Me.StatusStrip1)
        Me.GroupBox2.Controls.Add(Me.ButtonSDesmarcar)
        Me.GroupBox2.Controls.Add(Me.ButtonSMarcar)
        Me.GroupBox2.Controls.Add(Me.GrillaSinInc)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(442, 438)
        Me.GroupBox2.TabIndex = 123
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos sin asociar"
        '
        'cmbCategoria2
        '
        Me.cmbCategoria2.FormattingEnabled = True
        Me.cmbCategoria2.Location = New System.Drawing.Point(214, 18)
        Me.cmbCategoria2.Name = "cmbCategoria2"
        Me.cmbCategoria2.Size = New System.Drawing.Size(222, 21)
        Me.cmbCategoria2.TabIndex = 127
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSinRelacionar})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 413)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(436, 22)
        Me.StatusStrip1.TabIndex = 125
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblSinRelacionar
        '
        Me.lblSinRelacionar.Name = "lblSinRelacionar"
        Me.lblSinRelacionar.Size = New System.Drawing.Size(120, 17)
        Me.lblSinRelacionar.Text = "ToolStripStatusLabel1"
        '
        'ButtonSDesmarcar
        '
        Me.ButtonSDesmarcar.Location = New System.Drawing.Point(97, 18)
        Me.ButtonSDesmarcar.Name = "ButtonSDesmarcar"
        Me.ButtonSDesmarcar.Size = New System.Drawing.Size(111, 23)
        Me.ButtonSDesmarcar.TabIndex = 124
        Me.ButtonSDesmarcar.Text = "Desmarcar todos"
        Me.ButtonSDesmarcar.UseVisualStyleBackColor = True
        '
        'ButtonSMarcar
        '
        Me.ButtonSMarcar.Location = New System.Drawing.Point(8, 18)
        Me.ButtonSMarcar.Name = "ButtonSMarcar"
        Me.ButtonSMarcar.Size = New System.Drawing.Size(86, 23)
        Me.ButtonSMarcar.TabIndex = 123
        Me.ButtonSMarcar.Text = "Marcar todos"
        Me.ButtonSMarcar.UseVisualStyleBackColor = True
        '
        'GrillaSinInc
        '
        Me.GrillaSinInc.AllowUserToAddRows = False
        Me.GrillaSinInc.AllowUserToDeleteRows = False
        Me.GrillaSinInc.BackgroundColor = System.Drawing.Color.White
        Me.GrillaSinInc.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaSinInc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaSinInc.ColumnHeadersHeight = 25
        Me.GrillaSinInc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bu_codigo, Me.pro_seleccion, Me.pro_codint, Me.pro_nombre})
        Me.GrillaSinInc.EnableHeadersVisualStyles = False
        Me.GrillaSinInc.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaSinInc.Location = New System.Drawing.Point(8, 47)
        Me.GrillaSinInc.Name = "GrillaSinInc"
        Me.GrillaSinInc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaSinInc.RowHeadersVisible = False
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaSinInc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaSinInc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaSinInc.Size = New System.Drawing.Size(426, 383)
        Me.GrillaSinInc.TabIndex = 122
        '
        'bu_codigo
        '
        Me.bu_codigo.HeaderText = "pro_codigo"
        Me.bu_codigo.Name = "bu_codigo"
        Me.bu_codigo.Visible = False
        '
        'pro_seleccion
        '
        Me.pro_seleccion.HeaderText = "S"
        Me.pro_seleccion.Name = "pro_seleccion"
        Me.pro_seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pro_seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.pro_seleccion.Width = 30
        '
        'pro_codint
        '
        Me.pro_codint.HeaderText = "CODIGO"
        Me.pro_codint.Name = "pro_codint"
        Me.pro_codint.Width = 75
        '
        'pro_nombre
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.pro_nombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.pro_nombre.HeaderText = "PRODUCTO"
        Me.pro_nombre.Name = "pro_nombre"
        Me.pro_nombre.Width = 300
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.StatusStrip2)
        Me.GroupBox3.Controls.Add(Me.ButtonADesmarcar)
        Me.GroupBox3.Controls.Add(Me.ButtonAMarcar)
        Me.GroupBox3.Controls.Add(Me.GrillaConInc)
        Me.GroupBox3.Location = New System.Drawing.Point(487, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(442, 438)
        Me.GroupBox3.TabIndex = 124
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Productos asociados"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblRelacionados})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 413)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(436, 22)
        Me.StatusStrip2.TabIndex = 132
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'lblRelacionados
        '
        Me.lblRelacionados.Name = "lblRelacionados"
        Me.lblRelacionados.Size = New System.Drawing.Size(120, 17)
        Me.lblRelacionados.Text = "ToolStripStatusLabel1"
        '
        'ButtonADesmarcar
        '
        Me.ButtonADesmarcar.Location = New System.Drawing.Point(95, 18)
        Me.ButtonADesmarcar.Name = "ButtonADesmarcar"
        Me.ButtonADesmarcar.Size = New System.Drawing.Size(111, 23)
        Me.ButtonADesmarcar.TabIndex = 131
        Me.ButtonADesmarcar.Text = "Desmarcar todos"
        Me.ButtonADesmarcar.UseVisualStyleBackColor = True
        '
        'ButtonAMarcar
        '
        Me.ButtonAMarcar.Location = New System.Drawing.Point(6, 18)
        Me.ButtonAMarcar.Name = "ButtonAMarcar"
        Me.ButtonAMarcar.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAMarcar.TabIndex = 130
        Me.ButtonAMarcar.Text = "Marcar todos"
        Me.ButtonAMarcar.UseVisualStyleBackColor = True
        '
        'GrillaConInc
        '
        Me.GrillaConInc.AllowUserToAddRows = False
        Me.GrillaConInc.AllowUserToDeleteRows = False
        Me.GrillaConInc.BackgroundColor = System.Drawing.Color.White
        Me.GrillaConInc.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaConInc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.GrillaConInc.ColumnHeadersHeight = 25
        Me.GrillaConInc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.GrillaConInc.EnableHeadersVisualStyles = False
        Me.GrillaConInc.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaConInc.Location = New System.Drawing.Point(6, 47)
        Me.GrillaConInc.Name = "GrillaConInc"
        Me.GrillaConInc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaConInc.RowHeadersVisible = False
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaConInc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaConInc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaConInc.Size = New System.Drawing.Size(426, 383)
        Me.GrillaConInc.TabIndex = 129
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
        Me.DataGridViewTextBoxColumn2.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 75
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'btn_deselecciona
        '
        Me.btn_deselecciona.Location = New System.Drawing.Point(452, 276)
        Me.btn_deselecciona.Name = "btn_deselecciona"
        Me.btn_deselecciona.Size = New System.Drawing.Size(31, 25)
        Me.btn_deselecciona.TabIndex = 133
        Me.btn_deselecciona.Text = "<<"
        Me.btn_deselecciona.UseVisualStyleBackColor = True
        '
        'btn_selecciona
        '
        Me.btn_selecciona.Location = New System.Drawing.Point(452, 245)
        Me.btn_selecciona.Name = "btn_selecciona"
        Me.btn_selecciona.Size = New System.Drawing.Size(31, 25)
        Me.btn_selecciona.TabIndex = 132
        Me.btn_selecciona.Text = ">>"
        Me.btn_selecciona.UseVisualStyleBackColor = True
        '
        'frm_asocia_producto_de_reemplazo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 547)
        Me.Controls.Add(Me.btn_deselecciona)
        Me.Controls.Add(Me.btn_selecciona)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_asocia_producto_de_reemplazo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASOCIA PRODUCTOS DE REEMPLAZO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.GrillaSinInc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        CType(Me.GrillaConInc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbmProductos As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblSinRelacionar As ToolStripStatusLabel
    Friend WithEvents ButtonSDesmarcar As Button
    Friend WithEvents ButtonSMarcar As Button
    Friend WithEvents GrillaSinInc As DataGridView
    Friend WithEvents bu_codigo As DataGridViewTextBoxColumn
    Friend WithEvents pro_seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents pro_codint As DataGridViewTextBoxColumn
    Friend WithEvents pro_nombre As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents lblRelacionados As ToolStripStatusLabel
    Friend WithEvents ButtonADesmarcar As Button
    Friend WithEvents ButtonAMarcar As Button
    Friend WithEvents GrillaConInc As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents btn_deselecciona As Button
    Friend WithEvents btn_selecciona As Button
    Friend WithEvents cmbCategoria2 As ComboBox
End Class
