var assert = require('assert');
const { json } = require('body-parser');
var expect = require('expect');
var Request = require("request");
describe('Pruebas unitarias sobre el servidor de backend', ()=>
{
    it('Prueba para verificar que el servicio está disponible', (done)=>
    {
        Request.get(            
        {
            url:"http://localhost:3000/",
        },
        function(error, response, body)
        {            
            if(!error)
            {
                expect(response.statusCode).toBe(200);
                done();
            }
            else
            {
                console.log(error);
            }
        });
    });

    it('Prueba de consulta de datos de usuario correcta Erick Roberto', (done)=>
    {
        Request.post(            
        {
            url:"http://localhost:3000/cui",
            form:
            {
                "cui":2616501300304,                
            },
        },
        function(error, response, body)
        {                    
            if(!error)
            {                
                var respuesta = JSON.parse(response.body);
                //console.log(respuesta.nombre);
                expect(response.statusCode).toBe(200);  
                expect(respuesta.cui).toBe(2616501300304);
                //expect(respuesta.nombre).toBe("Erick Roberto");                 
                done();
            }
            else
            {
                console.log(error);
            }
        }        
        );
    });  

    it('Prueba de datos incorrectos de usuario', (done)=>
    {
        Request.post(            
        {
            url:"http://localhost:3000/cui",
            form:
            {
                "cui":2616501300305,                
            },
        },
        function(error, response, body)
        {
            if(!error)
            {                                
                expect(response.statusCode).toBe(400);  
                done();
            }
            else
            {
                console.log(error);
            }
        }        
        );
    });    

});