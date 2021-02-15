# Readme.md - Practica 2

## Parte 1
La parte 1 de la practica consiste en generar un token JWT utilizando el header que siempre se utiliza en JWT, el payload que contiene el nombre y carnet de un estudiante en formato JSON, y por ultimo la firma creada con un secret generado automaticamente para cada estudiante ingresado.

![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte1/p2_11.PNG "Aplicacion de escritorio, se introduce el nombre y carnet y al presionar el boton se genera el token, utilizando un secret generado automaticamente para el carnet, dicho carnet y secret se almacenan en memoria.")
Aplicacion de escritorio, se introduce el nombre y carnet y al presionar el boton se genera el token, utilizando un secret generado automaticamente para el carnet, dicho carnet y secret se almacenan en memoria.


![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte1/p2_12.PNG "Se agrega el servicio SOAP.")
El token generado se verifica en:
```
https://jwt.io/
```
Y como se puede ver el header y payload coinciden pero la firma no esta verificado por no tener secret


![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte1/p2_13.PNG "Al agregar el secret de 32 caracteres generado se valida la firma y el token es valido..")
Al agregar el secret de 32 caracteres generado se valida la firma y el token es valido.


![Se valida un token introducido.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte1/p2_14.PNG "Se valida un token introducido")
Se valida un token introducido.


## Parte 2
La parte 2 de la practica consiste en consumir un servicio SOAP, el cual se encuentra en:

```
http://www.dneonline.com/calculator.asmx
```
Dicho servicio posee cuatro operaciones matematicas: suma, resta, multiplicación y división. El resultado de la operacion será un número entero. Se creó una aplicación de consola que permite consumir el mencionado servicio y utilizar las metodos matematicas para operar dos numeros.

Los metodos son _sumar()_, _restar()_, _multiplicar()_, _dividir()_ y como valor de retorno devuelven un numero entero con el resultado.

El codigo se encuentra en el archivo _Main.vb_

### Pruebas

![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte2/p2_1.PNG "Se agrega el servicio SOAP.")
Se agrega el servicio SOAP.

![Se prueba la suma.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte2/p2_2.PNG "Se prueba la suma.")
Se prueba la suma.

![Se prueba la resta.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte2/p2_3.PNG "Se prueba la resta.")
Se prueba la resta.

![Se prueba la multiplicacion.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte2/p2_4.PNG "Se prueba la multiplicacion.")
Se prueba la multiplicacion.

![Se prueba la division.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica2/Parte2/p2_5.PNG "Se prueba la division.")
Se prueba la division.
