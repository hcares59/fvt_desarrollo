<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ingreso_vehiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ingreso_vehiculo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonGurdar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtCapacPalletDoble = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCapacidaPal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCapaKg = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPatente = New System.Windows.Forms.TextBox()
        Me.cbmTipoVehiculo = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCapacPalletDobleSodimac = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chRequiere = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 4)
        Me.Panel1.TabIndex = 28
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonGurdar, Me.ToolStripSeparator1, Me.ButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(447, 25)
        Me.ToolStrip1.TabIndex = 29
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(64, 22)
        Me.ButtonNuevo.Text = "NUEVO"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.Panel2.Size = New System.Drawing.Size(447, 4)
        Me.Panel2.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chRequiere)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCapacPalletDobleSodimac)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.txtCapacPalletDoble)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCapacidaPal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCapaKg)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPatente)
        Me.GroupBox1.Controls.Add(Me.cbmTipoVehiculo)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(436, 181)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MANTENEDOR DE VEHICULOS"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Location = New System.Drawing.Point(102, 132)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 17)
        Me.chkActivo.TabIndex = 7
        Me.chkActivo.Text = "ACTIVO"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtCapacPalletDoble
        '
        Me.txtCapacPalletDoble.Location = New System.Drawing.Point(344, 101)
        Me.txtCapacPalletDoble.MaxLength = 6
        Me.txtCapacPalletDoble.Name = "txtCapacPalletDoble"
        Me.txtCapacPalletDoble.Size = New System.Drawing.Size(81, 22)
        Me.txtCapacPalletDoble.TabIndex = 6
        Me.txtCapacPalletDoble.Text = "0"
        Me.txtCapacPalletDoble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(184, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 14)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "CAPAC. (Pallets doble ancho)"
        '
        'txtCapacidaPal
        '
        Me.txtCapacidaPal.Location = New System.Drawing.Point(97, 101)
        Me.txtCapacidaPal.MaxLength = 6
        Me.txtCapacidaPal.Name = "txtCapacidaPal"
        Me.txtCapacidaPal.Size = New System.Drawing.Size(81, 22)
        Me.txtCapacidaPal.TabIndex = 5
        Me.txtCapacidaPal.Text = "0"
        Me.txtCapacidaPal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 14)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "CAPAC. (Pallets)"
        '
        'txtCapaKg
        '
        Me.txtCapaKg.Location = New System.Drawing.Point(344, 72)
        Me.txtCapaKg.MaxLength = 6
        Me.txtCapaKg.Name = "txtCapaKg"
        Me.txtCapaKg.Size = New System.Drawing.Size(81, 22)
        Me.txtCapaKg.TabIndex = 4
        Me.txtCapaKg.Text = "0"
        Me.txtCapaKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(208, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 23)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "CAPACIDAD EN KILOS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 23)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "PATENTE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPatente
        '
        Me.txtPatente.Location = New System.Drawing.Point(97, 73)
        Me.txtPatente.MaxLength = 6
        Me.txtPatente.Name = "txtPatente"
        Me.txtPatente.Size = New System.Drawing.Size(81, 22)
        Me.txtPatente.TabIndex = 3
        '
        'cbmTipoVehiculo
        '
        Me.cbmTipoVehiculo.FormattingEnabled = True
        Me.cbmTipoVehiculo.Location = New System.Drawing.Point(97, 46)
        Me.cbmTipoVehiculo.Name = "cbmTipoVehiculo"
        Me.cbmTipoVehiculo.Size = New System.Drawing.Size(328, 21)
        Me.cbmTipoVehiculo.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(97, 18)
        Me.txtNombre.MaxLength = 70
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(328, 22)
        Me.txtNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 23)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "TIPO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 23)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "NOMBRE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapacPalletDobleSodimac
        '
        Me.txtCapacPalletDobleSodimac.Location = New System.Drawing.Point(344, 129)
        Me.txtCapacPalletDobleSodimac.MaxLength = 6
        Me.txtCapacPalletDobleSodimac.Name = "txtCapacPalletDobleSodimac"
        Me.txtCapacPalletDobleSodimac.Size = New System.Drawing.Size(81, 22)
        Me.txtCapacPalletDobleSodimac.TabIndex = 139
        Me.txtCapacPalletDobleSodimac.Text = "0"
        Me.txtCapacPalletDobleSodimac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(184, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(154, 30)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "CAPAC. (Pallets doble ancho) SODIMAC"
        '
        'chRequiere
        '
        Me.chRequiere.AutoSize = True
        Me.chRequiere.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chRequiere.Location = New System.Drawing.Point(6, 158)
        Me.chRequiere.Name = "chRequiere"
        Me.chRequiere.Size = New System.Drawing.Size(160, 17)
        Me.chRequiere.TabIndex = 141
        Me.chRequiere.Text = "REQUIERE COMPLEMENTO"
        Me.chRequiere.UseVisualStyleBackColor = True
        '
        'frm_ingreso_vehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 221)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ingreso_vehiculo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENEDOR DE VEHICULOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonGurdar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCapacidaPal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCapaKg As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPatente As TextBox
    Friend WithEvents cbmTipoVehiculo As ComboBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents txtCapacPalletDoble As TextBox
    Friend WithEvents chRequiere As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCapacPalletDobleSodimac As TextBox
End Class
