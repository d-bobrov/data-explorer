namespace DataExplorer.Common.SchemaGenerators.Models;

public class DatabaseTable
{
    public required string Name { get; set; }
    public required List<TableColumn> Columns { get; set; }
    public required string Sql { get; set; }
    public required bool IsView { get; set; }

}