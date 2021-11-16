namespace FMS.Blazor.Server.Services;

public class CityApiService : ICityApiService
{
    public CityApiService(IConfiguration configuration, IHttpClientFactory clientFactory)
    {
        this.configuration = configuration;
        this.clientFactory = clientFactory;

        #if DEBUG
            APIBaseAddress = configuration["CityApiUri_Debug"];
        #else
            APIBaseAddress = configuration["CityApiUri_Release"]; 
        #endif
    }

    // Call city api
    public async Task GetAllCities()
    {
        string uri = configuration["CityApiGetAll"];

        var client = clientFactory.CreateClient(
            name: "City Service Version 1");

        var request = new HttpRequestMessage(
            method: HttpMethod.Get, requestUri: uri);

        HttpResponseMessage response = await client.SendAsync(request);

        var model = await response.Content
            .ReadFromJsonAsync<IEnumerable<string>>();

        Cities = model?.ToArray();
    }

    public string[]? Cities { get; private set; }
    IConfiguration configuration;
    private readonly IHttpClientFactory clientFactory;
    public string APIBaseAddress { get; private set; }
}