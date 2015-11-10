

USE [GeoLoca]
GO

/****** Object:  UserDefinedFunction [dbo].[FNT_GETDIST]    Script Date: 06/11/2015 01:24:21 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[FNT_GETDIST4] (@lat1 Float(8),@long1 Float(8))
RETURNS @DIST TABLE (ID INT,DIST INT)

AS

BEGIN 
/*******************************/
/*DECLARO VARIABLES PARA CICLAR*/
/*******************************/
DECLARE
@ID INT,
@lat2 Float(8),
@long2 Float(8)

DECLARE DISTANCIAS CURSOR FOR
/***************************************************/
/* CONSULTA DE DONDE SE VAN A SACAR LAS LAT Y LONG */
/***************************************************/
SELECT id_contact,lat,lon FROM ubicaciones 

OPEN DISTANCIAS

FETCH DISTANCIAS
/******************************/
/*INSERTA DATOS PARA EL CICLAR*/
/******************************/
INTO @id,@lat2,@long2
/**************/
/*INICIA CICLO*/
/**************/
WHILE (@@FETCH_STATUS = 0 )

BEGIN
/**********************************/
/*FUNCION QUE CALCULA LA DISTANCIA*/
/**********************************/
DECLARE
@R Float(8),
@dLat Float(8),
@dLon Float(8),
@a Float(8),
@c Float(8),
@d Float(8)

      SET @R = 3960;
      SET @dLat = RADIANS(@lat2 - @lat1);
      SET @dLon = RADIANS(@long2 - @long1);
 
      SET @a = SIN(@dLat / 2) * SIN(@dLat / 2) + COS(RADIANS(@lat1))
                        * COS(RADIANS(@lat2)) * SIN(@dLon / 2) *SIN(@dLon / 2);
      SET @c = 2 * ASIN(MIN(SQRT(@a)));
      SET @d = @R * @c;
	  SET @d = (@d/0.62137)

/**********************************************************/
/*INSERTA X CADA CICLO EL ID Y LA DISTANCIA AL PTO BUSCADO*/
/**********************************************************/
INSERT INTO @DIST (ID,DIST) VALUES(@id,cast(@d as int))

/**********************************/
/*VUELVE A CICLAR POR EL SIGUIENTE*/
/**********************************/
FETCH DISTANCIAS 
INTO @id,@lat2,@long2

END

CLOSE DISTANCIAS
DEALLOCATE DISTANCIAS 
/******************************************/
/*DEJA EN LA TABLA SOLO LOS 5 MAS CERCANOS*/
/******************************************/
DELETE @DIST WHERE ID NOT IN (SELECT TOP 5 ID FROM @DIST ORDER BY DIST)

RETURN
END
GO

