namespace FMS.API.Minimal.Repositories;

public interface ICityRepository
{
    string[] GetAll();
}

public class CityRepository : ICityRepository
{
    private static readonly string[] CityNames = new[]
    {
        "Phoenix, AZ", "Raleigh, NC", "Saint John, NB (Canada)", "San Diego, CA"
    };

    public string[] GetAll() => CityNames;
}