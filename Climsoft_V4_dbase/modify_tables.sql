-- Dumping database structure for mariadb_climsoft_db_v4
-- CREATE DATABASE IF NOT EXISTS `mariadb_climsoft_db_v4` /*!40100 DEFAULT CHARACTER SET latin1 */;
-- USE `mariadb_climsoft_db_v4`;

ALTER TABLE `station`
	ADD COLUMN IF NOT EXISTS `icaoid` VARCHAR(20) NULL DEFAULT NULL AFTER `stationName`,
	ADD COLUMN IF NOT EXISTS `wmoid` VARCHAR(20) NULL DEFAULT NULL AFTER `stationName`,
	ADD COLUMN IF NOT EXISTS `qualifier` VARCHAR(20) NULL DEFAULT NULL AFTER `latitude`,
	CHANGE COLUMN IF EXISTS `openingDatetime` `openingDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `geoLocationAccuracy`,
	CHANGE COLUMN IF EXISTS `closingDatetime` `closingDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `openingDatetime`;
ALTER TABLE `instrument`
	CHANGE COLUMN IF EXISTS `installationDatetime` `installationDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `instrumentUncertainty`,
	CHANGE COLUMN IF EXISTS `deinstallationDatetime` `deinstallationDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `installationDatetime`,
	CHANGE COLUMN IF EXISTS `instrumentPicture` `instrumentPicture` CHAR(255) NULL AFTER `height`,
	ADD COLUMN IF NOT EXISTS `installedAt` VARCHAR(50) NULL DEFAULT NULL AFTER `instrumentPicture`;
ALTER TABLE `stationelement`
	ADD COLUMN IF NOT EXISTS `instrumentcode` VARCHAR(6) NULL DEFAULT NULL AFTER `recordedWith`,
	CHANGE COLUMN IF EXISTS `beginDate` `beginDate` VARCHAR(50) NULL DEFAULT NULL AFTER `height`,
	CHANGE COLUMN IF EXISTS `endDate` `endDate` VARCHAR(50) NULL DEFAULT NULL AFTER `beginDate`;
ALTER TABLE `obselement`
	ADD COLUMN IF NOT EXISTS `selected` TINYINT(4) NULL DEFAULT '0' AFTER `qcTotalRequired`;
ALTER TABLE `form_synoptic_2_ra1`
	CHANGE COLUMN IF EXISTS `Val_Elem196` `Val_Elem185` VARCHAR(6) NULL DEFAULT NULL AFTER `Val_Elem301`,
	CHANGE COLUMN IF EXISTS `Flag196` `Flag185` VARCHAR(1) NULL DEFAULT NULL AFTER `Flag301`,
	CHANGE COLUMN IF EXISTS `Val_Elem176` `Val_Elem192` VARCHAR(6) NULL DEFAULT NULL AFTER `Val_Elem105`,
	CHANGE COLUMN IF EXISTS `Flag176` `Flag192` VARCHAR(1) NULL DEFAULT NULL AFTER `Flag105`,
	CHANGE COLUMN IF EXISTS `Val_Elem177` `Val_Elem168` VARCHAR(6) NULL DEFAULT NULL AFTER `Val_Elem115`,
	CHANGE COLUMN IF EXISTS `Flag177` `Flag168` VARCHAR(1) NULL DEFAULT NULL AFTER `Flag115`;
ALTER TABLE `physicalfeature`
	CHANGE COLUMN IF EXISTS `beginDate` `beginDate` VARCHAR(50) NULL DEFAULT NULL AFTER `associatedWith`,
	CHANGE COLUMN IF EXISTS `endDate` `endDate` VARCHAR(50) NULL DEFAULT NULL AFTER `beginDate`;
ALTER TABLE `observationschedule`
	CHANGE COLUMN IF EXISTS `startTime` `startTime` VARCHAR(50) NULL DEFAULT NULL AFTER `classifiedInto`,
	CHANGE COLUMN IF EXISTS `endTime` `endTime` VARCHAR(50) NULL DEFAULT NULL AFTER `startTime`;
ALTER TABLE `instrumentinspection`
	CHANGE COLUMN IF EXISTS `inspectionDatetime` `inspectionDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `performedOn`;
ALTER TABLE `instrumentfaultreport`
	CHANGE COLUMN IF EXISTS `reportDatetime` `reportDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `reportId`,
	CHANGE COLUMN IF EXISTS `receivedDatetime` `receivedDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `reportedBy`;
ALTER TABLE `featuregeographicalposition`
	CHANGE COLUMN IF EXISTS `observedOn` `observedOn` VARCHAR(50) NULL DEFAULT NULL AFTER `belongsTo`;
ALTER TABLE `faultresolution`
	CHANGE COLUMN IF EXISTS `resolvedDatetime` `resolvedDatetime` VARCHAR(50) NULL DEFAULT NULL FIRST;
ALTER TABLE `stationidalias`
	CHANGE COLUMN IF EXISTS `idAliasBeginDate` `idAliasBeginDate` VARCHAR(50) NULL DEFAULT NULL AFTER `belongsTo`,
	CHANGE COLUMN IF EXISTS `idAliasEndDate` `idAliasEndDate` VARCHAR(50) NULL DEFAULT NULL AFTER `idAliasBeginDate`;
ALTER TABLE `stationlocationhistory`
	CHANGE COLUMN IF EXISTS `openingDatetime` `openingDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `geoLocationAccuracy`,
	CHANGE COLUMN IF EXISTS `closingDatetime` `closingDatetime` VARCHAR(50) NULL DEFAULT NULL AFTER `openingDatetime`;
ALTER TABLE `stationqualifier`
	CHANGE COLUMN IF EXISTS `qualifierBeginDate` `qualifierBeginDate` VARCHAR(50) NULL DEFAULT NULL AFTER `qualifier`,
	CHANGE COLUMN IF EXISTS `qualifierEndDate` `qualifierEndDate` VARCHAR(50) NULL DEFAULT NULL AFTER `qualifierBeginDate`;
ALTER TABLE `form_synoptic_2_ra1`
	CHANGE COLUMN IF EXISTS `Val_Elem196` `Val_Elem185` VARCHAR(6) NULL DEFAULT NULL AFTER `Val_Elem301`,
	CHANGE COLUMN IF EXISTS `Flag196` `Flag185` VARCHAR(1) NULL DEFAULT NULL AFTER `Flag301`,
	CHANGE COLUMN IF EXISTS `Val_Elem176` `Val_Elem192` VARCHAR(6) NULL DEFAULT NULL AFTER `Val_Elem105`,
	CHANGE COLUMN IF EXISTS `Flag176` `Flag192` VARCHAR(1) NULL DEFAULT NULL AFTER `Flag105`,
	CHANGE COLUMN IF EXISTS `Val_Elem177` `Val_Elem168` VARCHAR(6) NULL DEFAULT NULL AFTER `Val_Elem115`,
	CHANGE COLUMN IF EXISTS `Flag177` `Flag168` VARCHAR(1) NULL DEFAULT NULL AFTER `Flag115`;
ALTER TABLE `aws_sites` ADD COLUMN `GTSEncode` VARCHAR(20) NULL AFTER `OperationalStatus`;
ALTER TABLE `aws_sites` ADD COLUMN `GTSHeader` VARCHAR(20) NULL AFTER `GTSEncode`;


