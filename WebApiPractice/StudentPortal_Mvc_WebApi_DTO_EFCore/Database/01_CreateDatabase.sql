USE [master];
GO
IF DB_ID('StudentPortalDb') IS NULL CREATE DATABASE [StudentPortalDb];
GO
USE [StudentPortalDb];
GO
IF OBJECT_ID('dbo.Enrollments', 'U') IS NOT NULL DROP TABLE dbo.Enrollments;
IF OBJECT_ID('dbo.tblLog', 'U') IS NOT NULL DROP TABLE dbo.tblLog;
IF OBJECT_ID('dbo.Courses', 'U') IS NOT NULL DROP TABLE dbo.Courses;
IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL DROP TABLE dbo.Students;
GO
CREATE TABLE [dbo].[Courses](
    [CourseId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] [nvarchar](150) NOT NULL,
    [DurationDays] [int] NOT NULL,
    [Fee] [decimal](10, 2) NOT NULL,
    [Level] [nvarchar](30) NOT NULL,
    [IsActive] [bit] NOT NULL CONSTRAINT [DF_Courses_IsActive] DEFAULT ((1)),
    [CreatedAt] [datetime2](7) NOT NULL CONSTRAINT [DF_Courses_CreatedAt] DEFAULT (sysdatetime())
);
GO
CREATE TABLE [dbo].[Students](
    [StudentId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FullName] [nvarchar](120) NOT NULL,
    [Email] [nvarchar](180) NOT NULL,
    [Phone] [nvarchar](30) NULL,
    [Status] [nvarchar](20) NOT NULL CONSTRAINT [DF_Students_Status] DEFAULT ('Active'),
    [JoinDate] [date] NOT NULL,
    [CreatedAt] [datetime2](7) NOT NULL CONSTRAINT [DF_Students_CreatedAt] DEFAULT (sysdatetime())
);
GO
CREATE TABLE [dbo].[Enrollments](
    [EnrollmentId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [StudentId] [int] NOT NULL,
    [CourseId] [int] NOT NULL,
    [EnrollDate] [date] NOT NULL,
    [PaymentStatus] [nvarchar](20) NOT NULL CONSTRAINT [DF_Enrollments_PaymentStatus] DEFAULT ('Pending'),
    [PaidAmount] [decimal](10, 2) NOT NULL CONSTRAINT [DF_Enrollments_PaidAmount] DEFAULT ((0)),
    [CreatedAt] [datetime2](7) NOT NULL CONSTRAINT [DF_Enrollments_CreatedAt] DEFAULT (sysdatetime()),
    CONSTRAINT [UQ_Enrollments_StudentCourse] UNIQUE ([StudentId], [CourseId]),
    CONSTRAINT [FK_Enrollments_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students]([StudentId]),
    CONSTRAINT [FK_Enrollments_Courses] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses]([CourseId])
);
GO
CREATE TABLE [dbo].[tblLog](
    [StudentId] [int] NOT NULL,
    [LogId] [int] NOT NULL PRIMARY KEY,
    [Info] [varchar](2000) NULL,
    CONSTRAINT [FK_tblLog_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students]([StudentId])
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Students_Email] ON [dbo].[Students]([Email]);
CREATE NONCLUSTERED INDEX [IX_Courses_Title] ON [dbo].[Courses]([Title]);
CREATE NONCLUSTERED INDEX [IX_Enrollments_StudentId] ON [dbo].[Enrollments]([StudentId]);
CREATE NONCLUSTERED INDEX [IX_Enrollments_CourseId] ON [dbo].[Enrollments]([CourseId]);
GO