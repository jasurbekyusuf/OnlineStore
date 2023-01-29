CREATE DATABASE OnlineStore1;

USE OnlineStore1;

CREATE TABLE Seller(
Id int identity (1,1) primary key not null,
FirstName nvarchar(50),
LastName nvarchar(50),
Email nvarchar(50),
Phone nvarchar(50)
)

insert into Seller(FirstName,LastName,Email,Phone)
values('Jasurbek','Yusufov','jasur@gmail.com','1234567')

CREATE TABLE Customer (
Id int identity (1,1) primary key not null,
FirstName nvarchar(50),
LastName nvarchar(50),
Email nvarchar(50),
Phone nvarchar(50)
)

insert into Customer(FirstName,LastName,Email,Phone)
values('Cristiano','Ronaldo','ronaldo@gmail.com','+9981234567')

Create Table Product(
Id int identity(1,1)primary key not null,
Title nvarchar(50),
Descriptions nvarchar(500),
Price decimal not null,
ProductCount int null,
Sold int null,
SellerId int foreign key  references Seller(Id),
CreatedDate datetimeoffset,
UpdatedDate datetimeoffset
)

Create Table Orders(
Id int identity(1,1)primary key not null,
Count int not null,
TotalPrice decimal not null,
CustomerId int foreign key  references Customer(Id),
SellerId int foreign key references Seller(Id)
)

Create Table OrdersProduct(
Id int identity(1,1)primary key not null,
ProductId int foreign key  references Product(Id),
OrderId int foreign key references Orders(Id)
)


