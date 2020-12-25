Assignment Details

Requirement 1:
Using .NET Core, create an API that exposes a collection of the following cities:

Phoenix, AZ
Raleigh, NC
Saint John, NB (Canada)
San Diego, CA

Solution:
Path: \Weather Api\WeatherApi.sln

 - Created WeatherApi Solution using ASP.NET Core 5.0 Web Api project.
 - Configured to run using IIS Express on http://localhost:54509
 - Api endpoint is http://localhost:54509/api/Locations
 - While running through IIS Express, SwaggerUI endpoint will open @ http://localhost:54509/index.html
 - NuGet Package added to the project: Swashbuckle.AspNetCore v5.6.3

Design: 
 WeatherApi exposes /api/locations endpoint that returns collection of location model.
 ILocationRepo Interface declares GetLocationAsync() which returns collections of location model.
 LocationRepo class implements ILocationRepo to create list of locations. For the purposes of this assignment, location data is created manually using new List<>.Entity Framework could have be been used to create in-memory database as   well.
 Startup class adds scoped service ILocationRepo to IServiceCollection collection with implementation of LocationRepo. In future if we need to extend this repository functionality to use any database, a class implementing IlocationRepo    can be used and added to IServiceCollection under ConfigureServices() in Startup class.
 Constructor Dependency Injection is used to inject ILocationRepo in LocationsController which is used to retreive locations collections.

Optimization opportunities:
 - DataTransferObject (DTO) class could be used to avoid exposing internal fields and we can use AutoMapper to implement this.
 - Caching can be implemented for database calls.
 - Logging to be implemented.
 

 

Requirement 2:
Create a .NET Core unit test project to test this API action.

Solution:

Path: \WeatherApiTest\WeatherApiTest.csproj

 - Created WeatherApiTest project using xUnit Test project. Target Framework: .NET 5.0
 - Test project loads when you open \Weather Api\WeatherApi.sln
 - NuGet Package added to the project: Moq v4.15.2
 - Test class LocationsControllerTest contains unit test for WeatherApi's GetLocations()
 
 Design: Use Moq.Mock class to mock functionality of LocationRepo and then use Arrange, Act, Assert pattern to test. 



Requirement 3:
Using any web technologies you'd like, display the list of cities in a drop-down list. The list should be populated via a request to the city collection API that you created. The UI design should be simple and take minimal time to develop.

Requirement 4:
Selecting a city from the drop-down needs to trigger a call out to the DarkSky API and retrieve the weather for the selected city from July 4, 2018 at exactly noon local time. On the screen display the noon current summary description (example: Mostly Sunny), temperature (example: 88.81), and UV index (example: 5).


Solution:

Path: \Weather Web\WeatherWeb.sln

 - Created .Net Core web application using Razor pages.
 - Target Framework .NET 5.0
 - Configured to run using IIS Express on http://localhost:59291
 - While running through IIS Express, Web application will open @ http://localhost:59291
 - NuGet Package added to project: System.Net.Http.Json v5.0.0.
 - Application uses default layout out of the box provided by .net web application.
 - Custom Configuaration items in appsettings.json: 
	WeatherApiBaseAddress - Base address of WeatherApi service created earlier.
	DarkSkyApi:BaseAddress - Base address of DarkSky Api
		  :ApiKey - DarkSky api key.(Enter a valid key before running the application)
		

Design: 
 Weather Web application uses Index.cshtml as the default/Home page.
 In Index.cshtml.cs, OnGetAsyn() method is used to call WeatherApi to get location collection to fill the city dropdown.
 ILocationService interface declares GetLocationsAsync() that returns collection of location model. LocationService class implements ILocationService and handles http call to weather api created for this assignment.
 IDarkSkyService interface declares GetWeatherAsync() that returns Weather model. DarkSkyService class implements IDarkSkyService and handles http call to DarkSky api to retrieve weather data. DarkSky api is done on server side, CORS    issue for api call is handled. 
 Constructor Dependency Injection is used to inject ILocationService and IDarkSkyService in IndexModel class.
 Startup class adds scoped service ILocationService and IDarkSkyService to IServiceCollection collection with implementation of LocationService and DarkSkyService.
 Constructor Dependency Injection is used to inject HttpClient in LocationService and DarkSkyService class which is used to make http calls.
 Data from LocationService is used to fill dropdown with location/city details. Location model contain city's latitude and longitude along with time that is binded to dropdown value.
 Using jquery, On dropdown change event, GET ajax request to IndexModel OnGetWeatherData() method is made that in turn calls DarkSkyService and returns JsonReult that is used to display weather data on the Index page.

Optimization opportunities:
 - Response Caching middleware can be implemented.
 - Logging to be implemented.
 - Shared model project can be created that can be used between Weather web and Weather api.
 - Client side optimization including bundling and minification can be done to reduce page payload.
