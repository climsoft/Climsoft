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
-- Table structure for table `acquisitiontype`
--

DROP TABLE IF EXISTS `acquisitiontype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acquisitiontype` (
  `code` int(11) NOT NULL DEFAULT '0',
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `faultresolution`
--

DROP TABLE IF EXISTS `faultresolution`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faultresolution` (
  `resolvedDatetime` datetime DEFAULT NULL,
  `resolvedBy` varchar(255) DEFAULT NULL,
  `associatedWith` bigint(20) DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  UNIQUE KEY `solution` (`resolvedDatetime`,`associatedWith`),
  KEY `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` (`associatedWith`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` FOREIGN KEY (`associatedWith`) REFERENCES `instrumentfaultreport` (`reportId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `featuregeographicalposition`
--

DROP TABLE IF EXISTS `featuregeographicalposition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `featuregeographicalposition` (
  `belongsTo` varchar(255) NOT NULL,
  `observedOn` datetime DEFAULT NULL,
  `latitude` double(11,6) DEFAULT NULL,
  `longitude` double(11,6) DEFAULT NULL,
  UNIQUE KEY `FK_mysql_climsoft_db_v4_synopfeatureFeatureGeographicalPosition` (`belongsTo`,`observedOn`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_synopfeatureFeatureGeographicalPosition` FOREIGN KEY (`belongsTo`) REFERENCES `synopfeature` (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `flags`
--

DROP TABLE IF EXISTS `flags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `flags` (
  `characterSymbol` varchar(255) NOT NULL DEFAULT '',
  `numSymbol` int(11) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`characterSymbol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

-- Table structure for table `instrument`
--

DROP TABLE IF EXISTS `instrument`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `instrument` (
  `instrumentName` varchar(255) DEFAULT NULL,
  `instrumentId` varchar(255) NOT NULL,
  `serialNumber` varchar(255) DEFAULT NULL,
  `abbreviation` varchar(255) DEFAULT NULL,
  `model` varchar(255) DEFAULT NULL,
  `manufacturer` varchar(255) DEFAULT NULL,
  `instrumentUncertainty` float(11,6) DEFAULT NULL,
  `installationDatetime` datetime DEFAULT NULL,
  `deinstallationDatetime` datetime DEFAULT NULL,
  `height` varchar(255) DEFAULT NULL,
  `instrumentPicture` blob,
  `installedAt` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`instrumentId`),
  KEY `code` (`instrumentId`),
  KEY `IXFK_instrument` (`installedAt`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrument` FOREIGN KEY (`installedAt`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `instrumentfaultreport`
--

DROP TABLE IF EXISTS `instrumentfaultreport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `instrumentfaultreport` (
  `refersTo` varchar(255) DEFAULT NULL,
  `reportId` bigint(20) NOT NULL,
  `reportDatetime` datetime DEFAULT NULL,
  `faultDescription` varchar(255) DEFAULT NULL,
  `reportedBy` varchar(255) DEFAULT NULL,
  `receivedDatetime` datetime DEFAULT NULL,
  `receivedBy` varchar(255) DEFAULT NULL,
  `reportedFrom` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`reportId`),
  UNIQUE KEY `instrument_report` (`refersTo`,`reportDatetime`,`reportedFrom`),
  KEY `report_id` (`reportId`),
  KEY `FK_mysql_climsoft_db_v4_station_instrumentFaultReport` (`reportedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrument_instrumentFaultReport` FOREIGN KEY (`refersTo`) REFERENCES `instrument` (`instrumentId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_instrumentFaultReport` FOREIGN KEY (`reportedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `instrumentinspection`
--

DROP TABLE IF EXISTS `instrumentinspection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `instrumentinspection` (
  `performedOn` varchar(255) DEFAULT NULL,
  `inspectionDatetime` datetime DEFAULT NULL,
  `performedBy` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `performedAt` varchar(255) DEFAULT NULL,
  UNIQUE KEY `inspection` (`performedOn`,`inspectionDatetime`),
  KEY `FK_mysql_climsoft_db_v4_station_instrumentInspection` (`performedAt`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrument_instrumentInspection` FOREIGN KEY (`performedOn`) REFERENCES `instrument` (`instrumentId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_instrumentInspection` FOREIGN KEY (`performedAt`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `obselement`
--

DROP TABLE IF EXISTS `obselement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `obselement` (
  `elementId` bigint(20) NOT NULL DEFAULT '0',
  `abbreviation` varchar(255) DEFAULT NULL,
  `elementName` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `elementScale` decimal(8,2) DEFAULT NULL,
  `upperLimit` varchar(255) DEFAULT NULL,
  `lowerLimit` varchar(255) DEFAULT NULL,
  `units` varchar(255) DEFAULT NULL,
  `elementtype` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`elementId`),
  KEY `elementCode` (`elementId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `observationfinal`
--

DROP TABLE IF EXISTS `observationfinal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `observationfinal` (
  `recordedFrom` varchar(255) NOT NULL,
  `describedBy` bigint(20) DEFAULT NULL,
  `obsDatetime` datetime DEFAULT NULL,
  `obsLevel` varchar(255) DEFAULT 'surface',
  `obsValue` decimal(8,2) DEFAULT NULL,
  `flag` varchar(255) DEFAULT 'N',
  `period` int(11) DEFAULT NULL,
  `qcStatus` int(11) DEFAULT '0',
  `qcTypeLog` text,
  `acquisitionType` int(11) DEFAULT '0',
  `dataForm` varchar(255) DEFAULT NULL,
  `capturedBy` varchar(255) DEFAULT NULL,
  `mark` tinyint(4) DEFAULT NULL,
  `temperatureUnits` varchar(255) DEFAULT NULL,
  `precipitationUnits` varchar(255) DEFAULT NULL,
  `cloudHeightUnits` varchar(255) DEFAULT NULL,
  `visUnits` varchar(255) DEFAULT NULL,
  `dataSourceTimeZone` int(11) DEFAULT '0',
  UNIQUE KEY `obsFinalIdentification` (`recordedFrom`,`describedBy`,`obsDatetime`,`qcStatus`,`acquisitionType`),
  KEY `obsElementObservationInitial` (`describedBy`),
  KEY `stationObservationInitial` (`recordedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obselement_observationFinal` FOREIGN KEY (`describedBy`) REFERENCES `obselement` (`elementId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_observationFinal` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `observationinitial`
--

DROP TABLE IF EXISTS `observationinitial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `observationinitial` (
  `recordedFrom` varchar(255) NOT NULL,
  `describedBy` bigint(20) DEFAULT NULL,
  `obsDatetime` datetime DEFAULT NULL,
  `obsLevel` varchar(255) DEFAULT NULL,
  `obsValue` varchar(255) DEFAULT NULL,
  `flag` varchar(255) DEFAULT 'N',
  `period` int(11) DEFAULT NULL,
  `qcStatus` int(11) DEFAULT '0',
  `qcTypeLog` text,
  `acquisitionType` int(11) DEFAULT '0',
  `dataForm` varchar(255) DEFAULT NULL,
  `capturedBy` varchar(255) DEFAULT NULL,
  `mark` tinyint(4) DEFAULT NULL,
  `temperatureUnits` varchar(255) DEFAULT NULL,
  `precipitationUnits` varchar(255) DEFAULT NULL,
  `cloudHeightUnits` varchar(255) DEFAULT NULL,
  `visUnits` varchar(255) DEFAULT NULL,
  `dataSourceTimeZone` int(11) DEFAULT '0',
  UNIQUE KEY `obsInitialIdentification` (`recordedFrom`,`describedBy`,`obsDatetime`,`qcStatus`,`acquisitionType`),
  KEY `obsElementObservationInitial` (`describedBy`),
  KEY `stationObservationInitial` (`recordedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obselement_observationInitial` FOREIGN KEY (`describedBy`) REFERENCES `obselement` (`elementId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_observationInitial` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `observationschedule`
--

DROP TABLE IF EXISTS `observationschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `observationschedule` (
  `classifiedInto` varchar(255) DEFAULT NULL,
  `startTime` time DEFAULT NULL,
  `endTime` time DEFAULT NULL,
  `interval` varchar(255) DEFAULT NULL,
  `additionalObsTime` varchar(255) DEFAULT NULL,
  UNIQUE KEY `scheduleIdentification` (`classifiedInto`,`startTime`,`endTime`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obsSchedule` FOREIGN KEY (`classifiedInto`) REFERENCES `obsscheduleclass` (`scheduleClass`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `obsscheduleclass`
--

DROP TABLE IF EXISTS `obsscheduleclass`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `obsscheduleclass` (
  `scheduleClass` varchar(255) NOT NULL DEFAULT '',
  `description` varchar(255) DEFAULT NULL,
  `refersTo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`scheduleClass`),
  KEY `scheduleClassIdeification` (`scheduleClass`),
  KEY `FK_mysql_climsoft_db_v4_station_scheduleClass` (`refersTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_scheduleClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `paperarchive`
--

DROP TABLE IF EXISTS `paperarchive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paperarchive` (
  `belongsTo` varchar(255) DEFAULT NULL,
  `code` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `year` int(11) DEFAULT NULL,
  `month` int(11) DEFAULT NULL,
  `day` int(11) DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  UNIQUE KEY `paper_archive_identification` (`belongsTo`,`code`,`year`,`month`,`day`),
  KEY `stationpaperArchive` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_paperArchive` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `physicalfeature`
--

DROP TABLE IF EXISTS `physicalfeature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `physicalfeature` (
  `associatedWith` varchar(255) NOT NULL,
  `beginDate` datetime DEFAULT NULL,
  `endDate` datetime DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `classifiedInto` varchar(255) DEFAULT NULL,
  UNIQUE KEY `featureIdentification` (`associatedWith`,`beginDate`,`classifiedInto`,`description`),
  KEY `stationfeature` (`associatedWith`),
  KEY `physicalFeatureidentification_idx` (`classifiedInto`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_stationFeature` FOREIGN KEY (`associatedWith`) REFERENCES `station` (`stationId`),
  CONSTRAINT `physicalFeatureidentification` FOREIGN KEY (`classifiedInto`) REFERENCES `physicalfeatureclass` (`featureClass`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `physicalfeatureclass`
--

DROP TABLE IF EXISTS `physicalfeatureclass`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `physicalfeatureclass` (
  `featureClass` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `refersTo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`featureClass`),
  KEY `stationFeatureClass` (`featureClass`),
  KEY `FK_mysql_climsoft_db_v4_station_featureClass` (`refersTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_featureClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `qcstatusdefinition`
--

DROP TABLE IF EXISTS `qcstatusdefinition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `qcstatusdefinition` (
  `code` int(11) NOT NULL DEFAULT '0',
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `qctype`
--

DROP TABLE IF EXISTS `qctype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `qctype` (
  `code` int(11) NOT NULL DEFAULT '0',
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `regkeys`
--

DROP TABLE IF EXISTS `regkeys`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `regkeys` (
  `keyName` varchar(255) NOT NULL DEFAULT '',
  `keyData` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`keyName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `routinereportdefinition`
--

DROP TABLE IF EXISTS `routinereportdefinition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routinereportdefinition` (
  `reportClass` varchar(255) NOT NULL,
  `reportSchedule` varchar(255) DEFAULT NULL,
  `reportCode` varchar(255) DEFAULT NULL,
  `reportDescription` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`reportClass`),
  KEY `report_code` (`reportCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `routinereporttransmission`
--

DROP TABLE IF EXISTS `routinereporttransmission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routinereporttransmission` (
  `reportClass` varchar(255) DEFAULT NULL,
  `reportDatetime` datetime DEFAULT NULL,
  `receivedDatetime` datetime DEFAULT NULL,
  `reportedFrom` varchar(255) DEFAULT NULL,
  UNIQUE KEY `report` (`reportClass`,`reportDatetime`,`reportedFrom`),
  KEY `FK_mysql_climsoft_db_v4_station_routineReportTransmission` (`reportedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_routineReportTransmissionClass` FOREIGN KEY (`reportClass`) REFERENCES `routinereportdefinition` (`reportClass`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_routineReportTransmission` FOREIGN KEY (`reportedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `station`
--

DROP TABLE IF EXISTS `station`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `station` (
  `stationId` varchar(255) NOT NULL,
  `stationName` varchar(255) DEFAULT NULL,
  `latitude` double(11,6) DEFAULT NULL,
  `longitude` double(11,6) DEFAULT NULL,
  `elevation` varchar(255) DEFAULT NULL,
  `geoLocationMethod` varchar(255) DEFAULT NULL,
  `geoLocationAccuracy` float(11,6) DEFAULT NULL,
  `openingDatetime` datetime DEFAULT NULL,
  `closingDatetime` datetime DEFAULT NULL,
  `country` varchar(255) DEFAULT NULL,
  `authority` varchar(255) DEFAULT NULL,
  `adminRegion` varchar(255) DEFAULT NULL,
  `drainageBasin` varchar(255) DEFAULT NULL,
  `wacaSelection` tinyint(4) DEFAULT '0',
  `cptSelection` tinyint(4) DEFAULT '0',
  `stationOperational` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`stationId`),
  KEY `StationStationId` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `stationelement`
--

DROP TABLE IF EXISTS `stationelement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationelement` (
  `recordedFrom` varchar(255) DEFAULT NULL,
  `describedBy` bigint(20) DEFAULT NULL,
  `recordedWith` varchar(255) DEFAULT NULL,
  `scheduledFor` varchar(255) DEFAULT NULL,
  `height` float(6,2) DEFAULT NULL,
  `beginDate` datetime DEFAULT NULL,
  `endDate` datetime DEFAULT NULL,
  UNIQUE KEY `stationElementIdentification` (`recordedFrom`,`describedBy`,`recordedWith`,`beginDate`),
  KEY `obsElementobservationInitial` (`describedBy`),
  KEY `stationobservationInitial` (`recordedFrom`),
  KEY `FK_mysql_climsoft_db_v4_elementRecordedWith` (`recordedWith`),
  KEY `FK_mysql_climsoft_db_v4_elementScheduledFor` (`scheduledFor`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_elementDescribedBy` FOREIGN KEY (`describedBy`) REFERENCES `obselement` (`elementId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_elementRecordedWith` FOREIGN KEY (`recordedWith`) REFERENCES `instrument` (`instrumentId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_elementScheduledFor` FOREIGN KEY (`scheduledFor`) REFERENCES `obsscheduleclass` (`scheduleClass`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_staionRecordedFrom` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `stationidalias`
--

DROP TABLE IF EXISTS `stationidalias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationidalias` (
  `idAlias` varchar(255) DEFAULT NULL,
  `refersTo` varchar(255) DEFAULT NULL,
  `belongsTo` varchar(255) DEFAULT NULL,
  `idAliasBeginDate` datetime DEFAULT NULL,
  `idAliasEndDate` datetime DEFAULT NULL,
  UNIQUE KEY `stationid_alias_identification` (`idAlias`),
  KEY `stationstationidAlias` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_stationIdAlias` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `stationlocationhistory`
--

DROP TABLE IF EXISTS `stationlocationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationlocationhistory` (
  `belongsTo` varchar(255) DEFAULT NULL,
  `stationType` varchar(255) DEFAULT NULL,
  `geoLocationMethod` varchar(255) DEFAULT NULL,
  `geoLocationAccuracy` float(11,6) DEFAULT NULL,
  `openingDatetime` datetime DEFAULT NULL,
  `closingDatetime` datetime DEFAULT NULL,
  `latitude` double(11,6) DEFAULT NULL,
  `longitude` double(11,6) DEFAULT NULL,
  `elevation` bigint(20) DEFAULT NULL,
  `authority` varchar(255) DEFAULT NULL,
  `adminRegion` varchar(255) DEFAULT NULL,
  `drainageBasin` varchar(255) DEFAULT NULL,
  UNIQUE KEY `history` (`belongsTo`,`openingDatetime`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_stationLocationHistory` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `stationnetworkdefinition`
--

DROP TABLE IF EXISTS `stationnetworkdefinition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationnetworkdefinition` (
  `networkAbbreviation` varchar(255) NOT NULL DEFAULT '',
  `networkFullName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`networkAbbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `stationqualifier`
--

DROP TABLE IF EXISTS `stationqualifier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stationqualifier` (
  `qualifier` varchar(255) DEFAULT NULL,
  `qualifierBeginDate` datetime DEFAULT NULL,
  `qualifierEndDate` datetime DEFAULT NULL,
  `stationTimeZone` int(11) DEFAULT '0',
  `stationNetworkType` varchar(255) DEFAULT NULL,
  `belongsTo` varchar(255) DEFAULT NULL,
  UNIQUE KEY `stationid_qualifier_identification` (`qualifier`,`qualifierBeginDate`,`qualifierEndDate`,`belongsTo`),
  KEY `stationQualifierIdentification` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_qualifier` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `synopfeature`
--

DROP TABLE IF EXISTS `synopfeature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `synopfeature` (
  `abbreviation` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-04 23:50:06
