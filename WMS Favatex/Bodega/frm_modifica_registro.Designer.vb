<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modifica_registro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_modifica_registro))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpDistintoPallet = New System.Windows.Forms.GroupBox()
        Me.lblBulto = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.cmbPallet = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkPallet = New System.Windows.Forms.CheckBox()
        Me.chkCantidad = New System.Windows.Forms.CheckBox()
        Me.grpDistintaCantidad = New System.Windows.Forms.GroupBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBultoCantidad = New System.Windows.Forms.Label()
        Me.lblNombreCant = New System.Windows.Forms.Label()
        Me.lblCodigoCant = New System.Windows.Forms.Label()
        Me.cmbPalletCantidad = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.grpDistintoPallet.SuspendLayout()
        Me.grpDistintaCantidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(570, 4)
        Me.Panel2.TabIndex = 41
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonNuevo, Me.ToolStripSeparator2, Me.ButtonSalir, Me.ToolStripSeparator8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(570, 25)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(79, 22)
        Me.ButtonNuevo.Text = "GUARDAR"
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
        Me.Panel1.Size = New System.Drawing.Size(570, 4)
        Me.Panel1.TabIndex = 43
        '
        'grpDistintoPallet
        '
        Me.grpDistintoPallet.Controls.Add(Me.lblBulto)
        Me.grpDistintoPallet.Controls.Add(Me.lblNombre)
        Me.grpDistintoPallet.Controls.Add(Me.lblCodigo)
        Me.grpDistintoPallet.Controls.Add(Me.cmbPallet)
        Me.grpDistintoPallet.Controls.Add(Me.Label1)
        Me.grpDistintoPallet.Enabled = False
        Me.grpDistintoPallet.Location = New System.Drawing.Point(12, 51)
        Me.grpDistintoPallet.Name = "grpDistintoPallet"
        Me.grpDistintoPallet.Size = New System.Drawing.Size(272, 192)
        Me.grpDistintoPallet.TabIndex = 44
        Me.grpDistintoPallet.TabStop = False
        '
        'lblBulto
        '
        Me.lblBulto.AutoSize = True
        Me.lblBulto.Location = New System.Drawing.Point(12, 137)
        Me.lblBulto.Name = "lblBulto"
        Me.lblBulto.Size = New System.Drawing.Size(11, 13)
        Me.lblBulto.TabIndex = 28
        Me.lblBulto.Text = "-"
        '
        'lblNombre
        '
        Me.lblNombre.Location = New System.Drawing.Point(12, 82)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(250, 46)
        Me.lblNombre.TabIndex = 27
        Me.lblNombre.Text = "-"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(12, 60)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(11, 13)
        Me.lblCodigo.TabIndex = 26
        Me.lblCodigo.Text = "-"
        '
        'cmbPallet
        '
        Me.cmbPallet.FormattingEnabled = True
        Me.cmbPallet.Location = New System.Drawing.Point(11, 32)
        Me.cmbPallet.Name = "cmbPallet"
        Me.cmbPallet.Size = New System.Drawing.Size(254, 21)
        Me.cmbPallet.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione pallet"
        '
        'chkPallet
        '
        Me.chkPallet.AutoSize = True
        Me.chkPallet.Location = New System.Drawing.Point(12, 39)
        Me.chkPallet.Name = "chkPallet"
        Me.chkPallet.Size = New System.Drawing.Size(99, 17)
        Me.chkPallet.TabIndex = 45
        Me.chkPallet.Text = "Distinto pallet"
        Me.chkPallet.UseVisualStyleBackColor = True
        '
        'chkCantidad
        '
        Me.chkCantidad.AutoSize = True
        Me.chkCantidad.Location = New System.Drawing.Point(290, 39)
        Me.chkCantidad.Name = "chkCantidad"
        Me.chkCantidad.Size = New System.Drawing.Size(115, 17)
        Me.chkCantidad.TabIndex = 46
        Me.chkCantidad.Text = "Distinto cantidad"
        Me.chkCantidad.UseVisualStyleBackColor = True
        '
        'grpDistintaCantidad
        '
        Me.grpDistintaCantidad.Controls.Add(Me.txtCantidad)
        Me.grpDistintaCantidad.Controls.Add(Me.Label2)
        Me.grpDistintaCantidad.Controls.Add(Me.lblBultoCantidad)
        Me.grpDistintaCantidad.Controls.Add(Me.lblNombreCant)
        Me.grpDistintaCantidad.Controls.Add(Me.lblCodigoCant)
        Me.grpDistintaCantidad.Controls.Add(Me.cmbPalletCantidad)
        Me.grpDistintaCantidad.Controls.Add(Me.Label5)
        Me.grpDistintaCantidad.Enabled = False
        Me.grpDistintaCantidad.Location = New System.Drawing.Point(290, 51)
        Me.grpDistintaCantidad.Name = "grpDistintaCantidad"
        Me.grpDistintaCantidad.Size = New System.Drawing.Size(272, 189)
        Me.grpDistintaCantidad.TabIndex = 47
        Me.grpDistintaCantidad.TabStop = False
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(106, 161)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(66, 22)
        Me.txtCantidad.TabIndex = 30
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Nueva cantidad"
        '
        'lblBultoCantidad
        '
        Me.lblBultoCantidad.AutoSize = True
        Me.lblBultoCantidad.Location = New System.Drawing.Point(12, 137)
        Me.lblBultoCantidad.Name = "lblBultoCantidad"
        Me.lblBultoCantidad.Size = New System.Drawing.Size(11, 13)
        Me.lblBultoCantidad.TabIndex = 28
        Me.lblBultoCantidad.Text = "-"
        '
        'lblNombreCant
        '
        Me.lblNombreCant.Location = New System.Drawing.Point(12, 82)
        Me.lblNombreCant.Name = "lblNombreCant"
        Me.lblNombreCant.Size = New System.Drawing.Size(250, 46)
        Me.lblNombreCant.TabIndex = 27
        Me.lblNombreCant.Text = "-"
        '
        'lblCodigoCant
        '
        Me.lblCodigoCant.AutoSize = True
        Me.lblCodigoCant.Location = New System.Drawing.Point(12, 60)
        Me.lblCodigoCant.Name = "lblCodigoCant"
        Me.lblCodigoCant.Size = New System.Drawing.Size(11, 13)
        Me.lblCodigoCant.TabIndex = 26
        Me.lblCodigoCant.Text = "-"
        '
        'cmbPalletCantidad
        '
        Me.cmbPalletCantidad.Enabled = False
        Me.cmbPalletCantidad.FormattingEnabled = True
        Me.cmbPalletCantidad.Location = New System.Drawing.Point(11, 32)
        Me.cmbPalletCantidad.Name = "cmbPalletCantidad"
        Me.cmbPalletCantidad.Size = New System.Drawing.Size(254, 21)
        Me.cmbPalletCantidad.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Seleccione pallet"
        '
        'frm_modifica_registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 247)
        Me.Controls.Add(Me.chkCantidad)
        Me.Controls.Add(Me.grpDistintaCantidad)
        Me.Controls.Add(Me.chkPallet)
        Me.Controls.Add(Me.grpDistintoPallet)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_modifica_registro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimiento de pallet"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpDistintoPallet.ResumeLayout(False)
        Me.grpDistintoPallet.PerformLayout()
        Me.grpDistintaCantidad.ResumeLayout(False)
        Me.grpDistintaCantidad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grpDistintoPallet As GroupBox
    Friend WithEvents cmbPallet As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkPallet As CheckBox
    Friend WithEvents lblBulto As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents chkCantidad As CheckBox
    Friend WithEvents grpDistintaCantidad As GroupBox
    Friend WithEvents lblBultoCantidad As Label
    Friend WithEvents lblNombreCant As Label
    Friend WithEvents lblCodigoCant As Label
    Friend WithEvents cmbPalletCantidad As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label2 As Label
End Class
