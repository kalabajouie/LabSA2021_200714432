﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace WSCalculadora
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="WSCalculadora.CalculatorSoap")>  _
    Public Interface CalculatorSoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Add", ReplyAction:="*")>  _
        Function Add(ByVal intA As Integer, ByVal intB As Integer) As Integer
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Add", ReplyAction:="*")>  _
        Function AddAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Subtract", ReplyAction:="*")>  _
        Function Subtract(ByVal intA As Integer, ByVal intB As Integer) As Integer
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Subtract", ReplyAction:="*")>  _
        Function SubtractAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Multiply", ReplyAction:="*")>  _
        Function Multiply(ByVal intA As Integer, ByVal intB As Integer) As Integer
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Multiply", ReplyAction:="*")>  _
        Function MultiplyAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Divide", ReplyAction:="*")>  _
        Function Divide(ByVal intA As Integer, ByVal intB As Integer) As Integer
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/Divide", ReplyAction:="*")>  _
        Function DivideAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface CalculatorSoapChannel
        Inherits WSCalculadora.CalculatorSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class CalculatorSoapClient
        Inherits System.ServiceModel.ClientBase(Of WSCalculadora.CalculatorSoap)
        Implements WSCalculadora.CalculatorSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function Add(ByVal intA As Integer, ByVal intB As Integer) As Integer Implements WSCalculadora.CalculatorSoap.Add
            Return MyBase.Channel.Add(intA, intB)
        End Function
        
        Public Function AddAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer) Implements WSCalculadora.CalculatorSoap.AddAsync
            Return MyBase.Channel.AddAsync(intA, intB)
        End Function
        
        Public Function Subtract(ByVal intA As Integer, ByVal intB As Integer) As Integer Implements WSCalculadora.CalculatorSoap.Subtract
            Return MyBase.Channel.Subtract(intA, intB)
        End Function
        
        Public Function SubtractAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer) Implements WSCalculadora.CalculatorSoap.SubtractAsync
            Return MyBase.Channel.SubtractAsync(intA, intB)
        End Function
        
        Public Function Multiply(ByVal intA As Integer, ByVal intB As Integer) As Integer Implements WSCalculadora.CalculatorSoap.Multiply
            Return MyBase.Channel.Multiply(intA, intB)
        End Function
        
        Public Function MultiplyAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer) Implements WSCalculadora.CalculatorSoap.MultiplyAsync
            Return MyBase.Channel.MultiplyAsync(intA, intB)
        End Function
        
        Public Function Divide(ByVal intA As Integer, ByVal intB As Integer) As Integer Implements WSCalculadora.CalculatorSoap.Divide
            Return MyBase.Channel.Divide(intA, intB)
        End Function
        
        Public Function DivideAsync(ByVal intA As Integer, ByVal intB As Integer) As System.Threading.Tasks.Task(Of Integer) Implements WSCalculadora.CalculatorSoap.DivideAsync
            Return MyBase.Channel.DivideAsync(intA, intB)
        End Function
    End Class
End Namespace
