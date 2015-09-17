# Stock-Manage

To use the program, just open with Visual Studio or any other comparable program.
This program does require a MySql backend, this can be set up with these properties

```SQL
CREATE DATABASE IF NOT EXISTS `db_inventorymanagement` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `db_inventorymanagement`;

CREATE TABLE IF NOT EXISTS `tbl_orders` (
  `PK_ID` int(11) NOT NULL AUTO_INCREMENT,
  `FK_OrderId` int(11) NOT NULL,
  `FK_ProductId` int(11) NOT NULL,
  `Product_Quantity` int(11) NOT NULL,
  `Total_Cost` float NOT NULL,
  PRIMARY KEY(`PK_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `tbl_products` (
  `PK_ProductId` int(11) NOT NULL AUTO_INCREMENT,
  `Barcode` text,
  `Name` text,
  `Description` text,
  `Location` text,
  `Quantity` int(11) DEFAULT NULL,
  `Purchase_Price` float DEFAULT NULL,
  `Units_In_Case` int(11) NOT NULL,
  `FK_SupplierId` int(11) NOT NULL,
  `Critical_Level` int(11) DEFAULT NULL,
  `Nominal_Level` int(11) DEFAULT NULL,
  PRIMARY KEY(`PK_ProductId`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `tbl_purchase_orders` (
  `PK_OrderId` int(11) NOT NULL AUTO_INCREMENT,
  `FK_UserId` int(11) NOT NULL,
  `FK_SupplierId` int(11) NOT NULL,
  `DateOrdered` datetime NOT NULL,
  PRIMARY KEY(`PK_OrderId`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `tbl_suppliers` (
  `PK_SupplierId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `AddressLine1` text,
  `AddressLine2` text,
  `AddressLine3` text,
  `City` text,
  `Postcode` text,
  `Contact` text,
  `Telephone` text,
  `Type` text,
  PRIMARY KEY(`PK_SupplierId`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `tbl_users` (
  `PK_UserId` int(11) NOT NULL AUTO_INCREMENT,
  `System_Role` text NOT NULL,
  `First_Name` text NOT NULL,
  `Second_Name` text NOT NULL,
  `Password_Hash` text,
  `Salt` char(8) CHARACTER SET utf16 COLLATE utf16_bin DEFAULT NULL,
  PRIMARY KEY(`PK_UserId`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

ALTER TABLE `tbl_orders` ADD KEY `FK_OrderId` (`FK_OrderId`), ADD KEY `FK_ProductId` (`FK_ProductId`);
ALTER TABLE `tbl_products` ADD KEY `FK_SupplierId` (`FK_SupplierId`);
ALTER TABLE `tbl_purchase_orders` ADD KEY `FK_UserId` (`FK_UserId`), ADD KEY `FK_SupplierId` (`FK_SupplierId`);
```
