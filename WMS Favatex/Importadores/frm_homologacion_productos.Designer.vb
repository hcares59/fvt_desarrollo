<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_homologacion_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_homologacion_productos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_carga = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.btnMarcar = New System.Windows.Forms.Button()
        Me.btnDesmarcar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_pro_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cod_int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_pro_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_sku_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombrecli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_pro_cod2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_pro_int2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nom_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_elimina_rel = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(899, 4)
        Me.Panel2.TabIndex = 40
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ButtonSalir, Me.ToolStripSeparator8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(899, 25)
        Me.ToolStrip1.TabIndex = 41
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(899, 4)
        Me.Panel1.TabIndex = 42
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
        Me.Panel4.Size = New System.Drawing.Size(899, 24)
        Me.Panel4.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "HOMOLOGACIÓN DE PRODUCTOS"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 57)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(899, 80)
        Me.Panel3.TabIndex = 46
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbCliente)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btn_carga)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(566, 72)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Selecciona cliente"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(243, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(222, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "SKU Con producto homologado"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(104, 14)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(360, 21)
        Me.cmbCliente.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(8, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "No existe el producto en la base de datos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_carga
        '
        Me.btn_carga.Location = New System.Drawing.Point(467, 13)
        Me.btn_carga.Name = "btn_carga"
        Me.btn_carga.Size = New System.Drawing.Size(86, 23)
        Me.btn_carga.TabIndex = 3
        Me.btn_carga.Text = "Carga Archivo"
        Me.btn_carga.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnRegistrar)
        Me.GroupBox1.Controls.Add(Me.btnMarcar)
        Me.GroupBox1.Controls.Add(Me.btnDesmarcar)
        Me.GroupBox1.Location = New System.Drawing.Point(579, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 72)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistrar.Location = New System.Drawing.Point(125, 13)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(146, 23)
        Me.btnRegistrar.TabIndex = 6
        Me.btnRegistrar.Text = "Registrar homologación"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'btnMarcar
        '
        Me.btnMarcar.Location = New System.Drawing.Point(7, 13)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(112, 23)
        Me.btnMarcar.TabIndex = 5
        Me.btnMarcar.Text = "Marcar todos"
        Me.btnMarcar.UseVisualStyleBackColor = True
        '
        'btnDesmarcar
        '
        Me.btnDesmarcar.Location = New System.Drawing.Point(7, 39)
        Me.btnDesmarcar.Name = "btnDesmarcar"
        Me.btnDesmarcar.Size = New System.Drawing.Size(112, 23)
        Me.btnDesmarcar.TabIndex = 4
        Me.btnDesmarcar.Text = "Desmarcar todos"
        Me.btnDesmarcar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 444)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(899, 22)
        Me.StatusStrip1.TabIndex = 48
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sel, Me.eliminar, Me.col_pro_codigo, Me.col_cod_int, Me.col_pro_nombre, Me.col_sku_cliente, Me.col_nombrecli, Me.col_pro_cod2, Me.col_pro_int2, Me.col_nom_2, Me.col_elimina_rel})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 137)
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
        Me.Grilla.Size = New System.Drawing.Size(899, 307)
        Me.Grilla.TabIndex = 49
        '
        'sel
        '
        Me.sel.HeaderText = "sel"
        Me.sel.Name = "sel"
        Me.sel.ReadOnly = True
        Me.sel.Width = 27
        '
        'eliminar
        '
        Me.eliminar.HeaderText = ""
        Me.eliminar.Name = "eliminar"
        Me.eliminar.ReadOnly = True
        Me.eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.eliminar.Text = "Elimina"
        Me.eliminar.UseColumnTextForButtonValue = True
        Me.eliminar.Width = 19
        '
        'col_pro_codigo
        '
        Me.col_pro_codigo.HeaderText = "pro_codigo"
        Me.col_pro_codigo.Name = "col_pro_codigo"
        Me.col_pro_codigo.ReadOnly = True
        Me.col_pro_codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_pro_codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_pro_codigo.Visible = False
        Me.col_pro_codigo.Width = 72
        '
        'col_cod_int
        '
        Me.col_cod_int.HeaderText = "Código"
        Me.col_cod_int.Name = "col_cod_int"
        Me.col_cod_int.ReadOnly = True
        Me.col_cod_int.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_cod_int.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_cod_int.Width = 51
        '
        'col_pro_nombre
        '
        Me.col_pro_nombre.HeaderText = "Nombre Favatex"
        Me.col_pro_nombre.Name = "col_pro_nombre"
        Me.col_pro_nombre.ReadOnly = True
        Me.col_pro_nombre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_pro_nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_pro_nombre.Width = 95
        '
        'col_sku_cliente
        '
        Me.col_sku_cliente.HeaderText = "SKU Cliente"
        Me.col_sku_cliente.Name = "col_sku_cliente"
        Me.col_sku_cliente.ReadOnly = True
        Me.col_sku_cliente.Width = 91
        '
        'col_nombrecli
        '
        Me.col_nombrecli.HeaderText = "SKU Cliente"
        Me.col_nombrecli.Name = "col_nombrecli"
        Me.col_nombrecli.ReadOnly = True
        Me.col_nombrecli.Width = 91
        '
        'col_pro_cod2
        '
        Me.col_pro_cod2.HeaderText = "pro_codigo2"
        Me.col_pro_cod2.Name = "col_pro_cod2"
        Me.col_pro_cod2.ReadOnly = True
        Me.col_pro_cod2.Visible = False
        Me.col_pro_cod2.Width = 97
        '
        'col_pro_int2
        '
        Me.col_pro_int2.HeaderText = "Codigo Relacionado"
        Me.col_pro_int2.Name = "col_pro_int2"
        Me.col_pro_int2.ReadOnly = True
        Me.col_pro_int2.Width = 137
        '
        'col_nom_2
        '
        Me.col_nom_2.HeaderText = "Nombre Favatex relacionado"
        Me.col_nom_2.Name = "col_nom_2"
        Me.col_nom_2.ReadOnly = True
        Me.col_nom_2.Width = 178
        '
        'col_elimina_rel
        '
        Me.col_elimina_rel.HeaderText = ""
        Me.col_elimina_rel.Name = "col_elimina_rel"
        Me.col_elimina_rel.ReadOnly = True
        Me.col_elimina_rel.Text = "Elimina homolohación"
        Me.col_elimina_rel.UseColumnTextForButtonValue = True
        Me.col_elimina_rel.Visible = False
        Me.col_elimina_rel.Width = 5
        '
        'frm_homologacion_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 466)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_homologacion_productos"
        Me.Text = "HOMOLOGACIÓN DE PRODUCTOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn_carga As Button
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnDesmarcar As Button
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents btnMarcar As Button
    Friend WithEvents sel As DataGridViewCheckBoxColumn
    Friend WithEvents eliminar As DataGridViewButtonColumn
    Friend WithEvents col_pro_codigo As DataGridViewTextBoxColumn
    Friend WithEvents col_cod_int As DataGridViewTextBoxColumn
    Friend WithEvents col_pro_nombre As DataGridViewTextBoxColumn
    Friend WithEvents col_sku_cliente As DataGridViewTextBoxColumn
    Friend WithEvents col_nombrecli As DataGridViewTextBoxColumn
    Friend WithEvents col_pro_cod2 As DataGridViewTextBoxColumn
    Friend WithEvents col_pro_int2 As DataGridViewTextBoxColumn
    Friend WithEvents col_nom_2 As DataGridViewTextBoxColumn
    Friend WithEvents col_elimina_rel As DataGridViewButtonColumn
End Class
