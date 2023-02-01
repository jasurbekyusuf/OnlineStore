CREATE DATABASE onlinestore;

USE onlinestore;

CREATE TABLE Seller(
Id int identity (1,1) primary key not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Email nvarchar(50) not null unique,
Phone nvarchar(50) not null
)

insert into Seller(FirstName,LastName,Email,Phone)
values('Jasurbek','Yusufov','jasur@gmail.com','1234567')

CREATE TABLE Customer (
Id int identity (1,1) primary key not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Email nvarchar(50) not null unique,
Phone nvarchar(50) not null
)

insert into Customer(FirstName,LastName,Email,Phone)
values('Cristiano','Ronaldo','ronaldo@gmail.com','+9981234567')

Create Table Product(
Id int identity(1,1)primary key not null,
Title nvarchar(50) not null,
Descriptions nvarchar(500),
Price decimal not null,
CreatedSellerId int foreign key  references Seller(Id) not null
)

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

insert into [Order](Quantity,TotalPrice,ProductId,CustomerId,SellerId)
values(1,1000,4,1,1)

