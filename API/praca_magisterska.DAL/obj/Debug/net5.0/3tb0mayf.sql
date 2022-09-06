BEGIN TRANSACTION;
GO

ALTER TABLE [USER] DROP CONSTRAINT [FK_USER_CLASS_ClassID];
GO

ALTER TABLE [USER] DROP CONSTRAINT [FK_USER_ROLE_RoleID];
GO

DROP INDEX [IX_USER_RoleID] ON [USER];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[USER]') AND [c].[name] = N'RoleID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [USER] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [USER] ALTER COLUMN [RoleID] bigint NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[USER]') AND [c].[name] = N'ClassID');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [USER] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [USER] ALTER COLUMN [ClassID] bigint NULL;
GO

CREATE UNIQUE INDEX [IX_USER_RoleID] ON [USER] ([RoleID]) WHERE [RoleID] IS NOT NULL;
GO

ALTER TABLE [USER] ADD CONSTRAINT [FK_USER_CLASS_ClassID] FOREIGN KEY ([ClassID]) REFERENCES [CLASS] ([ClassID]) ON DELETE NO ACTION;
GO

ALTER TABLE [USER] ADD CONSTRAINT [FK_USER_ROLE_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [ROLE] ([RoleID]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220722191359_four', N'5.0.17');
GO

COMMIT;
GO

