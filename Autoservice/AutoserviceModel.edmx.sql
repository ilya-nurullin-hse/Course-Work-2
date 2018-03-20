
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2018 00:23:00
-- Generated from EDMX file: C:\Users\Ilya Nurullin\source\repos\Autoservice\Autoservice\AutoserviceModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Autoservice];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MarkModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoModels] DROP CONSTRAINT [FK_MarkModel];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoModelOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_AutoModelOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ClientOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ManufacturerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ManufacturerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceManufacturer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prices] DROP CONSTRAINT [FK_PriceManufacturer];
GO
IF OBJECT_ID(N'[dbo].[FK_ProviderOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ProviderOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_SpareOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_SpareOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceProvider]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prices] DROP CONSTRAINT [FK_PriceProvider];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceSpare]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prices] DROP CONSTRAINT [FK_PriceSpare];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoModelSpare_AutoModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoModelSpare] DROP CONSTRAINT [FK_AutoModelSpare_AutoModel];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoModelSpare_Spare]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutoModelSpare] DROP CONSTRAINT [FK_AutoModelSpare_Spare];
GO
IF OBJECT_ID(N'[dbo].[FK_SpareSpareType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Spares] DROP CONSTRAINT [FK_SpareSpareType];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_WorkerOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AutoMarks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoMarks];
GO
IF OBJECT_ID(N'[dbo].[AutoModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoModels];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Manufacturers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Manufacturers];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Prices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices];
GO
IF OBJECT_ID(N'[dbo].[Providers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Providers];
GO
IF OBJECT_ID(N'[dbo].[Spares]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Spares];
GO
IF OBJECT_ID(N'[dbo].[SpareTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpareTypes];
GO
IF OBJECT_ID(N'[dbo].[Workers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Workers];
GO
IF OBJECT_ID(N'[dbo].[AutoModelSpare]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoModelSpare];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AutoMarks'
CREATE TABLE [dbo].[AutoMarks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AutoModels'
CREATE TABLE [dbo].[AutoModels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AutoMarkId] int  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL
);
GO

-- Creating table 'Manufacturers'
CREATE TABLE [dbo].[Manufacturers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ManufacturerId] int  NOT NULL,
    [SpareVendorcode] nvarchar(50)  NOT NULL,
    [ProviderId] int  NOT NULL,
    [ClientId] int  NOT NULL,
    [AutoModelId] int  NOT NULL,
    [SparePrice] int  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [TotalPrice] int  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [WorkerId] int  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] int  NOT NULL,
    [Spare_Vendorcode] nvarchar(50)  NOT NULL,
    [Provider_Id] int  NOT NULL,
    [Manufacturer_Id] int  NOT NULL
);
GO

-- Creating table 'Providers'
CREATE TABLE [dbo].[Providers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Spares'
CREATE TABLE [dbo].[Spares] (
    [Vendorcode] nvarchar(50)  NOT NULL,
    [SpareTypeId] int  NOT NULL
);
GO

-- Creating table 'SpareTypes'
CREATE TABLE [dbo].[SpareTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Workers'
CREATE TABLE [dbo].[Workers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AutoModelSpare'
CREATE TABLE [dbo].[AutoModelSpare] (
    [AutoModels_Id] int  NOT NULL,
    [Spares_Vendorcode] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AutoMarks'
ALTER TABLE [dbo].[AutoMarks]
ADD CONSTRAINT [PK_AutoMarks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AutoModels'
ALTER TABLE [dbo].[AutoModels]
ADD CONSTRAINT [PK_AutoModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Manufacturers'
ALTER TABLE [dbo].[Manufacturers]
ADD CONSTRAINT [PK_Manufacturers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Providers'
ALTER TABLE [dbo].[Providers]
ADD CONSTRAINT [PK_Providers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Vendorcode] in table 'Spares'
ALTER TABLE [dbo].[Spares]
ADD CONSTRAINT [PK_Spares]
    PRIMARY KEY CLUSTERED ([Vendorcode] ASC);
GO

-- Creating primary key on [Id] in table 'SpareTypes'
ALTER TABLE [dbo].[SpareTypes]
ADD CONSTRAINT [PK_SpareTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Workers'
ALTER TABLE [dbo].[Workers]
ADD CONSTRAINT [PK_Workers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AutoModels_Id], [Spares_Vendorcode] in table 'AutoModelSpare'
ALTER TABLE [dbo].[AutoModelSpare]
ADD CONSTRAINT [PK_AutoModelSpare]
    PRIMARY KEY CLUSTERED ([AutoModels_Id], [Spares_Vendorcode] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AutoMarkId] in table 'AutoModels'
ALTER TABLE [dbo].[AutoModels]
ADD CONSTRAINT [FK_MarkModel]
    FOREIGN KEY ([AutoMarkId])
    REFERENCES [dbo].[AutoMarks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarkModel'
CREATE INDEX [IX_FK_MarkModel]
ON [dbo].[AutoModels]
    ([AutoMarkId]);
GO

-- Creating foreign key on [AutoModelId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_AutoModelOrder]
    FOREIGN KEY ([AutoModelId])
    REFERENCES [dbo].[AutoModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoModelOrder'
CREATE INDEX [IX_FK_AutoModelOrder]
ON [dbo].[Orders]
    ([AutoModelId]);
GO

-- Creating foreign key on [ClientId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ClientOrder]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientOrder'
CREATE INDEX [IX_FK_ClientOrder]
ON [dbo].[Orders]
    ([ClientId]);
GO

-- Creating foreign key on [ManufacturerId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ManufacturerOrder]
    FOREIGN KEY ([ManufacturerId])
    REFERENCES [dbo].[Manufacturers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManufacturerOrder'
CREATE INDEX [IX_FK_ManufacturerOrder]
ON [dbo].[Orders]
    ([ManufacturerId]);
GO

-- Creating foreign key on [Manufacturer_Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_PriceManufacturer]
    FOREIGN KEY ([Manufacturer_Id])
    REFERENCES [dbo].[Manufacturers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceManufacturer'
CREATE INDEX [IX_FK_PriceManufacturer]
ON [dbo].[Prices]
    ([Manufacturer_Id]);
GO

-- Creating foreign key on [ProviderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ProviderOrder]
    FOREIGN KEY ([ProviderId])
    REFERENCES [dbo].[Providers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProviderOrder'
CREATE INDEX [IX_FK_ProviderOrder]
ON [dbo].[Orders]
    ([ProviderId]);
GO

-- Creating foreign key on [SpareVendorcode] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_SpareOrder]
    FOREIGN KEY ([SpareVendorcode])
    REFERENCES [dbo].[Spares]
        ([Vendorcode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpareOrder'
CREATE INDEX [IX_FK_SpareOrder]
ON [dbo].[Orders]
    ([SpareVendorcode]);
GO

-- Creating foreign key on [Provider_Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_PriceProvider]
    FOREIGN KEY ([Provider_Id])
    REFERENCES [dbo].[Providers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceProvider'
CREATE INDEX [IX_FK_PriceProvider]
ON [dbo].[Prices]
    ([Provider_Id]);
GO

-- Creating foreign key on [Spare_Vendorcode] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_PriceSpare]
    FOREIGN KEY ([Spare_Vendorcode])
    REFERENCES [dbo].[Spares]
        ([Vendorcode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceSpare'
CREATE INDEX [IX_FK_PriceSpare]
ON [dbo].[Prices]
    ([Spare_Vendorcode]);
GO

-- Creating foreign key on [AutoModels_Id] in table 'AutoModelSpare'
ALTER TABLE [dbo].[AutoModelSpare]
ADD CONSTRAINT [FK_AutoModelSpare_AutoModel]
    FOREIGN KEY ([AutoModels_Id])
    REFERENCES [dbo].[AutoModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Spares_Vendorcode] in table 'AutoModelSpare'
ALTER TABLE [dbo].[AutoModelSpare]
ADD CONSTRAINT [FK_AutoModelSpare_Spare]
    FOREIGN KEY ([Spares_Vendorcode])
    REFERENCES [dbo].[Spares]
        ([Vendorcode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoModelSpare_Spare'
CREATE INDEX [IX_FK_AutoModelSpare_Spare]
ON [dbo].[AutoModelSpare]
    ([Spares_Vendorcode]);
GO

-- Creating foreign key on [SpareTypeId] in table 'Spares'
ALTER TABLE [dbo].[Spares]
ADD CONSTRAINT [FK_SpareSpareType]
    FOREIGN KEY ([SpareTypeId])
    REFERENCES [dbo].[SpareTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpareSpareType'
CREATE INDEX [IX_FK_SpareSpareType]
ON [dbo].[Spares]
    ([SpareTypeId]);
GO

-- Creating foreign key on [WorkerId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_WorkerOrder]
    FOREIGN KEY ([WorkerId])
    REFERENCES [dbo].[Workers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkerOrder'
CREATE INDEX [IX_FK_WorkerOrder]
ON [dbo].[Orders]
    ([WorkerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------