using System.Net.Cache;
using DataExplorer.Api.Commands.CreateConnection;
using DataExplorer.Api.Commands.DisposeConnection;
using DataExplorer.Api.Commands.ExecuteSql;
using DataExplorer.Api.Commands.GenerateSchema;
using DataExplorer.Api.Commands.TranslateNaturalLanguageToSql;
using DataExplorer.Common.SchemaGenerators.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace DataExplorer.Api.Commands;

public static class CommandExtensions
{

    public static RouteGroupBuilder MapCommands(this RouteGroupBuilder rpc)
    {
        rpc.MapPost("createConnection", async (IMediator mediator, CreateConnectionRequest request) =>
            {
                var response = await mediator.Send(request);
                return Results.Json(response);
            })
            .WithName("CreateConnection")
            .Accepts(typeof(CreateConnectionRequest), "application/json")
            .Produces<CreateConnectionResponse>()
            .WithOpenApi(op =>
            {
                op.Description = "Creates a new connection to the database. Use it to query data";
                op.Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = "Connection" } };
                return op;
            });

        rpc.MapPost("DisposeConnection", async (IMediator mediator, DisposeConnectionRequest request) => { })
            .WithName("DisposeConnection")
            .Produces<DisposeConnectionResponse>()
            .WithOpenApi(op =>
            {
                op.Description = "Disposes an existing connection";
                op.Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = "Connection" } };
                return op;
            });

        rpc.MapPost("GenerateSchema", async (IMediator mediator, GenerateSchemaRequest request) =>
            {
                var response = await mediator.Send(request);
                return Results.Json(response);
            })
            .WithName("GenerateSchema")
            .Produces<DatabaseSchema>()
            .WithOpenApi(op =>
            {
                op.Description = "Generates database schema";
                op.Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = "SchemaGenerator" } };
                return op;
            });
        rpc.MapPost("ExecuteSql", async (IMediator mediator, ExecuteSqlRequest request) =>
            {
                var response = await mediator.Send(request);
                return Results.Json(response);
            })
            .WithName("ExecuteSql")
            .Produces<ExecuteSqlResponse>()
            .WithOpenApi(op =>
            {
                op.Description = "Executes SQL query";
                op.Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = "Query" } };
                return op;
            });

        rpc.MapPost("TranslateNaturalLanguageToSql", async (IMediator mediator, TranslateNaturalLanguageToSqlRequest request) =>
            {
                var response = await mediator.Send(request);
                return Results.Json(response);
            })
            .WithName("TranslateNaturalLanguageToSql")
            .Produces<TranslateNaturalLanguageToSqlResponse>()
            .WithOpenApi(op =>
            {
                op.Description = "Translates natural language to SQL";
                op.Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = "Query" } };
                return op;
            });

        return rpc;
    }

    public static WebApplication MapRpc(this WebApplication app)
    {
        var rpc = app.MapGroup("/rpc")
            .WithName("rpc")
            .WithOpenApi();
        rpc.MapCommands();
        return app;
    }

}