namespace DataExplorer.Common.SchemaGenerators.Models;

public class DatabaseTable
{
   public string Name { get; set; }
   public List<TableColumn> Columns { get; set; }
   
}