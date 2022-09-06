﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [CLASS] (
    [ClassID] bigint NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    [Capacity] numeric(9,3) NOT NULL,
    CONSTRAINT [PK_CLASS] PRIMARY KEY ([ClassID])
);
GO

CREATE TABLE [GRADE] (
    [GradeID] bigint NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    [SubjectID] bigint NOT NULL,
    [Student_ID] bigint NOT NULL,
    [Subject_ID] bigint NOT NULL,
    CONSTRAINT [PK_GRADE] PRIMARY KEY ([GradeID])
);
GO

CREATE TABLE [ROLE] (
    [RoleID] bigint NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    [Description] varchar(100) NOT NULL,
    CONSTRAINT [PK_ROLE] PRIMARY KEY ([RoleID])
);
GO

CREATE TABLE [SUBJECTS] (
    [SubjectID] bigint NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_SUBJECTS] PRIMARY KEY ([SubjectID])
);
GO

CREATE TABLE [USER] (
    [UserID] bigint NOT NULL IDENTITY,
    [FirstName] varchar(50) NOT NULL,
    [SecondName] varchar(50) NOT NULL,
    [BornDate] datetime2 NOT NULL,
    [AccountName] varchar(50) NOT NULL,
    [Password] varchar(254) NOT NULL,
    [Email] nvarchar(max) NULL,
    [Address] varchar(50) NOT NULL,
    [ClassID] bigint NOT NULL,
    [RoleID] bigint NOT NULL,
    CONSTRAINT [PK_USER] PRIMARY KEY ([UserID]),
    CONSTRAINT [FK_USER_CLASS_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [CLASS] ([ClassID]) ON DELETE CASCADE,
    CONSTRAINT [FK_USER_ROLE_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [ROLE] ([RoleID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_USER_ClassID] ON [USER] ([ClassID]);
GO

CREATE UNIQUE INDEX [IX_USER_RoleID] ON [USER] ([RoleID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220722182117_initial', N'5.0.17');
GO

COMMIT;
GO

