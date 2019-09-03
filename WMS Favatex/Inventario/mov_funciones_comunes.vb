Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Module mov_funciones_comunes

    Public Function GUARDA_ENC_MOVIMINETO(ByVal conexion As SqlConnection, ByVal mov_folio As Integer, ByVal tmo_codigo As Integer, ByVal bod_codigo As Integer,
        ByVal mov_fechamovimiento As Date, ByVal mov_mes As String, ByVal mov_anno As Integer, ByVal mov_usuario As Integer,
        ByVal car_codigo As Integer, ByVal tdo_codigo As Integer, ByVal mov_nomdoc As Integer, ByVal mov_foliorelacionado As Integer,
        ByVal mov_observacion As String, ByVal mov_tipomovmanager As String, ByVal mov_nummovmanager As Long, ByRef _NewFolio As Integer) As Boolean

        Dim classMOV As class_movimientos = New class_movimientos
        Dim dsMov As DataSet = New DataSet
        Dim _Folio As Integer = 0
        Dim _msgError As String = ""

        Try
            classMOV.mov_folio = mov_folio
            classMOV.tmo_codigo = tmo_codigo
            classMOV.bod_codigo = bod_codigo
            classMOV.mov_fechamovimiento = mov_fechamovimiento
            classMOV.mov_mes = mov_mes
            classMOV.mov_anno = mov_anno
            classMOV.mov_usuario = mov_usuario
            classMOV.car_codigo = car_codigo
            classMOV.tdo_codigo = tdo_codigo
            classMOV.mov_nomdoc = mov_nomdoc
            classMOV.mov_foliorelacionado = mov_foliorelacionado
            classMOV.mov_observacion = mov_observacion
            classMOV.mov_tipomovmanager = mov_tipomovmanager
            classMOV.mov_nummovmanager = mov_nummovmanager
            dsMov = classMOV.MOVIMIENTOS_GUARDA_ENCABEZADO(_msgError, conexion)
            If dsMov.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), "INGRESO ENCABEZADO MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dsMov = Nothing
                        Return False
                        Exit Function
                    Else
                        _NewFolio = dsMov.Tables(0).Rows(0)("CODIGO")
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "INGRESO ENCABEZADO MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dsMov = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GUARDA_DET_MOVIMINETO(ByVal conexion As SqlConnection, ByVal mov_folio As Integer, ByVal pro_codigo As Integer, ByVal dmo_cantidad As Integer,
        ByVal dmo_bultos As Integer, ByVal dmo_totalbultos As Integer) As Boolean

        Dim classMOV As class_movimientos = New class_movimientos
        Dim dsMov As DataSet = New DataSet
        Dim _Folio As Integer = 0
        Dim _msgError As String = ""

        Try
            classMOV.mov_folio = mov_folio
            classMOV.pro_codigo = pro_codigo
            classMOV.dmo_cantidad = dmo_cantidad
            classMOV.dmo_bultos = dmo_bultos
            classMOV.dmo_totalbultos = dmo_totalbultos

            dsMov = classMOV.MOVIMIENTOS_GUARDA_DETALLE(_msgError, conexion)
            If dsMov.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), "GUARDA_DET_MOVIMINETO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dsMov = Nothing
                        Return False
                        Exit Function
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "GUARDA_DET_MOVIMINETO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dsMov = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ELIMINA_DETALLE_MOVIMIENTO(ByVal conexion As SqlConnection, ByVal mov_folio As Integer) As Boolean
        Dim classMOV As class_movimientos = New class_movimientos
        Dim dsMov As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            classMOV.mov_folio = mov_folio
            dsMov = classMOV.ELIMINA_DETALLE_MOVIMIENTO(_msgError, conexion)
            If _msgError <> "" Then
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                dsMov = Nothing
                MessageBox.Show(_msgError, "ELIMINA_DETALLE_MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
                Exit Function
            Else
                If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If

                    MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), "ELIMINA_DETALLE_MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dsMov = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function MARCA_SERIE_MOVIMIENTO(ByVal conexion As SqlConnection, ByVal prs_serie As String, ByVal prd_palletserie As String, ByVal bod_codigo As Integer) As Boolean
        Dim classRec As class_recepcion = New class_recepcion
        Dim dsMov As DataSet = New DataSet
        Dim _Folio As Integer = 0
        Dim _msgError As String = ""

        Try
            classRec.prs_serie = prs_serie
            classRec.prd_palletserie = prd_palletserie
            classRec.bod_codigo = bod_codigo
            dsMov = classRec.MARCA_SALIDA_SERIE_MOVIMIENTO(_msgError, conexion)
            If dsMov.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), "MARCA_SERIE_MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dsMov = Nothing
                        Return False
                        Exit Function
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "MARCA_SERIE_MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dsMov = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GUARDA_PRODUCTO_SERIE_MOVIMIENTO(ByVal conexion As SqlConnection, ByVal prs_serie As String, ByVal prd_palletserie As String,
        ByVal bod_codigo As Integer, ByVal mov_folio As Long, ByVal usu_codigo As Integer, ByVal observacion As String, ByVal prm_tipo As String,
        ByVal pro_codigo As Integer, ByVal bod_destino As Integer) As Boolean

        Dim classMOV As class_movimientos = New class_movimientos
        Dim dsMov As DataSet = New DataSet
        Dim _Folio As Integer = 0
        Dim _msgError As String = ""

        Try
            classMOV.prs_serie = prs_serie
            classMOV.prd_palletserie = prd_palletserie
            classMOV.bod_codigo = bod_codigo
            classMOV.mov_folio = mov_folio
            classMOV.usu_codigo = usu_codigo
            classMOV.observacion = observacion
            classMOV.prm_tipo = prm_tipo
            classMOV.pro_codigo = pro_codigo
            classMOV.bod_destino = bod_destino
            dsMov = classMOV.PRODUCTO_SERIE_MOVIMIENTO_GUARDA(_msgError, conexion)
            If dsMov.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), "GUARDA_PRODUCTO_SERIE_MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dsMov = Nothing
                        Return False
                        Exit Function
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "GUARDA_PRODUCTO_SERIE_MOVIMIENTO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dsMov = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ACTUALIZA_STOCK_BODEGA(ByVal conexion As SqlConnection, ByVal bod_codigo As Integer, ByVal pro_codigo As Integer, ByVal tmo_codigo As Integer, ByVal cantidad As Integer) As Boolean
        Dim classInv As class_inventario = New class_inventario
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            classInv.bod_codigo = bod_codigo
            classInv.pro_codigo = pro_codigo
            classInv.tmo_codigo = tmo_codigo
            classInv.cantidad = cantidad
            ds = classInv.ACTUALIZA_STOCK_MOVIMIENTOS(_msgError, conexion)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "ACTUALIZA_STOCK_BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Return False
                        Exit Function
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "ACTUALIZA_STOCK_BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ACTULIZA_UBICACION_DEL_PALLET(ByVal conexion As SqlConnection, ByVal usuCodigo As Integer) As Boolean
        Dim classRec As class_recepcion = New class_recepcion
        Dim dsMov As DataSet = New DataSet
        Dim _Folio As Integer = 0
        Dim _msgError As String = ""

        Try
            classRec.usu_codigo = usuCodigo
            dsMov = classRec.ACTUALIZA_UBICACIONES_PALLET(_msgError, conexion)
            If dsMov.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), "ACTULIZA_UBICACION_DEL_PALLET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dsMov = Nothing
                        Return False
                        Exit Function
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "ACTULIZA_UBICACION_DEL_PALLET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dsMov = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ELIMINA_UBICACIONES_TEMPORALES(ByVal conexion As SqlConnection, ByVal usu_codigo As Integer) As Boolean
        Dim classInv As class_inventario = New class_inventario
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            classInv.usu_codigo = usu_codigo
            ds = classInv.ELIMINA_UBICACIONES_TEMPORALES(_msgError, conexion)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "ELIMINA_UBICACIONES_TEMPORALES", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Return False
                        Exit Function
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "ELIMINA_UBICACIONES_TEMPORALES", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ACTUALIZA_ITEM_RECEPCION(ByVal conexion As SqlConnection, ByVal rec_numero As Integer, ByVal pro_codigo As Integer, ByVal cantidad_recepcionada As Integer) As Boolean
        Dim classRec As class_recepcion = New class_recepcion
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Try
            classRec.rec_numero = rec_numero
            classRec.pro_codigo = pro_codigo
            classRec.cant_resepcionada = cantidad_recepcionada
            ds = classRec.ACTUALIZA_ESTADO_ITEM_RECEPCION(_msgError, conexion)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "ACTUALIZA_ITEM_RECEPCION", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Return False
                        Exit Function
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "ACTUALIZA_ITEM_RECEPCION", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function VERIFICA_PRODUCTO_EN_BODEGA(ByVal _cnn As String, ByVal bod_codigo As Integer, ByVal pro_codigo As Integer) As Boolean
        Dim classInv As class_inventario = New class_inventario
        Dim dsInventario As DataSet = New DataSet
        Dim _msgError As String = ""

        VERIFICA_PRODUCTO_EN_BODEGA = False
        classInv.cnn = _cnn
        classInv.bod_codigo = bod_codigo
        classInv.pro_codigo = pro_codigo
        dsInventario = classInv.VERIFICA_PRODUCTO_BODEGA_SIN_TRANSACCION(_msgError)
        If _msgError <> "" Then
            VERIFICA_PRODUCTO_EN_BODEGA = False
            MessageBox.Show(_msgError, "VERIFICA_PRODUCTO_EN_BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Else
            If dsInventario.Tables(0).Rows(0)("CODIGO") < 0 Then
                VERIFICA_PRODUCTO_EN_BODEGA = False
                MessageBox.Show(dsInventario.Tables(0).Rows(0)("mensaje"), "VERIFICA_PRODUCTO_EN_BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsInventario = Nothing
                Exit Function
            ElseIf dsInventario.Tables(0).Rows(0)("CODIGO") > 0 Then
                VERIFICA_PRODUCTO_EN_BODEGA = True
            End If
        End If
        Return VERIFICA_PRODUCTO_EN_BODEGA
    End Function

    Public Function GENERA_PALLET_PARA_SSTT(ByVal conexion As SqlConnection, ByVal rec_numero As Integer, ByVal ubi_codigo As Integer, ByVal cantidad As Integer) As String
        Dim classMOV As class_movimientos = New class_movimientos
        Dim dsMov As DataSet = New DataSet
        Dim _Folio As Integer = 0
        Dim _msgError As String = ""

        GENERA_PALLET_PARA_SSTT = ""
        Try
            classMOV.rec_codigo = rec_numero
            classMOV.ubi_codigo = ubi_codigo
            classMOV.cantidad = cantidad

            dsMov = classMOV.GENERA_PALLET_SSTT(_msgError, conexion)
            If dsMov.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If dsMov.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(dsMov.Tables(0).Rows(0)("mensaje"), "GENERA_PALLET_PARA_SSTT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dsMov = Nothing
                        Return False
                        Exit Function
                    Else
                        GENERA_PALLET_PARA_SSTT = dsMov.Tables(0).Rows(0)("mensaje")
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "GENERA_PALLET_PARA_SSTT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dsMov = Nothing
                    Return False
                    Exit Function
                End If
            End If
            Return GENERA_PALLET_PARA_SSTT
        Catch ex As Exception
            Return GENERA_PALLET_PARA_SSTT
        End Try
    End Function

    Public Function DESCUENTA_CANTIDAD_ULTIMO_PALLET(ByVal conexion As SqlConnection, ByVal pro_codigo As Integer, ByVal rec_codigo As Integer, ByVal cantidad As Integer, ByVal SeriePallet As String) As Boolean
        Dim classMov As class_movimientos = New class_movimientos
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        DESCUENTA_CANTIDAD_ULTIMO_PALLET = False
        classMov.pro_codigo = pro_codigo
        classMov.rec_codigo = rec_codigo
        classMov.cantidad = cantidad
        classMov.prd_palletserie = SeriePallet

        ds = classMov.ACTUALIZA_CANTIDADES_PARA_MUESTRA_SSTT(_msgError, conexion)
        If _msgError <> "" Then
            DESCUENTA_CANTIDAD_ULTIMO_PALLET = False
            MessageBox.Show(_msgError, "DESCUENTA_CANTIDAD_ULTIMO_PALLET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Else
            If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                DESCUENTA_CANTIDAD_ULTIMO_PALLET = False
                MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "DESCUENTA_CANTIDAD_ULTIMO_PALLET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ds = Nothing
                Exit Function
            ElseIf ds.Tables(0).Rows(0)("CODIGO") > 0 Then
                DESCUENTA_CANTIDAD_ULTIMO_PALLET = True
            End If
        End If
        Return DESCUENTA_CANTIDAD_ULTIMO_PALLET
    End Function

End Module
