# FM: Systems Software Engineer Coding Exercise - Bonus round

## Quick documentation
The project is structured according to Domain Drive Design recommendations being with (virtual) VS solution folders for each layer. 
There is also a folder for Solution Items (.editorconfig, .gitattributes, .gitignore, etc) and for the tests projects.

## Technolody
It's a .NET5 Blazor Server/WebAssembly project.
Unit tests are written with XUnit.

## Database
This application uses in memory database. The seed data can be found in the following file: ```.\FMSystems.WeatherForecast.Infrastructure\Db\SeedData\StaticCities.cs```

## Environment Variables
You only need to set 1 environment variable (DarkSky api key) in order to run the project: 

> ```WeatherForecast_DarkSkyApiSettings__ApiKey```

Some other environment variables have default values but can be overwritten with environment variables:

> ```WeatherForecast_DarkSkyApiSettings__DefaultUnixTime``` (Default value: 1530705600)

> ```WeatherForecast_DarkSkyApiSettings__ExcludeArgs``` (Default value: "currently,minutely,daily,flags")

> ```WeatherForecast_DarkSkyApiSettings__UnitArgs``` (Default value: "us")

> ```WeatherForecast_DarkSkyApiSettings__LangArgs``` (Default value: "en")

## How to run?
You can run this application on Visual Studio or using the command line:

```sh
dotnet run --project FMSystems.WeatherForecast.Api
```

Check if you have .NET5 SDK installed with the following: ```dotnet --list-sdks```

## DarkSky Api Implementation
DarkSky api is a "connected service" and its client is auto generated using swaggergen during build. In the following file you can find the yaml with its specification:
```sh
#There is probably no need to ever change the request specification but you should manually edit this file case you want extra response data (at bottom of the file).
.\FMSystems.WeatherForecast.Infrastructure\Api\OpenApi\DarkSky.yaml
```
This yaml file was created base on the this file [here](https://github.com/exosite/darksky_service).

Why you would want to do that I don't know but if you want to check the generated api client code you can find it in following file: ```\FMSystems.WeatherForecast.Infrastructure\obj\DarkSkyApiClient.cs```

## Swagger
Swagger Docs is available and can be found here ```https://localhost:5001/swagger/index.html```.

## Online demo URL:
TODO

## Optimization opportunities
We could clearly save the time machine weather information in a database and avoid repetitive calls to the DarkSky api.

### Requirement 4:
Selecting a city from the drop-down needs to trigger a call out to the [DarkSky API](https://darksky.net/dev) and retrieve the weather for the selected city from July 4, 2018 at exactly noon local time. On the screen display the noon current summary description (example: Mostly Sunny), temperature (example: 88.81), and UV index (example: 5).

> Note: The Dark Sky API [doesn't enable CORS](https://darksky.net/dev/docs/faq#cross-origin). Handle this case as you see fit.

### Bonus
- Write clear documentation on how the app was designed and how to run the code.
- Provide an online demo of the application.
- Describe optimization opportunities when you conclude.

## What you should strive for
- Good use of current .NET design patterns and performance best practices.
- Solid testing approach.
- Extensible code.
- Able to explain your design decisions.
- Demonstrate good git best practices.