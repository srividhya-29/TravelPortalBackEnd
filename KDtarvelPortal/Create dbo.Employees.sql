USE [KDTravelPortal]
GO

/****** Object: Table [dbo].[Employees] Script Date: 15-10-2018 12:15:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees] (
    [EmployeeId]         INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeName]       NVARCHAR (50)   NOT NULL,
    [Team]               NVARCHAR (25)   NOT NULL,
    [WorkLocation]       NVARCHAR (25)   NOT NULL,
    [Address]            NVARCHAR (4000) NOT NULL,
    [MobNo]              VARCHAR (8000)  NOT NULL,
    [FatherName]         NVARCHAR (4000) NOT NULL,
    [MotherName]         NVARCHAR (4000) NOT NULL,
    [PortalPassword]     NVARCHAR (4000) NULL,
    [ReportingManagerId] INT             NOT NULL,
    [DesignationId]      TINYINT         NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_DesignationId]
    ON [dbo].[Employees]([DesignationId] ASC);


GO
ALTER TABLE [dbo].[Employees]
    ADD CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC);


GO
ALTER TABLE [dbo].[Employees]
    ADD CONSTRAINT [FK_dbo.Employees_dbo.Designations_DesignationId] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designations] ([DesignationId]) ON DELETE CASCADE;


	insert into Employees values('Tin','Products & Platforms','Bangalore','Uthrahalli Bangalore','+91-9876543234','FTin','MTin','123',-1,2)

	select * from Employees;
	update Employees
	set DesignationId = 2
	where EmployeeId = 3;

	insert into Employees values('Tommy','Drillings & Wells','Bangalore','Rajajinagar Bangalore','+91-9876543234','FTommy','MTommy','123',-1,2)
	insert into Employees values('Zen','Drillings & Wells','Bangalore','Rajajinagar Bangalore','+91-9876543234','FTommy','MTommy','123',3,5)
	insert into Employees values('Messy','Drillings & Wells','Bangalore','Rajajinagar Bangalore','+91-9876543234','FTommy','MTommy','123',3,4)
	insert into Employees values('Zyan','Products & Platforms','Bangalore','Ramurthynagar Bangalore','+91-9876543234','FZyan','MZyan','123',2,5)
	insert into Employees values('Kian','Products & Platforms','Bangalore','Kalyanagar Bangalore','+91-9876543234','FKian','MKian','123',2,4)
	insert into Employees values('Grace','Drillings & Wells','Bangalore','CoxTown Bangalore','+91-9876543234','FGrace','MGrace','123',-3,5)

	update Employees
	set ReportingManagerId = 3
	where EmployeeId = 7;