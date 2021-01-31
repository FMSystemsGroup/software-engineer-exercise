# Weather Forecast Example

## Features

* The application was written using Microsoft's Blazor technology. It utilizes client-side (WASM) in a self host ASP.Net 
* A deployed version of the application is at https://fmsystemsserver20210130153411.azurewebsites.net
* The Swagger is published at https://fmsystemsserver20210130153411.azurewebsites.net/swagger
* The unit tests are in the FMSystems.Tests
* The FMSytems.Shared allows the client and server to share common code. In this example the only shared code are some data models.
* A basic repository pattern was designed to simulate getting the city data.
* The application uses a DarkSky C# library from https://github.com/jcheng31/DarkSkyApi
* id the DarkSky API key is not installed on the server, you are provided a text box to run the app with proper key. It is never stored on the server


### Prerequisites

- .NET Core SDK ([3.1.300](https://dotnet.microsoft.com/download/dotnet-core/3.1) or later)
- Visual Studio Code, **OR**
- Visual Studio 2019 16.6 or later

### Visual Studio

1. Open the solution file 'FMSystems.sln'.
2. Ensure the `FMSystems.Server` project is set as the start up project.
3. You can set the DarkSky Api key in the appsettings file.
4. To run interactively in the debugger, use the IIS Express launch setting with the FMSystems.Server as the startup