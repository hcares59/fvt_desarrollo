<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_movimiento_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_movimiento_productos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ButtonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblBodega2 = New System.Windows.Forms.Label()
        Me.cmbBodega2 = New System.Windows.Forms.ComboBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.lblNumDoc = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
        Me.lblTipoDoc = New System.Windows.Forms.Label()
        Me.cmbCartera = New System.Windows.Forms.ComboBox()
        Me.lblCartera = New System.Windows.Forms.Label()
        Me.cmbBodega1 = New System.Windows.Forms.ComboBox()
        Me.lblBodega1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GrillaDetalle = New System.Windows.Forms.DataGridView()
        Me.col_fila_devu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conPRECIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GrillaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ToolStrip2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(843, 32)
        Me.Panel2.TabIndex = 5
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonGuardar, Me.ToolStripSeparator2, Me.ButtonImprimir, Me.ToolStripSeparator1, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(843, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGuardar.Image = CType(resources.GetObject("ButtonGuardar.Image"), System.Drawing.Image)
        Me.ButtonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(79, 22)
        Me.ButtonGuardar.Text = "GUARDAR"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImprimir.Image = CType(resources.GetObject("ButtonImprimir.Image"), System.Drawing.Image)
        Me.ButtonImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(76, 22)
        Me.ButtonImprimir.Text = "IMPRIMIR"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripButton2.Text = "SALIR"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(843, 23)
        Me.Panel1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MOVIMIENTOS DE PRODUCTO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblBodega2)
        Me.GroupBox1.Controls.Add(Me.cmbBodega2)
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNumDoc)
        Me.GroupBox1.Controls.Add(Me.lblNumDoc)
        Me.GroupBox1.Controls.Add(Me.cmbTipoDoc)
        Me.GroupBox1.Controls.Add(Me.lblTipoDoc)
        Me.GroupBox1.Controls.Add(Me.cmbCartera)
        Me.GroupBox1.Controls.Add(Me.lblCartera)
        Me.GroupBox1.Controls.Add(Me.cmbBodega1)
        Me.GroupBox1.Controls.Add(Me.lblBodega1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.txtFolio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(834, 142)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'lblBodega2
        '
        Me.lblBodega2.ForeColor = System.Drawing.Color.Black
        Me.lblBodega2.Location = New System.Drawing.Point(224, 46)
        Me.lblBodega2.Name = "lblBodega2"
        Me.lblBodega2.Size = New System.Drawing.Size(113, 13)
        Me.lblBodega2.TabIndex = 34
        Me.lblBodega2.Text = "BODEGA"
        Me.lblBodega2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBodega2.Visible = False
        '
        'cmbBodega2
        '
        Me.cmbBodega2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodega2.FormattingEnabled = True
        Me.cmbBodega2.Location = New System.Drawing.Point(343, 43)
        Me.cmbBodega2.Name = "cmbBodega2"
        Me.cmbBodega2.Size = New System.Drawing.Size(189, 21)
        Me.cmbBodega2.TabIndex = 33
        Me.cmbBodega2.Visible = False
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(97, 101)
        Me.txtObservacion.MaxLength = 250
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(723, 36)
        Me.txtObservacion.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "OBSERVACIONES"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(618, 69)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(95, 22)
        Me.txtNumDoc.TabIndex = 30
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumDoc
        '
        Me.lblNumDoc.AutoSize = True
        Me.lblNumDoc.ForeColor = System.Drawing.Color.Black
        Me.lblNumDoc.Location = New System.Drawing.Point(566, 72)
        Me.lblNumDoc.Name = "lblNumDoc"
        Me.lblNumDoc.Size = New System.Drawing.Size(46, 13)
        Me.lblNumDoc.TabIndex = 29
        Me.lblNumDoc.Text = "N° DOC"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.Location = New System.Drawing.Point(618, 42)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(202, 21)
        Me.cmbTipoDoc.TabIndex = 28
        '
        'lblTipoDoc
        '
        Me.lblTipoDoc.AutoSize = True
        Me.lblTipoDoc.ForeColor = System.Drawing.Color.Black
        Me.lblTipoDoc.Location = New System.Drawing.Point(555, 46)
        Me.lblTipoDoc.Name = "lblTipoDoc"
        Me.lblTipoDoc.Size = New System.Drawing.Size(57, 13)
        Me.lblTipoDoc.TabIndex = 27
        Me.lblTipoDoc.Text = "TIPO DOC"
        '
        'cmbCartera
        '
        Me.cmbCartera.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCartera.FormattingEnabled = True
        Me.cmbCartera.Location = New System.Drawing.Point(618, 15)
        Me.cmbCartera.Name = "cmbCartera"
        Me.cmbCartera.Size = New System.Drawing.Size(202, 21)
        Me.cmbCartera.TabIndex = 26
        '
        'lblCartera
        '
        Me.lblCartera.ForeColor = System.Drawing.Color.Black
        Me.lblCartera.Location = New System.Drawing.Point(540, 18)
        Me.lblCartera.Name = "lblCartera"
        Me.lblCartera.Size = New System.Drawing.Size(72, 13)
        Me.lblCartera.TabIndex = 25
        Me.lblCartera.Text = "PROVEEDOR"
        Me.lblCartera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBodega1
        '
        Me.cmbBodega1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodega1.FormattingEnabled = True
        Me.cmbBodega1.Location = New System.Drawing.Point(343, 15)
        Me.cmbBodega1.Name = "cmbBodega1"
        Me.cmbBodega1.Size = New System.Drawing.Size(189, 21)
        Me.cmbBodega1.TabIndex = 24
        '
        'lblBodega1
        '
        Me.lblBodega1.ForeColor = System.Drawing.Color.Black
        Me.lblBodega1.Location = New System.Drawing.Point(224, 18)
        Me.lblBodega1.Name = "lblBodega1"
        Me.lblBodega1.Size = New System.Drawing.Size(113, 13)
        Me.lblBodega1.TabIndex = 23
        Me.lblBodega1.Text = "BODEGA"
        Me.lblBodega1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "FECHA INGRESO"
        '
        'txtFecha
        '
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(97, 70)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(115, 22)
        Me.txtFecha.TabIndex = 21
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(97, 42)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(115, 22)
        Me.txtFolio.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(54, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "FOLIO"
        '
        'cmbTipo
        '
        Me.cmbTipo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(97, 15)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(115, 21)
        Me.cmbTipo.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "TIPO MOV"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 548)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(843, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GrillaDetalle
        '
        Me.GrillaDetalle.AllowUserToAddRows = False
        Me.GrillaDetalle.AllowUserToDeleteRows = False
        Me.GrillaDetalle.BackgroundColor = System.Drawing.Color.White
        Me.GrillaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaDetalle.ColumnHeadersHeight = 25
        Me.GrillaDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_fila_devu, Me.Column6, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn18, Me.conPRECIO, Me.colTOTAL, Me.Column1})
        Me.GrillaDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GrillaDetalle.EnableHeadersVisualStyles = False
        Me.GrillaDetalle.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaDetalle.Location = New System.Drawing.Point(0, 204)
        Me.GrillaDetalle.Name = "GrillaDetalle"
        Me.GrillaDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaDetalle.RowHeadersVisible = False
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.GrillaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GrillaDetalle.Size = New System.Drawing.Size(843, 344)
        Me.GrillaDetalle.TabIndex = 15
        '
        'col_fila_devu
        '
        Me.col_fila_devu.HeaderText = "FILA"
        Me.col_fila_devu.Name = "col_fila_devu"
        Me.col_fila_devu.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "PRO_CODIGO"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn12.HeaderText = "CODIGO INTERNO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.Width = 110
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "NOMBRE FAVATEX"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 280
        '
        'DataGridViewTextBoxColumn18
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn18.HeaderText = "CANTIDAD"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 70
        '
        'conPRECIO
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.conPRECIO.DefaultCellStyle = DataGridViewCellStyle4
        Me.conPRECIO.HeaderText = "PRECIO"
        Me.conPRECIO.Name = "conPRECIO"
        Me.conPRECIO.Width = 80
        '
        'colTOTAL
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colTOTAL.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTOTAL.HeaderText = "TOTAL"
        Me.colTOTAL.Name = "colTOTAL"
        Me.colTOTAL.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "QUITAR"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.UseColumnTextForButtonValue = True
        '
        'frm_movimiento_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 570)
        Me.Controls.Add(Me.GrillaDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_movimiento_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOVIMIENTO DE PRODUCTOS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GrillaDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ButtonGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFecha As DateTimePicker
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents lblCartera As Label
    Friend WithEvents cmbBodega1 As ComboBox
    Friend WithEvents lblBodega1 As Label
    Friend WithEvents txtNumDoc As TextBox
    Friend WithEvents lblNumDoc As Label
    Friend WithEvents cmbTipoDoc As ComboBox
    Friend WithEvents lblTipoDoc As Label
    Friend WithEvents cmbCartera As ComboBox
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents GrillaDetalle As DataGridView
    Friend WithEvents lblBodega2 As Label
    Friend WithEvents cmbBodega2 As ComboBox
    Friend WithEvents col_fila_devu As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents conPRECIO As DataGridViewTextBoxColumn
    Friend WithEvents colTOTAL As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
End Class
