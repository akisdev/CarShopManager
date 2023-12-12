For inserting new entries, simply press the insert button.
For updating old entries, select one entry from the table on the left and then press on the Update button, this will take you to another page where you will be able to update the entry.
For deleting old entries, select one entry from the same table and press delete, it will follow with a confirmation pop-up for safety measures.

The testing database was mounted on SSMS 2019, it was a MSSQL Database and I have attached a backup of this database in the folder MSSQL DB.
It can be imported on the local machine with the help of SSMS.

After importing the database I ran this command in the Packet manager console to migrate the database and create the Object classes for my tables.
Scaffold-DbContext "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CarShopManager;Integrated Security=True" Microsoft.EntityFrameWorkCore.SqlServer -outputdir Repository/Models -context DatabaseContext -contextdir Repository -DataAnnotations -Force

Data Source will be replaced by the server hostname and Initial Catalog by the Database name.
