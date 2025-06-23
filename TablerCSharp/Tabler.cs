namespace TablerCSharp;

public class Tabler<T>(IEnumerable<ColumnDefinition<T>> columnDefinitions)
{
    private readonly IEnumerable<ColumnDefinition<T>> colDefs = columnDefinitions;

    public string RenderString(IEnumerable<T> data)
    {
        // Step 1: Compute Table
        var table = new List<List<string>>(data.Count() + 1);

        foreach (var c in this.colDefs)
        {
            table[0].Add(c.RenderHeader());
        }

        foreach (var d in data)
        {
            var row = new List<string>(this.colDefs.Count());

            foreach (var c in this.colDefs)
            {
                row.Add(c.RenderValue(d));
            }

            table.Add(row);
        }


        // Step 2: Calculate column widths
        var colWidths = new List<int>(this.colDefs.Count());
        for (var x = 0; x < this.colDefs.Count(); x++)
        {
            var max = 0;
            foreach (var row in table)
            {
                if (row[x].Length > max)
                {
                    max = row[x].Length;
                }
            }

            colWidths.Add(max);
        }

        // Step 3: Convert Table to String
        var results = new List<string>(table.Count);
        for (var y = 0; y < table.Count; y++)
        {
            var row = table.ElementAt(y);
            var cells = new List<string>(this.colDefs.Count());

            for (var x = 0; x < row.Count; x++)
            {
                var colWidth = colWidths.ElementAt(x);

                cells.Add(row.ElementAt(x).PadRight(colWidth));
            }

            var line = string.Join(" | ", cells);
            results.Add(line);
        }

        return string.Join("\n", results);
    }
}

public class ColumnDefinition<T>(Func<string> renderHeaderFunc, Func<T, string> renderValueFunc)
{
    private readonly Func<string> renderHeaderFunc = renderHeaderFunc;

    private readonly Func<T, string> renderValueFunc = renderValueFunc;

    public string RenderHeader() => this.renderHeaderFunc();

    public string RenderValue(T data) => this.renderValueFunc(data);
}
