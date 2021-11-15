# .NET 6 Weather App
- Written by Thomas Divine Smith, II 
- November 14, 2021
- .NET 6 Implementation of a Blazor Web Assembly, ASP.NET and Minimal Web API

> Unable to push to Git Repository from Visual Studio Mac Community Edition. (Windows license required. Please consider proviing if selected for employment.
> 
> [DarkSkyAPI](https://darksky.net/dev) no longer allows new users to sign up. (Click to see prompt I recieved.)
> 
> I opted for [OpenWeatherMap](https://home.openweathermap.org/myservices) instead but the historical data requires a paid membership.

#[App Demo](https://weatherappexercise.azurewebsites.net/)

#[API Spec](https://cityapi.azurewebsites.net/swagger/v1/swagger.json)

#[API Documentation](https://cityapi.azurewebsites.net/swagger/index.html)


## Context
This exercise demonstrates to you some of the technologies being utilized at FM: Systems. It will also demonstrate to the development team how you approach a solution given liberal implementation guidelines. This exercise is designed to be completed under four hours.

## Requirements

### Requirement 1:
Using .NET Core, create an API that exposes a collection of the following cities:
- Phoenix, AZ
- Raleigh, NC
- Saint John, NB (Canada)
- San Diego, CA 

#### ASP.NET 6 Minimal API

```Shell
dotnet webapi --name FMS.API.Minimal
```
> Note: I chose .NET 6 for minimal development time but I would not have made this choose for an enterprise class application.

#### GlobalUsings.cs
```C#
global using System;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Builder;
global using FMS.API.Minimal.Repositories;
global using FMS.API.Endpoints;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.Swagger;
global using Swashbuckle.AspNetCore.SwaggerUI;
```
> Note: .NET 6 now allows global usings to rid namespaces from individual files.

#### CityEndpoints.cs
```C#
namespace FMS.API.Endpoints;

public static class CityEndpoints
{
    public static void DefineEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello FM Systems! Welcome to your api page.")
            .ExcludeFromDescription();

        app.MapGet("api/cities",
            (ICityRepository repo, HttpResponse response) =>
            repo.GetAll())
            .Produces<List<string>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetAllCities")
            .WithTags("Getters"); // Names Endpoint for SwaggerUI
    }
}
```
> Note: Minimal api's no longer require controllers. I implemented CityEndpoints.cs to map endpoints instead.

> I also opted for the fluent pattern instead of data annotations when defining the endpoints for compatibility with Swagger.

-
### Requirement 2:
Create a .NET Core unit test project to test this API action.

#### NUnit 3 Test Project
```Shell
dotnet nunit --name FMS.API.Tests
```
#### CityServiceTests.cs
```C#
using System.Linq;
using FMS.API.Minimal.Repositories;
using NUnit.Framework;

namespace FMS.API.Tests;

public class CityServiceTests
{
    [TestCase("Raleigh, NC", true)]
    [TestCase("typo", false)]
    [TestCase("", false)]
    public void IsValidCity_GetCity_ReturnsTrue(string name, bool expected)
    {
        // arrange
        CityRepository repo = new();
        var list = repo.GetAll().ToList();

        // act
        bool result = list.Contains(name); 

        // assert
        Assert.AreEqual(expected, result);
    }

    [TestCase(4, true)]
    [TestCase(5, false)]
    [TestCase(0, false)]
    public void IsValidCount_GetCity_ReturnsTrue(int count, bool expected)
    {
        // arrange
        CityRepository repo = new();
        var list = repo.GetAll().ToList();

        // act
        bool result = list.Count() == count;

        // assert
        Assert.AreEqual(expected, result);
    }
}
```
> Note: 6 tests were created to test the City collection size and validity of the containing elements.
 
-

### Requirement 3:
Using any web technologies you'd like, display the list of cities in a drop-down list. The list should be populated via a request to the city collection API that you created. The UI design should be simple and take minimal time to develop.

####  .NET 6 Blazor Server
```Shell
dotnet blazorserver --name FMS.Blazor.Server
```
>Note

> - I opted for Blazor Server because of its superior debugging capibilites. 

> - Blazor allows me to wrrite front end with C# instead of javascript.

> - If this application was expected to scale to 20+ users I would have opted for Blazor WASM instead where the client browser would be responsible for the work load instead of the server. 

> - If this were a productionized Blazor Server app I would have added Azure Monitoring and Logging to trace and log user exceptions.

#### Mud Blazor Free UI Component Package
```Shell
dotnet add package MudBlazor
```
> Note: 

> - Complete [MudBlazor installation](https://mudblazor.com/getting-started/installation#8c9f5156-80fe-42e8-9e04-300e1f2efe2d) starting at step 2 following the Blazor Server implementation.

> - I opted for MudBlazor to avoid the need of any custom or adhoc css or styling for rapid development time.

> - I also wanted something other than bootstrap. :)

> - MudBlazor has good documentation.

#### appsettings.json
```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "CityApiUri_Debug": "https://localhost:7084/",
  "CityApiUri_Release": "https://cityapi.azurewebsites.net/",
  "CityApiGetAll": "api/cities",
  "CityApiSpec": "swagger/v1/swagger.json",
  "CityApiDoc": "swagger",
  "WeatherForecastAPI": "*********"
}
``` 
> I placed the adjacent API urls in the appsettings.json for the ability to change API
 
> I avoided the complexity of Azure Key Vault for this demo.

> I would probably need to implement "Git ignore" for the appsettings.json to prevent API key from getting checked into source control. 

#### GlobalUsings.cs

```C#
global using System;
global using FMS.Blazor.Server.ViewModels;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Web;
global using MudBlazor.Services;
global using System.Net.Http.Headers;
global using System.Net.Http;
global using Microsoft.AspNetCore.Mvc;
global using MudBlazor;
global using FMS.Shared;
global using FMS.Blazor.Server.Components.Dialogs;
global using FMS.Blazor.Server.Services;
```
> Note: .NET 6 now allows global usings to rid namespaces from individual files.

#### Program.cs (Abbreviated)
```C#
#if DEBUG
    apiBaseAddress = configuration["CityApiUri_Debug"];

    builder.Services.AddHttpClient(name: "City Service Version 1",
        configureClient: options => {
          options.BaseAddress = new Uri(apiBaseAddress);
          options.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue(
                  "appliction/json", 1.0));
  });
#else
    apiBaseAddress = configuration["CityApiUri_Release"];

    builder.Services.AddHttpClient(name: "City Service Version 1",
        configureClient: options => {
          options.BaseAddress = new Uri(apiBaseAddress);
          options.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue(
                  "appliction/json", 1.0));
    });
#endif
```

> Note:

>  - Not a big fan of preprocessor directives but this proved to be the quickest alternative to choose the adjacent api base address based on the server app running in debug or release mode.

-

### Requirement 4:
Selecting a city from the drop-down needs to trigger a call out to the [DarkSky API](https://darksky.net/dev) and retrieve the weather for the selected city from July 4, 2018 at exactly noon local time. On the screen display the noon current summary description (example: Mostly Sunny), temperature (example: 88.81), and UV index (example: 5).

> Note: The Dark Sky API [doesn't enable CORS](https://darksky.net/dev/docs/faq#cross-origin). Handle this case as you see fit.

#### Blazor Server Implementation (Continued)

- Index.razor (Main page that implements City drop down menu)

- Index.razor.cs (Index Page model to remove bulk of C# from razor)

- IndexViewModel.cs (Minimal state manage)

- ApiService.cs (Stores a reference of the adjacent api's base address)

- BadStatusCodeDialog.cs (Dialog displayed when API call status code does not return status code "200 OK")

-

#### .NET 6 Shared Class Library

```Shell
dotnet classlib --name FMS.Shared
```
> Note: Shared class library to store data models and static utility functions

#### Weather.cs

```csharp
using System.ComponentModel.DataAnnotations;

namespace FMS.Shared;

public class Weather
{
    public Weather(DateTime time, string description, string temperature, string uvIndex)
    {
        Time = time;
        Description = description;
        Temperature = temperature;
        UVIndex = uvIndex;
    }

    [Required] public DateTime Time { get; private set; }
    [Required] public string Description { get; private set; }
    [Required] public string Temperature { get; private set; }
    [Required] public string UVIndex { get; private set; }
}
```

### Bonus
- Write clear documentation on how the app was designed and how to run the code.
- Provide an online demo of the application.
- Describe optimization opportunities when you conclude.

## What matters in this exercise
We're interested in your method and how you approach the problem just as much as we're interested in the end result. Use any libraries/packages you would normally use if this were a real production application.
> Note: we're interested in your code & the way you solve the problem, not how well you can use a particular library or feature.

## What you should strive for
- Good use of current .NET design patterns and performance best practices.
- Solid testing approach.
- Extensible code.
- Able to explain your design decisions.
- Demonstrate good git best practices.

## Q&A

> Where should I send back the result when I'm done?

Fork this repo and send us a pull request when you've completed the exercise. **Do not commit your Dark Sky API secret key.**

> What if I have a question?

Create a new issue in this repo and a team member will get back to you ASAP.
