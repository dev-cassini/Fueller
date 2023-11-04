using Fueller.Infrastructure;
using Fueller.Infrastructure.Persistence.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration, infrastructureConfigurator =>
    {
        infrastructureConfigurator.AddPersistence(persistenceConfigurator =>
        {
            persistenceConfigurator.AddEntityFramework();
        });
    });

var app = builder.Build();

app.Services.MigrateDatabase();

app.MapGet("/", () => "Hello World!");

app.Run();