USE [Protectores]
GO
/****** Object:  UserDefinedFunction [dbo].[FNT_GETDIST]    Script Date: 12/5/2015 3:33:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER FUNCTION [dbo].[FNT_GETDIST] (@lat1 Float(8),@long1 Float(8))
RETURNS @DIST TABLE (ContactoID INT,UsuarioID INT,Latitud float,Longitud float,DIST Float(8),Organizacion nvarchar (max),AddressNumber nvarchar (max),StreetName nvarchar (max),CityName nvarchar (max),CountryName nvarchar (max),Telefono nvarchar (max))

AS

BEGIN 
/*******************************/
/*DECLARO VARIABLES PARA CICLAR*/
/*******************************/
DECLARE
@CID Float(8),
@UID Float(8),
@lat2 Float(8),
@long2 Float(8),
@org nvarchar (max),
@address nvarchar(max),
@street nvarchar(max),
@city nvarchar (max),
@country nvarchar (max),
@tel nvarchar (max)

DECLARE DISTANCIAS CURSOR FOR
/***************************************************/
/* CONSULTA DE DONDE SE VAN A SACAR LAS LAT Y LONG */
/***************************************************/
SELECT ContactoID,UsuarioID,Latitud,Longitud,Organizacion,AddressNumber,StreetName,CityName,CountryName,Telefono FROM Contacto 

OPEN DISTANCIAS

FETCH DISTANCIAS
/******************************/
/*INSERTA DATOS PARA EL CICLAR*/
/******************************/
INTO @Cid,@uid,@lat2,@long2,@org,@address,@street,@city,@country,@tel
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
INSERT INTO @DIST (ContactoID,UsuarioID,Latitud,Longitud,DIST,Organizacion,AddressNumber,StreetName,CityName,CountryName,Telefono) 
VALUES(@cid,@uid,@lat2,@long2,cast(@d as Float(8)),@org,@address,@street,@city,@country,@tel)

/**********************************/
/*VUELVE A CICLAR POR EL SIGUIENTE*/
/**********************************/
FETCH DISTANCIAS 
INTO @cid,@uid,@lat2,@long2,@org,@address,@street,@city,@country,@tel

END

CLOSE DISTANCIAS
DEALLOCATE DISTANCIAS 
/******************************************/
/*DEJA EN LA TABLA SOLO LOS 5 MAS CERCANOS*/
/******************************************/
DELETE @DIST WHERE ContactoID NOT IN (SELECT TOP 5 ContactoID FROM @DIST ORDER BY DIST)

RETURN
END

