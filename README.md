# LabSA2021_200714432
Repositorio para el laboratorio de Software Avanzado 1er semestre 2021

## Practica 4
Esta práctica consistía en agregar el ESB a los 3 servicios creados en la practica 3 (cliente, restaurante y repartidor) con el objetivo que dichos servicios tengan comunicacion entre ellos por medio del ESB. Ahora el servicio de Cliente podia hacer un pedido que recibia el servicio de Restaurante, tambien consultar en el Restaurante el estado de algún pedido. El restaurante podia indicarle a el Repartidor que un pedido estaba listo para ser entregado y el Repartidor podia indicar que el pedido habia sido entregado y eliminar el pedido de su cola de entregas

El lenguaje de programacion es .NET, para los tres servicios y el ESB se crearon 4 proyectos diferentes, cada servicio se ejecuta en puertos diferentes, por ejemplo:

```
http://localhost:54869/ESB.asmx
```
```
http://localhost:50697/Cliente.asmx
```
```
http://localhost:53157/Restaurante.asmx
```
```
http://localhost:53313/Repartidor.asmx
```

![Archivo importante en servicio Repartidor.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica4/4.png "ESB")
Archivo importante en servicio ESB.

![Archivo importante en servicio cliente.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica4/1.png "Cliente")
Archivo importante en servicio cliente.

![Archivo importante en servicio restaurante.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica4/2.png "Restaurante")
Archivo importante en servicio restaurante.

![Archivo importante en servicio Repartidor.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica4/3.png "Repartidor")
Archivo importante en servicio Repartidor.
