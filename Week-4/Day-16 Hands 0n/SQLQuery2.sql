
Use ProcedureDb;

CREATE TABLE stocks 
(
store_id INT,
product_id INT,
quantity INT,
PRIMARY KEY (store_id,product_id)
);
INSERT INTO stocks VALUES
(1,101,50),
(1,102,40),
(2,101,30);

CREATE TRIGGER trg_UpdateStocks 
ON order_items
AFTER INSERT
AS
BEGIN
BEGIN TRY
IF EXISTS (
SELECT 1
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id
WHERE s.quantity < i.quantity
)
BEGIN
RAISERROR('Stock is insufficient', 16,1);
ROLLBACK TRANSACTION;
RETURN;
END

UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id;
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;
THROW;
END CATCH
END;

SELECT * FROM order_items;

INSERT INTO order_items(order_item_id,order_id,product_id,quantity)
VALUES(7,105,5,2);