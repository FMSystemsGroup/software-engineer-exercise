using System;
namespace FMS.Blazor.Server.Services;

public class ApiService
{
    public ApiService(NavigationManager navigationManager, IConfiguration configuration)
    {
        this.configuration = configuration;
        NavigationManager = navigationManager;

        #if DEBUG
            APIBaseAddress = configuration["CityApiUri_Debug"];
        #else
            APIBaseAddress = configuration["CityApiUri_Release"]; 
        #endif
    }

    IConfiguration configuration;
    public string APIBaseAddress { get; set; }
    public NavigationManager NavigationManager { get; }
}