# Renamer Web Dapper App

This console program uses Dapper and is a quick way to get data into a SQL Server database.

It has one table and one stored procedure to allow SQL Server to consume data.

## Original data format

The data is in the followig format in a text file.

```bash
    08-22 - Glasgow/20230822_065642.jpg
    08-22 - Glasgow/20230822_111352.jpg
    08-22 - Glasgow/20230822_172841.jpg
    ...
```

It is reformatted into the Photo entity model.

## Gotchas

I have to add the following to the connection string to get a connection to a SQL Server database.

```xml
    Encrypt=True;TrustServerCertificate=True;
```

## NuGet Packages used

* Microsoft.Data.SqlClient
* Dapper
* System.Configuration.ConfigurationManager
