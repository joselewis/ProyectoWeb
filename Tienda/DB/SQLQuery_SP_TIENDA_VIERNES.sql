CREATE PROC SPSACARIMAGEN
@ID INT
AS
BEGIN
	SELECT IMAGEN, DESCRIPCION_PRODUCTO, CODIGO_PRODUCTO, TIPO_PRENDA, PRECIO_PRODUCTO,
	CANTIDAD_PRODUCTO,TALLA_PRENDA, MARCA FROM PRODUCTO_ROPA WHERE CODIGO_PRODUCTO = @ID
END