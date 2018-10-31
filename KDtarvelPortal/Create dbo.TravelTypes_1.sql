USE [KDTravelPortal]
GO

/****** Object: Table [dbo].[TravelTypes] Script Date: 15-10-2018 12:13:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TravelTypes] (
    [TravelTypeId] TINYINT         IDENTITY (1, 1) NOT NULL,
    [Type]         NVARCHAR (4000) NOT NULL
);
go;

insert into [dbo].[TravelTypes] values('National'),('International');
GO;

select *from TravelTypes

