USE [onlinestore]
GO

/****** Object:  UserDefinedFunction [dbo].[GetOrderDetails]    Script Date: 2/4/2023 12:15:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetOrderDetails]()
RETURNS TABLE
AS
RETURN
SELECT 
    CreatedDate AS [Date], 
    Seller.Id AS SellerId,
	Seller.FirstName AS SellerName,
    Product.Id AS ProductId,
	Product.Title AS ProductName,
	Product.Price AS ProductPrice,
    Customer.Id AS CustomerId,
	Customer.FirstName AS CustomerName,
    SUM([Order].Quantity) AS TotalQuantity, 
	SUM([Product].Price*[Order].Quantity) AS TotalPrice
FROM 
    [Order]
    JOIN Seller ON [Order].SellerId = Seller.Id 
    JOIN Product ON [Order].ProductId = Product.Id 
    JOIN Customer ON [Order].CustomerId = Customer.Id 
GROUP BY 
    [Order].CreatedDate,
    Seller.Id, 
	Seller.FirstName,
    Product.Id, 
	Product.Title,
	Product.Price,
    Customer.Id,
	Customer.FirstName
GO


