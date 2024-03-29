namespace DataExplorer.Common.SchemaGenerators.Sqlite.Entities;

public class SchemaTable
{
    public required string Type { get; set; }
    public required string Name { get; set; }
    public required string TblName { get; set; }
    public required string Sql { get; set; }
   public List<ColumnInfo> Columns { get; set; } 
    
}