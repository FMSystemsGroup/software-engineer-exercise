
namespace FMS.Blazor.Server.Pages;

public class IndexPage : ComponentBase
{
    internal bool citiesNotEmpty = false;
    internal bool success;
    internal string[] errors = { };
    internal MudForm? form;
    internal int spacing { get; set; } = 2;
}