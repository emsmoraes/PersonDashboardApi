using Microsoft.EntityFrameworkCore;
using PersonDashboard.Data;
using PersonDashboard.Models;
namespace PersonDashboard.Routes;
public static class PersonRoute

{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");

        route.MapPost("",
        async (PersonRequest req, PersonContext context) =>
        {
            var person = new Person(req.name);
            await context.AddAsync(person);
            await context.SaveChangesAsync();
        });

        route.MapGet("", async (PersonContext context) =>
        {
            var persons = await context.People.ToListAsync();
            return Results.Ok(persons);
        });

        route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (person == null)
            {
                return Results.NotFound();
            }

            person.ChangeName(req.name);

            await context.SaveChangesAsync();

            return Results.Ok(person);
        });

        route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (person == null)
            {
                return Results.NotFound();
            }

            person.DisablePerson();

            await context.SaveChangesAsync();

            return Results.Ok(person);
        });
    }
}