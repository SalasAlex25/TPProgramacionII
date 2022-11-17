alter table empleados
add  Contraseņa varchar(50)

update empleados 
set contraseņa = 'admin123'
where id_empleado = 1

CREATE PROC SP_VALIDAR_INCIO_SESION
@USUARIO VARCHAR(50) ,
@CONTRASEŅA VARCHAR(50)
AS
SELECT * 
FROM EMPLEADOS
WHERE nombre_empleado = @usuario and contraseņa = @contraseņa


execute  SP_VALIDAR_INCIO_SESION 'jose','admin123'