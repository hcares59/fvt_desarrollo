Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_impresion_etiquetas_por_productos
    Private _cnn As String
    Dim IdImpresion As Integer = 0
    Dim _pic_codigo As Integer = 0
    Dim _codCliente As Integer = 0

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As frm_listado_picking = New frm_listado_picking
        frm.cnn = _cnn
        GLO_NUMERO_PICKING = 0
        _codCliente = 0
        GLO_BUSQUEDA_PICKING_DESDE = "IE"
        lblCliente.Text = ""
        lblFecha.Text = ""
        lblHora.Text = ""
        'frm.MdiParent = Me
        frm.ShowDialog()
        txtNumPicking.Text = GLO_NUMERO_PICKING
        _pic_codigo = GLO_NUMERO_PICKING
        If GLO_NUMERO_PICKING > 0 Then
            Call CARGA_DATOS_ENCABEZADO()
            Call CARGA_COMBO_ETIQUETAS()
        End If
    End Sub

    Private Sub CARGA_COMBO_ETIQUETAS()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            classCliente.car_codigo = _codCliente
            _msg = ""
            ds = classCliente.CARTERA_ETIQUETA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbEtiqueta.DataSource = ds.Tables(0)
                Me.cmbEtiqueta.DisplayMember = "MENSAJE"
                Me.cmbEtiqueta.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ETIQUETAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_DATOS_ENCABEZADO()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classPicking.cnn = _cnn
            classPicking.pic_codigo = _pic_codigo

            ds = classPicking.PICKING_CARGA_ENCABEZADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        lblCliente.Text = ds.Tables(0).Rows(Fila)("car_nombre")
                        lblFecha.Text = ds.Tables(0).Rows(Fila)("fecha_despacho")
                        lblHora.Text = ds.Tables(0).Rows(Fila)("hora_cita")
                        _codCliente = ds.Tables(0).Rows(Fila)("car_codigo")

                        'Call CARGA_GRILLA_LOG()
                        Call CARGA_GRILLA_DETALLE()
                    End If
                End If
            Else
                MessageBox.Show(_msgError + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_DATOS_ENCABEZADO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE()
        Dim classPicking As class_picking = New class_picking
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            classPicking.cnn = _cnn
            classPicking.pic_codigo = _pic_codigo

            ds = classPicking.PICKING_CARGA_DETALLE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Grilla.Rows.Clear()
                    If ds.Tables(0).Rows(Fila)("sku_cartera_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False, ds.Tables(0).Rows(Fila)("pic_codigo"),
                                                   ds.Tables(0).Rows(Fila)("pic_fila"),
                                                   ds.Tables(0).Rows(Fila)("pro_codigoactual"),
                                                   ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                                   ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                   ds.Tables(0).Rows(Fila)("sku_cartera"),
                                                   ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                                   ds.Tables(0).Rows(Fila)("existentes"),
                                                   FormatNumber((ds.Tables(0).Rows(Fila)("nuumero_bultos") * ds.Tables(0).Rows(Fila)("existentes")), 0))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frm_impresion_etiquetas_por_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblCliente.Text = ""
        lblFecha.Text = ""
        lblHora.Text = ""
    End Sub

    Private Sub ButtonImprimir_Click(sender As Object, e As EventArgs) Handles ButtonImprimir.Click

    End Sub
End Class