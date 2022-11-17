CREATE DATABASE COMPLEJO_CINE_v3
GO
USE COMPLEJO_CINE_v3
GO 
CREATE TABLE PROVINCIAS(
Id_Provincia INT,
Provincia VARCHAR(50)
CONSTRAINT PK_PROVINCIAS PRIMARY KEY (Id_Provincia)
)

CREATE TABLE LOCALIDADES (
Id_Localidad INT , 
Localidad VARCHAR(50),
Id_Provincia INT 
CONSTRAINT PK_LOCALIDADES PRIMARY KEY (Id_Localidad),
CONSTRAINT FK_LOCALIDADES_PROVINCIA FOREIGN KEY (Id_Provincia)
REFERENCES PROVINCIAS(Id_Provincia)
)

CREATE TABLE  BARRIOS(
Id_Barrio INT ,
Barrio VARCHAR(50),
Id_Localidad INT 
CONSTRAINT PK_BARRIOS PRIMARY KEY (Id_Barrio),
CONSTRAINT FK_BARRIOS_LOCALIDAD FOREIGN KEY (Id_Localidad)
REFERENCES LOCALIDADES (Id_Localidad)

)

CREATE TABLE CALLES(
Id_Calle INT,
Calle VARCHAR(50),
Id_Barrio INT
CONSTRAINT PK_CALLES PRIMARY KEY (Id_Calle),
CONSTRAINT FK_CALLES_BARRIO FOREIGN KEY (Id_Barrio)
REFERENCES BARRIOS (Id_Barrio)
 
)

CREATE TABLE GENEROS(
Id_Genero INT,
Genero VARCHAR(50)
CONSTRAINT PK_GENEROS PRIMARY KEY (Id_Genero)
)

CREATE TABLE TIPOS_DOCUMENTO (
Id_Tipo_Doc INT,
Tipo_Doc VARCHAR(50)
CONSTRAINT PK_TIPOS_DOCUMENTO PRIMARY KEY (Id_Tipo_Doc)
)

CREATE TABLE TIPOS_CONTACTO(
Id_Tipo_Contacto INT,
Tipo_Contacto Varchar(50)
CONSTRAINT PK_TIPOS_CONTACTO PRIMARY KEY (Id_Tipo_Contacto)

)

CREATE TABLE TIPOS_CLIENTES(
Id_Tipo_Clientes INT ,
Tipo_Cliente VARCHAR(50)

CONSTRAINT PK_TIPOS_CLIENTES PRIMARY KEY (Id_Tipo_Clientes) 
)

CREATE TABLE CLIENTES (
Id_Cliente INT ,
Apellido_Cliente VARCHAR (50),
Nombre_Cliente VARCHAR(50),
Id_Tipo_Cliente INT ,
Fecha_Nac DATETIME,
Id_Tipo_Doc INT,
Nro_Doc VARCHAR(50),
Id_Calle INT, 
Altura INT ,
Id_Genero INT ,
CONSTRAINT PK_CLIENTES PRIMARY KEY (Id_Cliente),
CONSTRAINT FK_CLIENTES_CALLE FOREIGN KEY (Id_Calle)
REFERENCES CALLES (Id_Calle),
CONSTRAINT FK_CLIENTES_TIPO_DOC FOREIGN KEY (Id_Tipo_Doc)
REFERENCES TIPOS_DOCUMENTO (Id_Tipo_Doc),
CONSTRAINT FK_CLIENTES_GENERO FOREIGN KEY (Id_Genero)
REFERENCES GENEROS (Id_Genero),
CONSTRAINT FK_CLIENTES_TIPOS_CLIENTE FOREIGN KEY (Id_Tipo_Cliente)
REFERENCES TIPOS_CLIENTES (Id_Tipo_Clientes)
)

CREATE TABLE EMPLEADOS (
Id_Empleado INT ,
Apellido_Empleado VARCHAR (50),
Nombre_Empleado VARCHAR(50),
Fecha_Nac DATETIME,
Fecha_Ingreso DATETIME,
Id_Tipo_Doc INT,
Nro_Doc VARCHAR(50),
Id_Calle INT, 
Altura INT ,
Id_Genero INT ,
Id_Contacto INT 
CONSTRAINT PK_EMPLEADOS PRIMARY KEY (Id_Empleado),
CONSTRAINT FK_EMPLEADOS_CALLE FOREIGN KEY (Id_Calle)
REFERENCES CALLES (Id_Calle),
CONSTRAINT FK_EMPLEADOS_TIPO_DOC FOREIGN KEY (Id_Tipo_Doc)
REFERENCES TIPOS_DOCUMENTO (Id_Tipo_Doc),
CONSTRAINT FK_EMPLEADOS_GENERO FOREIGN KEY (Id_Genero)
REFERENCES GENEROS (Id_Genero),
)

CREATE TABLE CONTACTOS_EMPLEADOS(
Id_Contacto_Empleado INT ,
Contacto VARCHAR(50),
Id_Tipo_Contacto INT,
Id_Empleado INT
CONSTRAINT PK_CONTACTOS_EMPLEADOS PRIMARY KEY (Id_Contacto_Empleado),
CONSTRAINT FK_CONTACTOS_EMPLEADOS_TIPO_CONTACTO FOREIGN KEY (Id_Tipo_Contacto)
REFERENCES Tipos_Contacto (Id_Tipo_Contacto),
CONSTRAINT FK_CONTACTOS_ID_EMPLEADO FOREIGN KEY (Id_Empleado)
REFERENCES EMPLEADOS(Id_Empleado)
)

CREATE TABLE CONTACTOS_CLIENTES(
Id_Contacto_Cliente INT ,
Contacto VARCHAR(50),
Id_Tipo_Contacto INT,
Id_Cliente INT
CONSTRAINT PK_CONTACTOS_CLIENTES PRIMARY KEY (Id_Contacto_Cliente),
CONSTRAINT FK_CONTACTOS_CLIENTES_TIPO_CONTACTO FOREIGN KEY (Id_Tipo_Contacto)
REFERENCES Tipos_Contacto (Id_Tipo_Contacto),
CONSTRAINT fk_contactos_id_cliente FOREIGN KEY (Id_Cliente)
REFERENCES CLIENTES(Id_Cliente)
)

CREATE TABLE TIPOS_COMPRA (
Id_Tipo_Compra INT ,
Tipo_Compra VARCHAR(50)
CONSTRAINT PK_TIPOS_COMPRA PRIMARY KEY (Id_Tipo_Compra)
)


CREATE TABLE TIPOS_GENERO_PELICULA (
Id_Tipo_Genero_Pelicula INT ,
Tipo_Genero_Pelicula VARCHAR(50)
CONSTRAINT PK_TIPOS_GENERO_PELICULA PRIMARY KEY (Id_Tipo_Genero_Pelicula)
)

CREATE TABLE PAIS_ORIGEN (
Id_Pais_Origen INT,
Pais VARCHAR(50)
CONSTRAINT PK_PAISES PRIMARY KEY (Id_Pais_Origen)

)

CREATE TABLE IDIOMAS (
Id_Idioma INT,
Idioma VARCHAR(50)
CONSTRAINT PK_IDIOMAS PRIMARY KEY (Id_Idioma)


)

CREATE TABLE CALIFICACIONES_ETARIAS(
Id_Calificacion_Etaria INT, 
Calificacion_Etarias VARCHAR(50),
CONSTRAINT PK_CALIFICACIONES_ETARIAS PRIMARY KEY (Id_Calificacion_Etaria)

)

CREATE TABLE PELICULAS (
Id_Pelicula INT,
Nombre VARCHAR(100),
Id_Genero INT,
Id_Pais_Origen INT,
Id_Calificacion_Etaria INT,
Id_Idioma INT,
Duracion INT,
Subtitulada BIT
CONSTRAINT PK_PELICULAS PRIMARY KEY (Id_Pelicula),
CONSTRAINT FK_PELICULAS_GENERO FOREIGN KEY (Id_Genero)
REFERENCES TIPOS_GENERO_PELICULA (Id_Tipo_Genero_Pelicula),
CONSTRAINT FK_PELICULAS_PAIS_ORIGEN FOREIGN KEY (Id_Pais_Origen)
REFERENCES PAIS_ORIGEN (Id_Pais_Origen),
CONSTRAINT FK_CALIFICACION_ETARIA FOREIGN KEY (Id_Calificacion_Etaria)
REFERENCES CALIFICACIONES_ETARIAS (Id_Calificacion_Etaria),
CONSTRAINT FK_PELICULAS_IDIOMA FOREIGN KEY (Id_Idioma) 
REFERENCES IDIOMAS (Id_Idioma)


)

CREATE TABLE TIPOS_SALA(
Id_Tipo_Sala INT,
Tipo_Sala VARCHAR(50)
CONSTRAINT PK_TIPOS_SALA PRIMARY KEY (Id_Tipo_Sala)
)

CREATE TABLE SALAS(
Id_Sala INT,
Capacidad INT,
Id_Tipo_Sala INT
CONSTRAINT PK_SALAS PRIMARY KEY (Id_Sala),
CONSTRAINT FK_SALAS_TIPO_SALAS FOREIGN KEY (Id_Tipo_Sala)
REFERENCES TIPOS_SALA (Id_Tipo_Sala)

)

CREATE TABLE TIPOS_BUTACAS(
Id_Tipo_Butaca INT,
Tipo_Butaca VARCHAR(50),
CONSTRAINT PK_TIPOS_BUTACAS PRIMARY KEY (Id_Tipo_Butaca)
)

CREATE TABLE BUTACAS(
Id_Butaca INT,
Id_Fila INT,
Nro_Butaca INT,
Id_Tipo_Butaca INT ,
Id_Sala INT 
CONSTRAINT PK_BUTACAS PRIMARY KEY (Id_Butaca),
CONSTRAINT FK_BUTACAS_TIPO_BUTACA FOREIGN KEY (Id_Tipo_Butaca)
REFERENCES TIPOS_BUTACAS (Id_Tipo_Butaca),
CONSTRAINT FK_BUTACAS_SALA FOREIGN KEY(Id_Sala)
REFERENCES SALAS (Id_Sala)

)

CREATE TABLE FUNCIONES(
Id_Funcion INT,
Id_Pelicula INT,
Id_Sala INT,
Dia DATETIME,
Horario TIME,
Precio_Actual FLOAT

CONSTRAINT PK_FUNCIONES PRIMARY KEY (Id_Funcion),
CONSTRAINT FK_FUNCIONES_PELICULA FOREIGN KEY (Id_Pelicula)
REFERENCES PELICULAS (Id_Pelicula),
CONSTRAINT FK_FUNCIONES_SALA FOREIGN KEY (Id_Sala)
REFERENCES SALAS(Id_Sala)
)

CREATE TABLE RESERVAS(
Id_Reserva INT,
Id_Cliente INT,
Fecha_Reserva DATETIME
CONSTRAINT PK_RESERVAS PRIMARY KEY (Id_Reserva)
CONSTRAINT FK_RESERVAS_CLIENTE FOREIGN KEY (Id_Cliente)
REFERENCES CLIENTES (Id_Cliente)

)

CREATE TABLE BUTACAS_FUNCIONES(
Id_Butaca_Funcion INT,
Id_Butaca INT, 
Id_Funcion INT,
Id_Reserva INT
CONSTRAINT PK_BUTACAS_FUNCIONES PRIMARY KEY (Id_Butaca_Funcion),
CONSTRAINT FK_BUTACAS_FUNCIONES_BUTACA FOREIGN KEY (Id_Butaca)
REFERENCES BUTACAS (Id_Butaca),
CONSTRAINT FK_BUTACAS_FUNCIONES_FUNCION FOREIGN KEY (Id_Funcion)
REFERENCES FUNCIONES (Id_Funcion),
CONSTRAINT FK_BUTACAS_FUNCIONES_RESERVA FOREIGN KEY (Id_Reserva)
REFERENCES RESERVAS (Id_Reserva)
)

--CREATE TABLE TICKETS (
--Id_Ticket INT,
--Butacas_Funciones INT,
----Id_Funcion INT

--CONSTRAINT PK_TICKETS PRIMARY KEY (Id_Ticket),
--CONSTRAINT FK_TICKETS_FUNCION FOREIGN KEY (Id_Funcion)
--REFERENCES FUNCIONES (Id_Funcion)


--)




CREATE TABLE COMPROBANTES (
Id_Comprobante INT,
Id_Empleado INT ,
Id_Cliente INT ,
Fecha DATETIME,
Hora DATETIME,
Id_Tipo_Compra INT,
Descuento FLOAT

CONSTRAINT PK_COMPRABANTES PRIMARY KEY (Id_Comprobante),
CONSTRAINT FK_COMPROBANTES_EMPLEADO FOREIGN KEY (Id_Empleado )
REFERENCES EMPLEADOS (Id_Empleado),
CONSTRAINT FK_COMPROBANTES_CLIENTE FOREIGN KEY (Id_Cliente)
REFERENCES CLIENTES (Id_Cliente),
CONSTRAINT FK_COMPROBANTES_TIPO_COMPRA FOREIGN KEY (Id_Tipo_Compra)
REFERENCES TIPOS_COMPRA (Id_Tipo_Compra)
)

CREATE TABLE FORMAS_PAGO(
Id_Forma_Pago INT,
Forma_Pago VARCHAR(50)
CONSTRAINT PK_FORMAS_PAGO PRIMARY KEY (Id_Forma_Pago)


)

CREATE TABLE DETALLES_COMBROBANTES(
Id_Detalle_Comprobante INT,
Id_Comprobante INT,
Id_Butaca_Funcion INT,
Precio_Historico FLOAT,
Cantidad INT,
Id_Forma_Pago INT

CONSTRAINT PK_DETALLES_COMPROBANTES PRIMARY KEY (Id_Detalle_Comprobante),
CONSTRAINT FK_DETALLES_COMBROBANTES_COMPROBANTE FOREIGN KEY (Id_Comprobante)
REFERENCES COMPROBANTES (Id_Comprobante),
CONSTRAINT FK_DETALLES_COMBROBANTES_FORMA_PAGO FOREIGN KEY (Id_Forma_Pago)
REFERENCES FORMAS_PAGO (Id_Forma_Pago),
CONSTRAINT FK_DETALLES_COMBROBANTES_BUTACAS_FUNCIONES FOREIGN KEY (Id_Butaca_Funcion)
REFERENCES BUTACAS_FUNCIONES(Id_Butaca_Funcion)
)
--INSERTS----

set dateformat 'dmy'
--PROVINCIAS
INSERT INTO PROVINCIAS(Id_Provincia,Provincia)
	VALUES(1,'Córdoba')

--LOCALIDADES
INSERT INTO LOCALIDADES(Id_Localidad,Localidad,Id_Provincia)
	VALUES(1,'Ciudad de Córdoba',1)

--BARRIOS
INSERT INTO BARRIOS(Id_Barrio,Barrio,Id_Localidad)
	VALUES(1,'Observatorio',1),
		(2,'Nueva Córdoba',1),
		(3,'San Martín',1),
		(4,'General Paz',1),
		(5,'Cofico',1),
		(6,'Alberdi',1),
		(7,'San Vicente',1),
		(8,'Centro',1),
		(9,'Alta Córdoba',1),
		(10,'Jardín',1)

--CALLES 
INSERT INTO CALLES(Id_Calle, Calle, Id_Barrio)
	VALUES(1,'La Pampa',1),
	(2,'Montevideo',1),
	(3,'Paso de los Andes',1),
	(4,'Boulevard Chacabuco',2),
	(5,'Buenos Aires',2),
	(6,'Deán Funes',6),
	(7,'Doctor Miguel Urrutia',6),
	(8,'Libertad',8),
	(9,'Gral. Justo José De Urquiza',9),
	(10,'Bedoya',5),
	(11,'25 de Mayo',4),
	(12,'Félix Frías',4),
	(13,'Panamá',4),
	(14,'Letizia',7),
	(15,'Estanislao Leartes',7),
	(16,'Concordia',7),
	(17,'Avenida Talleres',10),
	(18,'Pablo Belisle',10),
	(19,'Olimpia',10),
	(20,'Juan Patiño',10) 
	


---TIPOS GENEROS PELICULA------
INSERT INTO TIPOS_GENERO_PELICULA VALUES (1,'Accion')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (2,'Comedia')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (3,'Drama')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (4,'Terror')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (5,'Suspenso')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (6,'Documental')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (7,'Ciencia Ficcion')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (8,'Animacion')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (9,'Musical')
INSERT INTO TIPOS_GENERO_PELICULA VALUES (10,'Aventura')
---IDIOMAS----
INSERT INTO IDIOMAS VALUES (1,'Ingles')
INSERT INTO IDIOMAS VALUES (2,'Español España')
INSERT INTO IDIOMAS VALUES (3,'Español Latino')
INSERT INTO IDIOMAS VALUES (4,'Japones')
INSERT INTO IDIOMAS VALUES (5,'Portugues')

---CALIFICACION ETARTIAS---
INSERT INTO CALIFICACIONES_ETARIAS VALUES(1,'ATP')
INSERT INTO CALIFICACIONES_ETARIAS VALUES(2,'+13')
INSERT INTO CALIFICACIONES_ETARIAS VALUES(3,'+16')
INSERT INTO CALIFICACIONES_ETARIAS VALUES(4,'C')
------PAIS ORIGEN------
INSERT INTO PAIS_ORIGEN VALUES(1,'Argentina')
INSERT INTO PAIS_ORIGEN VALUES(2,'Estados Unidos')
INSERT INTO PAIS_ORIGEN VALUES(3,'Mexico')
INSERT INTO PAIS_ORIGEN VALUES(4,'Brasil')
INSERT INTO PAIS_ORIGEN VALUES(5,'Japon')
INSERT INTO PAIS_ORIGEN VALUES(6,'España')
----- PELICULAS-------
---id_pelicula --- nombre --- id_genero --- id_pais --- id_calificacion --- id_idioma---duracion----subtitulada
INSERT INTO PELICULAS   VALUES (1,'Relatos Salvajes',2,1,3,3,122,0)
INSERT INTO PELICULAS	VALUES (2,'El Secreto De sus Ojos',5,1,3,3,127,0)
INSERT INTO PELICULAS	VALUES (3,'El Clan',5,1,3,3,108,0)
INSERT INTO PELICULAS	VALUES (4,'El Robo del Siglo',5,1,2,3,114,0)
INSERT INTO PELICULAS	VALUES (5,'Granizo',3,1,2,3,114,0)
INSERT INTO PELICULAS   VALUES (6,'Red Social',3,2,3,1,120,1)
INSERT INTO PELICULAS	VALUES (7,'Shrek',8,2,1,3,90,0)
INSERT INTO PELICULAS	VALUES (8,'Interestelar',7,2,2,3,160,0)
INSERT INTO PELICULAS	VALUES (9,'Uncharted: fuera del mapa',10,2,1,3,116,0)
INSERT INTO PELICULAS	VALUES (10,'Los Vengadores',1,2,1,3,143,0)
INSERT INTO PELICULAS	VALUES (11,'ROMA',3,3,3,3,135,0)
INSERT INTO PELICULAS	VALUES (12,'Tropa de Elite',3,4,4,5,120,1)
INSERT INTO PELICULAS	VALUES (13,'Ciudad de Dios',3,4,4,5,130,1)
INSERT INTO PELICULAS	VALUES (14,'La maldición',4,5,3,4,92,1)
INSERT INTO PELICULAS	VALUES (15,'Premonition',4,5,3,4,95,1)
INSERT INTO PELICULAS	VALUES (16,'REC 4: Apocalipsis',4,6,3,2,95,0)
INSERT INTO PELICULAS	VALUES (17,'Durante la tormenta',7,6,2,2,128,0)
INSERT INTO PELICULAS	VALUES (18,'El Club de la Pelea',5,2,3,1,139,1)
INSERT INTO PELICULAS	VALUES (19,'Batman: El caballero de la noche',1,2,3,1,152,1)
INSERT INTO PELICULAS	VALUES (20,'La Guerra de Las Consolas',6,2,1,3,92,0)
INSERT INTO PELICULAS	VALUES (21,'The Truman Show: historia de una vida',3,2,2,3,103,0)
INSERT INTO PELICULAS	VALUES (22,'Pesadilla en la calle Elm',4,2,3,1,91,1)
INSERT INTO PELICULAS	VALUES (23,'Bastardos Sin Gloria',3,2,3,1,153,1)
INSERT INTO PELICULAS	VALUES (24,'Gladiador',1,2,3,1,155,1)
INSERT INTO PELICULAS	VALUES (25,'Black Adam',1,2,1,3,124,1)
INSERT INTO PELICULAS	VALUES (26,'Black Panther: Wakanda Forever',1,2,1,3,161,0)
INSERT INTO PELICULAS	VALUES (27,'SONRIE',4,2,3,3,115,0)
INSERT INTO PELICULAS	VALUES (28,'El irlandés',3,2,3,1,209,1)
INSERT INTO PELICULAS	VALUES (29,'The Batman',1,2,2,1,176,1)
INSERT INTO PELICULAS	VALUES (30,'El Escuadrón Suicida',1,2,3,3,132,0)


--TIPOS SALA
INSERT INTO TIPOS_SALA(Id_Tipo_Sala,Tipo_Sala)
	VALUES(1,'2D'),
		(2,'3D'),
		(3,'IMAX')
		

--SALAS
INSERT INTO SALAS(Id_Sala,Id_Tipo_Sala,Capacidad)
	VALUES(1,1,30),
		(2,1,20),
		(3,1,30),
		(4,2,30),
		(5,2,20),
		(6,3,30)


--FUNCIONES
INSERT INTO FUNCIONES(Id_Funcion,Id_Pelicula,Id_Sala,Dia,Horario,Precio_Actual)
	VALUES (1,1,1,'06-06-2020','13:20',500),
  (2,1,1,'06-07-2020','15:00',500),
  (3,2,3,'07-08-2020','19:40',500),
  (4,2,4,'07-08-2020','15:10',500),
  (5,3,1,'08-09-2020','16:30',550),
  (6,3,5,'09-09-2020','12:50',550),
  (7,4,6,'10-10-2020','10:30',550),
  (8,4,2,'11-10-2020','15:20',600),
  (9,5,3,'11-11-2020','15:50',630),

  (10,5,6,'01-01-2021','19:30',600),
  (11,6,5,'01-02-2021','13:50',600),
  (12,6,1,'02-02-2021','17:20',650),
  (13,7,2,'03-03-2021','19:30',650),
  (14,7,4,'05-04-2021','22:05',700),
  (15,8,3,'06-05-2021','14:35',740),
  (16,9,2,'07-06-2021','16:40',740),
  (17,9,1,'09-10-2021','17:50',740),

  (18,10,6,'02-03-2022','18:50',800),
  (19,12,2,'02-03-2022','20:10',800),
  (20,16,4,'04-04-2022','10:10',800),
  (21,10,1,'05-04-2022','18:50',900),
  (22,12,2,'06-05-2022','20:10',900),
  (23,16,4,'08-06-2022','10:10',900),
  (24,10,3,'09-10-2022','18:50',930),
  (25,12,1,'10-10-2022','20:10',930),
  (26,16,5,'10-10-22','10:10',930)

---GENEROS
insert into GENEROS (Id_Genero, Genero)
			values  (1        ,'Masculino'),
					(2        ,'Femenino'),
					(3        ,'No binario')

---FORMAS_PAGO
insert into FORMAS_PAGO(Id_Forma_Pago, Forma_Pago)
			values	   (1            , 'Efectivo'),
					   (2            , 'Tarjeta Débito'),
					   (3            , 'Tarjeta Crédito'),
					   (4            , 'Transferencia'),
					   (5            , 'QR')

--TIPOS_COMPRA
INSERT INTO TIPOS_COMPRA (id_tipo_compra, tipo_compra)
	VALUES(0, 'Fisica'),
		  (1, 'Virtual')

-- TIPOS_DOCUMENTO 
INSERT INTO TIPOS_DOCUMENTO (id_tipo_doc, tipo_doc)
	VALUES(0, 'Documento Nacional de Identidad'),
		  (1, 'Pasaporte'),
		  (2, 'Cedula de Identidad'),
		  (3, 'Libreta Civica'),
		  (4, 'Libreta de Enrolamiento')

--- TIPOS_CONTACTO
INSERT INTO TIPOS_CONTACTO(id_tipo_contacto, tipo_contacto)
	VALUES(0, 'Celular'),
		  (1, 'Telefono'),
		  (2, 'Email')

insert into EMPLEADOS(Id_Empleado, Apellido_Empleado, Nombre_Empleado, Fecha_Nac, Fecha_Ingreso, Id_Tipo_Doc, Nro_Doc, Id_Calle, Altura,Id_Genero) 
				values(1         , 'Pedrasa'        , 'Jose'         , '12/10/1980','02/05/2002'   ,0           , '35786985',  1     ,    325,  1      ),
					  (2         , 'Rodriguez'      , 'Miguel'       , '22/05/1990','07/01/2003'   ,0           , '37114865',  4     ,    500,  3      ),
					  (3         , 'Juarez'         , 'Roberto'      , '13/08/1985','02/12/2005'   ,0           , '30257896',  5     ,    752,  1      ),
					  (4         , 'Rodriguez'      , 'Pablo'        ,'08/01/1993','15/04/2007'   ,0           , '27845321',  2     ,    1025,  1    ),
					  (5         , 'Gonzalez'       , 'Agustina'     , '13/12/1975','01/10/2008'   ,0           , '35789321',  1     ,    125,  2   ),
					  (6         , 'Acosta'         , 'Maria'        , '10/11/1988','01/05/2010'   ,1           , '25786985',  6     ,    200,  2  ),
					  (7         , 'Acosta'         , 'Juan'         , '15/06/1989','01/05/2010'   ,1           , '40258793',  7     ,    1520,  1 ),
					  (8         , 'Di Maria'       , 'Julieta'      , '10/11/1992','04/08/2015'   ,0           , '38571486',  6     ,    1400,  2 ),
					  (9         , 'Paredes'        , 'Mario'        , '01/01/1984','28/05/2016'   ,0           , '34158453',  2     ,    600,  1 ),
					  (10        , 'Ramirez'        , 'Pedro'        , '28/07/1982','19/09/2016'   ,0           , '29888655',  3     ,    960,  1 )
---TIPOS_CLIENTES
INSERT INTO TIPOS_CLIENTES VALUES(1,'Menor')  
INSERT INTO TIPOS_CLIENTES VALUES(2,'Adulto')  
INSERT INTO TIPOS_CLIENTES VALUES(3,'Jubilado')  

--CLIENTES
INSERT INTO CLIENTES(id_cliente, apellido_cliente, nombre_cliente,Id_Tipo_Cliente, fecha_nac, id_tipo_doc, nro_doc, id_calle, ALTURA, id_genero)
	VALUES( 0, 'Carios'  , 'Alberto', 3,'12-05-1952', 4, 'M5739619' ,  6, 2065, 1),
		  ( 1, 'Escobar' , 'Mariano',3 ,'29-04-1989', 4, 'M8764512' ,  7, 1854, 1),
		  ( 2, 'Martinez', 'Mariano',2 ,'11-07-2001', 0, '46254761' , 15, 2390, 1),
		  ( 3, 'Sanchez' , 'Lara'   ,3 ,'02-06-2004', 0, '46254761' , 20,  682, 2),
		  ( 4, 'Carpa'   , 'Luis'   ,3 ,'04-08-1978', 1, 'A00009973',  7,  901, 1),
		  ( 5, 'Parta'   , 'Laura'  , 3,'17-12-1986', 0, '42453324' , 14, 1212, 2),
		  ( 6, 'Cañon'   , 'Malena' , 1,'26-12-2010', 0, '47289477' ,  7,  569, 2),
		  ( 7, 'Stalon'  , 'Mario'  , 3,'15-01-2000', 0, '37871309' ,  6,  456, 3),
		  ( 8, 'Sacon'   , 'Pilar'  ,2 ,'18-02-2002', 0, '44025209' , 19, 1234, 2),
		  ( 9, 'Miñon'   , 'Ramiro' ,2 ,'07-10-1997', 0, '38962824' ,  1,  456, 1),
		  (10, 'Lombardo', 'Mauro'  , 2,'24-06-1996', 0, '34566907' ,  3,  786, 1),
		  (11, 'Messi'   , 'Lionel' , 3,'24-06-1987', 0, '30862614' ,  7, 1237, 1),
		  (12, 'Artigas' , 'Lionel' , 2,'23-08-2001', 0, '41471777' ,  3, 1567, 1),
		  (13, 'Santopo' , 'Leandro', 2,'01-01-1999', 0, '44548867' ,  3,  230, 1),
		  (14, 'Alaña'   , 'Mia'    ,2 ,'12-08-2003', 0, '46363128' , 14,  246, 2),
		  (15, 'Renol'   , 'Armando', 2,'27-06-1996', 0, '46696024' , 16,  783, 1),
		  (16, 'Closs'   , 'Mariano', 2,'14-03-2000', 1, 'E00007734', 17,  567, 1),
		  (17, 'Martinez', 'Benito' , 2,'10-04-1994', 0, '46641349' , 13, 2003, 1),
		  (18, 'Caron'   , 'Monica' ,3 ,'23-08-1967', 0, '41727777' , 10, 2013, 2),
		  (19, 'Marlon'  , 'Mariano', 3,'13-04-1987', 0, '35293807' ,  9,  487, 1)


--CONTACTOS_CLIENTES--
INSERT INTO CONTACTOS_CLIENTES(id_contacto_cliente, contacto, Id_tipo_contacto, id_cliente)
	VALUES( 0,  'albertocarios@yahoo.com.ar', 2, 0),
		  ( 1,  '543514593516', 1, 1),
		  ( 2,  'salomon3452@gmail.com', 2, 2),
		  ( 3,  'mrestratos30989@outlook.com', 2, 4),
		  ( 4,  '4568769', 1, 4),
		  ( 5,  '3518794012', 0, 5),
		  ( 6,  'malenacañon8@gmail.com', 2, 6),
		  ( 7,  'superlion02@hotmail.com', 2, 7),
		  ( 8,  'varrabrava692@hotmail.com', 2, 8),
		  ( 9,  'ramielmaspio@hotmail.com', 2, 9),
		  (10, 'dukogoku123@hotmail.com', 2, 10),
		  (11, '4583211', 1, 11),
		  (12, '3514589766', 0, 12),
		  (13, '3568426694', 0, 13),
		  (14, '4521611', 1, 14),
		  (15, 'antezana247@gmail.com', 2, 15),
		  (16, '4562157', 1, 16),
		  (17, '3517896546', 0, 18),
		  (18, 'cookiemonster324@hotmail.com', 2, 18),
		  (19, '4255551212', 1, 19),
		  (20, 'luisarpado@gmail.com', 2, 4)

--CONTACTOS_EMPLEADOS
INSERT INTO CONTACTOS_EMPLEADOS(id_contacto_empleado, contacto, id_tipo_contacto, id_empleado)
	VALUES( 0, 'josep@yahoo.com.ar', 2, 1),
		  ( 1, '4587998', 1, 1),
		  ( 2, 'miguelrodriguez827@hotmail.com', 2, 2),
		  ( 3, '3518976548', 0, 4),
		  ( 4, 'agusgzlz@gmail.com', 2, 5),
		  ( 5, 'acostamaria23@gmail.com', 2, 6),
		  ( 6, '4586789', 1, 7),
		  ( 7, 'marioparedes1984@hotmail.com', 2, 9),
		  ( 8, 'bocateamo@outlook.com', 2, 10),
		  ( 9, '3514862415', 0, 10),
		  ( 10, 'roberjuarez78@outlook.com', 2, 3),
		  ( 11, '4567892', 1, 3),
		  ( 12, '3512648512', 0, 8),
		  ( 13, 'julietafideo@gmail.com', 2, 8)

---RESERVAS
INSERT INTO RESERVAS(id_reserva, id_cliente, fecha_reserva)
	VALUES( 0, 14, '04-10-2022'),
		  ( 1, 10, '27-09-2022'),
		  ( 2,  7, '02-10-2022'),
		  ( 3,  9, '08-06-2022'),
		  ( 4,  2, '27-09-2022'),
		  ( 5, 19, '16-07-2022'),
		  ( 6, 17, '03-03-2022'),
		  ( 7, 14, '04-10-2022'),
		  ( 8,  6, '14-03-2022'),
		  ( 9,  0, '29-09-2022'),
		  (10, 16, '01-02-2022')


--5--TIPOS_BUTACAS
INSERT INTO TIPOS_BUTACAS (id_tipo_butaca, tipo_butaca)
	VALUES(1, 'Regular'),
		  (2, 'Discapacidad')

--BUTACAS
Insert into BUTACAS(Id_Butaca, Id_Fila, Nro_Butaca, Id_Tipo_Butaca, Id_Sala)
			values (1        ,1       , 1         , 2             , 1      ),
				   (2        ,1       , 2         , 2             , 1      ),
				   (3        ,1       , 3         , 2             , 1      ),
				   (4        ,1       , 4         , 2             , 1      ),
				   (5        ,1       , 5         , 2             , 1      ),
				   (6        ,2       , 6         , 1             , 1      ),
				   (7        ,2       , 7         , 1             , 1      ),
				   (8        ,2       , 8         , 1             , 1      ),
				   (9        ,2       , 9         , 1             , 1      ),
				   (10       ,2       , 10        , 1             , 1      ),
				   (11       ,3       , 11        , 1             , 1      ),
				   (12       ,3       , 12        , 1             , 1      ),
				   (13       ,3       , 13        , 1             , 1      ),
				   (14       ,3       , 14        , 1             , 1      ),
				   (15       ,3       , 15        , 1             , 1      ),
				   (16       ,4       , 16        , 1             , 1      ),
				   (17       ,4       , 17        , 1             , 1      ),
				   (18       ,4       , 18        , 1             , 1      ),
				   (19       ,4       , 19        , 1             , 1      ),
				   (20       ,4       , 20        , 1             , 1      ),
				   (21       ,1       , 1         , 2             , 2      ),
				   (22       ,1       , 2         , 2             , 2      ),
				   (23       ,1       , 3         , 2             , 2      ),
				   (24       ,1       , 4         , 2             , 2      ),
				   (25       ,1       , 5         , 2             , 2      ),
				   (26       ,2       , 6         , 1             , 2      ),
				   (27       ,2       , 7         , 1             , 2      ),
				   (28       ,2       , 8         , 1             , 2      ),
				   (29       ,2       , 9         , 1             , 2      ),
				   (30       ,2       , 10        , 1             , 2      ),
				   (31       ,3       , 11        , 1             , 2      ),
				   (32       ,3       , 12        , 1             , 2      ),
				   (33       ,3       , 13        , 1             , 2      ),
				   (34       ,3       , 14        , 1             , 2      ),
				   (35       ,3       , 15        , 1             , 2      ),
				   (36       ,4       , 16        , 1             , 2      ),
				   (37       ,4       , 17        , 1             , 2      ),
				   (38       ,4       , 18        , 1             , 2      ),
				   (39       ,4       , 19        , 1             , 2      ),
				   (40       ,4       , 20        , 1             , 2      ),
				   (41       ,1       , 1         , 2             , 3      ),
				   (42       ,1       , 2         , 2             , 3      ),
				   (43       ,1       , 3         , 2             , 3      ),
				   (44       ,1       , 4         , 2             , 3      ),
				   (45       ,1       , 5         , 2             , 3      ),
				   (46       ,2       , 6         , 1             , 3      ),
				   (47       ,2       , 7         , 1             , 3      ),
				   (48       ,2       , 8         , 1             , 3      ),
				   (49       ,2       , 9         , 1             , 3      ),
				   (50       ,2       , 10        , 1             , 3      ),
				   (51       ,3       , 11        , 1             , 3      ),
				   (52       ,3       , 12        , 1             , 3      ),
				   (53       ,3       , 13        , 1             , 3      ),
				   (54       ,3       , 14        , 1             , 3      ),
				   (55       ,3       , 15        , 1             , 3      ),
				   (56       ,4       , 16        , 1             , 3      ),
				   (57       ,4       , 17        , 1             , 3      ),
				   (58       ,4       , 18        , 1             , 3      ),
				   (59       ,4       , 19        , 1             , 3      ),
				   (60       ,4       , 20        , 1             , 3      )




--BUTACAS_FUNCIONES
insert into BUTACAS_FUNCIONES(Id_Butaca_Funcion, Id_Butaca, Id_Funcion, Id_Reserva)
			values			 (      1           ,   1       ,  1         ,   1            ),
							 (      2           ,   2       ,  2         ,   2            ),
							 (      3           ,   3       ,  3         ,   null         ),
							 (      4           ,   4       ,  4         ,   null         ),
							 (      5           ,   5       ,  5         ,   3            ),
							 (      6           ,   6       ,  6         ,   null         ),
							 (      7           ,   7       ,  7         ,   null         ),
							 (      8           ,   8       ,  8         ,   4            ),
							 (      9           ,   9       ,  9         ,   null         ),
							 (      10          ,   10      ,  9         ,   null         ),
							 (      11          ,   11      ,  10        ,   8            ),
							 (      12          ,   12      ,  11        ,   null         ),
							 (      13          ,   13      ,  12        ,   5            ),
							 (      14          ,   14      ,  13        ,   null         ),
							 (      15          ,   15      ,  14        ,   6            ),
							 (      16          ,   16      ,  14        ,   null         ),
							 (      17          ,   17      ,  15        ,   7            ),
							 (      18          ,   18      ,  16        ,   null         ),
							 (      19          ,   19      ,  17        ,   9            ),
							 (      20          ,   20      ,  18        ,   null         ),
							 (      21          ,   21      ,  18        ,   10           ),
							 (      22          ,   22      ,  19        ,   null         ),
							 (      23          ,   23      ,  20        ,   null         ),
							 (      24          ,   24      ,  21        ,   null         ),
							 (      25          ,   25      ,  21        ,   null         ),
							 (      26          ,   26      ,  22        ,   null         ),
							 (      27          ,   27      ,  23        ,   null         ),
							 (      28          ,   28      ,  24        ,   null         ),
							 (      29          ,   29      ,  25        ,   null         ),
							 (      30          ,   30      ,  26        ,   null         )

----COMPROBANTES
insert into COMPROBANTES (Id_Comprobante, Id_Empleado, Id_Cliente, Fecha        , Hora, Id_Tipo_Compra, Descuento)
			values		 (1            ,      1      ,     1      ,'15/03/2016' , '10:00'    ,    0           ,   null       ),
						 (2            ,      3      ,     1      ,'19/07/2016' , '18:00'    ,    0           ,   null       ),
						 (3            ,      8      ,     2      ,'20/07/2016' , '17:00'    ,    0           ,   null       ),
						 (4            ,      5      ,     3      ,'30/09/2016' , '16:00'    ,    0           ,   null       ),
						 (5            ,      5      ,     6      ,'15/12/2016' , '15:00'    ,    0           ,   null       ),
						 (6            ,      6      ,     8      ,'05/01/2017' , '18:00'    ,    0           ,   null       ),
						 (7            ,      5      ,     9      ,'08/02/2017' , '20:00'    ,    0           ,   null       ),
						 (8            ,      9      ,     10     ,'14/02/2017' , '21:00'    ,    1           ,   null       ),
						 (9            ,      4      ,     7      ,'21/05/2017' , '22:00'    ,    1           ,   null       ),
						 (10           ,      1      ,     4      ,'15/07/2017' , '10:00'    ,    1           ,   null       ),
						 (11           ,      2      ,     7      ,'02/08/2017' , '14:00'    ,    1           ,   null       ),
						 (12           ,      6      ,     2      ,'09/10/2017' , '10:00'    ,    0           ,   null       ),
						 (13           ,      8      ,     6      ,'24/10/2017' , '13:00'    ,    1           ,   null       ),
						 (14           ,      9      ,     1      ,'13/11/2017' , '13:00'    ,    0           ,   null       ),
						 (15           ,      10     ,     8      ,'01/02/2018' , '12:00'    ,    1           ,   10         ),
						 (16           ,      5      ,     9      ,'03/02/2018' , '11:00'    ,    1           ,   null       ),
						 (17           ,      7      ,     4      ,'06/03/2019' , '09:00'    ,    1           ,   null       ),
						 (18           ,      7      ,     1      ,'25/04/2019' , '08:00'    ,    1           ,   null       ),
						 (19           ,      9      ,     2      ,'23/05/2019' , '11:00'    ,    0           ,   null       ),
						 (20           ,      6      ,     2      ,'26/05/2019' , '16:00'    ,    0           ,   null       ),
						 (21           ,      3      ,     2      ,'15/10/2019' , '17:00'    ,    0           ,   null       ),
						 (22           ,      2      ,     3      ,'17/12/2019' , '19:00'    ,    0           ,   null       ),
						 (23           ,      1      ,     6      ,'08/01/2020' , '15:00'    ,    1           ,   null       ),
						 (24           ,      1      ,     8      ,'28/03/2020' , '23:00'    ,    1           ,   null       ),
						 (25           ,      4      ,     7      ,'04/05/2020' , '10:00'    ,    0           ,   null       ),
						 (26           ,      5      ,     10     ,'09/07/2020' , '10:00'    ,    0           ,   null       ),
						 (27           ,      9      ,     10     ,'13/09/2020' , '10:00'    ,    1           ,   null       ),
						 (28           ,      8      ,      1     ,'18/11/2020' , '11:00'    ,    1           ,   null       ),
						 (29           ,      3      ,     10     ,'12/12/2020' , '20:00'    ,    0           ,   null       ),
						 (30           ,      2      ,     9      ,'06/01/2021' , '21:00'    ,    1           ,   null       ),
						 (31           ,      5      ,      5     ,'08/01/2021' , '17:00'    ,    0           ,   null       ),
						 (32           ,      4      ,      7     ,'15/01/2021' , '18:00'    ,    1           ,   null       ),
						 (33           ,      7      ,      9     ,'16/03/2021' , '15:00'    ,    1           ,   null       ),
						 (34           ,      9      ,      6     ,'28/03/2021' , '13:00'    ,    1           ,   10         ),
						 (35           ,      8      ,      7     ,'06/05/2021' , '12:00'    ,    0           ,   null       ),
						 (36           ,      3      ,      3     ,'15/05/2021' , '08:00'    ,    0           ,   null       ),
						 (37           ,      2      ,      2     ,'14/04/2022' , '10:00'    ,    0           ,   null       ),
						 (38           ,      5      ,      2     ,'25/05/2022' , '22:00'    ,    1           ,   null       ),
						 (39           ,      4      ,      6     ,'26/05/2022' , '21:00'    ,    1           ,   null       ),
						 (40           ,      7      ,      6     ,'23/06/2022' , '19:00'    ,    0           ,   null       ),
						 (41           ,      6      ,      5     ,'01/07/2022' , '09:00'    ,    1           ,   10         ),
						 (42           ,      9      ,      8     ,'03/07/2022' , '11:00'    ,    1           ,   null       ),
						 (43           ,      8      ,      7     ,'13/07/2022' , '15:00'    ,    1           ,   null       ),
						 (44           ,      1      ,      7     ,'15/09/2022' , '20:00'    ,    0           ,   null       )

---DETALLES_COMBROBANTES						 
insert into DETALLES_COMBROBANTES(Id_Detalle_Comprobante, Id_Comprobante, Id_Butaca_Funcion, Precio_Historico, Cantidad, Id_Forma_Pago)
			values				 (1                     , 1             ,       1           ,    100             ,  1       ,    1          ),
								 (2                     , 1             ,       2           ,    100             ,  1       ,    2          ),
								 (3                     , 2             ,       3           ,    100             ,   1      ,    1          ),
								 (4                     , 2             ,       4           ,    100             ,  1       ,    1          ),
								 (5                     , 2             ,       5           ,    100             ,  1       ,    1          ),
								 (6                     , 3             ,       5           ,    150             ,  1       ,    3          ),
								 (7                     , 4             ,       5           ,    150             ,  1       ,    3          ),
								 (8                     , 5             ,       6           ,    150             ,  1       ,    3          ),
								 (9                     , 5             ,       6           ,    150             ,  1       ,    3          ),
								 (10                    , 5             ,       7           ,    150             ,  1       ,     4         ),
								 (11                    , 6             ,       8           ,    150             ,  1       ,     4         ),
								 (12                    , 6             ,       9           ,    150             ,  1       ,     4         ),
								 (13                    , 7             ,       10           ,    150             ,  1       ,     5         ),
								 (14                    , 7             ,       11           ,    150             ,  1       ,     5         ),
								 (15                    , 7             ,       11           ,    200             ,  1       ,     5         ),
								 (16                    , 8             ,        12          ,     200            ,   1      ,      5        ),
								 (17                    , 8             ,       12           ,    250             ,  1       ,     1         ),
								 (18                    , 9             ,       12           ,    250             ,  1       ,     1         ),
								 (19                    , 9             ,       13           ,    250             ,  1       ,     1         ),
								 (20                    , 9             ,       14           ,    250             ,  1       ,     1         ),
								 (21                    , 9             ,       14           ,    250             ,   1      ,     1         ),
								 (22                    ,10             ,      15            ,   250              ,  1       ,    2          ),
								 (23                    ,10             ,      15            ,   300              ,  1       ,    2          ),
								 (24                    ,11             ,      15            ,   300              ,  1       ,    2          ),
								 (25                    ,12             ,      16            ,   300              ,  1       ,    3          ),
								 (26                    ,13             ,      16            ,   350              ,  1       ,    5          ),
								 (27                    ,13             ,      16            ,    350             ,  1       ,    5          ),
								 (28                    ,13             ,      16            ,    350             ,  1       ,    4          ),
								 (29                    ,14             ,      17            ,    350             ,  1       ,    5          ),
								 (30                    ,14             ,      17            ,    420             ,  1       ,    3          ),
								 (31                    ,15             ,      18            ,    420             ,  1       ,    2          ),
								 (32                    ,15             ,      18            ,    420             ,  1       ,    2          ),
								 (33                    ,15       ,           19            ,     420            ,  1       ,    1          ),
								 (34                    ,16       ,           19            ,     420            ,  1       ,    2          ),
								 (35                    ,17       ,           19            ,     470            ,  1       ,    3          ),
								 (36                    ,18       ,           20            ,     470            ,  1       ,    5          ),
								 (37                    ,19       ,           20            ,       470          ,  1       ,    5          ),
								 (38                    ,20       ,           20           ,    500             ,  1       ,     5         ),
								 (39                    ,20       ,           21            ,    500             ,  1       ,     4         ),
								 (40                    ,21       ,           22            ,    500             ,  1       ,     4         ),
								 (41                    ,22       ,           22            ,    500             ,  1       ,     4         ),
								 (42                    ,22       ,           23            ,    500             ,  1       ,      5        ),
								 (43                    ,22       ,           24            ,    500             ,  1       ,       2       ),
								 (44                    ,23       ,            24           ,    500             ,  1       ,      1        ),
								 (45                    ,24       ,           25            ,    600             ,  1       ,      1        ),
								 (46                    ,25       ,           25            ,    600             ,  1       ,      2        ),
								 (47                    ,26       ,           25            ,    600             ,  1       ,      3        ),
								 (48                    ,27       ,           26            ,     600            ,  1       ,      3        ),
								 (49                    ,28       ,           26            ,     600            ,  1       ,      3        ),
								 (50                    ,28       ,           26            ,     600            ,  1       ,      3        ),
								 (51                    ,29       ,           27            ,     600            ,  1       ,      5        ),
								 (52                    ,30       ,           28            ,     600            ,  1       ,      4        ),
								 (53                    ,31       ,           28            ,     600            ,  1       ,      4        ),
								 (54                    ,32       ,           28            ,     630            ,  1       ,      4        ),
								 (55                    ,33       ,           29            ,     630            ,  1       ,      5        ),
								 (56                    ,34       ,           29            ,     650            ,  1       ,      3        ),
								 (57                    ,35       ,           29            ,     650            ,  1       ,      2        ),
								 (58                    ,36       ,           30            ,     650            ,  1       ,      1        ),
								 (59                    ,36       ,            30           ,     650            ,  1       ,      1        ),
								 (60                    ,36       ,            30           ,     650            ,  1       ,      1        ),
								 (61                    ,37       ,            30           ,     650            ,  1       ,      2        ),
								 (62                    ,38       ,            30           ,     650            ,  1       ,      3        ),
								 (63                    ,38       ,            5           ,     650            ,  1       ,      3        ),
								 (64                    ,38       ,            6           ,     700            ,  1       ,      3        ),
								 (65                    ,38       ,            15           ,     700            ,  1       ,      3        ),
								 (66                    ,39       ,            16           ,     700            ,  1       ,      5        ),
								 (67                    ,39       ,            18           ,     700            ,  1       ,      4        ),
								 (68                    ,39       ,            25           ,     700            ,  1       ,      4        ),
								 (69                    ,40       ,            30           ,     700            ,  1       ,      4        ),
								 (70                    ,40       ,            4           ,     700            ,  1       ,      4        ),
								 (71                    ,40       ,            2           ,     700            ,  1       ,      4        ),
								 (72                    ,41       ,            1           ,     700            ,  1       ,      5        ),
								 (73                    ,41       ,            9           ,     700            ,  1       ,      2        ),
								 (74                    ,42       ,            7           ,     700            ,  1       ,      3        ),
								 (75                    ,42       ,            2           ,     700            ,  1       ,      3        ),
								 (76                    ,42       ,            14           ,     700            ,  1       ,      3        ),
								 (77                    ,43       ,            13           ,      700           ,  1       ,      3        ),
								 (78                    ,43       ,            17           ,     740            ,  1       ,      3        ),
								 (79                    ,43       ,            21           ,      740           ,  1       ,      1        ),
								 (80                    ,13       ,            29           ,      740           ,  1       ,      1        ),
								 (81                    ,44       ,            30           ,      740           ,  1       ,      3        ),
								 (82                    ,44       ,            16           ,      740           ,  1       ,      5        ),
								 (83                    ,44       ,            16           ,      740           ,  1       ,      5        ),
								 (84                    ,44       ,            9           ,      770           ,  1       ,      4        ),
								 (85                    ,44       ,            8           ,       770          ,  1       ,      2        )
								 