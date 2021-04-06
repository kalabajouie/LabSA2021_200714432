# LabSA2021_200714432
Repositorio para el laboratorio de Software Avanzado 1er semestre 2021

## Practica 8
Esta practica consistía en la implementacion de dos contenedores, uno era un servidor Apache2, y el otro era un servidor de Mysql, ambos se debían comunicar mediante Docker compose.

Para esta práctica se tomo como base el ejemplo que se muestra en el siguiente link

```
https://www.kodetop.com/crea-tu-ambiente-de-desarrollo-php-mysql-con-docker/
```
Primero en el _dockerfile_ se instala _php_ que servira como lenguaje backend para la conexion con Mysql, además de la extension _MySQLi_ que incluye una función de conexón.

Luego se crear el archivo _docker-compose.yml_ que incluye la creacion de la imagen de Mysql y de apache2, luego dicho archivo se construye usando la linea de comandos _docker-compose up -d_

Despues debe loguearse en el servidor mysql para crear una base de datos y una tabla con datos.

![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica8/bd.PNG "Se agrega el servicio SOAP.")


Como cuarto paso se agrega un archivo index.php que incluye la conexion a base de datos, un ciclo para leer las filas de la tabla y codigo html para presentarlo, en este punto fue donde falló mi conexion.

![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica8/fallo.PNG "Se agrega el servicio SOAP.")
