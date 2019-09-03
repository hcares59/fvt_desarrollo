<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mant_picking_ubicaciones
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Grilla = New System.Windows.Forms.DataGridView()
        Me.col_fec_ingreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLBULTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLUBICACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLDISP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTEMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLCON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colnumbulto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.txtCantidad)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblProducto)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(765, 80)
        Me.Panel1.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(682, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 25)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(124, 53)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(50, 22)
        Me.txtCantidad.TabIndex = 4
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cantidad requerida"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.Color.White
        Me.lblProducto.Location = New System.Drawing.Point(13, 33)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblProducto.TabIndex = 2
        Me.lblProducto.Text = "Label2"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(682, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 25)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SELECCIONE UBICACIONES"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 429)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(765, 10)
        Me.Panel2.TabIndex = 1
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grilla.BackgroundColor = System.Drawing.Color.White
        Me.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Grilla.ColumnHeadersHeight = 25
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_fec_ingreso, Me.COLBULTO, Me.colPallet, Me.COLUBICACION, Me.COLDISP, Me.colTEMP, Me.COLCON, Me.colnumbulto})
        Me.Grilla.EnableHeadersVisualStyles = False
        Me.Grilla.GridColor = System.Drawing.SystemColors.HotTrack
        Me.Grilla.Location = New System.Drawing.Point(2, 84)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.Grilla.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Grilla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grilla.Size = New System.Drawing.Size(760, 339)
        Me.Grilla.TabIndex = 10
        '
        'col_fec_ingreso
        '
        Me.col_fec_ingreso.HeaderText = "FECHA DE INGRESO"
        Me.col_fec_ingreso.Name = "col_fec_ingreso"
        Me.col_fec_ingreso.ReadOnly = True
        Me.col_fec_ingreso.Width = 120
        '
        'COLBULTO
        '
        Me.COLBULTO.HeaderText = "BULTO"
        Me.COLBULTO.Name = "COLBULTO"
        Me.COLBULTO.ReadOnly = True
        Me.COLBULTO.Width = 60
        '
        'colPallet
        '
        Me.colPallet.HeaderText = "PALLET"
        Me.colPallet.Name = "colPallet"
        Me.colPallet.ReadOnly = True
        Me.colPallet.Width = 180
        '
        'COLUBICACION
        '
        Me.COLUBICACION.HeaderText = "UBICACION"
        Me.COLUBICACION.Name = "COLUBICACION"
        Me.COLUBICACION.ReadOnly = True
        Me.COLUBICACION.Width = 150
        '
        'COLDISP
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.COLDISP.DefaultCellStyle = DataGridViewCellStyle6
        Me.COLDISP.HeaderText = "DISPONIBLE"
        Me.COLDISP.Name = "COLDISP"
        Me.COLDISP.ReadOnly = True
        Me.COLDISP.Width = 80
        '
        'colTEMP
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colTEMP.DefaultCellStyle = DataGridViewCellStyle7
        Me.colTEMP.HeaderText = "TEMPORAL"
        Me.colTEMP.Name = "colTEMP"
        Me.colTEMP.ReadOnly = True
        Me.colTEMP.Width = 80
        '
        'COLCON
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.COLCON.DefaultCellStyle = DataGridViewCellStyle8
        Me.COLCON.HeaderText = "CONSUMIR"
        Me.COLCON.Name = "COLCON"
        Me.COLCON.Width = 70
        '
        'colnumbulto
        '
        Me.colnumbulto.HeaderText = "BULTO"
        Me.colnumbulto.Name = "colnumbulto"
        Me.colnumbulto.ReadOnly = True
        Me.colnumbulto.Visible = False
        Me.colnumbulto.Width = 40
        '
        'frm_mant_picking_ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(765, 439)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_mant_picking_ubicaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_mant_picking_ubicaciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Grilla As DataGridView
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblProducto As Label
    Friend WithEvents col_fec_ingreso As DataGridViewTextBoxColumn
    Friend WithEvents COLBULTO As DataGridViewTextBoxColumn
    Friend WithEvents colPallet As DataGridViewTextBoxColumn
    Friend WithEvents COLUBICACION As DataGridViewTextBoxColumn
    Friend WithEvents COLDISP As DataGridViewTextBoxColumn
    Friend WithEvents colTEMP As DataGridViewTextBoxColumn
    Friend WithEvents COLCON As DataGridViewTextBoxColumn
    Friend WithEvents colnumbulto As DataGridViewTextBoxColumn
End Class
