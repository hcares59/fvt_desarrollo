Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_ubicacion_old
    Private _cnn As String
    Private _ubi_codigo As Integer
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property ubi_codigo() As Integer
        Get
            Return _ubi_codigo
        End Get
        Set(ByVal value As Integer)
            _ubi_codigo = value
        End Set
    End Property
    Private Sub frm_ingreso_ubicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
        If _ubi_codigo > 0 Then
            Call BUSCA_REGISTRO()
        End If

    End Sub

    Private Sub CARGA_COMBO_UBICACIONES_RELACIONADAS()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn

            If cmbZona.SelectedText = "" Then
                classUbicacion.zon_codigo = 0
            Else
                classUbicacion.zon_codigo = cmbZona.SelectedValue
            End If

            If cmbProveedor.SelectedText = "" Then
                classUbicacion.zon_codigo = 0
            Else
                classUbicacion.zon_codigo = cmbProveedor.SelectedValue
            End If

            _msg = ""
            ds = classUbicacion.UBICACIONES_RELACIONADAS_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbUbicacionRel.DataSource = ds.Tables(0)
                Me.cmbUbicacionRel.DisplayMember = "MENSAJE"
                Me.cmbUbicacionRel.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_UBICACIONES_RELACIONADAS", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_COMBO_UBICACIONES_RELACIONADAS_CON_UBICACION()
        Dim _msg As String
        Try
            Dim classUbicacion As class_ubicaciones = New class_ubicaciones
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classUbicacion.cnn = _cnn
            classUbicacion.ubi_codigo = _ubi_codigo
            _msg = ""
            ds = classUbicacion.UBICACIONES_RELACIONADAS_CON_UBICACION_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbUbicacionRel.DataSource = ds.Tables(0)
                Me.cmbUbicacionRel.DisplayMember = "MENSAJE"
                Me.cmbUbicacionRel.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_UBICACIONES_RELACIONADAS", MsgBoxStyle.Critical, Me.Text)
        End Try
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
            class_ubicacion.ubi_codigo = _ubi_codigo
            class_ubicacion.bod_codigo = 0
            class_ubicacion.tub_codigo = 0

            _msg = ""
            ds = class_ubicacion.CARGA_DATOS_UBICACIONES(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("ubi_codigo") > 0 Then
                        cmbBodegas.SelectedValue = ds.Tables(0).Rows(Fila)("bod_codigo")

                        Call CARGA_COMBO_TIPO_UBICACION()
                        cmbTipo.SelectedValue = ds.Tables(0).Rows(Fila)("btu_codigo")

                        Call CARGA_COMBO_ZONA()
                        cmbZona.SelectedValue = ds.Tables(0).Rows(Fila)("zon_codigo")

                        Call CARGA_COMBO_PROVEEDOR()
                        cmbProveedor.SelectedValue = ds.Tables(0).Rows(Fila)("car_codigo")

                        Call CARGA_COMBO_SEGMENTO()
                        cmbCapacidad.SelectedValue = ds.Tables(0).Rows(Fila)("sca_codigo")

                        txtEstado.Text = ds.Tables(0).Rows(Fila)("eub_nombre")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("ubi_nombre")
                        txtOcupadoPor.Text = ds.Tables(0).Rows(Fila)("prd_palletserie")
                        txtPrioridad.Text = ds.Tables(0).Rows(Fila)("ubi_prioridad")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("ubi_activo")

                        If ds.Tables(0).Rows(Fila)("ubi_relacionada") > 0 Then
                            Call CARGA_COMBO_UBICACIONES_RELACIONADAS_CON_UBICACION()
                            cmbUbicacionRel.SelectedValue = ds.Tables(0).Rows(Fila)("ubi_relacionada")
                        Else
                            Call CARGA_COMBO_UBICACIONES_RELACIONADAS()
                        End If

                        txtAncho.Text = ds.Tables(0).Rows(Fila)("ubi_ancho")
                        txtAlto.Text = ds.Tables(0).Rows(Fila)("ubi_alto")
                        txtFondo.Text = ds.Tables(0).Rows(Fila)("ubi_fondo")
                        txtMts3.Text = ds.Tables(0).Rows(Fila)("ubi_capacidadm3")
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\BUSCA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "BUSCA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub INICIALIZA()
        cmbCapacidad.DataSource = Nothing
        cmbProveedor.DataSource = Nothing
        cmbZona.DataSource = Nothing
        cmbTipo.DataSource = Nothing
        cmbBodegas.DataSource = Nothing

        cmbCapacidad.Items.Clear()
        cmbProveedor.Items.Clear()
        cmbZona.Items.Clear()
        cmbTipo.Items.Clear()
        cmbBodegas.Items.Clear()

        Call CARGA_COMBO_BODEGA()
        'Call CARGA_COMBO_TIPO_UBICACION()

        Call CARGA_COMBO_PROVEEDOR()
        Call CARGA_COMBO_SEGMENTO()


        txtNombre.Text = ""
        txtEstado.Text = ""
        txtOcupadoPor.Text = ""
        chkActivo.Checked = True
        txtCantPallet.Text = "0"
        txtCantPalletDoble.Text = "0"
        txtCantPalletOT1.Text = "0"
        txtCantPalletOT2.Text = "0"
        txtAlto.Text = "0"
        txtAncho.Text = "0"
        txtFondo.Text = "0"
        txtMts3.Text = "0"
    End Sub

    Private Sub CARGA_COMBO_BODEGA()
        Dim _msg As String
        Try
            Dim classBodega As class_bodegas = New class_bodegas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classBodega.cnn = _cnn
            _msg = ""
            ds = classBodega.BODEGA_CARGA_COMBO(_msg)
            If _msg = "" Then
                Me.cmbBodegas.DataSource = ds.Tables(0)
                Me.cmbBodegas.DisplayMember = "MENSAJE"
                Me.cmbBodegas.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_PROVEEDOR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
    Private Sub CARGA_COMBO_TIPO_UBICACION()
        Dim _msg As String
        Try
            Dim classTipoUbicacion As class_tipo_ubicacion = New class_tipo_ubicacion
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classTipoUbicacion.cnn = _cnn
            classTipoUbicacion.bod_codigo = cmbBodegas.SelectedValue

            _msg = ""
            ds = classTipoUbicacion.COMBO_CARGA_TIPO_UBICACION(_msg)
            If _msg = "" Then
                Me.cmbTipo.DataSource = ds.Tables(0)
                Me.cmbTipo.DisplayMember = "MENSAJE"
                Me.cmbTipo.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_TIPO_UBICACION", MsgBoxStyle.Critical, Me.Text)
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

    Private Sub cmbBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodegas.SelectedIndexChanged

    End Sub

    Private Sub cmbBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBodegas.SelectionChangeCommitted
        If cmbBodegas.SelectedValue >= 0 Then
            Call CARGA_COMBO_TIPO_UBICACION()
        End If

    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click

        If cmbTipo.Text = "" Then
            MessageBox.Show("Debe selecciona un tipo de rack", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipo.Focus()
            Exit Sub
        End If

        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar el nombre", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Sub
        End If

        Call GUARDA_REGISTRO()
    End Sub

    Private Sub GUARDA_REGISTRO()
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim conexion As New SqlConnection(_cnn)
        Dim scopeOptions = New TransactionOptions()
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Dim respuesta As Integer = 0

        Try
            Using Transaccion As New TransactionScope(TransactionScopeOption.Required, scopeOptions)
                conexion.Open()
                classUbicacion.ubi_codigo = _ubi_codigo
                classUbicacion.bod_codigo = cmbBodegas.SelectedValue
                classUbicacion.btu_codigo = cmbTipo.SelectedValue
                classUbicacion.zon_codigo = cmbZona.SelectedValue

                If cmbProveedor.SelectedText = "" Then
                    classUbicacion.car_codigo = 0
                Else
                    classUbicacion.car_codigo = cmbProveedor.SelectedValue
                End If

                If cmbCapacidad.SelectedText = "" Then
                    classUbicacion.car_codigo = 0
                Else
                    classUbicacion.sca_codigo = cmbCapacidad.SelectedValue
                End If

                classUbicacion.ubi_nombre = txtNombre.Text

                If txtCantPallet.Text = "" Then
                    classUbicacion.ubi_cantpallet = 0
                Else
                    classUbicacion.ubi_cantpallet = CDbl(txtCantPallet.Text)
                End If

                If txtCantPalletDoble.Text = "" Then
                    classUbicacion.ubi_cantpalletdoble = 0
                Else
                    classUbicacion.ubi_cantpalletdoble = CDbl(txtCantPalletDoble.Text)
                End If

                If txtCantPalletOT1.Text = "" Then
                    classUbicacion.ubi_cantpalletotro1 = 0
                Else
                    classUbicacion.ubi_cantpalletotro1 = CDbl(txtCantPalletOT1.Text)
                End If

                If txtCantPalletOT2.Text = "" Then
                    classUbicacion.ubi_cantpalletotro2 = 0
                Else
                    classUbicacion.ubi_cantpalletotro2 = CDbl(txtCantPalletOT2.Text)
                End If

                If txtAlto.Text = "" Then
                    classUbicacion.ubi_alto = 0
                Else
                    classUbicacion.ubi_alto = CDbl(txtAlto.Text)
                End If

                If txtAncho.Text = "" Then
                    classUbicacion.ubi_ancho = 0
                Else
                    classUbicacion.ubi_ancho = CDbl(txtAncho.Text)
                End If

                If txtFondo.Text = "" Then
                    classUbicacion.ubi_fondo = 0
                Else
                    classUbicacion.ubi_fondo = CDbl(txtFondo.Text)
                End If

                If txtMts3.Text = "" Then
                    classUbicacion.ubi_capacidadm3 = 0
                Else
                    classUbicacion.ubi_capacidadm3 = CDbl(txtMts3.Text)
                End If

                classUbicacion.ubi_activo = chkActivo.Checked

                If txtPrioridad.Text = "" Then
                    classUbicacion.ubi_prioridad = 0
                Else
                    classUbicacion.ubi_prioridad = Int(txtPrioridad.Text)
                End If

                If cmbUbicacionRel.Text = "" Then
                    classUbicacion.ubi_relacionada = 0
                Else
                    classUbicacion.ubi_relacionada = cmbUbicacionRel.SelectedValue
                End If


                ds = classUbicacion.GUARDA_REGISTRO_UBICACION(_msgError, conexion)
                If _msgError <> "" Then
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                    ds = Nothing
                    MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0)("codigo") < 0 Then
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                        ds = Nothing
                        MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                Transaccion.Complete()
                Transaccion.Dispose()
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If
                ds = Nothing

                conexion.Close()

                respuesta = MessageBox.Show("Los datos fueron ingresados en forma correcta," _
                                            + Chr(10) + "¿Desea ingresar otra ubicación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If respuesta = vbNo Then
                    Me.Dispose()
                Else
                    Call INICIALIZA()
                    ubi_codigo = 0
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        _ubi_codigo = 0
        Call INICIALIZA()
    End Sub

    Private Sub CARGA_COMBO_ZONA()
        Dim _msg As String
        Try
            Dim classZona As class_zonas = New class_zonas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classZona.cnn = _cnn
            classZona.btu_codigo = cmbTipo.SelectedValue

            _msg = ""
            ds = classZona.ZONAS_CARGA_ZONAS(_msg)
            If _msg = "" Then
                Me.cmbZona.DataSource = ds.Tables(0)
                Me.cmbZona.DisplayMember = "MENSAJE"
                Me.cmbZona.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ZONA", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub cmbTipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipo.SelectionChangeCommitted
        If cmbTipo.SelectedValue >= 0 Then
            Call CARGA_COMBO_ZONA()
        End If
    End Sub

    Private Sub btnUbicaciones_Click(sender As Object, e As EventArgs) Handles btnUbicaciones.Click
        Call CARGA_COMBO_UBICACIONES_RELACIONADAS()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub
End Class