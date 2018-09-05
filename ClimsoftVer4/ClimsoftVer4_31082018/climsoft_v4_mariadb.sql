-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.7-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.1.0.4867
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for mariadb_climsoft_db_v4
DROP DATABASE IF EXISTS `mariadb_climsoft_db_v4`;
CREATE DATABASE IF NOT EXISTS `mariadb_climsoft_db_v4` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `mariadb_climsoft_db_v4`;


-- Dumping structure for table mariadb_climsoft_db_v4.acquisitiontype
DROP TABLE IF EXISTS `acquisitiontype`;
CREATE TABLE IF NOT EXISTS `acquisitiontype` (
  `code` int(11) NOT NULL DEFAULT '0',
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.data_forms
DROP TABLE IF EXISTS `data_forms`;
CREATE TABLE IF NOT EXISTS `data_forms` (
  `id` bigint(20) NOT NULL DEFAULT '0',
  `order_num` bigint(20) DEFAULT '0',
  `table_name` varchar(255) DEFAULT NULL,
  `form_name` varchar(250) DEFAULT NULL,
  `description` text,
  `selected` tinyint(4) DEFAULT NULL,
  `val_start_position` bigint(20) DEFAULT '0',
  `val_end_position` bigint(20) DEFAULT '0',
  `elem_code_location` varchar(255) DEFAULT NULL,
  `sequencer` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `identification` (`form_name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.faultresolution
DROP TABLE IF EXISTS `faultresolution`;
CREATE TABLE IF NOT EXISTS `faultresolution` (
  `resolvedDatetime` datetime DEFAULT NULL,
  `resolvedBy` varchar(255) DEFAULT NULL,
  `associatedWith` bigint(20) DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  UNIQUE KEY `solution` (`resolvedDatetime`,`associatedWith`),
  KEY `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` (`associatedWith`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_instrumentFaultReport_faultResolution` FOREIGN KEY (`associatedWith`) REFERENCES `instrumentfaultreport` (`reportId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.featuregeographicalposition
DROP TABLE IF EXISTS `featuregeographicalposition`;
CREATE TABLE IF NOT EXISTS `featuregeographicalposition` (
  `belongsTo` varchar(255) NOT NULL,
  `observedOn` datetime DEFAULT NULL,
  `latitude` double(11,6) DEFAULT NULL,
  `longitude` double(11,6) DEFAULT NULL,
  UNIQUE KEY `FK_mysql_climsoft_db_v4_synopfeatureFeatureGeographicalPosition` (`belongsTo`,`observedOn`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_synopfeatureFeatureGeographicalPosition` FOREIGN KEY (`belongsTo`) REFERENCES `synopfeature` (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.flags
DROP TABLE IF EXISTS `flags`;
CREATE TABLE IF NOT EXISTS `flags` (
  `characterSymbol` varchar(255) NOT NULL DEFAULT '',
  `numSymbol` int(11) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`characterSymbol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.form_daily2
DROP TABLE IF EXISTS `form_daily2`;
CREATE TABLE IF NOT EXISTS `form_daily2` (
  `stationId` varchar(50) NOT NULL,
  `elementId` int(11) NOT NULL,
  `yyyy` int(11) NOT NULL,
  `mm` int(11) NOT NULL,
  `hh` int(11) NOT NULL,
  `day01` varchar(45) DEFAULT NULL,
  `day02` varchar(45) DEFAULT NULL,
  `day03` varchar(45) DEFAULT NULL,
  `day04` varchar(45) DEFAULT NULL,
  `day05` varchar(45) DEFAULT NULL,
  `day06` varchar(45) DEFAULT NULL,
  `day07` varchar(45) DEFAULT NULL,
  `day08` varchar(45) DEFAULT NULL,
  `day09` varchar(45) DEFAULT NULL,
  `day10` varchar(45) DEFAULT NULL,
  `day11` varchar(45) DEFAULT NULL,
  `day12` varchar(45) DEFAULT NULL,
  `day13` varchar(45) DEFAULT NULL,
  `day14` varchar(45) DEFAULT NULL,
  `day15` varchar(45) DEFAULT NULL,
  `day16` varchar(45) DEFAULT NULL,
  `day17` varchar(45) DEFAULT NULL,
  `day18` varchar(45) DEFAULT NULL,
  `day19` varchar(45) DEFAULT NULL,
  `day20` varchar(45) DEFAULT NULL,
  `day21` varchar(45) DEFAULT NULL,
  `day22` varchar(45) DEFAULT NULL,
  `day23` varchar(45) DEFAULT NULL,
  `day24` varchar(45) DEFAULT NULL,
  `day25` varchar(45) DEFAULT NULL,
  `day26` varchar(45) DEFAULT NULL,
  `day27` varchar(45) DEFAULT NULL,
  `day28` varchar(45) DEFAULT NULL,
  `day29` varchar(45) DEFAULT NULL,
  `day30` varchar(45) DEFAULT NULL,
  `day31` varchar(45) DEFAULT NULL,
  `flag01` varchar(1) DEFAULT NULL,
  `flag02` varchar(1) DEFAULT NULL,
  `flag03` varchar(1) DEFAULT NULL,
  `flag04` varchar(1) DEFAULT NULL,
  `flag05` varchar(1) DEFAULT NULL,
  `flag06` varchar(1) DEFAULT NULL,
  `flag07` varchar(1) DEFAULT NULL,
  `flag08` varchar(1) DEFAULT NULL,
  `flag09` varchar(1) DEFAULT NULL,
  `flag10` varchar(1) DEFAULT NULL,
  `flag11` varchar(1) DEFAULT NULL,
  `flag12` varchar(1) DEFAULT NULL,
  `flag13` varchar(1) DEFAULT NULL,
  `flag14` varchar(1) DEFAULT NULL,
  `flag15` varchar(1) DEFAULT NULL,
  `flag16` varchar(1) DEFAULT NULL,
  `flag17` varchar(1) DEFAULT NULL,
  `flag18` varchar(1) DEFAULT NULL,
  `flag19` varchar(1) DEFAULT NULL,
  `flag20` varchar(1) DEFAULT NULL,
  `flag21` varchar(1) DEFAULT NULL,
  `flag22` varchar(1) DEFAULT NULL,
  `flag23` varchar(1) DEFAULT NULL,
  `flag24` varchar(1) DEFAULT NULL,
  `flag25` varchar(1) DEFAULT NULL,
  `flag26` varchar(1) DEFAULT NULL,
  `flag27` varchar(1) DEFAULT NULL,
  `flag28` varchar(1) DEFAULT NULL,
  `flag29` varchar(1) DEFAULT NULL,
  `flag30` varchar(1) DEFAULT NULL,
  `flag31` varchar(1) DEFAULT NULL,
  `period01` varchar(45) DEFAULT NULL,
  `period02` varchar(45) DEFAULT NULL,
  `period03` varchar(45) DEFAULT NULL,
  `period04` varchar(45) DEFAULT NULL,
  `period05` varchar(45) DEFAULT NULL,
  `period06` varchar(45) DEFAULT NULL,
  `period07` varchar(45) DEFAULT NULL,
  `period08` varchar(45) DEFAULT NULL,
  `period09` varchar(45) DEFAULT NULL,
  `period10` varchar(45) DEFAULT NULL,
  `period11` varchar(45) DEFAULT NULL,
  `period12` varchar(45) DEFAULT NULL,
  `period13` varchar(45) DEFAULT NULL,
  `period14` varchar(45) DEFAULT NULL,
  `period15` varchar(45) DEFAULT NULL,
  `period16` varchar(45) DEFAULT NULL,
  `period17` varchar(45) DEFAULT NULL,
  `period18` varchar(45) DEFAULT NULL,
  `period19` varchar(45) DEFAULT NULL,
  `period20` varchar(45) DEFAULT NULL,
  `period21` varchar(45) DEFAULT NULL,
  `period22` varchar(45) DEFAULT NULL,
  `period23` varchar(45) DEFAULT NULL,
  `period24` varchar(45) DEFAULT NULL,
  `period25` varchar(45) DEFAULT NULL,
  `period26` varchar(45) DEFAULT NULL,
  `period27` varchar(45) DEFAULT NULL,
  `period28` varchar(45) DEFAULT NULL,
  `period29` varchar(45) DEFAULT NULL,
  `period30` varchar(45) DEFAULT NULL,
  `period31` varchar(45) DEFAULT NULL,
  `total` varchar(45) DEFAULT NULL,
  `signature` varchar(45) DEFAULT NULL,
  `temperatureUnits` varchar(45) DEFAULT NULL,
  `precipUnits` varchar(45) DEFAULT NULL,
  `cloudHeightUnits` varchar(45) DEFAULT NULL,
  `visUnits` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`stationId`,`elementId`,`yyyy`,`mm`,`hh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.form_hourly
DROP TABLE IF EXISTS `form_hourly`;
CREATE TABLE IF NOT EXISTS `form_hourly` (
  `stationId` varchar(50) NOT NULL,
  `elementId` int(11) NOT NULL,
  `yyyy` int(11) NOT NULL,
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  `hh_00` varchar(50) DEFAULT NULL,
  `hh_01` varchar(50) DEFAULT NULL,
  `hh_02` varchar(50) DEFAULT NULL,
  `hh_03` varchar(50) DEFAULT NULL,
  `hh_04` varchar(50) DEFAULT NULL,
  `hh_05` varchar(50) DEFAULT NULL,
  `hh_06` varchar(50) DEFAULT NULL,
  `hh_07` varchar(50) DEFAULT NULL,
  `hh_08` varchar(50) DEFAULT NULL,
  `hh_09` varchar(50) DEFAULT NULL,
  `hh_10` varchar(50) DEFAULT NULL,
  `hh_11` varchar(50) DEFAULT NULL,
  `hh_12` varchar(50) DEFAULT NULL,
  `hh_13` varchar(50) DEFAULT NULL,
  `hh_14` varchar(50) DEFAULT NULL,
  `hh_15` varchar(50) DEFAULT NULL,
  `hh_16` varchar(50) DEFAULT NULL,
  `hh_17` varchar(50) DEFAULT NULL,
  `hh_18` varchar(50) DEFAULT NULL,
  `hh_19` varchar(50) DEFAULT NULL,
  `hh_20` varchar(50) DEFAULT NULL,
  `hh_21` varchar(50) DEFAULT NULL,
  `hh_22` varchar(50) DEFAULT NULL,
  `hh_23` varchar(50) DEFAULT NULL,
  `flag00` varchar(50) DEFAULT NULL,
  `flag01` varchar(50) DEFAULT NULL,
  `flag02` varchar(50) DEFAULT NULL,
  `flag03` varchar(50) DEFAULT NULL,
  `flag04` varchar(50) DEFAULT NULL,
  `flag05` varchar(50) DEFAULT NULL,
  `flag06` varchar(50) DEFAULT NULL,
  `flag07` varchar(50) DEFAULT NULL,
  `flag08` varchar(50) DEFAULT NULL,
  `flag09` varchar(50) DEFAULT NULL,
  `flag10` varchar(50) DEFAULT NULL,
  `flag11` varchar(50) DEFAULT NULL,
  `flag12` varchar(50) DEFAULT NULL,
  `flag13` varchar(50) DEFAULT NULL,
  `flag14` varchar(50) DEFAULT NULL,
  `flag15` varchar(50) DEFAULT NULL,
  `flag16` varchar(50) DEFAULT NULL,
  `flag17` varchar(50) DEFAULT NULL,
  `flag18` varchar(50) DEFAULT NULL,
  `flag19` varchar(50) DEFAULT NULL,
  `flag20` varchar(50) DEFAULT NULL,
  `flag21` varchar(50) DEFAULT NULL,
  `flag22` varchar(50) DEFAULT NULL,
  `flag23` varchar(50) DEFAULT NULL,
  `total` varchar(50) DEFAULT NULL,
  `signature` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`stationId`,`elementId`,`yyyy`,`mm`,`dd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.form_hourlywind
DROP TABLE IF EXISTS `form_hourlywind`;
CREATE TABLE IF NOT EXISTS `form_hourlywind` (
  `stationId` varchar(255) NOT NULL,
  `yyyy` int(11) NOT NULL,
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  `elem_112_00` varchar(255) DEFAULT NULL,
  `elem_112_01` varchar(255) DEFAULT NULL,
  `elem_112_02` varchar(255) DEFAULT NULL,
  `elem_112_03` varchar(255) DEFAULT NULL,
  `elem_112_04` varchar(255) DEFAULT NULL,
  `elem_112_05` varchar(255) DEFAULT NULL,
  `elem_112_06` varchar(255) DEFAULT NULL,
  `elem_112_07` varchar(255) DEFAULT NULL,
  `elem_112_08` varchar(255) DEFAULT NULL,
  `elem_112_09` varchar(255) DEFAULT NULL,
  `elem_112_10` varchar(255) DEFAULT NULL,
  `elem_112_11` varchar(255) DEFAULT NULL,
  `elem_112_12` varchar(255) DEFAULT NULL,
  `elem_112_13` varchar(255) DEFAULT NULL,
  `elem_112_14` varchar(255) DEFAULT NULL,
  `elem_112_15` varchar(255) DEFAULT NULL,
  `elem_112_16` varchar(255) DEFAULT NULL,
  `elem_112_17` varchar(255) DEFAULT NULL,
  `elem_112_18` varchar(255) DEFAULT NULL,
  `elem_112_19` varchar(255) DEFAULT NULL,
  `elem_112_20` varchar(255) DEFAULT NULL,
  `elem_112_21` varchar(255) DEFAULT NULL,
  `elem_112_22` varchar(255) DEFAULT NULL,
  `elem_112_23` varchar(255) DEFAULT NULL,
  `ddflag00` varchar(255) DEFAULT NULL,
  `ddflag01` varchar(255) DEFAULT NULL,
  `ddflag02` varchar(255) DEFAULT NULL,
  `ddflag03` varchar(255) DEFAULT NULL,
  `ddflag04` varchar(255) DEFAULT NULL,
  `ddflag05` varchar(255) DEFAULT NULL,
  `ddflag06` varchar(255) DEFAULT NULL,
  `ddflag07` varchar(255) DEFAULT NULL,
  `ddflag08` varchar(255) DEFAULT NULL,
  `ddflag09` varchar(255) DEFAULT NULL,
  `ddflag10` varchar(255) DEFAULT NULL,
  `ddflag11` varchar(255) DEFAULT NULL,
  `ddflag12` varchar(255) DEFAULT NULL,
  `ddflag13` varchar(255) DEFAULT NULL,
  `ddflag14` varchar(255) DEFAULT NULL,
  `ddflag15` varchar(255) DEFAULT NULL,
  `ddflag16` varchar(255) DEFAULT NULL,
  `ddflag17` varchar(255) DEFAULT NULL,
  `ddflag18` varchar(255) DEFAULT NULL,
  `ddflag19` varchar(255) DEFAULT NULL,
  `ddflag20` varchar(255) DEFAULT NULL,
  `ddflag21` varchar(255) DEFAULT NULL,
  `ddflag22` varchar(255) DEFAULT NULL,
  `ddflag23` varchar(255) DEFAULT NULL,
  `elem_111_00` varchar(255) DEFAULT NULL,
  `elem_111_01` varchar(255) DEFAULT NULL,
  `elem_111_02` varchar(255) DEFAULT NULL,
  `elem_111_03` varchar(255) DEFAULT NULL,
  `elem_111_04` varchar(255) DEFAULT NULL,
  `elem_111_05` varchar(255) DEFAULT NULL,
  `elem_111_06` varchar(255) DEFAULT NULL,
  `elem_111_07` varchar(255) DEFAULT NULL,
  `elem_111_08` varchar(255) DEFAULT NULL,
  `elem_111_09` varchar(255) DEFAULT NULL,
  `elem_111_10` varchar(255) DEFAULT NULL,
  `elem_111_11` varchar(255) DEFAULT NULL,
  `elem_111_12` varchar(255) DEFAULT NULL,
  `elem_111_13` varchar(255) DEFAULT NULL,
  `elem_111_14` varchar(255) DEFAULT NULL,
  `elem_111_15` varchar(255) DEFAULT NULL,
  `elem_111_16` varchar(255) DEFAULT NULL,
  `elem_111_17` varchar(255) DEFAULT NULL,
  `elem_111_18` varchar(255) DEFAULT NULL,
  `elem_111_19` varchar(255) DEFAULT NULL,
  `elem_111_20` varchar(255) DEFAULT NULL,
  `elem_111_21` varchar(255) DEFAULT NULL,
  `elem_111_22` varchar(255) DEFAULT NULL,
  `elem_111_23` varchar(255) DEFAULT NULL,
  `total` varchar(50) DEFAULT NULL,
  `signature` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`stationId`,`yyyy`,`mm`,`dd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.form_monthly
DROP TABLE IF EXISTS `form_monthly`;
CREATE TABLE IF NOT EXISTS `form_monthly` (
  `stationId` varchar(255) DEFAULT NULL,
  `elementId` int(11) DEFAULT NULL,
  `yyyy` int(11) DEFAULT NULL,
  `mm_01` varchar(255) DEFAULT NULL,
  `mm_02` varchar(255) DEFAULT NULL,
  `mm_03` varchar(255) DEFAULT NULL,
  `mm_04` varchar(255) DEFAULT NULL,
  `mm_05` varchar(255) DEFAULT NULL,
  `mm_06` varchar(255) DEFAULT NULL,
  `mm_07` varchar(255) DEFAULT NULL,
  `mm_08` varchar(255) DEFAULT NULL,
  `mm_09` varchar(255) DEFAULT NULL,
  `mm_10` varchar(255) DEFAULT NULL,
  `mm_11` varchar(255) DEFAULT NULL,
  `mm_12` varchar(255) DEFAULT NULL,
  `flag01` varchar(255) DEFAULT NULL,
  `flag02` varchar(255) DEFAULT NULL,
  `flag03` varchar(255) DEFAULT NULL,
  `flag04` varchar(255) DEFAULT NULL,
  `flag05` varchar(255) DEFAULT NULL,
  `flag06` varchar(255) DEFAULT NULL,
  `flag07` varchar(255) DEFAULT NULL,
  `flag08` varchar(255) DEFAULT NULL,
  `flag09` varchar(255) DEFAULT NULL,
  `flag10` varchar(255) DEFAULT NULL,
  `flag11` varchar(255) DEFAULT NULL,
  `flag12` varchar(255) DEFAULT NULL,
  `period01` varchar(255) DEFAULT NULL,
  `period02` varchar(255) DEFAULT NULL,
  `period03` varchar(255) DEFAULT NULL,
  `period04` varchar(255) DEFAULT NULL,
  `period05` varchar(255) DEFAULT NULL,
  `period06` varchar(255) DEFAULT NULL,
  `period07` varchar(255) DEFAULT NULL,
  `period08` varchar(255) DEFAULT NULL,
  `period09` varchar(255) DEFAULT NULL,
  `period10` varchar(255) DEFAULT NULL,
  `period11` varchar(255) DEFAULT NULL,
  `period12` varchar(255) DEFAULT NULL,
  `signature` varchar(50) DEFAULT NULL,
  UNIQUE KEY `identification` (`stationId`,`elementId`,`yyyy`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.form_synoptic2_tdcf
DROP TABLE IF EXISTS `form_synoptic2_tdcf`;
CREATE TABLE IF NOT EXISTS `form_synoptic2_tdcf` (
  `stationId` varchar(10) NOT NULL,
  `yyyy` bigint(20) NOT NULL,
  `mm` bigint(20) NOT NULL,
  `dd` bigint(20) NOT NULL,
  `hh` varchar(5) NOT NULL,
  `106` varchar(6) DEFAULT NULL,
  `107` varchar(6) DEFAULT NULL,
  `399` varchar(5) DEFAULT NULL,
  `301` varchar(8) DEFAULT NULL,
  `185` varchar(6) DEFAULT NULL,
  `101` varchar(5) DEFAULT NULL,
  `103` varchar(5) DEFAULT NULL,
  `105` varchar(50) DEFAULT NULL,
  `110` varchar(5) DEFAULT NULL,
  `114` varchar(5) DEFAULT NULL,
  `115` varchar(5) DEFAULT NULL,
  `168` varchar(5) DEFAULT NULL,
  `192` varchar(5) DEFAULT NULL,
  `169` varchar(5) DEFAULT NULL,
  `170` varchar(5) DEFAULT NULL,
  `171` varchar(5) DEFAULT NULL,
  `119` varchar(5) DEFAULT NULL,
  `116` varchar(5) DEFAULT NULL,
  `117` varchar(5) DEFAULT NULL,
  `118` varchar(5) DEFAULT NULL,
  `123` varchar(5) DEFAULT NULL,
  `120` varchar(5) DEFAULT NULL,
  `121` varchar(5) DEFAULT NULL,
  `122` varchar(5) DEFAULT NULL,
  `127` varchar(5) DEFAULT NULL,
  `124` varchar(5) DEFAULT NULL,
  `125` varchar(5) DEFAULT NULL,
  `126` varchar(5) DEFAULT NULL,
  `131` varchar(5) DEFAULT NULL,
  `128` varchar(5) DEFAULT NULL,
  `129` varchar(5) DEFAULT NULL,
  `130` varchar(5) DEFAULT NULL,
  `167` varchar(5) DEFAULT NULL,
  `197` varchar(50) DEFAULT NULL,
  `193` varchar(5) DEFAULT NULL,
  `18` varchar(6) DEFAULT NULL,
  `532` varchar(6) DEFAULT NULL,
  `132` varchar(6) DEFAULT NULL,
  `5` varchar(6) DEFAULT NULL,
  `174` varchar(50) DEFAULT NULL,
  `3` varchar(5) DEFAULT NULL,
  `2` varchar(5) DEFAULT NULL,
  `112` varchar(5) DEFAULT NULL,
  `111` varchar(5) DEFAULT NULL,
  `85` varchar(50) DEFAULT NULL,
  `flag1` varchar(1) DEFAULT NULL,
  `flag2` varchar(1) DEFAULT NULL,
  `flag3` varchar(1) DEFAULT NULL,
  `flag4` varchar(1) DEFAULT NULL,
  `flag5` varchar(1) DEFAULT NULL,
  `flag6` varchar(1) DEFAULT NULL,
  `flag7` varchar(1) DEFAULT NULL,
  `flag8` varchar(1) DEFAULT NULL,
  `flag9` varchar(1) DEFAULT NULL,
  `flag10` varchar(1) DEFAULT NULL,
  `flag11` varchar(1) DEFAULT NULL,
  `flag12` varchar(1) DEFAULT NULL,
  `flag13` varchar(1) DEFAULT NULL,
  `flag14` varchar(1) DEFAULT NULL,
  `flag15` varchar(1) DEFAULT NULL,
  `flag16` varchar(1) DEFAULT NULL,
  `flag17` varchar(1) DEFAULT NULL,
  `flag18` varchar(1) DEFAULT NULL,
  `flag19` varchar(1) DEFAULT NULL,
  `flag20` varchar(1) DEFAULT NULL,
  `flag21` varchar(1) DEFAULT NULL,
  `flag22` varchar(1) DEFAULT NULL,
  `flag23` varchar(1) DEFAULT NULL,
  `flag24` varchar(1) DEFAULT NULL,
  `flag25` varchar(1) DEFAULT NULL,
  `flag26` varchar(1) DEFAULT NULL,
  `flag27` varchar(1) DEFAULT NULL,
  `flag28` varchar(1) DEFAULT NULL,
  `flag29` varchar(1) DEFAULT NULL,
  `flag30` varchar(1) DEFAULT NULL,
  `flag31` varchar(1) DEFAULT NULL,
  `flag32` varchar(1) DEFAULT NULL,
  `flag33` varchar(1) DEFAULT NULL,
  `flag34` varchar(1) DEFAULT NULL,
  `flag35` varchar(1) DEFAULT NULL,
  `flag36` varchar(1) DEFAULT NULL,
  `flag37` varchar(1) DEFAULT NULL,
  `flag38` varchar(1) DEFAULT NULL,
  `flag39` varchar(1) DEFAULT NULL,
  `flag40` varchar(1) DEFAULT NULL,
  `flag41` varchar(1) DEFAULT NULL,
  `flag42` varchar(1) DEFAULT NULL,
  `flag43` varchar(1) DEFAULT NULL,
  `flag44` varchar(1) DEFAULT NULL,
  `flag45` varchar(1) DEFAULT NULL,
  `signature` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`stationId`,`yyyy`,`mm`,`dd`,`hh`),
  UNIQUE KEY `Identification` (`stationId`,`yyyy`,`mm`,`dd`,`hh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.form_synoptic_2_ra1
DROP TABLE IF EXISTS `form_synoptic_2_ra1`;
CREATE TABLE IF NOT EXISTS `form_synoptic_2_ra1` (
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
  `Val_Elem178` varchar(6) DEFAULT NULL,
  `Val_Elem179` varchar(6) DEFAULT NULL,
  `Val_Elem180` varchar(6) DEFAULT NULL,
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
  `Flag193` varchar(1) DEFAULT NULL,
  `Flag115` varchar(1) DEFAULT NULL,
  `Flag177` varchar(1) DEFAULT NULL,
  `Flag178` varchar(1) DEFAULT NULL,
  `Flag179` varchar(1) DEFAULT NULL,
  `Flag180` varchar(1) DEFAULT NULL,
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
  PRIMARY KEY (`stationId`,`yyyy`,`mm`,`dd`,`hh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.import_obs_flags
DROP TABLE IF EXISTS `import_obs_flags`;
CREATE TABLE IF NOT EXISTS `import_obs_flags` (
  `stationId` varchar(255) DEFAULT NULL,
  `flagsObsdatetime` varchar(255) DEFAULT NULL,
  `obsFlag` varchar(255) DEFAULT NULL,
  `elementCode` varchar(255) DEFAULT NULL,
  UNIQUE KEY `ObsFlagIdentification` (`stationId`,`flagsObsdatetime`,`elementCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='This is a table for importing flags from v2_or v_3';

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.instrument
DROP TABLE IF EXISTS `instrument`;
CREATE TABLE IF NOT EXISTS `instrument` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.instrumentfaultreport
DROP TABLE IF EXISTS `instrumentfaultreport`;
CREATE TABLE IF NOT EXISTS `instrumentfaultreport` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.instrumentinspection
DROP TABLE IF EXISTS `instrumentinspection`;
CREATE TABLE IF NOT EXISTS `instrumentinspection` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.obselement
DROP TABLE IF EXISTS `obselement`;
CREATE TABLE IF NOT EXISTS `obselement` (
  `elementId` bigint(20) NOT NULL DEFAULT '0',
  `abbreviation` varchar(255) DEFAULT NULL,
  `elementName` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `elementScale` decimal(8,2) DEFAULT NULL,
  `upperLimit` varchar(255) DEFAULT NULL,
  `lowerLimit` varchar(255) DEFAULT NULL,
  `units` varchar(255) DEFAULT NULL,
  `elementtype` varchar(50) DEFAULT NULL,
  `qcTotalRequired` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`elementId`),
  KEY `elementCode` (`elementId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.observationfinal
DROP TABLE IF EXISTS `observationfinal`;
CREATE TABLE IF NOT EXISTS `observationfinal` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.observationinitial
DROP TABLE IF EXISTS `observationinitial`;
CREATE TABLE IF NOT EXISTS `observationinitial` (
  `recordedFrom` varchar(255) NOT NULL,
  `describedBy` bigint(20) DEFAULT NULL,
  `obsDatetime` datetime DEFAULT NULL,
  `obsLevel` varchar(255) DEFAULT NULL,
  `obsValue` varchar(255) DEFAULT NULL,
  `flag` varchar(255) DEFAULT NULL,
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
  CONSTRAINT `FK_maria_climsoft_db_v4_obselement_observationInitial` FOREIGN KEY (`describedBy`) REFERENCES `obselement` (`elementId`),
  CONSTRAINT `FK_maria_climsoft_db_v4_station_observationInitial` FOREIGN KEY (`recordedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.observationschedule
DROP TABLE IF EXISTS `observationschedule`;
CREATE TABLE IF NOT EXISTS `observationschedule` (
  `classifiedInto` varchar(255) DEFAULT NULL,
  `startTime` time DEFAULT NULL,
  `endTime` time DEFAULT NULL,
  `interval` varchar(255) DEFAULT NULL,
  `additionalObsTime` varchar(255) DEFAULT NULL,
  UNIQUE KEY `scheduleIdentification` (`classifiedInto`,`startTime`,`endTime`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_obsSchedule` FOREIGN KEY (`classifiedInto`) REFERENCES `obsscheduleclass` (`scheduleClass`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.obsscheduleclass
DROP TABLE IF EXISTS `obsscheduleclass`;
CREATE TABLE IF NOT EXISTS `obsscheduleclass` (
  `scheduleClass` varchar(255) NOT NULL DEFAULT '',
  `description` varchar(255) DEFAULT NULL,
  `refersTo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`scheduleClass`),
  KEY `scheduleClassIdeification` (`scheduleClass`),
  KEY `FK_mysql_climsoft_db_v4_station_scheduleClass` (`refersTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_scheduleClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.paperarchive
DROP TABLE IF EXISTS `paperarchive`;
CREATE TABLE IF NOT EXISTS `paperarchive` (
  `belongsTo` varchar(255) DEFAULT NULL,
  `formDatetime` datetime DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  `classifiedInto` varchar(50) DEFAULT NULL,
  UNIQUE KEY `paper_archive_identification` (`belongsTo`,`formDatetime`,`classifiedInto`),
  KEY `FK_mysql_climsoft_db_v4_0_station_paperArchiveDef` (`classifiedInto`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_0_station_paperArchive` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_0_station_paperArchiveDef` FOREIGN KEY (`classifiedInto`) REFERENCES `paperarchivedefinition` (`formId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.paperarchivedefinition
DROP TABLE IF EXISTS `paperarchivedefinition`;
CREATE TABLE IF NOT EXISTS `paperarchivedefinition` (
  `formId` varchar(50) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`formId`),
  KEY `paperarchivedef` (`formId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.physicalfeature
DROP TABLE IF EXISTS `physicalfeature`;
CREATE TABLE IF NOT EXISTS `physicalfeature` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.physicalfeatureclass
DROP TABLE IF EXISTS `physicalfeatureclass`;
CREATE TABLE IF NOT EXISTS `physicalfeatureclass` (
  `featureClass` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `refersTo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`featureClass`),
  KEY `stationFeatureClass` (`featureClass`),
  KEY `FK_mysql_climsoft_db_v4_station_featureClass` (`refersTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_featureClass` FOREIGN KEY (`refersTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.qcstatusdefinition
DROP TABLE IF EXISTS `qcstatusdefinition`;
CREATE TABLE IF NOT EXISTS `qcstatusdefinition` (
  `code` int(11) NOT NULL DEFAULT '0',
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.qctype
DROP TABLE IF EXISTS `qctype`;
CREATE TABLE IF NOT EXISTS `qctype` (
  `code` int(11) NOT NULL DEFAULT '0',
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.regkeys
DROP TABLE IF EXISTS `regkeys`;
CREATE TABLE IF NOT EXISTS `regkeys` (
  `keyName` varchar(255) NOT NULL DEFAULT '',
  `keyValue` varchar(255) DEFAULT NULL,
  `keyDescription` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`keyName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.routinereportdefinition
DROP TABLE IF EXISTS `routinereportdefinition`;
CREATE TABLE IF NOT EXISTS `routinereportdefinition` (
  `reportClass` varchar(255) NOT NULL,
  `reportSchedule` varchar(255) DEFAULT NULL,
  `reportCode` varchar(255) DEFAULT NULL,
  `reportDescription` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`reportClass`),
  KEY `report_code` (`reportCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.routinereporttransmission
DROP TABLE IF EXISTS `routinereporttransmission`;
CREATE TABLE IF NOT EXISTS `routinereporttransmission` (
  `reportClass` varchar(255) DEFAULT NULL,
  `reportDatetime` datetime DEFAULT NULL,
  `receivedDatetime` datetime DEFAULT NULL,
  `reportedFrom` varchar(255) DEFAULT NULL,
  UNIQUE KEY `report` (`reportClass`,`reportDatetime`,`reportedFrom`),
  KEY `FK_mysql_climsoft_db_v4_station_routineReportTransmission` (`reportedFrom`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_routineReportTransmissionClass` FOREIGN KEY (`reportClass`) REFERENCES `routinereportdefinition` (`reportClass`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_routineReportTransmission` FOREIGN KEY (`reportedFrom`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.seq_daily_element
DROP TABLE IF EXISTS `seq_daily_element`;
CREATE TABLE IF NOT EXISTS `seq_daily_element` (
  `element_code` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.seq_month_day
DROP TABLE IF EXISTS `seq_month_day`;
CREATE TABLE IF NOT EXISTS `seq_month_day` (
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  PRIMARY KEY (`mm`,`dd`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.seq_month_day_element
DROP TABLE IF EXISTS `seq_month_day_element`;
CREATE TABLE IF NOT EXISTS `seq_month_day_element` (
  `elementId` int(11) NOT NULL,
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  PRIMARY KEY (`elementId`,`mm`,`dd`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.seq_month_day_element_leap_yr
DROP TABLE IF EXISTS `seq_month_day_element_leap_yr`;
CREATE TABLE IF NOT EXISTS `seq_month_day_element_leap_yr` (
  `elementId` int(11) NOT NULL,
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  PRIMARY KEY (`elementId`,`mm`,`dd`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.seq_month_day_leap_yr
DROP TABLE IF EXISTS `seq_month_day_leap_yr`;
CREATE TABLE IF NOT EXISTS `seq_month_day_leap_yr` (
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  PRIMARY KEY (`mm`,`dd`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.seq_month_day_synoptime
DROP TABLE IF EXISTS `seq_month_day_synoptime`;
CREATE TABLE IF NOT EXISTS `seq_month_day_synoptime` (
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  `hh` int(11) NOT NULL,
  PRIMARY KEY (`mm`,`dd`,`hh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.seq_month_day_synoptime_leap_yr
DROP TABLE IF EXISTS `seq_month_day_synoptime_leap_yr`;
CREATE TABLE IF NOT EXISTS `seq_month_day_synoptime_leap_yr` (
  `mm` int(11) NOT NULL,
  `dd` int(11) NOT NULL,
  `hh` int(11) NOT NULL,
  PRIMARY KEY (`mm`,`dd`,`hh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.station
DROP TABLE IF EXISTS `station`;
CREATE TABLE IF NOT EXISTS `station` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.stationelement
DROP TABLE IF EXISTS `stationelement`;
CREATE TABLE IF NOT EXISTS `stationelement` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.stationidalias
DROP TABLE IF EXISTS `stationidalias`;
CREATE TABLE IF NOT EXISTS `stationidalias` (
  `idAlias` varchar(255) DEFAULT NULL,
  `refersTo` varchar(255) DEFAULT NULL,
  `belongsTo` varchar(255) DEFAULT NULL,
  `idAliasBeginDate` datetime DEFAULT NULL,
  `idAliasEndDate` datetime DEFAULT NULL,
  UNIQUE KEY `stationid_alias_identification` (`idAlias`),
  KEY `stationstationidAlias` (`belongsTo`),
  CONSTRAINT `FK_mysql_climsoft_db_v4_station_stationIdAlias` FOREIGN KEY (`belongsTo`) REFERENCES `station` (`stationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.stationlocationhistory
DROP TABLE IF EXISTS `stationlocationhistory`;
CREATE TABLE IF NOT EXISTS `stationlocationhistory` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.stationnetworkdefinition
DROP TABLE IF EXISTS `stationnetworkdefinition`;
CREATE TABLE IF NOT EXISTS `stationnetworkdefinition` (
  `networkAbbreviation` varchar(255) NOT NULL DEFAULT '',
  `networkFullName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`networkAbbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.stationqualifier
DROP TABLE IF EXISTS `stationqualifier`;
CREATE TABLE IF NOT EXISTS `stationqualifier` (
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

-- Data exporting was unselected.


-- Dumping structure for table mariadb_climsoft_db_v4.synopfeature
DROP TABLE IF EXISTS `synopfeature`;
CREATE TABLE IF NOT EXISTS `synopfeature` (
  `abbreviation` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`abbreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
