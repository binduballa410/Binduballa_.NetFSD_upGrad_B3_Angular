

Use AutoDb

---1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.---

SELECT *
INTO archived_orders
FROM ords
WHERE 1=0;

INSERT INTO archived_orders
SELECT * 
FROM ords
WHERE order_date < DATEADD(YEAR, -1,GETDATE());

--2. Delete orders where order_status = 3 (Rejected) and older than 1 year.--
DELETE FROM ords
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1,GETDATE());

---3. Use nested query to identify customers whose all orders are completed.---
SELECT order_id
FROM ords o
WHERE NOT EXISTS (
SELECT 1
FROM ords
WHERE order_id = o.order_id
AND order_status <>'Completed'
);


--4. Display order processing delay (DATEDIFF between shipped_date and order_date)---
ALTER TABLE orders
ADD order_date DATE,
shipped_date DATE;

SELECT * FROM orders;


UPDATE orders
SET order_date = '2024-01-10',
shipped_date = '2024-01-15'
WHERE order_id = 101;

UPDATE orders
SET order_date = '2024-01-1',
shipped_date = '2024-01-05'
WHERE order_id = 102;

UPDATE orders
SET order_date = '2024-01-11',
shipped_date = '2024-01-14'
WHERE order_id = 103;

UPDATE orders
SET order_date = '2024-01-20',
shipped_date = '2024-01-25'
WHERE order_id = 104;

SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY,shipped_date, order_date) AS
processing_delay
FROM orders;

---5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date---
ALTER TABLE orders
ADD requried_date DATE;

UPDATE orders
SET requried_date = '2024-01-26'
WHERE order_id = 101;
UPDATE orders
SET requried_date = '2024-01-28'
WHERE order_id = 102;
UPDATE orders
SET requried_date = '2024-01-10'
WHERE order_id = 103;
UPDATE orders
SET requried_date = '2024-01-05'
WHERE order_id = 104;

SELECT
order_id,
order_date,
shipped_date,
requried_date,
CASE WHEN shipped_date > requried_date
THEN 'Delayed'
ELSE 'On Time'
END AS delivary_status
FROM orders;

