# TimeForUpdate

## Configuration

In order to run the application, your **appsettings.json** template must include:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "<Your-SQL-Server-connection-string-here>"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
