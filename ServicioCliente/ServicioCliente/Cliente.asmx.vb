Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Cliente
    Inherits System.Web.Services.WebService
    Shared colaPedidos As New Queue
    Shared colaPedidosListos As New Queue
    Shared colaPedidosRepartidor As New Queue
    Shared idPedido As Integer

    <WebMethod()>
    Public Function RecibirPedidoCliente(pedido As String) As String

        idPedido = idPedido + 1
        Dim clave_valor As New KeyValuePair(Of Integer, String)(idPedido, pedido)
        colaPedidos.Enqueue(clave_valor)

        'PedidoCliente(idPedido)
        Return "Su pedido " & pedido & " ha sido tomado, el ID es " & idPedido

    End Function

    <WebMethod()>
    Public Function EstadoPedidoCliente(idpedido As Integer) As String
        'metodo para buscar en que estado se encuentra un pedido en el restaurante
        Dim a As New KeyValuePair(Of Integer, String)()
        Dim respuesta As String = ""

        'Dim total = colaPedidos.Count
        'colaPedidos.Peek()

        'para revisar el estado del pedido del cliente se busca en una cola donde estan todos los pedidos "en proceso", 
        'si el id del pedido no se encuentra aca es posible que esté en la cola de pedidos "listos" o que no exista dicho registro
        For Each elemento In colaPedidos
            a = elemento
            If a.Key = idpedido Then
                'If elemento.ToString = colaPedidos.Peek.ToString Then
                '    'PedidoListoRepartidor(idp)
                '    Return "Pedido en preparación"
                'Else
                '    Return "Pedido en preparacion"
                'End If
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
    Public Function EstadoPedidoRepartidor(idpedido As Integer) As String
        'metodo para buscar en que estado se encuentra un pedido en la entrega

        Dim a As New KeyValuePair(Of Integer, String)()
        Dim respuesta As String = ""

        'se revisa en la cola de pedidos listos si se encuentra el ID pedido
        For Each elemento In colaPedidosListos
            a = elemento
            If a.Key = idpedido Then
                respuesta = "Su pedido: " & a.Value & ", está listo para ser entregado."
            End If
        Next

        'se revisa en la cola de pedidos en camino si se encuentra el ID pedido
        For Each elemento In colaPedidosRepartidor
            a = elemento
            If a.Key = idpedido Then
                respuesta = "Su pedido: " & a.Value & " está en camino."
            End If
        Next

        'si no se encuentra en ninguna de las dos colas es porque el ID no existe
        If respuesta = "" Then
            respuesta = "El pedido " & idpedido & " no fue encontrado en los registros de entrega."
        End If

        'luego de una busqueda se simula el cambio de estado de un pedido, sale de la cola de productos listos a la cola de productos en camino
        If colaPedidosListos.Count > 0 Then
            colaPedidosRepartidor.Enqueue(colaPedidosListos.Peek())
            colaPedidosListos.Dequeue()
        End If

        Return respuesta

    End Function


End Class