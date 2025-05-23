﻿CREATE DATABASE Shop
GO

USE Shop
GO

CREATE TABLE Products (
                          ProductId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
                          ProductName NVARCHAR(255) NOT NULL,
                          ProductPrice FLOAT NOT NULL,
                          Quantity INT NOT NULL
);

CREATE TABLE Orders (
                        OrderId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
                        CustomerId UNIQUEIDENTIFIER NOT NULL,
                        OrderReference NVARCHAR (20) NOT NULL,

                        CONSTRAINT unqOrderReference UNIQUE (OrderReference)
)

CREATE TABLE OrderItems (
                            OrderItemId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
                            OrderId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
                            ProductId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Products(ProductId),
                            Quantity INT NOT NULL,
                            Price FLOAT NOT NULL
);