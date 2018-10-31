USE [KDTravelPortal]
GO

/****** Object: Table [dbo].[Statuses] Script Date: 15-10-2018 17:39:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Statuses] (
    [StatusId] TINYINT         IDENTITY (1, 1) NOT NULL,
    [Message]  NVARCHAR (4000) NOT NULL
);

insert into Statuses values('Request Raised'),('Approved')

