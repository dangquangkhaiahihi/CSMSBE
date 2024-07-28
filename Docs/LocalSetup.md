# Local Setup

## `appsettings.Development.json`

- Clone the `template.appsettings.Development.json` configuration file and remove the `template` part.
- Add local setup keys/secrets to the `appsettings.Development.json`.

## Update database

- Ensure `dotnet-ef` is installed: `dotnet tool install --global dotnet-ef --version 6.0.31`
- Add a new migration: `dotnet ef migrations add MigrationName -p .\CSMSBE.Entity\ -s .\CSMSBE.Api\`
- Update table `dotnet ef database update -p .\CSMSBE.Entity\ -s .\CSMSBE.Api\`
