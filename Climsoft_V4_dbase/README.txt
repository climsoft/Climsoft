Creating the MySQL development database
=======================================

- Open MySQL Workbench
- Create a connection to your test server (e.g. localhost). The connect will open in a new tab.
- Click on the +SQL button on the tool bar to create a new SQL tab for executing queries
- Open the mysql_climsoft_db_v4.sql script
- Click the execute button (lightening bolt icon on the toolbar) to run the script
- Repeat for data_forms.sql


mysql_climsoft_db_v4.sql
------------------------

Create the mysql_climsoft_db_v4 database with the entities and relations that are required by the software


data_forms.sql
--------------

An additional sql script to create the data_forms table that is required by the data entry form.
Note: this script does not create or name the database to use - it you import it separately from the main setup SQL script then you must first double-click the existing mysql_climsoft_db_v4 database on the left hand side (under schemas) so that it is known which database the SQL should be applied to.