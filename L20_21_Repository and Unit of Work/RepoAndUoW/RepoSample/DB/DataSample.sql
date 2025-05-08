USE Shop;
GO

-- Thêm dữ liệu vào bảng Products
INSERT INTO Products (ProductId, ProductName, ProductPrice, Quantity) VALUES
(NEWID(), N'Laptop Dell XPS 13', 1200.00, 10),
(NEWID(), N'iPhone 14 Pro', 999.99, 20),
(NEWID(), N'Bàn phím cơ Keychron K6', 89.99, 15),
(NEWID(), N'Chuột Logitech MX Master 3', 79.99, 25);
GO

-- Thêm dữ liệu vào bảng Orders
INSERT INTO Orders (OrderId, CustomerId, OrderReference) VALUES
(NEWID(), NEWID(), 'ORD001'),
(NEWID(), NEWID(), 'ORD002'),
(NEWID(), NEWID(), 'ORD003');
GO

-- Thêm dữ liệu vào bảng OrderItems
INSERT INTO OrderItems (OrderItemId, OrderId, ProductId, Quantity, Price) VALUES
(NEWID(), (SELECT TOP 1 OrderId FROM Orders ORDER BY NEWID()), (SELECT TOP 1 ProductId FROM Products ORDER BY NEWID()), 2, 1200.00),
(NEWID(), (SELECT TOP 1 OrderId FROM Orders ORDER BY NEWID()), (SELECT TOP 1 ProductId FROM Products ORDER BY NEWID()), 1, 999.99),
(NEWID(), (SELECT TOP 1 OrderId FROM Orders ORDER BY NEWID()), (SELECT TOP 1 ProductId FROM Products ORDER BY NEWID()), 3, 89.99);
GO
