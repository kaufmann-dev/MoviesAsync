# MoviesAsync
Things you need:
* dotnet-ef (Install: `dotnet tool install --global dotnet-ef`)
* A MySql database
* .NET 7 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

## Tasks before running the application
### `Api/appsettings.json` (Configure MySql Connection String)
Rename `Api/appsettings.json.example` to `Api/appsettings.json` and update the connection string accordingly. For security purposes, this file is not included in the Git repository.

```json
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "server=<server_address>; port=<exposed_port>; database=<database>; user=<user>; password=<password>; Persist Security Info=False; Connect Timeout=300"
  }
}
```
### `Api/Program.cs` (Define MySql Server Version)
In `Api/Proram.cs`, define `MySqlServerVersion` to match your MySql server.

For example, if your MySql server is running version 8.0.27:
```csharp
...
builder.Services.AddDbContextFactory<ImdbContext>(
  options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"), 
     new MySqlServerVersion(new Version(8,0,27))
  )
);
...
```

### Create a migration and update the database
Before running the application, you need to create a migration and update your database. In order to do so, execute the following commands.

```cd Model```

```dotnet ef --startup-project ../Api/ migrations add migration1```

```dotnet ef --startup-project ../Api/ database update```

### Running `Api` and `View`
If you followed the previous steps, you are now ready to run the application.

First, run the configuration `Api: http`. A Swagger application will now be available in the browser. After that, run the configuration `View: http`. The blazor site where you can create and take a look at all of your movies will now be available. Please note that it is important to run the Api first, as the View requires it.
