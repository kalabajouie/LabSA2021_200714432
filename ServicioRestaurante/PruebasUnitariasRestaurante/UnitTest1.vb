Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1
    Dim restaurante As New ServicioRestaurante.Restaurante

    <TestMethod()> Public Sub TestMethod1()
        Dim resultado As String = restaurante.RecibirPedidoCliente("café con pan")

        Assert.AreEqual(resultado, "Se ha tomado su pedido de café con pan, el ID de su pedido es 1")

    End Sub


    <TestMethod()> Public Sub TestMethod2()
        Dim resultado As String = restaurante.EstadoPedidoCliente(1)

        Assert.AreEqual(resultado, "Su pedido: café con pan está en preparacion.")

    End Sub

End Class