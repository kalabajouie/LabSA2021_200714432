/*Eliminar tablas*/
DROP TABLE IF EXISTS ciudadanos;
DROP TABLE IF EXISTS municipios;
DROP TABLE IF EXISTS departamentos;
DROP TABLE IF EXISTS paises;
DROP PROCEDURE IF EXISTS obtenerDatos; 
DROP PROCEDURE IF EXISTS registarCiudadano;
DROP PROCEDURE IF EXISTS verificarDatosGuardados;
DROP PROCEDURE IF EXISTS obtenerInformacion;

CREATE TABLE IF NOT EXISTS paises
(
    codigoPais INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS  departamentos
(
	codigoDepartamento INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR (100) NOT NULL
);

CREATE TABLE IF NOT EXISTS municipios
(
	codigoMunicipio INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS ciudadanos (
    cui BIGINT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    apellidos VARCHAR(255) NOT NULL,
    fechaNacimiento DATE NOT NULL,
    codigoMunicipio INT NOT NULL,
    codigoDepartamento INT NOT NULL,
    codigoPais INT NOT NULL,
    codigoNacionalidad INT NOT NULL,
    sexo INT NOT NULL,
    estadoCivil INT,
    servicioMilitar INT,
    privadoLibertad INT,
    fotografia VARCHAR(255) NOT NULL,
    padron INT,
    FOREIGN KEY (codigoPais) REFERENCES paises(codigoPais),
    FOREIGN KEY (codigoMunicipio) REFERENCES municipios(codigoMunicipio),
    FOREIGN KEY (codigoDepartamento) REFERENCES departamentos(codigoDepartamento),
    FOREIGN KEY (codigoNacionalidad) REFERENCES paises(codigoPais)
);



INSERT INTO paises(nombre) values("Guatemala"),("Costa Rica"),("El Salvador"),("Honduras"),("Panamá"),("Belice");
INSERT INTO departamentos(nombre) values("Peten"),("Zacapa"),("Jutiapa"),("Izabal"),("Santa Rosa"),("Chimaltenango"),("Sacatepequez"),("San Marcos");
INSERT INTO municipios(nombre) values("Sumpango"),("San Lucas"),("San Bartolomé"),("Santiago"),("Antigua Guatemala"),("Tecpán");



/*Procedimiento para obtener datos de los usuarios*/
DELIMITER $$
CREATE PROCEDURE verificarDatosGuardados(IN _pais VARCHAR(255), IN _departamento VARCHAR(255), IN _municipio VARCHAR(255), IN _nacionalidad VARCHAR(255))
BEGIN 
	INSERT INTO paises(`nombre`) SELECT _pais FROM DUAL WHERE NOT EXISTS(SELECT codigoPais FROM paises WHERE nombre = _pais);    
    INSERT INTO departamentos(`nombre`) SELECT _departamento FROM DUAL WHERE NOT EXISTS(SELECT codigoDepartamento FROM departamentos WHERE nombre = _departamento);    
    INSERT INTO municipios(`nombre`) SELECT _municipio FROM DUAL WHERE NOT EXISTS(SELECT codigoMunicipio FROM municipios WHERE nombre = _municipio);    
    INSERT INTO paises(`nombre`) SELECT _nacionalidad FROM DUAL WHERE NOT EXISTS(SELECT codigoPais FROM paises WHERE nombre = _nacionalidad);    
END$$

/*Procedimiento para obtener datos de los usuarios*/
DELIMITER $$
CREATE PROCEDURE obtenerDatos(IN _pais VARCHAR(255), IN _departamento VARCHAR(255), IN _municipio VARCHAR(255), IN _nacionalidad VARCHAR(255),
				OUT  codPais INT , OUT codDepartamento INT, OUT codMunicipio INT, OUT codNacionalidad INT)
BEGIN 
	CALL  verificarDatosGuardados(_pais, _departamento, _municipio, _nacionalidad);
    SELECT codigoPais INTO codPais FROM paises WHERE nombre = _pais;
    SELECT codigoDepartamento INTO codDepartamento FROM departamentos WHERE nombre = _departamento;
    SELECT codigoMunicipio INTO codMunicipio FROM municipios WHERE nombre = _municipio;
    SELECT codigoPais INTO codNacionalidad FROM paises WHERE nombre = _nacionalidad;        
END$$





/* Procedimiento para registar usuario.*/ 
DELIMITER $$ 
CREATE PROCEDURE registarCiudadano(IN _cui BIGINT, IN _nombre VARCHAR(255), IN _apellidos VARCHAR(255), IN _fechaNacimiento VARCHAR(255), IN _pais VARCHAR(255), IN _departamento VARCHAR(255), 
									IN _municipio VARCHAR(255),	IN _nacionalidad VARCHAR(255), IN _sexo INT, IN _estadoCivil INT, IN _servicioMilitar INT, 
                                    IN _privadoLibertad INT, IN _padron INT, IN _fotografia VARCHAR(255))
BEGIN
	CALL obtenerDatos(_pais, _departamento, _municipio, _nacionalidad, @codigoPais, @codigoDepartamento, @codigoMunicipio, @codigoNacionalidad);
    INSERT INTO ciudadanos(cui, nombre, apellidos, fechaNacimiento, codigoPais, codigoDepartamento, codigoMunicipio, codigoNacionalidad, sexo, estadoCivil, servicioMilitar,
							privadoLibertad, padron, fotografia) values 
                            (_cui, _nombre, _apellidos, STR_TO_DATE(_fechaNacimiento, '%Y-%m-%d'), @codigoPais, @codigoDepartamento, @codigoMunicipio, @codigoNacionalidad,
                            _sexo, _estadoCivil, _servicioMilitar, _privadoLibertad, _padron, _fotografia);
END $$


/*Vaciar las tablas*/
SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE TABLE ciudadanos;
TRUNCATE TABLE paises;
TRUNCATE TABLE municipios;
TRUNCATE TABLE departamentos;
SET FOREIGN_KEY_CHECKS = 1;

COMMIT;

SELECT * FROM paises;
SELECT * FROM departamentos;
SELECT * FROM municipios;
SELECT ciudadano.fechaNacimiento FROM ciudadanos as ciudadano;
SELECT * FROM ciudadanos;
-- CALL registarCiudadano (2616501302224, 'Erick Roberto', 'Tejaxun Xicon', '22-May-1993', 'Guatemala', 'Sacatepequez', 'Sumpango', 'Guatemala',1,0,0,0,90199219,'URL');
-- CALL registarCiudadano (2932093209299, 'Carlos  Ricardo', 'Estada', '20-Jun-1990', 'Guatemala', 'Chimaltenango', 'Tecpan', 'España',1,0,0,0,99999,'URL/2');
-- CALL registarCiudadano (0923902399291, 'Carla', 'Medinilla', '29-Dec-1989', 'Guatemala', 'Sacatepequez', 'Antigua Guatemala', 'Guatemala',1,0,0,0,2309139,'URL/3');


/*Consulta para obtener datos tales como se requiere por el endpoint servicio-renap/cui*/
SELECT ciudadano.cui, ciudadano.nombre, ciudadano.apellidos, ciudadano.fechaNacimiento, pais.nombre as pais, departamento.nombre as departamento, municipio.nombre as municipio,
nacionalidad.nombre AS nacionalidad, ciudadano.sexo, ciudadano.estadoCivil, ciudadano.servicioMilitar, ciudadano.privadoLibertad, ciudadano.padron, ciudadano.fotografia
FROM ciudadanos AS ciudadano
INNER JOIN paises AS pais ON ciudadano.codigoPais=pais.codigoPais
INNER JOIN departamentos AS departamento ON ciudadano.codigoDepartamento=departamento.codigoDepartamento
INNER JOIN municipios AS municipio ON ciudadano.codigoMunicipio=municipio.codigoMunicipio
INNER JOIN paises AS nacionalidad ON ciudadano.codigoNacionalidad=nacionalidad.codigoPais
WHERE ciudadano.cui=2616501300304;

DELIMITER $$
CREATE PROCEDURE obtenerInformacion(IN _cui BIGINT,
OUT cui BIGINT, OUT nombre VARCHAR(255),OUT apellidos VARCHAR(255), OUT pais VARCHAR(255), OUT departamento VARCHAR(255), OUT municipio VARCHAR(255), 
OUT nacionalidad VARCHAR(255), OUT sexo INT, OUT estadoCivil INT, OUT servicioMilitar INT, OUT privadoLibertad INT, OUT padron INT, OUT fotografia VARCHAR(255))
BEGIN 
	SELECT ciudadano.cui, ciudadano.nombre, ciudadano.apellidos, pais.nombre as pais, departamento.nombre as departamento, municipio.nombre as municipio,
	nacionalidad.nombre AS nacionalidad, ciudadano.sexo, ciudadano.estadoCivil, ciudadano.servicioMilitar, ciudadano.privadoLibertad, ciudadano.padron, ciudadano.fotografia
    INTO cui, nombre, apellidos, pais, departamento, municipio, nacionalidad, sexo, estadoCivil, servicioMilitar, privadoLibertad, padron, fotografia
	FROM ciudadanos AS ciudadano
	INNER JOIN paises AS pais ON ciudadano.codigoPais=pais.codigoPais
	INNER JOIN departamentos AS departamento ON ciudadano.codigoDepartamento=departamento.codigoDepartamento
	INNER JOIN municipios AS municipio ON ciudadano.codigoMunicipio=municipio.codigoMunicipio
	INNER JOIN paises AS nacionalidad ON ciudadano.codigoNacionalidad=nacionalidad.codigoPais
	WHERE ciudadano.cui=_cui;	
END$$





