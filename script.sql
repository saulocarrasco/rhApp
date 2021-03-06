USE [rhdatabase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/7/2018 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspirePosition] [nvarchar](max) NULL,
	[Department] [nvarchar](max) NULL,
	[EmployeeId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IdentificationNumber] [nvarchar](max) NULL,
	[Languages_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Candidates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompetitionCandidates]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompetitionCandidates](
	[Competition_Id] [int] NOT NULL,
	[Candidate_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CompetitionCandidates] PRIMARY KEY CLUSTERED 
(
	[Competition_Id] ASC,
	[Candidate_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competitions]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competitions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Competitions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateJoin] [datetime] NOT NULL,
	[Department] [nvarchar](max) NULL,
	[JobPosition] [nvarchar](max) NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IdentificationNumber] [nvarchar](max) NULL,
	[Languages_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPositions]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPositions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[RiskLevel] [int] NOT NULL,
	[MinSalary] [decimal](18, 2) NOT NULL,
	[MaxSalary] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.JobPositions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingCandidates]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingCandidates](
	[Training_Id] [int] NOT NULL,
	[Candidate_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TrainingCandidates] PRIMARY KEY CLUSTERED 
(
	[Training_Id] ASC,
	[Candidate_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainings]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Level] [int] NOT NULL,
	[From] [datetime] NOT NULL,
	[To] [datetime] NOT NULL,
	[Institution] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Trainings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCredentials]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCredentials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PassWord] [nvarchar](max) NULL,
	[UserRole] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserCredentials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkExperiences]    Script Date: 10/7/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkExperiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](max) NULL,
	[JobName] [nvarchar](max) NULL,
	[From] [datetime] NOT NULL,
	[To] [datetime] NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[CandidateId] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.WorkExperiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Candidates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Candidates_dbo.Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Candidates] CHECK CONSTRAINT [FK_dbo.Candidates_dbo.Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Candidates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Candidates_dbo.Languages_Languages_Id] FOREIGN KEY([Languages_Id])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Candidates] CHECK CONSTRAINT [FK_dbo.Candidates_dbo.Languages_Languages_Id]
GO
ALTER TABLE [dbo].[CompetitionCandidates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CompetitionCandidates_dbo.Candidates_Candidate_Id] FOREIGN KEY([Candidate_Id])
REFERENCES [dbo].[Candidates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompetitionCandidates] CHECK CONSTRAINT [FK_dbo.CompetitionCandidates_dbo.Candidates_Candidate_Id]
GO
ALTER TABLE [dbo].[CompetitionCandidates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CompetitionCandidates_dbo.Competitions_Competition_Id] FOREIGN KEY([Competition_Id])
REFERENCES [dbo].[Competitions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompetitionCandidates] CHECK CONSTRAINT [FK_dbo.CompetitionCandidates_dbo.Competitions_Competition_Id]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Languages_Languages_Id] FOREIGN KEY([Languages_Id])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Languages_Languages_Id]
GO
ALTER TABLE [dbo].[TrainingCandidates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TrainingCandidates_dbo.Candidates_Candidate_Id] FOREIGN KEY([Candidate_Id])
REFERENCES [dbo].[Candidates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrainingCandidates] CHECK CONSTRAINT [FK_dbo.TrainingCandidates_dbo.Candidates_Candidate_Id]
GO
ALTER TABLE [dbo].[TrainingCandidates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TrainingCandidates_dbo.Trainings_Training_Id] FOREIGN KEY([Training_Id])
REFERENCES [dbo].[Trainings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrainingCandidates] CHECK CONSTRAINT [FK_dbo.TrainingCandidates_dbo.Trainings_Training_Id]
GO
ALTER TABLE [dbo].[WorkExperiences]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkExperiences_dbo.Candidates_CandidateId] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidates] ([Id])
GO
ALTER TABLE [dbo].[WorkExperiences] CHECK CONSTRAINT [FK_dbo.WorkExperiences_dbo.Candidates_CandidateId]
GO
