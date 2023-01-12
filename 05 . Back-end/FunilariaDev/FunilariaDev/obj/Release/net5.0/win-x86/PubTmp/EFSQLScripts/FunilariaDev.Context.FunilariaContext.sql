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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE TABLE [Brands] (
        [IdBrand] int NOT NULL IDENTITY,
        [NameBrand] varchar(70) NOT NULL,
        CONSTRAINT [PK_Brands] PRIMARY KEY ([IdBrand])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE TABLE [Services] (
        [IdService] int NOT NULL IDENTITY,
        [Problem] varchar(200) NOT NULL,
        CONSTRAINT [PK_Services] PRIMARY KEY ([IdService])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE TABLE [Users] (
        [IdUser] int NOT NULL IDENTITY,
        [Name] varchar(40) NOT NULL,
        [Email] varchar(100) NOT NULL,
        [Password] varchar(200) NOT NULL,
        [Phone] BIGINT NOT NULL,
        [ImagePlate] varchar(255) NULL,
        [Plate] varchar(255) NULL,
        [TypeUser] INT NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([IdUser])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE TABLE [templates] (
        [IdModel] int NOT NULL IDENTITY,
        [IdBrand] int NOT NULL,
        [NameModel] varchar(100) NOT NULL,
        CONSTRAINT [PK_templates] PRIMARY KEY ([IdModel]),
        CONSTRAINT [FK_templates_Brands_IdBrand] FOREIGN KEY ([IdBrand]) REFERENCES [Brands] ([IdBrand]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE TABLE [Cars] (
        [IdCar] int NOT NULL IDENTITY,
        [Plate] varchar(11) NOT NULL,
        [Color] varchar(30) NOT NULL,
        [Year] varchar(20) NOT NULL,
        [City] varchar(60) NOT NULL,
        [Model] varchar(70) NOT NULL,
        [Brand] varchar(40) NOT NULL,
        [IdUser] int NOT NULL,
        CONSTRAINT [PK_Cars] PRIMARY KEY ([IdCar]),
        CONSTRAINT [FK_Cars_Users_IdUser] FOREIGN KEY ([IdUser]) REFERENCES [Users] ([IdUser]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE TABLE [Budgets] (
        [IdBudget] int NOT NULL IDENTITY,
        [IdModel] int NOT NULL,
        [IdService] int NOT NULL,
        [TotalValue] float NOT NULL,
        CONSTRAINT [PK_Budgets] PRIMARY KEY ([IdBudget]),
        CONSTRAINT [FK_Budgets_Services_IdService] FOREIGN KEY ([IdService]) REFERENCES [Services] ([IdService]) ON DELETE CASCADE,
        CONSTRAINT [FK_Budgets_templates_IdModel] FOREIGN KEY ([IdModel]) REFERENCES [templates] ([IdModel]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE UNIQUE INDEX [IX_Brands_NameBrand] ON [Brands] ([NameBrand]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE INDEX [IX_Budgets_IdModel] ON [Budgets] ([IdModel]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE INDEX [IX_Budgets_IdService] ON [Budgets] ([IdService]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE INDEX [IX_Cars_IdUser] ON [Cars] ([IdUser]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE UNIQUE INDEX [IX_Cars_Plate] ON [Cars] ([Plate]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE UNIQUE INDEX [IX_Services_Problem] ON [Services] ([Problem]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE INDEX [IX_templates_IdBrand] ON [templates] ([IdBrand]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE UNIQUE INDEX [IX_templates_NameModel] ON [templates] ([NameModel]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    CREATE UNIQUE INDEX [IX_Users_Phone] ON [Users] ([Phone]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119103834_Banco')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211119103834_Banco', N'5.0.12');
END;
GO

COMMIT;
GO

