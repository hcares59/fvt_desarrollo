<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_productos_muestra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_productos_muestra))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonImprime = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GrillaDetalle = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colpronom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprocantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprocantidadm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBulUni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotBul = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colfila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNumRec = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtNumTraspaso = New System.Windows.Forms.TextBox()
        Me.lblNumTraspaso = New System.Windows.Forms.Label()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.lblZona = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GrillaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(682, 4)
        Me.Panel1.TabIndex = 31
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonImprime, Me.ToolStripSeparator4, Me.ButtonSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(682, 25)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonGurdar
        '
        Me.ButtonGurdar.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGurdar.Image = CType(resources.GetObject("ButtonGurdar.Image"), System.Drawing.Image)
        Me.ButtonGurdar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonGurdar.Name = "ButtonGurdar"
        Me.ButtonGurdar.Size = New System.Drawing.Size(80, 22)
        Me.ButtonGurdar.Text = "GUARDAR"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonImprime
        '
        Me.ButtonImprime.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImprime.Image = CType(resources.GetObject("ButtonImprime.Image"), System.Drawing.Image)
        Me.ButtonImprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonImprime.Name = "ButtonImprime"
        Me.ButtonImprime.Size = New System.Drawing.Size(81, 22)
        Me.ButtonImprime.Text = "IMPRIMIR"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSalir.Image = CType(resources.GetObject("ButtonSalir.Image"), System.Drawing.Image)
        Me.ButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(57, 22)
        Me.ButtonSalir.Text = "SALIR"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(682, 4)
        Me.Panel2.TabIndex = 33
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 437)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(682, 22)
        Me.StatusStrip1.TabIndex = 35
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GrillaDetalle
        '
        Me.GrillaDetalle.AllowUserToAddRows = False
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
        Me.GrillaDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.colCodInt, Me.colpronom, Me.colprocantidad, Me.colprocantidadm, Me.colBulUni, Me.colTotBul, Me.colfila})
        Me.GrillaDetalle.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.GrillaDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaDetalle.EnableHeadersVisualStyles = False
        Me.GrillaDetalle.GridColor = System.Drawing.SystemColors.HotTrack
        Me.GrillaDetalle.Location = New System.Drawing.Point(0, 94)
        Me.GrillaDetalle.Name = "GrillaDetalle"
        Me.GrillaDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.GrillaDetalle.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaDetalle.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.GrillaDetalle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.GrillaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaDetalle.Size = New System.Drawing.Size(682, 343)
        Me.GrillaDetalle.TabIndex = 57
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "pro_codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'colCodInt
        '
        Me.colCodInt.HeaderText = "CÓDIGO"
        Me.colCodInt.Name = "colCodInt"
        Me.colCodInt.ReadOnly = True
        Me.colCodInt.Width = 80
        '
        'colpronom
        '
        Me.colpronom.HeaderText = "NOMBRE"
        Me.colpronom.Name = "colpronom"
        Me.colpronom.ReadOnly = True
        Me.colpronom.Width = 350
        '
        'colprocantidad
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colprocantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.colprocantidad.HeaderText = "CANTIDAD"
        Me.colprocantidad.Name = "colprocantidad"
        Me.colprocantidad.ReadOnly = True
        Me.colprocantidad.Width = 70
        '
        'colprocantidadm
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colprocantidadm.DefaultCellStyle = DataGridViewCellStyle3
        Me.colprocantidadm.HeaderText = "CANT MUESTRA"
        Me.colprocantidadm.Name = "colprocantidadm"
        Me.colprocantidadm.Width = 95
        '
        'colBulUni
        '
        Me.colBulUni.HeaderText = "bulUni"
        Me.colBulUni.Name = "colBulUni"
        Me.colBulUni.ReadOnly = True
        Me.colBulUni.Visible = False
        '
        'colTotBul
        '
        Me.colTotBul.HeaderText = "TotBul"
        Me.colTotBul.Name = "colTotBul"
        Me.colTotBul.ReadOnly = True
        Me.colTotBul.Visible = False
        '
        'colfila
        '
        Me.colfila.HeaderText = "fila"
        Me.colfila.Name = "colfila"
        Me.colfila.ReadOnly = True
        Me.colfila.Visible = False
        '
        'lblNumRec
        '
        Me.lblNumRec.AutoSize = True
        Me.lblNumRec.Location = New System.Drawing.Point(13, 9)
        Me.lblNumRec.Name = "lblNumRec"
        Me.lblNumRec.Size = New System.Drawing.Size(10, 13)
        Me.lblNumRec.TabIndex = 0
        Me.lblNumRec.Text = "."
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(12, 31)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(10, 13)
        Me.lblProveedor.TabIndex = 2
        Me.lblProveedor.Text = "."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.txtNumTraspaso)
        Me.Panel3.Controls.Add(Me.lblNumTraspaso)
        Me.Panel3.Controls.Add(Me.cmbZona)
        Me.Panel3.Controls.Add(Me.lblZona)
        Me.Panel3.Controls.Add(Me.lblProveedor)
        Me.Panel3.Controls.Add(Me.lblNumRec)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(682, 61)
        Me.Panel3.TabIndex = 34
        '
        'txtNumTraspaso
        '
        Me.txtNumTraspaso.Location = New System.Drawing.Point(508, 31)
        Me.txtNumTraspaso.Name = "txtNumTraspaso"
        Me.txtNumTraspaso.Size = New System.Drawing.Size(167, 22)
        Me.txtNumTraspaso.TabIndex = 7
        Me.txtNumTraspaso.Visible = False
        '
        'lblNumTraspaso
        '
        Me.lblNumTraspaso.AutoSize = True
        Me.lblNumTraspaso.Location = New System.Drawing.Point(355, 35)
        Me.lblNumTraspaso.Name = "lblNumTraspaso"
        Me.lblNumTraspaso.Size = New System.Drawing.Size(147, 13)
        Me.lblNumTraspaso.TabIndex = 6
        Me.lblNumTraspaso.Text = "N° TRASPASO DE MANAGER"
        Me.lblNumTraspaso.Visible = False
        '
        'cmbZona
        '
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(508, 6)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(167, 21)
        Me.cmbZona.TabIndex = 5
        Me.cmbZona.Visible = False
        '
        'lblZona
        '
        Me.lblZona.AutoSize = True
        Me.lblZona.Location = New System.Drawing.Point(400, 9)
        Me.lblZona.Name = "lblZona"
        Me.lblZona.Size = New System.Drawing.Size(103, 13)
        Me.lblZona.TabIndex = 3
        Me.lblZona.Text = "SELECCIONE ZONA"
        Me.lblZona.Visible = False
        '
        'frm_productos_muestra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 459)
        Me.Controls.Add(Me.GrillaDetalle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_productos_muestra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRODUCTOS PARA MUESTRAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GrillaDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonImprime As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents GrillaDetalle As DataGridView
    Friend WithEvents lblNumRec As Label
    Friend WithEvents lblProveedor As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblZona As Label
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents txtNumTraspaso As TextBox
    Friend WithEvents lblNumTraspaso As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents colCodInt As DataGridViewTextBoxColumn
    Friend WithEvents colpronom As DataGridViewTextBoxColumn
    Friend WithEvents colprocantidad As DataGridViewTextBoxColumn
    Friend WithEvents colprocantidadm As DataGridViewTextBoxColumn
    Friend WithEvents colBulUni As DataGridViewTextBoxColumn
    Friend WithEvents colTotBul As DataGridViewTextBoxColumn
    Friend WithEvents colfila As DataGridViewTextBoxColumn
End Class
