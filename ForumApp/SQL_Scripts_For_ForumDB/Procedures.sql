USE [ForumDB]
GO

/****** Object:  StoredProcedure [dbo].[CreateMessage]    Script Date: 12.09.2017 11:57:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[CreateMessage]
	@TextMessage NVARCHAR(4000),
	@UserID INT,
	@TopicID INT
AS
	INSERT INTO [ForumDB].[dbo].[Messages]
	      ([TextMessage]
	      ,[MessageDate]
	      ,[UserID]
	      ,[TopicID])
	VALUES
	      (@TextMessage
	      ,CONVERT(DATETIME, GETDATE(), 103)
	      ,@UserID
	      ,@TopicID)


GO


CREATE PROCEDURE [dbo].[CreateTopic]
	@TopicName NVARCHAR(50),
	@UserID INT
AS
	INSERT INTO [ForumDB].[dbo].[Topics]
          ([TopicName]
          ,[UserID])
    VALUES
          (@TopicName
          ,@UserID)


GO

CREATE PROCEDURE [dbo].[CreateUser]
	@UserName NVARCHAR(50),
	@Password NVARCHAR(50)
AS
	INSERT INTO [ForumDB].[dbo].[Users]
          ([UserName]
          ,[Password]
          ,[RegistrationDate]
          ,[TypeUserID])
    VALUES
          (@UserName
          ,@Password
          ,CONVERT(DATETIME, GETDATE(), 103)
          ,1)

GO

CREATE PROCEDURE [dbo].[DeleteMessage]
	@MessageID INT
AS
	DELETE FROM [ForumDB].[dbo].[Messages]
    WHERE [MessageID] = @MessageID


GO

CREATE PROCEDURE [dbo].[EditMessage]
	@TextMessage NVARCHAR(4000),
	@MessageID INT
AS
	UPDATE [ForumDB].[dbo].[Messages]
    SET [TextMessage] = @TextMessage
    WHERE [MessageID] = @MessageID



GO

CREATE PROCEDURE [dbo].[EditTopic]
	@TopicName NVARCHAR(50),
	@TopicID INT
AS
	UPDATE [ForumDB].[dbo].[Topics]
    SET [TopicName] = @TopicName
    WHERE [TopicID] = @TopicID


GO

CREATE PROCEDURE [dbo].[EditTypeUser]
	@TypeUserID INT,
	@UserID INT
AS
	UPDATE [ForumDB].[dbo].[Users]
    SET [TypeUserID] = @TypeUserID
    WHERE [UserID] = @UserID


GO

CREATE PROCEDURE [dbo].[ExistTopic]
	@TopicName NVARCHAR(50)
AS
	SELECT COUNT([TopicName]) FROM [ForumDB].[dbo].[Topics] WHERE [TopicName] = @TopicName


GO

CREATE PROCEDURE [dbo].[ExistUser]
	@UserName NVARCHAR(50)
AS
	SELECT COUNT([UserName]) FROM [ForumDB].[dbo].[Users] WHERE [UserName] = @UserName


GO

CREATE PROCEDURE [dbo].[SelectMaxTopicID]
AS
	SELECT MAX([TopicID]) FROM [ForumDB].[dbo].[Topics]


GO

CREATE PROCEDURE [dbo].[SelectMessInfo]
	@TopicID INT
AS
	SELECT MAX([MessageDate]), COUNT(*)
    FROM [ForumDB].[dbo].[Messages]
    WHERE [TopicID] = @TopicID


GO

CREATE PROCEDURE [dbo].[SelectTextMessage]
	@MessageID INT
AS
	SELECT [TextMessage] FROM [ForumDB].[dbo].[Messages] WHERE [MessageID] = @MessageID

GO

CREATE PROCEDURE [dbo].[SelectTopicName]
	@TopicID INT
AS
	SELECT [TopicName] FROM [ForumDB].[dbo].[Topics] WHERE [TopicID] = @TopicID

GO

CREATE PROCEDURE [dbo].[SelectTypeUser]
	@UserName NVARCHAR(50)
AS
	SELECT [TypeUser] 
	FROM [ForumDB].[dbo].[TypeUser]
	WHERE [TypeUserID] = 
	        (SELECT [TypeUserID] 
	         FROM [ForumDB].[dbo].[Users]
	         WHERE [UserName] = @UserName)

GO

CREATE PROCEDURE [dbo].[SelectTypeUserID]
	@TypeUser NVARCHAR(50)
AS
SELECT [TypeUserID] FROM [ForumDB].[dbo].[TypeUser] WHERE [TypeUser] = @TypeUser

GO

CREATE PROCEDURE [dbo].[SelectUserID]
	@UserName NVARCHAR(50)
AS
	SELECT [UserID] FROM [ForumDB].[dbo].[Users] WHERE [UserName] = @UserName

GO

CREATE PROCEDURE [dbo].[SelectUserName]
	@UserID INT
AS
	SELECT [UserName] FROM [ForumDB].[dbo].[Users] WHERE [UserID] = @UserID

GO


CREATE PROCEDURE [dbo].[ShowMessages]
	@TopicID INT
AS
	SELECT [MessageID]
	      ,[MessageDate]
	      ,[TextMessage]
	      ,[UserID]
	      ,[TopicID]
	FROM [ForumDB].[dbo].[Messages] 
	WHERE [TopicID] = @TopicID


GO

CREATE PROCEDURE [dbo].[ShowMessagesByOneUser]
	@UserID INT
AS
	SELECT [MessageID]
	      ,[MessageDate]
	      ,[TextMessage]
	      ,[UserID]
	      ,[TopicID]
	FROM [ForumDB].[dbo].[Messages] 
	WHERE [UserID] = @UserID


GO

CREATE PROCEDURE [dbo].[ShowTopics]
AS
	SELECT T.[TopicID], T.[TopicName], U.[UserName]
	FROM [ForumDB].[dbo].[Topics] AS T
	JOIN [ForumDB].[dbo].[Users] AS U
	ON T.[UserID] = U.[UserID]

GO

CREATE PROCEDURE [dbo].[ShowTypeUsers]
AS
	SELECT [TypeUser] FROM [ForumDB].[dbo].[TypeUser]

GO

CREATE PROCEDURE [dbo].[ShowUserInfo]
	@UserID INT
AS
	SELECT U.[UserName]
	      ,U.[Password]
	      ,U.[RegistrationDate]            
	      ,TY.[TypeUser]
	      ,(SELECT COUNT(*) 
	       FROM [ForumDB].[dbo].[Messages] AS M
	       WHERE M.[UserID] = @UserID)
	FROM [ForumDB].[dbo].[Users] AS U
	JOIN [ForumDB].[dbo].[TypeUser] AS TY
	ON U.[TypeUserID] = TY.[TypeUserID]
	WHERE U.[UserID] = @UserID


GO

CREATE PROCEDURE [dbo].[ShowUsers]
AS
	SELECT [UserName] FROM [ForumDB].[dbo].[Users]


GO

CREATE PROCEDURE [dbo].[ValidateUser]
	@UserName NVARCHAR(50),
	@Password NVARCHAR(50)
AS
	SELECT COUNT(*) FROM [ForumDB].[dbo].[Users] WHERE [UserName] = @UserName AND [Password] = @Password

GO