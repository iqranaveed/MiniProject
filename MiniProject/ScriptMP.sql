USE [ProjectA]
GO
/****** Object:  Table [dbo].[Advisor]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advisor](
	[Id] [int] NOT NULL,
	[Designation] [int] NOT NULL,
	[Salary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Evaluation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created_On] [date] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupEvaluation]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupEvaluation](
	[GroupId] [int] NOT NULL,
	[EvaluationId] [int] NOT NULL,
	[ObtainedMarks] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupEvaluation] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[EvaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupProject]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupProject](
	[ProjectId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupStudent]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupStudent](
	[GroupId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupStudent] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lookup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[Contact] [varchar](20) NULL,
	[Email] [varchar](30) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectAdvisor]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAdvisor](
	[AdvisorId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[AdvisorRole] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectAdvisor] PRIMARY KEY CLUSTERED 
(
	[AdvisorId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[RegistrationNo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[question1]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[question1] AS
SELECT (FirstName + LastName) AS AdvisorName, Designation
FROM Person
JOIN Advisor
ON Advisor.Id = Person.Id
WHERE Advisor.Id not in (SELECT AdvisorId FROM ProjectAdvisor)
GO
/****** Object:  View [dbo].[question2]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[question2] AS
SELECT (FirstName + LastName) AS AdvisorName, Title
FROM Person
JOIN Advisor
ON Advisor.Id = Person.Id
JOIN ProjectAdvisor
ON ProjectAdvisor.AdvisorId = Advisor.Id
JOIN Project
ON Project.Id = ProjectAdvisor.ProjectId
GO
/****** Object:  View [dbo].[question3]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[question3] AS
SELECT P2.FirstName AS AdvisorName, P1.FirstName AS StudentName
FROM (Person as P1 JOIN ProjectAdvisor ON P1.Id = ProjectAdvisor.ProjectId)
JOIN Person AS P2 ON P2.Id = ProjectAdvisor.AdvisorId

GO
/****** Object:  View [dbo].[question4]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[question4] AS
SELECT Person.Id AS StudentId, FirstName AS StudentName, GroupStudent.GroupId
FROM Person JOIN Student ON Person.Id = Student.Id
JOIN GroupStudent ON GroupStudent.StudentId = Student.Id 
JOIN GroupProject ON GroupProject.groupId = GroupStudent.groupId 
JOIN ProjectAdvisor ON ProjectAdvisor.ProjectId = GroupProject.ProjectId
GO
/****** Object:  View [dbo].[question6]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[question6] AS
SELECT Name AS EvaluationName, TotalMarks, ObtainedMarks
FROM GroupEvaluation
JOIN Evaluation ON Evaluation.Id = GroupEvaluation.EvaluationId
GO
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (52, 6, CAST(20000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1, N'Enter Name', 30, 5)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (2, N'Enter Name', 34, 23)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (3, N'iqra', 34, 3)
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (4, CAST(N'2019-03-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (5, CAST(N'2019-03-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (6, CAST(N'2019-03-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (7, CAST(N'2019-03-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (8, CAST(N'2019-05-02' AS Date))
SET IDENTITY_INSERT [dbo].[Group] OFF
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (4, 1, 39, CAST(N'2019-01-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (1, N'Male', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (2, N'Female', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (3, N'Active', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (4, N'InActive', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (6, N'Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (7, N'Associate Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (8, N'Assisstant Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (9, N'Lecturer', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (10, N'Industry Professional', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (11, N'Main Advisor', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (12, N'Co-Advisror', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (14, N'Industry Advisor', N'ADVISOR_ROLE')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (4, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (5, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (6, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (7, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (9, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (10, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (11, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (12, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (13, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (14, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (15, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (16, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (17, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (18, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (19, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (21, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (22, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (23, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (24, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (25, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (26, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (27, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (28, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (29, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (30, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (31, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (32, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (33, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (34, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (35, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (36, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (37, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (38, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (39, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (40, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (41, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (42, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (43, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (44, N'', N'', N'', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (45, N'nn', N'mmm', N'987', N'yuy', CAST(N'1998-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (46, N'iqra', N'iqra', N'4345', N'ffff', CAST(N'1997-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (47, N'sa', N'asa', N'565', N'iqra', CAST(N'1996-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (48, N'uchiha', N'itachi', N'0900', N'asd', CAST(N'1998-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (49, N'itachi', N'itachi', N'0900', N'iqra@gmail.com', CAST(N'1998-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (50, N'iqra', N'iqra', N'0900', N'iqra@gmail.com', CAST(N'1998-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (51, N'iqra', N'naveed', N'0900', N'iqra@gmail.com', CAST(N'1997-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (52, N'iqra', N'naveed', N'090078601', N'iqra@gmail.com', CAST(N'1997-01-01 00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (1, N'kkkkkkkkkkkk', N'kkkkkkkkkk')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2, N'aise', N'aise')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (3, N'aise', N'aise')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (4, N'aise', N'aise')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (5, N'aise', N'aise')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (6, N'qwqw', N'qwqw')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (7, N'er', N'er')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (8, N'ui', N'ui')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (9, N'sa', N'as')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (10, N'bv', N'bv')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (11, N'nm', N'nm')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (12, N'xc', N'zxz')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (13, N'assaassa', N'assaas')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (14, N'nauto', N'nauto')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (15, N'aaaa', N'aaaaaa')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (16, N'sssssssss', N'sssssssss')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (17, N'ttttt', N'ttttt')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (18, N'nnnnnnn', N'nnnnn')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (19, N'llllllllll', N'llllllllllll')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (20, N'ddddddd', N'dddddd')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (21, N'itachi', N'itachi')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (22, N'blah', N'bluh')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (23, N'xxxx', N'wwwww')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (24, N'iqra', N'iqra')
SET IDENTITY_INSERT [dbo].[Project] OFF
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (52, 2, 11, CAST(N'2019-04-10 10:11:33.217' AS DateTime))
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (6, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (7, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (9, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (11, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (12, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (13, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (14, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (15, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (16, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (17, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (18, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (19, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (21, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (22, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (23, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (24, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (25, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (26, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (27, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (28, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (29, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (30, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (31, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (32, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (33, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (34, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (35, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (36, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (37, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (38, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (39, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (40, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (41, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (42, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (43, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (44, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (45, N'987')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (46, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (47, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (48, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (49, N'')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (50, N'')
ALTER TABLE [dbo].[Advisor]  WITH CHECK ADD  CONSTRAINT [FK_Advisor_Lookup] FOREIGN KEY([Designation])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Advisor] CHECK CONSTRAINT [FK_Advisor_Lookup]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Evaluation] FOREIGN KEY([EvaluationId])
REFERENCES [dbo].[Evaluation] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Evaluation]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Project]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_GroupStudents_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_GroupStudents_Lookup]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Group]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Student]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Lookup] FOREIGN KEY([Gender])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Lookup] FOREIGN KEY([AdvisorRole])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Project]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeachers_Teacher] FOREIGN KEY([AdvisorId])
REFERENCES [dbo].[Advisor] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectTeachers_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person]
GO
/****** Object:  StoredProcedure [dbo].[projects]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[projects] AS
SELECT (SELECT Person.FirstName FROM Person
JOIN Advisor
ON Person.Id = Advisor.Id
WHERE ProjectAdvisor.AdvisorId = Advisor.Id) AS AdvisorName, Count(*) AS ProjectCount
FROM ProjectAdvisor
GROUP BY ProjectAdvisor.AdvisorId
GO
/****** Object:  StoredProcedure [dbo].[question4_1]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[question4_1] AS
SELECT Person.Id AS StudentId, FirstName AS StudentName, GroupStudent.GroupId
FROM Person JOIN Student ON Person.Id = Student.Id
JOIN GroupStudent ON GroupStudent.StudentId = Student.Id 
JOIN GroupProject ON GroupProject.groupId = GroupStudent.groupId 
JOIN ProjectAdvisor ON ProjectAdvisor.ProjectId = GroupProject.ProjectId
GO
/****** Object:  StoredProcedure [dbo].[question5]    Script Date: 5/2/2019 8:36:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[question5] AS
SELECT ProjectAdvisor.ProjectId, Count(*) AS ProjectCount
FROM ProjectAdvisor
JOIN GroupProject ON GroupProject.ProjectId = ProjectAdvisor.ProjectId
Group By ProjectAdvisor.ProjectId 

GO
