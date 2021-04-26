var cors = require('cors');
const router = require('express').Router();
var jwt = require('jsonwebtoken');
const fs = require('fs');
const { sign } = require('crypto');


var privateKey = fs.readFileSync(__dirname+ '/../id_rsa/private.key','utf8');
var publicKey = fs.readFileSync(__dirname +'/../id_rsa/public.key','utf8');

router.use(cors());

router.get('/registrar', async(req,res)=>
{
    res.json({
        error:null,
        data: 'data'
    });
});


router.post('/login', (req,res) =>
{
    var username = req.body.username;
    var password = req.body.password;
    
    if(!(username==='usuario1' && password==='@@@'))
    {
       return res.status(401).send({error:'Credenciales incorrectas.'});
    }

    // Comenzamos a generar el token jwt
    var tokenData = 
    {
        username: username
    }


    var i  = 'admin-grupo6';          // Issuer 
    var s  = username;        // Subject 
    var a  = 'grupo6-sa'; // Audience

    var signOptions = {
        issuer:  i,
        subject:  s,
        audience:  a,
        expiresIn:  "3m",
        algorithm:  "RS256"
       };

    var token = jwt.sign(tokenData,privateKey, signOptions );
    return res.send({token: token});

});


router.post('/secure', (req, res) => {
    var token = req.headers['authorization']
    if(!token)
    {
        return res.status(401).send({
          error: "Necesitas autenticarte."
        })        
    }

    var resultado = comprobarToken(token);
	console.log(resultado);
    return res.send({resultado: resultado});


})

function comprobarToken(token)
{
    token = token.replace('Bearer ', '')
    var payload = decodificar(token);
    if(!payload)
    {
        return res.send({error:"Token JWT inválido."});
    }
    console.log(payload.payload.sub);
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

    try
    {
        return jwt.verify(token, publicKey, verifyOptions);
    }catch (err)
    {
        return err;
    }    
}

function decodificar(token)
{
    return jwt.decode(token, {complete: true});    
 }


module.exports = router;