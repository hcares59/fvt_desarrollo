Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_kpi
    Private _cnn As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Private Sub optEntreFecha_CheckedChanged(sender As Object, e As EventArgs) Handles optEntreFecha.CheckedChanged
        Call ACTIVA_CAJA()
    End Sub

    Private Sub ACTIVA_CAJA()
        If optEntreFecha.Checked = True Then
            boxEntreFechas.Visible = True
            boxEntrePeriodos.Visible = False
            boxPeriodo.Visible = False
        ElseIf optEntrePeriodos.Checked = True Then
            boxEntreFechas.Visible = False
            boxEntrePeriodos.Visible = True
            boxPeriodo.Visible = False
        ElseIf optPorPeriodo.Checked = True Then
            boxEntreFechas.Visible = False
            boxEntrePeriodos.Visible = False
            boxPeriodo.Visible = True
        End If
    End Sub

    Private Sub optEntrePeriodos_CheckedChanged(sender As Object, e As EventArgs) Handles optEntrePeriodos.CheckedChanged
        Call ACTIVA_CAJA()
        Call CARGA_PERIODO_DESDE_MESES()
    End Sub
    Private Sub CARGA_PERIODO_DESDE_MESES()
        Dim _msg As String
        Try
            Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
            Dim ds As DataSet = New DataSet

            ds = Nothing

            classTipoInforme.cnn = _cnn
            classTipoInforme.meseSeleccionado = 0
            _msg = ""
            ds = classTipoInforme.MESES_CARGA_COMBO(_msg)
            If _msg = "" Then
                cmbPeriodoDesdeMes.DataSource = ds.Tables(0)
                cmbPeriodoDesdeMes.DisplayMember = "mes_nombre"
                cmbPeriodoDesdeMes.ValueMember = "mes_codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_PERIODO_MESES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub optPorPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles optPorPeriodo.CheckedChanged
        Call CARGA_PERIODO_MESES()
        Call ACTIVA_CAJA()
    End Sub

    Private Sub frm_kpi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LIMPIAR()
    End Sub

    Private Sub LIMPIAR()
        optEntreFecha.Checked = True
        boxEntreFechas.Visible = True
        boxEntrePeriodos.Visible = False
        boxPeriodo.Visible = False

        txtPeriodoAno.Text = GLO_FECHA_SISTEMA.Year
        txtPeriodoDesdeAno.Text = GLO_FECHA_SISTEMA.Year
        txtPeriodoHastaAno.Text = GLO_FECHA_SISTEMA.Year

        txtFechaDesde.Text = GLO_FECHA_SISTEMA
        txtFechaHasta.Text = GLO_FECHA_SISTEMA

        Call CARGA_TIPO_INFORME()
        Call CARGA_CLIENTE_CON_INCLUIR()
        Call CARGA_CLIENTE_SIN_INCLUIR()
    End Sub

    Private Sub CARGA_TIPO_INFORME()
        Dim _msg As String
        Try
            Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
            Dim ds As DataSet = New DataSet

            ds = Nothing

            classTipoInforme.cnn = _cnn
            _msg = ""
            ds = classTipoInforme.TIPO_INFORME_KPI_CARGA_COMBO(_msg)
            If _msg = "" Then
                cmbInformes.DataSource = ds.Tables(0)
                cmbInformes.DisplayMember = "mensaje"
                cmbInformes.ValueMember = "codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_BODEGAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_PERIODO_MESES()
        Dim _msg As String
        Try
            Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
            Dim ds As DataSet = New DataSet

            ds = Nothing

            classTipoInforme.cnn = _cnn
            classTipoInforme.meseSeleccionado = 0
            _msg = ""
            ds = classTipoInforme.MESES_CARGA_COMBO(_msg)
            If _msg = "" Then
                cmbPeriodoMes.DataSource = ds.Tables(0)
                cmbPeriodoMes.DisplayMember = "mes_nombre"
                cmbPeriodoMes.ValueMember = "mes_codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_PERIODO_MESES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_CLIENTE_SIN_INCLUIR()
        Dim classCartera As class_cartera = New class_cartera

        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classCartera.cnn = _cnn
            classCartera.porDefecto = False
            _msg = ""
            GrillaSinInc.Rows.Clear()
            ds = classCartera.CLIENTE_PARA_INFORME_KPI(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            If VALIDA_CLIENTE_EN_GRILLA(ds.Tables(0).Rows(Fila)("car_codigo")) = False Then
                                GrillaSinInc.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                        False,
                                        ds.Tables(0).Rows(Fila)("car_nombre"))
                            End If
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_PRODUCTOS_SIN_INCLUIR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_PRODUCTOS_SIN_INCLUIR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Function VALIDA_CLIENTE_EN_GRILLA(ByVal codCliente As Integer) As Boolean
        Dim fila As Integer = 0

        VALIDA_CLIENTE_EN_GRILLA = False
        Do While fila <= GrillaConInc.RowCount - 1
            If GrillaConInc.Rows(fila).Cells(0).Value = codCliente Then
                VALIDA_CLIENTE_EN_GRILLA = True
                Exit Function
            End If
            fila = fila + 1
        Loop
    End Function

    Private Sub CARGA_CLIENTE_CON_INCLUIR()
        Dim classCartera As class_cartera = New class_cartera

        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classCartera.cnn = _cnn
            classCartera.porDefecto = True
            _msg = ""
            GrillaConInc.Rows.Clear()
            ds = classCartera.CLIENTE_PARA_INFORME_KPI(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaConInc.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                        False,
                                        ds.Tables(0).Rows(Fila)("car_nombre"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_CLIENTE_CON_INCLUIR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_CLIENTE_CON_INCLUIR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btn_selecciona_Click(sender As Object, e As EventArgs) Handles btn_selecciona.Click
        Dim nomCliente As String = ""
        Dim codCliente As Integer = 0
        Dim Opcion As Boolean = False
        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            codCliente = row.Cells(0).Value
            nomCliente = row.Cells(2).Value
            Opcion = row.Cells(1).Value
            If Opcion = True Then
                GrillaConInc.Rows.Add(codCliente, False, nomCliente)
            End If
        Next
        Call CARGA_CLIENTE_SIN_INCLUIR()
    End Sub

    Private Sub btn_deselecciona_Click(sender As Object, e As EventArgs) Handles btn_deselecciona.Click
        Dim fila As Integer = 0
        Dim elimino As Boolean = False
        Do While fila <= GrillaConInc.RowCount - 1
            elimino = False
            If GrillaConInc.Rows(fila).Cells(1).Value = True Then
                GrillaConInc.Rows.RemoveAt(fila)
                elimino = True
            End If
            If elimino = False Then
                fila = fila + 1
            End If

        Loop
        Call CARGA_CLIENTE_SIN_INCLUIR()

    End Sub

    Private Sub cmbPeriodoDesdeMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoDesdeMes.SelectedIndexChanged

    End Sub

    Private Sub cmbPeriodoDesdeMes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbPeriodoDesdeMes.SelectionChangeCommitted
        If cmbPeriodoDesdeMes.SelectedValue > 0 Then
            Call CARGA_PERIODO_HASTA_MESES()
        End If
    End Sub

    Private Sub CARGA_PERIODO_HASTA_MESES()
        Dim _msg As String
        Try
            Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
            Dim ds As DataSet = New DataSet

            ds = Nothing

            classTipoInforme.cnn = _cnn
            classTipoInforme.meseSeleccionado = cmbPeriodoDesdeMes.SelectedValue
            _msg = ""
            ds = classTipoInforme.MESES_CARGA_COMBO(_msg)
            If _msg = "" Then
                cmbPeriodoHastaMes.DataSource = ds.Tables(0)
                cmbPeriodoHastaMes.DisplayMember = "mes_nombre"
                cmbPeriodoHastaMes.ValueMember = "mes_codigo"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_PERIODO_HASTA_MESES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call LIMPIAR()
    End Sub

    Private Sub ButtonImprime_Click(sender As Object, e As EventArgs) Handles ButtonImprime.Click
        Dim _codigoCliente As String = ""
        Dim _fecha_desde As String = ""
        Dim _fecha_hasta As String = ""
        Dim mesIngresoDesde As String = ""
        Dim diaIngresoDesde As String = ""
        Dim mesIngresoHasta As String = ""
        Dim diaIngresoHasta As String = ""
        Dim ultimaFecha As Date
        Dim ultimoDia As String = ""
        Dim fechaFinal As Date

        Me.Cursor = Cursors.WaitCursor

        Try



            For Each row As DataGridViewRow In Me.GrillaConInc.Rows
                If row.Cells(1).Value = True Then
                    If _codigoCliente = "" Then
                        _codigoCliente = row.Cells(0).Value.ToString
                    Else
                        _codigoCliente = _codigoCliente + "," + row.Cells(0).Value.ToString
                    End If
                End If
            Next

            If _codigoCliente = "" Then
                MessageBox.Show("Debe seleccionar a lo menos un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                GrillaConInc.Focus()
                Exit Sub
            End If

            If optEntreFecha.Checked = True Then
                'Fecha desde
                If CStr(txtFechaDesde.Value.Month).Length = 1 Then
                    mesIngresoDesde = Trim("0" + CStr(txtFechaDesde.Value.Month))
                Else
                    mesIngresoDesde = CStr(txtFechaDesde.Value.Month)
                End If

                If CStr(txtFechaDesde.Value.Day).Length = 1 Then
                    diaIngresoDesde = Trim("0" + CStr(txtFechaDesde.Value.Day))
                Else
                    diaIngresoDesde = CStr(txtFechaDesde.Value.Day)
                End If

                _fecha_desde = CStr(txtFechaDesde.Value.Year) + mesIngresoDesde + diaIngresoDesde

                'Fecha hasta
                If CStr(txtFechaHasta.Value.Month).Length = 1 Then
                    mesIngresoHasta = Trim("0" + CStr(txtFechaHasta.Value.Month))
                Else
                    mesIngresoHasta = CStr(txtFechaHasta.Value.Month)
                End If

                If CStr(txtFechaHasta.Value.Day).Length = 1 Then
                    mesIngresoHasta = Trim("0" + CStr(txtFechaHasta.Value.Day))
                Else
                    mesIngresoHasta = CStr(txtFechaHasta.Value.Day)
                End If

                _fecha_hasta = CStr(txtFechaHasta.Value.Year) + mesIngresoHasta + mesIngresoHasta

            ElseIf optEntrePeriodos.Checked = True Then
                If txtPeriodoDesdeAno.Text = "" Or txtPeriodoDesdeAno.Text = "0" Then
                    MessageBox.Show("Debe ingresar el año desde", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtPeriodoDesdeAno.Focus()
                    Exit Sub
                End If

                If txtPeriodoHastaAno.Text = "" Or txtPeriodoHastaAno.Text = "0" Then
                    MessageBox.Show("Debe ingresar el año hasta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtPeriodoHastaAno.Focus()
                    Exit Sub
                End If

                'fecha desde
                If CStr(cmbPeriodoDesdeMes.SelectedValue).Length = 1 Then
                    mesIngresoDesde = Trim("0" + CStr(cmbPeriodoDesdeMes.SelectedValue))
                Else
                    mesIngresoDesde = CStr(cmbPeriodoDesdeMes.SelectedValue)
                End If

                _fecha_desde = CStr(txtPeriodoDesdeAno.Text) + mesIngresoDesde + "01"

                'fecha hasta
                If CStr(cmbPeriodoHastaMes.SelectedValue).Length = 1 Then
                    mesIngresoHasta = Trim("0" + CStr(cmbPeriodoHastaMes.SelectedValue))
                Else
                    mesIngresoHasta = CStr(cmbPeriodoHastaMes.SelectedValue)
                End If

                ultimaFecha = CDate("01-" + mesIngresoHasta + "-" + CStr(txtPeriodoHastaAno.Text))
                fechaFinal = (DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, ultimaFecha)))
                If CStr(fechaFinal.Day).Length = 1 Then
                    ultimoDia = Trim("0" + CStr(fechaFinal.Day))
                Else
                    ultimoDia = CStr(fechaFinal.Day)
                End If

                _fecha_hasta = CStr(txtPeriodoHastaAno.Text) + mesIngresoHasta + ultimoDia
            ElseIf optPorPeriodo.Checked = True Then
                'fecha desde
                If CStr(cmbPeriodoMes.SelectedValue).Length = 1 Then
                    mesIngresoDesde = Trim("0" + CStr(cmbPeriodoMes.SelectedValue))
                Else
                    mesIngresoDesde = CStr(cmbPeriodoMes.SelectedValue)
                End If

                _fecha_desde = CStr(txtPeriodoAno.Text) + mesIngresoDesde + "01"

                'fecha hasta
                If CStr(cmbPeriodoMes.SelectedValue).Length = 1 Then
                    mesIngresoHasta = Trim("0" + CStr(cmbPeriodoMes.SelectedValue))
                Else
                    mesIngresoHasta = CStr(cmbPeriodoMes.SelectedValue)
                End If

                ultimaFecha = CDate("01-" + mesIngresoHasta + "-" + CStr(txtPeriodoHastaAno.Text))
                fechaFinal = (DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, ultimaFecha)))
                If CStr(fechaFinal.Day).Length = 1 Then
                    ultimoDia = Trim("0" + CStr(fechaFinal.Day))
                Else
                    ultimoDia = CStr(fechaFinal.Day)
                End If

                _fecha_hasta = CStr(txtPeriodoAno.Text) + mesIngresoHasta + ultimoDia.ToString

            End If

            If cmbInformes.SelectedValue = 1 Then
                Call IMPRIME_VENTAS_PENDIENTES(_codigoCliente, _fecha_desde, _fecha_hasta)
            ElseIf cmbInformes.SelectedValue = 3 Then
                Call IMPRIME_INFORME_KPI_FACTURAS_RENDIDAS_VS_POR_RENDIR(_codigoCliente, _fecha_desde, _fecha_hasta)
            ElseIf cmbInformes.SelectedValue = 4 Then
                Call IMPRIME_INFORME_KPI_COMPRAS_VS_DESPACHO(_codigoCliente, _fecha_desde, _fecha_hasta)
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub IMPRIME_INFORME_KPI_COMPRAS_VS_DESPACHO(ByVal _codigoCliente As String, ByVal _fecha_desde As String, ByVal _fecha_hasta As String)
        Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim tipoInforme As Integer = 0

        If cmbInformes.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar un tipo de informe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbInformes.Focus()
            Exit Sub
        End If

        Try
            classTipoInforme.cnn = _cnn

            ' ingresa data para informe
            classTipoInforme.usu_codigo = GLO_USUARIO_ACTUAL
            classTipoInforme.cod_cliente = _codigoCliente
            classTipoInforme.fecha_desde = _fecha_desde
            classTipoInforme.fecha_hasta = _fecha_hasta

            ds = classTipoInforme.CARGA_DATOS_PARA_TABLA_INFORME_KPI_COMPRA_VS_DESPACHO(_msgError)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "INFORME: " + cmbInformes.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "CARGA_DATOS_PARA_TABLA_INFORME_KPI_COMPRA_VS_DESPACHO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                End If
            End If

            System.Diagnostics.Process.Start(strRutaIngformesExcel + "INFORME SOLICITADOS VS DESPACHADOS.xlsm")

            tipoInforme = GLO_INF_COMPRAS_VS_DESPACHO

            'limpiar tabla informe
            ds = Nothing
            classTipoInforme.usu_codigo = GLO_USUARIO_ACTUAL
            classTipoInforme.tipo_informe = tipoInforme
            ds = classTipoInforme.LIMPIA_TABLA_INFORME_KPI(_msgError)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "INFORME: " + cmbInformes.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "CARGA_DATOS_PARA_TABLA_INFORME_KPI_COMPRA_VS_DESPACHO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub IMPRIME_INFORME_KPI_FACTURAS_RENDIDAS_VS_POR_RENDIR(ByVal _codigoCliente As String, ByVal _fecha_desde As String, ByVal _fecha_hasta As String)
        Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim tipoInforme As Integer = 0

        If cmbInformes.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar un tipo de informe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbInformes.Focus()
            Exit Sub
        End If

        Try
            classTipoInforme.cnn = _cnn

            ' ingresa data para informe
            classTipoInforme.usu_codigo = GLO_USUARIO_ACTUAL
            classTipoInforme.cod_cliente = _codigoCliente
            classTipoInforme.fecha_desde = _fecha_desde
            classTipoInforme.fecha_hasta = _fecha_hasta

            ds = classTipoInforme.CARGA_DATOS_PARA_TABLA_INFORME_KPI_FACTURAS_RENDIDAS_VS_POR_RENDIR(_msgError)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "INFORME: " + cmbInformes.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "IMPRIME_INFORME_KPI_FACTURAS_RENDIDAS_VS_POR_RENDIR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                End If
            End If

            System.Diagnostics.Process.Start(strRutaIngformesExcel + "INF_FACT_RENDIDAS_Y_POR_RENDIR.xlsm")

            tipoInforme = GLO_INF_FACTURAS_RENDIDAS_VS_POR_RENDIR

            'limpiar tabla informe
            ds = Nothing
            classTipoInforme.usu_codigo = GLO_USUARIO_ACTUAL
            classTipoInforme.tipo_informe = tipoInforme
            ds = classTipoInforme.LIMPIA_TABLA_INFORME_KPI(_msgError)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "INFORME: " + cmbInformes.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "IMPRIME_INFORME_KPI_FACTURAS_RENDIDAS_VS_POR_RENDIR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub IMPRIME_VENTAS_PENDIENTES(ByVal _codigoCliente As String, ByVal _fecha_desde As String, ByVal _fecha_hasta As String)
        Dim classTipoInforme As class_tipo_informe_kpi = New class_tipo_informe_kpi
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""

        Dim tipoInforme As Integer = 0

        If cmbInformes.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar un tipo de informe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbInformes.Focus()
            Exit Sub
        End If

        Try
            classTipoInforme.cnn = _cnn

            ' ingresa data para informe
            classTipoInforme.usu_codigo = GLO_USUARIO_ACTUAL
            classTipoInforme.cod_cliente = _codigoCliente
            classTipoInforme.fecha_desde = _fecha_desde
            classTipoInforme.fecha_hasta = _fecha_hasta

            ds = classTipoInforme.CARGA_DATOS_PARA_TABLA_INFORME_KPI_VENTA_PENDIENTE(_msgError)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "INFORME: " + cmbInformes.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "IMPRIME_VENTAS_PENDIENTES", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                End If
            End If

            System.Diagnostics.Process.Start(strRutaIngformesExcel + "INFORME VENTAS PENDIENTES.xlsm")

            tipoInforme = GLO_INF_VENTAS_PENDIENTES

            'limpiar tabla informe
            ds = Nothing
            classTipoInforme.usu_codigo = GLO_USUARIO_ACTUAL
            classTipoInforme.tipo_informe = tipoInforme
            ds = classTipoInforme.LIMPIA_TABLA_INFORME_KPI(_msgError)
            If ds.Tables(0).Rows.Count > 0 Then
                If _msgError = "" Then
                    If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), "INFORME: " + cmbInformes.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                    End If
                Else
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    MessageBox.Show(_msgError, "IMPRIME_VENTAS_PENDIENTES", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ds = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaConInc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaConInc.CellContentClick
        If e.ColumnIndex = Me.GrillaConInc.Columns.Item(1).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaConInc.Rows(e.RowIndex).Cells(1)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub GrillaSinInc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSinInc.CellContentClick
        If e.ColumnIndex = Me.GrillaSinInc.Columns.Item(1).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaSinInc.Rows(e.RowIndex).Cells(1)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub ButtonSMarcar_Click(sender As Object, e As EventArgs) Handles ButtonSMarcar.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub ButtonSDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonSDesmarcar.Click
        DESMARCAR_TODOS()
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaSinInc.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub ButtonAMarcar_Click(sender As Object, e As EventArgs) Handles ButtonAMarcar.Click
        MARCAR_TODOS_CON_R()
    End Sub
    Private Sub MARCAR_TODOS_CON_R()
        For Each row As DataGridViewRow In Me.GrillaConInc.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub ButtonADesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonADesmarcar.Click
        DESMARCAR_TODOS_CON_R()
    End Sub
    Private Sub DESMARCAR_TODOS_CON_R()
        For Each row As DataGridViewRow In Me.GrillaConInc.Rows
            row.Cells(1).Value = False
        Next
    End Sub
End Class