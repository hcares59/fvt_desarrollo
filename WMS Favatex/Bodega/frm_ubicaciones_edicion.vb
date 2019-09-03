Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ubicaciones_edicion
    Private _cnn As String
    Private _ubi_codigos As String
    Private _es_edicion As Boolean

    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property ubi_codigos() As String
        Get
            Return _ubi_codigos
        End Get
        Set(ByVal value As String)
            _ubi_codigos = value
        End Set
    End Property
    Public Property es_edicion() As Boolean
        Get
            Return _es_edicion
        End Get
        Set(ByVal value As Boolean)
            _es_edicion = value
        End Set
    End Property

    Private Sub frm_ubicaciones_edicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CARGA_COMBO_PROVEEDOR()
        Call CARGA_COMBO_SEGMENTO()

        If _es_edicion = True Then
            Call BUSCA_REGISTRO()
        End If

    End Sub

    Private Sub BUSCA_REGISTRO()
        Dim class_ubicacion As class_ubicaciones = New class_ubicaciones
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_ubicacion.cnn = _cnn
            class_ubicacion.ubi_codigo = Replace(_ubi_codigos, ",", "")
            _msg = ""
            ds = class_ubicacion.BUSCA_DATOS_UBICACIONES(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ubi_codigo") > 0 Then
                        cmbProveedor.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")
                        cmbCapacidad.SelectedValue = ds.Tables(0).Rows(Fila)("sca_codigo")
                        txtAncho.Text = ds.Tables(0).Rows(Fila)("ubi_largo")
                        txtAlto.Text = ds.Tables(0).Rows(Fila)("ubi_alto")
                        txtFondo.Text = ds.Tables(0).Rows(Fila)("ubi_fondo")
                        txtMTS3.Text = ds.Tables(0).Rows(Fila)("ubi_capacidadm3")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\BUSCA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_PROVEEDOR()
        Dim _msg As String
        Try
            Dim classComunes As class_comunes = New class_comunes
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classComunes.cnn = _cnn
            _msg = ""
            ds = classComunes.CARGA_COMBO_PROVEEDOR(_msg)
            If _msg = "" Then
                Me.cmbProveedor.DataSource = ds.Tables(0)
                Me.cmbProveedor.DisplayMember = "MENSAJE"
                Me.cmbProveedor.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_SEGMENTO()
        Dim _msg As String
        Try
            Dim classSegmento As class_segmento = New class_segmento
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classSegmento.cnn = _cnn
            _msg = ""
            ds = classSegmento.CARGA_COMBO_SEGMENTO(_msg)
            If _msg = "" Then
                Me.cmbCapacidad.DataSource = ds.Tables(0)
                Me.cmbCapacidad.DisplayMember = "MENSAJE"
                Me.cmbCapacidad.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_SEGMENTO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        'Call GUARDA_REGISTRO()
    End Sub

    'Private Sub GUARDA_REGISTRO()
    '    Dim classUbicacion As class_ubicaciones = New class_ubicaciones
    '    Dim ds As DataSet = New DataSet
    '    Dim _msgError As String = ""
    '    Dim conexion As New SqlConnection(_cnn)
    '    Dim scopeOptions = New TransactionOptions()
    '    Dim fila As Integer = 0
    '    Dim _msg As String = ""
    '    Dim respuesta As Integer = 0

    '    Try
    '        Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
    '            conexion.Open()
    '            classUbicacion.ubi_cadena = _ubi_codigos

    '            If txtAncho.Text = "" Then
    '                txtAncho.Text = "0"
    '            End If
    '            classUbicacion.ubi_largo = CDbl(txtAncho.Text)

    '            If txtAlto.Text = "" Then
    '                txtAlto.Text = "0"
    '            End If
    '            classUbicacion.ubi_alto = CDbl(txtAlto.Text)

    '            If txtFondo.Text = "" Then
    '                txtFondo.Text = "0"
    '            End If
    '            classUbicacion.ubi_fondo = txtFondo.Text

    '            classUbicacion.car_codigo = cmbProveedor.SelectedValue
    '            classUbicacion.sca_codigo = cmbCapacidad.SelectedValue

    '            If txtMTS3.Text = "" Then
    '                txtMTS3.Text = "0"
    '            End If
    '            classUbicacion.ubi_capacidadm3 = txtMTS3.Text

    '            ds = classUbicacion.GUARDA_REGISTRO_UBICACION(_msgError, conexion)
    '            If _msgError <> "" Then
    '                If conexion.State = ConnectionState.Open Then
    '                    conexion.Close()
    '                End If
    '                ds = Nothing
    '                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            Else
    '                If ds.Tables(0).Rows(0)("codigo") < 0 Then
    '                    If conexion.State = ConnectionState.Open Then
    '                        conexion.Close()
    '                    End If
    '                    ds = Nothing
    '                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Exit Sub
    '                End If
    '            End If

    '            Transaccion.Complete()
    '            Transaccion.Dispose()
    '            If conexion.State = ConnectionState.Open Then
    '                conexion.Close()
    '            End If
    '            ds = Nothing

    '            conexion.Close()

    '            MessageBox.Show("Los datos fueron ingresados en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub
End Class