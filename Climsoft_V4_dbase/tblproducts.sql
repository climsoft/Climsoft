CREATE DATABASE  IF NOT EXISTS `mysql_climsoft_db_v4` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `mysql_climsoft_db_v4`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: mysql_climsoft_db_v4
-- ------------------------------------------------------
-- Server version	5.0.51b-community-nt

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Not dumping tablespaces as no INFORMATION_SCHEMA.FILES table on this server
--

--
-- Table structure for table `tblproducts`
--

DROP TABLE IF EXISTS `tblproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblproducts` (
  `productId` varchar(10) NOT NULL,
  `productName` varchar(50) default NULL,
  `prDetails` varchar(50) default NULL,
  `prCategory` varchar(25) default NULL,
  PRIMARY KEY  (`productId`),
  KEY `productId` (`productId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblproducts`
--

LOCK TABLES `tblproducts` WRITE;
/*!40000 ALTER TABLE `tblproducts` DISABLE KEYS */;
INSERT INTO `tblproducts` VALUES ('01','Inventory','Details of Data Records','Inventory'),('02','Hourly','Summaries of Hourly Observations','Data'),('03','Daily','Summaries of Daily Observation','Data'),('04','Pentad','5 Days Summeries','Data'),('05','Dekadal','10 Days Summaries','Data'),('06','Monthly','Monthly Summaries','Data'),('07','Annual','Annual Summaries','Data'),('08','Means','Long Term Means','Data'),('09','Extremes','Long Term','Data'),('10','WindRose','Wind Rose Picture','Graphics'),('11','TimeSeries','Time Series Chart','Graphics'),('12','Histograms','Histogram Chart','Graphics'),('13','Instat','Daily Data for Instat','Special Products'),('14','Rclimdex','Daily Data for Rclimdex','Special Products'),('15','CPT','Data for CPT','Special Products'),('16','SynopticFeature','Synoptic Features','Special Products'),('17','ACMADBulletin','ACMAD Dekadal Bulletin','Summaries'),('18','CLIMAT','CLIMAT Messages','Messages');
/*!40000 ALTER TABLE `tblproducts` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- There was original a conflict in this file, and we chose the most recent commit
-- Dump completed on 2015-05-08  0:04:44
-- Dump completed on 2015-05-06  2:37:18

