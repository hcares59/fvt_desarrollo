<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_movimiento_pallet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_movimiento_pallet))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSelecciona = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonDesmarcar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonImprime = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonMovimiento = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New System.Windows.Forms.ComboBox()
        Me.cmbProductos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbBodega = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.COL_SE = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_fila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRO_CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_PRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_NBU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_BUL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_SER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(740, 4)
        Me.Panel1.TabIndex = 33
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ButtonNuevo, Me.ToolStripSeparator1, Me.ButtonSelecciona, Me.ToolStripSeparator5, Me.ButtonDesmarcar, Me.ToolStripSeparator6, Me.ButtonImprime, Me.ToolStripSeparator4, Me.ButtonMovimiento, Me.ToolStripSeparator2, Me.ButtonSalir, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(740, 25)
        Me.ToolStrip1.TabIndex = 34
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator3.Visible = False
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(64, 22)
        Me.ButtonNuevo.Text = "NUEVO"
        Me.ButtonNuevo.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonSelecciona
        '
        Me.ButtonSelecciona.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSelecciona.Image = CType(resources.GetObject("ButtonSelecciona.Image"), System.Drawing.Image)
        Me.ButtonSelecciona.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSelecciona.Name = "ButtonSelecciona"
        Me.ButtonSelecciona.Size = New System.Drawing.Size(204, 22)
        Me.ButtonSelecciona.Text = "SELECCIONA TODO PARA IMPRIMIR"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonDesmarcar
        '
        Me.ButtonDesmarcar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDesmarcar.Image = CType(resources.GetObject("ButtonDesmarcar.Image"), System.Drawing.Image)
        Me.ButtonDesmarcar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDesmarcar.Name = "ButtonDesmarcar"
        Me.ButtonDesmarcar.Size = New System.Drawing.Size(125, 22)
        Me.ButtonDesmarcar.Text = "DESMARCAR TODO"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonImprime
        '
        Me.ButtonImprime.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImprime.Image = CType(resources.GetObject("ButtonImprime.Image"), System.Drawing.Image)
        Me.ButtonImprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonImprime.Name = "ButtonImprime"
        Me.ButtonImprime.Size = New System.Drawing.Size(76, 22)
        Me.ButtonImprime.Text = "IMPRIMIR"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonMovimiento
        '
        Me.ButtonMovimiento.Image = CType(resources.GetObject("ButtonMovimiento.Image"), System.Drawing.Image)
        Me.ButtonMovimiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonMovimiento.Name = "ButtonMovimiento"
        Me.ButtonMovimiento.Size = New System.Drawing.Size(141, 22)
        Me.ButtonMovimiento.Text = "GENERA MOVIMIENTO"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSalir.Image = CType(resources.GetObject("ButtonSalir.Image"), System.Drawing.Image)
        Me.ButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(55, 22)
        Me.ButtonSalir.Text = "SALIR"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(740, 4)
        Me.Panel2.TabIndex = 35
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbUbicacion)
        Me.Panel3.Controls.Add(Me.cmbProductos)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cmbBodega)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(740, 95)
        Me.Panel3.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "SELECCIONE UBICACIÓN"
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.Location = New System.Drawing.Point(190, 39)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(356, 21)
        Me.cmbUbicacion.TabIndex = 29
        '
        'cmbProductos
        '
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(190, 66)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(356, 21)
        Me.cmbProductos.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "SELECCIONE PRODUCTO"
        '
        'cmbBodega
        '
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(190, 12)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(356, 21)
        Me.cmbBodega.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE BODEGA DE PISO"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 435)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(740, 22)
        Me.StatusStrip1.TabIndex = 37
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
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_SE, Me.col_fila, Me.PRO_CODIGO, Me.col_codigo, Me.COL_PRO, Me.COL_NBU, Me.COL_BUL, Me.COL_SER, Me.COL_CANTIDAD})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(0, 128)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Grilla.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(740, 307)
        Me.Grilla.TabIndex = 49
        '
        'COL_SE
        '
        Me.COL_SE.HeaderText = "S"
        Me.COL_SE.Name = "COL_SE"
        Me.COL_SE.Width = 40
        '
        'col_fila
        '
        Me.col_fila.HeaderText = "FILA"
        Me.col_fila.Name = "col_fila"
        Me.col_fila.ReadOnly = True
        Me.col_fila.Visible = False
        '
        'PRO_CODIGO
        '
        Me.PRO_CODIGO.HeaderText = "PRO_CODIGO"
        Me.PRO_CODIGO.Name = "PRO_CODIGO"
        Me.PRO_CODIGO.ReadOnly = True
        Me.PRO_CODIGO.Visible = False
        '
        'col_codigo
        '
        Me.col_codigo.HeaderText = "CODIGO"
        Me.col_codigo.Name = "col_codigo"
        Me.col_codigo.ReadOnly = True
        '
        'COL_PRO
        '
        Me.COL_PRO.HeaderText = "PRODUCTO"
        Me.COL_PRO.Name = "COL_PRO"
        Me.COL_PRO.ReadOnly = True
        Me.COL_PRO.Width = 250
        '
        'COL_NBU
        '
        Me.COL_NBU.HeaderText = "NBULTO"
        Me.COL_NBU.Name = "COL_NBU"
        Me.COL_NBU.ReadOnly = True
        Me.COL_NBU.Visible = False
        '
        'COL_BUL
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COL_BUL.DefaultCellStyle = DataGridViewCellStyle2
        Me.COL_BUL.HeaderText = "BULTO"
        Me.COL_BUL.Name = "COL_BUL"
        Me.COL_BUL.ReadOnly = True
        Me.COL_BUL.Width = 90
        '
        'COL_SER
        '
        Me.COL_SER.HeaderText = "SERIE PALLET"
        Me.COL_SER.Name = "COL_SER"
        Me.COL_SER.ReadOnly = True
        Me.COL_SER.Width = 170
        '
        'COL_CANTIDAD
        '
        Me.COL_CANTIDAD.HeaderText = "CANTIDAD"
        Me.COL_CANTIDAD.Name = "COL_CANTIDAD"
        Me.COL_CANTIDAD.ReadOnly = True
        '
        'frm_movimiento_pallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 457)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frm_movimiento_pallet"
        Me.Text = "MOVIMIENTO DE PALLET ENTRE PISOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonImprime As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents cmbProductos As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbBodega As ComboBox
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbUbicacion As ComboBox
    Friend WithEvents ButtonDesmarcar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ButtonSelecciona As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents COL_SE As DataGridViewCheckBoxColumn
    Friend WithEvents col_fila As DataGridViewTextBoxColumn
    Friend WithEvents PRO_CODIGO As DataGridViewTextBoxColumn
    Friend WithEvents col_codigo As DataGridViewTextBoxColumn
    Friend WithEvents COL_PRO As DataGridViewTextBoxColumn
    Friend WithEvents COL_NBU As DataGridViewTextBoxColumn
    Friend WithEvents COL_BUL As DataGridViewTextBoxColumn
    Friend WithEvents COL_SER As DataGridViewTextBoxColumn
    Friend WithEvents COL_CANTIDAD As DataGridViewTextBoxColumn
    Friend WithEvents ButtonMovimiento As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
End Class
