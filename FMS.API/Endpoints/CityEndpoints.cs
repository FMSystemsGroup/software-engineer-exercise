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