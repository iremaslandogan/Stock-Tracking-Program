USE [master]
GO
/****** Object:  Database [StokTakip]    Script Date: 27.12.2018 22:53:40 ******/
CREATE DATABASE [StokTakip]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StokTakip', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StokTakip.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StokTakip_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StokTakip_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StokTakip] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StokTakip].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StokTakip] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StokTakip] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StokTakip] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StokTakip] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StokTakip] SET ARITHABORT OFF 
GO
ALTER DATABASE [StokTakip] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StokTakip] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StokTakip] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StokTakip] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StokTakip] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StokTakip] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StokTakip] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StokTakip] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StokTakip] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StokTakip] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StokTakip] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StokTakip] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StokTakip] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StokTakip] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StokTakip] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StokTakip] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StokTakip] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StokTakip] SET RECOVERY FULL 
GO
ALTER DATABASE [StokTakip] SET  MULTI_USER 
GO
ALTER DATABASE [StokTakip] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StokTakip] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StokTakip] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StokTakip] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StokTakip] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StokTakip', N'ON'
GO
ALTER DATABASE [StokTakip] SET QUERY_STORE = OFF
GO
USE [StokTakip]
GO
/****** Object:  Table [dbo].[Bilesen]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bilesen](
	[UrunID] [int] NOT NULL,
	[UrunTuru] [nvarchar](50) NOT NULL,
	[UrunOzellik] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bilgisayar]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bilgisayar](
	[RAM] [nvarchar](50) NULL,
	[Islemci] [nvarchar](50) NULL,
	[EkranKarti] [nvarchar](50) NULL,
	[IsletimSistemi] [nvarchar](50) NULL,
	[EkranBoyutu] [nvarchar](50) NULL,
	[WIFI] [nvarchar](50) NULL,
	[HardDisk] [nvarchar](50) NULL,
	[SSD] [nvarchar](50) NULL,
	[Bluetooth] [nvarchar](50) NULL,
	[Cekirdek] [nvarchar](50) NULL,
	[UrunID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Birim]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Birim](
	[BirimID] [int] IDENTITY(1,1) NOT NULL,
	[BirimAdi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Birim] PRIMARY KEY CLUSTERED 
(
	[BirimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BirimYetkilisi]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BirimYetkilisi](
	[KullaniciID] [int] NULL,
	[BirimID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depo]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depo](
	[ZimmetID] [int] NULL,
	[UrunID] [int] NULL,
	[DepoBilgi] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[SonGirisTarih] [nvarchar](50) NULL,
	[Silindi] [bit] NULL,
	[Yetki] [nvarchar](50) NOT NULL,
	[Birim] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kullanicilar_1] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatinAlmaGorevlisi]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatinAlmaGorevlisi](
	[KullaniciID] [int] NULL,
	[BirimID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stok]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stok](
	[StokID] [int] IDENTITY(1,1) NOT NULL,
	[Adet] [int] NULL,
	[UrunID] [int] NULL,
	[UrunTuru] [nvarchar](50) NULL,
 CONSTRAINT [PK_Stok] PRIMARY KEY CLUSTERED 
(
	[StokID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urun]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](50) NULL,
	[UrunBirimFiyat] [nvarchar](50) NULL,
	[SatinAlmaTarih] [nvarchar](50) NULL,
	[SatinAlinanFirma] [nvarchar](50) NULL,
	[BirimID] [int] NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[KullaniciID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zimmetleme]    Script Date: 27.12.2018 22:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zimmetleme](
	[ZimmetID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[ZimmetlemeBilgi] [nvarchar](50) NULL,
	[ZimmetlemeTarih] [nvarchar](50) NULL,
 CONSTRAINT [PK_Zimmetleme] PRIMARY KEY CLUSTERED 
(
	[ZimmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bilesen]  WITH CHECK ADD  CONSTRAINT [FK_Bilesen_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[Bilesen] CHECK CONSTRAINT [FK_Bilesen_Urun]
GO
ALTER TABLE [dbo].[Bilgisayar]  WITH CHECK ADD  CONSTRAINT [FK_Bilgisayar_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[Bilgisayar] CHECK CONSTRAINT [FK_Bilgisayar_Urun]
GO
ALTER TABLE [dbo].[BirimYetkilisi]  WITH CHECK ADD  CONSTRAINT [FK_BirimYetkilisi_Birim] FOREIGN KEY([BirimID])
REFERENCES [dbo].[Birim] ([BirimID])
GO
ALTER TABLE [dbo].[BirimYetkilisi] CHECK CONSTRAINT [FK_BirimYetkilisi_Birim]
GO
ALTER TABLE [dbo].[BirimYetkilisi]  WITH CHECK ADD  CONSTRAINT [FK_BirimYetkilisi_Kullanicilar1] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[BirimYetkilisi] CHECK CONSTRAINT [FK_BirimYetkilisi_Kullanicilar1]
GO
ALTER TABLE [dbo].[Depo]  WITH CHECK ADD  CONSTRAINT [FK_Depo_Zimmetleme] FOREIGN KEY([ZimmetID])
REFERENCES [dbo].[Zimmetleme] ([ZimmetID])
GO
ALTER TABLE [dbo].[Depo] CHECK CONSTRAINT [FK_Depo_Zimmetleme]
GO
ALTER TABLE [dbo].[SatinAlmaGorevlisi]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlmaGorevlisi_Birim1] FOREIGN KEY([BirimID])
REFERENCES [dbo].[Birim] ([BirimID])
GO
ALTER TABLE [dbo].[SatinAlmaGorevlisi] CHECK CONSTRAINT [FK_SatinAlmaGorevlisi_Birim1]
GO
ALTER TABLE [dbo].[SatinAlmaGorevlisi]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlmaGorevlisi_Kullanicilar1] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[SatinAlmaGorevlisi] CHECK CONSTRAINT [FK_SatinAlmaGorevlisi_Kullanicilar1]
GO
ALTER TABLE [dbo].[Stok]  WITH CHECK ADD  CONSTRAINT [FK_Stok_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[Stok] CHECK CONSTRAINT [FK_Stok_Urun]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Birim1] FOREIGN KEY([BirimID])
REFERENCES [dbo].[Birim] ([BirimID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_Birim1]
GO
ALTER TABLE [dbo].[Yonetici]  WITH CHECK ADD  CONSTRAINT [FK_Yonetici_Kullanicilar1] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[Yonetici] CHECK CONSTRAINT [FK_Yonetici_Kullanicilar1]
GO
ALTER TABLE [dbo].[Zimmetleme]  WITH CHECK ADD  CONSTRAINT [FK_Zimmetleme_Kullanicilar] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[Zimmetleme] CHECK CONSTRAINT [FK_Zimmetleme_Kullanicilar]
GO
ALTER TABLE [dbo].[Zimmetleme]  WITH CHECK ADD  CONSTRAINT [FK_Zimmetleme_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[Zimmetleme] CHECK CONSTRAINT [FK_Zimmetleme_Urun]
GO
USE [master]
GO
ALTER DATABASE [StokTakip] SET  READ_WRITE 
GO
