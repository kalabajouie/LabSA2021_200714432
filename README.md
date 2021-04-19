# LabSA2021_200714432
Repositorio para el laboratorio de Software Avanzado 1er semestre 2021

## Practica 9
Esta practica constaba de 4 pasos, la primera utilizar la practica anterior (practica 8), luego agregar un 3er contenedor, se agregó como tercer contenedor un python:

```
FROM python:3

WORKDIR /usr/src/app

COPY requirements.txt ./
COPY holamundo.py ./

RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD [ "python", "./holamundo.py" ]
```
dockerfile python

Como tercer punto se debía usar volumenes y cargar datos a base de datos desde dicho volumen:

![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/main/pasos%20volumen.png "")
El volumen tiene un nombre fuera de docker _vol-sql_ y otro dentro del contenedor _volx_


Y por ultimo involucrar al tercer contenedor con los otros dos, en este caso la idea era obtener los datos de base de datos en el contenedor con python, y luego mandarlo hacia el contenedor con el servidor web apache 2 pero no fue implementeado.
