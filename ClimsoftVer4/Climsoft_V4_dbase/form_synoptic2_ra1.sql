CREATE DATABASE  IF NOT EXISTS `mysql_climsoft_db_v4` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mysql_climsoft_db_v4`;
-- MySQL dump 10.13  Distrib 5.6.12, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: mysql_climsoft_db_v4
-- ------------------------------------------------------
-- Server version	5.6.12

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
-- Table structure for table `form_synoptic_2_ra1`
--

DROP TABLE IF EXISTS `form_synoptic_2_ra1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `form_synoptic_2_ra1` (
  `stationId` varchar(50) NOT NULL DEFAULT '',
  `yyyy` int(11) NOT NULL,
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  `hh` int(11) NOT NULL,
  `Val_Elem106` varchar(6) DEFAULT NULL,
  `Val_Elem107` varchar(6) DEFAULT NULL,
  `Val_Elem400` varchar(6) DEFAULT NULL,
  `Val_Elem814` varchar(6) DEFAULT NULL,
  `Val_Elem399` varchar(6) DEFAULT NULL,
  `Val_Elem301` varchar(6) DEFAULT NULL,
  `Val_Elem196` varchar(6) DEFAULT NULL,
  `Val_Elem101` varchar(6) DEFAULT NULL,
  `Val_Elem102` varchar(6) DEFAULT NULL,
  `Val_Elem103` varchar(6) DEFAULT NULL,
  `Val_Elem105` varchar(6) DEFAULT NULL,
  `Val_Elem176` varchar(6) DEFAULT NULL,
  `Val_Elem110` varchar(6) DEFAULT NULL,
  `Val_Elem114` varchar(6) DEFAULT NULL,
  `Val_Elem112` varchar(6) DEFAULT NULL,
  `Val_Elem111` varchar(6) DEFAULT NULL,
  `Val_Elem167` varchar(6) DEFAULT NULL,
  `Val_Elem197` varchar(6) DEFAULT NULL,
  `Val_Elem193` varchar(6) DEFAULT NULL,
  `Val_Elem115` varchar(6) DEFAULT NULL,
  `Val_Elem177` varchar(6) DEFAULT NULL,
  `Val_Elem119` varchar(6) DEFAULT NULL,
  `Val_Elem116` varchar(6) DEFAULT NULL,
  `Val_Elem117` varchar(6) DEFAULT NULL,
  `Val_Elem118` varchar(6) DEFAULT NULL,
  `Val_Elem123` varchar(6) DEFAULT NULL,
  `Val_Elem120` varchar(6) DEFAULT NULL,
  `Val_Elem121` varchar(6) DEFAULT NULL,
  `Val_Elem122` varchar(6) DEFAULT NULL,
  `Val_Elem127` varchar(6) DEFAULT NULL,
  `Val_Elem124` varchar(6) DEFAULT NULL,
  `Val_Elem125` varchar(6) DEFAULT NULL,
  `Val_Elem126` varchar(6) DEFAULT NULL,
  `Val_Elem131` varchar(6) DEFAULT NULL,
  `Val_Elem128` varchar(6) DEFAULT NULL,
  `Val_Elem129` varchar(6) DEFAULT NULL,
  `Val_Elem130` varchar(6) DEFAULT NULL,
  `Val_Elem002` varchar(6) DEFAULT NULL,
  `Val_Elem003` varchar(6) DEFAULT NULL,
  `Val_Elem099` varchar(6) DEFAULT NULL,
  `Val_Elem018` varchar(6) DEFAULT NULL,
  `Val_Elem084` varchar(6) DEFAULT NULL,
  `Val_Elem132` varchar(6) DEFAULT NULL,
  `Val_Elem005` varchar(6) DEFAULT NULL,
  `Val_Elem174` varchar(6) DEFAULT NULL,
  `Val_Elem046` varchar(6) DEFAULT NULL,
  `Flag106` varchar(1) DEFAULT NULL,
  `Flag107` varchar(1) DEFAULT NULL,
  `Flag400` varchar(1) DEFAULT NULL,
  `Flag814` varchar(1) DEFAULT NULL,
  `Flag399` varchar(1) DEFAULT NULL,
  `Flag301` varchar(1) DEFAULT NULL,
  `Flag196` varchar(1) DEFAULT NULL,
  `Flag101` varchar(1) DEFAULT NULL,
  `Flag102` varchar(1) DEFAULT NULL,
  `Flag103` varchar(1) DEFAULT NULL,
  `Flag105` varchar(1) DEFAULT NULL,
  `Flag176` varchar(1) DEFAULT NULL,
  `Flag110` varchar(1) DEFAULT NULL,
  `Flag114` varchar(1) DEFAULT NULL,
  `Flag112` varchar(1) DEFAULT NULL,
  `Flag111` varchar(1) DEFAULT NULL,
  `Flag167` varchar(1) DEFAULT NULL,
  `Flag197` varchar(1) DEFAULT NULL,
  `Flag115` varchar(1) DEFAULT NULL,
  `Flag177` varchar(1) DEFAULT NULL,
  `Flag119` varchar(1) DEFAULT NULL,
  `Flag116` varchar(1) DEFAULT NULL,
  `Flag117` varchar(1) DEFAULT NULL,
  `Flag118` varchar(1) DEFAULT NULL,
  `Flag123` varchar(1) DEFAULT NULL,
  `Flag120` varchar(1) DEFAULT NULL,
  `Flag121` varchar(1) DEFAULT NULL,
  `Flag122` varchar(1) DEFAULT NULL,
  `Flag127` varchar(1) DEFAULT NULL,
  `Flag124` varchar(1) DEFAULT NULL,
  `Flag125` varchar(1) DEFAULT NULL,
  `Flag126` varchar(1) DEFAULT NULL,
  `Flag131` varchar(1) DEFAULT NULL,
  `Flag128` varchar(1) DEFAULT NULL,
  `Flag129` varchar(1) DEFAULT NULL,
  `Flag130` varchar(1) DEFAULT NULL,
  `Flag002` varchar(1) DEFAULT NULL,
  `Flag003` varchar(1) DEFAULT NULL,
  `Flag099` varchar(1) DEFAULT NULL,
  `Flag018` varchar(1) DEFAULT NULL,
  `Flag084` varchar(1) DEFAULT NULL,
  `Flag132` varchar(1) DEFAULT NULL,
  `Flag005` varchar(1) DEFAULT NULL,
  `Flag174` varchar(1) DEFAULT NULL,
  `Flag046` varchar(1) DEFAULT NULL,
  `signature` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`mm`,`stationId`,`yyyy`,`dd`,`hh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-15 22:39:42
