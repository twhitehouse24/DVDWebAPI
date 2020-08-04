USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DvdLibrary')
DROP DATABASE DvdLibrary
GO

CREATE DATABASE DvdLibrary
GO

USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='DVD')
	DROP TABLE DVD
GO

/*---------------------------------------------------------------------------*/

CREATE TABLE [dbo].[DVD](
	[DvdID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[ReleaseYear] [int] NOT NULL,
	[Director] [varchar](100) NOT NULL,
	[Rating] [varchar](5) NOT NULL,
	[Notes] [char](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[DvdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='DVDS')
	DROP TABLE DVDS
GO
CREATE TABLE [dbo].[DVDS](
	[DvdID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[ReleaseYear] [int] NOT NULL,
	[Director] [varchar](100) NOT NULL,
	[Rating] [varchar](5) NOT NULL,
	[Notes] [char](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[DvdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO