select * from Customers;

CREATE VIEW MyNewView
AS
SELECT * FROM Customers 
WHERE LastName = 'Moore';

--once a view is created, you have to create or alter it.
CREATE OR ALTER VIEW MyNewView
AS
SELECT * FROM Customers 
WHERE FirstName = 'Libby' OR LastName = 'Smith';

select * from MyNewView;
drop view MyNewView;
------------------------------

--create a view with a join.
