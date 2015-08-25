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
-- Table structure for table `data_forms`
--

DROP TABLE IF EXISTS `data_forms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `data_forms` (
  `id` bigint(20) NOT NULL default '0',
  `order` bigint(20) default '0',
  `table_name` varchar(255) default NULL,
  `form_name` varchar(250) default NULL,
  `description` text,
  `selected` tinyint(4) default NULL,
  `val_start_position` bigint(20) default '0',
  `val_end_position` bigint(20) default '0',
  `elem_code_location` varchar(255) default NULL,
  `sequencer` varchar(50) default NULL,
  PRIMARY KEY  (`id`),
  UNIQUE KEY `identification` (`form_name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `data_forms`
--

LOCK TABLES `data_forms` WRITE;
/*!40000 ALTER TABLE `data_forms` DISABLE KEYS */;
INSERT INTO `data_forms` VALUES (61000,3,'form_daily1','form_daily1','Data for some elements for one day',1,5,19,'Horizontal','seq_month_day_form_daily1'),(61001,2,'form_daily2','form_daily2','Data for one element for the whole month',1,5,36,'Vertical','seq_element_form_daily2'),(61002,1,'form_hourly','form_hourly','Data for one element for 24 hours',1,5,28,'Vertical','seq_form_hourly'),(61003,4,'form_synoptic1','form_synoptic1','Synoptic data for one hour for one element for the whole month',0,5,35,'Vertical','seq_synoptime_element'),(61004,5,'form_synoptic2','form_synoptic2','Synoptic data for many elements for one  observation time',0,5,37,'Horizontal','seq_month_day_synoptime'),(61005,6,'form_synoptic3','form_synoptic3','Synoptic data for all hours for one element',1,5,12,'Vertical','seq_form_synopt3'),(61006,7,'form_upperair1','form_upperair1','Upper air data for several elements for one day',1,6,17,'Vertical','seq_month_day_synoptime_level'),(61007,8,'form_upperair2','form_upperair2','Upper air data for one element and one level for the whole month',0,6,36,'Vertical','seq_level_upperair_element'),(61043,19,'form_synoptic2_TDCF','form_synoptic2_TDCF','Synoptic data for many elements for one  observation time - TDCF',1,5,52,'Horizontal','seq_month_day_synoptime'),(61139,20,'form_bmet26','form_bmet26','Botswana Hourly Data for several elements for 24 hours(BMET26)',0,5,34,'Horizontal','seq_month_day_time'),(63021,15,'form_hourlywind','form_hourlywind','Hourly wind data',0,4,27,'Horizontal','seq_month_day_form_hourlywind'),(63027,14,'form_agro1','form_agro1','Kenya Agromet data',0,4,37,'Horizontal','seq_month_day'),(63028,16,'form_temp0','form_temp0','Uganda temperature data',0,4,11,'Horizontal','seq_month_day'),(63029,17,'form_synoptic2_caribbean','form_synoptic2_caribbean','Caribbean synoptic data for many elements for one  observation time',0,5,37,'Horizontal','seq_month_day_hour'),(63030,18,'form_monthly','form_monthly','Monthly data',0,3,14,'Vertical','seq_year'),(63031,19,'form_climat','form_climat','Data for monthly CLIMAT report',0,4,16,'Horizontal','seq_month_day');
/*!40000 ALTER TABLE `data_forms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-13 16:36:00
