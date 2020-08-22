using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Estoque.Infra.CrossCutting.IoC;

namespace Estoque.Orquestrador.Configuration
{ 
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}
