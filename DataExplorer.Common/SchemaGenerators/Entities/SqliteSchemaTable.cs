namespace DataExplorer.Common.SchemaGenerators.Entities;

public class SqliteSchemaTable
{
    public required string Type { get; set; }
    public required string Name { get; set; }
    public required string TblName { get; set; }
    public required string Sql { get; set; }
   public List<SqliteColumnInfo> Columns { get; set; } 
    
}