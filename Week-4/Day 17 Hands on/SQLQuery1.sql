Use procedureDb;

CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
stock_quantity INT
);
INSERT INTO products VALUES
(1,'Car Battery',50),
(2,'Engine Oil',100),
(3,'Brake Pads',30);

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
order_date DATE
);

CREATE TABLE order_items
(
order_item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
FOREIGN KEY (order_id)REFERENCES orders(order_id),
FOREIGN KEY (product_id) REFERENCES products(product_id)
);


CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS 
BEGIN
IF EXISTS (
SELECT 1
FROM products p
JOIN inserted i ON p.product_id = i.product_id
WHERE p.stock_quantity < i.quantity
)
BEGIN 
RAISERROR('Insuffient stock',16,1);
ROLLBACK TRANSACTION;
RETURN;
END
UPDATE p
SET p.stock_quantity = 
p.stock_quantity - i.quantity
FROM products p
JOIN inserted i
ON p.product_id = i.product_id;
END;

BEGIN TRANSACTION
INSERT INTO orders VALUES (103,GETDATE());
INSERT INTO order_items VALUES(3,103,1,5);
COMMIT;

BEGIN TRANSACTION
INSERT INTO orders VALUES(102,GETDATE());
INSERT INTO order_items VALUES(2,102,3,100);
COMMIT;

SELECT * FROM products;


SELECT * FROM order_items;




