USE COMPLEJO_CINE_v3
GO 

create proc Consultar_Clientes
as
	begin
	select *, Apellido_Cliente+' '+Nombre_Cliente 'Cliente' from clientes
	--select Id_Cliente, Apellido_Cliente+' '+Nombre_Cliente 'Cliente' from CLIENTES
	end
	go
--exec Consultar_Clientes


create procedure SP_CONSULTAR_COMPRAS_CON_FILTROS
@fecha1 datetime,
@fecha2 datetime,
@codigo int
as
	begin
	select c.Id_Comprobante 'Nro. Comprobante', format(c.Fecha,'dd/MM/yyyy') 'Fecha', format(c.Hora,'hh:ss') 'Hora', count(d.Id_Comprobante) 'Cantidad', sum(Precio_Historico) 'Total'
	from COMPROBANTES c
	join DETALLES_COMBROBANTES d on c.Id_Comprobante = d.Id_Comprobante
	where c.Fecha between @fecha1 and @fecha2
	and c.Id_Cliente = @codigo
	group by c.Id_Comprobante, c.Fecha, c.Hora
	end
	go

--exec SP_CONSULTAR_COMPRAS_CON_FILTROS '13/01/2016', '31/12/2022', 1


create procedure SP_CONSULTAR_COMPRAS
@codigo int
as
	begin
	select c.Id_Comprobante 'Nro. Comprobante', format(c.Fecha,'dd/MM/yyyy') 'Fecha', format(c.Hora,'hh:ss') 'Hora', count(d.Id_Comprobante) 'Cantidad', sum(Precio_Historico) 'Total'
	from COMPROBANTES c
	join DETALLES_COMBROBANTES d on c.Id_Comprobante = d.Id_Comprobante
	where c.Id_Cliente = @codigo
	group by c.Id_Comprobante, c.Fecha, c.Hora
	end
	go
--exec SP_CONSULTAR_COMPRAS 1

create proc SP_CONTACTOS_CLIENTES
@codigo int
as
	begin
	select Id_Cliente, Tipo_Contacto, Contacto 
	from CONTACTOS_CLIENTES cc 
	join tipos_contacto tc on cc.Id_Tipo_Contacto = tc.Id_Tipo_Contacto
	where Id_Cliente = 2
	end
	go
create procedure SP_TOTAL_COMPRAS_CON_FILTRO
@fecha1 datetime,
@fecha2 datetime,
@codigo int,
@total decimal(10,2) output
as
		begin
		select @total = sum(Precio_Historico) 
		from COMPROBANTES c
		join DETALLES_COMBROBANTES d on c.Id_Comprobante = d.Id_Comprobante
		where c.Fecha between @fecha1 and @fecha2
		and c.Id_Cliente = @codigo
		if (@total IS NULL)
			SET @total = 0
		end
	go
--declare @total decimal
--exec SP_TOTAL_COMPRAS '13/01/2016', '31/12/2022', 0, @total output
--select @total 'Total'

	
create procedure SP_TOTAL_COMPRAS
@codigo int,
@total decimal(10,2) output
as
		begin
		select @total = sum(Precio_Historico) 
		from COMPROBANTES c
		join DETALLES_COMBROBANTES d on c.Id_Comprobante = d.Id_Comprobante
		where c.Id_Cliente = @codigo
		if (@total IS NULL)
			SET @total = 0
		end
	go
--declare @total decimal
--exec SP_TOTAL_COMPRAS 0, @total output
--select @total 'Total'


create proc SP_CONSULTA_REPORTE --agregar parametro año
as
begin
SELECT        CLIENTES.Apellido_Cliente + ' ' + CLIENTES.Nombre_Cliente AS Cliente, CLIENTES.Nro_Doc AS Documento, YEAR(COMPROBANTES.Fecha) AS Año, SUM(DETALLES_COMBROBANTES.Cantidad) AS Cantidad, 
                         SUM(DETALLES_COMBROBANTES.Precio_Historico) AS Total
FROM            DETALLES_COMBROBANTES INNER JOIN
                         COMPROBANTES ON DETALLES_COMBROBANTES.Id_Comprobante = COMPROBANTES.Id_Comprobante INNER JOIN
                         CLIENTES ON COMPROBANTES.Id_Cliente = CLIENTES.Id_Cliente
WHERE        (YEAR(COMPROBANTES.Fecha) = YEAR(GETDATE()))
GROUP BY CLIENTES.Apellido_Cliente + ' ' + CLIENTES.Nombre_Cliente, CLIENTES.Nro_Doc, YEAR(COMPROBANTES.Fecha)
ORDER BY Total DESC
end
go
--exec SP_CONSULTA_REPORTE

--set dateformat dmy

create proc SP_SORTEO
as
	begin
	select top 10 Apellido_Cliente+', '+Nombre_Cliente 'Cliente', Nro_Doc 'Documento', Tipo_Contacto 'Tipo de Contacto',
	Contacto, sum(Precio_Historico) 'Total compras' 
	from CLIENTES c
	join CONTACTOS_CLIENTES cc on cc.Id_Cliente = c.Id_Cliente
	join tipos_contacto tc on cc.Id_Tipo_Contacto = tc.Id_Tipo_Contacto
	join COMPROBANTES co on co.Id_Cliente = c.Id_Cliente
	join DETALLES_COMBROBANTES d on co.Id_Comprobante = d.Id_Comprobante
	where year(co.Fecha) = year(getdate())
	group by Apellido_Cliente+', '+Nombre_Cliente, Nro_Doc, Tipo_Contacto, Contacto
	order by 5 desc
	end
	go


