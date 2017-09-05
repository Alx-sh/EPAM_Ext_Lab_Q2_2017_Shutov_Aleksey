USE [ForumDB]
GO

/****** Object:  Table [dbo].[TypeUser]    Script Date: 05.09.2017 21:45:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TypeUser](
	[TypeUserID] [int] IDENTITY(1,1) NOT NULL,
	[TypeUser] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeUser] PRIMARY KEY CLUSTERED 
(
	[TypeUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[TypeUser]
           ([TypeUser])
     VALUES
           ('User')
GO

INSERT INTO [dbo].[TypeUser]
           ([TypeUser])
     VALUES
           ('Administrator')
GO

INSERT INTO [dbo].[TypeUser]
           ([TypeUser])
     VALUES
           ('Banned')
GO


