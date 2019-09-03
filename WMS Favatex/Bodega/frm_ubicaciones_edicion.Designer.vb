<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ubicaciones_edicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ubicaciones_edicion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCapacidad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMTS3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFondo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(372, 4)
        Me.Panel1.TabIndex = 28
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(372, 25)
        Me.ToolStrip1.TabIndex = 29
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(372, 4)
        Me.Panel2.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCapacidad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbProveedor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(363, 119)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MANTENCIÓN DE UBICACIONES"
        '
        'cmbCapacidad
        '
        Me.cmbCapacidad.FormattingEnabled = True
        Me.cmbCapacidad.Location = New System.Drawing.Point(7, 90)
        Me.cmbCapacidad.Name = "cmbCapacidad"
        Me.cmbCapacidad.Size = New System.Drawing.Size(348, 21)
        Me.cmbCapacidad.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 27)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "CAPACIDAD EN PESO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbProveedor
        '
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(8, 42)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(347, 21)
        Me.cmbProveedor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 27)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "PROVEEDOR ASOCIADO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMTS3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtFondo)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtAlto)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtAncho)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 155)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(363, 95)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DIMENCIONES"
        '
        'txtMTS3
        '
        Me.txtMTS3.Location = New System.Drawing.Point(247, 54)
        Me.txtMTS3.MaxLength = 5
        Me.txtMTS3.Name = "txtMTS3"
        Me.txtMTS3.Size = New System.Drawing.Size(71, 22)
        Me.txtMTS3.TabIndex = 6
        Me.txtMTS3.Text = "0"
        Me.txtMTS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(173, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 18)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "MTS 3"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFondo
        '
        Me.txtFondo.Location = New System.Drawing.Point(247, 26)
        Me.txtFondo.MaxLength = 5
        Me.txtFondo.Name = "txtFondo"
        Me.txtFondo.Size = New System.Drawing.Size(71, 22)
        Me.txtFondo.TabIndex = 5
        Me.txtFondo.Text = "0"
        Me.txtFondo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(173, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 18)
        Me.Label21.TabIndex = 139
        Me.Label21.Text = "FONDO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAlto
        '
        Me.txtAlto.Location = New System.Drawing.Point(85, 54)
        Me.txtAlto.MaxLength = 5
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Size = New System.Drawing.Size(71, 22)
        Me.txtAlto.TabIndex = 4
        Me.txtAlto.Text = "0"
        Me.txtAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(11, 53)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 18)
        Me.Label23.TabIndex = 137
        Me.Label23.Text = "ALTO"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(85, 26)
        Me.txtAncho.MaxLength = 5
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Size = New System.Drawing.Size(71, 22)
        Me.txtAncho.TabIndex = 3
        Me.txtAncho.Text = "0"
        Me.txtAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(11, 26)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 18)
        Me.Label22.TabIndex = 135
        Me.Label22.Text = "ANCHO"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_ubicaciones_edicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 253)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ubicaciones_edicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCIÓN DE UBICACIONES"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbCapacidad As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbProveedor As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtAlto As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtAncho As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtFondo As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtMTS3 As TextBox
    Friend WithEvents Label4 As Label
End Class
