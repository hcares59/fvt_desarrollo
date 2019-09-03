Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frm_ingreso_agenda
    Private _cnn As String
    Private _cit_codigo As Integer
    Private _eag_codigo As Integer
    Private _age_codigoNew As Integer

    'COLUMNAS GRILLA ENCABEZADO
    Const col_SEL As Integer = 0
    Const col_O_COMPRA As Integer = 1
    Const col_FECHA As Integer = 2
    Const col_MONTO As Integer = 3
    Const col_ES_ABIERTA As Integer = 4

    'COLUMNAS GRILLA DETALLE
    Const C_OC As Integer = 0
    Const C_FILA_CONSO As Integer = 1
    Const C_PRO_CODIGO As Integer = 2
    Const C_C_INTERNO As Integer = 3
    Const C_NOMBRE_FAVATEX As Integer = 4
    Const C_SKU_CLIENTE As Integer = 5
    Const C_NOMBRE_CLIENTE As Integer = 6
    Const C_PRECIO As Integer = 7
    Const C_CANTIDAD As Integer = 8
    Const C_SALDO As Integer = 9
    Const C_C_AGENDADA As Integer = 11


    Private cellTextBox As DataGridViewTextBoxEditingControl
    Dim PrecionaTeclaDesde As String = ""

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property eag_codigo() As Integer
        Get
            Return _eag_codigo
        End Get
        Set(ByVal value As Integer)
            _eag_codigo = value
        End Set
    End Property
    Public Property age_codigoNew() As Integer
        Get
            Return _age_codigoNew
        End Get
        Set(ByVal value As Integer)
            _age_codigoNew = value
        End Set
    End Property

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA() = False Then
            Exit Sub
        End If

        If VALIDA_DATOS_FAVATEX() > 0 Then
            MessageBox.Show("Existe productos en el detalle que no tienen código FAVATEX asociado, para generar la agenda debe existir la relación entre SKU Cliente y Código Interno, pongace en contacto con el administrador de productos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Call GUARDA_DATOS()

    End Sub

    Private Function VALIDA_DATOS_FAVATEX() As Integer
        Dim contador As Integer = 0
        Try
            contador = 0
            For Each row As DataGridViewRow In Me.grillaDetalle.Rows
                If row.Cells(C_NOMBRE_FAVATEX).Value.ToString = "" Then
                    contador = contador + 1
                End If
            Next
            VALIDA_DATOS_FAVATEX = contador
        Catch ex As Exception
            VALIDA_DATOS_FAVATEX = 0
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub GUARDA_DATOS()
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                ButtonConfirmar.Enabled = False
                conexion.Open()
                classAgenda.age_codigo = _age_codigoNew
                classAgenda.car_codigo = cmbCliente.SelectedValue
                classAgenda.age_ordencompra = txtOrdenCompra.Text
                classAgenda.age_fechaorden = CDate(txtFechaOrdenCompra.Text)

                If chkPorconfirmar.Checked = True Then
                    classAgenda.eag_codigo = ESTADOS_AGENDA.POR_CONFIRMAR
                    ButtonConfirmar.Enabled = True
                Else
                    classAgenda.eag_codigo = ESTADOS_AGENDA.AGENDADA
                    ButtonConfirmar.Enabled = False
                End If

                classAgenda.age_fechasujerida = CDate(txtFechaCita.Value)
                classAgenda.age_usuarioingreso = GLO_USUARIO_ACTUAL
                classAgenda.age_usuarioproceso = 0
                classAgenda.age_monto = txtMonto.Text

                ds = classAgenda.AGENDA_GUARDA_DATOS_ENCABEZADO(_msgError, conexion)
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
                    Else
                        _age_codigoNew = ds.Tables(0).Rows(0)("CODIGO")
                    End If
                End If


                'ELIMINA DETALLE AGENDA
                ds = Nothing
                classAgenda.age_codigo = _age_codigoNew
                ds = classAgenda.ELIMINA_DETALLE(_msgError, conexion)
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
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                ds = Nothing
                Do While fila <= grillaDetalle.Rows.Count - 1
                    If grillaDetalle.Rows(fila).Cells(C_C_AGENDADA).Value > 0 Then
                        classAgenda.age_codigo = _age_codigoNew
                        classAgenda.car_codigo = cmbCliente.SelectedValue
                        classAgenda.pro_codigo = grillaDetalle.Rows(fila).Cells(C_PRO_CODIGO).Value
                        classAgenda.pro_codigointerno = grillaDetalle.Rows(fila).Cells(C_C_INTERNO).Value
                        classAgenda.pro_nombre = grillaDetalle.Rows(fila).Cells(C_NOMBRE_FAVATEX).Value
                        classAgenda.sku_cartera = grillaDetalle.Rows(fila).Cells(C_SKU_CLIENTE).Value
                        classAgenda.sku_cartera_nombre = grillaDetalle.Rows(fila).Cells(C_NOMBRE_CLIENTE).Value
                        classAgenda.ade_precio = grillaDetalle.Rows(fila).Cells(C_PRECIO).Value
                        classAgenda.ade_cantidad = grillaDetalle.Rows(fila).Cells(C_CANTIDAD).Value
                        classAgenda.oco_numero = txtOrdenCompra.Text
                        classAgenda.fila_consolidado = grillaDetalle.Rows(fila).Cells(C_FILA_CONSO).Value
                        classAgenda.age_cantidadagendada = grillaDetalle.Rows(fila).Cells(C_C_AGENDADA).Value
                        _msg = ""

                        ds = classAgenda.AGENDA_GUARDA_DATOS_DETALLE(_msg, conexion)
                        If _msg = "" Then
                            If ds.Tables.Count > 0 Then
                                If ds.Tables(0).Rows(0)("CODIGO") < 0 Then
                                    If conexion.State <> ConnectionState.Closed Then
                                        conexion.Close()
                                    End If
                                    conexion.Dispose()
                                    ds.Dispose()
                                    MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        Else
                            If conexion.State <> ConnectionState.Closed Then
                                conexion.Close()
                            End If
                            conexion.Dispose()
                            ds.Dispose()
                            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        ds = Nothing
                    End If
                    fila = fila + 1
                Loop

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                _age_codigoNew = 0
                Call INICIALIZA()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Function VALIDA() As Boolean
        VALIDA = False

        'If GrillaFechas.RowCount = 0 Then
        If txtOrdenCompra.Text = "" Or txtOrdenCompra.Text = "0" Then
            MessageBox.Show("Debe seleccionar una orden de compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        If grillaDetalle.RowCount = 0 Then
            MessageBox.Show("No existen detalles seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        If VERIFICA_CANTIDADES() = 0 Then
            MessageBox.Show("Debe ingresar cantidades en a lo menos un registro del detalle", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        If CDate(txtFechaOrdenCompra.Text) < CDate(txtFechaCita.Value) Then
            MessageBox.Show("La fecha de la cita no puede ser mayor a la fecha de compromiso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        VALIDA = True

    End Function

    Private Function VERIFICA_CANTIDADES() As Integer
        Dim contador As Integer = 0
        VERIFICA_CANTIDADES = contador

        Try
            For Each row As DataGridViewRow In Me.grillaDetalle.Rows
                contador = contador + row.Cells(11).Value
            Next

            VERIFICA_CANTIDADES = contador
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub INICIALIZA()
        ButtonConfirmar.Enabled = False
        GrillaFechas.DataSource = Nothing
        GrillaFechas.Rows.Clear()

        ChkConfirmar.Checked = False

        cmbCliente.Enabled = True
        cmbCliente.DataSource = Nothing
        cmbCliente.Items.Clear()
        Call CARGA_COMBO_CLIENTE()
        Call LIMPIA_FORMULARIO()
    End Sub

    Private Sub LIMPIA_FORMULARIO()
        txtOrdenCompra.Text = "0"
        txtFechaOrdenCompra.Text = ""
        txtMonto.Text = "0"
        txtFechaCita.Value = Date.Today
        grillaDetalle.DataSource = Nothing
        grillaDetalle.Rows.Clear()
    End Sub

    Private Sub CARGA_COMBO_CLIENTE()
        Dim _msg As String
        Try
            Dim classCliente As class_cartera = New class_cartera
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classCliente.cnn = _cnn
            _msg = ""
            ds = classCliente.CARGA_COMBO_CLIENTE(_msg)
            If _msg = "" Then
                Me.cmbCliente.DataSource = ds.Tables(0)
                Me.cmbCliente.DisplayMember = "MENSAJE"
                Me.cmbCliente.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_BOLETA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub frm_ingreso_agenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=CL-MV054\DESARROLLO;Initial Catalog=APPFVT_01;User ID=sa;Password=S1st3m4s"
        cmbCliente.Enabled = True
        Call INICIALIZA()
        If _age_codigoNew > 0 Then
            Call CARGA_DATOS()
            Call CARGA_GRILLA_DETALLE_INGRESADO(_age_codigoNew)
            txtFechaCita.Enabled = True
            cmbCliente.Enabled = False
            If _eag_codigo = ESTADOS_AGENDA.PROCESADA Then
                ButtonGurdar.Enabled = False
                ButtonNuevo.Enabled = False
                txtFechaCita.Enabled = False
            End If
        End If
    End Sub

    Private Sub AjustaGrillas()
        GrillaFechas.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        GrillaFechas.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        grillaDetalle.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grillaDetalle.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

    End Sub


    Private Sub CARGA_GRILLA_DETALLE_INGRESADO(ByVal ageCodigo As Integer)
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0

        Try
            classAgenda.cnn = _cnn
            classAgenda.age_codigo = ageCodigo

            ds = classAgenda.AGENDA_INGRESADO_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    grillaDetalle.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("sku_nombre") <> "" Then
                            grillaDetalle.Rows.Add(txtOrdenCompra.Text,
                                                  ds.Tables(0).Rows(Fila)("fila"),
                                                  ds.Tables(0).Rows(Fila)("pro_codigo"),
                                                  ds.Tables(0).Rows(Fila)("codigo_interno"),
                                                  ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                  ds.Tables(0).Rows(Fila)("sku_cliente"),
                                                  ds.Tables(0).Rows(Fila)("sku_nombre"),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("precio"), 0),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("cantidad"), 0),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("saldo"), 0),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("agendadas"), 0),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("age_cantidadagendada"), 0))
                        End If
                        Fila = Fila + 1
                    Loop
                End If
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
                'Call PINTA_GRILLA_FECHAS()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub CARGA_DATOS()
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classAgenda.cnn = _cnn
            classAgenda.age_codigo = _age_codigoNew
            classAgenda.car_codigo = 0
            classAgenda.age_fechaorden_string = "-"
            classAgenda.eag_codigo = 0

            _msg = ""

            ds = classAgenda.AGENDA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        txtOrdenCompra.Text = ds.Tables(0).Rows(Fila)("age_ordencompra")
                        txtFechaOrdenCompra.Text = ds.Tables(0).Rows(Fila)("age_fechaorden")
                        txtMonto.Text = ds.Tables(0).Rows(Fila)("age_monto")
                        txtFechaCita.Value = ds.Tables(0).Rows(Fila)("age_fechasujerida")
                        cmbCliente.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")

                        If ds.Tables(0).Rows(Fila)("eag_codigo") = ESTADOS_AGENDA.POR_CONFIRMAR Then
                            chkPorconfirmar.Checked = True
                            ButtonConfirmar.Enabled = True
                        End If


                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_DATOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_DATOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

    End Sub
    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        Call CARGA_GRILLA_FECHAS()
    End Sub

    Private Sub CARGA_GRILLA_FECHAS()
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Dim mes As String = ""
        Dim dia As String = ""
        Dim mes2 As String = ""
        Dim dia2 As String = ""
        Dim diaActual As Integer = 0
        Dim VariableDiaProCliente = 10
        Dim pic As New PictureBox
        Dim destino As New Bitmap(13, 13) ' Me.GrillaFechas.RowTemplate.Height - 5)
        Try
            classAgenda.cnn = _cnn
            classAgenda.car_codigo = cmbCliente.SelectedValue

            ds = classAgenda.OC_POR_FECHA_LISTADO_AGENDA(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaFechas.Rows.Clear()
                    Call LIMPIA_FORMULARIO()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("con_ocnumero") > 0 Then
                            GrillaFechas.Rows.Add(False, ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                                  CDate(ds.Tables(0).Rows(Fila)("cod_fechadespacho")).ToShortDateString,
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("oco_total"), 0),
                                                  ds.Tables(0).Rows(Fila)("es_abierta"),
                                                  ds.Tables(0).Rows(Fila)("es_porconfirmar"))
                            If Fila = 0 Then
                                txtOrdenCompra.Text = ds.Tables(0).Rows(Fila)("con_ocnumero")
                                txtFechaOrdenCompra.Text = CDate(ds.Tables(0).Rows(Fila)("cod_fechadespacho")).ToShortDateString
                                chkTipoOrden.Checked = ds.Tables(0).Rows(Fila)("es_abierta")
                                FormatNumber(txtMonto.Text = ds.Tables(0).Rows(Fila)("oco_total"), 0)
                                chkPorconfirmar.Checked = ds.Tables(0).Rows(Fila)("es_porconfirmar")
                            End If
                        End If

                        Fila = Fila + 1
                    Loop
                    Call PINTA_ORDENES_POR_CONFIRMAR()
                    Call AjustaGrillas()
                End If
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
                'Call PINTA_GRILLA_FECHAS()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_FECHAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PINTA_ORDENES_POR_CONFIRMAR()
        For Each row As DataGridViewRow In Me.GrillaFechas.Rows

            If row.Cells(5).Value = True Then
                row.DefaultCellStyle.BackColor = Color.LightYellow
                row.DefaultCellStyle.ForeColor = Color.Orange
            End If
        Next
    End Sub

    Private Sub CARGA_GRILLA_DETALLE(ByVal oco_numero As String, ByVal oco_fecha As Date)
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0

        Try
            classAgenda.cnn = _cnn
            classAgenda.car_codigo = cmbCliente.SelectedValue
            classAgenda.age_ordencompra = oco_numero
            classAgenda.age_fechaorden = oco_fecha
            grillaDetalle.Rows.Clear()
            ds = classAgenda.OC_POR_FECHA_LISTADO_AGENDA_DETALLE(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then

                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("sku_nombre") <> "" Then
                            grillaDetalle.Rows.Add(oco_numero,
                                                  ds.Tables(0).Rows(Fila)("fila"),
                                                  ds.Tables(0).Rows(Fila)("pro_codigo"),
                                                  ds.Tables(0).Rows(Fila)("codigo_interno"),
                                                  ds.Tables(0).Rows(Fila)("pro_nombre"),
                                                  ds.Tables(0).Rows(Fila)("sku_cliente"),
                                                  ds.Tables(0).Rows(Fila)("sku_nombre"),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("precio"), 0),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("cantidad"), 0),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("saldo"), 0),
                                                  FormatNumber(ds.Tables(0).Rows(Fila)("saldoAgendado"), 0),
                                                  0)
                        End If
                        Fila = Fila + 1
                    Loop
                End If
                Call AjustaGrillas()
                'GrillaFechas.AutoResizeColumns()
                'Call PINTA_GRILLA()
                'Call PINTA_GRILLA_FECHAS()
            Else
                MessageBox.Show(_msgError + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "\CARGA_GRILLA_DETALLE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick
        Try
            txtOrdenCompra.Text = GrillaFechas.Rows(e.RowIndex).Cells(col_O_COMPRA).Value
            txtFechaOrdenCompra.Text = GrillaFechas.Rows(e.RowIndex).Cells(col_FECHA).Value
            txtMonto.Text = FormatNumber(GrillaFechas.Rows(e.RowIndex).Cells(col_MONTO).Value, 0)
            chkPorconfirmar.Checked = GrillaFechas.Rows(e.RowIndex).Cells(5).Value
            ChkConfirmar.Checked = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrillaFechas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellEnter
        Try
            txtOrdenCompra.Text = GrillaFechas.Rows(e.RowIndex).Cells(col_O_COMPRA).Value
            txtFechaOrdenCompra.Text = GrillaFechas.Rows(e.RowIndex).Cells(col_FECHA).Value
            txtMonto.Text = FormatNumber(GrillaFechas.Rows(e.RowIndex).Cells(col_MONTO).Value, 0)
            chkPorconfirmar.Checked = GrillaFechas.Rows(e.RowIndex).Cells(5).Value
            ChkConfirmar.Checked = 0
            Call CARGA_GRILLA_DETALLE(GrillaFechas.Rows(e.RowIndex).Cells(col_O_COMPRA).Value, GrillaFechas.Rows(e.RowIndex).Cells(col_FECHA).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub grillaDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaDetalle.CellContentClick

    End Sub

    Private Sub validar_Keypress_cantidades(
        ByVal sender As Object,
        ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = grillaDetalle.CurrentCell.ColumnIndex
        Dim fila As Integer = grillaDetalle.CurrentCell.RowIndex

        ' solo numeicas 
        If (columna = C_C_AGENDADA) Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If

        'If (columna = 2) Then
        '    Dim caracter As Char = e.KeyChar

        '    ' referencia a la celda  
        '    Dim txt As TextBox = CType(sender, TextBox)

        '    ' comprobar si es un número con isNumber, si es el backspace, si el caracter  

        '    ' es el separador decimal, y que no contiene ya el separador 

        '    If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ",") And (txt.Text.Contains(",") = False) Then

        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End If

    End Sub

    Private Sub grillaDetalle_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grillaDetalle.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        PrecionaTeclaDesde = "GrillaDetalle"
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress_cantidades
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim columna As Integer
        Dim fila As Integer

        Try
            Select Case keyData
                Case Keys.Escape

                    ' No hacemos nada porque se supone

                    ' que la tecla Escape cancela la acción.

                Case Keys.Enter 'Or Keys.Down Or Keys.Up Or Keys.Left Or Keys.Right

                    'If GrillaFinanciamiento.Focus = True Then
                    If PrecionaTeclaDesde = "GrillaDetalle" Then

                        columna = grillaDetalle.CurrentCell.ColumnIndex
                        fila = grillaDetalle.CurrentCell.RowIndex

                        If (columna = C_C_AGENDADA) Then
                            If (cellTextBox IsNot Nothing) Then
                                With grillaDetalle
                                    If ((.CurrentCell.RowIndex) < (.RowCount - 1)) Then
                                        .CurrentCell = .Item(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex + 1)
                                    ElseIf ((.CurrentCell.RowIndex) = (.RowCount - 1)) Then
                                        If .ColumnCount = (.CurrentCell.ColumnIndex + 1) Then
                                            .CurrentCell = .Item(.CurrentCell.ColumnIndex, 0)
                                        Else
                                            .CurrentCell = .Item(.CurrentCell.ColumnIndex + 1, 0)
                                        End If

                                    End If
                                End With
                            End If

                            If CDbl(grillaDetalle.Rows(fila).Cells(C_SALDO).Value) < CDbl(grillaDetalle.Rows(fila).Cells(C_C_AGENDADA).Value) Then
                                MessageBox.Show("La cantidad que esta ingresando no es válida, ya que es mayor a la cantidad pendiente de entrega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                grillaDetalle.Rows(fila).Cells(C_C_AGENDADA).Value = grillaDetalle.Rows(fila).Cells(C_SALDO).Value
                            End If
                        End If
                    End If

                    PrecionaTeclaDesde = ""
                Case Else

                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged

    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        _age_codigoNew = 0
        Call INICIALIZA()
    End Sub

    Private Sub ChkConfirmar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkConfirmar.CheckedChanged
        If ChkConfirmar.Checked = True Then
            For Each row As DataGridViewRow In Me.grillaDetalle.Rows
                row.Cells(11).Value = row.Cells(C_SALDO).Value
            Next
        Else
            For Each row As DataGridViewRow In Me.grillaDetalle.Rows
                row.Cells(11).Value = 0
            Next
        End If
    End Sub

    Private Sub ButtonConfirmar_Click(sender As Object, e As EventArgs) Handles ButtonConfirmar.Click
        If CONFIRMA_AGENDA() = True Then
            MessageBox.Show("La solicitud de agenda fuen confirmada en forma correcta", Me.Text, MessageBoxButtons.OK)
        End If
    End Sub

    Private Function CONFIRMA_AGENDA() As Boolean
        Dim classAgenda As class_agendanew = New class_agendanew
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        CONFIRMA_AGENDA = False
        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classAgenda.age_codigo = _age_codigoNew
                classAgenda.eag_codigo = ESTADOS_AGENDA.AGENDADA

                ds = classAgenda.AGENDA_CAMBIA_ESTDO(_msgError, conexion)
                If ds.Tables(0).Rows.Count > 0 Then
                    If _msgError = "" Then
                        If ds.Tables(0).Rows(0)("CODIGO") <= 0 Then
                            If conexion.State = ConnectionState.Open Then
                                conexion.Close()
                            End If
                            MessageBox.Show(ds.Tables(0).Rows(0)("MENSAJE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ds = Nothing
                            Exit Function
                        End If
                    Else
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ds = Nothing
                        Exit Function
                    End If
                End If
                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing
                CONFIRMA_AGENDA = True

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            CONFIRMA_AGENDA = False
        End Try
    End Function

    Private Sub GrillaFechas_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles GrillaFechas.CellBeginEdit

    End Sub
End Class