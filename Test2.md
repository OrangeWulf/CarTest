Напишите SQL запрос в котором будет создание двух таблиц: Customers, которая содержит в себе столбцы и таблицу Orders с столбцами

```
CREATE TABLE `Customers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(25) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `Customers` VALUES (1,'Max'),(2,'Pavel'),(3,'Ivan'),(4,'Leonid');

CREATE TABLE `Orders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CustomerId` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `Orders` VALUES (1,2),(2,4);
```

Выведите имена всех покупателей не совершивших ни одной покупки в формате

```
SELECT Name FROM Customers c WHERE c.Id NOT IN (SELECT CustomerId FROM Orders)
```
