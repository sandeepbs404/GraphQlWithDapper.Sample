
/****** Object:  Table [dbo].[Form]    Script Date: 25-04-2018 11:23:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Form](
	[Identification] [nvarchar](max) NULL,
	[FormCreationDate] [nvarchar](max) NULL,
	[FormCreationHour] [nvarchar](max) NULL,
	[AttestationStatus] [nvarchar](max) NULL,
	[TypeForm] [nvarchar](max) NULL,
	[Form_Id] [varchar](50) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_Form_Id] PRIMARY KEY CLUSTERED 
(
	[Form_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[EmployerDeclaration](
	[Quarter] [nvarchar](max) NULL,
	[NOSSRegistrationNbr] [nvarchar](max) NULL,
	[Trusteeship] [nvarchar](max) NULL,
	[NOSSLPARegistrationNbr] [nvarchar](max) NULL,
	[CompanyID] [nvarchar](max) NULL,
	[System5] [nvarchar](max) NULL,
	[EmployerDeclarationPID] [nvarchar](max) NULL,
	[EmployerDeclarationVersionNbr] [nvarchar](max) NULL,
	[ResultCodeResearch] [nvarchar](max) NULL,
	[AnomalySubmission] [nvarchar](max) NULL,
	[Form_Id] [varchar](50) NOT NULL,
	[EmployerDeclaration_Id] [varchar](50) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_EmployerDeclaration_Id] PRIMARY KEY CLUSTERED 
(
	[EmployerDeclaration_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployerDeclaration]  WITH CHECK ADD FOREIGN KEY([Form_Id])
REFERENCES [dbo].[Form] ([Form_Id])
GO


