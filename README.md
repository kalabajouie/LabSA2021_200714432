# LabSA2021_200714432
Repositorio para el laboratorio de Software Avanzado 1er semestre 2021

## Practica 12
Esta practica estaba basada en la Practica 11, basicamente consistía en usar Terraform para obtener el archivo de configuración de determinada maquina virtual, algo asi como ingeniería inversa, para poder recrear la maquina virtual nuevamente.

Los comandos que hacen la magia son los siguientes:

```

terraform import google_compute_instance.default projects/concise-rex-312602/zones/us-west1-a/instances/demo-terraform2-194a7de826be8b8f

terraform show -no-color > codigo_generado.tf

```

- En la primera linea se hace el import y se indica el nombre de la VM.
- En la segunda linea se escribe la configuracion a un archivo llamado, en este caso, _codigo_generado.tf_

![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica12/cod.png "")


Al archivo generado (codigo_generado.tf) hay que hacerle algunos y luego renombrarlo como main.tf, con esto ya podemos hacer el _terraform plan_ y el _terraform apply_


![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica12/import.png "")
El archivo generado _codigo_generado.tf_



![Se agrega el servicio SOAP.](https://github.com/kalabajouie/LabSA2021_200714432/blob/Practica12/pr12.png "")
Se muestra la VM original y la nueva VM _copiada_ a partir de la original