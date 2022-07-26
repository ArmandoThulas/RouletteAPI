USE [Northwind]
GO
/****** Object:  StoredProcedure [dbo].[pr_GetOrderSummary]    Script Date: 20/07/2022 01:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[pr_GetOrderSummary]
	@StartDate	DATE,
	@EndDate	DATE,
	@EmployeeID	INT,
	@CustomerID	NVARCHAR(5)
AS
BEGIN
	-- Drop a temporary table called '#Orders'
	-- Drop the table if it already exists
	IF OBJECT_ID('tempDB..#Orders', 'U') IS NOT NULL
	DROP TABLE #Orders

	SELECT employee.TitleOfCourtesy + ' ' + employee.FirstName + ' ' + employee.LastName AS EmployeeFullName 
	,shipper.CompanyName AS ShippingCompanyName
	,customer.CompanyName AS CustomerCompanyName
	,orders.OrderID
	,orders.OrderDate AS [Date]
	,orders.Freight
	INTO #Orders
	FROM Orders orders WITH (NOLOCK)
	INNER JOIN Employees employee WITH (NOLOCK) ON orders.EmployeeID = employee.EmployeeID
	INNER JOIN Shippers shipper WITH (NOLOCK) ON orders.ShipVia = shipper.ShipperID
	INNER JOIN Customers customer WITH (NOLOCK) ON orders.CustomerID = customer.CustomerID
	WHERE orders.OrderDate BETWEEN @StartDate AND @EndDate 
	AND employee.EmployeeID = CASE WHEN @EmployeeID IS NULL THEN employee.EmployeeID ELSE @EmployeeID END
	AND customer.CustomerID = CASE WHEN @CustomerID IS NULL THEN customer.CustomerID ELSE @CustomerID END

	SELECT orders.EmployeeFullName 
	,orders.ShippingCompanyName
	,orders.CustomerCompanyName
	,COUNT(orders.OrderID) AS NumberOfOrders
	,orders.[Date]
	,SUM(orders.Freight) AS TotalFreightCost
	,SUM(products.NumberOfDifferentProducts) AS NumberOfDifferentProducts
	,SUM(products.TotalOrderValue) AS TotalOrderValue
	FROM #Orders orders WITH (NOLOCK)
	OUTER APPLY (SELECT COUNT(ProductID) AS NumberOfDifferentProducts, SUM(UnitPrice) AS TotalOrderValue FROM [Order Details] orderDetails WHERE OrderID = orders.OrderID) AS products
	GROUP BY orders.[Date], orders.EmployeeFullName, orders.CustomerCompanyName, orders.ShippingCompanyName
	ORDER BY orders.[Date]

	DROP TABLE #Orders
END
