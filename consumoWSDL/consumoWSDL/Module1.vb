Module Module1

    Dim ws As New WSCalculadora.CalculatorSoapClient

    Sub Main()
        'Se creará un menú de consola para seleccionar la operacion que se quiera realizar
        'En el metodo main de la aplicacion se crea un ciclo Do para repetir el menu

        Do
            Dim intInput As Integer = 0
            Dim v1, v2 As Decimal

            Console.WriteLine("")
            Console.WriteLine("Menú")
            Console.WriteLine("==========================")
            Console.WriteLine("1. Para SUMAR dos números")
            Console.WriteLine("2. Para RESTAR dos números")
            Console.WriteLine("3. Para MULTIPLICAR dos números")
            Console.WriteLine("4. Para DIVIDIR dos números")
            Console.WriteLine("5. Salir" & vbNewLine)
            Console.Write("Seleccione: ")

            If Integer.TryParse(Console.ReadLine(), intInput) Then
                Select Case intInput
                    Case 1
                        Console.WriteLine("Escriba dos valores para sumar")
                        If Decimal.TryParse(Console.ReadLine(), v1) And Decimal.TryParse(Console.ReadLine(), v2) Then
                            Console.WriteLine("La suma es " & suma(v1, v2))
                        End If
                    Case 2
                        Console.WriteLine("Escriba dos valores para restar")
                        If Decimal.TryParse(Console.ReadLine(), v1) And Decimal.TryParse(Console.ReadLine(), v2) Then
                            Console.WriteLine("La resta es " & resta(v1, v2))
                        End If
                    Case 3
                        Console.WriteLine("Escriba dos valores para multiplicar")
                        If Decimal.TryParse(Console.ReadLine(), v1) And Decimal.TryParse(Console.ReadLine(), v2) Then
                            Console.WriteLine("La multiplicación es " & multiplicacion(v1, v2))
                        End If
                    Case 4
                        Console.WriteLine("Escriba dos valores para dividir")
                        If Decimal.TryParse(Console.ReadLine(), v1) And Decimal.TryParse(Console.ReadLine(), v2) Then
                            Console.WriteLine("La división es " & division(v1, v2) & " el resultado es aproximado")
                        End If
                    Case 5
                        Exit Sub
                    Case Else
                        Console.WriteLine("Seleccione una opcion de 1 a 5")
                End Select
            Else
                Console.WriteLine("Seleccione una opcion de 1 a 5")
            End If
        Loop


    End Sub

    Private Function suma(v1 As Decimal, v2 As Decimal) As Decimal
        Dim resultado As Decimal = ws.Add(v1, v2)
        Return resultado
    End Function


    Private Function resta(v1 As Decimal, v2 As Decimal) As Decimal
        Dim resultado As Decimal = ws.Subtract(v1, v2)
        Return resultado
    End Function


    Private Function multiplicacion(v1 As Decimal, v2 As Decimal) As Decimal
        Dim resultado As Decimal = ws.Multiply(v1, v2)
        Return resultado
    End Function


    Private Function division(v1 As Decimal, v2 As Decimal) As Decimal
        Dim resultado As Decimal = ws.Divide(v1, v2)
        Return resultado
    End Function

End Module
