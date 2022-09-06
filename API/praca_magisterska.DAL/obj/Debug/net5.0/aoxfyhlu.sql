BEGIN TRANSACTION;
GO

ALTER TABLE [SUBJECTS] ADD [ClassID] bigint NOT NULL DEFAULT CAST(0 AS bigint);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220722183832_second', N'5.0.17');
GO

COMMIT;
GO

