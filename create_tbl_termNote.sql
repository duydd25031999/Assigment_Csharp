USE [PRN292_ASS]
GO

/****** Object:  Table [dbo].[termNote]    Script Date: 11/12/2019 8:41:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[termNote](
	[termid] [int] NULL,
	[userid] [int] NULL,
	[note] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


