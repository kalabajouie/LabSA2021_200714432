Imports System.IO
Imports System.Net
Imports System.Text

Module Module1

    Sub Main()
        'Se creará un menú de consola para seleccionar la operacion que se quiera realizar
        'En el metodo main de la aplicacion se crea un ciclo Do para repetir el menu

        Do
            Dim intInput As Integer = 0
            Dim user_id As Integer = 0

            Console.WriteLine("")
            Console.WriteLine("Menú")
            Console.WriteLine("==========================")
            Console.WriteLine("1. Para LISTAR datos")
            Console.WriteLine("2. Para AGREGAR datos")
            Console.WriteLine("3. Para MODIFICAR datos")
            Console.WriteLine("4. Para ELIMINAR datos")
            Console.WriteLine("5. Salir" & vbNewLine)
            Console.Write("Seleccione: ")

            If Integer.TryParse(Console.ReadLine(), intInput) Then
                Select Case intInput
                    Case 1
                        Console.WriteLine("Escriba el ID de usuario")
                        If Integer.TryParse(Console.ReadLine(), user_id) Then
                            listar(user_id)
                        End If
                        'Exit Do
                    Case 2
                        Console.WriteLine("Escriba una cadena con los datos del nuevo usuario con el formato {'name':'xxx xxx', 'gender':'xxxx', 'email':'xxxxxx', 'status':'xxxxx'}")
                        agregar(Console.ReadLine())
                        'Exit Do
                    Case 3
                        Console.WriteLine("Escriba el ID del usuario a modificar junto con una cadena con los nuevos datos del usuario con el formato {'name':'xxx xxx', 'gender':'xxxx', 'email':'xxxxxx', 'status':'xxxxx'}")
                        update(Console.ReadLine(), Console.ReadLine())
                    Case 4
                        Console.WriteLine("Escriba el ID del usuario a eliminar")
                        If Integer.TryParse(Console.ReadLine(), user_id) Then
                            delete(user_id)
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

    Private Sub listar(user_id As Integer)

        'uri del WS al que se le concatena el id de usuario a listar
        Dim uri As String = "https://gorest.co.in/public-api/users/" & user_id

        Dim myReq As HttpWebRequest = WebRequest.Create(uri)
        Dim response As WebResponse = myReq.GetResponse()

        Using dataStream As Stream = response.GetResponseStream()
            ' Abrir el stream usando un StreamReader para facil acceso
            Dim reader As New StreamReader(dataStream)
            ' Leer el contenido
            Dim responseFromServer As String = reader.ReadToEnd()
            ' Mostrar el contenido
            Console.WriteLine(responseFromServer)
        End Using

        ' Limpiar la respuesta
        response.Close()

    End Sub

    Private Sub agregar(json_data As String)

        'uri del WS
        Dim uri As String = "https://gorest.co.in/public-api/users"
        Dim request As HttpWebRequest = WebRequest.Create(uri)

        'tipo de solicitud
        request.Method = "POST"

        'autorizacion con bearer token generado
        request.Headers.Add("Authorization", "Bearer d8ca0d76c2347ef1bcff6699952a821b12d691a572db797e6d3d4b89c6e90361")

        'tipo del contenido
        request.ContentType = "application/json"
        Dim json_bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(json_data)
        request.ContentLength = json_bytes.Length

        Dim stream As IO.Stream = request.GetRequestStream

        stream.Write(json_bytes, 0, json_bytes.Length)


        Dim response As HttpWebResponse = request.GetResponse

        Debug.Print(response.StatusDescription)

        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)          ' Abrir el stream usando un StreamReader para facil acceso
        Dim responseFromServer As String = reader.ReadToEnd()  ' Leer el contenido

        Console.WriteLine(responseFromServer)  ' Mostrar el contenido

    End Sub

    Private Sub update(user_id As Integer, json_data As String)

        'uri del WS al que se le concatena el id de usuario a modificar
        Dim uri As String = "https://gorest.co.in/public-api/users/" & user_id
        Dim request As HttpWebRequest = WebRequest.Create(uri)

        'tipo de solicitud
        request.Method = "PUT"

        'autorizacion con bearer token generado
        request.Headers.Add("Authorization", "Bearer d8ca0d76c2347ef1bcff6699952a821b12d691a572db797e6d3d4b89c6e90361")

        'tipo del contenido
        request.ContentType = "application/json"
        Dim json_bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(json_data)
        request.ContentLength = json_bytes.Length

        Dim stream As IO.Stream = request.GetRequestStream

        stream.Write(json_bytes, 0, json_bytes.Length)


        Dim response As HttpWebResponse = request.GetResponse

        Debug.Print(response.StatusDescription)

        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)          ' Abrir el stream usando un StreamReader para facil acceso
        Dim responseFromServer As String = reader.ReadToEnd()  ' Leer el contenido

        Console.WriteLine(responseFromServer)  ' Mostrar el contenido

    End Sub

    Private Sub delete(user_id As Integer)

        'uri del WS al que se le concatena el id de usuario a borrar
        Dim uri As String = "https://gorest.co.in/public-api/users/" & user_id
        Dim request As HttpWebRequest = WebRequest.Create(uri)

        'tipo de solicitud
        request.Method = "DELETE"

        'autorizacion con bearer token generado
        request.Headers.Add("Authorization", "Bearer d8ca0d76c2347ef1bcff6699952a821b12d691a572db797e6d3d4b89c6e90361")


        Dim response As HttpWebResponse = request.GetResponse

        Debug.Print(response.StatusDescription)

        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)          ' Abrir el stream usando un StreamReader para facil acceso
        Dim responseFromServer As String = reader.ReadToEnd()  ' Leer el contenido

        Console.WriteLine(responseFromServer)  ' Mostrar el contenido

    End Sub

End Module

