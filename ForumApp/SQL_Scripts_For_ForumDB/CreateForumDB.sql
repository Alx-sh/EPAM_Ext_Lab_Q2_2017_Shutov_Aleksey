USE [master]
GO

/****** Object:  Database [ForumDB]    Script Date: 12.09.2017 12:06:10 ******/
CREATE DATABASE [ForumDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ForumDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ForumDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ForumDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ForumDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [ForumDB] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ForumDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ForumDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ForumDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ForumDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ForumDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ForumDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [ForumDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ForumDB] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [ForumDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ForumDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ForumDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ForumDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ForumDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ForumDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ForumDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ForumDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ForumDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ForumDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ForumDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ForumDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ForumDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ForumDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ForumDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ForumDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ForumDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ForumDB] SET  MULTI_USER 
GO

ALTER DATABASE [ForumDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ForumDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ForumDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ForumDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [ForumDB] SET  READ_WRITE 
GO


