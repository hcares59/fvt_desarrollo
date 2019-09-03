Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ingreso_ubicaciones
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
    Private Sub frm_ingreso_ubicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call INICIALIZA()
        If _ubi_codigo > 0 Then
            Call BUSCA_REGISTRO()

            cmbBodegas.Enabled = False
            cmbTipo.Enabled = False
            cmbZona.Enabled = False
            cmbAltura.Enabled = False
            txtEstado.Enabled = False
            txtNombre.Enabled = False
            ButtonAsocia.Enabled = True

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
            class_ubicacion.ubi_codigo = _ubi_codigo
            class_ubicacion.bod_codigo = 0
            class_ubicacion.tub_codigo = 0
            class_ubicacion.zon_codigo = 0
            class_ubicacion.eub_codigo = 0

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

                        cmbAltura.SelectedValue = ds.Tables(0).Rows(Fila)("alt_codigo")

                        txtEstado.Text = ds.Tables(0).Rows(Fila)("eub_nombre")
                        txtNombre.Text = ds.Tables(0).Rows(Fila)("ubi_nombre")
                        chkActivo.Checked = ds.Tables(0).Rows(Fila)("ubi_activo")

                        If ds.Tables(0).Rows(Fila)("ubi_para_pk") = True Then
                            ButtonBulto.Enabled = True
                        Else
                            ButtonBulto.Enabled = False
                        End If


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
        Call CARGA_COMBO_BODEGA()
        Call CARGA_COMBO_ALTURA()
        txtEstado.Text = ""
        txtNombre.Text = ""
        chkActivo.Checked = True
        ButtonAsocia.Enabled = False
        ButtonBulto.Enabled = False
    End Sub

    Private Sub CARGA_COMBO_ALTURA()
        Dim _msg As String
        Try
            Dim classAltura As class_alturas = New class_alturas
            Dim ds As DataSet = New DataSet

            ds = Nothing
            classAltura.cnn = _cnn

            _msg = ""
            ds = classAltura.CARGA_COMBO_ALTURA(_msg)
            If _msg = "" Then
                Me.cmbAltura.DataSource = ds.Tables(0)
                Me.cmbAltura.DisplayMember = "MENSAJE"
                Me.cmbAltura.ValueMember = "CODIGO"
            Else
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_COMBO_ALTURA", MsgBoxStyle.Critical, Me.Text)
        End Try
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

    Private Sub cmbBodegas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBodegas.SelectionChangeCommitted
        If cmbBodegas.SelectedValue >= 0 Then
            Call CARGA_COMBO_TIPO_UBICACION()
        End If
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

    Private Sub cmbTipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTipo.SelectionChangeCommitted
        If cmbTipo.SelectedValue >= 0 Then
            Call CARGA_COMBO_ZONA()
            Call OBTIENE_TIPO_UBICACION()
        End If
    End Sub

    Private Sub OBTIENE_TIPO_UBICACION()
        Dim class_tipo_ubicacion As class_tipo_ubicacion = New class_tipo_ubicacion
        Dim SearchChar As String = "-"
        Dim TestPos As Integer = 0
        Dim Fila As Integer = 0

        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            class_tipo_ubicacion.cnn = _cnn
            class_tipo_ubicacion.tub_codigo = 0
            class_tipo_ubicacion.tub_nombre = cmbTipo.SelectedText
            txtNombre.Enabled = False
            _msg = ""
            ds = class_tipo_ubicacion.TIPOS_UBICACIONES_LISTADO(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("tub_codigo") > 0 Then
                        If ds.Tables(0).Rows(Fila)("tub_nombreauto") = False Then
                            txtNombre.Enabled = True
                        End If
                    End If
                End If
            Else
                MessageBox.Show(_msg + "\CARGA_REGISTRO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "CARGA_REGISTRO", MsgBoxStyle.Critical, Me.Text)
        End Try
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

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click
        If cmbBodegas.Text = "" Then
            MessageBox.Show("Debe selecciona una bodega", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbBodegas.Focus()
            Exit Sub
        End If

        If cmbTipo.Text = "" Then
            MessageBox.Show("Debe selecciona un tipo de rack", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTipo.Focus()
            Exit Sub
        End If

        If cmbZona.Text = "" Then
            MessageBox.Show("Debe selecciona una zona", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbZona.Focus()
            Exit Sub
        End If

        If cmbAltura.Text = "" Then
            MessageBox.Show("Debe selecciona una altura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbAltura.Focus()
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
                classUbicacion.alt_codigo = cmbAltura.SelectedValue

                If txtNombre.Text = "" Then
                    classUbicacion.ubi_nombre = "-"
                Else
                    classUbicacion.ubi_nombre = txtNombre.Text
                End If

                classUbicacion.ubi_activo = chkActivo.Checked

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
                    Else
                        _ubi_codigo = ds.Tables(0).Rows(0)("codigo")
                        txtNombre.Text = ds.Tables(0).Rows(0)("mensaje")
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
                                            + Chr(10) + "¿Desea asociar algun proveedor a la ubicación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Call BUSCA_REGISTRO()
                If respuesta = vbNo Then
                    Me.Dispose()
                Else
                    cmbBodegas.Enabled = False
                    cmbTipo.Enabled = False
                    cmbZona.Enabled = False
                    cmbAltura.Enabled = False
                    txtEstado.Enabled = False
                    txtNombre.Enabled = False
                    ButtonAsocia.Enabled = True

                    Dim frm As frm_ubicacion_asocia_proveedor = New frm_ubicacion_asocia_proveedor
                    frm.cnn = _cnn
                    frm.ubi_codigo = _ubi_codigo
                    frm.bodega = cmbBodegas.Text
                    frm.tipoZona = cmbTipo.Text
                    frm.Zona = cmbZona.Text
                    frm.Altura = cmbAltura.Text
                    frm.ubicacionNombre = txtNombre.Text
                    frm.ShowDialog()
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonAsocia_Click(sender As Object, e As EventArgs) Handles ButtonAsocia.Click
        Dim frm As frm_ubicacion_asocia_proveedor = New frm_ubicacion_asocia_proveedor
        frm.cnn = _cnn
        frm.ubi_codigo = _ubi_codigo
        frm.bodega = cmbBodegas.Text
        frm.tipoZona = cmbTipo.Text
        frm.Zona = cmbZona.Text
        frm.Altura = cmbAltura.Text
        frm.ubicacionNombre = txtNombre.Text
        frm.ShowDialog()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub

    Private Sub ButtonBulto_Click(sender As Object, e As EventArgs) Handles ButtonBulto.Click
        Dim frm As frm_ubicacion_asocia_producto_bulto = New frm_ubicacion_asocia_producto_bulto
        frm.cnn = _cnn
        frm.ubi_codigo = _ubi_codigo
        frm.bodega = cmbBodegas.Text
        frm.tipoZona = cmbTipo.Text
        frm.Zona = cmbZona.Text
        frm.Altura = cmbAltura.Text
        frm.ubicacionNombre = txtNombre.Text
        frm.ShowDialog()
    End Sub
End Class