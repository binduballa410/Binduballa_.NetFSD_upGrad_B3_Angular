
Use procedureDb;

SELECT * FROM orders;

ALTER TABLE orders
ADD order_status INT;

UPDATE orders
SET shipped_date = '2026-03-09',
order_status = 4
WHERE order_id IN (102,104);

UPDATE orders
SET shipped_date = '2026-03-25',
order_status = 2
WHERE order_id IN (103,105);

BEGIN TRY
BEGIN TRANSACTION

CREATE TABLE #StoreRevenue
(
store_id INT,
order_id INT,
revenue DECIMAL(10,2)
)
DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @REVENUE DECIMAL(10,2)

DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO
@order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN
SELECT @revenue = SUM(quantity * list_price * (1 - discount))
FROM order_items 
WHERE order_id = @order_id

INSERT INTO #StoreRevenue VALUES(@store_id, @order_id, @revenue)

FETCH NEXT FROM order_cursor INTO
@order_id, @store_id

END
CLOSE order_cursor
DEALLOCATE order_cursor

SELECT store_id,
SUM(revenue) AS total_revenue
FROM #StoreRevenue
GROUP BY store_id

COMMIT TRANSACTION
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Error occurred'
END CATCH




