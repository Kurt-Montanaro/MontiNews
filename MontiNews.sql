USE [master]
GO
/****** Object:  Database [MontiNews]    Script Date: 5/27/2017 11:52:04 PM ******/
CREATE DATABASE [MontiNews]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MontiNews', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MontiNews.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MontiNews_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MontiNews_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MontiNews] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MontiNews].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MontiNews] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MontiNews] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MontiNews] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MontiNews] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MontiNews] SET ARITHABORT OFF 
GO
ALTER DATABASE [MontiNews] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MontiNews] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MontiNews] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MontiNews] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MontiNews] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MontiNews] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MontiNews] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MontiNews] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MontiNews] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MontiNews] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MontiNews] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MontiNews] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MontiNews] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MontiNews] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MontiNews] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MontiNews] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MontiNews] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MontiNews] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MontiNews] SET  MULTI_USER 
GO
ALTER DATABASE [MontiNews] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MontiNews] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MontiNews] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MontiNews] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MontiNews] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MontiNews]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 5/27/2017 11:52:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[Heading] [nvarchar](50) NOT NULL,
	[Sub] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[ArticleContent] [nvarchar](max) NOT NULL,
	[Published] [datetime] NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Author]    Script Date: 5/27/2017 11:52:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (6, N'Shark Attack', N'Msida', N'Odd', N'admin', N'Great-White-Shark.jpg', N'Attakk feroci', CAST(N'2017-05-26 22:11:10.000' AS DateTime))
INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (7, N'Beautiful Xlendi', N'Maltese Treasure', N'Travel', N'admin', N'5-2-700x500.jpg', N'Xlendi Bay beach quality: It is cleaned by the local authorities.

Beach facilities: Sunbeds and umbrellas are available on the right side of the outer bay facing the beautiful cliffs and blue deep sea water.

Getting here: Getting here is very easy. The capital city Rabat, also known as Victoria, is centrally located and well connected with the surrounding villages. From Rabat follow the signs to Fontana and from there you can start the descent down to the valley until you reach this location.', CAST(N'2017-05-26 23:11:10.000' AS DateTime))
INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (8, N'Elezzjoni toqrob', N'Elezzjoni Generali 2017', N'National', N'admin', N'file.jpg', N'L-Għawdxin li talbu li jixtiequ l-vot tagħhom minn Malta għandhom jiġbruh personalment mill-Uffiċċju tal-Kummissjoni Elettorali fil-Kumpless tal-Għadd tal-Voti fin-Naxxar.
Fi stqarrija, il-Kummissjoni spjegat li wieħed jista’ jagħmel dan minn nhar it-Tnejn li ġej sal-Ħamis li ġej.
Il-ħinijiet għall-ġbir tad-dokumenti se jkunu:
Mit-Tnejn 29 sal-Erbgħa 31 ta’ Mejju:
mit-8am sas-2pm, u mit-3pm sad-9pm;
Il-Ħamis 1 ta’ Ġunju (l-aħħar jum):
mit-8am sas-2pm, u mit-3pm sa nofsillejl.
Dawk il-votanti rreġistrati Malta u li għażlu li jiġbru d-dokument tal-vot tagħhom minn Għawdex, għandhom jagħmlu dan fl-istess ġranet u fl-istess ħinijiet mill-Uffiċċju tal-Karta tal-Identità, 28A, Pjazza San Franġisk, ir-Rabat - Għawdex.', CAST(N'2017-05-27 18:31:29.000' AS DateTime))
INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (9, N'Ariana Grande lura Manchester', N'UPDATE: Manchester Attacks', N'Overseas', N'admin', N'1285516-400xNone.jpg', N'Nhar it-Tnejn li ġej, il-kantanta Amerikana Ariana Grande se tmur lura Manchester fl-Ingilterra sabiex tkanta għall-vittmi li tilfu ħajjithom waqt il-kunċert tagħha.
Fuq Twitter, il-kantanta semmiet kif qalbha u t-talb tagħha qiegħda mat-22 persuna li tilfu ħajithom fil-Manchester Arena nhar it-Tnejn li għadda.
Sostniet kif la hija u lanqas ħadd ieħor ma jista’ jagħmel xejn biex itaffi l-weġgħat tal-qraba tal-vittmi, iżda qed toffri qalbha jekk tista’ tgħin b’xi mod.
Hawnhekk Ariana Grande qalet li se tmur lura f’dik li sejħet bħala l-“belt qalbiena ta’ Manchester” sabiex tqatta’ ħin man-nies u ħa terġa’ tkanta biex tiġbor flus għall-vittmi u l-familji tagħhom.
Qalet li r-risposta għall-vjolenza għandha tkun iktar għaqda, mħabba u ġenerożità.', CAST(N'2017-05-27 18:40:09.000' AS DateTime))
INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (10, N'Luxol jirbħu l-ewwel logħba tal-playoffs', N'Futsal', N'Sports', N'admin', N'1286391-400xNone.jpg', N'Luxol ħadu l-ewwel rebħa kontra ċ-champions renjanti Valletta fl-ewwel partita tal-finali tal-Playoffs tal-Elite fil-futsal.
Iż-żewġ timijiet, reġa’ kellhom staġun mill-aqwa u taw logħba kbira bħal f’kull konfront li jkollhom bejniethom. 
Luxol u Valletta ssieltu mhux ftit hekk kif it-tnejn li huma riedu r-rebħa u għaldaqstant l-ewwel taqsima spiċċat fi dro ta'' 1-1.
Fit-tieni taqsima Luxol ħarġu aktar determinati u dawru r-riżultat għal kollox favurihom biex l-iskor finali spiċċa dak ta'' 5-2.', CAST(N'2017-05-27 18:43:41.000' AS DateTime))
INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (11, N'Business and politics do not mix', N'Opinion on current election overview', N'Opinion', N'admin', N'18157197_10212554328842572_7026708253469284468_n.jpg', N'Business is a great important thing. What a pity that it is being given such a bad name.
Businessmen are generally hardworking, honest persons that create wealth by providing us with goods and services and they do this candidly and with great dedication. 
Businessmen as human beings are lucky that they get fulfilment from what they do - they come up with great ideas that involve risk; they invest money in researching ideas and in innovation. They take big decisions. They have insight and they are brave. We call this entrepreneurship. The values of these businessmen make the world go around. They set up businesses, employ bright people as executives and managers, they employ others to do the more repetitive work. They disseminate values of challenging work, enterprise, and creativity. 
What a pity that business is being given a bad name.', CAST(N'2017-05-27 18:44:50.000' AS DateTime))
INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (12, N'Serqa f''PaceVille', N'Jaħrab darbtejn u jibqa'' b''xejn', N'National', N'admin', N'1286486-400xNone.jpg', N'Raġel qed jiġi mfittex mill-Pulizija wara li wettaq serqa f’Paceville.
Kelliem għall-Pulizija qal ma’ montinews.com  li s-serqa seħħet f’ħanut tal-ġojjellerija fis-2.30pm.
Ir-raġel irnexxielu jaħrab minn fuq il-post b’xi ġojjellerija, imma twaqqaf minn xi nies li kienu għaddejjin fit-triq.
Hekk kif waqqfuh ir-raġel telaq il-ġojjellerija li kien seraq fl-art u reġa’ ħarab.', CAST(N'2017-05-27 18:50:49.000' AS DateTime))
INSERT [dbo].[Article] ([ArticleID], [Heading], [Sub], [Category], [Username], [Image], [ArticleContent], [Published]) VALUES (13, N'Fit for The King! ', N'A glimpse inside Elvis''s Private jet.', N'Odd', N'admin', N'408B04AF00000578-0-Elvis_Presley_s_last_privately_owned_jet_will_be_auctioned_on_Ma-m-33_1495457198535.jpg', N'''This aircraft has never been restored and features original external painting and detailing, as well as original interior,'' the listing reads. 
''The interior was custom designed to Elvis'' specifications. Down to the gold-tone, woodwork, inlay and red velvet seats and red shag carpet.'' 
The jet is currently owned by a private collector, who has not been named.', CAST(N'2017-05-27 18:54:53.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorID], [Username], [Email], [Password], [Name], [Surname], [Description]) VALUES (3, N'admin', N'admin@admin.com', N'7ZBILKZSCrcJPY/1Y+76MQZpFiVC+fqnx0XSVo8Le57JggJ6yce4QBERHYAHWyP1eVF9orA5hD/up8fYCoY+5A==', N'Admin', N'Adminny', N'Admin is my name, I control things around here.')
INSERT [dbo].[Author] ([AuthorID], [Username], [Email], [Password], [Name], [Surname], [Description]) VALUES (4, N'Montanaro', N'montakurt@gmail.com', N'7ZBILKZSCrcJPY/1Y+76MQZpFiVC+fqnx0XSVo8Le57JggJ6yce4QBERHYAHWyP1eVF9orA5hD/up8fYCoY+5A==', N'Kurt', N'Montanaro', N'Tifel ferriehi, minajr ma jwettaq griehi.')
SET IDENTITY_INSERT [dbo].[Author] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [U_AuthorUsername]    Script Date: 5/27/2017 11:52:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [U_AuthorUsername] ON [dbo].[Author]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MontiNews] SET  READ_WRITE 
GO
