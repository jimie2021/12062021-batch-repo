--1
Select FirstName, LastName, CustomerId, Country
FROM Customer
Where Country = 'USA';

--2
Select * 
FROM Customer
Where Country = 'Brazil';

--3
SELECT *
FROM Employee
WHERE Title LIKE '%Sales%Agent%'
--ORDER BY LastName;

--4
SELECT BillingCountry
FROM Invoice
GROUP BY BillingCountry;
-- alternate
SELECT CustomerId, BillingCountry FROM Invoice
ORDER BY BillingCity DESC;
-- you can order the results by columns that aren't displayed in the results.

--5
SELECT COUNT(*) AS 'countingcountingface', SUM(Total) AS 'Sum of Total column' FROM Invoice
WHERE InvoiceDate LIKE '%2009%';

--extra
SELECT COUNT(*) AS 'Orders in the Year', SUM(Total) AS 'Total for the year' 
FROM Invoice 
GROUP BY Year(InvoiceDate);

--6
SELECT COUNT(InvoiceLineId) AS 'numinvoices;' 
FROM InvoiceLine
WHERE InvoiceId = 37;

--7
--later....

--8
SELECT SUM(Total) AS 'Totals by Country', BillingCountry
FROM Invoice
GROUP BY BillingCountry
ORDER BY SUM(Total) DESC;







