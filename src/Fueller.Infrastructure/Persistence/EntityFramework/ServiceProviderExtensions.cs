using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fueller.Infrastructure.Persistence.EntityFramework;

public static class ServiceProviderExtensions
{
    public static IServiceProvider MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<FuellerDbContext>();
        dbContext.Database.Migrate();

        return serviceProvider;
    }
}