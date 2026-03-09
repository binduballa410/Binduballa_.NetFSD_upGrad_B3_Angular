
Use EcommDb;
GO
CREATE VIEW vw_product_summary
AS 
SELECT
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b ON p.brand_id=
b.brand_id
JOIN categories c ON
p.category_id = c.category_id;

SELECT *FROM vw_product_summary;

----------------------------------------------
Use EcommDb;
GO

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
customer_id INT,
store_id INT
);

INSERT INTO orders VALUES
(1,1,1),
(2,2,2),
(3,3,1);

CREATE VIEW vw_order_details 
AS
SELECT
o.order_id,
CONCAT(c.first_name, ' ',c.last_name) 
AS customer_name,
s.store_name
FROM orders o
JOIN customers c ON
o.customer_id = c.customer_id
JOIN stores s 
ON o.store_id = s.store_id;

SELECT * FROM vw_order_details;

-----------------------------------------------------
CREATE INDEX idx_products_brand_id
ON products(brand_id);
CREATE INDEX idx_products_category_id
ON products(category_id);
CREATE INDEX idx_orders_customer_id
ON orders(customer_id);
CREATE INDEX idx_orders_store_id
ON orders(store_id);





