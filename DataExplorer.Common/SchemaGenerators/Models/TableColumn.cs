namespace DataExplorer.Common.SchemaGenerators.Models;

public class TableColumn
{
   public string Name { get; set; }
   public string DataType { get; set; }
   public bool IsPrimaryKey { get; set; }
   public string? ReferenceTable { get; set; } // Set this only if the column is a foreign key
   
}