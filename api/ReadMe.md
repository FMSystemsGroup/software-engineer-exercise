# WeatherFetch API

The WeatherFetch API exposes two endpoints. The city controller exposes a GET request to /api/City that will return a list of available cities.\
The weather controller exposes a GET to /api/Weather/ForCity/[cityId] where cityId is the id of a city from the city controller endpoint.\
This second endpoint takes the city requested and uses it to find the weather for that city at the date specified in the appsettings file property DateToCheck.\
The cities are initially stored in the appsettings file but after the first call to /api/City, they are added to a database where more data related to the city found via\
a geolocation library can be stored with the city record for faster subsequent retrieval.

## appsettings.json file
There is an example.appsettings.jaon file included to show you the properties needed for the API to function properly.\
Create a file called "appsettings.json" and mimic the properties of the example file with the correct values for your application.\
You can also create app settings for specific environments. Integration tests require the appsettings.Integration.Json file.\
The most important parts of the app settings are the cities, api keys, and CORS url. Generally I keep these values in their own, environment-specific files.\
For example, locally I have appsettings.json, appsettings.Development.json, appsettings.Integration.json, and appsettings.Production.json files for each respective environment.\

## Testing

The unit tests will run regardless of app settings. They generate their own data to run the tests. Anything that uses an API key\
is run through the integration tests. That way the API key is still kept in the appsettings file and out of the git repository.\
The integration tests use the Development environment which I've been configuring with 4 separate city records in the appsettings.Development.json file.

## Future optimizations

In the future, it may help to add the ability for users to specify the city they want to check the temperature for as well as the date to check. Each time a new city is added it can store that city's data in the database and append it to the list of available cities. As that list grows, it would make sense to start saving country information in another table and relate city data to the country the city is located in. This could help users narrow down large lists of cities.
