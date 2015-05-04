# NOTE: This script is for creating primary tables for the Climsoft V4 database in MySQL version 5.6 
# When editing the script, please note use of appropriate quotes symbol for enclosing database name, table names and field names 
# in MySQL version 5.6 i.e. [`] and not ['] 

# Detailed explanation about the data model are contained in the application documentation
# Addition of extra fields for local use is best done by using SQL commands on the MySQL Command Line Prompt

DROP DATABASE IF EXISTS `mysql_climsoft_db_v4`;

CREATE DATABASE `mysql_climsoft_db_v4`;

USE `mysql_climsoft_db_v4`;

#

SET FOREIGN_KEY_CHECKS=0;

# Creating Table Structure for station

#1
DROP TABLE IF EXISTS `station`;
CREATE TABLE `station` (
  `stationId` varchar(255) NOT NULL,
  `stationName` varchar(255) default NULL,
  `latitude` double(11,6) default NULL,
  `longitude` double(11,6) default NULL,
  `elevation` varchar(255) default NULL,
# Examples of geoLocationMethod are Grid referencing,GPS,GoogleEarth
  `geoLocationMethod` varchar(255) default NULL,
  `geoLocationAccuracy` float(11,6) default NULL,
  `openingDatetime` datetime default NULL,
  `closingDatetime` datetime default NULL,
  `country` varchar(255) default NULL,
  `authority` varchar(255) default NULL,
# Examples of adminRegion are district, province
  `adminRegion` varchar(255) default NULL,
#  drainageBasin is the same as catchment area
  `drainageBasin` varchar(255) default NULL,
  `wacaSelection` tinyint(4) default '0',
  `cptSelection` tinyint(4) default '0',
  `stationOperational` tinyint(4) default '0',
  PRIMARY KEY  (`stationId`),
  KEY `StationStationId` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
# Creating Table Structure for stationIdAlias
#2
DROP TABLE IF EXISTS `stationIdAlias`;
CREATE TABLE `stationIdAlias` (
  `idAlias` varchar(255) default NULL,
  `refersTo` varchar(255) default NULL,
  `belongsTo` varchar(255) default NULL,
  `idAliasBeginDate` datetime default NULL,
  `idAliasEndDate` datetime default NULL,

  UNIQUE KEY `stationid_alias_identification` (`idAlias`),
  KEY `stationstationidAlias` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_stationIdAlias` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#

#3
DROP TABLE IF EXISTS `stationQualifier`;
CREATE TABLE `stationQualifier` (
  `qualifier` varchar(255) default NULL,
  `qualifierBeginDate` datetime default NULL,
  `qualifierEndDate` datetime default NULL,
#  dataSourceTimeZone to be entered as an integer indicating deviation from UTC + or -
  `dataSourceTimeZone` int(11) default '0',
  `stationTimeZone` varchar(255) default NULL,
  `stationNetworkType` varchar(255) default NULL,
  `belongsTo` varchar(255) default NULL,
  UNIQUE KEY `stationid_qualifier_identification` (`qualifier`,`qualifierBeginDate`,`qualifierEndDate`,`belongsTo`),
  KEY `stationQualifierIdentification` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_qualifier` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#4
# Creating Table Structure for obsScheduleClass
DROP TABLE IF EXISTS `obsScheduleClass`;
CREATE TABLE `obsScheduleClass` (
  `scheduleClass` varchar(255) default NULL,
  `description` varchar(255) default NULL,
  `refersTo` varchar(255) default NULL,
  PRIMARY KEY  (`scheduleClass`),
  KEY `scheduleClassIdeification` (`scheduleClass`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_scheduleClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
  ) ENGINE=InnoDB DEFAULT CHARSET=latin1;

# Creating Table Structure for ObservationSchedule

#5
DROP TABLE IF EXISTS `observationSchedule`;
CREATE TABLE `observationSchedule` (
  `classifiedInto` varchar(255) default NULL,
  `startTime` datetime default NULL,
  `endTime` datetime default NULL,
  `interval` varchar(50) default NULL,
  `additionalObsTime` datetime default NULL,
  UNIQUE KEY `scheduleIdentification` (`classifiedInto`,`startTime`,`endTime`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obsSchedule` FOREIGN KEY (`classifiedInto`) REFERENCES `obsScheduleClass` (`scheduleClass`) 
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#6
# Creating Table Structure for physicalFeatureClass

# Site should be undesrtood to mean instrument site 
# Examples of feature class include siteExposure, siteRoughness,soilType,VegetationType, surroundingLandUse
# Pictures of siteExposure should be taken from different angles or views including arial view from above if possible
# View fro above could come from GoogleEarth

DROP TABLE IF EXISTS `physicalFeatureClass`;
CREATE TABLE `physicalFeatureClass` (
  `featureClass` varchar(255) NOT NULL,
  `description` varchar(255),
  `refersTo` varchar(255) default NULL,
  PRIMARY KEY  (`featureClass`),
 KEY `stationFeatureClass` (`featureClass`),
CONSTRAINT `FK_mysql_climsoft_db_v4_station_featureClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#7
DROP TABLE IF EXISTS `physicalFeature`;
CREATE TABLE `physicalFeature` (
   `associatedWith` varchar(255) NOT NULL,
# Fields commented out should be moved to feature class where they will be contained in a list
#  `siteExposureDescription` varchar(255) default NULL,
#  `siteRoughness` varchar(255) default NULL,
#  `siteSoilType` varchar(255) default NULL,
#  `siteVegetationtype` varchar(255) default NULL,
#  `surroundingLandUse` varchar(255) default NULL,
  `beginDate` varchar(255) default NULL,
  `endDate` varchar(255) default NULL,
  `picture` blob default NULL,
  `description` varchar(255) default NULL,
  UNIQUE KEY `featureIdentification` (`associatedWith`,`beginDate`),
  KEY `stationfeature` (`associatedWith`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_stationFeature` FOREIGN KEY (`associatedWith`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
# Creating Table Structure for stationElement
#8
  DROP TABLE IF EXISTS `stationElement`;
  CREATE TABLE `stationElement` (
  `recordedFrom` varchar(255) default NULL,
  `describedBy` bigint(20) default NULL,
  `recordedWith` varchar(255) default NULL,
  `scheduledFor` varchar(255) default NULL,
  `height` float (6,2) default NULL,
  `beginDate` datetime default NULL,
  `endDate` datetime default NULL,  
   KEY `obsElementobservationInitial` (`describedBy`),
   KEY `stationobservationInitial` (`recordedFrom`),
   CONSTRAINT `FK_mysql_climsoft_db_v4_staionRecordedFrom` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`),
   CONSTRAINT `FK_mysql_climsoft_db_v4_elementDescribedBy` FOREIGN KEY (`describedby`) REFERENCES `obsElement` (`code`),
   CONSTRAINT `FK_mysql_climsoft_db_v4_elementRecordedWith` FOREIGN KEY (`recordedWith`) REFERENCES `instrument` (`instrumentCode`),
   CONSTRAINT `FK_mysql_climsoft_db_v4_elementScheduledFor` FOREIGN KEY (`scheduledFor`) REFERENCES `obsScheduleClass` (`scheduleClass`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

# Creating Table Structure for stationLocationHistory
#9
DROP TABLE IF EXISTS `stationLocationHistory`;
CREATE TABLE `stationLocationHistory` (
  `belongsTo` varchar(255) default NULL,
  `stationType` varchar(255) default NULL,
  # Examples of geoLocationMethod are GPS, grid referencing, GoogleEarth
  `geoLocationMethod` varchar(255) default NULL,
  `geoLocationAccuracy` float(11,6) default Null,
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

# Creating Table Structure for obsElement
#10
DROP TABLE IF EXISTS `obsElement`;
CREATE TABLE `obsElement` (
  `code` bigint (20) default NULL,
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
#

# Creating Table Structure for instrument
#11
DROP TABLE IF EXISTS `instrument`;
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
  `instrumentPicture` blob default NULL,
  `installedAt` varchar(255) default NULL,
  PRIMARY KEY  (`instrumentCode`),
  KEY `code` (`instrumentCode`),
  KEY `IXFK_instrument` (`installedAt`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrument` FOREIGN KEY (`installedAt`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
# Creating Table Structure for instrumentInspection

#12
DROP TABLE IF EXISTS `instrumentInspection`;
CREATE TABLE `instrumentInspection` (
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
#
#Creating Table Structure for instrumentFaultReport
#13
DROP TABLE IF EXISTS `instrumentFaultReport`;
CREATE TABLE `instrumentFaultReport` (
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
#

# Creating Table Structure for instrumentFaulResolution
#14
DROP TABLE IF EXISTS `faultResolution`;
CREATE TABLE `faultResolution` (
  `resolvedDatetime` datetime default NULL,
  `resolvedBy` varchar(255) default NULL,
  `associatedWith` bigint(20) default NULL,
  `remarks` varchar(255) default NULL,
  UNIQUE KEY `solution` (`resolvedDatetime`,`associatedWith`),
  KEY `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` (`associatedWith`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` FOREIGN KEY (`associatedWith`) REFERENCES `instrumentFaultReport` (`reportId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

# Creating Table Structure for routineReportDefinition
# Examples of rotine reports are SYNOP, METAR, CLIMAT, TEMP
#15
DROP TABLE IF EXISTS `routineReportDefinition`;
CREATE TABLE `routineReportDefinition` (
  `reportClass` varchar(255) NOT NULL,
  `reportSchedule` varchar(255) default NULL,
  `reportCode` varchar(255) default NULL,
  `reportDescription` varchar(255) default NULL,
  PRIMARY KEY  (`reportClass`),
  KEY `report_code` (`reportCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
# Creating Table Structure for routineReportTransmission
#16
DROP TABLE IF EXISTS `routinereportTransmission`;
CREATE TABLE `routinereportTransmission` (
  `reportClass` varchar(255) default NULL,
  `reportDatetime` datetime default NULL,
  `receivedDatetime` datetime default NULL,
  `reportedFrom` varchar(255) default NULL,
  UNIQUE KEY `report` (`reportClass`,`reportDatetime`,`reportedFrom`),
  KEY `FK_mysql_climsoft_db_v4_station_routineReportTransmission` (`reportedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_routineReportTransmission` FOREIGN KEY (`reportedFrom`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_routineReportTransmissionClass` FOREIGN KEY (`reportClass`) REFERENCES `routineReportDefinition` (`reportClass`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

# Creating Table Structure for observationInitial
#17
DROP TABLE IF EXISTS `observationInitial`;
CREATE TABLE `observationInitial` (
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
 # datasourceTimeZone to be entered as an integer indicating deviation from UTC + or -
  `dataSourceTimeZone` int(11) default '0',
  KEY `obsElementObservationInitial` (`describedBy`),
  KEY `stationObservationInitial` (`recordedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_observationInitial` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obselement_observationInitial` FOREIGN KEY (`describedby`) REFERENCES `obsElement` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
# Creating Table Structure for observationFinal

#18
DROP TABLE IF EXISTS `observationFinal`;
CREATE TABLE `observationFinal` (
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
# datasourceTimeZone to be entered as an integer indicating deviation from UTC + or -
  `dataSourceTimeZone` int(11) default '0',
  KEY `obsElementObservationInitial` (`describedBy`),
  KEY `stationObservationInitial` (`recordedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_observationFinal` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obselement_observationFinal` FOREIGN KEY (`describedby`) REFERENCES `obsElement` (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
# Creating Table Structure for paperArchive

#19
DROP TABLE IF EXISTS `paperArchive`;
CREATE TABLE `paperArchive` (
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
#

# Creating Table Structure for synopFeature

#20
DROP TABLE IF EXISTS `synopFeature`;
CREATE TABLE `synopFeature` (
  `abbreviation` varchar(255) NOT NULL,
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
# Creating Table Structure for featureGeographicalPosition

#21
DROP TABLE IF EXISTS `featureGeographicalPosition`;
CREATE TABLE `featureGeographicalPosition` (
  `belongsTo` varchar(255) NOT NULL,
  `observedOn` datetime default NULL,
  `latitude` double(11,6) default NULL,
  `longitude` double(11,6) default NULL,
  CONSTRAINT `FK_mysql_climsoft_db_v4_synopfeatureFeatureGeographicalPosition` FOREIGN KEY (`belongsTo`) REFERENCES `synopFeature` (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#Additional tables that are not part of the ERD
#
# Creating Table Structure for flags

#22
DROP TABLE IF EXISTS `flags`;
CREATE TABLE `flags` (
  `characterSymbol` varchar(255) default NULL,
  `numSymbol` integer(11) default NULL,
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`characterSymbol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#23
DROP TABLE IF EXISTS `acquisitionType`;
#This table contains information about the source of observation data e.g. Key entry, GTS, CLICOM
CREATE TABLE `acquisitionType` (
  `code` integer (11) default NULL,
# Description may include URL oFTP site e.g. in the case of GTS data downloaded from NOAA-NCDC FTP site
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#24
DROP TABLE IF EXISTS `qcType`;
#This table contains information about the type of QC carried out on a data record e.g.  limits checks, inter-element comparison
CREATE TABLE `qcType` (
  `code` integer (11) default NULL,
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#25
DROP TABLE IF EXISTS `qcStatusDefinition`;
#This table contains information which indicates whether QC has been carried out on a record or not, whether the value has been modified

CREATE TABLE `qcStatusDefinition` (
  `code` integer (11) default NULL,
  `description` varchar(255) default NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#26
DROP TABLE IF EXISTS `RegKeys`;
# Replaces storage of application values in Registry. KeyData needs to be encrypted. 
CREATE TABLE `RegKeys` (
  `keyName` varchar(255) default NULL,
  `keyData` varchar(255) default NULL,
  PRIMARY KEY  (`keyName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
#
#Script for static key-entry data tables and static tables for products will be created separately. Some of the tables for products 
#shall be created on the fly
#
SET FOREIGN_KEY_CHECKS=1

