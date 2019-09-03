<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnLogistica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBodega = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDespacho = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnComercial = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGerencia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConfiguracion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.picD = New System.Windows.Forms.PictureBox()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.picH = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtServidor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtBase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.TreeMenu = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblNombreUsuario = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 6)
        Me.Panel1.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLogistica, Me.ToolStripSeparator1, Me.btnBodega, Me.ToolStripSeparator2, Me.btnDespacho, Me.ToolStripSeparator3, Me.btnComercial, Me.ToolStripSeparator4, Me.btnGerencia, Me.ToolStripSeparator5, Me.btnConfiguracion, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 6)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(787, 54)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnLogistica
        '
        Me.btnLogistica.Image = CType(resources.GetObject("btnLogistica.Image"), System.Drawing.Image)
        Me.btnLogistica.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLogistica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLogistica.Name = "btnLogistica"
        Me.btnLogistica.Size = New System.Drawing.Size(58, 51)
        Me.btnLogistica.Text = "Logistica"
        Me.btnLogistica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'btnBodega
        '
        Me.btnBodega.Image = CType(resources.GetObject("btnBodega.Image"), System.Drawing.Image)
        Me.btnBodega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBodega.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBodega.Name = "btnBodega"
        Me.btnBodega.Size = New System.Drawing.Size(51, 51)
        Me.btnBodega.Text = "Bodega"
        Me.btnBodega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'btnDespacho
        '
        Me.btnDespacho.Image = CType(resources.GetObject("btnDespacho.Image"), System.Drawing.Image)
        Me.btnDespacho.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDespacho.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDespacho.Name = "btnDespacho"
        Me.btnDespacho.Size = New System.Drawing.Size(64, 51)
        Me.btnDespacho.Text = "Despacho"
        Me.btnDespacho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        '
        'btnComercial
        '
        Me.btnComercial.Image = CType(resources.GetObject("btnComercial.Image"), System.Drawing.Image)
        Me.btnComercial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnComercial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComercial.Name = "btnComercial"
        Me.btnComercial.Size = New System.Drawing.Size(64, 51)
        Me.btnComercial.Text = "Comercial"
        Me.btnComercial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'btnGerencia
        '
        Me.btnGerencia.Image = CType(resources.GetObject("btnGerencia.Image"), System.Drawing.Image)
        Me.btnGerencia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGerencia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGerencia.Name = "btnGerencia"
        Me.btnGerencia.Size = New System.Drawing.Size(57, 51)
        Me.btnGerencia.Text = "Gerencia"
        Me.btnGerencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 54)
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Image = CType(resources.GetObject("btnConfiguracion.Image"), System.Drawing.Image)
        Me.btnConfiguracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnConfiguracion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(86, 51)
        Me.btnConfiguracion.Text = "Configuración"
        Me.btnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 54)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.lblModulo)
        Me.Panel2.Controls.Add(Me.picD)
        Me.Panel2.Controls.Add(Me.lblMenu)
        Me.Panel2.Controls.Add(Me.picH)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(787, 29)
        Me.Panel2.TabIndex = 5
        '
        'lblModulo
        '
        Me.lblModulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModulo.ForeColor = System.Drawing.Color.Black
        Me.lblModulo.Location = New System.Drawing.Point(415, 5)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(273, 18)
        Me.lblModulo.TabIndex = 7
        Me.lblModulo.Text = "MODULO LOGISTICA ACTIVO"
        Me.lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picD
        '
        Me.picD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picD.Image = CType(resources.GetObject("picD.Image"), System.Drawing.Image)
        Me.picD.Location = New System.Drawing.Point(10, 3)
        Me.picD.Name = "picD"
        Me.picD.Size = New System.Drawing.Size(24, 24)
        Me.picD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picD.TabIndex = 6
        Me.picD.TabStop = False
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Location = New System.Drawing.Point(38, 9)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(76, 13)
        Me.lblMenu.TabIndex = 5
        Me.lblMenu.Text = "Contraer menú"
        '
        'picH
        '
        Me.picH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picH.Image = CType(resources.GetObject("picH.Image"), System.Drawing.Image)
        Me.picH.Location = New System.Drawing.Point(10, 3)
        Me.picH.Name = "picH"
        Me.picH.Size = New System.Drawing.Size(24, 24)
        Me.picH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picH.TabIndex = 4
        Me.picH.TabStop = False
        Me.picH.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(693, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(87, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtServidor, Me.txtBase, Me.txtVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 434)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(787, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtServidor
        '
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(120, 17)
        Me.txtServidor.Text = "ToolStripStatusLabel1"
        '
        'txtBase
        '
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(120, 17)
        Me.txtBase.Text = "ToolStripStatusLabel1"
        '
        'txtVersion
        '
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(120, 17)
        Me.txtVersion.Text = "ToolStripStatusLabel1"
        '
        'PanelMenu
        '
        Me.PanelMenu.Controls.Add(Me.TreeMenu)
        Me.PanelMenu.Controls.Add(Me.Panel3)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 89)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(200, 345)
        Me.PanelMenu.TabIndex = 7
        '
        'TreeMenu
        '
        Me.TreeMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeMenu.ImageIndex = 0
        Me.TreeMenu.ImageList = Me.ImageList1
        Me.TreeMenu.Location = New System.Drawing.Point(0, 0)
        Me.TreeMenu.Name = "TreeMenu"
        Me.TreeMenu.SelectedImageIndex = 0
        Me.TreeMenu.Size = New System.Drawing.Size(200, 297)
        Me.TreeMenu.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder-3-16.ico")
        Me.ImageList1.Images.SetKeyName(1, "application_form.gif")
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblCargo)
        Me.Panel3.Controls.Add(Me.lblNombreUsuario)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 297)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 48)
        Me.Panel3.TabIndex = 0
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Location = New System.Drawing.Point(51, 26)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(10, 13)
        Me.lblCargo.TabIndex = 2
        Me.lblCargo.Text = "-"
        '
        'lblNombreUsuario
        '
        Me.lblNombreUsuario.AutoSize = True
        Me.lblNombreUsuario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreUsuario.Location = New System.Drawing.Point(51, 7)
        Me.lblNombreUsuario.Name = "lblNombreUsuario"
        Me.lblNombreUsuario.Size = New System.Drawing.Size(12, 14)
        Me.lblNombreUsuario.TabIndex = 1
        Me.lblNombreUsuario.Text = "-"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 456)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "frmMenu"
        Me.Text = "DESKTOP Menu principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PanelMenu.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnLogistica As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnBodega As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnDespacho As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblModulo As Label
    Friend WithEvents picD As PictureBox
    Friend WithEvents lblMenu As Label
    Friend WithEvents picH As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents TreeMenu As TreeView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblCargo As Label
    Friend WithEvents lblNombreUsuario As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnComercial As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnGerencia As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnConfiguracion As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents txtServidor As ToolStripStatusLabel
    Friend WithEvents txtBase As ToolStripStatusLabel
    Friend WithEvents txtVersion As ToolStripStatusLabel
End Class
