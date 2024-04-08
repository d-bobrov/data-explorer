using DataExplorer.App.Commands;
using Microsoft.OpenApi.Models;

namespace DataExplorer.App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddMediator();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c => 
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "Data Explorer RPC API", 
                Version = "v1",
                Description = "This is an RPC API for the Data Explorer application.",
                License = new OpenApiLicense
                {
                    Name = "Use Under MIT",
                    Url = new Uri("http://https://opensource.org/license/mit")
                }
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapRpc();
        app.Run();
    }
}