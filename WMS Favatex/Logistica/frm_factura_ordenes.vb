Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_factura_ordenes
    Private _cnn As String
    Private _pic_codigo As Integer

    Const col_S As Integer = 0
    Const col_PIC_CODIGO As Integer = 1
    Const col_NUM_OC As Integer = 2
    Const col_NOMBRE_CLIENTE As Integer = 3
    Const col_FECHA_PICKING As Integer = 4
    Const col_FECHA_COMPROMISO As Integer = 5
    Const col_CODIGO_UNICO As Integer = 6
    Const col_CANTIDAD As Integer = 7
    Const col_N_B_X_U As Integer = 8
    Const col_T_BULTOS As Integer = 9
    Const col_EXISTENTES As Integer = 10
    Const col_TOTAL_NETO As Integer = 11
    Const col_IVA As Integer = 12
    Const col_TOTAL_OC As Integer = 13
    Const col_FACTURADAS As Integer = 14

    Const colD_SELECCION As Integer = 0
    Const colD_CAR_CODIGO As Integer = 1
    Const colD_FIL As Integer = 2
    Const colD_COD_UNICO As Integer = 3
    Const colD_CODIGO_INTERNO As Integer = 4
    Const colD_NOMBRE_FAVATEX As Integer = 5
    Const colD_SKU_CLIENTE As Integer = 6
    Const colD_SKU_NOMBRE As Integer = 7
    Const colD_DISPONIBLE As Integer = 8
    Const colD_CANTIDAD As Integer = 9
    Const colD_NBXU As Integer = 10 'NUMERO DE BULTOS POR UNIDAD
    Const colD_TBULTOS As Integer = 11
    Const colD_CODIGO_INTERNO_ORIGINAL As Integer = 12
    Const colD_EXISTENTES As Integer = 13
    Const colD_OBSERVACIONES As Integer = 14
    Const colD_NEW_CODIGO As Integer = 15
    Const colD_COD_INT_ORI As Integer = 16
    Const colD_NOMBRE_ORI As Integer = 17
    Const colD_NBO As Integer = 18 'CANTIDAD DE BULTOS ORIGINALES
    Const colD_PIC_CODIGO As Integer = 19
    Const colD_NUEVA As Integer = 20
    Const colD_PRECIO_UNITARIO As Integer = 21
    Const colD_OC_ORIGEN As Integer = 22
    Const colD_FECHA_OC As Integer = 23
    Const colD_TOTAL_FILA As Integer = 24

    Private cargaPrimeraVez As Boolean = False

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property

    Public Property pic_codigo() As Integer
        Get
            Return _pic_codigo
        End Get
        Set(ByVal value As Integer)
            _pic_codigo = value
        End Set
    End Property
    Private Sub frm_factura_ordenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Dim valor As Integer = _pic_codigo
        Dim dato As String = String.Format("{0:000000}", valor)

        lbltitulo.Text = lbltitulo.Text + " " + dato

        Call CARGA_GRILLA()

        cargaPrimeraVez = True
    End Sub

    Private Sub CARGA_GRILLA()
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classFactura.cnn = _cnn
            classFactura.pic_codigo = _pic_codigo
            _msg = ""
            GrillaEnc.Rows.Clear()
            ds = classFactura.LISTA_ENCABEZADOS_OC_PARA_FACTURAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaEnc.Rows.Add(False, ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("car_nombre"),
                                            CDate(ds.Tables(0).Rows(Fila)("pic_fecha")).ToShortDateString,
                                            CDate(ds.Tables(0).Rows(Fila)("pic_fechaoc")).ToShortDateString,
                                            "-",
                                            ds.Tables(0).Rows(Fila)("cant_unidades"),
                                            ds.Tables(0).Rows(Fila)("cant_bultos"),
                                            ds.Tables(0).Rows(Fila)("total_bultos"),
                                            ds.Tables(0).Rows(Fila)("cant_unidades_encontradas"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("total_neto"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("total_neto") * GLO_VALOR_IVA, 0),
                                            FormatNumber((ds.Tables(0).Rows(Fila)("total_neto") * GLO_VALOR_IVA) + (ds.Tables(0).Rows(Fila)("total_neto")), 0),
                                            ds.Tables(0).Rows(Fila)("filas_facturadas"))
                            Fila = Fila + 1
                        Loop

                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_GRILLA_DETALLE(ByVal num_oc As Integer)
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classFactura.cnn = _cnn
            classFactura.pic_codigo = _pic_codigo
            classFactura.pic_ocnumero = num_oc
            _msg = ""
            GrillaDetalle.Rows.Clear()
            ds = classFactura.LISTA_DETALLE_OC_PARA_FACTURAR(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("sku_cartera_nombre") <> "" Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaDetalle.Rows.Add(False, 0,
                                            ds.Tables(0).Rows(Fila)("pic_fila"),
                                            ds.Tables(0).Rows(Fila)("con_codigounico"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera"),
                                            ds.Tables(0).Rows(Fila)("sku_cartera_nombre"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("disponible"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("cantidad"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("nuumero_bultos"), 0),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("total_bulto"), 0),
                                            ds.Tables(0).Rows(Fila)("pro_codigooriginal"),
                                            ds.Tables(0).Rows(Fila)("existentes"),
                                            ds.Tables(0).Rows(Fila)("observacion"),
                                            ds.Tables(0).Rows(Fila)("pro_codigoactual"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointernooriginal"),
                                            ds.Tables(0).Rows(Fila)("pro_nombreoriginal"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("pro_numerobultosoriginal"), 0),
                                            ds.Tables(0).Rows(Fila)("pic_codigo"),
                                            ds.Tables(0).Rows(Fila)("nueva_fila"),
                                            FormatNumber(ds.Tables(0).Rows(Fila)("precio"), 0),
                                            ds.Tables(0).Rows(Fila)("pic_ocnumero"),
                                            ds.Tables(0).Rows(Fila)("pic_fechaoc"),
                                            FormatNumber((ds.Tables(0).Rows(Fila)("precio") * ds.Tables(0).Rows(Fila)("existentes")), 0))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_GRILLA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_GRILLA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub GrillaEnc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaEnc.CellContentClick
        If e.ColumnIndex = Me.GrillaEnc.Columns.Item(0).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaEnc.Rows(e.RowIndex).Cells(0)
            chkCell.Value = Not chkCell.Value
        End If

        If e.ColumnIndex = 0 Then
            SUMA_TOTALES()
        End If
    End Sub

    Private Sub SUMA_TOTALES()
        Dim TotalNeto As Long = 0
        Dim TotalIVA As Long = 0

        Try
            For Each row As DataGridViewRow In Me.GrillaEnc.Rows
                If row.Cells(0).Value = True Then
                    TotalNeto = TotalNeto + row.Cells(11).Value
                End If
            Next

            txtTotalNeto.Text = FormatNumber(TotalNeto, 0)
            TotalIVA = TotalNeto * GLO_VALOR_IVA
            txtTotalIVA.Text = FormatNumber(TotalIVA, 0)
            txtTotal.Text = FormatNumber(TotalNeto + TotalIVA, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaEnc_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaEnc.CellEnter
        If GrillaEnc.RowCount < 0 Then
            Exit Sub
        End If

        'If cargaPrimeraVez = True Then
        Call CARGA_GRILLA_DETALLE(GrillaEnc.Rows(e.RowIndex).Cells(col_NUM_OC).Value)

        'End If

    End Sub

    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        Try
            If ORDENES_MARCADAS() = False Then
                MessageBox.Show("Debe checkar las ordenes que desea facturar del picking seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If txtNumero.Text = "" Then
                MessageBox.Show("Debe ingresar el número de la factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Call GUARDA_FACURA()
            GrillaDetalle.DataSource = Nothing
            GrillaDetalle.Rows.Clear()
            Call CARGA_GRILLA()
        Catch ex As Exception

        End Try



    End Sub

    Private Function ORDENES_MARCADAS() As Boolean
        Dim Contador As Integer = 0
        Try
            ORDENES_MARCADAS = False

            For Each row As DataGridViewRow In Me.GrillaEnc.Rows
                If row.Cells(col_S).Value = False Then
                    Contador = Contador + 1
                End If
            Next

            If Contador <> Me.GrillaEnc.RowCount Then
                ORDENES_MARCADAS = True
            End If

        Catch ex As Exception
            ORDENES_MARCADAS = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GUARDA_FACURA()
        Dim classFactura As class_factura_picking = New class_factura_picking
        Dim classPicking As class_picking = New class_picking

        Dim classLog As LogEventos = New LogEventos
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()

        Dim DetalleCompletoFacturado As Boolean = False

        Dim OrdenesFacturadas As String = "[ "

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                classFactura.pic_codigo = _pic_codigo
                classFactura.fac_fecha = txtFecha.Value
                classFactura.fac_codigo = txtNumero.Text

                For Each row As DataGridViewRow In Me.GrillaEnc.Rows
                    If row.Cells(col_S).Value = True Then
                        classFactura.pic_ocnumero = row.Cells(col_NUM_OC).Value
                        classFactura.fac_neto = row.Cells(col_TOTAL_NETO).Value
                        classFactura.fac_iva = row.Cells(col_IVA).Value
                        classFactura.fac_total = row.Cells(col_TOTAL_OC).Value
                        ds = classFactura.PICKING_FACTURA_GUARDA_DATOS(_msgError, conexion)
                        If _msgError <> "" Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            ds = Nothing
                            MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ds = Nothing
                                Exit Sub
                            End If
                        End If

                        For Each row2 As DataGridViewRow In Me.GrillaDetalle.Rows
                            ds = Nothing
                            classFactura.pic_fila = row2.Cells(2).Value
                            ds = classFactura.PICKING_MARCA_FILAS_FACURADAS(_msgError, conexion)
                            If _msgError <> "" Then
                                If conexion.State = ConnectionState.Open Then
                                    conexion.Close()
                                End If
                                ds = Nothing
                                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            Else
                                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                    If conexion.State = ConnectionState.Open Then
                                        conexion.Close()
                                    End If
                                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    ds = Nothing
                                    Exit Sub
                                End If
                            End If
                        Next
                        If OrdenesFacturadas = "[ " Then
                            OrdenesFacturadas = row.Cells(col_NUM_OC).Value
                        Else
                            OrdenesFacturadas = OrdenesFacturadas & " | " & row.Cells(col_NUM_OC).Value
                        End If
                    End If
                Next

                If OrdenesFacturadas <> "[ " Then
                    OrdenesFacturadas = OrdenesFacturadas & " ]"

                    ds = Nothing
                    classPicking.pic_codigo = _pic_codigo
                    classPicking.lpi_descripcion = "Se factura(n) la(s) orden(es): " + OrdenesFacturadas
                    classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                    ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
                    If _msgError <> "" Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Sub
                        End If
                    End If
                End If

                ds = Nothing
                ds = classFactura.REVISA_FILAS_FACTURADAS(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("mensaje") > 0 Then
                        DetalleCompletoFacturado = True
                    Else
                        DetalleCompletoFacturado = False
                    End If
                End If

                ds = Nothing
                classPicking.cnn = _cnn
                classPicking.pic_codigo = _pic_codigo
                classPicking.usu_codigo = GLO_USUARIO_ACTUAL
                If DetalleCompletoFacturado = False Then
                    classPicking.lpi_descripcion = "Picking facturado parcial"
                Else
                    classPicking.lpi_descripcion = "Picking facturado completo"
                End If

                ds = classPicking.PICKING_GUARDA_LOG(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                If DetalleCompletoFacturado = True Then
                    ds = Nothing
                    classPicking.pic_codigo = _pic_codigo
                    classPicking.epc_codigo = ESTADOS_PICKING.Enviado_a_despachar
                    ds = classPicking.PICKING_CAMBIA_ESTDO(_msgError, conexion)
                    If _msgError <> "" Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Sub
                        End If
                    End If
                End If




                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                MessageBox.Show("Se ha(n) factura(n) la(s) orden(es): " + OrdenesFacturadas, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Class

