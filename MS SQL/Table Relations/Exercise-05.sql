CREATE
 TABLE [Cities](
       [CityID] INT PRIMARY KEY,
	   [Name] VARCHAR(60))

CREATE
 TABLE [Customers](
       [CustomerID] INT PRIMARY KEY,
	   [Name] VARCHAR(60) NOT NULL,
	   [Birthday] DATETIME2,
	   [CityID] INT NOT NULL FOREIGN KEY REFERENCES [Cities](CityID))

CREATE
 TABLE [Orders](
       [OrderID] INT PRIMARY KEY,
	   [CustomerID] INT NOT NULL FOREIGN KEY REFERENCES [Customers](CustomerID))

CREATE
 TABLE [ItemTypes](
       [ItemTypeID] INT PRIMARY KEY,
	   [Name] VARCHAR(60) NOT NULL)

CREATE
 TABLE [Items](
       [ItemID] INT PRIMARY KEY,
	   [Name] VARCHAR(60) NOT NULL,
	   [ItemTypeID] INT NOT NULL FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID))

CREATE
 TABLE [OrderItems](
       [OrderID] INT NOT NULL FOREIGN KEY REFERENCES [Orders](OrderID),
	   [ItemID] INT NOT NULL FOREIGN KEY REFERENCES [Items](ItemID),
	   CONSTRAINT [PK_OrderID, ItemID] PRIMARY KEY(OrderID, ItemID))