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

CREATE TABLE [USER] (
    [UserID] bigint NOT NULL,
    [FirstName] varchar(50) NOT NULL,
    [SecondName] varchar(50) NOT NULL,
    [BornDate] datetime2 NOT NULL,
    [AccountName] varchar(50) NOT NULL,
    [Password] varchar(254) NOT NULL,
    [Email] nvarchar(max) NULL,
    [Address] varchar(50) NOT NULL,
    CONSTRAINT [PK_USER] PRIMARY KEY ([UserID]),
    CONSTRAINT [FK_USER_CLASS_UserID] FOREIGN KEY ([UserID]) REFERENCES [CLASS] ([ClassID]) ON DELETE CASCADE
);
GO

CREATE TABLE [GRADE] (
    [GradeID] bigint NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    [StudentUserID] bigint NULL,
    CONSTRAINT [PK_GRADE] PRIMARY KEY ([GradeID]),
    CONSTRAINT [FK_GRADE_USER_StudentUserID] FOREIGN KEY ([StudentUserID]) REFERENCES [USER] ([UserID]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ROLE] (
    [RoleID] bigint NOT NULL,
    [Name] varchar(50) NOT NULL,
    [Description] varchar(100) NOT NULL,
    CONSTRAINT [PK_ROLE] PRIMARY KEY ([RoleID]),
    CONSTRAINT [FK_ROLE_USER_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [USER] ([UserID]) ON DELETE CASCADE
);
GO

CREATE TABLE [SUBJECTS] (
    [SubjectID] bigint NOT NULL,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_SUBJECTS] PRIMARY KEY ([SubjectID]),
    CONSTRAINT [FK_SUBJECTS_GRADE_SubjectID] FOREIGN KEY ([SubjectID]) REFERENCES [GRADE] ([GradeID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_GRADE_StudentUserID] ON [GRADE] ([StudentUserID]);
GO

ALTER TABLE [USER] ADD CONSTRAINT [FK_USER_GRADE_UserID] FOREIGN KEY ([UserID]) REFERENCES [GRADE] ([GradeID]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220722175643_initial', N'5.0.17');
GO

COMMIT;
GO

