CREATE DATABASE  IF NOT EXISTS `mysql_climsoft_db_v4` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mysql_climsoft_db_v4`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: mysql_climsoft_db_v4
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
-- Table structure for table `ccitt`
--

DROP TABLE IF EXISTS `ccitt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ccitt` (
  `Characters` varchar(255) default NULL,
  `MostSignificant` int(11) default NULL,
  `LeastSignificant` int(11) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ccitt`
--

LOCK TABLES `ccitt` WRITE;
/*!40000 ALTER TABLE `ccitt` DISABLE KEYS */;
INSERT INTO `ccitt` VALUES ('NUL',0,0),('DLE',1,0),('SP',2,0),('0',3,0),('@',4,0),('P',5,0),('`',6,0),('p',7,0),('SOH',0,1),('DC1',1,1),('!',2,1),('1',3,1),('A',4,1),('Q',5,1),('a',6,1),('q',7,1),('STX',0,2),('DC2',1,2),('“',2,2),('2',3,2),('B',4,2),('R',5,2),('b',6,2),('r',7,2),('ETX',0,3),('DC3',1,3),('#',2,3),('3',3,3),('C',4,3),('S',5,3),('c',6,3),('s',7,3),('EOT',0,4),('DC4',1,4),('$',2,4),('4',3,4),('D',4,4),('T',5,4),('d',6,4),('t',7,4),('ENQ',0,5),('NAK',1,5),('%',2,5),('5',3,5),('E',4,5),('U',5,5),('e',6,5),('u',7,5),('ACK',0,6),('SYN',1,6),('&',2,6),('6',3,6),('F',4,6),('V',5,6),('f',6,6),('v',7,6),('BEL',0,7),('ETB',1,7),('‘',2,7),('7',3,7),('G',4,7),('W',5,7),('g',6,7),('w',7,7),('BS',0,8),('CAN',1,8),('(',2,8),('8',3,8),('H',4,8),('X',5,8),('h',6,8),('x',7,8),('HT',0,9),('EM',1,9),(')',2,9),('9',3,9),('I',4,9),('Y',5,9),('i',6,9),('y',7,9),('LF',0,10),('SUB',1,10),('*',2,10),(':',3,10),('J',4,10),('Z',5,10),('j',6,10),('z',7,10),('VT',0,11),('ESC',1,11),('+',2,11),(';',3,11),('K',4,11),('[',5,11),('k',6,11),('{',7,11),('FF',0,12),('FS',1,12),(',',2,12),('<',3,12),('L',4,12),('\\',5,12),('l',6,12),('¦',7,12),('CR',0,13),('GS',1,13),('-',2,13),('=',3,13),('M',4,13),(']',5,13),('m',6,13),('}',7,13),('SO',0,14),('RS',1,14),('.',2,14),('>',3,14),('N',4,14),('^',5,14),('n',6,14),('~',7,14),('SI',0,15),('US',1,15),('/',2,15),('?',3,15),('O',4,15),('_',5,15),('o',6,15),('DEL',7,15);
/*!40000 ALTER TABLE `ccitt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_process_parameters`
--

DROP TABLE IF EXISTS `aws_process_parameters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_process_parameters` (
  `RetrieveInterval` int(11) NOT NULL default '60',
  `HourOffset` int(11) NOT NULL default '10',
  `RetrievePeriod` int(11) NOT NULL default '1',
  `RetrieveTimeout` int(11) NOT NULL default '20',
  `DelinputFile` tinyint(4) NOT NULL default '1',
  PRIMARY KEY  (`RetrieveInterval`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_process_parameters`
--

LOCK TABLES `aws_process_parameters` WRITE;
/*!40000 ALTER TABLE `aws_process_parameters` DISABLE KEYS */;
INSERT INTO `aws_process_parameters` VALUES (60,10,1,10,0);
/*!40000 ALTER TABLE `aws_process_parameters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_toa5_mg2`
--

DROP TABLE IF EXISTS `aws_toa5_mg2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_toa5_mg2` (
  `Cols` bigint(20) NOT NULL,
  `Element_Abbreviation` varchar(50) default NULL,
  `Element_Name` varchar(50) default NULL,
  `Element_Details` varchar(50) default NULL,
  `Climsoft_Element` varchar(6) default NULL,
  `Bufr_Element` varchar(6) default NULL,
  `unit` varchar(15) default NULL,
  `lower_limit` varchar(50) default NULL,
  `upper_limit` varchar(50) default NULL,
  `obsv` varchar(50) default NULL,
  PRIMARY KEY  (`Cols`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_toa5_mg2`
--

LOCK TABLES `aws_toa5_mg2` WRITE;
/*!40000 ALTER TABLE `aws_toa5_mg2` DISABLE KEYS */;
INSERT INTO `aws_toa5_mg2` VALUES (1,'Date/time','Date/time','Date and time',NULL,NULL,NULL,NULL,NULL,'10/11/2015 00:50'),(2,'RECORD','RECORD','Record number',NULL,NULL,NULL,NULL,NULL,'348577'),(3,'AirTemp_1m','AirTemp_1m','Air Temperature at 1 metre','881','012103','\'C',NULL,NULL,'20.29727'),(4,'AirTemp_1m_Err','AirTemp_1m_Err','Air Temperature at 1 metre error',NULL,NULL,NULL,NULL,NULL,'0'),(5,'TEMP_MAX_24HR','TEMP_MAX_24HR','TEMP MAX for 24HR','882','012111','\'C',NULL,NULL,'28.84937'),(6,'TEMP_MAX_24HR_AT','TEMP_MAX_24HR_AT','TEMP MAX for 24HR Time',NULL,NULL,NULL,NULL,NULL,'30/11/2014 10:12'),(7,'TEMP_MAX_24HR_Err','TEMP_MAX_24HR_Err','TEMP MAX for 24HR Error',NULL,NULL,NULL,NULL,NULL,'0'),(8,'TEMP_MIN_24HR','TEMP_MIN_24HR','TEMP MIN for 24HR','883','012112','\'C',NULL,NULL,'17.79975'),(9,'TEMP_MIN_24HR_AT','TEMP_MIN_24HR_AT','TEMP MIN for 24HR Time',NULL,NULL,NULL,NULL,NULL,'30/11/2014 01:16'),(10,'TEMP_MIN_24HR_Err','TEMP_MIN_24HR_Err','TEMP MIN for 24HR Error',NULL,NULL,NULL,NULL,NULL,'0'),(11,'DB_1m','DB_1m','Dry bulb, 1 minute average',NULL,NULL,NULL,NULL,NULL,'20.29727'),(12,'DB_1m_Err','DB_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(13,'DB2_1m','DB2_1m','DB2_1m',NULL,NULL,NULL,NULL,NULL,NULL),(14,'DB2_1m_Err','DB2_1m_Err','DB2_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(15,'WB_1m','WB_1m','WB_1m',NULL,NULL,NULL,NULL,NULL,NULL),(16,'WB_1m_Err','WB_1m_Err','WB_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(17,'GRA_1m','GRA_1m','GRA_1m',NULL,NULL,NULL,NULL,NULL,NULL),(18,'GRA_1m_Err','GRA_1m_Err','GRA_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(19,'CON_1m','CON_1m','CON_1m',NULL,NULL,NULL,NULL,NULL,NULL),(20,'CON_1m_Err','CON_1m_Err','CON_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(21,'S10_1m','S10_1m','S10_1m',NULL,'012130','\'C',NULL,'',NULL),(22,'S10_1m_Err','S10_1m_Err','S10_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(23,'S30_1m','S30_1m','S30_1m',NULL,NULL,NULL,NULL,NULL,NULL),(24,'S30_1m_Err','S30_1m_Err','S30_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(25,'S100_1m','S100_1m','S100_1m',NULL,NULL,NULL,NULL,NULL,NULL),(26,'S100_1m_Err','S100_1m_Err','S100_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(27,'RH_1m','RH_1m','Relative humidity, 1 min average','893','013003','%',NULL,NULL,'85.4'),(28,'RH_1m_Err','RH_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(29,'RHT_1m','RHT_1m','Temperature from RH sensor',NULL,NULL,NULL,NULL,NULL,'19.9338'),(30,'RHT_1m_Err','RHT_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(31,'DewPT_WB_1m','DewPT_WB_1m','DewPT_WB_1m',NULL,NULL,NULL,NULL,NULL,NULL),(32,'DewPT_WB_1m_Err','DewPT_WB_1m_Err','DewPT_WB_1m_Err',NULL,NULL,NULL,NULL,NULL,'1281'),(33,'DewPT_RH_1m','DewPT_RH_1m','Dew-point (calculated from RH sensor) ','885','012103','°C',NULL,NULL,'17.76225'),(34,'DewPT_RH_1m_Err','DewPT_RH_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(35,'RH_DBWB_1m','RH_DBWB_1m','RH_DBWB_1m',NULL,NULL,NULL,NULL,NULL,NULL),(36,'RH_DBWB_1m_Err','RH_DBWB_1m_Err','RH_DBWB_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(37,'WS_1m','WS_1m','Wind speed, 1 min average',NULL,NULL,'Knots',NULL,NULL,'3.38'),(38,'WS_1m_Err','WS_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(39,'WD_1m','WD_1m','Wind direction, 1 min average',NULL,NULL,'Degree',NULL,NULL,'54.84'),(40,'WD_1m_Err','WD_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(41,'WS_2m','WS_2m','Wind Speed at 2m',NULL,NULL,NULL,NULL,NULL,'3.738'),(42,'WS_2m_Err','WS_2m_Err','Wind Speed at 2m error',NULL,NULL,NULL,NULL,NULL,'0'),(43,'WD_2m','WD_2m','Wind Direction at 2m',NULL,NULL,NULL,NULL,NULL,'60.15'),(44,'WD_2m_Err','WD_2m_Err','Wind Direction at 2m error',NULL,NULL,NULL,NULL,NULL,'0'),(45,'WS_10m','WS_10m','Wind Speed at 10m','897','011002','Knots',NULL,NULL,'4.028'),(46,'WS_10m_Err','WS_10m_Err','Wind Speed at 10m error',NULL,NULL,NULL,NULL,NULL,'0'),(47,'WD_10m','WD_10m','Wind Direction at 10m','895','011001','Degree',NULL,NULL,'56.13'),(48,'WD_10m_Err','WD_10m_Err','Wind Direction at 10m error',NULL,NULL,NULL,NULL,NULL,'0'),(49,'MAXGust','MAXGust','Maximum wind gust speed',NULL,NULL,NULL,NULL,NULL,'4.167'),(50,'MaxGust_TIME','MaxGust_TIME','Time of above',NULL,NULL,NULL,NULL,NULL,'30/11/2014 13:59'),(51,'MaxGust_WD','MaxGust_WD','Maximum wind gust direction',NULL,NULL,'Degree',NULL,NULL,'54.06'),(52,'MAXGust_10m','MAXGust_10m','Maximum wind gust speed at 10m','886','011041','Knots',NULL,NULL,'6.3'),(53,'MaxGust_TIME_10m','MaxGust_TIME_10m','MaxGust TIME at 10m',NULL,NULL,NULL,NULL,NULL,'30/11/2014 13:57'),(54,'MaxGust_WD_10m','MaxGust_WD_10m','MaxGust direction at 10m','887','011043','Knots',NULL,NULL,'60.25'),(55,'MAXGust_60m','MAXGust_60m','MaxGust speed at 60m',NULL,NULL,NULL,NULL,NULL,'15.08'),(56,'MaxGust_TIME_60m','MaxGust_TIME_60m','MaxGust tIME at 60m',NULL,NULL,NULL,NULL,NULL,'30/11/2014 13:22'),(57,'MaxGust_WD_60m','MaxGust_WD_60m','MaxGust direction at 60m',NULL,NULL,NULL,NULL,NULL,'284.9'),(58,'MostBacked_2m','MostBacked_2m','MostBacked at 2m',NULL,NULL,NULL,NULL,NULL,'17.5'),(59,'MostVeered_2m','MostVeered_2m','MostVeered at 2m',NULL,NULL,NULL,NULL,NULL,'110.4'),(60,'MostBacked_10m','MostBacked_10m','Most backed direction over past 10 mins',NULL,NULL,'Degree',NULL,NULL,'14'),(61,'MostVeered_10m','MostVeered_10m','Most veered direction over past 10 mins',NULL,NULL,'Degree',NULL,NULL,'110.4'),(62,'MD_WS_10m','MD_WS_10m','MD WS 10m',NULL,NULL,NULL,NULL,NULL,NULL),(63,'MD_WS_10m','MD_WS_10m','MD WS 10m',NULL,NULL,NULL,NULL,NULL,NULL),(64,'MD_WS_10m_Err','MD_WS_10m_Err','MD WS 10m error',NULL,NULL,NULL,NULL,NULL,'257'),(65,'MD_WD_10m_Err','MD_WD_10m_Err','MD WD 10m error',NULL,NULL,NULL,NULL,NULL,'257'),(66,'MD_MAXGust_10m','MD_MAXGust_10m','MD MAXGust speed at 10m',NULL,NULL,NULL,NULL,NULL,NULL),(67,'MD_MAXGust_WD_10m','MD_MAXGust_WD_10m','MD MAXGust direction at 10m',NULL,NULL,NULL,NULL,NULL,NULL),(68,'MD_MAXGust_TIME_10m','MD_MAXGust_TIME_10m','MD MAXGust tIME at 10m',NULL,NULL,NULL,NULL,NULL,'13/12/1921 20:45'),(69,'MD_MAXGust_10m_Err','MD_MAXGust_10m_Err','MD MAXGust 10m error',NULL,NULL,NULL,NULL,NULL,'257'),(70,'MD_MAXGust_WD_10m_Err','MD_MAXGust_WD_10m_Err','MD MAXGust WD 10m error',NULL,NULL,NULL,NULL,NULL,'257'),(71,'MD_MAXGust_TIME_10m_Err','MD_MAXGust_TIME_10m_Err','MD MAXGust TIME 10m error',NULL,NULL,NULL,NULL,NULL,'257'),(72,'RAIN_mm_1m','RAIN_mm_1m','Total rain over 1 min','892','013011','mm',NULL,NULL,'0'),(73,'RAIN_mm_1m_Err','RAIN_mm_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(74,'RAIN_SINCE_0850','RAIN_SINCE_0850','RAIN SINCE 0850',NULL,NULL,NULL,NULL,NULL,'4'),(75,'RAIN_SINCE_0850_Err','RAIN_SINCE_0850_Err','RAIN SINCE 0850_Err',NULL,NULL,NULL,NULL,NULL,'0'),(76,'SNOW_1m','SNOW_1m','SNOW_1m',NULL,'013013','mm',NULL,NULL,'0'),(77,'SNOW_1m_Err','SNOW_1m_Err','SNOW_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(78,'CLOUD_1st_1m','CLOUD_1st_1m','CLOUD_1st_1m',NULL,NULL,NULL,NULL,NULL,'-2147483648'),(79,'CLOUD_1st_1m_Err','CLOUD_1st_1m_Err','CLOUD_1st_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(80,'CLOUD_2nd_1m','CLOUD_2nd_1m','CLOUD_2nd_1m',NULL,NULL,NULL,NULL,NULL,'-2147483648'),(81,'CLOUD_2nd_1m_Err','CLOUD_2nd_1m_Err','CLOUD_2nd_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(82,'CLOUD_3rd_1m','CLOUD_3rd_1m','CLOUD_3rd_1m',NULL,NULL,NULL,NULL,NULL,'-2147483648'),(83,'CLOUD_3rd_1m_Err','CLOUD_3rd_1m_Err','CLOUD_3rd_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(84,'CLOUD30s_1st_1m','CLOUD30s_1st_1m','CLOUD30s_1st_1m',NULL,NULL,NULL,NULL,NULL,'-2147483648'),(85,'CLOUD30s_1st_1m_Err','CLOUD30s_1st_1m_Err','CLOUD30s_1st_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(86,'CLOUD30s_2nd_1m','CLOUD30s_2nd_1m','CLOUD30s_2nd_1m',NULL,NULL,NULL,NULL,NULL,'-2147483648'),(87,'CLOUD30s_2nd_1m_Err','CLOUD30s_2nd_1m_Err','CLOUD30s_2nd_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(88,'CLOUD30s_3rd_1m','CLOUD30s_3rd_1m','CLOUD30s_3rd_1m',NULL,NULL,NULL,NULL,NULL,'-2147483648'),(89,'CLOUD30s_3rd_1m_Err','CLOUD30s_3rd_1m_Err','CLOUD30s_3rd_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(90,'CLOUD_VertVis_1m','CLOUD_VertVis_1m','CLOUD_VertVis_1m',NULL,NULL,NULL,NULL,NULL,'0'),(91,'VIZ_1m','VIZ_1m','Visibility at 1m',NULL,'020001','m',NULL,NULL,'0'),(92,'VIZ_1m_Err','VIZ_1m_Err','Visibility at 1m error',NULL,NULL,NULL,NULL,NULL,'1024'),(93,'MD_VIZ_10m','MD_VIZ_10m','MD visibility at 10m',NULL,NULL,NULL,NULL,NULL,'0'),(94,'MD_VIZ_10m_Err','MD_VIZ_10m_Err','MD visibility at 10m error',NULL,NULL,NULL,NULL,NULL,'0'),(95,'PW_Code_1m','PW_Code_1m','PW Code 1m',NULL,NULL,NULL,NULL,NULL,'0'),(96,'BP_1m','BP_1m','Barometric Pressure, 1 min average','884','010004','HPa',NULL,NULL,'867.04'),(97,'BP_1m_Err','BP_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(98,'BP_QNH_1m','BP_QNH_1m','QNH, 1 min average','891','007004','HPa',NULL,NULL,'1014.939'),(99,'BP_QNH_1m_Err','BP_QNH_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(100,'BP_QFF_1m','BP_QFF_1m','QFF, 1 min average','890','010051','HPa',NULL,NULL,'1009.688'),(101,'BP_QFF_1m_Err','BP_QFF_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(102,'BP_QFE_1m','BP_QFE_1m','QFE, 1 min average','889',NULL,'HPa',NULL,NULL,'867.2416'),(103,'BP_QFE_1m_Err','BP_QFE_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(104,'BP_QNHinHg_1m','BP_QNHinHg_1m','QNH, inches of mercury, 1 min average',NULL,NULL,NULL,NULL,NULL,'29.96'),(105,'BP_QNHinHg_1m_Err','BP_QNHinHg_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(106,'BP_QFEinHg_1m','BP_QFEinHg_1m','QFE, inches of mercury, 1 min average',NULL,NULL,NULL,NULL,NULL,'25.6'),(107,'BP_QFEinHg_1m_Err','BP_QFEinHg_1m_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(108,'BP_Difference_3hr','BP_Difference_3hr','3-hour pressure change',NULL,'010061','HPa',NULL,NULL,'-0.06750488'),(109,'BP_Characteristic_3hr','BP_Characteristic_3hr','Pressure trend',NULL,'010063','HPa',NULL,NULL,'5'),(110,'WET_1m','WET_1m','WET_1m',NULL,NULL,NULL,NULL,NULL,'0'),(111,'WET_1m_Err','WET_1m_Err','WET_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(112,'RAD_1m','RAD_1m','RAD_1m',NULL,'014028','Joules',NULL,NULL,'0'),(113,'RAD_1m_Err','RAD_1m_Err','RAD_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(114,'SUN_1m','SUN_1m','SUN_1m',NULL,'014031','Joules',NULL,NULL,'0'),(115,'SUN_1m_Err','SUN_1m_Err','SUN_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(116,'SunnySUN_1m','SunnySUN_1m','SunnySUN_1m',NULL,NULL,NULL,NULL,NULL,'0'),(117,'SunnySUN_1m_Err','SunnySUN_1m_Err','SunnySUN_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(118,'SunnyRAD_1m','SunnyRAD_1m','SunnyRAD_1m',NULL,NULL,NULL,NULL,NULL,'0'),(119,'SunnyRAD_1m_Err','SunnyRAD_1m_Err','SunnyRAD_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(120,'TEMP_MAX_24HR_AT_ERR','TEMP_MAX_24HR_AT_ERR','TEMP MAX for 24HR AT error',NULL,NULL,NULL,NULL,NULL,'0'),(121,'TEMP_MIN_24HR_AT_ERR','TEMP_MIN_24HR_AT_ERR','TEMP MIN for 24HR AT error',NULL,NULL,NULL,NULL,NULL,'0'),(122,'BP_Difference_3hr_Err','BP_Difference_3hr_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(123,'BP_Characteristic_3hr_Err','BP_Characteristic_3hr_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(124,'PW_Code_1m_Err','PW_Code_1m_Err','PW_Code_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(125,'PW_Precipitation_1m','PW_Precipitation_1m','PW_Precipitation_1m',NULL,NULL,NULL,NULL,NULL,'0'),(126,'PW_Precipitation_1m_Err','PW_Precipitation_1m_Err','PW_Precipitation_1m_Err',NULL,NULL,NULL,NULL,NULL,'1024'),(127,'MAXGust_Err','MAXGust_Err','Binary Quality Flags',NULL,NULL,NULL,NULL,NULL,'0'),(128,'MAXGust_10m_Err','MAXGust_10m_Err','MAXGust speed at 10m Err',NULL,NULL,NULL,NULL,NULL,'0'),(129,'MAXGust_60m_Err','MAXGust_60m_Err','MAXGust speed at 60m_Err',NULL,NULL,NULL,NULL,NULL,'0'),(130,'MaxGust_TIME_Err','MaxGust_TIME_Err','MaxGust TIME error',NULL,NULL,NULL,NULL,NULL,'0'),(131,'MaxGust_TIME_10m_Err','MaxGust_TIME_10m_Err','MaxGust time at 10m error',NULL,NULL,NULL,NULL,NULL,'0'),(132,'MaxGust_TIME_60m_Err','MaxGust_TIME_60m_Err','MaxGust time at 60m error',NULL,NULL,NULL,NULL,NULL,'0'),(133,'MaxGust_WD_Err','MaxGust_WD_Err','MaxGust WD error',NULL,NULL,NULL,NULL,NULL,'0'),(134,'MaxGust_WD_10m_Err','MaxGust_WD_10m_Err','MaxGust_WD_10m_Err',NULL,NULL,NULL,NULL,NULL,'0'),(135,'MaxGust_WD_60m_Err','MaxGust_WD_60m_Err','MaxGust WD at 60m eror',NULL,NULL,NULL,NULL,NULL,'0'),(136,'MostBacked_2m_Err','MostBacked_2m_Err','MostBacked at 2m error',NULL,NULL,NULL,NULL,NULL,'0'),(137,'MostBacked_10m_Err','MostBacked_10m_Err','MostBacked at 10m error',NULL,NULL,NULL,NULL,NULL,'0'),(138,'MostVeered_2m_Err','MostVeered_2m_Err','MostVeered at 2m error',NULL,NULL,NULL,NULL,NULL,'0'),(139,'MostVeered_10m_Err','MostVeered_10m_Err','MostVeered at 10m error',NULL,NULL,NULL,NULL,NULL,'0'),(140,'CLOUD_VertVis_1m_Err','CLOUD_VertVis_1m_Err','CLOUD VertVis at 1m error',NULL,NULL,NULL,NULL,NULL,'1024');
/*!40000 ALTER TABLE `aws_toa5_mg2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_malawi1`
--

DROP TABLE IF EXISTS `aws_malawi1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_malawi1` (
  `Cols` int(11) NOT NULL,
  `Element_abbreviation` varchar(50) default NULL,
  `Element_Name` varchar(50) default NULL,
  `Element_Details` varchar(50) default NULL,
  `Climsoft_Element` varchar(6) default NULL,
  `Bufr_Element` varchar(6) default NULL,
  `unit` varchar(15) default NULL,
  `lower_limit` varchar(50) default NULL,
  `upper_limit` varchar(50) default NULL,
  `obsv` varchar(50) default NULL,
  PRIMARY KEY  (`Cols`),
  KEY `Identification` (`Element_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_malawi1`
--

LOCK TABLES `aws_malawi1` WRITE;
/*!40000 ALTER TABLE `aws_malawi1` DISABLE KEYS */;
INSERT INTO `aws_malawi1` VALUES (1,'Date','Date','Date ddmmyy',NULL,NULL,NULL,NULL,NULL,'30/04/13'),(2,'Time','Time','Time hhmmss',NULL,NULL,NULL,NULL,NULL,' 10:00:00'),(3,'Rain','Rainfall','Rain cummulative','892','013011','mm','0',NULL,' 0'),(4,'WDSPD','WindSpeed','Wind Speed Average','897',NULL,'ms-1',NULL,NULL,' 3.3802'),(5,'BARO','Pressure','Pressure','884','010004',NULL,NULL,NULL,' 957.366'),(6,'WDDR','WindDirection','Wind Direction','895','011001','deg','0','360',' 145.066'),(7,'TEMP','AirTemp','Air temperature','881','012103','dec \'C',NULL,NULL,' 26.5028'),(8,'RH','RelativeHumidity','Relative Humidity','893','013003','%','0','100',' 66.6466'),(9,'SOLRD','SolarRadiation','Solar Radiation','894','014028','Jm-2',NULL,NULL,' 406.52');
/*!40000 ALTER TABLE `aws_malawi1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_rwanda1`
--

DROP TABLE IF EXISTS `aws_rwanda1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_rwanda1` (
  `Cols` int(11) default '0',
  `Element_abbreviation` varchar(50) default NULL,
  `Element_Name` varchar(50) default NULL,
  `Element_Details` varchar(50) default NULL,
  `Climsoft_Element` varchar(6) default NULL,
  `Bufr_Element` varchar(6) default NULL,
  `unit` varchar(15) default NULL,
  `lower_limit` varchar(50) default NULL,
  `upper_limit` varchar(50) default NULL,
  `obsv` varchar(50) default NULL,
  KEY `identification` (`Element_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_rwanda1`
--

LOCK TABLES `aws_rwanda1` WRITE;
/*!40000 ALTER TABLE `aws_rwanda1` DISABLE KEYS */;
INSERT INTO `aws_rwanda1` VALUES (13,'AP_Ave','AP_Ave',NULL,'884','010004','Hpa',NULL,NULL,NULL),(14,'AP_Max','AP_Max',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(12,'AP_Min','AP_Min',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(16,'AP_Perc','AP_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(15,'AP_StdDV','AP_StdDV',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(8,'AT_Ave','AT_Ave',NULL,'881','012101','°C',NULL,NULL,NULL),(9,'AT_Max','AT_Max',NULL,'882','012111','°C',NULL,NULL,NULL),(7,'AT_Min','AT_Min',NULL,'883','012112','°C',NULL,NULL,NULL),(11,'AT_Perc','AT_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(10,'AT_StdV','AT_StdV',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(24,'BAT_Inst','BAT_Inst',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(25,'BAT_Perc','BAT_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(1,'Date/time','Date/time',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(18,'RAD_Ave','RAD_Ave',NULL,'894','014028','J',NULL,NULL,NULL),(19,'RAD_Max','RAD_Max',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(17,'RAD_Min','RAD_Min',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(21,'RAD_Perc','RAD_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(20,'RAD_StdDV','RAD_StdDV',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(23,'RAIN_Perc','RAIN_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(22,'RAIN_Tot','RAIN_Tot',NULL,'892','013011','mm',NULL,NULL,NULL),(3,'RH_Ave','RH_Ave',NULL,'893','013003','%',NULL,NULL,NULL),(4,'RH_Max','RH_Max',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,'RH_Min','RH_Min',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(6,'RH_Perc','RH_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(5,'RH_StdV','RH_StdV',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(26,'TX_Inst','TX_Inst',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(27,'TX_Perc','TX_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(37,'WDR_CalmPerc','WDR_CalmPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(38,'WDR_Perc','WDR_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(33,'WDR_PrevDir','WDR_PrevDir',NULL,'895','011001','Deg',NULL,NULL,NULL),(34,'WDR_RisDir','WDR_RisDir',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(35,'WDR_RisVel','WDR_RisVel',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(36,'WDR_StdDevDir','WDR_StdDevDir',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(29,'WSD_Ave','WSD_Ave',NULL,'897','011002','Knots',NULL,NULL,NULL),(30,'WSD_Max','WSD_Max',NULL,'886','011041','Knots',NULL,NULL,NULL),(28,'WSD_Min','WSD_Min',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(32,'WSD_Perc','WSD_Perc',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(31,'WSD_StdDev','WSD_StdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `aws_rwanda1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_structures`
--

DROP TABLE IF EXISTS `aws_structures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_structures` (
  `strID` int(11) NOT NULL auto_increment,
  `strName` varchar(20) NOT NULL,
  `data_delimiter` varchar(10) NOT NULL,
  `hdrRows` int(11) NOT NULL,
  `txtQualifier` varchar(5) default NULL,
  PRIMARY KEY  (`strName`),
  UNIQUE KEY `strID_UNIQUE` (`strID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_structures`
--

LOCK TABLES `aws_structures` WRITE;
/*!40000 ALTER TABLE `aws_structures` DISABLE KEYS */;
INSERT INTO `aws_structures` VALUES (11,'aws_malawi1','Tab',3,'\"'),(14,'aws_rwanda4','tab',3,NULL),(19,'aws_sasscal1','comma',1,'\"'),(5,'aws_toa5_bw1','Comma',4,'\"'),(18,'aws_toa5_mg2','comma',4,'');
/*!40000 ALTER TABLE `aws_structures` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_rwanda4`
--

DROP TABLE IF EXISTS `aws_rwanda4`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_rwanda4` (
  `Cols` int(11) NOT NULL,
  `Element_Name` varchar(20) default NULL,
  `Element_Abbreviation` varchar(20) default NULL,
  `Element_Details` varchar(25) default NULL,
  `Climsoft_Element` varchar(6) default NULL,
  `Bufr_Element` varchar(6) default NULL,
  `unit` varchar(15) default NULL,
  `lower_limit` varchar(10) default NULL,
  `upper_limit` varchar(10) default NULL,
  `obsv` varchar(25) default NULL,
  PRIMARY KEY  (`Cols`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_rwanda4`
--

LOCK TABLES `aws_rwanda4` WRITE;
/*!40000 ALTER TABLE `aws_rwanda4` DISABLE KEYS */;
INSERT INTO `aws_rwanda4` VALUES (1,'date/time','Date/time','Date and time',NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(2,'RHMin','RHMIN','RELATIVE Humidity Minimum',NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(3,'RHAve','RHAVG','RELATIVE Humidity Average','893','13003','%',NULL,NULL,'10-22-2015'),(4,'RHMax','RHMAX','RELATIVE Humidity Maximum',NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(5,'StdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(6,'RHValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(7,'TempMin','TMIN','Minimum Temperature','883','12112',NULL,NULL,NULL,'10-22-2015'),(8,'TempAve','TVG','Average Temperature','881','12101','\'C',NULL,NULL,'10-22-2015'),(9,'TempMax','TMAX','Maximum Temperature','882','12111',NULL,NULL,NULL,'10-22-2015'),(10,'TempStdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(11,'TempValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(12,'PRESMin','PRESMIN','Minimum Pressure',NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(13,'PRESAve','PRESAVG','Average Pressure','884','30200','hPa',NULL,NULL,'10-22-2015'),(14,'PRESMax','PRESMAX','Maximum Pressure',NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(15,'PRESStdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(16,'PRESValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(17,'RADMin','RADMIN','Global Radiation Minimum',NULL,NULL,'W/m2',NULL,NULL,'10-22-2015'),(18,'RADAve','RADAVG','Global Radiation Average','894','14028','W/m2',NULL,NULL,'10-22-2015'),(19,'RADMax','RADMAX','Global Radiation Maximum',NULL,NULL,'W/m2',NULL,NULL,'10-22-2015'),(20,'RADStdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(21,'RADValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(22,'PRECTot','PRECTOT','Total Precipitation','892','13011','mm',NULL,NULL,'10-22-2015'),(23,'PRECValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(24,'PWInst',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(25,'PWValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(26,'TempInst',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(27,'TempValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(28,'WSPMin','WSPMIN','Minimum Wind speed',NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(29,'WSPAve','WSPAVG','Average Wind speed','897','11002','m/s',NULL,NULL,'10-22-2015'),(30,'WSPMax','WSMAX','Maximum Wind speed',NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(31,'WSPStdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(32,'WSPValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(33,'WDPrevDir','WDPR','Wind Direction','895','11001',NULL,NULL,NULL,'10-22-2015'),(34,'WDRisDir','WDR',NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(35,'WDRisVel',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(36,'WDStdDevDir',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(37,'WDCalmPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(38,'WDValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(39,'TempSoilMin','TSMIN','Minimum Soil Temperature',NULL,NULL,'\'C',NULL,NULL,'10-22-2015'),(40,'TempSoilAve','TSAVG','Average Soil Temperature','900','12130','\'C',NULL,NULL,'10-22-2015'),(41,'TempSoilMax','TSMAX','Maximum Soil Temperature',NULL,NULL,'\'C',NULL,NULL,'10-22-2015'),(42,'TempSoliStdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(43,'TempSoiValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(44,'Temp10mMin',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(45,'Temp10mAve',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(46,'Temp10mMax',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(47,'Temp10mStdDev',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015'),(48,'Temp10mValidDataPerc',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'10-22-2015');
/*!40000 ALTER TABLE `aws_rwanda4` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_toa5_bw1`
--

DROP TABLE IF EXISTS `aws_toa5_bw1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_toa5_bw1` (
  `Cols` int(11) default '0',
  `Element_Abbreviation` varchar(50) default NULL,
  `Element_Name` varchar(50) default NULL,
  `Element_Details` varchar(50) default NULL,
  `Climsoft_Element` varchar(6) default NULL,
  `Bufr_Element` varchar(6) default NULL,
  `unit` varchar(15) default NULL,
  `lower_limit` varchar(50) default NULL,
  `upper_limit` varchar(50) default NULL,
  `obsv` varchar(50) default NULL,
  UNIQUE KEY `identification` (`Element_Abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_toa5_bw1`
--

LOCK TABLES `aws_toa5_bw1` WRITE;
/*!40000 ALTER TABLE `aws_toa5_bw1` DISABLE KEYS */;
INSERT INTO `aws_toa5_bw1` VALUES (1,'Date/time','date/time','Datetime',NULL,NULL,NULL,NULL,NULL,NULL),(2,'RECORD','record','Record number',NULL,NULL,NULL,NULL,NULL,NULL),(3,'BATTV','BattV_Avg','Battery Power',NULL,NULL,NULL,NULL,NULL,NULL),(4,'BATT24V','Batt24V_Avg','Daily Average Battery Power',NULL,NULL,NULL,NULL,NULL,NULL),(5,'TRACKERWM','TrackerWM_Avg','Tracker',NULL,NULL,NULL,NULL,NULL,NULL),(6,'SHADOWWM','ShadowWM_Avg','Shadow',NULL,NULL,NULL,NULL,NULL,NULL),(7,'SUNWM','SunWM_Avg','Sloar Radiation','894','014028','W/m2',NULL,NULL,NULL),(8,'WSV','WS_ms_S_WVT','Wind Speed Average','897','011002','Knots',NULL,NULL,NULL),(9,'WINDDIRD','WindDir_D1_WVT','Wind Direction Average','895','011001','Deg',NULL,NULL,NULL),(10,'WINDDIRS','WindDir_SD1_WVT','Wind Gust Direction','887',NULL,NULL,NULL,NULL,NULL),(11,'WSX','WS_ms_Max','Wind Gust Speed','886','011041','Knots',NULL,NULL,NULL),(12,'AIRTC','AirTc_Avg','Air Temperature','881','012101','°C',NULL,NULL,NULL),(13,'RH','RH','Relative Humidity','893','013003','%',NULL,NULL,NULL),(14,'BPAR','BP_mbar_Avg','Pressure','884','010004','Hpa',NULL,NULL,NULL);
/*!40000 ALTER TABLE `aws_toa5_bw1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_mss`
--

DROP TABLE IF EXISTS `aws_mss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_mss` (
  `ftpId` varchar(50) NOT NULL,
  `outputFolder` varchar(20) NOT NULL,
  `ftpMode` varchar(10) default NULL,
  `userName` varchar(15) NOT NULL,
  `password` varchar(15) NOT NULL,
  PRIMARY KEY  (`ftpId`),
  UNIQUE KEY `ftpId_UNIQUE` (`ftpId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_mss`
--

LOCK TABLES `aws_mss` WRITE;
/*!40000 ALTER TABLE `aws_mss` DISABLE KEYS */;
INSERT INTO `aws_mss` VALUES ('localhost','output','ftp','climsoft','climsoft1');
/*!40000 ALTER TABLE `aws_mss` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_basestation`
--

DROP TABLE IF EXISTS `aws_basestation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_basestation` (
  `ftpId` varchar(50) NOT NULL,
  `inputFolder` varchar(20) NOT NULL,
  `ftpMode` varchar(10) default NULL,
  `userName` varchar(15) NOT NULL,
  `password` varchar(15) NOT NULL,
  PRIMARY KEY  (`ftpId`),
  UNIQUE KEY `ftpId_UNIQUE` (`ftpId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_basestation`
--

LOCK TABLES `aws_basestation` WRITE;
/*!40000 ALTER TABLE `aws_basestation` DISABLE KEYS */;
INSERT INTO `aws_basestation` VALUES ('localhost','input','ftp','climsoft','climsoft1');
/*!40000 ALTER TABLE `aws_basestation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `code_flag`
--

DROP TABLE IF EXISTS `code_flag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `code_flag` (
  `FXY` varchar(255) NOT NULL,
  `Fxyyy` varchar(50) default NULL,
  `Description` varchar(255) default NULL,
  `Bufr_DataWidth_Bits` int(11) default NULL,
  `Crex_DataWidth` varchar(25) default NULL,
  `Bufr_Unit` varchar(255) default NULL,
  `Bufr_Value` varchar(50) default NULL,
  `Crex_Value` varchar(10) default NULL,
  PRIMARY KEY  (`FXY`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `code_flag`
--

LOCK TABLES `code_flag` WRITE;
/*!40000 ALTER TABLE `code_flag` DISABLE KEYS */;
INSERT INTO `code_flag` VALUES ('001101','B01101','State identifier',10,'3','Code table','128',NULL),('002001','B02001','Type of station',2,'1','Code table','0',NULL),('002038','B02038','Method of sea surface temperature measurement',4,'2','Code table','15',NULL),('002175','B02175','Method of precipitation measurement ',4,'2','Code table','1',NULL),('002176','B02176','Method of state of ground measurement ',4,'2','Code table','14',NULL),('002177','B02177','Method of snow depth measurement ',4,'2','Code table','15',NULL),('002178','B02178','Method of liquid content measurement of precipitation',4,'2','Code table','4',NULL),('002179','B02179','Type of sky condition algorithm ',4,'2','Code table','3',NULL),('002180','B02180','Main present weather detecting system ',4,'2','Code table','14',NULL),('002181','B02181','Supplementary present weather sensor',21,'7','Flag table',NULL,NULL),('002182','B02182','Visibility measurement system ',4,'2','Code table','14',NULL),('002183','B02183','Cloud detection system',4,'2','Code table','14',NULL),('002184','B02184','Type of lightning detection sensor',4,'2','Code table','14',NULL),('002185','B02185','Method of evaporation measurement',4,'2','Code table','14',NULL),('002186','B02186','Capability to detect precipitation phenomena',30,'10','Flag table','111111111111111111111110000000',NULL),('002187','B02187','Capability to detect other weather phenomena',18,'6','Flag table',NULL,NULL),('002188','B02188','Capability to detect obscuration',21,'7','Flag table',NULL,NULL),('002189','B02189','Capability to discriminate lightning strikes',12,'4','Flag table',NULL,NULL),('008002','B08002','Vertical significance (surface observations)',6,'2','Code table','62',NULL),('008010','B08010','Surface qualifier (temperature data)',5,'2','Code table','3',NULL),('008021','B08021','Time significance (= 2 (time averaged))',5,'2','Code table','2',NULL),('008023','B08023','First order statistics',6,'2','Code table','63',NULL),('010063','B10063','Characteristic of pressure tendency',4,'2','Code table','15',NULL),('020003','B20003','Present weather',9,'3','Code table',NULL,NULL),('020004','B20004','Past weather (1) ',5,'2','Code table',NULL,NULL),('020005','B20005','Past weather (2)',5,'2','Code table',NULL,NULL),('020011','B20011','Cloud amount',4,'2','Code table',NULL,NULL),('020012','B20012','Cloud type',6,'2','Code table',NULL,NULL),('020021','B20021','Type of precipitation',30,'10','Flag table',NULL,NULL),('020022','B20022','Character of precipitation',4,'2','Code table',NULL,NULL),('020023','B20023','Other weather phenomena',18,'6','Flag table',NULL,NULL),('020024','B20024','Intensity of phenomena',3,'1','Code table',NULL,NULL),('020025','B20025','Obscuration',21,'7','Flag table',NULL,NULL),('020026','B20026','Character of obscuration',4,'2','Code table','15',NULL),('020032','B20032','Rate of ice accretion',3,'1','Code table','7',NULL),('020062','B20062','State of the ground (with or without snow)',5,'2','Code table','32',NULL),('033005','B33005','Quality information (AWS data)',30,'10','Flag table',NULL,NULL),('033006','B33006','Internal measurement status information (AWS)',3,'1','Code table','0',NULL),('033041','B33041','Attribute of following value',2,'1','Code table','3',NULL);
/*!40000 ALTER TABLE `code_flag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_sasscal1`
--

DROP TABLE IF EXISTS `aws_sasscal1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_sasscal1` (
  `Cols` int(11) default '0',
  `Element_Abbreviation` varchar(50) default NULL,
  `Element_Name` varchar(50) default NULL,
  `Element_Details` varchar(50) default NULL,
  `Climsoft_Element` varchar(6) default NULL,
  `Bufr_Element` varchar(6) default NULL,
  `unit` varchar(15) default NULL,
  `lower_limit` varchar(50) default NULL,
  `upper_limit` varchar(50) default NULL,
  `obsv` varchar(50) default NULL,
  UNIQUE KEY `identification` (`Element_Abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_sasscal1`
--

LOCK TABLES `aws_sasscal1` WRITE;
/*!40000 ALTER TABLE `aws_sasscal1` DISABLE KEYS */;
INSERT INTO `aws_sasscal1` VALUES (1,'Station','Station','Station',NULL,NULL,NULL,NULL,NULL,'Mahenene'),(2,'Date/time','Date/time','Date/time',NULL,NULL,NULL,NULL,NULL,'20/03/2014 21:00:00'),(3,'AT','Air_Temp','Air Temperature','881','012101','\'C',NULL,NULL,'19.4'),(4,'PRECIP','Precip','Precipitation','892','013011','mm',NULL,NULL,'0.0'),(5,'WINDSPD','Wind_Speed','Wind Speed','897','011002','m/s',NULL,NULL,'1.2'),(6,'WINDSPDX','Wind_Speed_Max','Wind Speed Maximum','886','011041','m/s',NULL,NULL,'2.2'),(7,'WINDDIR','Wind_Direction','Wind Direction','895','011001','Deg',NULL,NULL,'169'),(8,'RH','RH','Relative Humidity','893','013003','%',NULL,NULL,'59.5'),(9,'BPAR','BP_mbar_Avg','Pressure','884','010004','Hpa',NULL,NULL,'891'),(10,'SOLRD','Solar_Rad','Solar Radiation','894','014028','MJ/s',NULL,NULL,'0.08'),(11,'SUNHRS','Sun_Hrs','Sunshine Hours','893','013003','hrs',NULL,NULL,'0.0');
/*!40000 ALTER TABLE `aws_sasscal1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tm_307091`
--

DROP TABLE IF EXISTS `tm_307091`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tm_307091` (
  `Rec` int(11) NOT NULL default '0',
  `Bufr_Template` varchar(50) default NULL,
  `CREX_Template` varchar(50) default NULL,
  `Sequence_Descriptor1` varchar(255) default NULL,
  `Sequence_Descriptor0` varchar(255) default NULL,
  `Bufr_Element` varchar(255) default NULL,
  `Crex_Element` varchar(50) default NULL,
  `Climsoft_Element` varchar(50) default NULL,
  `Element_Name` varchar(255) default NULL,
  `Crex_Unit` varchar(25) default NULL,
  `Crex_Scale` varchar(25) default NULL,
  `Crex_DataWidth` varchar(25) default NULL,
  `Bufr_Unit` varchar(255) default NULL,
  `Bufr_Scale` int(11) default NULL,
  `Bufr_RefValue` bigint(20) default NULL,
  `Bufr_DataWidth_Bits` int(11) default NULL,
  `Selected` tinyint(4) default NULL,
  `Observation` varchar(255) default NULL,
  `Crex_Data` varchar(30) default NULL,
  `Bufr_Data` varchar(255) default NULL,
  PRIMARY KEY  (`Rec`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tm_307091`
--

LOCK TABLES `tm_307091` WRITE;
/*!40000 ALTER TABLE `tm_307091` DISABLE KEYS */;
INSERT INTO `tm_307091` VALUES (1,'307091','D07091','301089','001101','001101','B01101','station_state_id','State identifier','Code table','0','3','Code table',0,0,10,1,NULL,NULL,'1111111111'),(2,NULL,NULL,NULL,'001102','001102','B01102','station_National_number','National station number','Numeric','0','9','Numeric',0,0,30,1,'',NULL,'111111111111111111111111111111'),(3,NULL,NULL,'301090','301004','001001','B01001','station_WMO_bloc','WMO block number','Numeric','0','2','Numeric',0,0,7,1,'63',NULL,'0011111'),(4,NULL,NULL,NULL,NULL,'001002','B01002','station_WMO_number','WMO station number','Numeric','0','3','Numeric',0,0,10,1,'999',NULL,'0111100111'),(5,NULL,NULL,NULL,NULL,'001015','B01015','station_name','Station or site name','Character','0','20','CCITT IA5',0,0,160,1,'TEST AWS',NULL,'0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000001000100010001000000000000000000010001001100010001'),(6,NULL,NULL,NULL,NULL,'002001','B02001','station_qualifier','Type of station','Code table','0','1','Code table',0,0,2,1,NULL,NULL,'1'),(7,NULL,NULL,NULL,'301011','004001','B04001','datetime_year','Year','Year','0','4','Year',0,0,12,1,'2015',NULL,'001111011111'),(8,NULL,NULL,NULL,NULL,'004002','B04002','datetime_month','Month','Month','0','2','Month',0,0,4,1,'11',NULL,'0011'),(9,NULL,NULL,NULL,NULL,'004003','B04003','datetime_day','Day','Day','0','2','Day',0,0,6,1,'10',NULL,'000010'),(10,NULL,NULL,NULL,'301012','004004','B04004','datetime_hour','Hour','Hour','0','2','Hour',0,0,5,1,'0',NULL,'00000'),(11,NULL,NULL,NULL,NULL,'004005','B04005','datetime_minute','Minute','Minute','0','2','Minute',0,0,6,1,'50',NULL,'010010'),(12,NULL,NULL,NULL,'301021','005001','B05001','station_deglatitude','Latitude (high accuracy)','Degree','5','7','Degree',5,-9000000,25,1,'-1.2575',NULL,'0000001110110100100001010'),(13,NULL,NULL,NULL,NULL,'006001','B06001','station_deglongitude','Longitude (high accuracy)','Degree','5','8','Degree',5,-18000000,26,1,'36.745',NULL,'00010010101011101000000100'),(14,NULL,NULL,NULL,'007030','007030','B07030','station_elevation','Height of station ground above mean sea level (see Note 3)','m','1','5','m',1,-4000,17,1,'2000',NULL,'00001110111000000'),(15,NULL,NULL,NULL,'007031','007031','B07031','station_pressure_height','Height of barometer above mean sea level (see Note 4)','m','1','5','m',1,-4000,17,1,'',NULL,'11111111111111111'),(16,NULL,NULL,'008010','008010','008010','B08010',NULL,'Surface qualifier (temperature data)','Code table','0','2','Code table',0,0,5,1,'3',NULL,'00001'),(17,NULL,NULL,'301091','002180','002180','B02180',NULL,'Main present weather detecting system ','Code table','0','2','Code table',0,0,4,1,'14',NULL,'0110'),(18,NULL,NULL,NULL,'002181','002181','B02181',NULL,'Supplementary present weather sensor','Flag table','0','7','Flag table',0,0,21,1,'',NULL,'111111111111111111111'),(19,NULL,NULL,NULL,'002182','002182','B02182',NULL,'Visibility measurement system ','Code table','0','2','Code table',0,0,4,1,'14',NULL,'0110'),(20,NULL,NULL,NULL,'002183','002183','B02183',NULL,'Cloud detection system','Code table','0','2','Code table',0,0,4,1,'14',NULL,'0110'),(21,NULL,NULL,NULL,'002184','002184','B02184',NULL,'Type of lightning detection sensor','Code table','0','2','Code table',0,0,4,1,'14',NULL,'0110'),(22,NULL,NULL,NULL,'002179','002179','B02179',NULL,'Type of sky condition algorithm ','Code table','0','2','Code table',0,0,4,1,'3',NULL,'0001'),(23,NULL,NULL,NULL,'002186','002186','B02186',NULL,'Capability to detect precipitation phenomena','Flag table','0','10','Flag table',0,0,30,1,'',NULL,'111111111111111111111110000000'),(24,NULL,NULL,NULL,'002187','002187','B02187',NULL,'Capability to detect other weather phenomena','Flag table','0','6','Flag table',0,0,18,1,'',NULL,'111111111111111111'),(25,NULL,NULL,NULL,'002188','002188','B02188',NULL,'Capability to detect obscuration','Flag table','0','7','Flag table',0,0,21,1,'',NULL,'111111111111111111111'),(26,NULL,NULL,NULL,'002189','002189','B02189',NULL,'Capability to discriminate lightning strikes','Flag table','0','4','Flag table',0,0,12,1,'',NULL,'111111111111'),(27,NULL,NULL,'302001','010004','010004','B10004',NULL,'Pressure','Pa',' -1','5','Pa',-1,0,14,1,'867.04',NULL,'00000000010111'),(28,NULL,NULL,NULL,'010051','010051','B10051',NULL,'Pressure reduced to mean sea level','Pa','-1','5','Pa',-1,0,14,1,'1009.688',NULL,'00000000100101'),(29,NULL,NULL,NULL,'010061','010061','B10061',NULL,'3-hour pressure change','Pa','-1','4','Pa',-1,-500,10,1,'-0.06750488',NULL,'0011110100'),(30,NULL,NULL,NULL,'010063','010063','B10063',NULL,'Characteristic of pressure tendency','Code table','0','2','Code table',0,0,4,1,'5',NULL,'0001'),(31,NULL,NULL,'007004','007004','007004','B07004',NULL,'Pressure (standard level)','Pa','-1','5','Pa',-1,0,14,1,'1014.939',NULL,'00000000100101'),(32,NULL,NULL,'010009','010009','010009','B10009',NULL,'Geopotential height of the standard level','gpm','0','5','gpm',0,-1000,17,1,'',NULL,'11111111111111111'),(33,NULL,NULL,'302072','007032','007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(34,NULL,NULL,NULL,'007033','007033','B07033',NULL,'Height of sensor above water surface (see Note 6)','m','1','4','m',1,0,12,1,'',NULL,'111111111111'),(35,NULL,NULL,NULL,'012101','012101','B12101',NULL,'Temperature/dry-bulb temperature','°C','2','4','K',2,0,16,1,'28.5',NULL,'0011010111010101'),(36,NULL,NULL,NULL,'012103','012103','B12103','885','Dew-point temperature','°C','2','4','K',2,0,16,1,'20.29727',NULL,'0011001010100001'),(37,NULL,NULL,NULL,'013003','013003','B13003',NULL,'Relative humidity','%','0','3','%',0,0,7,1,'85.4',NULL,'0010101'),(38,NULL,NULL,'103000','103000','103000','R03000',NULL,'Delayed replication of 3 descriptors',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(39,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(40,NULL,NULL,'101005','101005','101005','R01005',NULL,'Replication of 1 descriptor 5 times',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(41,NULL,NULL,'307063','007061','007061','B07061',NULL,'Depth below land surface','m','2','5','m',2,0,14,1,'',NULL,'11111111111111'),(42,NULL,NULL,NULL,'012130','012130','B12130',NULL,'Soil temperature','°C','2','4','K',2,0,16,1,'',NULL,'1111111111111111'),(43,NULL,NULL,NULL,'007061','007061','B07061',NULL,'Depth below land surface','m','2','5','m',2,0,14,1,'',NULL,'11111111111111'),(44,NULL,NULL,NULL,'012130','012130','B12130',NULL,'Soil temperature','°C','2','4','K',2,0,16,1,'',NULL,'1111111111111111'),(45,NULL,NULL,NULL,'007061','007061','B07061',NULL,'Depth below land surface','m','2','5','m',2,0,14,1,'',NULL,'11111111111111'),(46,NULL,NULL,NULL,'012130','012130','B12130',NULL,'Soil temperature','°C','2','4','K',2,0,16,1,'',NULL,'1111111111111111'),(47,NULL,NULL,NULL,'007061','007061','B07061',NULL,'Depth below land surface','m','2','5','m',2,0,14,1,'',NULL,'11111111111111'),(48,NULL,NULL,NULL,'012130','012130','B12130',NULL,'Soil temperature','°C','2','4','K',2,0,16,1,'',NULL,'1111111111111111'),(49,NULL,NULL,NULL,'007061','007061','B07061',NULL,'Depth below land surface','m','2','5','m',2,0,14,1,'',NULL,'11111111111111'),(50,NULL,NULL,NULL,'012130','012130','B12130',NULL,'Soil temperature','°C','2','4','K',2,0,16,1,'',NULL,'1111111111111111'),(51,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(52,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(53,NULL,NULL,'302069','007032','007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(54,NULL,NULL,NULL,'007033','007033','B07033',NULL,'Height of sensor above water surface (see Note 6)','m','1','4','m',1,0,12,1,'',NULL,'111111111111'),(55,NULL,NULL,NULL,'033041','033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(56,NULL,NULL,NULL,'020001','020001','B20001',NULL,'Horizontal visibility','m','-1','4','m',-1,0,13,1,'0',NULL,'0000000000000'),(57,NULL,NULL,'007032','007032','007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(58,NULL,NULL,'007033','007033','007033','B07033',NULL,'Height of sensor above water surface (see Note 6)','m','1','4','m',1,0,12,1,'',NULL,'111111111111'),(59,NULL,NULL,'105000','105000','105000','R05000',NULL,'Delayed replication of 5 descriptors  ',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(60,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(61,NULL,NULL,NULL,NULL,'020031','B20031',NULL,'Ice deposit (thickness)','m','2','3','m',2,0,7,1,'',NULL,'1111111'),(62,NULL,NULL,NULL,NULL,'020032','B20032',NULL,'Rate of ice accretion','Code table','0','1','Code table',0,0,3,1,'7',NULL,'011'),(63,NULL,NULL,NULL,NULL,'002038','B02038',NULL,'Method of sea surface temperature measurement','Code table','0','2','Code table',0,0,4,1,'15',NULL,'0111'),(64,NULL,NULL,NULL,NULL,'022043','B22043',NULL,'Sea/water temperature (scale 2)','K','2','5','K',2,0,15,1,'',NULL,'111111111111111'),(65,NULL,NULL,'302021',NULL,'022001','B22001',NULL,'Direction of waves','Degree true','0','3','Degree true',0,0,9,1,'',NULL,'111111111'),(66,NULL,NULL,NULL,NULL,'022011','B22011',NULL,'Period of waves','s','0','2','s',0,0,6,1,'',NULL,'111111'),(67,NULL,NULL,NULL,NULL,'022021','B22021',NULL,'Height of waves','m','1','4','m',1,0,10,1,'',NULL,'1111111111'),(68,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(69,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(70,NULL,NULL,'302078',NULL,'002176','B02176',NULL,'Method of state of ground measurement ','Code table','0','2','Code table',0,0,4,1,'14',NULL,'0110'),(71,NULL,NULL,NULL,NULL,'020062','B20062',NULL,'State of the ground (with or without snow)','Code table','0','2','Code table',0,0,5,1,'32',NULL,'00000'),(72,NULL,NULL,NULL,NULL,'002177','B02177',NULL,'Method of snow depth measurement ','Code table','0','2','Code table',0,0,4,1,'15',NULL,'0111'),(73,NULL,NULL,NULL,NULL,'013013','B13013',NULL,'Total snow depth','m','2','5','m',2,-2,16,1,'0',NULL,'0000000000000000'),(74,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(75,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(76,NULL,NULL,'302073',NULL,'020010','B20010',NULL,'Cloud cover (total) (see Note 5)','%','0','3','%',0,0,7,1,'',NULL,'1111111'),(77,NULL,NULL,NULL,NULL,'105004','R05004',NULL,'Replication of 5 descriptor 4 times',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(78,NULL,NULL,NULL,NULL,'008002','B08002',NULL,'Vertical significance (surface observations)','Code table','0','2','Code table',0,0,6,1,'62',NULL,'011110'),(79,NULL,NULL,NULL,NULL,'020011','B20011',NULL,'Cloud amount','Code table','0','2','Code table',0,0,4,1,NULL,NULL,'1111'),(80,NULL,NULL,NULL,NULL,'020012','B20012',NULL,'Cloud type','Code table','0','2','Code table',0,0,6,1,NULL,NULL,'111111'),(81,NULL,NULL,NULL,NULL,'033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(82,NULL,NULL,NULL,NULL,'020013','B20013',NULL,'Height of base of cloud','m','-1','4','m',-1,-40,11,1,'',NULL,'11111111111'),(83,NULL,NULL,NULL,NULL,'008002','B08002',NULL,'Vertical significance (surface observations)','Code table','0','2','Code table',0,0,6,1,'62',NULL,'011110'),(84,NULL,NULL,NULL,NULL,'020011','B20011',NULL,'Cloud amount','Code table','0','2','Code table',0,0,4,1,NULL,NULL,'1111'),(85,NULL,NULL,NULL,NULL,'020012','B20012',NULL,'Cloud type','Code table','0','2','Code table',0,0,6,1,NULL,NULL,'111111'),(86,NULL,NULL,NULL,NULL,'033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(87,NULL,NULL,NULL,NULL,'033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(88,NULL,NULL,NULL,NULL,'008002','B08002',NULL,'Vertical significance (surface observations)','Code table','0','2','Code table',0,0,6,1,'62',NULL,'011110'),(89,NULL,NULL,NULL,NULL,'020011','B20011',NULL,'Cloud amount','Code table','0','2','Code table',0,0,4,1,NULL,NULL,'1111'),(90,NULL,NULL,NULL,NULL,'020012','B20012',NULL,'Cloud type','Code table','0','2','Code table',0,0,6,1,NULL,NULL,'111111'),(91,NULL,NULL,NULL,NULL,'033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(92,NULL,NULL,NULL,NULL,'033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(93,NULL,NULL,NULL,NULL,'008002','B08002',NULL,'Vertical significance (surface observations)','Code table','0','2','Code table',0,0,6,1,'62',NULL,'011110'),(94,NULL,NULL,NULL,NULL,'020011','B20011',NULL,'Cloud amount','Code table','0','2','Code table',0,0,4,1,NULL,NULL,'1111'),(95,NULL,NULL,NULL,NULL,'020012','B20012',NULL,'Cloud type','Code table','0','2','Code table',0,0,6,1,NULL,NULL,'111111'),(96,NULL,NULL,NULL,NULL,'033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(97,NULL,NULL,NULL,NULL,'033041','B33041',NULL,'Attribute of following value','Code table','0','1','Code table',0,0,2,1,'3',NULL,'01'),(98,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(99,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(100,NULL,NULL,'302074',NULL,'020003','B20003',NULL,'Present weather','Code table','0','3','Code table',0,0,9,1,NULL,NULL,'111111111'),(101,NULL,NULL,NULL,NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(102,NULL,NULL,NULL,NULL,'020004','B20004',NULL,'Past weather (1) ','Code table','0','2','Code table',0,0,5,1,NULL,NULL,'11111'),(103,NULL,NULL,NULL,NULL,'020005','B20005',NULL,'Past weather (2)','Code table','0','2','Code table',0,0,5,1,NULL,NULL,'11111'),(104,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(105,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(106,NULL,NULL,'302175',NULL,'008021','B08021',NULL,'Time significance (= 2 (time averaged))','Code table','0','2','Code table',0,0,5,1,'2',NULL,'00000'),(107,NULL,NULL,NULL,NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(108,NULL,NULL,NULL,NULL,'013155','B13155',NULL,'Intensity of precipitation (high accuracy)','mmh-1','1','5','kg/m-2s-1',5,-1,16,1,'-2.121421',NULL,'1111111111111111'),(109,NULL,NULL,NULL,NULL,'013058','B13058',NULL,'Size of precipitating element','mm','4','3','m',4,0,7,1,'',NULL,'1111111'),(110,NULL,NULL,NULL,NULL,'008021','B08021',NULL,'Time significance (= 2 (time averaged))','Code table','0','2','Code table',0,0,5,1,'2',NULL,'00000'),(111,NULL,NULL,'102000','102000','102000','R02000',NULL,'Delayed replication of 2 descriptors',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(112,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(113,NULL,NULL,'004025',NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(114,NULL,NULL,'302076',NULL,'020021','B20021',NULL,'Type of precipitation','Flag table','0','10','Flag table',0,0,30,1,'',NULL,'111111111111111111111111111111'),(115,NULL,NULL,NULL,NULL,'020022','B20022',NULL,'Character of precipitation','Code table','0','2','Code table',0,0,4,1,NULL,NULL,'1111'),(116,NULL,NULL,NULL,NULL,'026020','B26020',NULL,'Duration of precipitation','Minute','0','4','Minute',0,0,11,1,'',NULL,'11111111111'),(117,NULL,NULL,NULL,NULL,'020023','B20023',NULL,'Other weather phenomena','Flag table','0','6','Flag table',0,0,18,1,'',NULL,'111111111111111111'),(118,NULL,NULL,NULL,NULL,'020024','B20024',NULL,'Intensity of phenomena','Code table','0','1','Code table',0,0,3,1,NULL,NULL,'111'),(119,NULL,NULL,NULL,NULL,'020025','B20025',NULL,'Obscuration','Flag table','0','7','Flag table',0,0,21,1,'',NULL,'111111111111111111111'),(120,NULL,NULL,NULL,NULL,'020026','B20026',NULL,'Character of obscuration','Code table','0','2','Code table',0,0,4,1,'15',NULL,'0111'),(121,NULL,NULL,'302071','007032','007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(122,NULL,NULL,NULL,'007033','007033','B07033',NULL,'Height of sensor above water surface (see Note 6)','m','1','4','m',1,0,12,1,'',NULL,'111111111111'),(123,NULL,NULL,NULL,'008021','008021','B08021',NULL,'Time significance (= 2 (time averaged))','Code table','0','2','Code table',0,0,5,1,'2',NULL,'00000'),(124,NULL,NULL,NULL,'004025','004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(125,NULL,NULL,NULL,'011001','011001','B11001',NULL,'Wind direction','Degree true','0','3','Degree true',0,0,9,1,'56.13',NULL,'000011000'),(126,NULL,NULL,NULL,'011002','011002','B11002',NULL,'Wind speed','m s-1','1','4','m s-1',1,0,12,1,'4.028',NULL,'000000001000'),(127,NULL,NULL,NULL,'008021','008021','B08021',NULL,'Time significance (= 2 (time averaged))','Code table','0','2','Code table',0,0,5,1,'2',NULL,'00000'),(128,NULL,NULL,NULL,'103002','103002','R03002',NULL,'Replicate next 3 descriptors 2 times',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(129,NULL,NULL,NULL,'004025','004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'-10',NULL,'001111110110'),(130,NULL,NULL,NULL,'011043','011043','B11043','887','Maximum wind gust direction','Degree true','0','3','Degree true',0,0,9,1,'60.25',NULL,'000011100'),(131,NULL,NULL,NULL,'011041','011041','B11041','886','Maximum wind gust speed','m s-1','1','4','m s-1',1,0,12,1,'6.3',NULL,'000000011111'),(132,NULL,NULL,NULL,'004025','004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(133,NULL,NULL,NULL,'011043','011043','B11043','887','Maximum wind gust direction','Degree true','0','3','Degree true',0,0,9,1,'',NULL,'111111111'),(134,NULL,NULL,NULL,'011041','011041','B11041','886','Maximum wind gust speed','m s-1','1','4','m s-1',1,0,12,1,'',NULL,'111111111111'),(135,NULL,NULL,NULL,'004025','004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'-10',NULL,'001111110110'),(136,NULL,NULL,NULL,'011016','011016','B11016',NULL,'Extreme counterclockwise wind direction of a variable wind','Degree true','0','3','Degree true',0,0,9,1,'',NULL,'111111111'),(137,NULL,NULL,NULL,'011017','011017','B11017',NULL,'Extreme clockwise wind direction of a variable wind','Degree true','0','3','Degree true',0,0,9,1,'',NULL,'111111111'),(138,NULL,NULL,'302077','007032','007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(139,NULL,NULL,NULL,'007033','007033','B07033',NULL,'Height of sensor above water surface (see Note 6)','m','1','4','m',1,0,12,1,'',NULL,'111111111111'),(140,NULL,NULL,NULL,'004025','004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(141,NULL,NULL,NULL,'012111','012111','B12111',NULL,'Maximum temperature (scale 2) at height and over period specified','°C','2','4','K',2,0,16,1,'28.84937',NULL,'0011010111111000'),(142,NULL,NULL,NULL,'012112','012112','B12112',NULL,'Minimum temperature (scale 2) at height and over period specified','°C','2','4','K',2,0,16,1,'17.79975',NULL,'0011000110100111'),(143,NULL,NULL,NULL,'007032','007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(144,NULL,NULL,NULL,'004025','004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(145,NULL,NULL,NULL,'012112','012112','B12112',NULL,'Minimum temperature (scale 2) at height and over period specified','°C','2','4','K',2,0,16,1,'17.79975',NULL,'0011000110100111'),(146,NULL,NULL,'007033','007033','007033','B07033',NULL,'Height of sensor above water surface (see Note 6)','m','1','4','m',1,0,12,1,'',NULL,'111111111111'),(147,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(148,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(149,NULL,NULL,'302079',NULL,'007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(150,NULL,NULL,NULL,NULL,'002175','B02175',NULL,'Method of precipitation measurement ','Code table','0','2','Code table',0,0,4,1,'1',NULL,'0001'),(151,NULL,NULL,NULL,NULL,'002178','B02178',NULL,'Method of liquid content measurement of precipitation','Code table','0','2','Code table',0,0,4,1,'4',NULL,'0000'),(152,NULL,NULL,NULL,NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(153,NULL,NULL,NULL,NULL,'013011','B13011',NULL,'Total precipitation/total water equivalent','kg m-2','1','5','kg m-2',1,-1,14,1,'0',NULL,'00000000000001'),(154,NULL,NULL,'007032','007032','007032','B07032',NULL,'Height of sensor above local ground (or deck of marine platform) (see Note 5)','m','2','5','m',2,0,16,1,'',NULL,'1111111111111111'),(155,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(156,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(157,NULL,NULL,'302080',NULL,'002185','B02185',NULL,'Method of evaporation measurement','Code table','0','2','Code table',0,0,4,1,'14',NULL,'0110'),(158,NULL,NULL,NULL,NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(159,NULL,NULL,NULL,NULL,'013033','B13033',NULL,'Evaporation/evapotranspiration','kg m-2','1','4','kg m-2',1,0,10,1,'',NULL,'1111111111'),(160,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(161,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(162,NULL,NULL,'302081',NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(163,NULL,NULL,NULL,NULL,'014031','B14031',NULL,'Total sunshine','Minute','0','4','Minute',0,0,11,1,'0',NULL,'00000000000'),(164,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(165,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(166,NULL,NULL,'302082',NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(167,NULL,NULL,NULL,NULL,'014002','B14002',NULL,'Long-wave radiation, integrated over period specified','J m-2','-3','4','J m-2',-3,-2048,12,1,'',NULL,'111111111111'),(168,NULL,NULL,NULL,NULL,'014004','B14004',NULL,'Short-wave radiation, integrated over period specified','J m-2','-3','4','J m-2',-3,-2048,12,1,'',NULL,'111111111111'),(169,NULL,NULL,NULL,NULL,'014016','B14016',NULL,'Net radiation, integrated over period specified','J m-2','-4','5','J m-2',-4,-16384,15,1,'',NULL,'111111111111111'),(170,NULL,NULL,NULL,NULL,'014028','B14028',NULL,'Global solar radiation (high accuracy), integrated over period specified','J m-2','-2','5','J m-2',-2,0,16,1,'0',NULL,'0000000000000000'),(171,NULL,NULL,NULL,NULL,'014029','B14029',NULL,'Diffuse solar radiation (high accuracy), integrated over period specified','J m-2','-2','5','J m-2',-2,0,16,1,'',NULL,'1111111111111111'),(172,NULL,NULL,NULL,NULL,'014030','B14030',NULL,'Direct solar radiation (high accuracy), integrated over period specified','J m-2','-2','5','J m-2',-2,0,16,1,'',NULL,'1111111111111111'),(173,NULL,NULL,'102000','102000','102000','R02000',NULL,'Delayed replication of 2 descriptors',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(174,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(175,NULL,NULL,'004025',NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(176,NULL,NULL,'013059',NULL,'013059','B13059',NULL,'Number of flashes (thunderstorm)','Numeric','0','3','Numeric',0,0,7,1,'',NULL,'1111111'),(177,NULL,NULL,'101000','101000','101000','R01000',NULL,'Delayed replication of 1 descriptor',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'',NULL,NULL),(178,NULL,NULL,'031000','031000','031000','B31000',NULL,'Short delayed descriptor replication factor','Numeric','0','4','Numeric',0,0,1,1,'',NULL,'1'),(179,NULL,NULL,'302083',NULL,'004025','B04025',NULL,'Time period or displacement','Minute','0','4','Minute',0,-2048,12,1,'',NULL,'111111111111'),(180,NULL,NULL,NULL,NULL,'008023','B08023',NULL,'First order statistics','Code table','0','2','Code table',0,0,6,1,'63',NULL,'011111'),(181,NULL,NULL,NULL,NULL,'010004','B10004',NULL,'Pressure','Pa',' -1','5','Pa',-1,0,14,1,'867.04',NULL,'00000000010111'),(182,NULL,NULL,NULL,NULL,'011001','B11001',NULL,'Wind direction','Degree true','0','3','Degree true',0,0,9,1,'56.13',NULL,'000011000'),(183,NULL,NULL,NULL,NULL,'011002','B11002',NULL,'Wind speed','m s-1','1','4','m s-1',1,0,12,1,'4.028',NULL,'000000001000'),(184,NULL,NULL,NULL,NULL,'012101','B12101',NULL,'Temperature/dry-bulb temperature','°C','2','4','K',2,0,16,1,'',NULL,'1111111111111111'),(185,NULL,NULL,NULL,NULL,'013003','B13003',NULL,'Relative humidity','%','0','3','%',0,0,7,1,'85.4',NULL,'0010101'),(186,NULL,NULL,NULL,NULL,'008023','B08023',NULL,'First order statistics','Code table','0','2','Code table',0,0,6,1,'63',NULL,'011111'),(187,NULL,NULL,'033005','033005','033005','B33005',NULL,'Quality information (AWS data)','Flag table','0','10','Flag table',0,0,30,1,'',NULL,'111111111111111111111111111111'),(188,NULL,NULL,'033006','033006','033006','B33006',NULL,'Internal measurement status information (AWS)','Code table','0','1','Code table',0,0,3,1,'0',NULL,'000');
/*!40000 ALTER TABLE `tm_307091` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aws_sites`
--

DROP TABLE IF EXISTS `aws_sites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aws_sites` (
  `SiteID` varchar(20) NOT NULL,
  `InputFile` varchar(50) NOT NULL,
  `DataStructure` varchar(20) NOT NULL,
  `MissingDataFlag` varchar(10) default NULL,
  `awsServerIp` varchar(50) NOT NULL,
  `OperationalStatus` tinyint(4) NOT NULL,
  `aws_msg` varchar(12) default NULL,
  PRIMARY KEY  (`SiteID`),
  UNIQUE KEY `SiteID_UNIQUE` (`SiteID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aws_sites`
--

LOCK TABLES `aws_sites` WRITE;
/*!40000 ALTER TABLE `aws_sites` DISABLE KEYS */;
INSERT INTO `aws_sites` VALUES ('AWS1','TOLIARY_CurrentValues.dat','aws_toa5_bw1','-9999','localhost',0,'ISAH01 HKNC'),('AWS3','ANTSIRANANA_CurrentValues.csv','aws_toa5_mg2','NAN','localhost',1,'ISAH01 HKNC'),('AWS4','Data_12071103.Elab.txt','aws_rwanda4','-999990.00','localhost',0,'ISAH01 HKNC'),('AWS5','aws_stations.csv','aws_sasscal1','-99999','localhost',0,'ISAH01 HKNC');
/*!40000 ALTER TABLE `aws_sites` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-11-10  9:15:19
