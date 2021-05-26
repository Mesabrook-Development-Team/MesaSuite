/****** Object:  Table [dbo].[MCSync]    Script Date: 2/17/2021 9:26:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MCSyncFile](
	[MCSyncFileID] [bigint] IDENTITY(1,1) NOT NULL,
	[FileType] [nvarchar](13) NOT NULL,
	[Path] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NOT NULL,
	[Checksum] [varbinary](16) NOT NULL,
	[DownloadType] [nvarchar](6) NULL,
 CONSTRAINT [PK_MCSyncFile] PRIMARY KEY CLUSTERED 
(
	[MCSyncFileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


INSERT INTO MCSyncFile (FileType, [Path], [Filename], [Checksum], DownloadType) (SELECT FileType, [Path], [Filename], [Checksum], 'Common' FROM MCSync)
go