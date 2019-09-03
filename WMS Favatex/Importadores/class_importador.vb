Imports System.IO 'esta libreria nos va a servir para poder activar el commandialog
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports Microsoft.VisualBasic

Module Importar

    Sub importarExcel(ByVal tabla As DataGridView, ByVal _cnn As String, ByVal car_codigo As Integer)
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xlsx"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString
            Dim Fila As Integer = 0
            Dim codInterno As Integer = 0
            Dim nomInterno As String = ""
            Dim proCodigoRel As Integer = 0
            Dim codInternoRel As String = ""
            Dim nomInternoRel As String = ""

            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            xSheet = "Hoja1"
            'xSheet = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
            conn = New OleDbConnection(
                              "Provider=Microsoft.ACE.OLEDB.12.0;" &
                              "data source=" & ExcelFile & "; " &
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [" & xSheet & "$]", conn)

                conn.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                If ds.Tables(0).Rows.Count > 0 Then
                    Do While Fila < ds.Tables(0).Rows.Count
                        codInterno = 0
                        nomInterno = ""
                        proCodigoRel = 0
                        codInternoRel = ""
                        nomInternoRel = ""

                        If Fila = 479 Then
                            Fila = Fila
                        End If

                        codInterno = retorna_codigo_interno(ds.Tables(0).Rows(Fila)(0), _cnn)
                        If codInterno = -1 Then
                            Exit Sub
                        End If

                        If codInterno > 0 Then
                            nomInterno = retorna_nombre_interno(ds.Tables(0).Rows(Fila)(0), _cnn)
                            If nomInterno = "Error" Then
                                Exit Sub
                            End If
                        End If


                        proCodigoRel = retorna_codigo_homologado(car_codigo, ds.Tables(0).Rows(Fila)(1), _cnn)
                        If proCodigoRel = -1 Then
                            Exit Sub
                        End If

                        If proCodigoRel > 0 Then
                            codInternoRel = retorna_codigointerno_homologado(car_codigo, ds.Tables(0).Rows(Fila)(1), _cnn)
                            If codInternoRel = "Error" Then
                                Exit Sub
                            End If

                            nomInternoRel = retorna_nombre_homologado(car_codigo, ds.Tables(0).Rows(Fila)(1), _cnn)
                            If nomInternoRel = "Error" Then
                                Exit Sub
                            End If
                        End If

                        tabla.Rows.Add(False,
                                       "",
                                       codInterno,
                                       ds.Tables(0).Rows(Fila)(0),
                                       nomInterno,
                                       ds.Tables(0).Rows(Fila)(1),
                                       ds.Tables(0).Rows(Fila)(2),
                                       proCodigoRel,
                                       codInternoRel,
                                       nomInternoRel)

                        If codInterno = 0 Then
                            PintaCeldaEnRojo(Fila, tabla)
                        Else
                            If proCodigoRel > 0 Then
                                PintaCeldaEnNaranjo(Fila, tabla)
                            End If
                        End If



                        Fila = Fila + 1
                        'Contador = Contador + 1
                    Loop
                End If

                MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")

                'tabla.DataSource = ds
                'tabla.DataMember = "MyData"
            Catch ex As Exception
                MessageBox.Show(Fila.ToString())
                MsgBox(ex.Message, MsgBoxStyle.Information, "Informacion")
            Finally
                conn.Close()
            End Try
        End If

    End Sub

    Private Function PintaCeldaEnNaranjo(ByVal fila As Integer, ByVal tabla As DataGridView) As Boolean
        Try
            tabla.Item(0, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(0, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(1, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(1, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(2, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(2, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(3, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(3, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(4, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(4, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(5, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(5, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(6, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(6, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(7, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(7, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(8, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(8, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)

            tabla.Item(9, fila).Style.BackColor = Color.FromArgb(255, 224, 192)
            tabla.Item(9, fila).Style.ForeColor = Color.FromArgb(255, 128, 0)


            PintaCeldaEnNaranjo = True
        Catch ex As Exception
            PintaCeldaEnNaranjo = False
            MessageBox.Show(ex.Message, "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function PintaCeldaEnRojo(ByVal fila As Integer, ByVal tabla As DataGridView) As Boolean
        Try
            tabla.Item(0, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(0, fila).Style.ForeColor = Color.Red

            tabla.Item(1, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(1, fila).Style.ForeColor = Color.Red

            tabla.Item(2, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(2, fila).Style.ForeColor = Color.Red

            tabla.Item(3, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(3, fila).Style.ForeColor = Color.Red

            tabla.Item(4, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(4, fila).Style.ForeColor = Color.Red

            tabla.Item(5, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(5, fila).Style.ForeColor = Color.Red

            tabla.Item(6, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(6, fila).Style.ForeColor = Color.Red

            tabla.Item(7, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(7, fila).Style.ForeColor = Color.Red

            tabla.Item(8, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(8, fila).Style.ForeColor = Color.Red

            tabla.Item(9, fila).Style.BackColor = Color.FromArgb(239, 197, 188)
            tabla.Item(9, fila).Style.ForeColor = Color.Red

            PintaCeldaEnRojo = True
        Catch ex As Exception
            PintaCeldaEnRojo = False
            MessageBox.Show(ex.Message, "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function retorna_nombre_homologado(ByVal car_codigo As String, ByVal sku_codigo As String, ByVal _cnn As String) As String
        Dim Class_Producto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            retorna_nombre_homologado = ""
            Class_Producto.cnn = _cnn
            Class_Producto.car_codigo = car_codigo
            Class_Producto.sku_codigo = sku_codigo

            ds = Class_Producto.retorna_nom_homologado(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    retorna_nombre_homologado = ds.Tables(0).Rows(Fila)("pro_nombre")
                End If
            Else
                retorna_nombre_homologado = "Error"
                MessageBox.Show(_msgError + "\retorna_nombre_homologado", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            retorna_nombre_homologado = "Error"
            MessageBox.Show(ex.Message + "\retorna_nombre_homologado", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function retorna_codigointerno_homologado(ByVal car_codigo As String, ByVal sku_codigo As String, ByVal _cnn As String) As String
        Dim Class_Producto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            retorna_codigointerno_homologado = ""
            Class_Producto.cnn = _cnn
            Class_Producto.car_codigo = car_codigo
            Class_Producto.sku_codigo = sku_codigo

            ds = Class_Producto.retorna_codinterno_homologado(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    retorna_codigointerno_homologado = ds.Tables(0).Rows(Fila)("pro_codigointerno")
                End If
            Else
                retorna_codigointerno_homologado = "Error"
                MessageBox.Show(_msgError + "\retorna_codigointerno_homologado", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            retorna_codigointerno_homologado = "Error"
            MessageBox.Show(ex.Message + "\retorna_codigointerno_homologado", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function retorna_codigo_homologado(ByVal car_codigo As String, ByVal sku_codigo As String, ByVal _cnn As String) As Integer
        Dim Class_Producto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            retorna_codigo_homologado = 0
            Class_Producto.cnn = _cnn
            Class_Producto.car_codigo = car_codigo
            Class_Producto.sku_codigo = sku_codigo

            ds = Class_Producto.retorna_cod_homologado(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    retorna_codigo_homologado = ds.Tables(0).Rows(Fila)("pro_codigo")
                End If
            Else
                retorna_codigo_homologado = -1
                MessageBox.Show(_msgError + "\retorna_codigo_homologado", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            retorna_codigo_homologado = -1
            MessageBox.Show(ex.Message + "\retorna_codigo_homologado", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function retorna_codigo_interno(ByVal codigo_int As String, ByVal _cnn As String) As Integer
        Dim Class_Producto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            retorna_codigo_interno = 0
            Class_Producto.cnn = _cnn
            Class_Producto.codigo_interno = codigo_int

            ds = Class_Producto.retorna_cod_interno(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    retorna_codigo_interno = ds.Tables(0).Rows(Fila)("pro_codigo")
                End If
            Else
                retorna_codigo_interno = -1
                MessageBox.Show(_msgError + "\obtiene_codigo_interno", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            retorna_codigo_interno = -1
            MessageBox.Show(ex.Message + "\obtiene_codigo_interno", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function retorna_nombre_interno(ByVal codigo_int As String, ByVal _cnn As String) As String
        Dim Class_Producto As class_producto = New class_producto
        Dim _msgError As String = ""
        Dim ds As DataSet
        Dim Fila As Integer = 0
        Try
            retorna_nombre_interno = ""
            Class_Producto.cnn = _cnn
            Class_Producto.codigo_interno = codigo_int

            ds = Class_Producto.retorna_nom_interno(_msgError)
            If _msgError = "" Then
                If ds.Tables(0).Rows.Count > 0 Then
                    retorna_nombre_interno = ds.Tables(0).Rows(Fila)("pro_nombre")
                End If
            Else
                retorna_nombre_interno = "Error"
                MessageBox.Show(_msgError + "\obtiene_codigo_interno", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            retorna_nombre_interno = "Error"
            MessageBox.Show(ex.Message + "\obtiene_codigo_interno", "Homologación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Module
