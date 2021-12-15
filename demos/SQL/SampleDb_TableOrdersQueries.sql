--SELECT * from Addresses;
--SELECT * from Customers;
--SELECT * from Orders;

SELECT CustomerID, totalAmount FROM Orders
WHERE totalAmount < 100;

SELECT CustomerID,totalAmount FROM Orders
WHERE totalAmount > 0
ORDER BY OrderDate DESC;

SELECT FirstName, LastName FROM Customers
WHERE FirstName LIKE '%bb%';

SELECT SUM(totalAmount) AS TotalSales
FROM Orders;

SELECT SUM(totalAmount), CUstomerID
FROM Orders
WHERE CustomerID >= 2
GROUP BY CustomerID;

SELECT FirstName, CustomerId
FROM Customers 
WHERE FirstName NOT IN('Matt','Libby');

SELECT CustomerID, FirstName, LastName
FROM Customers
WHERE LastName NOT BETWEEN 'A' AND 'P';