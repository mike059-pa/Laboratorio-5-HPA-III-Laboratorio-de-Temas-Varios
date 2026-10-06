/*Consulta 1 */
SELECT * 
FROM productos
WHERE id=1 WAITFOR DELAY '00:00:15';
--Consulta 2
SELECT *
FROM productos
WHERE cantidad = '' or '1'='1' AND id = '' OR '1' = '1'
--3
SELECT * FROM productos WHERE nombre = 'root'; -- ' AND password = 'mypassword';

--4 
SELECT * FROM dbo.productos WHERE nombre = 'Lapiz' OR '1' != '@unam.mx';