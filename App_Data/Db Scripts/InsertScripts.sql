INSERT INTO [dbo].[Users] ( [Name], [Login], [Password]) VALUES ( N'Admin User', N'Admin', N'Admin')

INSERT INTO [dbo].[Region] ( [Location]) VALUES ( N'East Region')
INSERT INTO [dbo].[Region] ( [Location]) VALUES ( N'West Region')
INSERT INTO [dbo].[Region] ([Location]) VALUES ( N'Central Region')

INSERT INTO [dbo].[Products] ( [Name], [Description], [MonthlyBasePrice]) VALUES ( N'Diagnosis', N'Diagnosis', CAST(100.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ( [Name], [Description], [MonthlyBasePrice]) VALUES ( N'Procedure', N'Procedure', CAST(1000.36 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ( [Name], [Description], [MonthlyBasePrice]) VALUES ( N'Anesthesia', N'Anesthesia', CAST(856.35 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ( [Name], [Description], [MonthlyBasePrice]) VALUES ( N'E/M', N'E/M', CAST(432.29 AS Decimal(16, 2)))

INSERT INTO [dbo].[User_Log] ( [User_Id], [LoginDate], [ProductID]) VALUES ( 1, N'2020-08-18 00:00:00', 1)


INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client A  ', 1)
INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client B  ', 1)
INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client C  ', 2)
INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client D  ', 3)
INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client A  ', 1)
INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client B  ', 1)
INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client C  ', 2)
INSERT INTO [dbo].[Client] ( [Name], [RegionID]) VALUES ( N'Client D  ', 3)

