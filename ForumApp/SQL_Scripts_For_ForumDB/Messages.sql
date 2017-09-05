USE [ForumDB]
GO

/****** Object:  Table [dbo].[Messages]    Script Date: 05.09.2017 21:51:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[TextMessage] [nvarchar](4000) NOT NULL,
	[MessageDate] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[TopicID] [int] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Topics] FOREIGN KEY([TopicID])
REFERENCES [dbo].[Topics] ([TopicID])
GO

ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Topics]
GO

ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users]
GO


