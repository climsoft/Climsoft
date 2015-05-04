# DBTools DBMYSQL - MySQL Database Dump
#

SET FOREIGN_KEY_CHECKS=0;

# Dumping Table Structure for data_forms

#
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
#
# Dumping Data for data_forms
#
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61000, 3, 'form_daily1', 'form_daily1', 'Data for some elements for one day', 1, 5, 19, 'Horizontal', 'seq_month_day_form_daily1');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61001, 2, 'form_daily2', 'form_daily2', 'Data for one element for the whole month', 1, 5, 36, 'Vertical', 'seq_element_form_daily2');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61002, 1, 'form_hourly', 'form_hourly', 'Data for one element for 24 hours', 1, 5, 28, 'Vertical', 'seq_form_hourly');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61003, 4, 'form_synoptic1', 'form_synoptic1', 'Synoptic data for one hour for one element for the whole month', 0, 5, 35, 'Vertical', 'seq_synoptime_element');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61004, 5, 'form_synoptic2', 'form_synoptic2', 'Synoptic data for many elements for one  observation time', 0, 5, 37, 'Horizontal', 'seq_month_day_synoptime');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61005, 6, 'form_synoptic3', 'form_synoptic3', 'Synoptic data for all hours for one element', 1, 5, 12, 'Vertical', 'seq_form_synopt3');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61006, 7, 'form_upperair1', 'form_upperair1', 'Upper air data for several elements for one day', 1, 6, 17, 'Vertical', 'seq_month_day_synoptime_level');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61007, 8, 'form_upperair2', 'form_upperair2', 'Upper air data for one element and one level for the whole month', 0, 6, 36, 'Vertical', 'seq_level_upperair_element');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61043, 19, 'form_synoptic2_TDCF', 'form_synoptic2_TDCF', 'Synoptic data for many elements for one  observation time - TDCF', 1, 5, 52, 'Horizontal', 'seq_month_day_synoptime');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (61139, 20, 'form_bmet26', 'form_bmet26', 'Botswana Hourly Data for several elements for 24 hours(BMET26)', 0, 5, 34, 'Horizontal', 'seq_month_day_time');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (63021, 15, 'form_hourlywind', 'form_hourlywind', 'Hourly wind data', 0, 4, 27, 'Horizontal', 'seq_month_day_form_hourlywind');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (63027, 14, 'form_agro1', 'form_agro1', 'Kenya Agromet data', 0, 4, 37, 'Horizontal', 'seq_month_day');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (63028, 16, 'form_temp0', 'form_temp0', 'Uganda temperature data', 0, 4, 11, 'Horizontal', 'seq_month_day');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (63029, 17, 'form_synoptic2_caribbean', 'form_synoptic2_caribbean', 'Caribbean synoptic data for many elements for one  observation time', 0, 5, 37, 'Horizontal', 'seq_month_day_hour');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (63030, 18, 'form_monthly', 'form_monthly', 'Monthly data', 0, 3, 14, 'Vertical', 'seq_year');
INSERT INTO `data_forms` (id, `order`, table_name, form_name, description, selected, val_start_position, val_end_position, elem_code_location, sequencer) VALUES (63031, 19, 'form_climat', 'form_climat', 'Data for monthly CLIMAT report', 0, 4, 16, 'Horizontal', 'seq_month_day');
SET FOREIGN_KEY_CHECKS=1

