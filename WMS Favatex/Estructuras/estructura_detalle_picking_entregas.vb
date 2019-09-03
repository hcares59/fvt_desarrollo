Public Class estructura_detalle_picking_entregas
    Public Property pic_codigo As Integer
    Public Property pro_codigo As String
    Public Property pro_nombre As String
    Public Property sku_cartera As String
    Public Property sku_cartera_nombre As String
    Public Property pic_cantidad As Integer
    Public Property pic_num_bultos As Integer
    Public Property pic_total_bultos As Integer
    Public Property precio As Long
    Public Property pic_cantidad_encontrada As Integer
    Public Property pic_num_bultos_encontrado As Integer
    Public Property pic_total_bultos_encontrado As Integer
    Public Property num_orden_compra As Long
    Public Property fecha_orden_compra As Date
    Public Property con_codigounico As String

    Public Property con_despacharanumero As String
    Public Property con_despachara As String
    Public Property con_local As String
    Public Property con_localnombre As String
    Public Property rut_cliente As String
    Public Property nombre_cliente As String
    Public Property con_observacion As String
    Public Property pic_fechaocoriginal As Date
    Public Property pic_semodificafecha As Boolean
    Public Property pic_saldo As Integer
    Public Property pic_cantidad_entrega As Integer
    Public Property pic_bultos_por_entrega As Integer



    Public Sub New(ByVal _pic_codigo As Integer, ByVal _pro_codigo As String, ByVal _pro_nombre As String,
                   ByVal _sku_cartera As String, ByVal _sku_cartera_nombre As String, ByVal _pic_cantidad As Integer, ByVal _pic_num_bultos As Integer,
                   ByVal _pic_total_bultos As Integer, ByVal _precio As Long, ByVal _pic_cantidad_encontrada As Integer, ByVal _pic_num_bultos_encontrado As Integer,
                   ByVal _pic_total_bultos_encontrado As Integer, ByVal _nom_orden_compra As Long, ByVal _fecha_orden_compra As Date, ByVal _con_codigounico As String,
                   ByVal _con_despacharanumero As String, ByVal _con_despachara As String, ByVal _con_local As String, ByVal _con_localnombre As String,
                   ByVal _rut_cliente As String, ByVal _nombre_cliente As String, ByVal _con_observacion As String, ByVal _pic_fechaocoriginal As Date, ByVal _pic_semodificafecha As Boolean,
                   ByVal _pic_saldo As Integer, ByVal _pic_cantidad_entrega As Integer, ByVal _pic_bultos_por_entrega As Integer)
        Me.pic_codigo = _pic_codigo
        Me.pro_codigo = _pro_codigo
        Me.pro_nombre = _pro_nombre
        Me.sku_cartera = _sku_cartera
        Me.sku_cartera_nombre = _sku_cartera_nombre
        Me.pic_cantidad = _pic_cantidad
        Me.pic_num_bultos = _pic_num_bultos
        Me.pic_total_bultos = _pic_total_bultos
        Me.precio = _precio
        Me.pic_cantidad_encontrada = _pic_cantidad_encontrada
        Me.pic_num_bultos_encontrado = _pic_num_bultos_encontrado
        Me.pic_total_bultos_encontrado = _pic_total_bultos_encontrado
        Me.num_orden_compra = _nom_orden_compra
        Me.fecha_orden_compra = _fecha_orden_compra
        Me.con_codigounico = _con_codigounico
        Me.con_despacharanumero = _con_despacharanumero
        Me.con_despachara = _con_despachara
        Me.con_local = _con_local
        Me.con_localnombre = _con_localnombre
        Me.rut_cliente = _rut_cliente
        Me.nombre_cliente = _nombre_cliente
        Me.con_observacion = _con_observacion
        Me.pic_fechaocoriginal = _pic_fechaocoriginal
        Me.pic_semodificafecha = _pic_semodificafecha
        Me.pic_saldo = _pic_saldo
        Me.pic_cantidad_entrega = _pic_cantidad_entrega
        Me.pic_bultos_por_entrega = _pic_bultos_por_entrega

    End Sub
End Class
