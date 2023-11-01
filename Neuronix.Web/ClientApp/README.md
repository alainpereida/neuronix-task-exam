## Neuronix Task Web for ASP.NET Core

## Environment configuration

To configure the development environment for the web, follow these steps:

- Download and install Node js.
- Download and install the .Net SDK.
- Clone the repository and API repository.
- Change the ```REACT_APP_API_BASE_URL``` in the .env file.
- Install project libraries with ```npm install``` in the root folder of the React js project ```ClientApp```.
- Run the project with CTRL + F5.

## Starting the Application

For run the app we have appsettings.Local.json to configurte the app. In the file ```Properties->launchSettings.json``` you need to change the environment variable ```ASPNETCORE_ENVIRONMENT``` to ```Development``` to get the file appsettings.

- Press ```CTRL + F5``` to run the project or press ```F5``` to run it in debug mode.

## Application Structure

- The Neuronix.Web is a basic Web Application project. There are SPA.

## Framework(s)

- ASP.NET .net core 7
- React js
- Node js 20.*
