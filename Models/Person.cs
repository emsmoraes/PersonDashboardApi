namespace PersonDashboard.Models;
public class Person 
{
    public Person(string name)
    {
        Name = name;
        Id = new Guid();
    }

    public Guid Id { get; init; }
    public string Name { get; private set; }
}