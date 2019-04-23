USE [master]
GO
/****** Object:  Database [MajsterStrelby]    Script Date: 14. 4. 2019 21:22:37 ******/
CREATE DATABASE [MajsterStrelby]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MajsterStrelby', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SERVERSQL\MSSQL\DATA\MajsterStrelby.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MajsterStrelby_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SERVERSQL\MSSQL\DATA\MajsterStrelby_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MajsterStrelby] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MajsterStrelby].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MajsterStrelby] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MajsterStrelby] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MajsterStrelby] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MajsterStrelby] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MajsterStrelby] SET ARITHABORT OFF 
GO
ALTER DATABASE [MajsterStrelby] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MajsterStrelby] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MajsterStrelby] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MajsterStrelby] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MajsterStrelby] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MajsterStrelby] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MajsterStrelby] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MajsterStrelby] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MajsterStrelby] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MajsterStrelby] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MajsterStrelby] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MajsterStrelby] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MajsterStrelby] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MajsterStrelby] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MajsterStrelby] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MajsterStrelby] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MajsterStrelby] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MajsterStrelby] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MajsterStrelby] SET  MULTI_USER 
GO
ALTER DATABASE [MajsterStrelby] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MajsterStrelby] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MajsterStrelby] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MajsterStrelby] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MajsterStrelby] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MajsterStrelby] SET QUERY_STORE = OFF
GO
USE [MajsterStrelby]
GO
/****** Object:  Table [dbo].[achievmenty]    Script Date: 14. 4. 2019 21:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[achievmenty](
	[id_hrac] [int] NOT NULL,
	[typ_achievmentu] [int] NOT NULL,
	[level_achievmentu] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[info_hrac]    Script Date: 14. 4. 2019 21:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[info_hrac](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[meno] [varchar](30) NOT NULL,
 CONSTRAINT [info_hrac_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sk_lemmas_antonyms]    Script Date: 14. 4. 2019 21:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sk_lemmas_antonyms](
	[lemma] [varchar](60) NOT NULL,
	[pos] [char](1) NOT NULL,
	[synset] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[lemma] ASC,
	[pos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sk_lemmas_synonyms]    Script Date: 14. 4. 2019 21:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sk_lemmas_synonyms](
	[lemma] [varchar](60) NOT NULL,
	[pos] [char](1) NOT NULL,
	[synset] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[synonimicke_vztahy]    Script Date: 14. 4. 2019 21:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[synonimicke_vztahy](
	[prve_slovo] [varchar](30) NOT NULL,
	[druhe_slovo] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zbieranie_ohodnoteni]    Script Date: 14. 4. 2019 21:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zbieranie_ohodnoteni](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_hrac] [int] NOT NULL,
	[prve_slovo] [varchar](30) NOT NULL,
	[druhe_slovo] [varchar](30) NOT NULL,
	[vzdialenost] [float] NOT NULL,
	[body] [int] NOT NULL,
 CONSTRAINT [PK_zbieranie_ohodnoteni] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zrucnosti]    Script Date: 14. 4. 2019 21:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zrucnosti](
	[id_hrac] [int] NOT NULL,
	[atribut] [int] NOT NULL,
	[level_atributu] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[achievmenty]  WITH CHECK ADD  CONSTRAINT [achievmenty_info_hrac] FOREIGN KEY([id_hrac])
REFERENCES [dbo].[info_hrac] ([id])
GO
ALTER TABLE [dbo].[achievmenty] CHECK CONSTRAINT [achievmenty_info_hrac]
GO
ALTER TABLE [dbo].[zbieranie_ohodnoteni]  WITH CHECK ADD  CONSTRAINT [zbieranie_ohodnoteni_info_hrac] FOREIGN KEY([id_hrac])
REFERENCES [dbo].[info_hrac] ([id])
GO
ALTER TABLE [dbo].[zbieranie_ohodnoteni] CHECK CONSTRAINT [zbieranie_ohodnoteni_info_hrac]
GO
ALTER TABLE [dbo].[zrucnosti]  WITH CHECK ADD  CONSTRAINT [zrucnosti_info_hrac] FOREIGN KEY([id_hrac])
REFERENCES [dbo].[info_hrac] ([id])
GO
ALTER TABLE [dbo].[zrucnosti] CHECK CONSTRAINT [zrucnosti_info_hrac]
GO
USE [master]
GO
ALTER DATABASE [MajsterStrelby] SET  READ_WRITE 
GO
