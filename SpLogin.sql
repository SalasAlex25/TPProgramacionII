alter table empleados
add  Contrase�a varchar(50)

update empleados 
set contrase�a = 'admin123'
where id_empleado = 1

CREATE PROC SP_VALIDAR_INCIO_SESION
@USUARIO VARCHAR(50) ,
@CONTRASE�A VARCHAR(50)
AS
SELECT * 
FROM EMPLEADOS
WHERE nombre_empleado = @usuario and contrase�a = @contrase�a


execute  SP_VALIDAR_INCIO_SESION 'jose','admin123'