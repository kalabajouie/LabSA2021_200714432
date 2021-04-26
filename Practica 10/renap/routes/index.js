const { response } = require('express');
var express = require('express');
var router = express.Router();
const multer = require('multer');
const fileUpload = require('express-fileupload');
const morgan = require('morgan');
const _ = require('lodash');
const formidable = require('formidable');

const fs = require('fs');
const csv = require('csv-parser');


let Ciudadanos = require('./../services/ciudadano');
let Ciudadano = Ciudadanos.Ciudadano;


const conn = require('../services/conection');


/* GET home page. */
router.get('/', function(req, res) 
{  
  res.render('pages/index', {mensaje: 'F'});
});



/** POST login */
router.post('/login', function(req, res)
{
  var username = req.body.username; 
  var password = req.body.password;
  if(username=="admin" && password=="admin")
  {
    res.render('pages/load',);
  }
  else
  {
    res.render('pages/index', {mensaje:"Datos incorrectos."});
  }  
});


/**
 * Este end point recibe como parametro el número CUI 
 * Del ciudadano para buscar sus datos en la base de datos del sistema
 * RENAP 
 */
router.post('/cui', async function(req, res)
{
  //Número de CUI del ciudadano
  var cui = req.body.cui; 
  console.log("/CUI\t");
  if(cui)
  {
    var data = await getData(cui);  
    if(data==null)
    {
      res.status(400).send({msg:'Usuario Inexistente'});  
    }  
    else
    {      
      res.status(200).send(data);
    }      
  }  
  else
  {
      res.status(500).send('Debe enviar el número de cui.');
  }
});


router.get('/datos/:cui', async function(req, res)
{
  //Número de CUI del ciudadano
  var cui = req.params.cui; 
  console.log("/CUI\t");
  if(cui)
  {
    var data = await getData(cui);  
    if(data==null)
    {
      res.status(400).send({msg:'Usuario Inexistente'});  
    }  
    else
    {      
      res.status(200).send(data);
    }      
  }  
  else
  {
      res.status(500).send('Debe enviar el número de cui.');
  }
});


router.get('/datos', async function(req, res)
{  
  var data = await getAllData();  
  if(data==null)
  {
    res.status(400).send({msg:'No hay usuario en la base de datos'});  
  }  
  else
  {      
    res.status(200).send(data);
  }      
});


router.post('/upload', async function(req,res, next)
{  
  
  let archivoSubido;
  let archivoNuevo;
  var continuar = true;
  if (!req.files || Object.keys(req.files).length === 0) 
  {
    return res.status(500).send('Ningún archivo fue cargado.');
  }
  
  archivoSubido = req.files.archivo;
  archivoNuevo = __dirname + '/../tmp/' + archivoSubido.name;
    
  archivoSubido.mv(archivoNuevo, function(err) {
    if (err)
    {
      continuar = false;
      return res.status(500).send("Error al guardar el archivo.");
    }      
  });

  if(continuar)
  {   
    fs.createReadStream(archivoNuevo)
    .pipe(csv())
    .on('data', async (row) => 
    {
      //console.log(row);

      const sql  = {sql:`CALL registarCiudadano
                     (
                      ${BigInt(row.cui)}, 
                      '${row.nombres}',
                      '${row.apellidos}',
                      '${row.fecha_nacimiento}',
                      '${row.lugar_pais}',
                      '${row.lugar_departamento}', 
                      '${row.lugar_municipio}',
                      '${row.nacionalidad}', 
                      ${parseInt(row.sexo==='F' ? '0' : '1')}, 
                      ${parseInt(row.estado_civil==='' ? '0' : row.estado_civil)}, 
                      ${parseInt(row.servicio_militar==='' ? '0' :  row.servicio_militar)}, 
                      ${parseInt(row.privado_libertad==='' ? '0' : row.privado_libertad)}, 
                      ${parseInt(row.padron ==='' ? '0' : row.padron)}, 
                      '${row.foto}');
                      `,
                      timeout: 40000,
                      values: [
                      BigInt(row.cui), 
                      row.nombres, 
                      row.apellidos, 
                      row.fecha_nacimiento, 
                      row.lugar_pais, 
                      row.lugar_departamento, 
                      row.lugar_municipio,
                      row.nacionalidad, 
                      parseInt(row.sexo==='' ? '0' : row.sexo), 
                      parseInt(row.estado_civil==='' ? '0' : row.estado_civil), 
                      parseInt(row.servicio_militar==='' ? '0' :  row.servicio_militar), 
                      parseInt(row.privado_libertad==='' ? '0' : row.privado_libertad), 
                      parseInt(row.padron ==='' ? '0' : row.padron), 
                      row.foto]
                  };
                  //console.log(sql.sql);
                  const [rows, fields] =  await conn.execute(sql);                                                      
    })
    .on('end', () => 
    {
      console.log('CSV file successfully processed');
    });    

    res.render('pages/index', {mensaje: 'Archivo cargado. Se está procesando'});          
  }  
});



async function getData(cui)
{
  const sql = 
  { sql:`SELECT ciudadano.cui, ciudadano.nombre, ciudadano.apellidos, ciudadano.fechaNacimiento, pais.nombre as pais, departamento.nombre as departamento, municipio.nombre as municipio,
                nacionalidad.nombre AS nacionalidad, ciudadano.sexo, ciudadano.estadoCivil, ciudadano.servicioMilitar, ciudadano.privadoLibertad, ciudadano.padron, ciudadano.fotografia
                FROM ciudadanos AS ciudadano
                INNER JOIN paises AS pais ON ciudadano.codigoPais=pais.codigoPais
                INNER JOIN departamentos AS departamento ON ciudadano.codigoDepartamento=departamento.codigoDepartamento
                INNER JOIN municipios AS municipio ON ciudadano.codigoMunicipio=municipio.codigoMunicipio
                INNER JOIN paises AS nacionalidad ON ciudadano.codigoNacionalidad=nacionalidad.codigoPais
                WHERE ciudadano.cui=?;`,
    timeout: 40000,
    values: [cui]
  };   

  const [rows, fields] = await conn.execute(sql);
  //console.log(rows);
  if(rows.length===1)
  {
    return rows[0];
  }
  return null;
}

async function getAllData()
{
  const sql = 
  { sql:`SELECT ciudadano.cui, ciudadano.nombre, ciudadano.apellidos, ciudadano.fechaNacimiento, pais.nombre as pais, departamento.nombre as departamento, municipio.nombre as municipio,
                nacionalidad.nombre AS nacionalidad, ciudadano.sexo, ciudadano.estadoCivil, ciudadano.servicioMilitar, ciudadano.privadoLibertad, ciudadano.padron, ciudadano.fotografia
                FROM ciudadanos AS ciudadano
                INNER JOIN paises AS pais ON ciudadano.codigoPais=pais.codigoPais
                INNER JOIN departamentos AS departamento ON ciudadano.codigoDepartamento=departamento.codigoDepartamento
                INNER JOIN municipios AS municipio ON ciudadano.codigoMunicipio=municipio.codigoMunicipio
                INNER JOIN paises AS nacionalidad ON ciudadano.codigoNacionalidad=nacionalidad.codigoPais;`,
    timeout: 40000,
    values: []
  };   

  const [rows, fields] = await conn.execute(sql);    
  return rows;  
}


const storage = multer.diskStorage({
  destination: function(req, file, cb) {
      cb(null, 'tmp/');
  },  
  filename: function(req, file, cb) {
      cb(null, file.fieldname + '-' + Date.now() + path.extname(file.originalname));
  }
});

module.exports = router;