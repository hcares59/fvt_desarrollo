Imports System.Data.SqlClient
Imports System.Data
Imports System.Transactions
Imports System.IO

Public Class frm_img_pallet
    Dim _cnn As String = "Data Source=192.168.1.8\POSEIDONSQL;Initial Catalog=APPFVT_01;User ID=sa;Password=S1nc0ntr4s3n4db4.2017"
    Dim a As Integer, b As Integer, c As Integer
    Dim Lista As ArrayList = New ArrayList(c)
    Dim archivos() As String

    Private Sub frm_img_pallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LIMPIAR()
    End Sub

    Private Sub LIMPIAR()
        txtCodigo.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call LIMPIAR()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Mi_Colección()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ms As New MemoryStream
        Dim cnn As SqlConnection

        cnn = New SqlConnection(_cnn)
        cnn.Open()
        ms = New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        If Inserta_Imagen_set(ms, cnn) = True Then
            MessageBox.Show("Guarda imagen en forma correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Se ah producido un error al guardar la imagen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Function Inserta_Imagen_set(ByVal ImagenBox As MemoryStream, ByVal cnn As SqlConnection) As Boolean
        'Dim cn As New SqlConnection(Me._StringConexion)
        Try
            'cn.Open()
            Dim arrImage() As Byte = ImagenBox.GetBuffer
            Dim cmd As New SqlCommand("UPDATE imagen_pallet SET ipa_imagen = @Imagen WHERE ipa_codigo = @ipa_codigo", cnn)

            With cmd
                .Parameters.Add(New SqlParameter("@imagen", SqlDbType.Image)).Value = arrImage
                .Parameters.Add(New SqlParameter("@ipa_codigo", SqlDbType.Int)).Value = CInt(txtCodigo.Text)
            End With
            cmd.ExecuteNonQuery()
            Inserta_Imagen_set = True
        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Inserta_Imagen_set = False
        Catch ex As Exception
            MsgBox(ex.Message)
            Inserta_Imagen_set = False
        Finally
            'cn.Close()
        End Try
    End Function

    Sub Mi_Colección()
        Try
            Dim ofd As New OpenFileDialog

            With ofd
                .Filter = "Archivos JPEG|*.jpg|Archivos BMP|*.bmp|Archivos PNG|*.png|Todos los archivos|*.*"
                .FilterIndex = 1
                .Multiselect = True
                If .ShowDialog() = DialogResult.OK Then
                    Lista.Clear()
                    PictureBox1.Image = Nothing

                    'agregamos los elementos seleccionados a la lista
                    archivos = .FileNames
                    Dim i As Integer
                    For i = 0 To archivos.Length - 1
                        Lista.Add(archivos(i))
                    Next
                    c = Lista.Count
                    Label1.Text = "N° de archivos en la colección: " & c

                    'Leemos
                    Pasamos_la_ruta()
                End If
            End With


            ofd.Dispose() 'Liberamos
        Catch ex As Exception
            ex.Message.ToUpper()
        End Try
    End Sub

    Sub Pasamos_la_ruta()
        'Declaramos un IEnumerator 
        Dim enumerator As IEnumerator = Lista.GetEnumerator()

        'MessageBox.Show(obtenerNumeroBytes(Lista.Item(0)))

        While enumerator.MoveNext()
            Me.Text = "Leyendo imágenes..."
            'Mediante enumerator.MoveNext() pasamos la ruta a 
            'cada picturebox desde el array
            PictureBox1.Image = Image.FromFile(Lista.Item(0))


            'PictureBox7.BackColor = Color.Black
            'leer(PictureBox1)
            'Me.Text = "Listo !!"
            ' Label2.Text = enumerator.Current
        End While

        '  enumerator.Reset()
    End Sub


End Class