# TablerCSharp

Simple table formatter for C# loosely based on [ag-grid](https://www.ag-grid.com/).

## Example

Run the example by cloning this repository and running the project.

```shell
> dotnet run --project .\TablerCSharp\
First Name | Last Name      | Birth Date
Joel       | Lau            | 1990-01-01
Arnold     | Schwarzenegger | 1947-07-30
```

## Usage

1. Declare your configuration
    ```csharp
    var tabler = new Tabler<Person>([
        new ColumnDefinition<Person>(() => "First Name", (p) => p.FirstName),
            new ColumnDefinition<Person>(() => "Last Name", (p) => p.LastName),
            new ColumnDefinition<Person>(() => "Birth Date", (p) => p.BirthDate.ToString("yyyy-MM-dd")),
        ]);
    ```
1. Render data
    ```csharp
    var result = tabler.RenderString([
        new Person("Joel", "Lau", new DateTime(1990, 01, 01)),
            new Person("Arnold", "Schwarzenegger", new DateTime(1947, 07, 30)),
        ]);


    System.Console.WriteLine(result);
    ```

## Development

Requires dotnet 9.0

### Commands

| . | Command |
| --- | --- |
| Run Example | dotnet run --project .\TablerCSharp |
| Run Tests | dotnet test |
