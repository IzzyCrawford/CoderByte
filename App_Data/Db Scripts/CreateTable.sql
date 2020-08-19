CREATE TABLE [dbo].[Region] (
   [Id]           INT	IDENTITY(1,1),
    [Location] NCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Users] (
   [Id]           INT	IDENTITY(1,1),
    [Name]     NCHAR (25) NULL,
    [Login]    NCHAR (15) NULL,
    [Password] NCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Client] (
    [Id]       INT IDENTITY(1,1) ,
    [Name]     NCHAR (10) NULL,
    [RegionID] INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Region] ([Id])
);

CREATE TABLE [dbo].[Products] (
    [Id]           INT	IDENTITY(1,1),
    [Name]             NCHAR (25)      NULL,
    [Description]      NCHAR (50)      NULL,
    [MonthlyBasePrice] NUMERIC (16, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Client_Products] (
    [Id]           INT	IDENTITY(1,1),
    [ClientID]     INT             NULL,
    [ProductID]    INT             NULL,
    [Discount]     DECIMAL (16, 2) NULL,
    [ActiveDate]   DATETIME        NULL,
    [InactiveDate] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([Id]),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([Id])
);


CREATE TABLE [dbo].[User_Log] (
   [Id]           INT	IDENTITY(1,1),
    [User_Id]   INT      NULL,
    [LoginDate] DATETIME NULL,
    [ProductID] INT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([Id])
);
