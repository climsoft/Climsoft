<<<<<<< HEAD
CREATE DATABASE  IF NOT EXISTS `mysql_climsoft_db_v4` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `mysql_climsoft_db_v4`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: mysql_climsoft_db_v4
-- ------------------------------------------------------
-- Server version	5.0.51b-community-nt
=======
# NOTE: This script is for creating primary tables for the Climsoft V4 database in MySQL version 5.6 
# When editing the script, please note use of appropriate quotes symbol for enclosing database name, table names and field names 
# in MySQL version 5.6 i.e. [`] and not ['] 
>>>>>>> master

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
-- Table structure for table `acquisitiontype`
--

DROP TABLE IF EXISTS `acquisitiontype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acquisitiontype` (
  `code` int(11) NOT NULL default '0',
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acquisitiontype`
--

LOCK TABLES `acquisitiontype` WRITE;
/*!40000 ALTER TABLE `acquisitiontype` DISABLE KEYS */;
/*!40000 ALTER TABLE `acquisitiontype` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `faultresolution`
--

DROP TABLE IF EXISTS `faultresolution`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faultresolution` (
  `resolvedDatetime` datetime default NULL,
  `resolvedBy` varchar(255) default NULL,
  `associatedWith` bigint(20) default NULL,
  `remarks` varchar(255) default NULL,
  UNIQUE KEY `solution` (`resolvedDatetime`,`associatedWith`),
  KEY `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` (`associatedWith`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` FOREIGN KEY (`associatedWith`) REFERENCES `instrumentfaultreport` (`reportId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faultresolution`
--

LOCK TABLES `faultresolution` WRITE;
/*!40000 ALTER TABLE `faultresolution` DISABLE KEYS */;
/*!40000 ALTER TABLE `faultresolution` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `featuregeographicalposition`
--

DROP TABLE IF EXISTS `featuregeographicalposition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `featuregeographicalposition` (
  `belongsTo` varchar(255) NOT NULL,
  `observedOn` datetime default NULL,
  `latitude` double(11,6) default NULL,
  `longitude` double(11,6) default NULL,
  KEY `FK_mysql_climsoft_db_v4_synopfeatureFeatureGeographicalPosition` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_synopfeatureFeatureGeographicalPosition` FOREIGN KEY (`belongsTo`) REFERENCES `synopfeature` (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `featuregeographicalposition`
--

LOCK TABLES `featuregeographicalposition` WRITE;
/*!40000 ALTER TABLE `featuregeographicalposition` DISABLE KEYS */;
/*!40000 ALTER TABLE `featuregeographicalposition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `flags`
--

DROP TABLE IF EXISTS `flags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `flags` (
  `characterSymbol` varchar(255) NOT NULL default '',
  `numSymbol` int(11) default NULL,
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`characterSymbol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flags`
--

LOCK TABLES `flags` WRITE;
/*!40000 ALTER TABLE `flags` DISABLE KEYS */;
/*!40000 ALTER TABLE `flags` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrument`
--

DROP TABLE IF EXISTS `instrument`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `instrument` (
  `instrumentName` varchar(255) default NULL,
  `instrumentCode` varchar(255) NOT NULL,
  `serialNumber` varchar(255) default NULL,
  `abbreviation` varchar(255) default NULL,
  `model` varchar(255) default NULL,
  `manufacturer` varchar(255) default NULL,
  `instrumentUncertainty` float(11,6) default NULL,
  `installationDatetime` datetime default NULL,
  `deinstallationDatetime` datetime default NULL,
  `height` varchar(255) default NULL,
  `instrumentPicture` blob,
  `installedAt` varchar(255) default NULL,
  PRIMARY KEY  (`instrumentCode`),
  KEY `code` (`instrumentCode`),
  KEY `IXFK_instrument` (`installedAt`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrument` FOREIGN KEY (`installedAt`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrument`
--

LOCK TABLES `instrument` WRITE;
/*!40000 ALTER TABLE `instrument` DISABLE KEYS */;
/*!40000 ALTER TABLE `instrument` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrumentfaultreport`
--

DROP TABLE IF EXISTS `instrumentfaultreport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `instrumentfaultreport` (
  `refersTo` varchar(255) default NULL,
  `reportId` bigint(20) NOT NULL,
  `reportDatetime` datetime default NULL,
  `faultDescription` varchar(255) default NULL,
  `reportedBy` varchar(255) default NULL,
  `receivedDatetime` datetime default NULL,
  `receivedBy` varchar(255) default NULL,
  `reportedFrom` varchar(255) default NULL,
  PRIMARY KEY  (`reportId`),
  UNIQUE KEY `instrument_report` (`refersTo`,`reportDatetime`,`reportedFrom`),
  KEY `report_id` (`reportId`),
  KEY `FK_mysql_climsoft_db_v4_station_instrumentFaultReport` (`reportedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrument_instrumentFaultReport` FOREIGN KEY (`refersTo`) REFERENCES `instrument` (`instrumentCode`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_instrumentFaultReport` FOREIGN KEY (`reportedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrumentfaultreport`
--

LOCK TABLES `instrumentfaultreport` WRITE;
/*!40000 ALTER TABLE `instrumentfaultreport` DISABLE KEYS */;
/*!40000 ALTER TABLE `instrumentfaultreport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrumentinspection`
--

DROP TABLE IF EXISTS `instrumentinspection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `instrumentinspection` (
  `performedOn` varchar(255) default NULL,
  `inspectionDatetime` datetime default NULL,
  `performedBy` varchar(255) default NULL,
  `status` varchar(255) default NULL,
  `remarks` varchar(255) default NULL,
  `performedAt` varchar(255) default NULL,
  UNIQUE KEY `inspection` (`performedOn`,`inspectionDatetime`),
  KEY `FK_mysql_climsoft_db_v4_station_instrumentInspection` (`performedAt`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrument_instrumentInspection` FOREIGN KEY (`performedOn`) REFERENCES `instrument` (`instrumentCode`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_instrumentInspection` FOREIGN KEY (`performedAt`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrumentinspection`
--

LOCK TABLES `instrumentinspection` WRITE;
/*!40000 ALTER TABLE `instrumentinspection` DISABLE KEYS */;
/*!40000 ALTER TABLE `instrumentinspection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `obselement`
--

DROP TABLE IF EXISTS `obselement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `obselement` (
  `code` bigint(20) NOT NULL default '0',
  `abbreviation` varchar(255) default NULL,
  `elementName` varchar(255) default NULL,
  `description` varchar(255) default NULL,
  `elementScale` decimal(8,2) default NULL,
  `upperLimit` varchar(255) default NULL,
  `lowerLimit` varchar(255) default NULL,
  `units` varchar(255) default NULL,
  `elementtype` varchar(50) default NULL,
  PRIMARY KEY  (`code`),
  KEY `elementCode` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `obselement`
--

LOCK TABLES `obselement` WRITE;
/*!40000 ALTER TABLE `obselement` DISABLE KEYS */;
/*!40000 ALTER TABLE `obselement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `observationfinal`
--

DROP TABLE IF EXISTS `observationfinal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `observationfinal` (
  `recordedFrom` varchar(255) NOT NULL,
  `describedBy` bigint(20) default NULL,
  `obsDatetime` datetime default NULL,
  `obsLevel` varchar(255) default NULL,
  `obsValue` decimal(8,2) default NULL,
  `flag` varchar(255) default NULL,
  `period` int(11) default NULL,
  `qcStatus` int(11) default '0',
  `qcTypeLog` text,
  `acquisitionType` int(11) default '0',
  `dataForm` varchar(255) default NULL,
  `capturedBy` varchar(255) default NULL,
  `mark` varchar(50) default NULL,
  `temperatureUnits` varchar(255) default NULL,
  `precipitationUnits` varchar(255) default NULL,
  `cloudHeightUnits` varchar(255) default NULL,
  `visUnits` varchar(255) default NULL,
  `dataSourceTimeZone` int(11) default '0',
  KEY `obsElementObservationInitial` (`describedBy`),
  KEY `stationObservationInitial` (`recordedFrom`),
  KEY `FK_mysql_climsoft_db_v4_obselement_observationFinal` (`describedBy`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_observationFinal` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obselement_observationFinal` FOREIGN KEY (`describedBy`) REFERENCES `obselement` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `observationfinal`
--

LOCK TABLES `observationfinal` WRITE;
/*!40000 ALTER TABLE `observationfinal` DISABLE KEYS */;
/*!40000 ALTER TABLE `observationfinal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `observationinitial`
--

DROP TABLE IF EXISTS `observationinitial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `observationinitial` (
  `recordedFrom` varchar(255) NOT NULL,
  `describedBy` bigint(20) default NULL,
  `obsDatetime` datetime default NULL,
  `obsLevel` varchar(255) default NULL,
  `obsValue` decimal(8,2) default NULL,
  `flag` varchar(255) default NULL,
  `period` int(11) default NULL,
  `qcStatus` int(11) default '0',
  `qcTypeLog` text,
  `acquisitionType` int(11) default '0',
  `dataForm` varchar(255) default NULL,
  `capturedBy` varchar(255) default NULL,
  `mark` varchar(255) default NULL,
  `temperatureUnits` varchar(255) default NULL,
  `precipitationUnits` varchar(255) default NULL,
  `cloudHeightUnits` varchar(255) default NULL,
  `visUnits` varchar(255) default NULL,
  `dataSourceTimeZone` int(11) default '0',
  KEY `obsElementObservationInitial` (`describedBy`),
  KEY `stationObservationInitial` (`recordedFrom`),
  KEY `FK_mysql_climsoft_db_v4_obselement_observationInitial` (`describedBy`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_observationInitial` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obselement_observationInitial` FOREIGN KEY (`describedBy`) REFERENCES `obselement` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `observationinitial`
--

LOCK TABLES `observationinitial` WRITE;
/*!40000 ALTER TABLE `observationinitial` DISABLE KEYS */;
/*!40000 ALTER TABLE `observationinitial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `observationschedule`
--

DROP TABLE IF EXISTS `observationschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `observationschedule` (
  `classifiedInto` varchar(255) default NULL,
  `startTime` datetime default NULL,
  `endTime` datetime default NULL,
  `interval` varchar(50) default NULL,
  `additionalObsTime` datetime default NULL,
  UNIQUE KEY `scheduleIdentification` (`classifiedInto`,`startTime`,`endTime`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obsSchedule` FOREIGN KEY (`classifiedInto`) REFERENCES `obsscheduleclass` (`scheduleClass`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `observationschedule`
--

LOCK TABLES `observationschedule` WRITE;
/*!40000 ALTER TABLE `observationschedule` DISABLE KEYS */;
/*!40000 ALTER TABLE `observationschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `obsscheduleclass`
--

DROP TABLE IF EXISTS `obsscheduleclass`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `obsscheduleclass` (
  `scheduleClass` varchar(255) NOT NULL default '',
  `description` varchar(255) default NULL,
  `refersTo` varchar(255) default NULL,
  PRIMARY KEY  (`scheduleClass`),
  KEY `scheduleClassIdeification` (`scheduleClass`),
  KEY `FK_mysql_climsoft_db_v4_station_scheduleClass` (`refersTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_scheduleClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `obsscheduleclass`
--

LOCK TABLES `obsscheduleclass` WRITE;
/*!40000 ALTER TABLE `obsscheduleclass` DISABLE KEYS */;
/*!40000 ALTER TABLE `obsscheduleclass` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paperarchive`
--

DROP TABLE IF EXISTS `paperarchive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paperarchive` (
  `belongsTo` varchar(255) default NULL,
  `code` varchar(255) default NULL,
  `description` varchar(255) default NULL,
  `year` int(11) default NULL,
  `month` int(11) default NULL,
  `day` int(11) default NULL,
  `image` blob,
  UNIQUE KEY `paper_archive_identification` (`belongsTo`,`code`,`year`,`month`,`day`),
  KEY `stationpaperArchive` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_paperArchive` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paperarchive`
--

LOCK TABLES `paperarchive` WRITE;
/*!40000 ALTER TABLE `paperarchive` DISABLE KEYS */;
/*!40000 ALTER TABLE `paperarchive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physicalfeature`
--

DROP TABLE IF EXISTS `physicalfeature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `physicalfeature` (
  `associatedWith` varchar(255) NOT NULL,
  `beginDate` varchar(255) default NULL,
  `endDate` varchar(255) default NULL,
  `picture` blob,
  `description` varchar(255) default NULL,
  UNIQUE KEY `featureIdentification` (`associatedWith`,`beginDate`),
  KEY `stationfeature` (`associatedWith`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_stationFeature` FOREIGN KEY (`associatedWith`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physicalfeature`
--

LOCK TABLES `physicalfeature` WRITE;
/*!40000 ALTER TABLE `physicalfeature` DISABLE KEYS */;
/*!40000 ALTER TABLE `physicalfeature` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physicalfeatureclass`
--

DROP TABLE IF EXISTS `physicalfeatureclass`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `physicalfeatureclass` (
  `featureClass` varchar(255) NOT NULL,
  `description` varchar(255) default NULL,
  `refersTo` varchar(255) default NULL,
  PRIMARY KEY  (`featureClass`),
  KEY `stationFeatureClass` (`featureClass`),
  KEY `FK_mysql_climsoft_db_v4_station_featureClass` (`refersTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_featureClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physicalfeatureclass`
--

LOCK TABLES `physicalfeatureclass` WRITE;
/*!40000 ALTER TABLE `physicalfeatureclass` DISABLE KEYS */;
/*!40000 ALTER TABLE `physicalfeatureclass` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qcstatusdefinition`
--

DROP TABLE IF EXISTS `qcstatusdefinition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `qcstatusdefinition` (
  `code` int(11) NOT NULL default '0',
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qcstatusdefinition`
--

LOCK TABLES `qcstatusdefinition` WRITE;
/*!40000 ALTER TABLE `qcstatusdefinition` DISABLE KEYS */;
/*!40000 ALTER TABLE `qcstatusdefinition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qctype`
--

DROP TABLE IF EXISTS `qctype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `qctype` (
  `code` int(11) NOT NULL default '0',
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qctype`
--

LOCK TABLES `qctype` WRITE;
/*!40000 ALTER TABLE `qctype` DISABLE KEYS */;
/*!40000 ALTER TABLE `qctype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `regkeys`
--

DROP TABLE IF EXISTS `regkeys`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `regkeys` (
  `keyName` varchar(255) NOT NULL default '',
  `keyData` varchar(255) default NULL,
  PRIMARY KEY  (`keyName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `regkeys`
--

LOCK TABLES `regkeys` WRITE;
/*!40000 ALTER TABLE `regkeys` DISABLE KEYS */;
/*!40000 ALTER TABLE `regkeys` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routinereportdefinition`
--

DROP TABLE IF EXISTS `routinereportdefinition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routinereportdefinition` (
  `reportClass` varchar(255) NOT NULL,
  `reportSchedule` varchar(255) default NULL,
  `reportCode` varchar(255) default NULL,
  `reportDescription` varchar(255) default NULL,
  PRIMARY KEY  (`reportClass`),
  KEY `report_code` (`reportCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routinereportdefinition`
--

LOCK TABLES `routinereportdefinition` WRITE;
/*!40000 ALTER TABLE `routinereportdefinition` DISABLE KEYS */;
/*!40000 ALTER TABLE `routinereportdefinition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routinereporttransmission`
--

DROP TABLE IF EXISTS `routinereporttransmission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routinereporttransmission` (
  `reportClass` varchar(255) default NULL,
  `reportDatetime` datetime default NULL,
  `receivedDatetime` datetime default NULL,
  `reportedFrom` varchar(255) default NULL,
  UNIQUE KEY `report` (`reportClass`,`reportDatetime`,`reportedFrom`),
  KEY `FK_mysql_climsoft_db_v4_station_routineReportTransmission` (`reportedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_routineReportTransmission` FOREIGN KEY (`reportedFrom`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_routineReportTransmissionClass` FOREIGN KEY (`reportClass`) REFERENCES `routinereportdefinition` (`reportClass`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routinereporttransmission`
--

LOCK TABLES `routinereporttransmission` WRITE;
/*!40000 ALTER TABLE `routinereporttransmission` DISABLE KEYS */;
/*!40000 ALTER TABLE `routinereporttransmission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `station`
--

DROP TABLE IF EXISTS `station`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `station` (
  `stationId` varchar(255) NOT NULL,
  `stationName` varchar(255) default NULL,
  `latitude` double(11,6) default NULL,
  `longitude` double(11,6) default NULL,
  `elevation` varchar(255) default NULL,
  `geoLocationMethod` varchar(255) default NULL,
  `geoLocationAccuracy` float(11,6) default NULL,
  `openingDatetime` datetime default NULL,
  `closingDatetime` datetime default NULL,
  `country` varchar(255) default NULL,
  `authority` varchar(255) default NULL,
  `adminRegion` varchar(255) default NULL,
  `drainageBasin` varchar(255) default NULL,
  `wacaSelection` tinyint(4) default '0',
  `cptSelection` tinyint(4) default '0',
  `stationOperational` tinyint(4) default '0',
  PRIMARY KEY  (`stationId`),
  KEY `StationStationId` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `station`
--

LOCK TABLES `station` WRITE;
/*!40000 ALTER TABLE `station` DISABLE KEYS */;
/*!40000 ALTER TABLE `station` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stationelement`
--

DROP TABLE IF EXISTS `stationelement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationelement` (
  `recordedFrom` varchar(255) default NULL,
  `describedBy` bigint(20) default NULL,
  `recordedWith` varchar(255) default NULL,
  `scheduledFor` varchar(255) default NULL,
  `height` float(6,2) default NULL,
  `beginDate` datetime default NULL,
  `endDate` datetime default NULL,
  KEY `obsElementobservationInitial` (`describedBy`),
  KEY `stationobservationInitial` (`recordedFrom`),
  KEY `FK_mysql_climsoft_db_v4_elementDescribedBy` (`describedBy`),
  KEY `FK_mysql_climsoft_db_v4_elementRecordedWith` (`recordedWith`),
  KEY `FK_mysql_climsoft_db_v4_elementScheduledFor` (`scheduledFor`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_staionRecordedFrom` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_elementDescribedBy` FOREIGN KEY (`describedBy`) REFERENCES `obselement` (`code`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_elementRecordedWith` FOREIGN KEY (`recordedWith`) REFERENCES `instrument` (`instrumentCode`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_elementScheduledFor` FOREIGN KEY (`scheduledFor`) REFERENCES `obsscheduleclass` (`scheduleClass`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stationelement`
--

LOCK TABLES `stationelement` WRITE;
/*!40000 ALTER TABLE `stationelement` DISABLE KEYS */;
/*!40000 ALTER TABLE `stationelement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stationidalias`
--

DROP TABLE IF EXISTS `stationidalias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationidalias` (
  `idAlias` varchar(255) default NULL,
  `refersTo` varchar(255) default NULL,
  `belongsTo` varchar(255) default NULL,
  `idAliasBeginDate` datetime default NULL,
  `idAliasEndDate` datetime default NULL,
  UNIQUE KEY `stationid_alias_identification` (`idAlias`),
  KEY `stationstationidAlias` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_stationIdAlias` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stationidalias`
--

LOCK TABLES `stationidalias` WRITE;
/*!40000 ALTER TABLE `stationidalias` DISABLE KEYS */;
/*!40000 ALTER TABLE `stationidalias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stationlocationhistory`
--

DROP TABLE IF EXISTS `stationlocationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationlocationhistory` (
  `belongsTo` varchar(255) default NULL,
  `stationType` varchar(255) default NULL,
  `geoLocationMethod` varchar(255) default NULL,
  `geoLocationAccuracy` float(11,6) default NULL,
  `openingDatetime` datetime default NULL,
  `closingDatetime` datetime default NULL,
  `latitude` double(11,6) default NULL,
  `longitude` double(11,6) default NULL,
  `elevation` bigint(20) default NULL,
  `authority` varchar(255) default NULL,
  `adminRegion` varchar(255) default NULL,
  `drainageBasin` varchar(255) default NULL,
  UNIQUE KEY `history` (`belongsTo`,`openingDatetime`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_stationLocationHistory` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stationlocationhistory`
--

LOCK TABLES `stationlocationhistory` WRITE;
/*!40000 ALTER TABLE `stationlocationhistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `stationlocationhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stationqualifier`
--

DROP TABLE IF EXISTS `stationqualifier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationqualifier` (
  `qualifier` varchar(255) default NULL,
  `qualifierBeginDate` datetime default NULL,
  `qualifierEndDate` datetime default NULL,
  `dataSourceTimeZone` int(11) default '0',
  `stationTimeZone` varchar(255) default NULL,
  `stationNetworkType` varchar(255) default NULL,
  `belongsTo` varchar(255) default NULL,
  UNIQUE KEY `stationid_qualifier_identification` (`qualifier`,`qualifierBeginDate`,`qualifierEndDate`,`belongsTo`),
  KEY `stationQualifierIdentification` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_qualifier` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stationqualifier`
--

LOCK TABLES `stationqualifier` WRITE;
/*!40000 ALTER TABLE `stationqualifier` DISABLE KEYS */;
/*!40000 ALTER TABLE `stationqualifier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `synopfeature`
--

DROP TABLE IF EXISTS `synopfeature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `synopfeature` (
  `abbreviation` varchar(255) NOT NULL,
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `synopfeature`
--

LOCK TABLES `synopfeature` WRITE;
/*!40000 ALTER TABLE `synopfeature` DISABLE KEYS */;
/*!40000 ALTER TABLE `synopfeature` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-04 13:43:06
