var cors = require('cors');
const express = require('express');
var jwt = require('jsonwebtoken');
const fs = require('fs');
const router = express.Router();
const creareleccion = require('../services/creareleccion');

var privateKey = fs.readFileSync(__dirname+ '/../id_rsa/private.key','utf8');
var publicKey = fs.readFileSync(__dirname +'/../id_rsa/public.key','utf8');

router.use(cors());

/* GET  */
router.get('/eleccion', async function(req, res, next) {
    var token = req.headers['authorization']
    if(!token){
        return res.status(401).send({
            error: "Se debe autenticar para utilizar el servicio de elección!"
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
        //res.json(await creareleccion.getMultiple(req.query.page));
        res.json(await creareleccion.getTodo());
    } catch (err) {
        console.error(`Error al obtener la elección `, err.message);
        next(err);
    }
});


/* GET  */
router.get('/eleccion/:eleccion_id', async function(req, res, next) {
    try {
        const id_eleccion = req.params.eleccion_id;
        //res.json(await creareleccion.getMultiple(req.query.page));
        res.json(await creareleccion.getMultiple(id_eleccion));
    } catch (err) {
        console.error(`Error al obtener la elección `, err.message);
        next(err);
    }
});


/* POST */
router.post('/', async function(req, res, next) {
    var token = req.headers['authorization']
    if(!token){
        return res.status(401).send({
            error: "Se debe autenticar para utilizar el servicio de elección!"
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
        res.json(await creareleccion.create(req.body));
    } catch (err) {
        console.error(`Error al crear la elección`, err.message);
        next(err);
    }
});


function comprobarToken(token){
    token = token.replace('Bearer ', '')
    var payload = decodificar(token);
    if(!payload)
    {
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