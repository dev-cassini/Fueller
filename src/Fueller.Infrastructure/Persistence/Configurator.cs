using Fueller.Infrastructure.Persistence.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fueller.Infrastructure.Persistence;

public class Configurator
{
    private readonly IServiceCollection _serviceCollection;
    private readonly IConfiguration _configuration;

    public Configurator(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _serviceCollection = serviceCollection;
        _configuration = configuration;
    }
    
    public Configurator AddEntityFramework()
    {
        _serviceCollection.AddEntityFramework(_configuration);
        return this;
    }
}