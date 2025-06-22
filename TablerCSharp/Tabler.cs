namespace TablerCSharp
{
    public class Tabler<T>(IEnumerable<ColumnDefinition<T>> coldefs)
    {
        IEnumerable<ColumnDefinition<T>> _colDefs = coldefs;

        public string RenderString(IEnumerable<T> data)
        {
            // Step 1: Compute Table
            List<List<string>> table = new List<List<string>>(data.Count() + 1);
            table.Add(new List<string>());

            // headers
            foreach (var c in _colDefs)
            {
                table[0].Add(c.RenderHeader());
            }

            // cells
            foreach (var d in data)
            {
                var row = new List<string>(_colDefs.Count());

                foreach (var c in _colDefs)
                {
                    row.Add(c.RenderValue(d));
                }

                table.Add(row);
            }


            // Step 2: Calculate column widths
            var colWidths = new List<int>(_colDefs.Count());
            for (var x = 0; x < _colDefs.Count(); x++)
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
            List<string> results = new List<string>(table.Count());
            for (var y = 0; y < table.Count(); y++)
            {
                List<string> row = table.ElementAt(y);
                List<string> cells = new List<string>(_colDefs.Count());

                for (var x = 0; x < row.Count(); x++)
                {
                    int colWidth = colWidths.ElementAt(x);

                    cells.Add(row.ElementAt(x).PadRight(colWidth));
                }

                string line = String.Join(" | ", cells);
                results.Add(line);
            }

            return String.Join("\n", results);
        }

        private List<List<string>> GetTable(IEnumerable<T> data)
        {
            List<List<string>> table = new List<List<string>>(data.Count());

            return table;
        }
    }

    public class ColumnDefinition<T>
    {
        public ColumnDefinition() { }

        public ColumnDefinition(Func<string> renderHeader, Func<T, string> renderValue)
        {
            RenderHeader = renderHeader;
            RenderValue = renderValue;
        }

        public Func<string> RenderHeader = static () =>
        {
            return "";
        };

        public Func<T, string> RenderValue = static data =>
        {
            return $"{data}";
        };
    }
}
