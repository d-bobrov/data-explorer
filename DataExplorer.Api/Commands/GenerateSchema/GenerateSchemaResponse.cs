using DataExplorer.Common.SchemaGenerators.Models;

namespace DataExplorer.Api.Commands.GenerateSchema;

public record GenerateSchemaResponse(DatabaseSchema Schema);