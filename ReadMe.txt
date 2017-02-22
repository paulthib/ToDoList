About the app

Developed using Visual Studio 2015, update 3, in C# using SQL Server

There is a unit test project with a single class containing some basic unit tests.
For dependency injection, AutoFac was used.

Regarding SQL Server version:
The actual database is a SQL Server MDF file, contained within the project.  It was created using SQL Server 2012

When I tested this on a different computer (than where developed), there was initially a problem with the version of SQL Server LocalDB
The instructions below helped me resolve the problem.
	http://stackoverflow.com/questions/36699309/sql-local-database-cannot-be-opened

If you get a runtime error indicating that " the database ... cannot be opened ...", try these instructions.
	



