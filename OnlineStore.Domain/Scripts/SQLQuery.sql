
-- Create a tabele

CREATE DATABASE onlinestore;

-- Use onlinestore dababase

USE onlinestore;

-- Create Seller table

CREATE TABLE Seller(
Id int identity (1,1) primary key not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Email nvarchar(50) not null unique,
Phone nvarchar(50) not null
)

-- Insert data to Seller table

insert into Seller(FirstName,LastName,Email,Phone)
values('Jasurbek','Yusufov','jasur@gmail.com','1234567')

-- Create Customer table

CREATE TABLE Customer (
Id int identity (1,1) primary key not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Email nvarchar(50) not null unique,
Phone nvarchar(50) not null
)

-- Insert data to Customer table

insert into Customer(FirstName,LastName,Email,Phone)
values('Cristiano','Ronaldo','ronaldo@gmail.com','+9981234567')

-- Create Product table

Create Table Product(
Id int identity(1,1)primary key not null,
Title nvarchar(50) not null,
Descriptions nvarchar(500),
Price decimal not null,
CreatedSellerId int foreign key  references Seller(Id) not null
)

-- Create Order table

Create Table [Order](
Id int identity(1,1)primary key not null,
Quantity int not null,
TotalPrice decimal not null,
ProductId int foreign key  references Product(Id) not null,
CustomerId int foreign key  references Customer(Id) not null,
SellerId int foreign key references Seller(Id) not null,
CreatedDate datetimeoffset,
UpdatedDate datetimeoffset
)

--Add random data to Seller table

DECLARE @i INT = 1
DECLARE @random INT
DECLARE @FirstName VARCHAR(50)
DECLARE @LastName VARCHAR(50)
DECLARE @Email VARCHAR(100)
DECLARE @Phone VARCHAR(15)

WHILE (@i <= 100000)
BEGIN
  SET @random = (SELECT FLOOR(RAND() * 100000))

  SET @FirstName = 'FirstName' + CAST(@random AS VARCHAR(10))
  SET @LastName = 'LastName' + CAST(@random AS VARCHAR(10))
  SET @Email = @FirstName + '.' + @LastName + '@email.com'
  SET @Phone = '(+998)' + CAST(FLOOR(RAND() * 1000) + 10 AS VARCHAR(4)) + ' ' + CAST(FLOOR(RAND() * 1000) + 100 AS VARCHAR(4)) + ' ' + CAST(FLOOR(RAND() * 10000) AS VARCHAR(4))

  INSERT INTO [Seller] (FirstName, LastName, Email, Phone)
  VALUES (@FirstName, @LastName, @Email, @Phone)

  SET @i = @i + 1
END

--Add random data to Customer Table

DECLARE @i INT = 1
DECLARE @random INT
DECLARE @FirstName VARCHAR(50)
DECLARE @LastName VARCHAR(50)
DECLARE @Email VARCHAR(100)
DECLARE @Phone VARCHAR(15)

WHILE (@i <= 200000)
BEGIN
  SET @random = (SELECT FLOOR(RAND() * 200000))

  SET @FirstName = 'FirstName' + CAST(@random AS VARCHAR(10))
  SET @LastName = 'LastName' + CAST(@random AS VARCHAR(10))
  SET @Email = @FirstName + '.' + @LastName + '@email.com'
  SET @Phone = '(+998)' + CAST(FLOOR(RAND() * 1000) + 10 AS VARCHAR(4)) + ' ' + CAST(FLOOR(RAND() * 1000) + 100 AS VARCHAR(4)) + ' ' + CAST(FLOOR(RAND() * 10000) AS VARCHAR(4))

  INSERT INTO [Customer] (FirstName, LastName, Email, Phone)
  VALUES (@FirstName, @LastName, @Email, @Phone)

  SET @i = @i + 1
END



-- Add random data to Product table

DECLARE @i INT = 1
DECLARE @random INT
DECLARE @Title NVARCHAR(50)
DECLARE @Descriptions NVARCHAR(500)
DECLARE @Price DECIMAL
DECLARE @CreatedSellerId INT

WHILE (@i <= 1500000000)
BEGIN
SET @random = (SELECT FLOOR(RAND() * 100000)) + 1

SET @Title = 'Product' + CAST(@random AS VARCHAR(10))
SET @Descriptions = 'Description' + CAST(@random AS VARCHAR(10))
SET @Price = (SELECT FLOOR(RAND() * 1000)) + 10.00
SET @CreatedSellerId = (SELECT FLOOR(RAND() * 100000)) + 1

INSERT INTO [Product] (Title, Descriptions, Price, CreatedSellerId)
VALUES (@Title, @Descriptions, @Price, @CreatedSellerId)

SET @i = @i + 1
END

SELECT COUNT(*)
FROM [Order];

--Add random data to Order

DECLARE @i INT = 1
DECLARE @random INT
DECLARE @Quantity INT
DECLARE @TotalPrice DECIMAL
DECLARE @ProductId INT
DECLARE @CustomerId INT
DECLARE @SellerId INT

WHILE (@i <= 10000000)
BEGIN
SET @random = (SELECT FLOOR(RAND() * 1000000))

SET @Quantity = FLOOR(RAND() * 100)
SET @TotalPrice = FLOOR(RAND() * 100000) / 100
SET @ProductId = FLOOR(RAND() * 100000) + 1
SET @CustomerId = FLOOR(RAND() * 100000) + 1
SET @SellerId = FLOOR(RAND() * 100000) + 1

INSERT INTO [Order] (Quantity, TotalPrice, ProductId, CustomerId, SellerId, CreatedDate, UpdatedDate)
VALUES (@Quantity, @TotalPrice, @ProductId, @CustomerId, @SellerId, SYSDATETIMEOFFSET(), SYSDATETIMEOFFSET())

SET @i = @i + 1
END

-- Filter

SELECT 
    CreatedDate AS [Date], 
    Seller.Id AS SellerId, 
    Product.Id AS ProductId,
	Product.Price AS ProductPrice,
    Customer.Id AS CustomerId, 
    SUM([Order].Quantity) AS TotalQuantity, 
  --  SUM([Order].TotalPrice) AS TotalPrice, 
	SUM([Product].Price*[Order].Quantity) AS TotalPrice
FROM 
    [Order] 
    JOIN Seller ON [Order].SellerId = Seller.Id 
    JOIN Product ON [Order].ProductId = Product.Id 
    JOIN Customer ON [Order].CustomerId = Customer.Id 
GROUP BY 
    [Order].CreatedDate,
    Seller.Id, 
    Product.Id, 
	Product.Price,
    Customer.Id 

