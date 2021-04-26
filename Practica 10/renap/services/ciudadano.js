class Ciudadano
{

    constructor(status, cui, nombre, apellidos, fecha_nacimiento, municipio, departamento, pais, nacionalidad, 
        sexo, estado_civil, servicio_militar, privado_libertad, foto, padron)
    {
        this.status = status;
        this.cui = cui;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fecha_nacimiento;
        this.municipio = municipio;
        this.departamento = departamento;
        this.pais = pais;
        this.nacionalidad = nacionalidad;
        this.sexo = sexo;
        this.estadoCivil = estado_civil;
        this.servicioMilitar = servicio_militar;
        this.privadoLibertad = privado_libertad;
        this.foto = foto;
        this.padron = padron;
    }

}

module.exports = 
{
    Ciudadano: Ciudadano 
}
