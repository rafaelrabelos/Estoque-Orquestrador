using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estorquestrador.Configuration
{
    using Estoque.Infra.CrossCutting.IoC;

    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}
