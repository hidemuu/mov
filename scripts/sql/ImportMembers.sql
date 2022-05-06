USE [MobileLinks.Sql.MobileLinksDbContext]
GO

/****** Object:  Table [dbo].[Memories]    Script Date: 2020/01/15 12:58:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DELETE FROM [dbo].[Members];

GO

BULK INSERT [dbo].[Members]
FROM 'C:\Applications\MobileLinks\SolutionAssets\Initialize\Member.csv'
WITH
(
	FIRSTROW = 2,
	--FORMAT = 'CSV'
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FORMATFILE='C:\Applications\MobileLinks\SolutionAssets\Formats\Member.xml'
);