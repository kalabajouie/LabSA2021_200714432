const db = require('./db');
const helper = require('../helper');
const config = require('../config');
const fetch = require('node-fetch');
const https = require('https');
const http = require('http');


async function getMultiple(page = 1){
  const offset = helper.getOffset(page, config.listPerPage);
  const rows = await db.query(
    `SELECT CUI, DISPOSITIVO_MOVIL, NUMERO_TELEFONO, PIN, CORREO_ELECTRONICO, FECHA_HORA_REGISTRO, IP, DEPARTAMENTO, MUNICIPIO, UBICACION 
    FROM USUARIO LIMIT ?,?`, 
    [offset, config.listPerPage]
  );
  const data = helper.emptyOrRows(rows);
  const meta = {page};

  return {
    data,
    meta
  }
}


async function create(datos){
    
    let message;

    //comunicacion al servicio de renap
    await fetch('http://localhost:3000/datos/' + datos.cui)

    .then((resp) => resp.json())
    .then(async function(data) {

        if(!data.msg){
            
            if(data.servicioMilitar == '0' && data.privadoLibertad == '0'){
                var day1 = new Date(data.fechaNacimiento); 
                var day2 = new Date(Date.now());
    
                var difference= Math.abs(day2-day1);
                days = difference/(1000 * 3600 * 24)
    
                if (parseInt(days) > parseInt(6574)){
                    //message = 'La persona puede votar';
                    
                    const result = await db.query(
                        `INSERT INTO USUARIO 
                        (CUI, DISPOSITIVO_MOVIL, NUMERO_TELEFONO, PIN, CORREO_ELECTRONICO, FECHA_HORA_REGISTRO, IP, DEPARTAMENTO, MUNICIPIO, UBICACION)
                        VALUES 
                        (?, ?, ?, ?, ?, NOW(), ?, ?, ?, ?)`, 
                        [
                            datos.cui, datos.dispositivo, datos.numtel, datos.pin,
                            datos.correo, datos.ip, datos.departamento, datos.municipio, datos.ubicacion
                        ]
                    );
                
                    message = 'Error en el registro de usuario.';
                
                    if (result.affectedRows) {
                        message = 'Usuario registrado exitosamente!';
                    }else{
                        console.log(result);
                        message = result.message;
                    }
                }else {
                    console.log('La persona puede NO votar');
                    message = 'La persona aún no es mayor de edad';
                }
            }else{
                console.log("La persona esta incapacitada para votar.");
                message = 'La persona esta incapacitada para votar.';
            }
        }else{
            console.error('La persona no se encuentra registrada en RENAP.');
            message = 'La persona no se encuentra registrada en RENAP.';
        }
    })
    .catch(function(error) {
        console.log(error);
        if (error.message.includes("Duplicate")){
            message = 'Este CUI ya fue registrado previamente!';
        }else{
            message = error.message;
        }
    });
    
    return {message};
    
}

  
module.exports = {
    getMultiple,
    create
}
