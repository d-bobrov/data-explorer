namespace DataExplorer.Common.SchemaGenerators.Sqlite.Entities;

public class ColumnInfo
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public bool IsNullable { get; set; }
    public required string DefaultValue { get; set; }
    public int PrimaryKeyIndex { get; set; } // If value is 0, then this column is not a primary key. Otherwise, it is. The reason it is stored as int, because Sqlite stores an index of a column, and I'm not sure if this value can fit in boolean.
}