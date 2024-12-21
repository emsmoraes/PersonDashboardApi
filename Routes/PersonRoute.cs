using PersonDashboard.Models;
namespace PersonDashboard.Routes;
public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        app.MapGet("person", () => new Person("Eduardo"));
    }
}