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
    Public Function HacerPedidoRestaurante(descripcion_pedido As String) As String
        Dim ESB As New WSESB.ESBSoapClient

        Return ESB.PedidoCliente(descripcion_pedido)

    End Function

    <WebMethod()>
    Public Function EstadoPedidoRestaurante(idpedido As Integer) As String
        Dim ESB As New WSESB.ESBSoapClient

        Return ESB.EstadoPedidoRestaurante(idpedido)
    End Function

    <WebMethod()>
    Public Function EstadoPedidoRepartidor(idpedido As Integer) As String
        Dim ESB As New WSESB.ESBSoapClient

        Return ESB.EstadoPedidoRepartidor(idpedido)
    End Function


End Class