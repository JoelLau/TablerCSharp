namespace TablerCSharp.Test;

using System.Globalization;


public class TablerTests
{
    private sealed record Person(
        string FirstName,
        string LastName,
        DateTime BirthDate
    );

    [Fact]
    public void Example()
    {
        // Arrange
        var tabler = new Tabler<Person>([
            new ColumnDefinition<Person>(() => "First Name", (p) => p.FirstName),
                new ColumnDefinition<Person>(() => "Last Name", (p) => p.LastName),
                new ColumnDefinition<Person>(() => "Birth Date", (p) => p.BirthDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
            ]);

        // Act
        var result = tabler.RenderString([
            new Person("Joel", "Lau", new DateTime(1990, 01, 01)),
                new Person("Arnold", "Schwarzenegger", new DateTime(1947, 07, 30)),
            ]);

        // Assert
        var expect = string.Join("\n", [
            "First Name | Last Name      | Birth Date",
                "Joel       | Lau            | 1990-01-01",
                "Arnold     | Schwarzenegger | 1947-07-30",
            ]);

        Assert.Equal(expect, result);
    }
}

