**Using SQL Server for Windows**

- [Introducing SQL Server for Windows](#introducing-sql-server-for-windows)
- [Downloading and installing SQL Server](#downloading-and-installing-sql-server)
- [Creating the Northwind sample database for SQL Server](#creating-the-northwind-sample-database-for-sql-server)
- [Managing the Northwind sample database with Server Explorer](#managing-the-northwind-sample-database-with-server-explorer)
- [Connecting to a database](#connecting-to-a-database)
- [Encrypting communication](#encrypting-communication)
- [Defining the Northwind database context class](#defining-the-northwind-database-context-class)
- [Scaffolding models using an existing database](#scaffolding-models-using-an-existing-database)

# Introducing SQL Server for Windows

Microsoft offers various editions of its popular and capable SQL Server product 
for Windows, Linux, and Docker containers. We will use a free version that can 
run standalone, known as SQL Server Developer Edition. You can also use the 
Express edition or the free SQL Server LocalDB edition that can be installed 
with Visual Studio for Windows.

# Downloading and installing SQL Server

You can download SQL Server editions from the following link:
https://www.microsoft.com/en-us/sql-server/sql-server-downloads

1.	Download the **Developer** edition.
2.	Run the installer.
3.	Select the **Custom** installation type.
4.	Select a folder for the installation files and then click **Install**.
5.	Wait for the 1.5 GB of installer files to download.
6.	In **SQL Server Installation Center**, click **Installation**, and then click **New SQL Server stand-alone installation or add features to an existing installation**, as shown in *Figure 10.1*:

![Installation using SQL Server Installation Center](B19586_10_sql_01.png)
*Figure 10.1: Installation using SQL Server Installation Center*

7.	Select **Developer** as the free edition and then click **Next**.
8.	Accept the license terms and then click **Next**.
9.	Review the install rules, fix any issues, and then click **Next**.
10.	In **Feature Selection**, select **Database Engine Services**, and then click **Next**.
11.	In **Instance Configuration**, select **Default instance**, and then click **Next**. If you already have a default instance configured, then you could create a named instance, perhaps called **csdotnetbook**.
12.	In **Server Configuration**, note the **SQL Server Database Engine** is configured to start automatically. Set the **SQL Server Browser** to start automatically, and then click **Next**.
13.	In **Database Engine Configuration**, on the **Server Configuration** tab, set **Authentication Mode** to **Mixed**, set the **sa** account password to a strong password, click **Add Current User**, and then click **Next**.
14.	In **Ready to Install**, review the actions that will be taken, and then click **Install**.
15.	In **Complete**, note the successful actions taken, and then click **Close**.
16.	In **SQL Server Installation Center**, in **Installation**, click **Install SQL Server Management Tools**.
17.	In the browser window, click to download the latest version of SSMS.
18.	Run the installer and click **Install**.
19.	When the installer has finished, click **Restart** if needed or **Close**.

# Creating the Northwind sample database for SQL Server

Now we can run a database script to create the Northwind sample database:

1.	If you have not previously downloaded or cloned the GitHub repository for this book, then do so now using the following link: https://github.com/markjprice/cs11dotnet7/.
2.	Copy the script to create the Northwind database for SQL Server from the following path in your local Git repository: `/sql-scripts/Northwind4SQLServer.sql` into the `WorkingWithEFCore` folder.
3.	Start **SQL Server Management Studio**.
4.	In the **Connect to Server** dialog, for **Server name**, enter `.` (a dot) meaning the local computer name, and then click **Connect**.
If you had to create a named instance, like `csdotnetbook`, then enter `.\csdotnetbook`
5.	Navigate to **File** | **Open** | **File...**.
6.	Browse to select the `Northwind4SQLServer.sql` file and then click **Open**.
7.	In the toolbar, click **Execute**, and note the the **Command(s) completed successfully** message.
8.	In **Object Explorer**, expand the **Northwind** database, and then expand **Tables**.
9.	Right-click **Products**, click **Select Top 1000 Rows**, and note the returned results, as shown in *Figure 10.2*:

![The Products table in SQL Server Management Studio](B19586_10_sql_02.png)
*Figure 10.2: The Products table in SQL Server Management Studio*

10.	In the **Object Explorer** toolbar, click the **Disconnect** button.
11.	Exit SQL Server Management Studio.

# Managing the Northwind sample database with Server Explorer

We did not have to use **SQL Server Management Studio** to execute the database script. We can also use tools in **Visual Studio 2022** including the **SQL Server Object Explorer** and **Server Explorer**:

1.	In Visual Studio 2022, choose **View** | **Server Explorer**.
2.	In the **Server Explorer** window, right-click **Data Connections** and choose **Add Connection...**.
3.	If you see the **Choose Data Source** dialog, as shown in *Figure 10.3*, then select **Microsoft SQL Server** and then click **Continue**:

![Choosing SQL Server as the data source](B19586_10_sql_03.png)
*Figure 10.3: Choosing SQL Server as the data source*

4.	In the **Add Connection** dialog, enter the server name as `.`, enter the database name as `Northwind`, and then click **OK**.
5.	In **Server Explorer**, expand the data connection and its tables. You should see 13 tables, including the **Categories** and **Products** tables, as shown in *Figure 10.4*:

![13 tables in Northwind database](B19586_10_sql_04.png)
*Figure 10.4: 13 tables in Northwind database*

6.	Right-click the **Products** table, choose **Show Table Data**, and note the 77 rows of products are returned.
7.	To see the details of the **Products** table columns and types, right-click **Products** and choose **Open Table Definition**, or double-click the table in **Server Explorer**.

# Connecting to a database

To connect to an SQL Server database, we need to know multiple pieces of information, as shown in the following list:
- The name of the server (and the instance if it has one).
- The name of the database.
- Security information, such as username and password, or if we should pass the currently logged-on user's credentials automatically.

We specify this information in a **connection string**.

For backward compatibility, there are multiple possible keywords we can use in an SQL Server connection string for the various parameters, as shown in the following list:
- `Data Source` or `server` or `addr`: These keywords are the name of the server (and an optional instance). You can use a dot `.` to mean the local server.
- `Initial Catalog` or `database`: These keywords are the name of the database.
- `Integrated Security` or `trusted_connection`: These keywords are set to `true` or `SSPI` to pass the thread's current Windows user credentials.
- `Encrypt`: This keyword enables SSL/TLS encryption of the transmitted data if set to `true`. Default is `false`. On a local computer it will use the local developer certificate to encrypt so this must be trusted.
- `TrustServerCertificate`: This keyword enables trusting the local certificate if set to `true`.
- `MultipleActiveResultSets`: This keyword is set to `true` to enable a single connection to be used to work with multiple tables simultaneously to improve efficiency. It is used for lazy loading rows from related tables.

As described in the list above, when you write code to connect to an SQL Server database, you need to know its server name. The server name depends on the edition and version of SQL Server that you will connect to, as shown in the following table:


| SQL Server edition | Server name \ Instance name |
| --- | --- |
| LocalDB 2012 | `(localdb)\v11.0` |
| LocalDB 2016 or later | `(localdb)\mssqllocaldb` |
| Express | `.\sqlexpress` |
| Full/Developer (default instance) | `.` |
| Full/Developer (named instance) | `.\csdotnetbook` |

> **Good Practice**: Use a dot `.` as shorthand for the local computer name. Remember that server names for SQL Server are made of two parts: the name of the computer and the name of an SQL Server instance. You provide instance names during custom installation.

# Encrypting communication

If you get the error, `The certificate chain was issued by an authority that is not trusted.`, then it is because the connection to the SQL Server database is trying to encrypt the transmission using the local development server certificate but the OS and therefore the app does not (yet) trust it.

You have three choices to fix this issue:

1. Add the following to the database connection string to make the local development server certicate trusted for this connection:
```
TrustServerCertificate=true;
```
1. Add the following to the database connection string to disable encryption so it does not *need* to trust the certificate for this connection:
```
Encrypt=false;
```
1. Run the following at the command prompt to trust the certificate for all .NET apps in future:
```
dotnet dev-certs https --trust
```

# Defining the Northwind database context class

1.	In the `WorkingWithEFCore` project, add package references to the EF Core data provider for SQL Server and the ADO.NET Provider for SQL Server, and globally and statically import the `System.Console` class for all C# files, as shown in the following markup:
```xml
<ItemGroup>
	<Using Include="System.Console" Static="true" />
</ItemGroup>

<ItemGroup>
  <PackageReference Version="5.1.1" Include="Microsoft.Data.SqlClient" />
  <PackageReference Version="8.0.0"
    Include="Microsoft.EntityFrameworkCore.SqlServer" />
</ItemGroup>
```

2.	Build the `WorkingWithEFCore` project to restore packages.
3.	Add a new class file named `NorthwindDb.cs`.
4.	In `NorthwindDb.cs`, define a class named `NorthwindDb`, import the main namespace for EF Core, make the class inherit from `DbContext`, and in an `OnConfiguring` method, configure the options builder to use SQL Server, as shown in the following code:
```cs
using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
using Microsoft.EntityFrameworkCore; // To use DbContext and so on.

namespace Northwind.EntityModels;

// This manages the connection to the database.
public class NorthwindDb : DbContext
{
  protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
  {
    SqlConnectionStringBuilder builder = new();

    builder.DataSource = "."; // "ServerName\InstanceName" e.g. @".\sqlexpress"
    builder.InitialCatalog = "Northwind";
    builder.IntegratedSecurity = true;
    builder.Encrypt = true;
    builder.TrustServerCertificate = true;
    builder.MultipleActiveResultSets = true;
    builder.ConnectTimeout = 3; // Because we want to fail fast. Default is 15 seconds.

    string? connectionString = builder.ConnectionString;
    WriteLine($"Connection: {connectionString}");
    optionsBuilder.UseSqlServer(connectionString);
  }
}
```

5.	In `Program.cs`, delete the existing statements and then import the `Packt.Shared` namespace and output the database provider, as shown in the following code:
```cs
using Northwind.EntityModels; // To use NorthwindDb.

NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");
```

6.	Run the console app and note the output showing the database connection string and which database provider you are using, as shown in the following output:
```
Connection: Data Source=.;Initial Catalog=Northwind;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;MultipleActiveResultSets=true;
Provider: Microsoft.EntityFrameworkCore.SqlServer
```

# Scaffolding models using an existing database

For SQL Server, change the database provider and connection string, as shown in the following command:
```
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context NorthwindDb
```
