Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading

Public Class frm_movimiento_pallet
    Dim _cnn As String
    Const CONST_COL_SE As Integer = 0
    Const CONST_COL_FILA As Integer = 1
    Const CONST_COL_PRO_CODIGO As Integer = 2
    Const CONST_COL_CODIGO As Integer = 3
    Const CONST_COL_PRODUCTO As Integer = 4
    Const CONST_COL_NBULTO As Integer = 5
    Const CONST_COL_BULTO As Integer = 6
    Const CONST_SERIE_PALLET As Integer = 7
    Const CONST_CANTIDAD As Integer = 8

    Dim cargaPrimeraVez As Boolean = False
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub frm_movimiento_pallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cargaPrimeraVez = False
        Call INICIALIZA()
        cargaPrimeraVez = True
    End Sub

    Private Sub INICIALIZA()

        Call CARGA_COMBO_BODEGAS_PISO_SIN_PT()

        Grilla.Columns(CONST_COL_SE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_COL_FILA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_COL_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_COL_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_COL_PRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_COL_NBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_COL_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_SERIE_PALLET).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Grilla.Columns(CONST_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

    End Sub

    Private Sub CARGA_COMBO_BODEGAS_PISO_SIN_PT()
        Dim _msg As String
        Try
            Dim classBodega As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classBodega.cnn = _cnn
            _msg = ""
            ds = classBodega.BODEGA_PISO_SIN_PT_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbBodega.DataSource = ds.Tables(0)
                Me.cmbBodega.DisplayMember = "MENSAJE"
                Me.cmbBodega.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_RECEPCION", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If cargaPrimeraVez = True Then
            Call CARGA_COMBO_UBICACION_PISO()
        End If
    End Sub

    Private Sub CARGA_COMBO_UBICACION_PISO()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn

            If cmbBodega.Text = "" Then
                classUbicacion.bod_codigo = 0
            Else
                classUbicacion.bod_codigo = cmbBodega.SelectedValue
            End If

            _msg = ""
            ds = classUbicacion.UBICACIONES_PISO_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbUbicacion.DataSource = ds.Tables(0)
                Me.cmbUbicacion.DisplayMember = "MENSAJE"
                Me.cmbUbicacion.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_UBICACION_PISO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_PRODUCTOS_UBICACION_PISO()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn

            If cmbUbicacion.SelectedValue = 0 Then
                classUbicacion.ubi_codigo = 0
            Else
                classUbicacion.ubi_codigo = cmbUbicacion.SelectedValue
            End If

            _msg = ""
            ds = classUbicacion.PRODUCTOS_POR_UBICACIONES_PISO_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbProductos.DataSource = ds.Tables(0)
                Me.cmbProductos.DisplayMember = "MENSAJE"
                Me.cmbProductos.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PRODUCTOS_UBICACION_PISO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbUbicacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectionChangeCommitted
        If cargaPrimeraVez = True Then
            Call CARGA_COMBO_PRODUCTOS_UBICACION_PISO()
            Call CARGA_GRILLA_PALLET_UBICACION()
        End If
    End Sub

    Private Sub CARGA_GRILLA_PALLET_UBICACION()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim Contador As Integer = 1
        Try
            classUbicacion.cnn = _cnn

            If cmbUbicacion.SelectedValue = 0 Then
                classUbicacion.ubi_codigo = 0
            Else
                classUbicacion.ubi_codigo = cmbUbicacion.SelectedValue
            End If

            If cmbProductos.SelectedValue = 0 Then
                classUbicacion.pro_codigo = 0
            Else
                classUbicacion.pro_codigo = cmbProductos.SelectedValue
            End If
            Grilla.Rows.Clear()
            ds = classUbicacion.PALLET_PISO_CARGA_GRILLA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            Grilla.Rows.Add(False, 0,
                                            ds.Tables(0).Rows(Fila)("pro_codigo"),
                                            ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                            ds.Tables(0).Rows(Fila)("pro_nombre"),
                                            ds.Tables(0).Rows(Fila)("pro_nbulto"),
                                            ds.Tables(0).Rows(Fila)("pro_bulto"),
                                            Trim(ds.Tables(0).Rows(Fila)("pallet")),
                                            ds.Tables(0).Rows(Fila)("cantidad"))
                            Fila = Fila + 1
                            Contador = Contador + 1
                        Loop
                        Grilla.Columns(CONST_COL_SE).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_COL_FILA).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_COL_PRO_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_COL_CODIGO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_COL_PRODUCTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_COL_NBULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_COL_BULTO).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_SERIE_PALLET).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                        Grilla.Columns(CONST_CANTIDAD).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                    End If
                End If
                'GrillaNotaria.AutoResizeColumns()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_PALLET_UBICACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_PALLET_UBICACION", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbProductos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbProductos.SelectionChangeCommitted
        Call CARGA_GRILLA_PALLET_UBICACION()
    End Sub

    Private Sub ButtonSelecciona_Click(sender As Object, e As EventArgs) Handles ButtonSelecciona.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = True
        Next
    End Sub
    Private Sub ButtonDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub
    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.Grilla.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub ButtonImprime_Click(sender As Object, e As EventArgs) Handles ButtonImprime.Click
        'Try
        '    Dim frm As frm_imprimir = New frm_imprimir
        '    frm.Origen = "SPA"

        '    frm.asi_codigo = _asiNumero
        '    frm.serie_paller = OBTIENE_SERIES()

        '    frm.ShowDialog()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub ButtonMovimiento_Click(sender As Object, e As EventArgs) Handles ButtonMovimiento.Click
        Call GENERA_MOVIMIENTO_A_PISO_PT()
        Call CARGA_GRILLA_PALLET_UBICACION()
    End Sub

    Private Sub GENERA_MOVIMIENTO_A_PISO_PT()
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim contador As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()

                For Each row As DataGridViewRow In Me.Grilla.Rows
                    If ENVIA_PALLET_A_PT(row.Cells(CONST_SERIE_PALLET).Value, conexion) = False Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        Exit Sub
                    End If
                Next

                If GUARDA_MOVIMIENTO(conexion) = False Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                Me.Cursor = Cursors.Default
            End Using

            MessageBox.Show("El movimiento fue realizado en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GUARDA_MOVIMIENTO(ByVal conexion As SqlConnection) As Boolean
        Dim classMOV As class_movimientos = New class_movimientos
        Dim classInv As class_inventario = New class_inventario
        'Dim class_recepcion As class_recepcion = New class_recepcion
        Dim classRecepcion As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim dsDetalle As DataSet = New DataSet
        Dim dsInventario As DataSet = New DataSet
        Dim dsUbicacion As DataSet = New DataSet
        Dim dsMov As DataSet = New DataSet
        Dim _numCantidadBultos As Integer = 0

        Dim _Folio As Integer = 0
        Dim _FolioRelacionado As Integer = 0
        Dim fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim _msgError As String = ""
        'Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim _fecha As Date
        Dim cantidad As Integer = 0
        Dim sumaCantidad As Integer = 0
        Dim seriePallet As String = ""
        Dim _Observacion As String = ""
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones

        GUARDA_MOVIMIENTO = False


        Try
            _Observacion = "MOVIMIENTO GENERADO A TRAVEZ DEL TRASPASO DE MERADERIA A LA BODEGA DE PISO DE PT"

            _fecha = GLO_FECHA_SISTEMA

            If CStr(_fecha.Month).Length = 1 Then
                mes = Trim("0" + CStr(_fecha.Month))
            Else
                mes = CStr(_fecha.Month)
            End If

            'SALIDA DE BODEGA DE ORIGEN
            '=============================================================
            If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.SALIDA, cmbBodega.SelectedValue, _fecha, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                        COM_TIPO_DOCUMENTO.VALE_DE_SALIDA, 0, 0, _Observacion, "-", 0, _Folio) = False Then
                Return False
                Exit Function
            End If

            _FolioRelacionado = _Folio

            If ELIMINA_DETALLE_MOVIMIENTO(conexion, _Folio) = False Then
                Return False
                Exit Function
            End If

            dsUbicacion = Nothing
            classUbicaciones.pallet = SELECCIONA_PARA_TRASPASAR()
            dsUbicacion = classUbicaciones.DATOS_PARA_TRASPASO_A_PISO_PT(_msgError, conexion)
            If _msgError = "" Then
                If dsUbicacion.Tables(0).Rows.Count > 0 Then
                    If dsUbicacion.Tables(0).Rows(fila)("pro_codigo") > 0 Then
                        If GUARDA_DET_MOVIMINETO(conexion, _Folio, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_cantidad")), CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_bultos")), CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_totalbultos"))) = False Then
                            Return False
                            Exit Function
                        End If

                        If ACTUALIZA_STOCK_BODEGA(conexion, GLO_BODEGA_RECEPCION, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), TIPO_MOVIMIENTO.SALIDA, CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_cantidad"))) = False Then
                            Return False
                            Exit Function
                        End If
                    Else
                        MessageBox.Show("Se produjo un error en el procedimiento de traspaso de movimiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                        Exit Function
                    End If
                End If
            Else
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
                Exit Function
            End If

            'FIN SALIDA DE BODEGA DE ORIGEN
            '=============================================================

            'ENTRADA A BODEGA DE DESTINO
            '=============================================================
            _Folio = 0
            If GUARDA_ENC_MOVIMINETO(conexion, 0, TIPO_MOVIMIENTO.ENTRADA, GLO_BODEGA_PRODUCTO_TERMINADO, _fecha, mes, _fecha.Year, GLO_USUARIO_ACTUAL, 0,
                                        COM_TIPO_DOCUMENTO.VALE_DE_INGRESO, 0, _FolioRelacionado, _Observacion, "-", CLng(0), _Folio) = False Then
                Return False
                Exit Function
            End If

            If ELIMINA_DETALLE_MOVIMIENTO(conexion, _Folio) = False Then
                Return False
                Exit Function
            End If

            dsUbicacion = Nothing
            classUbicaciones.pallet = SELECCIONA_PARA_TRASPASAR()
            dsUbicacion = classUbicaciones.DATOS_PARA_TRASPASO_A_PISO_PT(_msgError, conexion)
            If _msgError = "" Then
                If dsUbicacion.Tables(0).Rows.Count > 0 Then
                    If dsUbicacion.Tables(0).Rows(fila)("pro_codigo") > 0 Then
                        If GUARDA_DET_MOVIMINETO(conexion, _Folio, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_cantidad")), CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_bultos")), CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_totalbultos"))) = False Then
                            Return False
                            Exit Function
                        End If

                        If ACTUALIZA_STOCK_BODEGA(conexion, GLO_BODEGA_PRODUCTO_TERMINADO, dsUbicacion.Tables(0).Rows(fila)("pro_codigo"), TIPO_MOVIMIENTO.ENTRADA, CInt(dsUbicacion.Tables(0).Rows(fila)("dmo_cantidad"))) = False Then
                            Return False
                            Exit Function
                        End If
                    End If
                Else
                    MessageBox.Show("Se produjo un error en el procedimiento de traspaso de movimiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                    Exit Function
                End If
            Else
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
                Exit Function
            End If

            ''FIN ENTRADA A BODEGA DE DESTINO
            ''=============================================================

            'Transaccion.Complete()
            'Transaccion.Dispose()
            'If conexion.State = ConnectionState.Open Then
            '    conexion.Close()
            'End If

            GUARDA_MOVIMIENTO = True


        Catch ex As Exception
            GUARDA_MOVIMIENTO = False
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function SELECCIONA_PARA_TRASPASAR() As String
        Dim strPallet As String = ""

        For Each row As DataGridViewRow In Me.Grilla.Rows
            If strPallet = "" Then
                strPallet = row.Cells(CONST_SERIE_PALLET).Value
            Else
                strPallet = strPallet + "," + row.Cells(CONST_SERIE_PALLET).Value
            End If
        Next

        If strPallet <> "" Then
            strPallet = strPallet + ","
        End If

        SELECCIONA_PARA_TRASPASAR = strPallet

    End Function


    Private Function ENVIA_PALLET_A_PT(ByVal strPallet As String, ByVal conexion As SqlConnection) As Boolean
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim _msgError As String = ""
        Dim ds As DataSet

        ENVIA_PALLET_A_PT = False

        Try
            'Guarda cabecera del documento
            ds = Nothing
            classUbicaciones.pallet = strPallet
            classUbicaciones.ubi_codigo = GLO_UBI_PISO_PRODUCTO_TERMINADO

            ds = classUbicaciones.ACTUALIZA_UBICACIONES_A_PISO_PT(_msgError, conexion)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            Else
                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Exit Function
                End If
            End If

            ENVIA_PALLET_A_PT = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub cmbUbicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectedIndexChanged

    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged

    End Sub
End Class