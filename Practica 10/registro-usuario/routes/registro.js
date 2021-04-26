var cors = require('cors');
const express = require('express');
var jwt = require('jsonwebtoken');
const fs = require('fs');
const router = express.Router();
const registro = require('../services/registro');

var privateKey = fs.readFileSync(__dirname+ '/../id_rsa/private.key','utf8');
var publicKey = fs.readFileSync(__dirname +'/../id_rsa/public.key','utf8');

router.use(cors());

/* GET  */
router.get('/', async function(req, res, next) {
  try {
    res.json(await registro.getMultiple(req.query.page));
  } catch (err) {
    console.error(`Error al obtener el listado de usuarios registrados. `, err.message);
    next(err);
  }
});


/* POST */
router.post('/', async function(req, res, next) {
    var token = req.headers['authorization']
    if(!token)
    {
        return res.status(401).send({
            error: "Se debe autenticar para utilizar el servicio de registro!"
        })        
    }

    var resultado = comprobarToken(token);
    //return res.send({resultado: resultado});

    if(resultado.name){
        //    
        return res.status(401).send({
            error: "Token JWT no válido."
        })    
    }

    try {
        res.json(await registro.create(req.body));
    } catch (err) {
        if (err.message.includes("Duplicate")){
            console.error('Este CUI ya fue registrado previamente!');
        }else{
            console.error(`Error al acceder al servicio de registro de usuario.`, err.message);
        }
        next(err);
    }
});





function comprobarToken(token)
{
    token = token.replace('Bearer ', '')
    var payload = decodificar(token);
    if(!payload){
        return res.send({error:"Token JWT inválido."});
    }
    console.log(payload);
    var i  = 'admin-grupo6';          // Issuer 
    //var s  = username;        // Subject 
    var a  = 'grupo6-sa'; // Audience

    var verifyOptions = {
        issuer:  i,
        subject:  payload.payload.sub,
        audience:  a,
        expiresIn:  "10s",
        algorithm:  ["RS256"]
    };

    try{
        return jwt.verify(token, publicKey, verifyOptions);
    }catch (err){
        return err;
    }    
}

function decodificar(token){
    return jwt.decode(token, {complete: true});
}

module.exports = router;