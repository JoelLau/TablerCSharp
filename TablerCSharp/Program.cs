namespace TablerCSharp;

public class Example
{
    private sealed class Person(string firstname, string lastname, DateTime birthdate)
    {
        public string FirstName { get; set; } = firstname;
        public string LastName { get; set; } = lastname;
        public DateTime BirthDate { get; set; } = birthdate;
    }

    public static void Main()
    {
        var tabler = new Tabler<Person>([
            new ColumnDefinition<Person>(() => "First Name", (p) => p.FirstName),
                new ColumnDefinition<Person>(() => "Last Name", (p) => p.LastName),
                new ColumnDefinition<Person>(() => "Birth Date", (p) => p.BirthDate.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            ]);

        var result = tabler.RenderString([
            new Person("Joel", "Lau", new DateTime(1990, 01, 01)),
                new Person("Arnold", "Schwarzenegger", new DateTime(1947, 07, 30)),
            ]);

        Console.WriteLine(result);
    }
}

