--- Scalar Function
CREATE FUNCTION dbo.GetNetSale(
	@quantity INT,	
	@unitprice dec(10,2),
	@discount dec(10,2)
)
RETURNS dec(10,2)--10 is the total number of digits, 2 are after the decimal
AS 
BEGIN
	RETURN @quantity*@unitprice*(1-@discount);
END

-- call function (dbo means DataBase Owner)
SELECT dbo.GetNetSale(100,100,0.9) AS netSale;

------------------------------------------------------------
-- Chinook Db
--- Table Valued Function
GO
CREATE FUNCTION dbo.GetItPeeps(@title NVARCHAR(20))
RETURNS TABLE
AS 
	RETURN (SELECT * FROM dbo.Employee WHERE Title = @title);
GO

DROP Function GetItPeeps;
SELECT * FROM dbo.GetItPeeps('IT Staff');

-- call function (dbo means DataBase Owner)
SELECT dbo.GetNetSale(100,100,0.9) AS netSale;

---------------------------------------------------
--create a Table-Valued Function
CREATE FUNCTION udfProductInYear (@model_year INT)
RETURNS TABLE
AS
RETURN
    SELECT 
        product_name,
        model_year,
        list_price
    FROM
        production.products
    WHERE
        model_year = @model_year;

--alter a TVF
ALTER FUNCTION udfProductInYear (
    @start_year INT,
    @end_year INT
)
RETURNS TABLE
AS
RETURN
    SELECT 
        product_name,
        model_year,
        list_price
    FROM
        production.products
    WHERE
        model_year BETWEEN @start_year AND @end_year
