CREATE TABLE products ( 
    id INT NOT NULL PRIMARY KEY IDENTITY,
    productname NVARCHAR (100) NOT NULL,
    enterprisename NVARCHAR (100) NOT NULL,
    email NVARCHAR (100) NOT NULL,
    phone NVARCHAR (100) NOT NULL,
    amont INT NOT NULL,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO products(productname, enterprisename, email, phone, amont)
VALUES
( 'PS4', 'Playstation', 'sony@sony.com', '(012)3456-7890', 10 ),
( 'Xbox Series X', 'Microsoft', 'microsoft@microsoft.com', '(012)3456-7890', 10 ),
( 'Switch Oled', 'Nintendo', 'nintendo@nintendo.com', '(012)3456-7890', 10 ),
( 'PS5', 'Playstation', 'sony@sony.com', '(012)3456-7890', 10 ),
( 'Xbox Series S', 'Microsoft', 'microsoft@microsoft.com', '(012)3456-7890', 10 ),
( 'Switch Lite', 'Nintendo', 'nintendo@nintendo.com', '(012)3456-7890', 10 );
