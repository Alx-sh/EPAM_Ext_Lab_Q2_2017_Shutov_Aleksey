--13.1--
IF OBJECT_ID('GreatestOrders') IS NOT NULL
	DROP PROCEDURE GreatestOrders
GO
CREATE PROCEDURE GreatestOrders
	@Year INT
AS
	SELECT LastName + ' ' + FirstName AS 'Seller', 
		o1.OrderID,  
		CONVERT(MONEY, ROUND((UnitPrice - UnitPrice * Discount) * Quantity, 2), 1) AS 'Totals'
	FROM Northwind.Employees
	JOIN Northwind.Orders AS o1
	ON Employees.EmployeeID = o1.EmployeeID
	JOIN Northwind.[Order Details]
	ON o1.OrderID = [Order Details].OrderID
	WHERE YEAR(OrderDate) = @Year
	AND (UnitPrice - UnitPrice * Discount) * Quantity = 
		(SELECT MAX((UnitPrice - UnitPrice * Discount) * Quantity)
		 FROM Northwind.Orders AS o2
		 JOIN Northwind.[Order Details]
		 ON o2.OrderID = [Order Details].OrderID
		 WHERE YEAR(OrderDate) = @Year AND o1.EmployeeID = o2.EmployeeID)
GO

--13.2--
IF OBJECT_ID('ShippedOrdersDiff') IS NOT NULL
	DROP PROCEDURE ShippedOrdersDiff
GO
CREATE PROCEDURE ShippedOrdersDiff
	@SpecifiedDelay INT = 35
AS
	SELECT OrderID, CONVERT(NVARCHAR, OrderDate, 101) AS OrderDate, CONVERT(NVARCHAR, ShippedDate, 101) AS ShippedDate, DATEDIFF(DAY, OrderDate, ShippedDate) AS 'ShippedDelay', @SpecifiedDelay AS 'SpecifiedDelay'
	FROM Northwind.Orders
	WHERE DATEDIFF(DAY, OrderDate, ShippedDate) > @SpecifiedDelay OR ShippedDate IS NULL
GO

--13.3--
IF OBJECT_ID('SubordinationInfo') IS NOT NULL
	DROP PROCEDURE SubordinationInfo
GO
CREATE PROCEDURE SubordinationInfo
	@EmployerID INT,
	@Sym NVARCHAR(30) = ''
AS
	DECLARE @Name NVARCHAR(30)
	DECLARE @EmpID INT = 0
BEGIN
	SET @Name = 
	(
		SELECT @Sym + LastName + ' ' + FirstName 
		FROM Northwind.Employees 
		WHERE EmployeeID = @EmployerID
	)
	PRINT @Name
	SET @Sym = @Sym + '  '
	WHILE (@EmpID IS NOT NULL)
	BEGIN
		SET @EmpID = 
		(
			SELECT MIN(EmployeeID)
			FROM Northwind.Employees 
			WHERE EmployeeID > @EmpID
		)
		IF EXISTS 
		(
			SELECT ReportsTo
			FROM Northwind.Employees
			WHERE ReportsTo = @EmployerID AND @EmpID = EmployeeID
		)
		EXEC SubordinationInfo @EmpID, @Sym
	END
END
GO

--13.4--
IF OBJECT_ID('IsBoss') IS NOT NULL
	DROP FUNCTION IsBoss
GO
CREATE FUNCTION IsBoss(@EmployeeID INT)
	RETURNS BIT
AS
BEGIN
	IF EXISTS(
		SELECT EmployeeID
		FROM Northwind.Employees
		WHERE ReportsTo = @EmployeeID)
		RETURN 1
	RETURN 0
END
GO