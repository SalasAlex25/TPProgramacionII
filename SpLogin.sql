alter table empleados
add  Contraseña varchar(50)

update empleados 
set contraseña = 'admin123'
where id_empleado = 1

CREATE PROC SP_VALIDAR_INCIO_SESION
@USUARIO VARCHAR(50) ,
@CONTRASEÑA VARCHAR(50)
AS
SELECT * 
FROM EMPLEADOS
WHERE nombre_empleado = @usuario and contraseña = @contraseña


execute  SP_VALIDAR_INCIO_SESION 'jose','admin123'