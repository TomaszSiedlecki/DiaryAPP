BEGIN TRANSACTION;
GO

EXEC sp_rename N'[SUBJECTS].[ClassID]', N'Class_ID', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220722184008_third', N'5.0.17');
GO

COMMIT;
GO

