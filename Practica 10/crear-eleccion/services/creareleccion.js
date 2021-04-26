const db = require('./db');
const helper = require('../helper');
//const config = require('../config');


async function getTodo(){
  //const offset = helper.getOffset(page, config.listPerPage);
  const rows = await db.query(
    `
    SELECT ID_ELECCION, TITULO, DESCRIPCION, FECHA_HORA_INICIO, FECHA_HORA_FIN
    FROM ELECCION E
    ;
    `
  );
  const data = helper.emptyOrRows(rows);
  //const meta = {page};

  return {
    data
    //rows
    //,meta
  }
}


async function getMultiple(eleccion){
  //const offset = helper.getOffset(page, config.listPerPage);
  const rows = await db.query(
    `
    SELECT json_object(      
      'id_eleccion',ID_ELECCION, 'titulo', TITULO, 'descripcion', DESCRIPCION, 'fecha_inicio', FECHA_HORA_INICIO, 'fecha_fin', FECHA_HORA_FIN, 'estado', ESTADO, 'candidatos', (          
          SELECT CAST(CONCAT('[',GROUP_CONCAT(JSON_OBJECT('id_candidato', ID_CANDIDATO_ELECCION, 'titulo', TITULO, 'metadata', METADATA)),']')AS JSON) FROM CANDIDATO_ELECCION WHERE ELECCION_ID = E.ID_ELECCION
        )
    )X FROM ELECCION E
    WHERE ID_ELECCION = ?;
    `, 
    [eleccion]
  );
  const data = helper.emptyOrRows(rows);
  //const meta = {page};

  return {
    data
    //rows
    //,meta
  }
}

async function create(cadena){
    
  const result = await db.query(
    `
    INSERT INTO ELECCION 
    (TITULO, DESCRIPCION, FECHA_HORA_INICIO, FECHA_HORA_FIN, ESTADO) 
    VALUES 
    (?, ?, DATE_SUB(FROM_UNIXTIME(?/1000), INTERVAL '6' HOUR), DATE_SUB(FROM_UNIXTIME(?/1000), INTERVAL '6' HOUR), 0);
    `, 
    [
        cadena.titulo, cadena.descripcion, cadena.fecha_hora_inicio, cadena.fecha_hora_fin
    ]
  );

  for (i = 0; i < cadena.candidatos.length; i++){
    const result = await db.query(
      `
      INSERT INTO CANDIDATO_ELECCION 
      (ELECCION_ID, TITULO, IMAGEN, METADATA) 
      VALUES
      ((SELECT MAX(ID_ELECCION) FROM ELECCION), ?, ?, ?)`, 
      [
        cadena.candidatos[i].titulo_candidato, cadena.candidatos[i].imagen, cadena.candidatos[i].metadata
      ]
    );
  }

  let message = 'Error al crear la elección.';

  if (result.affectedRows) {
    message = 'Elección creada correctamente!';
  }

  return {message};
}

  
module.exports = {
    getMultiple,
    getTodo,
    create
}
