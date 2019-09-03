<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Desktop
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LogisticaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneraPickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.GeneraciónDeCitasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusquedaDeCitasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneraPickingATravesDeCitasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GeneraciónDeAgendaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusquedaDeAgendaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneraciónDePickingATravesDeAgendaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListadoDeOrdenesDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenesDeCompraClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.VisorDePickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PickingPendientesDeFacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PickingPendientesDeDespachoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevoluciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BusquedaDePickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsolidadoDePickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogisticaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FffffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BosquedaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantDePickingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtUsuarioActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtServidor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtBase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DetalleDePickingPorDiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogisticaToolStripMenuItem1, Me.SistemaToolStripMenuItem, Me.LogisticaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(654, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LogisticaToolStripMenuItem1
        '
        Me.LogisticaToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneraPickingToolStripMenuItem, Me.ToolStripMenuItem4, Me.GeneraciónDeCitasToolStripMenuItem, Me.BusquedaDeCitasToolStripMenuItem, Me.GeneraPickingATravesDeCitasToolStripMenuItem, Me.ToolStripMenuItem1, Me.GeneraciónDeAgendaToolStripMenuItem, Me.BusquedaDeAgendaToolStripMenuItem, Me.GeneraciónDePickingATravesDeAgendaToolStripMenuItem, Me.ToolStripMenuItem5, Me.ListadoDeOrdenesDeCompraToolStripMenuItem, Me.OrdenesDeCompraClienteToolStripMenuItem, Me.ToolStripMenuItem6, Me.VisorDePickingToolStripMenuItem, Me.ToolStripMenuItem2, Me.PickingPendientesDeFacturaciónToolStripMenuItem, Me.PickingPendientesDeDespachoToolStripMenuItem, Me.DevoluciónToolStripMenuItem, Me.ToolStripMenuItem3, Me.BusquedaDePickingToolStripMenuItem, Me.ConsolidadoDePickingToolStripMenuItem, Me.DetalleDePickingPorDiaToolStripMenuItem})
        Me.LogisticaToolStripMenuItem1.Name = "LogisticaToolStripMenuItem1"
        Me.LogisticaToolStripMenuItem1.Size = New System.Drawing.Size(64, 20)
        Me.LogisticaToolStripMenuItem1.Text = "Logistica"
        '
        'GeneraPickingToolStripMenuItem
        '
        Me.GeneraPickingToolStripMenuItem.Name = "GeneraPickingToolStripMenuItem"
        Me.GeneraPickingToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.GeneraPickingToolStripMenuItem.Text = "Genera picking venta en verde"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(262, 6)
        '
        'GeneraciónDeCitasToolStripMenuItem
        '
        Me.GeneraciónDeCitasToolStripMenuItem.Name = "GeneraciónDeCitasToolStripMenuItem"
        Me.GeneraciónDeCitasToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.GeneraciónDeCitasToolStripMenuItem.Text = "Generación de citas"
        '
        'BusquedaDeCitasToolStripMenuItem
        '
        Me.BusquedaDeCitasToolStripMenuItem.Name = "BusquedaDeCitasToolStripMenuItem"
        Me.BusquedaDeCitasToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.BusquedaDeCitasToolStripMenuItem.Text = "Busqueda de citas"
        '
        'GeneraPickingATravesDeCitasToolStripMenuItem
        '
        Me.GeneraPickingATravesDeCitasToolStripMenuItem.Name = "GeneraPickingATravesDeCitasToolStripMenuItem"
        Me.GeneraPickingATravesDeCitasToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.GeneraPickingATravesDeCitasToolStripMenuItem.Text = "Genera picking a traves de citas"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(262, 6)
        '
        'GeneraciónDeAgendaToolStripMenuItem
        '
        Me.GeneraciónDeAgendaToolStripMenuItem.Name = "GeneraciónDeAgendaToolStripMenuItem"
        Me.GeneraciónDeAgendaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.GeneraciónDeAgendaToolStripMenuItem.Text = "Generación de agenda"
        '
        'BusquedaDeAgendaToolStripMenuItem
        '
        Me.BusquedaDeAgendaToolStripMenuItem.Name = "BusquedaDeAgendaToolStripMenuItem"
        Me.BusquedaDeAgendaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.BusquedaDeAgendaToolStripMenuItem.Text = "Busqueda de agenda"
        '
        'GeneraciónDePickingATravesDeAgendaToolStripMenuItem
        '
        Me.GeneraciónDePickingATravesDeAgendaToolStripMenuItem.Name = "GeneraciónDePickingATravesDeAgendaToolStripMenuItem"
        Me.GeneraciónDePickingATravesDeAgendaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.GeneraciónDePickingATravesDeAgendaToolStripMenuItem.Text = "Genera picking a traves de agenda"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(262, 6)
        '
        'ListadoDeOrdenesDeCompraToolStripMenuItem
        '
        Me.ListadoDeOrdenesDeCompraToolStripMenuItem.Name = "ListadoDeOrdenesDeCompraToolStripMenuItem"
        Me.ListadoDeOrdenesDeCompraToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ListadoDeOrdenesDeCompraToolStripMenuItem.Text = "Listado de ordenes de compra cliente"
        '
        'OrdenesDeCompraClienteToolStripMenuItem
        '
        Me.OrdenesDeCompraClienteToolStripMenuItem.Name = "OrdenesDeCompraClienteToolStripMenuItem"
        Me.OrdenesDeCompraClienteToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.OrdenesDeCompraClienteToolStripMenuItem.Text = "Ordenes de compra cliente"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(262, 6)
        '
        'VisorDePickingToolStripMenuItem
        '
        Me.VisorDePickingToolStripMenuItem.Name = "VisorDePickingToolStripMenuItem"
        Me.VisorDePickingToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.VisorDePickingToolStripMenuItem.Text = "Visor de picking"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(262, 6)
        '
        'PickingPendientesDeFacturaciónToolStripMenuItem
        '
        Me.PickingPendientesDeFacturaciónToolStripMenuItem.Name = "PickingPendientesDeFacturaciónToolStripMenuItem"
        Me.PickingPendientesDeFacturaciónToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.PickingPendientesDeFacturaciónToolStripMenuItem.Text = "Picking pendientes de facturación"
        '
        'PickingPendientesDeDespachoToolStripMenuItem
        '
        Me.PickingPendientesDeDespachoToolStripMenuItem.Name = "PickingPendientesDeDespachoToolStripMenuItem"
        Me.PickingPendientesDeDespachoToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.PickingPendientesDeDespachoToolStripMenuItem.Text = "Picking pendientes de despacho"
        '
        'DevoluciónToolStripMenuItem
        '
        Me.DevoluciónToolStripMenuItem.Name = "DevoluciónToolStripMenuItem"
        Me.DevoluciónToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.DevoluciónToolStripMenuItem.Text = "Devolución de productos"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(262, 6)
        '
        'BusquedaDePickingToolStripMenuItem
        '
        Me.BusquedaDePickingToolStripMenuItem.Name = "BusquedaDePickingToolStripMenuItem"
        Me.BusquedaDePickingToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.BusquedaDePickingToolStripMenuItem.Text = "Busqueda de Picking"
        '
        'ConsolidadoDePickingToolStripMenuItem
        '
        Me.ConsolidadoDePickingToolStripMenuItem.Name = "ConsolidadoDePickingToolStripMenuItem"
        Me.ConsolidadoDePickingToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ConsolidadoDePickingToolStripMenuItem.Text = "Consolidado de Picking"
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.SistemaToolStripMenuItem.Text = "Sistema"
        Me.SistemaToolStripMenuItem.Visible = False
        '
        'LogisticaToolStripMenuItem
        '
        Me.LogisticaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PickingToolStripMenuItem, Me.FffffToolStripMenuItem, Me.BosquedaToolStripMenuItem, Me.MantDePickingToolStripMenuItem})
        Me.LogisticaToolStripMenuItem.Name = "LogisticaToolStripMenuItem"
        Me.LogisticaToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.LogisticaToolStripMenuItem.Text = "Logistica"
        Me.LogisticaToolStripMenuItem.Visible = False
        '
        'PickingToolStripMenuItem
        '
        Me.PickingToolStripMenuItem.Name = "PickingToolStripMenuItem"
        Me.PickingToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PickingToolStripMenuItem.Text = "Picking"
        '
        'FffffToolStripMenuItem
        '
        Me.FffffToolStripMenuItem.Name = "FffffToolStripMenuItem"
        Me.FffffToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.FffffToolStripMenuItem.Text = "fffff"
        '
        'BosquedaToolStripMenuItem
        '
        Me.BosquedaToolStripMenuItem.Name = "BosquedaToolStripMenuItem"
        Me.BosquedaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.BosquedaToolStripMenuItem.Text = "busqueda"
        '
        'MantDePickingToolStripMenuItem
        '
        Me.MantDePickingToolStripMenuItem.Name = "MantDePickingToolStripMenuItem"
        Me.MantDePickingToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.MantDePickingToolStripMenuItem.Text = "mant de picking"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtUsuarioActual, Me.txtServidor, Me.txtBase, Me.txtVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 418)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(654, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtUsuarioActual
        '
        Me.txtUsuarioActual.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.txtUsuarioActual.Name = "txtUsuarioActual"
        Me.txtUsuarioActual.Size = New System.Drawing.Size(124, 19)
        Me.txtUsuarioActual.Text = "ToolStripStatusLabel1"
        '
        'txtServidor
        '
        Me.txtServidor.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(124, 19)
        Me.txtServidor.Text = "ToolStripStatusLabel1"
        '
        'txtBase
        '
        Me.txtBase.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(124, 19)
        Me.txtBase.Text = "ToolStripStatusLabel1"
        '
        'txtVersion
        '
        Me.txtVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(124, 19)
        Me.txtVersion.Text = "ToolStripStatusLabel1"
        '
        'DetalleDePickingPorDiaToolStripMenuItem
        '
        Me.DetalleDePickingPorDiaToolStripMenuItem.Name = "DetalleDePickingPorDiaToolStripMenuItem"
        Me.DetalleDePickingPorDiaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.DetalleDePickingPorDiaToolStripMenuItem.Text = "Detalle de picking por dia"
        '
        'Desktop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 442)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Desktop"
        Me.Text = "DESKTOP FAVATEX WMS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LogisticaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PickingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FffffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BosquedaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MantDePickingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SistemaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogisticaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GeneraPickingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents BusquedaDePickingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents VisorDePickingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents PickingPendientesDeFacturaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PickingPendientesDeDespachoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents txtUsuarioActual As ToolStripStatusLabel
    Friend WithEvents txtServidor As ToolStripStatusLabel
    Friend WithEvents txtBase As ToolStripStatusLabel
    Friend WithEvents txtVersion As ToolStripStatusLabel
    Friend WithEvents DevoluciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsolidadoDePickingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneraciónDeCitasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BusquedaDeCitasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents GeneraPickingATravesDeCitasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneraciónDeAgendaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BusquedaDeAgendaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneraciónDePickingATravesDeAgendaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents ListadoDeOrdenesDeCompraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdenesDeCompraClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents DetalleDePickingPorDiaToolStripMenuItem As ToolStripMenuItem
End Class
