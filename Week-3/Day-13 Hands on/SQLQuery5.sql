
CREATE  DATABASE StocksDb

Use StocksDb

CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(50)
);

INSERT INTO products VALUES
(1,'Laptop'),
(2,'Mobile'),
(3,'Headphones'),
(4,'Keyboard'),
(5,'Mouse');

CREATE TABLE stores
(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);

INSERT INTO stores VALUES
(1,'Hyderabad'),
(2,'Chennai'),
(3,'vizag');

CREATE TABLE stocks
(
store_id INT,
product_id INT,
quantity INT,
FOREIGN KEY (product_id)REFERENCES products(product_id),
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO stocks VALUES
(1,1,5),
(2,2,100),
(2,3,60),
(1,4,80),
(3,5,70);

CREATE TABLE order_items
(
order_item_id INT PRIMARY KEY,
product_id INT,
quantity INT,
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO order_items VALUES
(1,1,5),
(2,2,10),
(3,1,3),
(4,3,7),
(5,5,4);

SELECT
p.product_name,
st.quantity AS avaliable_stock,
SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s 
on st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name,st.quantity
ORDER BY p.product_name;




