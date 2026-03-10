Use procedureDb;

ALTER TABLE orders
ADD order_status INT;

BEGIN TRY 
BEGIN TRANSACTION;
SAVE TRANSACTION BeforeStockRestore;

UPDATE p
SET p.stock_quantity  = p.stock_quantity + oi.quantity
FROM products p
JOIN order_items oi
ON p.product_id = oi.product_id
WHERE oi.order_id = (101);

UPDATE orders
SET order_status = 3
WHERE order_id = (101);

COMMIT TRANSACTION;
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
BeforeStockRestore;
print('Error occurred Transaction rolled back to savepoint.');
END CATCH;

SELECT * FROM orders;
SELECT * FROM products;
SELECT * FROM order_items;
