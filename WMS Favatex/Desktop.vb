Public Class Desktop
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub PickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickingToolStripMenuItem.Click
        Dim frm As frm_solicitud_picking = New frm_solicitud_picking
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Public Sub MostrarVentana(ByVal Formulario As Form, ByVal Mdi As Form, ByVal titulo_formulario As String, Optional ByVal CargaNormal As Boolean = False)
        Dim Frmllamado As Form
        Dim Escargado As Boolean = False
        For Each Frmllamado In Mdi.MdiChildren
            If Frmllamado.Text = titulo_formulario Then
                Escargado = True
                Exit For
            End If
        Next

        Formulario.MdiParent = Mdi
        Formulario.Show()
        Formulario.Focus()
    End Sub

    Private Sub Desktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV032\DESARROLLO;Initial Catalog=db_favatex;User ID=sa;Password=S1st3m4s"
        Call INICIALIZA_VALORES()


        'Dim frm As frm_resumen = New frm_resumen

        'MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub INICIALIZA_VALORES()
        txtUsuarioActual.Text = "USUARIO ACTUAL: " + GLO_PERSONA_NOMBRE
        txtServidor.Text = "SERVIDOR: " + pubServidor
        txtBase.Text = "BASE DE DATOS: " + pubBaseDato
        txtVersion.Text = "VERSIÓN DEL SISTEMA: " + Application.ProductVersion

        GLO_FECHA_SISTEMA = OBTIENE_FECHA_SISTEMA()
        GLO_BODEGA_RECEPCION = 14
    End Sub

    Private Function OBTIENE_FECHA_SISTEMA() As Date
        Dim classComnes As class_comunes = New class_comunes
        Dim _msgError As String = ""
        Dim ds As DataSet
        OBTIENE_FECHA_SISTEMA = CDate("01-01-1900")
        Try
            classComnes.cnn = _cnn
            ds = classComnes.OBTIENE_FECHA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return CDate(ds.Tables(0).Rows(0)("fecha_sistema"))
                End If
            Else
                MessageBox.Show(_msgError + "\OBTIENE_FECHA_SISTEMA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message + "\OBTIENE_FECHA_SISTEMA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub FffffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FffffToolStripMenuItem.Click
        Dim frm As frm_picking_sugerido = New frm_picking_sugerido
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub BosquedaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BosquedaToolStripMenuItem.Click
        Dim frm As frm_listado_picking = New frm_listado_picking
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub MantDePickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantDePickingToolStripMenuItem.Click
        Dim frm As frm_mant_picking = New frm_mant_picking
        'frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub GeneraPickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraPickingToolStripMenuItem.Click
        Dim frm As frm_picking_sugerido = New frm_picking_sugerido
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub VisorDePickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisorDePickingToolStripMenuItem.Click
        Dim frm As frm_visor_picking = New frm_visor_picking
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub
    Private Sub Desktop_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub
    Private Sub BusquedaDePickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusquedaDePickingToolStripMenuItem.Click
        Dim frm As frm_listado_picking = New frm_listado_picking
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub
    Private Sub PickingPendientesDeFacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickingPendientesDeFacturaciónToolStripMenuItem.Click
        Dim frm As frm_visor_facturacion_picking = New frm_visor_facturacion_picking
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub PickingPendientesDeDespachoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickingPendientesDeDespachoToolStripMenuItem.Click
        Dim frm As frm_visor_despacho = New frm_visor_despacho
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub DevoluciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevoluciónToolStripMenuItem.Click
        Dim frm As frm_visor_devoluciones = New frm_visor_devoluciones
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ConsolidadoDePickingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsolidadoDePickingToolStripMenuItem.Click
        Dim frm As frm_consolidado_picking = New frm_consolidado_picking
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub BusquedaDeCitasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusquedaDeCitasToolStripMenuItem.Click
        Dim frm As frm_listado_citas = New frm_listado_citas
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub GeneraciónDeCitasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraciónDeCitasToolStripMenuItem.Click
        Dim frm As frm_ingreso_citas = New frm_ingreso_citas
        frm.cnn = _cnn
        frm.cit_codigo = 0
        frm.eci_codigo = 0
        MostrarVentana(frm, Me, frm.Text, False)
        'frm.ShowDialog()
    End Sub

    Private Sub GeneraPickingATravesDeCitasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraPickingATravesDeCitasToolStripMenuItem.Click
        Dim frm As frm_picking_por_citas = New frm_picking_por_citas
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub GeneraciónDeAgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraciónDeAgendaToolStripMenuItem.Click
        Dim frm As frm_ingreso_agenda = New frm_ingreso_agenda
        frm.cnn = _cnn
        frm.age_codigoNew = 0
        frm.eag_codigo = 0
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub BusquedaDeAgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusquedaDeAgendaToolStripMenuItem.Click
        Dim frm As frm_listado_agenda = New frm_listado_agenda
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub GeneraciónDePickingATravesDeAgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraciónDePickingATravesDeAgendaToolStripMenuItem.Click
        Dim frm As frm_picking_por_agenda = New frm_picking_por_agenda
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub ListadoDeOrdenesDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeOrdenesDeCompraToolStripMenuItem.Click
        Dim frm As frm_listado_ordenes_de_compra = New frm_listado_ordenes_de_compra
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub

    Private Sub OrdenesDeCompraClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenesDeCompraClienteToolStripMenuItem.Click
        Dim frm As frm_orden_compra = New frm_orden_compra
        frm.cnn = _cnn
        frm.car_codigo = 0
        frm.numOC = 0
        frm.ShowDialog()
    End Sub

    Private Sub DetalleDePickingPorDiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleDePickingPorDiaToolStripMenuItem.Click
        Dim frm As frm_listado_picking_diario = New frm_listado_picking_diario
        frm.cnn = _cnn
        MostrarVentana(frm, Me, frm.Text, False)
    End Sub
End Class
