CREATE PROCEDURE [dbo].[Reports_Procedure]
	@ClientId int,
	@Client_Products_Id int
AS
	SELECT 
		Client.Name,
		Region.Location,
		Products.Name,
		(Products.MonthlyBasePrice - Client_Products.Discount) AS Total
	FROM Client_Products
		Inner Join Client on Client_Products.ClientID = Client.Id
		Inner Join Region on Client.RegionID = Region.Id
		Inner Join Products on Client_Products.ProductID = Products.Id
	WHERE Client.Id = @ClientId
	    AND Client_Products.Id = @Client_Products_Id
		AND InactiveDate = NULL
		
RETURN

GO;