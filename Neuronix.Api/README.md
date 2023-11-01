## Neuronix Task API for ASP.NET Core

## Starting the Application

For run the app we have appsettings.Local.json to configurte the app. In the file ```Properties->launchSettings.json``` you need to change the environment variable ```ASPNETCORE_ENVIRONMENT``` to ```Development``` to get the file appsettings.

- Press ```CTRL + F5``` to run the project or press ```F5``` to run it in debug mode.

## Application Structure

- The Neuronix.API is a basic Web RESTful created with ASP.NET Core 7.0+.
- The Neuronix.Core is a basic Class Library project. There are Models, Enums, Helpers, Interfaces from Repositories and Services.
- The Neuronix.Data is a basic Class Library project. We use the use unit of work pattern to connect to the database and use all repositories in a single class.
- The Neuronix.Services is a basic Class Library project. There are Services.

## Framework(s)

- ASP.NET Core 7

## Migrations

	-You need to run the next command to be execute migrations:
		dotnet ef --startup-project .\Neuronix.API\Neuronix.API.csproj database update
    -If you need create any migrations
		dotnet ef --startup-project .\Neuronix.API\Neuronix.API.csproj -p .\Neuronix.Data\Neuronix.Data.csproj migrations add <name-migration>