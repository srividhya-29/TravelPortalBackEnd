USE [KDTravelPortal]
GO

/****** Object: Table [dbo].[Clients] Script Date: 15-10-2018 14:30:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients] (
    [ClientId]   INT             IDENTITY (1, 1) NOT NULL,
    [ClientName] NVARCHAR (4000) NOT NULL
);

insert into Clients values('Kongsberg'),('Shell'),('Relience')
select * from Clients

