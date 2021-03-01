Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ESB
    Inherits System.Web.Services.WebService

#Region "metodos CLIENTE"
    <WebMethod()>
    Public Function PedidoCliente(descripcion_pedido As String) As String
        Dim restaurante As New WSRestaurante.RestauranteSoapClient

        Return restaurante.RecibirPedidoCliente(descripcion_pedido)
    End Function

    <WebMethod()>
    Public Function EstadoPedidoRestaurante(idpedido As Integer) As String
        Dim restaurante As New WSRestaurante.RestauranteSoapClient

        Return restaurante.EstadoPedidoCliente(idpedido)
    End Function

    <WebMethod()>
    Public Function EstadoPedidoRepartidor(idpedido As Integer) As String
        Dim repartidor As New WSRepartidor.RepartidorSoapClient

        Return repartidor.EstadoPedidoCliente(idpedido)
    End Function

#End Region


#Region "metodos RESTAURANTE"
    <WebMethod()>
    Public Function PedidoListoRepartidor(idpedido As Integer, nombre_repartidor As String) As String
        Dim repartidor As New WSRepartidor.RepartidorSoapClient

        Return repartidor.RecibirEntregaRestaurante(idpedido, nombre_repartidor)
    End Function
#End Region


#Region "metodos REPARTIDOR"
    <WebMethod()>
    Public Function PedidoEntregado(idpedido As Integer) As String
        Dim repartidor As New WSRepartidor.RepartidorSoapClient

        Return repartidor.PedidoEntregado(idpedido)
    End Function
#End Region

End Class