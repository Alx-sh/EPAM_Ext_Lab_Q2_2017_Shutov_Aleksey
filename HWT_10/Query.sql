/*1 ������ � ������ ������ Date, NULL ����������, ����������� ������. 
����������� ������������ �������� � ����������� ������� � ����������� �� ���������� �������������� �������� ���������� �������. 
�������� � ����������� ������� ������ ������������ �������.*/

/*1.1 ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) ������������ � ������� ���������� � ShipVia >= 2. 
������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������, �������� ����������� ������ �Writing International Transact-SQL Statements� � Books Online ������ �Accessing and Changing Relational Data Overview�.
���� ����� ������������ ����� ��� ���� �������. 
������ ������ ����������� ������ ������� OrderID, ShippedDate � ShipVia.
�������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate.*/

SELECT OrderID, CONVERT(NVARCHAR, ShippedDate, 101) AS ShippedDate, ShipVia 
FROM Northwind.Orders
WHERE ShippedDate >= CONVERT(DATETIME, '19980506', 101) AND ShipVia >=2
--������ � NULL �� ������ � �������, ������ ��� ��� �� ������������ � ���������.

/*1.2 �������� ������, ������� ������� ������ �������������� ������ �� ������� Orders.
� ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped� � ������������ ��������� ������� CAS�.
������ ������ ����������� ������ ������� OrderID � ShippedDate.*/

SELECT OrderID, 
		CASE 
			WHEN ShippedDate IS NULL THEN 'Not Shipped'
		END AS ShippedDate
FROM Northwind.Orders
WHERE ShippedDate IS NULL

/*1.3 ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) �� ������� ��� ���� ��� ������� ��� �� ����������.
� ������� ������ ������������� ������ ������� OrderID (������������� � Order Number) � ShippedDate (������������� � Shipped Date).
� ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped�, ��� ��������� �������� ����������� ���� � ������� �� ���������.*/

SELECT OrderID AS 'Order Number', 
		CASE
			WHEN ShippedDate IS NULL THEN 'Not Shipped'
			ELSE CONVERT(NVARCHAR, ShippedDate, 101)
		END AS 'Shipped Date' 
FROM Northwind.Orders
WHERE ShippedDate > CONVERT(DATETIME, '19980506', 101) OR ShippedDate IS NULL

/*2 ������������� ���������� IN, DISTINCT, ORDER BY, NOT*/

/*2.1 ������� �� ������� Customers ���� ����������, ����������� � USA � Canada. 
������ ������� � ������ ������� ��������� IN. 
����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. 
����������� ���������� ������� �� ����� ���������� � �� ����� ����������.*/

SELECT ContactName, Country
FROM Northwind.Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country

/*2.2 ������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. 
������ ������� � ������� ��������� IN. 
����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. 
����������� ���������� ������� �� ����� ����������.*/

SELECT ContactName, Country
FROM Northwind.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName

/*2.3 ������� �� ������� Customers ��� ������, � ������� ��������� ���������. 
������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������. 
�� ������������ ����������� GROUP BY.
����������� ������ ���� ������� � ����������� �������.*/

SELECT DISTINCT Country
FROM Northwind.Customers
ORDER BY Country DESC

/*3 ������������� ��������� BETWEEN, DISTINCT*/

/*3.1 ������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������), ��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � ������� Order Details. 
������������ �������� BETWEEN. 
������ ������ ����������� ������ ������� OrderID.*/

SELECT DISTINCT OrderID
FROM Northwind.[Order Details]
WHERE Quantity BETWEEN 3 AND 10

/*3.2 ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g. 
������������ �������� BETWEEN. 
���������, ��� � ���������� ������� �������� Germany. 
������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.*/

SELECT CustomerID, Country
FROM Northwind.Customers
WHERE Country BETWEEN 'B' AND 'H'
ORDER BY Country

/*3.3 ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g, �� ��������� �������� BETWEEN. 
� ������� ����� �Execution Plan� ���������� ����� ������ ���������������� 3.2 ��� 3.3 � ��� ����� ���� ������ � ������ ���������� ���������� Execution Plan-a ��� ���� ���� ��������, ���������� ���������� Execution Plan ���� ������ � ������ � ���� ����������� � �� �� ����������� ���� ����� �� ������ � �� ������ ��������� ���� ��������� ���������. 
������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.*/

SELECT CustomerID, Country
FROM Northwind.Customers
WHERE Country > 'B' AND Country < 'H'
ORDER BY Country
--������� �� ����� ��������� ���������, ���������� Execution Plan ��� 3.2 � 3.3 �������� �  ����� ExecutionPlan.sqlplan

/*4 ������������� ��������� LIKE*/

/*4.1 � ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 'chocolade'. 
��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� - ����� ��� ��������, ������� ������������� ����� �������. 
���������: ���������� ������� ������ ����������� 2 ������.*/

SELECT ProductName
FROM Northwind.Products
WHERE ProductName LIKE '%cho_olade%'

/*5 ������������� ���������� ������� (SUM, COUNT)*/

/*5.1 ����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� ������� � ������ �� ���.
��������� ��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money.
������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������. 
��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� � ������� UnitPrice ����.
����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� ������� 'Totals'.*/

SELECT CONVERT(MONEY, ROUND(SUM((UnitPrice - UnitPrice * Discount) * Quantity), 2), 1) AS 'Totals'
FROM Northwind.[Order Details]

/*5.2 �� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� (�.�. � ������� ShippedDate ��� �������� ���� ��������).
������������ ��� ���� ������� ������ �������� COUNT.
�� ������������ ����������� WHERE � GROUP.*/

SELECT COUNT(OrderID) - COUNT(ShippedDate) AS 'Not Shipped'
FROM Northwind.Orders

/*5.3 �� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������.
������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.*/ 
 
SELECT COUNT(DISTINCT CustomerID) AS 'Customers'
FROM Northwind.Orders

/*6 ����� ���������� ������, ��������������, ������������� ���������� ������� � ����������� GROUP BY � HAVING*/

/*6.1 �� ������� Orders ����� ���������� ������� � ������������ �� �����.
� ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total.
�������� ����������� ������, ������� ��������� ���������� ���� �������.*/

SELECT YEAR(OrderDate) AS 'Year', COUNT(OrderID) AS 'Total'
FROM Northwind.Orders
GROUP BY YEAR(OrderDate)

SELECT COUNT(OrderID) AS 'Orders'
FROM Northwind.Orders

/*6.2 �� ������� Orders ����� ���������� �������, c�������� ������ ���������.
����� ��� ���������� �������� � ��� ����� ������ � ������� Orders, ��� � ������� EmployeeID ������ �������� ��� ������� ��������.
� ����������� ������� ���� ����������� ������� � ������ �������� 
(������ ������������� ��� ���������� ������������� LastName & FirstName. 
��� ������ LastName & FirstName ������ ���� �������� ��������� �������� � ������� ��������� �������. 
����� �������� ������ ������ ������������ ����������� �� EmployeeID.) 
� ��������� ������� �Seller� � ������� c ����������� ������� ����������� � ��������� 'Amount'. 
���������� ������� ������ ���� ����������� �� �������� ���������� �������.*/

SELECT (SELECT LastName + ' ' + FirstName
		FROM Northwind.Employees
		WHERE Employees.EmployeeID	= Orders.EmployeeID) AS 'Seller',
		COUNT(OrderID) AS 'Amount' 
FROM Northwind.Orders
GROUP BY EmployeeID
ORDER BY Amount DESC

/*6.3 �� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� ����������. 
���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. 
� ����������� ������� ���� ����������� ������� � ������ �������� (�������� ������� �Seller�), ������� � ������ ���������� (�������� ������� �Customer�)  � ������� c ����������� ������� ����������� � ��������� 'Amount'. 
� ������� ���������� ������������ ����������� �������� ����� T-SQL ��� ������ � ���������� GROUP (���� �� �������� ������� �������� ������ �ALL� � ����������� �������). 
����������� ������ ���� ������� �� ID �������� � ����������. 
���������� ������� ������ ���� ����������� �� ��������, ���������� � �� �������� ���������� ������. 
� ����������� ������ ���� ������� ���������� �� ��������.*/

SELECT 
	CASE
		WHEN LastName + ' ' + FirstName IS NULL THEN 'ALL'
		ELSE LastName + ' ' + FirstName
	END AS 'Seller',
	CASE
		WHEN CompanyName IS NULL THEN 'ALL'
		ELSE CompanyName
	END AS 'Customer',
	COUNT(OrderID) AS 'Amount'
FROM Northwind.Orders
JOIN Northwind.Customers
ON Orders.CustomerID = Customers.CustomerID
JOIN Northwind.Employees
ON Orders.EmployeeID = Employees.EmployeeID
WHERE YEAR(OrderDate) = 1998
GROUP BY CUBE(CompanyName, LastName + ' ' + FirstName)
ORDER BY Seller, Customer, Amount DESC

/*6.4 ����� ����������� � ���������, ������� ����� � ����� ������. 
���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ���� ��� ��������� �����������, �� ���������� � ����� ���������� � ��������� �� ������ �������� � �������������� �����. 
�� ������������ ����������� JOIN. 
� ����������� ������� ���������� ������� ��������� ��������� ��� ����������� �������: 
�Person�, �Type� (����� ���� �������� ������ �Customer� ���  �Seller� � ��������� �� ���� ������), �City�. 
������������� ���������� ������� �� ������� �City� � �� �Person�.*/

SELECT ContactName AS 'Person', 'Customer' AS 'Type', City
FROM Northwind.Customers
WHERE EXISTS (SELECT City 
			  FROM Northwind.Employees
			  WHERE Customers.City = Employees.City)
UNION
SELECT LastName + ' ' + FirstName AS 'Person', 'Seller' AS 'Type', City
FROM Northwind.Employees
WHERE EXISTS (SELECT City 
			  FROM Northwind.Customers
			  WHERE Employees.City = Customers.City)
ORDER BY City, Person

/*6.5 ����� ���� �����������, ������� ����� � ����� ������. 
� ������� ������������ ���������� ������� Customers c ����� - ��������������. 
��������� ������� CustomerID � City. 
������ �� ������ ����������� ����������� ������. 
��� �������� �������� ������, ������� ����������� ������, ������� ����������� ����� ������ ���� � ������� Customers. 
��� �������� ��������� ������������ �������.*/

SELECT c1.CustomerID, c1.City
FROM Northwind.Customers AS c1
JOIN Northwind.Customers AS c2
ON c1.City = c2.City
GROUP BY c1.CustomerID, c1.City
HAVING COUNT(c1.City) > 1

SELECT City, COUNT(City) AS 'Count'
FROM Northwind.Customers
GROUP BY City
HAVING COUNT(City) > 1

/*6.6 �� ������� Employees ����� ��� ������� �������� ��� ������������, �.�. ���� �� ������ �������. 
��������� ������� � ������� 'User Name' (LastName) � 'Boss'. 
� �������� ������ ���� ��������� ����� �� ������� LastName. 
��������� �� ��� �������� � ���� �������?*/

SELECT e1.LastName AS 'User Name', e2.LastName AS 'Boss'
FROM Northwind.Employees AS e1
LEFT JOIN Northwind.Employees AS e2
ON e1.ReportsTo = e2.EmployeeID
--��� ������������� LEFT JOIN �������� ��������� ���, �� � Fuller ��� �����, �.�. �� ������ �� ������ �������.
--��� ������������� JOIN �� �������� Fuller.

/*7 ������������� Inner JOIN*/

/*7.1 ���������� ���������, ������� ����������� ������ 'Western' (������� Region).
���������� ������� ������ ����������� ��� ����: 'LastName' �������� � �������� ������������� ���������� ('TerritoryDescription' �� ������� Territories).
������ ������ ������������ JOIN � ����������� FROM.
��� ����������� ������ ����� ��������� Employees � Territories ���� ������������ ����������� ��������� ��� ���� Northwind.*/

SELECT LastName, TerritoryDescription
FROM Northwind.Employees
JOIN Northwind.EmployeeTerritories
ON Employees.EmployeeID = EmployeeTerritories.EmployeeID
JOIN Northwind.Territories
ON EmployeeTerritories.TerritoryID = Territories.TerritoryID
JOIN Northwind.Region
ON Territories.RegionID = Region.RegionID
WHERE RegionDescription = 'Western'

/*8 ������������� Outer JOIN*/

/*8.1 ��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� ���������� �� ������� �� ������� Orders.
������� �� ��������, ��� � ��������� ���������� ��� �������, �� ��� ����� ������ ���� �������� � ����������� �������.
����������� ���������� ������� �� ����������� ���������� �������.*/

SELECT ContactName, COUNT(OrderID) AS 'Amount'
FROM Northwind.Customers
LEFT JOIN Northwind.Orders
ON Customers.CustomerID = Orders.CustomerID
GROUP BY ContactName
ORDER BY Amount

/*9 ������������� �����������*/

/*9.1 ��������� ���� ����������� ������� CompanyName � ������� Suppliers, � ������� ��� ���� �� ������ �������� �� ������ (UnitsInStock � ������� Products ����� 0).
������������ ��������� SELECT ��� ����� ������� � �������������� ��������� IN.
����� �� ������������ ������ ��������� IN �������� '=' ?*/

SELECT CompanyName
FROM Northwind.Suppliers
JOIN Northwind.Products
ON Suppliers.SupplierID = Products.SupplierID
WHERE Products.SupplierID IN 
	(SELECT SupplierID 
	 FROM Northwind.Suppliers
	 WHERE UnitsInStock = 0)
--�������� '=' ������ ������������, �.�. ��������� ������ ���������� ����� ������ ��������.

/*10 ��������������� ������*/

/*10.1 ��������� ���� ���������, ������� ����� ����� 150 �������.
������������ ��������� ��������������� SELECT.*/

SELECT LastName + ' ' + FirstName AS 'Seller'
FROM Northwind.Employees
WHERE EmployeeID IN
	(SELECT EmployeeID
	 FROM Northwind.Orders
	 GROUP BY EmployeeID
	 HAVING COUNT(OrderID) > 150)

/*11 ������������� EXISTS*/

/*11.1 ��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ (��������� �� ������� Orders).
������������ ��������������� SELECT � �������� EXISTS.*/

SELECT CompanyName
FROM Northwind.Customers
WHERE NOT EXISTS
	(SELECT CustomerID 
	 FROM Northwind.Orders
	 WHERE Customers.CustomerID = Orders.CustomerID)

/*12 ������������� ��������� �������*/

/*12.1 ��� ������������ ����������� ��������� Employees ��������� �� ������� Employees ������ ������ ��� ���� ��������, � ������� ���������� ������� Employees (������� LastName ) �� ���� �������.
���������� ������ ������ ���� ������������ �� �����������.*/

SELECT DISTINCT SUBSTRING(LastName, 1, 1) AS 'Alphabetic list'
FROM Northwind.Employees 
ORDER BY [Alphabetic list]

/*13 ���������� ������� � ��������*/

/*13.1 �������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� ������������ ���.
� ����������� �� ����� ���� ��������� ������� ������ ��������, ������ ���� ������ ���� � ����� �������.
� ����������� ������� ������ ���� �������� ��������� �������: ������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), ����� ������ � ��� ���������.
� ������� ���� ��������� Discount ��� ������� �������.
��������� ���������� ���, �� ������� ���� ������� �����, � ���������� ������������ �������.
���������� ������� ������ ���� ����������� �� �������� ����� ������.
��������� ������ ���� ����������� � �������������� ��������� SELECT � ��� ������������� ��������.
�������� ������� �������������� GreatestOrders.
���������� ������������������ ������������� ���� ��������.
����� ������ ������������ ������� �������� � ������� Query.sql ���� �������� ��������� �������������� ����������� ������ ��� ������������ ������������ ������ ��������� GreatestOrders.
����������� ������ ������ �������� � ������� ��� ��������� � ������������ ������ �������� ���� ��� ������������� �������� ��� ���� ��� ������� �� ������������ ��������� ��� � ����������� ��������� �������: ��� ��������, ����� ������, ����� ������.
����������� ������ �� ������ ��������� ������, ���������� � ���������, - �� ������ ��������� ������ ��, ��� ������� � ����������� �� ����.*/

DECLARE @Year INT
SET @Year = 1998
EXEC GreatestOrders 1998

--����������� ������ ��� EmployeeID = 2
SELECT LastName + ' ' + FirstName AS 'Seller', Orders.OrderID,  CONVERT(MONEY, ROUND((UnitPrice - UnitPrice * Discount) * Quantity, 2), 1) AS 'Totals'
	FROM Northwind.Employees
	JOIN Northwind.Orders
	ON Employees.EmployeeID = Orders.EmployeeID
	JOIN Northwind.[Order Details]
	ON Orders.OrderID = [Order Details].OrderID
	WHERE YEAR(OrderDate) = @Year AND Employees.EmployeeID = 2
	ORDER BY Totals DESC

/*13.2 �������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� ����� �������� � ���� (������� ����� OrderDate � ShippedDate).
� ����������� ������ ���� ���������� ������, ���� ������� ��������� ���������� �������� ��� ��� �������������� ������.
�������� �� ��������� ��� ������������� ����� 35 ����.
�������� ��������� ShippedOrdersDiff.
��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate, ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay (���������� � ��������� ��������).
���������� ������������������ ������������� ���� ���������.*/

EXEC ShippedOrdersDiff 20

/*13.3 �������� ���������, ������� ����������� ���� ����������� ��������� ��������, ��� ����������������, ��� � ����������� ��� �����������.
� �������� �������� ��������� ������� ������������ EmployeeID.
���������� ����������� ����� ����������� � ��������� �� � ������ (������������ �������� PRINT) �������� �������� ����������.
��������, ��� �������� ���� ����� ����������� ����� ������ ���� ��������.
�������� ��������� SubordinationInfo.
� �������� ��������� ��� ������� ���� ������ ���� ������������ ������, ����������� � Books Online � ��������������� Microsoft ��� ������� ��������� ���� �����.
������������������ ������������� ���������.*/

EXEC SubordinationInfo 7

/*13.4  �������� �������, ������� ����������, ���� �� � �������� �����������.
���������� ��� ������ BIT.
� �������� �������� ��������� ������� ������������ EmployeeID.
�������� ������� IsBoss.
������������������ ������������� ������� ��� ���� ��������� �� ������� Employees.*/

SELECT LastName + ' ' + FirstName AS 'Seller',
	CASE
	   WHEN dbo.IsBoss(EmployeeID) = 1 THEN 'Yes'
	   ELSE 'No'
	END AS 'IsBoss'
FROM Northwind.Employees