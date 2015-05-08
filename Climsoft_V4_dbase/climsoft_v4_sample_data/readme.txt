In order to run a MySQL script from the MySQL Command Line Prompt, you need to type the keyword 'SOURCE' followed by a space then the script name and a semi-colon.

So the syntax is as shown in the line below.

SOURCE script name;

Step 1:

Run script "mysql_climsoft_db_v4.sql" to create an empty MySQL CLIMSOFT database with the core tables.

Step 2:

Run the script "import_v4_elements.sql" to import element information into the "obsElement" table in the newly created MySQL CLIMSOFT database.

Step 3:

Run the script "import_v4_stations.sql" to import sample station information into the "station" table in the newly created MySQL CLIMSOFT database.

Step 4:

Run the script "import_v4_obs_data.sql" to import sample observation data into the "observationFinal" table in the newly created MySQL CLIMSOFT database.


