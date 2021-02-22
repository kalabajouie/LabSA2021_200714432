Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Repartidor
    Inherits System.Web.Services.WebService
    Shared colaPedidosRepartidor As New Queue
    Shared colaPedidosEntregados As New Queue


    <WebMethod()>
    Public Function RecibirEntregaRestaurante(idPedido As Integer, idRepartidor As Integer) As String

        'Se recibe un ID de pedido y un ID del repartidor al que fue asignado el pedido, esto se almacena en una cola

        Dim clave_valor As New KeyValuePair(Of Integer, Integer)(idPedido, idRepartidor)
        colaPedidosRepartidor.Enqueue(clave_valor)

        'se informa de la asignacion
        Return "El pedido " & idPedido & " se ha asignado al repartidor " & idRepartidor

    End Function


    <WebMethod()>
    Public Function EstadoPedidoCliente(idpedido As Integer) As String
        Dim a As New KeyValuePair(Of Integer, Integer)()
        Dim respuesta As String = ""


        'aca se busca el id del pedido en la cola de pedidos que estan en camino
        For Each elemento In colaPedidosRepartidor
            a = elemento
            If a.Key = idpedido Then
                respuesta = "Su pedido: " & a.Key & " está en camino."
            End If
        Next

        'aca se busca el id del pedido en la cola de pedidos que ya fueron entregados
        For Each elemento In colaPedidosEntregados
            a = elemento
            If a.Key = idpedido Then
                respuesta = "El pedido: " & a.Key & " ya fue entregado."
            End If
        Next

        'si el id del pedido no se encuentra en ninguna de las dos colas es porque no existe dicho ID
        If respuesta = "" Then
            respuesta = "El pedido " & idpedido & " no fue encontrado en los registros de ENTREGA."
        End If

        'luego de hacer la busqueda el primer elemento de la cola se mueve y se traslada a la cola de pedidos listos para entregar
        'esto es para simular que el pedido ya fue preparado y esta listo
        If colaPedidosRepartidor.Count > 0 Then
            colaPedidosEntregados.Enqueue(colaPedidosRepartidor.Peek())
            colaPedidosRepartidor.Dequeue()
        End If

        Return respuesta

    End Function


    <WebMethod()>
    Public Function PedidoEntregado(idpedido As Integer, idRepartidor As Integer) As String
        'se simula que el pedido fue entregado y el pedido se cierra
        Return "El repartidor " & idRepartidor & " informa que el pedido " & idpedido & " ya fue entregado."
    End Function

End Class