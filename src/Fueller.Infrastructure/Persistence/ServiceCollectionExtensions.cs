using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fueller.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration,
        Action<Configurator> configuratorAction)
    {
        var configurator = new Configurator(serviceCollection, configuration);
        configuratorAction.Invoke(configurator);
        
        return serviceCollection;
    }
}