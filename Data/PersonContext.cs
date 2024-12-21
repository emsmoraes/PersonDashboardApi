using Microsoft.EntityFrameworkCore;
using PersonDashboard.Models;

namespace PersonDashboard.Data;

public class PersonContext : DbContext
{
    public DbSet<Person> People { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Data Source=person.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}