USE [master]
GO

/****** Object:  Database [QLTCuoi]    Script Date: 12/3/2017 6:22:42 PM ******/
CREATE DATABASE [QLTCuoi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLTCuoi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLTCuoi.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLTCuoi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLTCuoi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [QLTCuoi] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLTCuoi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [QLTCuoi] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [QLTCuoi] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [QLTCuoi] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [QLTCuoi] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [QLTCuoi] SET ARITHABORT OFF 
GO

ALTER DATABASE [QLTCuoi] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [QLTCuoi] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [QLTCuoi] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [QLTCuoi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [QLTCuoi] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [QLTCuoi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [QLTCuoi] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [QLTCuoi] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [QLTCuoi] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [QLTCuoi] SET  DISABLE_BROKER 
GO

ALTER DATABASE [QLTCuoi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [QLTCuoi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [QLTCuoi] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [QLTCuoi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [QLTCuoi] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [QLTCuoi] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [QLTCuoi] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [QLTCuoi] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [QLTCuoi] SET  MULTI_USER 
GO

ALTER DATABASE [QLTCuoi] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [QLTCuoi] SET DB_CHAINING OFF 
GO

ALTER DATABASE [QLTCuoi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [QLTCuoi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [QLTCuoi] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [QLTCuoi] SET  READ_WRITE 
GO
