USE [KDTravelPortal]
GO

/****** Object: Table [dbo].[Designations] Script Date: 15-10-2018 12:16:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Designations] (
    [DesignationId]   TINYINT       IDENTITY (1, 1) NOT NULL,
    [DesignationType] NVARCHAR (50) NOT NULL
);

insert into Designations values('Administrator'),('Manager'),('Tester'),('Senior Tester'),('Developer'),('Senior Developer')
select * from Designations;
