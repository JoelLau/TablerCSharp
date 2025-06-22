namespace TablerCSharp.Test
{
    public class TablerTests
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

        [Fact]
        public void Example()
        {
            // Arrange
            var tabler = new Tabler<Person>([
                new ColumnDefinition<Person>(() => "First Name", (p) => p.FirstName),
                new ColumnDefinition<Person>(() => "Last Name", (p) => p.LastName),
                new ColumnDefinition<Person>(() => "Birth Date", (p) => p.BirthDate.ToString("yyyy-MM-dd")),
            ]);

            // Act
            var result = tabler.RenderString([
                new Person("Joel", "Lau", new DateTime(1990, 01, 01)),
                new Person("Arnold", "Schwarzenegger", new DateTime(1947, 07, 30)),
            ]);

            // Assert 
            var expect = String.Join("\n", [
                "First Name | Last Name      | Birth Date",
                "Joel       | Lau            | 1990-01-01",
                "Arnold     | Schwarzenegger | 1947-07-30",
            ]);

            Assert.Equal(expect, result);
        }
    }
}
