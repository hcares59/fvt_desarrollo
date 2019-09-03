Public Class frm_ubicacion_asocia_producto_bulto
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
    Private Sub frm_ubicacion_asocia__producto_bulto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDetalle.Text = _bodega + " | " + _tipoZona + " | " + _Zona + " | " + _Altura + " | " + _ubicacionNombre
        Call CARGA_UBICACION_ASOCIADAS()
    End Sub

    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        If txtCodigo.Text = "" Then
            MessageBox.Show("Debe digitar el código del producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Call CARGA_UBICACION_SIN_ASOCIAR()
    End Sub

    Private Sub CARGA_UBICACION_SIN_ASOCIAR()
        Dim classUbicaciones As class_ubicaciones = New class_ubicaciones
        Dim Fila As Integer = 0
        Try
            Dim ds As DataSet = New DataSet
            Dim _msg As String
            ds = Nothing
            classUbicaciones.cnn = _cnn
            classUbicaciones.pro_codigointerno = Trim(txtCodigo.Text)
            classUbicaciones.ubi_codigo = _ubi_codigo

            _msg = ""
            GrillaSinAsoc.Rows.Clear()
            ds = classUbicaciones.CARGA_UBICACIONES_SIN_UBICACION_ASOC(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaSinAsoc.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                        False,
                                        ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                        ds.Tables(0).Rows(Fila)("bulto"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_UBICACION_SIN_ASOCIAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "\CARGA_UBICACION_SIN_ASOCIAR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub CARGA_UBICACION_ASOCIADAS()
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
            ds = classUbicaciones.CARGA_UBICACIONES_CON_UBICACION_ASOC(_msg)
            If _msg = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(Fila)("pro_codigo") > 0 Then
                        Do While Fila < ds.Tables(0).Rows.Count
                            GrillaConAsoc.Rows.Add(ds.Tables(0).Rows(Fila)("pro_codigo"),
                                        False,
                                        ds.Tables(0).Rows(Fila)("pro_codigointerno"),
                                        ds.Tables(0).Rows(Fila)("bulto"))
                            Fila = Fila + 1
                        Loop
                    End If
                End If

            Else
                MessageBox.Show(_msg + "\CARGA_UBICACION_SIN_ASOCIAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + " " + "\CARGA_UBICACION_SIN_ASOCIAR", MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub btn_selecciona_Click(sender As Object, e As EventArgs) Handles btn_selecciona.Click
        Dim proCodigo As Integer = 0
        Dim Seleccion As Boolean = False
        Dim bulCodigo As Integer = 0

        For Each row As DataGridViewRow In Me.GrillaSinAsoc.Rows
            proCodigo = row.Cells(0).Value
            Seleccion = row.Cells(1).Value
            bulCodigo = row.Cells(3).Value
            If Seleccion = True Then
                SELECCIONA_REGISTRO(Val(proCodigo), Val(bulCodigo))
            End If
        Next
        Call CARGA_UBICACION_SIN_ASOCIAR()
        Call CARGA_UBICACION_ASOCIADAS()
        MessageBox.Show("Selección de productos fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SELECCIONA_REGISTRO(ByVal proCodigo As Integer, ByVal bulCodigo As Integer)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""

        Try
            classUbicacion.cnn = _cnn
            classUbicacion.ubi_codigo = _ubi_codigo
            classUbicacion.pro_codigo = proCodigo
            classUbicacion.bul_codigo = bulCodigo

            ds = classUbicacion.UBICACION_ASOCIA_REGISTRO(_msgError)
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
        Dim proCodigo As Integer = 0
        Dim Seleccion As Boolean = False
        Dim bulCodigo As Integer = 0

        For Each row As DataGridViewRow In Me.GrillaConAsoc.Rows
            proCodigo = row.Cells(0).Value
            Seleccion = row.Cells(1).Value
            bulCodigo = row.Cells(3).Value
            If Seleccion = True Then
                DESELECCIONA_REGISTRO(proCodigo, bulCodigo)
            End If
        Next
        Call CARGA_UBICACION_SIN_ASOCIAR()
        Call CARGA_UBICACION_ASOCIADAS()
        MessageBox.Show("Desseleccion de producto fue hecha en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DESELECCIONA_REGISTRO(ByVal proCodigo As Integer, ByVal bulCodigo As Integer)
        Dim classUbicacion As class_ubicaciones = New class_ubicaciones
        Dim ds As DataSet = New DataSet
        Dim _msgError As String = ""
        Dim fila As Integer = 0
        Dim _msg As String = ""
        Try
            classUbicacion.cnn = _cnn
            classUbicacion.ubi_codigo = _ubi_codigo
            classUbicacion.pro_codigo = proCodigo
            classUbicacion.bul_codigo = bulCodigo
            ds = classUbicacion.UBICACION_DESASOCIA_REGISTRO(_msgError)
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

    Private Sub ButtonGurdar_Click(sender As Object, e As EventArgs) Handles ButtonGurdar.Click

    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Me.Dispose()
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

    Private Sub GrillaSinAsoc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSinAsoc.CellContentClick
        If e.ColumnIndex = Me.GrillaSinAsoc.Columns.Item(1).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaSinAsoc.Rows(e.RowIndex).Cells(1)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub

    Private Sub GrillaConAsoc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaConAsoc.CellContentClick
        If e.ColumnIndex = Me.GrillaConAsoc.Columns.Item(1).Index Then
            Dim chkCell As DataGridViewCheckBoxCell = Me.GrillaConAsoc.Rows(e.RowIndex).Cells(1)
            chkCell.Value = Not chkCell.Value
        End If
    End Sub
End Class