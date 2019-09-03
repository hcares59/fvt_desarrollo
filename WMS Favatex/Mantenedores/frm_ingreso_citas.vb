Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_citas
    Private _cnn As String
    Private _cit_codigo As Integer
    Private _eci_codigo As Integer

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property cit_codigo() As Integer
        Get
            Return _cit_codigo
        End Get
        Set(ByVal value As Integer)
            _cit_codigo = value
        End Set
    End Property
    Public Property eci_codigo() As Integer
        Get
            Return _eci_codigo
        End Get
        Set(ByVal value As Integer)
            _eci_codigo = value
        End Set
    End Property

    Private Sub frm_ingreso_citas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_cnn = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
        Call INICIALIZA()

        If _cit_codigo > 0 Then
            Call CARGA_DATOS()
            cmbCliente.Enabled = False
            txtNumerocita.Enabled = False

            If _eci_codigo = ESTADOS_CITAS.PROCESADA Then
                ButtonGurdar.Enabled = False
                ButtonNuevo.Enabled = False
                txtFechaCita.Enabled = False
                txtHora.Enabled = False
            End If
        End If
    End Sub

    Private Sub CARGA_DATOS()
        Dim classCita As class_citas = New class_citas
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String

            ds = Nothing
            classCita.cnn = _cnn
            classCita.car_codigo = 0
            classCita.cit_codigo = _cit_codigo
            classCita.fecha_compromiso = "-"
            classCita.hora_inicio = "08:00"
            classCita.hora_termino = "23:59"
            classCita.solo_codigo = 1
            _msg = ""

            ds = classCita.CITA_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("car_nombre") <> "" Then
                        cmbCliente.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")
                        txtOrdenCompra.Text = ds.Tables(0).Rows(Fila)("cit_ordencompra")
                        txtFechaOrdenCompra.Text = ds.Tables(0).Rows(Fila)("cit_fechaorden")
                        txtFechaCita.Value = ds.Tables(0).Rows(Fila)("cit_fecha")
                        txtHora.Text = ds.Tables(0).Rows(Fila)("cit_hora")
                        txtNumerocita.Text = ds.Tables(0).Rows(Fila)("cit_numero")
                        chkTipoOrden.Checked = ds.Tables(0).Rows(Fila)("es_abierta")
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_DATOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_DATOS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub INICIALIZA()
        GrillaFechas.DataSource = Nothing
        GrillaFechas.Rows.Clear()
        txtNumerocita.Enabled = True

        cmbCliente.Enabled = True
        cmbCliente.DataSource = Nothing
        cmbCliente.Items.Clear()
        Call CARGA_COMBO_CLIENTE()
        Call LIMPIA_FORMULARIO()
    End Sub

    Private Sub LIMPIA_FORMULARIO()
        txtOrdenCompra.Text = "0"
        txtFechaOrdenCompra.Text = ""
        txtFechaCita.Value = Date.Today
        txtHora.Text = ""
        txtNumerocita.Text = "0"
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

    Private Sub cmbCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCliente.SelectionChangeCommitted
        Call LIMPIA_FORMULARIO()
        Call CARGA_GRILLA_FECHAS()
    End Sub

    Private Sub CARGA_GRILLA_FECHAS()
        Dim classCitas As class_citas = New class_citas
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

            classCitas.cnn = _cnn
            classCitas.car_codigo = cmbCliente.SelectedValue

            ds = classCitas.OC_POR_FECHA_LISTADO(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    GrillaFechas.Rows.Clear()
                    Do While Fila < ds.Tables(0).Rows.Count
                        If ds.Tables(0).Rows(Fila)("con_ocnumero") > 0 Then
                            GrillaFechas.Rows.Add(False, ds.Tables(0).Rows(Fila)("con_ocnumero"),
                                                  CDate(ds.Tables(0).Rows(Fila)("cod_fechadespacho")).ToShortDateString,
                                                  ds.Tables(0).Rows(Fila)("es_abierta"))
                            If Fila = 0 Then
                                txtOrdenCompra.Text = ds.Tables(0).Rows(Fila)("con_ocnumero")
                                txtFechaOrdenCompra.Text = CDate(ds.Tables(0).Rows(Fila)("cod_fechadespacho")).ToShortDateString
                                chkTipoOrden.Checked = ds.Tables(0).Rows(Fila)("es_abierta")
                            End If

                        End If

                        Fila = Fila + 1
                    Loop
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

    Private Sub GrillaFechas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaFechas.CellContentClick
        Try
            txtOrdenCompra.Text = GrillaFechas.Rows(e.RowIndex).Cells(1).Value
            txtFechaOrdenCompra.Text = GrillaFechas.Rows(e.RowIndex).Cells(2).Value
            chkTipoOrden.Checked = GrillaFechas.Rows(e.RowIndex).Cells(3).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Call INICIALIZA()
        _cit_codigo = 0
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If VALIDA_DATOS() = False Then
            Exit Sub
        End If

        Call GUARDA_DATOS()

        If cmbCliente.Enabled = False Then
            Me.Dispose()
        Else
            _cit_codigo = 0
        End If

        Call INICIALIZA()

    End Sub

    Private Sub GUARDA_DATOS()
        Dim classCita As class_citas = New class_citas
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try

            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classCita.cit_codigo = _cit_codigo
                classCita.car_codigo = cmbCliente.SelectedValue
                classCita.cit_ordencompra = txtOrdenCompra.Text
                classCita.cit_fechaorden = CDate(txtFechaOrdenCompra.Text)
                classCita.cit_fecha = CDate(txtFechaCita.Value)
                classCita.cit_hora = txtHora.Text
                classCita.cit_numero = txtNumerocita.Text
                classCita.eci_codigo = ESTADOS_CITAS.AGENDADA

                ds = classCita.CITA_GUARDA_DATOS(_msgError, conexion)
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
                    Else
                        _cit_codigo = ds.Tables(0).Rows(0)("CODIGO")
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                MessageBox.Show("Los datos fueron guardados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                _cit_codigo = 0
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Function VALIDA_DATOS()
        VALIDA_DATOS = False

        If Trim(txtHora.Text) = ":" Then
            MessageBox.Show("Debe ingresar la hora de la cita de entrega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtHora.Focus()
            Exit Function
        End If

        If txtNumerocita.Text = "0" And txtNumerocita.Text = "" Then
            MessageBox.Show("Debe ingresar el numero de la cita generada en el portal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumerocita.Focus()
            Exit Function
        End If

        'If 

        VALIDA_DATOS = True

    End Function

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class