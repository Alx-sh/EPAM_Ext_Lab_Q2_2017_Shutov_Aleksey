USE [ForumDB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 05.09.2017 21:51:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[TypeUserID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_TypeUserID] FOREIGN KEY([TypeUserID])
REFERENCES [dbo].[TypeUser] ([TypeUserID])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_TypeUserID]
GO


INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[RegistrationDate]
           ,[TypeUserID])
     VALUES
           ('Admin'
           ,'12345678'
           ,GETDATE()
           ,2)
GO

