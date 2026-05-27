IF DB_ID('Store') IS NULL
BEGIN
    CREATE DATABASE [Store]
END
GO

USE [Store]
GO

/* =====================================================
   PRODUCT TABLE
===================================================== */
IF OBJECT_ID('dbo.Product', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Product](
        [ProductId] INT IDENTITY(1,1) NOT NULL,
        [ProductResourceID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Name] NVARCHAR(50) NOT NULL,

        CONSTRAINT [PK_Product]
            PRIMARY KEY ([ProductId]),

        CONSTRAINT [UQ_Product_ProductResourceID]
            UNIQUE ([ProductResourceID])
    )
END
GO

/* =====================================================
   USER TABLE
===================================================== */
IF OBJECT_ID('dbo.[User]', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[User](
        [UserId] INT IDENTITY(1,1) NOT NULL,
        [UserResourceId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Name] NVARCHAR(50) NOT NULL,
        [Username] NVARCHAR(50) NOT NULL,
        [Email] NVARCHAR(100) NOT NULL,
        [PasswordHash] NVARCHAR(255) NOT NULL,

        CONSTRAINT [PK_User]
            PRIMARY KEY ([UserId]),

        CONSTRAINT [UQ_User_UserResourceId]
            UNIQUE ([UserResourceId]),

        CONSTRAINT [UQ_User_Username]
            UNIQUE ([Username]),

        CONSTRAINT [UQ_User_Email]
            UNIQUE ([Email])
    )
END
GO

/* =====================================================
   ROLE TABLE
===================================================== */
IF OBJECT_ID('dbo.Role', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Role](
        [Id] INT IDENTITY(1,1) NOT NULL,
        [RoleResourceId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Name] NVARCHAR(100) NOT NULL,

        CONSTRAINT [PK_Role]
            PRIMARY KEY ([Id]),

        CONSTRAINT [UQ_Role_Name]
            UNIQUE ([Name]),

        CONSTRAINT [UQ_Role_RoleResourceId]
            UNIQUE ([RoleResourceId])
    )
END
GO

/* =====================================================
   USERROLE TABLE
===================================================== */
IF OBJECT_ID('dbo.UserRole', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[UserRole](
        [UserId] INT NOT NULL,
        [RoleId] INT NOT NULL,
        [UserRoleResourceId] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

        CONSTRAINT [PK_UserRole]
            PRIMARY KEY ([UserId], [RoleId]),

        CONSTRAINT [UQ_UserRole_UserRoleResourceId]
            UNIQUE ([UserRoleResourceId]),

        CONSTRAINT [FK_UserRole_User]
            FOREIGN KEY ([UserId])
            REFERENCES [dbo].[User]([UserId])
            ON DELETE CASCADE,

        CONSTRAINT [FK_UserRole_Role]
            FOREIGN KEY ([RoleId])
            REFERENCES [dbo].[Role]([Id])
            ON DELETE CASCADE
    )
END
GO

/* =====================================================
   MOCK DATA - PRODUCT
===================================================== */
IF NOT EXISTS (SELECT 1 FROM dbo.Product)
BEGIN
    INSERT INTO dbo.Product (Name)
    VALUES
        ('Gaming Laptop'),
        ('Mechanical Keyboard'),
        ('Wireless Mouse'),
        ('27 Inch Monitor'),
        ('USB-C Docking Station')
END
GO

/* =====================================================
   MOCK DATA - ROLE
===================================================== */
IF NOT EXISTS (SELECT 1 FROM dbo.Role)
BEGIN
    INSERT INTO dbo.Role (Name)
    VALUES
        ('Administrator'),
        ('Customer'),
        ('Support')
END
GO

/* =====================================================
   MOCK DATA - USER
===================================================== */
IF NOT EXISTS (SELECT 1 FROM dbo.[User])
BEGIN
    INSERT INTO dbo.[User]
    (
        Name,
        Username,
        Email,
        PasswordHash
    )
    VALUES
    (
        'Carlos Rodriguez',
        'carlosr',
        'carlos@example.com',
        'HASH_PASSWORD_1'
    ),
    (
        'Maria Gonzalez',
        'mariag',
        'maria@example.com',
        'HASH_PASSWORD_2'
    ),
    (
        'John Smith',
        'johns',
        'john@example.com',
        'HASH_PASSWORD_3'
    )
END
GO

/* =====================================================
   MOCK DATA - USERROLE
===================================================== */
IF NOT EXISTS (SELECT 1 FROM dbo.UserRole)
BEGIN
    INSERT INTO dbo.UserRole (UserId, RoleId)
    VALUES
        (1, 1), -- Carlos -> Administrator
        (2, 2), -- Maria -> Customer
        (3, 3), -- John -> Support
        (1, 3)  -- Carlos -> Support
END
GO

/* =====================================================
   TEST QUERIES
===================================================== */
SELECT * FROM dbo.Product;
SELECT * FROM dbo.[User];
SELECT * FROM dbo.Role;
SELECT * FROM dbo.UserRole;
GO
