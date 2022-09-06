IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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
    [GradeID] bigint NULL,
    CONSTRAINT [PK_USER] PRIMARY KEY ([UserID]),
    CONSTRAINT [FK_USER_CLASS_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [CLASS] ([ClassID]) ON DELETE CASCADE,
    CONSTRAINT [FK_USER_GRADE_GradeID] FOREIGN KEY ([GradeID]) REFERENCES [GRADE] ([GradeID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_USER_ROLE_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [ROLE] ([RoleID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_USER_ClassID] ON [USER] ([ClassID]);
GO

CREATE INDEX [IX_USER_GradeID] ON [USER] ([GradeID]);
GO

CREATE UNIQUE INDEX [IX_USER_RoleID] ON [USER] ([RoleID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220722181737_initial', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [USER] DROP CONSTRAINT [FK_USER_GRADE_GradeID];
GO

DROP INDEX [IX_USER_GradeID] ON [USER];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[USER]') AND [c].[name] = N'GradeID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [USER] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [USER] DROP COLUMN [GradeID];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220722182020_scond', N'5.0.17');
GO

COMMIT;
GO

