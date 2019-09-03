<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visor_recepciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_visor_recepciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbAsignarA = New System.Windows.Forms.ComboBox()
        Me.lblAsignarA = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.CAR_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAR_NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUM_REC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_RECEPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colsdo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_FECHA_OC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEsRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_paletizar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Panel2.Size = New System.Drawing.Size(684, 4)
        Me.Panel2.TabIndex = 38
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(684, 25)
        Me.ToolStrip1.TabIndex = 39
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
        Me.Panel1.Size = New System.Drawing.Size(684, 4)
        Me.Panel1.TabIndex = 40
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(684, 33)
        Me.Panel4.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(349, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "VISOR DE RECEPCIÓN PENDIENTE DE ALMACENAR"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.cmbAsignarA)
        Me.Panel3.Controls.Add(Me.lblAsignarA)
        Me.Panel3.Controls.Add(Me.cmbProveedor)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(684, 35)
        Me.Panel3.TabIndex = 45
        '
        'cmbAsignarA
        '
        Me.cmbAsignarA.FormattingEnabled = True
        Me.cmbAsignarA.Location = New System.Drawing.Point(393, 6)
        Me.cmbAsignarA.Name = "cmbAsignarA"
        Me.cmbAsignarA.Size = New System.Drawing.Size(201, 21)
        Me.cmbAsignarA.TabIndex = 23
        '
        'lblAsignarA
        '
        Me.lblAsignarA.AutoSize = True
        Me.lblAsignarA.ForeColor = System.Drawing.Color.Black
        Me.lblAsignarA.Location = New System.Drawing.Point(314, 8)
        Me.lblAsignarA.Name = "lblAsignarA"
        Me.lblAsignarA.Size = New System.Drawing.Size(73, 13)
        Me.lblAsignarA.TabIndex = 22
        Me.lblAsignarA.Text = "ASIGNADO A"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(89, 6)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(201, 21)
        Me.cmbProveedor.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "PROVEEDOR"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 395)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(684, 22)
        Me.StatusStrip1.TabIndex = 46
        Me.StatusStrip1.Text = "StatusStrip1"
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CAR_CODIGO, Me.CAR_NOMBRE, Me.NUM_REC, Me.FECHA_RECEPCION, Me.colsdo, Me.COL_FECHA_OC, Me.col, Me.colEsRE, Me.Column1, Me.col_paletizar})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 101)
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
        Me.Grilla.Size = New System.Drawing.Size(684, 294)
        Me.Grilla.TabIndex = 47
        '
        'CAR_CODIGO
        '
        Me.CAR_CODIGO.HeaderText = "CAR_CODIGO"
        Me.CAR_CODIGO.Name = "CAR_CODIGO"
        Me.CAR_CODIGO.ReadOnly = True
        Me.CAR_CODIGO.Visible = False
        '
        'CAR_NOMBRE
        '
        Me.CAR_NOMBRE.HeaderText = "NOMBRE PROVEEDOR"
        Me.CAR_NOMBRE.Name = "CAR_NOMBRE"
        Me.CAR_NOMBRE.ReadOnly = True
        Me.CAR_NOMBRE.Width = 250
        '
        'NUM_REC
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NUM_REC.DefaultCellStyle = DataGridViewCellStyle2
        Me.NUM_REC.HeaderText = "N° RECEPCIÓN"
        Me.NUM_REC.Name = "NUM_REC"
        Me.NUM_REC.ReadOnly = True
        Me.NUM_REC.Width = 90
        '
        'FECHA_RECEPCION
        '
        Me.FECHA_RECEPCION.HeaderText = "FECHA REC"
        Me.FECHA_RECEPCION.Name = "FECHA_RECEPCION"
        Me.FECHA_RECEPCION.ReadOnly = True
        Me.FECHA_RECEPCION.Width = 90
        '
        'colsdo
        '
        Me.colsdo.HeaderText = "NÚMERO OC"
        Me.colsdo.Name = "colsdo"
        Me.colsdo.ReadOnly = True
        Me.colsdo.Width = 90
        '
        'COL_FECHA_OC
        '
        Me.COL_FECHA_OC.HeaderText = "FECHA OC"
        Me.COL_FECHA_OC.Name = "COL_FECHA_OC"
        Me.COL_FECHA_OC.ReadOnly = True
        '
        'col
        '
        Me.col.HeaderText = "ere_codigo"
        Me.col.Name = "col"
        Me.col.ReadOnly = True
        Me.col.Visible = False
        '
        'colEsRE
        '
        Me.colEsRE.HeaderText = "ESTADO RECEPCIÓN"
        Me.colEsRE.Name = "colEsRE"
        Me.colEsRE.ReadOnly = True
        Me.colEsRE.Width = 200
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "VER RECEPCIÓN"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 80
        '
        'col_paletizar
        '
        Me.col_paletizar.HeaderText = ""
        Me.col_paletizar.Name = "col_paletizar"
        Me.col_paletizar.ReadOnly = True
        Me.col_paletizar.Text = "ALMACENAR"
        Me.col_paletizar.UseColumnTextForButtonValue = True
        '
        'frm_visor_recepciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 417)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_visor_recepciones"
        Me.Text = "VISOR DE RECEPCIÓN PENDIENTE DE ALMACENAR"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbAsignarA As ComboBox
    Friend WithEvents lblAsignarA As Label
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents CAR_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents CAR_NOMBRE As DataGridViewTextBoxColumn
    Friend WithEvents NUM_REC As DataGridViewTextBoxColumn
    Friend WithEvents FECHA_RECEPCION As DataGridViewTextBoxColumn
    Friend WithEvents colsdo As DataGridViewTextBoxColumn
    Friend WithEvents COL_FECHA_OC As DataGridViewTextBoxColumn
    Friend WithEvents col As DataGridViewTextBoxColumn
    Friend WithEvents colEsRE As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents col_paletizar As DataGridViewButtonColumn
End Class
