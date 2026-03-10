Use procedureDb;

CREATE TRIGGER trg_OrderStatusvalidation
ON orders
AFTER UPDATE
AS
BEGIN
BEGIN TRY
IF EXISTS(
SELECT 1
FROM inserted
WHERE order_status = 4
AND shipped_date IS NULL
)
BEGIN
RAISERROR ('Cannot mark order as Completed without shipped_date',16,1);
ROLLBACK TRANSACTION;
END
END TRY
BEGIN CATCH
PRINT 'Error occurred while updating order status';
ROLLBACK TRANSACTION;
END CATCH
END;

---INVALID UPDATE---
UPDATE orders
SET order_status = 4
WHERE order_id = 101;

---VALID UPDATE---
UPDATE orders
SET shipped_date = '2026-03-08',
order_status = 4
WHERE order_id = 101;

SELECT * FROM orders;

ALTER TABLE orders
ADD shipped_date DATE,
order_status INT;

