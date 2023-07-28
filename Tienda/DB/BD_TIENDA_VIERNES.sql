CREATE DATABASE TIENDA_VIERNES
USE TIENDA_VIERNES

CREATE TABLE USUARIOS
(
	ID_USUARIO INT IDENTITY NOT NULL,
	CORREO_ELECTRONICO VARCHAR(50) PRIMARY KEY NOT NULL,
	NOMBRE_USUARIO VARCHAR(20) NOT NULL,
	NOMBRE VARCHAR(50) NOT NULL,
	APELLIDO_1_USUARIO VARCHAR(20) NOT NULL,
	APELLIDO_2_USUARIO VARCHAR(20)NOT NULL,
	TELEFONO_USUARIO VARCHAR(20) NOT NULL, 
	CONTRASENNA VARCHAR(50) NOT NULL,
	TIPO_USUARIO VARCHAR(20) NOT NULL,
	IMAGEN_USUARIO VARBINARY(MAX),
	CUENTA_ACTIVA BIT NOT NULL
)

DELETE FROM USUARIOS WHERE CORREO_ELECTRONICO = 'mario@gmail.com'
DELETE FROM PRODUCTO_ROPA WHERE CODIGO_PRODUCTO = 56516758
DELETE FROM CARRITO WHERE ID_CARRITO =  24

ALTER TABLE USUARIOS
ADD CUENTA_ACTIVA BIT NOT NULL CONSTRAINT DF_MyTable_MyColumn DEFAULT 1

ALTER TABLE USUARIOS
DROP CONSTRAINT DF_MyTable_MyColumn

SELECT * FROM USUARIOS

CREATE TABLE METODO_PAGO
(
	NUMERO_TARJETA BIGINT PRIMARY KEY NOT NULL,
	NUMERO_EXPIRA_1 NUMERIC(2) NOT NULL,
	NUMERO_EXPIRA_2 NUMERIC(2) NOT NULL,
	CODIGO_TARJETA NUMERIC(3) NOT NULL,
	CORREO_ELECTRONICO VARCHAR(50) NOT NULL,
	TARJETA_ACTICA BIT NOT NULL,
	CONSTRAINT FK_USUARIO_TARJETA FOREIGN KEY (CORREO_ELECTRONICO) REFERENCES USUARIOS(CORREO_ELECTRONICO)
)

CREATE TABLE ADMINISTRADORES
(
	ID_USUARIO_ADMIN INT IDENTITY NOT NULL,
	CORREO_ELECTRONICO_ADMIN VARCHAR(50) PRIMARY KEY NOT NULL,
	NOMBRE_USUARIO_ADMIN VARCHAR(20) NOT NULL,
	NOMBRE_ADMIN VARCHAR(50) NOT NULL,
	APELLIDO_1_ADMIN VARCHAR(20) NOT NULL,
	APELLIDO_2_ADMIN VARCHAR(20)NOT NULL,
	TELEFONO_ADMIN VARCHAR(20) NOT NULL, 
	CONTRASENNA_ADMIN VARCHAR(50) NOT NULL,
	TIPO_USUARIO VARCHAR(20) NOT NULL,
	CUENTA_ACTIVA BIT NOT NULL
)

ALTER TABLE ADMINISTRADORES
ADD CUENTA_ACTIVA BIT NOT NULL CONSTRAINT DF_MyTable_MyColumn DEFAULT 1

ALTER TABLE ADMINISTRADORES
DROP CONSTRAINT DF_MyTable_MyColumn

SELECT * FROM ADMINISTRADORES

CREATE TABLE PRODUCTO_ROPA
(
	ID_PRODUCTO INT IDENTITY NOT NULL,
	CODIGO_PRODUCTO INT PRIMARY KEY NOT NULL,
	TIPO_PRENDA VARCHAR(100) NOT NULL,
	PRECIO_PRODUCTO INT NOT NULL,
	NUMERO_CANTIDAD_PRODUCTO INT NOT NULL,
	CANTIDAD_PRODUCTO INT NOT NULL,
	DESCRIPCION_PRODUCTO VARCHAR(2000) NOT NULL,
	TALLA_PRENDA VARCHAR(25) NOT NULL,
	IMAGEN VARBINARY(MAX) NOT NULL,
	MARCA VARCHAR(50) NOT NULL,
	PRODUCTO_ACTIVO BIT NOT NULL
)

SELECT CANTIDAD_PRODUCTO FROM PRODUCTO_ROPA WHERE CODIGO_PRODUCTO = 3061450

SELECT * FROM PRODUCTO_ROPA
DROP TABLE PRODUCTO_ROPA

CREATE TABLE CLASIFICAR_ROPA
(
	ID_CLASIFICACION INT IDENTITY PRIMARY KEY NOT NULL,
	CATEGORIA_NUMERO INT NOT NULL,
	CATEGORIA_PRENDA VARCHAR(100) NOT NULL,
	CODIGO_PRODUCTO INT NOT NULL,
	CONSTRAINT FK_PRENDA_CLASIFICAION FOREIGN KEY (CODIGO_PRODUCTO) REFERENCES PRODUCTO_ROPA(CODIGO_PRODUCTO)
)

SELECT * FROM CLASIFICAR_ROPA
DROP TABLE CLASIFICAR_ROPA

CREATE TABLE CARRITO
(
	ID_CARRITO INT IDENTITY PRIMARY KEY NOT NULL,
	CORREO_ELECTRONICO VARCHAR(50) NOT NULL,
	CODIGO_PRODUCTO INT NOT NULL,
	NUMERO_CANTIDAD INT NOT NULL,
	CARRITO_ACTIVO BIT NOT NULL,
	CONSTRAINT FK_CARRITO_USUARIO FOREIGN KEY (CORREO_ELECTRONICO) REFERENCES USUARIOS(CORREO_ELECTRONICO),
	CONSTRAINT FK_PRODUCTO_CARRITO FOREIGN KEY (CODIGO_PRODUCTO) REFERENCES PRODUCTO_ROPA(CODIGO_PRODUCTO)
)

SELECT * FROM CARRITO WHERE CORREO_ELECTRONICO = 'mario@gmail.com'
SELECT * FROM CARRITO WHERE CORREO_ELECTRONICO = 'joselewis@gmail.com'

DROP TABLE CARRITO

INSERT INTO CARRITO 
(
	NUMERO_CARRITO,
	CORREO_ELECTRONICO,
	CODIGO_PRODUCTO,
	CANTIDAD,
	CARRITO_ACTIVO
)
VALUES 
(
	1,
	'joselewis@gmail.com',
	5949191,
	2,
	1
)

INSERT INTO CARRITO 
(
	NUMERO_CARRITO,
	CORREO_ELECTRONICO,
	CODIGO_PRODUCTO,
	CANTIDAD,
	CARRITO_ACTIVO
)
VALUES 
(
	2,
	'mario@gmail.com',
	5949191,
	4,
	1
)

CREATE TABLE GENERO_ROPA
(
	ID_GENERO INT IDENTITY PRIMARY KEY NOT NULL,
	GENERO_PRENDA VARCHAR(9) NOT NULL,
	NUMERO_GENERO INT NOT NULL,
	CODIGO_PRODUCTO INT NOT NULL,
	CONSTRAINT FK_PRENDA_GENERO FOREIGN KEY (CODIGO_PRODUCTO) REFERENCES PRODUCTO_ROPA(CODIGO_PRODUCTO)
)	

DROP TABLE GENERO_ROPA

CREATE TABLE ORDEN_COMPRA
(
	ID_ORDEN_COMPRA INT IDENTITY PRIMARY KEY NOT NULL,
	CORREO_ELECTRONICO VARCHAR(50) NOT NULL,
	NUMERO_TARJETA BIGINT NOT NULL,
	COMPRA_TOTAL INT NOT NULL,
	CODIGO_PRODUCTO INT NOT NULL,
	CONSTRAINT FK_ORDEN_COMPRA_USUARIO FOREIGN KEY (CORREO_ELECTRONICO) REFERENCES USUARIOS(CORREO_ELECTRONICO),
	CONSTRAINT FK_METODOPAGO_CARRITO FOREIGN KEY (NUMERO_TARJETA) REFERENCES METODO_PAGO(NUMERO_TARJETA),
	CONSTRAINT FK_PRODUCTOS_CARRITO FOREIGN KEY (CODIGO_PRODUCTO) REFERENCES PRODUCTO_ROPA(CODIGO_PRODUCTO),
)

DROP TABLE ORDER_COMPRA

SELECT * FROM USUARIOS INNER JOIN CARRITO ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO

SELECT * FROM PRODUCTO_ROPA INNER JOIN CLASIFICAR_ROPA ON PRODUCTO_ROPA.CODIGO_PRODUCTO = CLASIFICAR_ROPA.CODIGO_PRODUCTO WHERE CATEGORIA_PRENDA = 'Zapatos'
SELECT * FROM USUARIOS INNER JOIN CARRITO ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE NUMERO_CARRITO = 1
SELECT * FROM CARRITO INNER JOIN USUARIOS ON CARRITO.CORREO_ELECTRONICO = USUARIOS.CORREO_ELECTRONICO WHERE CORREO_ELECTRONICO = 'mario@gmail.com'

SELECT *
FROM USUARIOS
INNER JOIN CARRITO ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO
INNER JOIN PRODUCTO_ROPA ON PRODUCTO_ROPA.CODIGO_PRODUCTO = CARRITO.CODIGO_PRODUCTO WHERE PRODUCTO_ROPA.CODIGO_PRODUCTO = 5949191

SELECT *
FROM PRODUCTO_ROPA
INNER JOIN CARRITO ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO
INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO = 'mario@gmail.com'

SELECT *
FROM PRODUCTO_ROPA
INNER JOIN CARRITO ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO
INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO = 'mario@gmail.com'

SELECT NUMERO_TARJETA, COMPRA_TOTAL, TIPO_PRENDA, PRECIO_PRODUCTO, NUMERO_CANTIDAD
FROM PRODUCTO_ROPA
INNER JOIN PRODUCTO_ROPA ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO
INNER JOIN CARRITO ON CARRITO.CODIGO_PRODUCTO = PRODUCTO_ROPA.CODIGO_PRODUCTO
INNER JOIN USUARIOS ON USUARIOS.CORREO_ELECTRONICO = CARRITO.CORREO_ELECTRONICO WHERE USUARIOS.CORREO_ELECTRONICO = 'joselewis@gmail.com'


--CORREO_ELECTRONICO = 'joselewis@gmail.com'

SELECT * FROM ADMINISTRADORES
SELECT * FROM USUARIOS
SELECT * FROM METODO_PAGO
SELECT * FROM PRODUCTO_ROPA
SELECT * FROM CLASIFICAR_ROPA

--CODIGO_PRODUCTO, TIPO_PRENDA, PRECIO_PRODUCTO, CANTIDAD_PRODUCTO, TALLA_PRENDA, MARCA, CORREO_ELECTRONICO, NOMBRE, APELLIDO_1_USUARIO