Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Restaurante
    Inherits System.Web.Services.WebService
    Shared colaPedidos As New Queue
    Shared colaPedidosListos As New Queue
    Shared colaPedidosRepartidor As New Queue
    Shared idPedido As Integer

    <WebMethod()>
    Public Function RecibirPedidoCliente(descripcion_pedido As String) As String

        'con cada pedido nuevo se suma un 1 a la variable idPedido que simula ser el ID generado para cada pedido
        idPedido = idPedido + 1
        Dim clave_valor As New KeyValuePair(Of Integer, String)(idPedido, descripcion_pedido)
        colaPedidos.Enqueue(clave_valor)

        Return "Se ha tomado su pedido de " & descripcion_pedido & ", el ID de su pedido es " & idPedido

    End Function

    <WebMethod()>
    Public Function EstadoPedidoCliente(idpedido As Integer) As String
        Dim a As New KeyValuePair(Of Integer, String)()
        Dim respuesta As String = ""

        'para revisar el estado del pedido del cliente se busca en una cola donde estan todos los pedidos "en proceso", 
        'si el id del pedido no se encuentra aca es posible que esté en la cola de pedidos "listos" o que no exista dicho registro
        For Each elemento In colaPedidos
            a = elemento
            If a.Key = idpedido Then
                respuesta = "Su pedido: " & a.Value & " está en preparacion."
            End If
        Next

        'aca se busca el id del pedido en la cola de pedidos listos para ser entregados
        For Each elemento In colaPedidosListos
            a = elemento
            If a.Key = idpedido Then
                respuesta = "Su pedido: " & a.Value & " está listo para ser entregado."
            End If
        Next

        'si el id del pedido no se encuentra en ninguna de las dos colas es porque no existe dicho ID
        If respuesta = "" Then
            respuesta = "El pedido " & idpedido & " no fue encontrado en los registros."
        End If

        'luego de hacer la busqueda el primer elemento de la cola se mueve y se traslada a la cola de pedidos listos para entregar
        'esto es para simular que el pedido ya fue preparado y esta listo
        If colaPedidos.Count > 0 Then
            colaPedidosListos.Enqueue(colaPedidos.Peek())
            colaPedidos.Dequeue()
        End If

        Return respuesta

    End Function

    <WebMethod()>
    Public Function PedidoListoRepartidor(idpedido As Integer, nombre_repartidor As String) As String
        Dim ESB As New WSESB.ESBSoapClient

        Return ESB.PedidoListoRepartidor(idpedido, nombre_repartidor)
    End Function



End Class