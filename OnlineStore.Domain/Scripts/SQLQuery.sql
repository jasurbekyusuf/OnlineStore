CREATE DATABASE OnlineStore1;

USE OnlineStore1;

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
ProductCount int,
Sold int,
UserId int foreign key  references Seller(Id) not null,
CreatedDate datetimeoffset,
UpdatedDate datetimeoffset
)

Create Table [Order](
Id int identity(1,1)primary key not null,
Count int not null,
TotalPrice decimal not null,
ProductId int foreign key  references Product(Id),
CustomerId int foreign key  references Customer(Id),
SellerId int foreign key references Seller(Id)
)
