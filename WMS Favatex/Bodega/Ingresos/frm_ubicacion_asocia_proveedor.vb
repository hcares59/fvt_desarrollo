Imports System.Transactions
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class frm_ubicacion_asocia_proveedor
    Private _cnn As String
    Private _ubi_codigo As Integer
    Private _bodega As String
    Private _tipoZona As String
    Private _Zona As String
    Private _Altura As String
    Private _ubicacionNombre As String
    Public Property cnn() As String
        Get
            Return _cnn
        End Get
        Set(ByVal value As String)
            _cnn = value
        End Set
    End Property
    Public Property bodega() As String
        Get
            Return _bodega
        End Get
        Set(ByVal value As String)
            _bodega = value
        End Set
    End Property
    Public Property tipoZona() As String
        Get
            Return _tipoZona
        End Get
        Set(ByVal value As String)
            _tipoZona = value
        End Set
    End Property
    Public Property Altura() As String
        Get
            Return _Altura
        End Get
        Set(ByVal value As String)
            _Altura = value
        End Set
    End Property
    Public Property Zona() As String
        Get
            Return _Zona
        End Get
        Set(ByVal value As String)
            _Zona = value
        End Set
    End Property
    Public Property ubicacionNombre() As String
        Get
            Return _ubicacionNombre
        End Get
        Set(ByVal value As String)
            _ubicacionNombre = value
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

    Private Sub frm_ubicacion_asocia_proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDetalle.Text = _bodega + " | " + _tipoZona + " | " + _Zona + " | " + _Altura + " | " + _ubicacionNombre
        Call CARGA_UBICACION_SIN_PROVEEDORES()
        Call CARGA_UBICACION_CON_PROVEEDORES()
    End Sub

    Private Sub CARGA_UBICACION_SIN_PROVEEDORES()
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.ubi_codigo = _ubi_codigo

            _msg = ""
            GrillaSinAsoc.Rows.Clear()
            ds = classUbicaciones.CARGA_UBICACIONES_SIN_PROVEEDORES(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    'lblSinRelacionar.Text = "Registros encontrados: 0"
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSinAsoc.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                        False,
                                        ds.Tables(0).Rows(Fila)("car_nombre"))
                            Fila = Fila + 1
                        Loop
                        'lblSinRelacionar.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_UBICACION_SIN_PROVEEDORES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "\CARGA_UBICACION_SIN_PROVEEDORES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_UBICACION_CON_PROVEEDORES()
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.ubi_codigo = _ubi_codigo

            _msg = ""
            GrillaConAsoc.Rows.Clear()
            ds = classUbicaciones.CARGA_UBICACIONES_CON_PROVEEDORES(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    'lblSinRelacionar.Text = "Registros encontrados: 0"
                    If ds.Tables(0).Rows(Fila)("car_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaConAsoc.Rows.Add(ds.Tables(0).Rows(Fila)("car_codigo"),
                                        False,
                                        ds.Tables(0).Rows(Fila)("car_nombre"))
                            Fila = Fila + 1
                        Loop
                        'lblConRelacionar.Text = "Registros encontrados: " + ds.Tables(0).Rows.Count.ToString
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_UBICACION_SIN_PROVEEDORES", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "\CARGA_UBICACION_SIN_PROVEEDORES", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub ButtonSMarcar_Click(sender As Object, e As EventArgs) Handles ButtonSMarcar.Click
        Call MARCAR_TODOS()
    End Sub

    Private Sub MARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaSinAsoc.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub ButtonSDesmarcar_Click(sender As Object, e As EventArgs) Handles ButtonSDesmarcar.Click
        Call DESMARCAR_TODOS()
    End Sub

    Private Sub DESMARCAR_TODOS()
        For Each row As DataGridViewRow In Me.GrillaSinAsoc.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call MARCAR_TODOS_ASOC()
    End Sub

    Private Sub MARCAR_TODOS_ASOC()
        For Each row As DataGridViewRow In Me.GrillaConAsoc.Rows
            row.Cells(1).Value = True
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call DESMARCAR_TODOS_ASOC()
    End Sub

    Private Sub DESMARCAR_TODOS_ASOC()
        For Each row As DataGridViewRow In Me.GrillaConAsoc.Rows
            row.Cells(1).Value = False
        Next
    End Sub

    Private Sub btn_selecciona_Click(sender As Object, e As EventArgs) Handles btn_selecciona.Click
        Dim carCodigo As Integer = 0
        Dim Seleccion As Boolean = False

        For Each row As DataGridViewRow In Me.GrillaSinAsoc.Rows
            carCodigo = row.Cells(0).Value
            Seleccion = row.Cells(1).Value
            If Seleccion = True Then
                SELECCIONA_REGISTRO(Val(carCodigo))
            End If
        Next
        Call CARGA_UBICACION_SIN_PROVEEDORES()
        Call CARGA_UBICACION_CON_PROVEEDORES()
        MessageBox.Show("Selección de proveedores fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SELECCIONA_REGISTRO(ByVal carCodigo As Integer)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classUbicacion.cnn = _cnn
            classUbicacion.ubi_codigo = _ubi_codigo
            classUbicacion.car_codigo = carCodigo
            ds = classUbicacion.PROVEEDOR_ASOCIA_REGISTRO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    'fam_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If
            ds = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DESELECCIONA_REGISTRO(ByVal carCodigo As Integer)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.ubi_codigo = _ubi_codigo
            classUbicacion.car_codigo = carCodigo
            ds = classUbicacion.PROVEEDOR_DESASOCIA_REGISTRO(_msgError)
            If _msgError <> "" Then
                ds = Nothing
                MessageBox.Show(_msgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If ds.Tables(0).Rows(0)("codigo") < 0 Then
                    ds = Nothing
                    MessageBox.Show(ds.Tables(0).Rows(0)("mensaje"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    'fam_codigo = ds.Tables(0).Rows(0)("codigo")
                End If
            End If
            ds = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_deselecciona_Click(sender As Object, e As EventArgs) Handles btn_deselecciona.Click
        Dim carCodigo As Integer = 0
        Dim Seleccion As Boolean = False
        For Each row As DataGridViewRow In Me.GrillaConAsoc.Rows
            carCodigo = row.Cells(0).Value
            Seleccion = row.Cells(1).Value
            If Seleccion = True Then
                DESELECCIONA_REGISTRO(carCodigo)
            End If
        Next
        Call CARGA_UBICACION_SIN_PROVEEDORES()
        Call CARGA_UBICACION_CON_PROVEEDORES()
        MessageBox.Show("Desseleccion de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click

    End Sub

    Private Sub GrillaSinAsoc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSinAsoc.CellContentClick

    End Sub
End Class