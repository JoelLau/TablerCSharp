using TablerCSharp;

public class Example
{
    private class Person
    {
        public string FirstName;
        public string LastName;
        public DateTime BirthDate;

        public Person(string firstname, string lastname, DateTime birthdate)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
        }
    }

    public static void Main()
    {
        var tabler = new Tabler<Person>([
            new ColumnDefinition<Person>(() => "First Name", (p) => p.FirstName),
                new ColumnDefinition<Person>(() => "Last Name", (p) => p.LastName),
                new ColumnDefinition<Person>(() => "Birth Date", (p) => p.BirthDate.ToString("yyyy-MM-dd")),
            ]);

        var result = tabler.RenderString([
            new Person("Joel", "Lau", new DateTime(1990, 01, 01)),
                new Person("Arnold", "Schwarzenegger", new DateTime(1947, 07, 30)),
            ]);


        System.Console.WriteLine(result);
    }
}
