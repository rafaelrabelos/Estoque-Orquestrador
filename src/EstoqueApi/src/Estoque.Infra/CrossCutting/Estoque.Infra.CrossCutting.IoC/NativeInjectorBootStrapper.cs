using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Infra.CrossCutting.IoC
{
    using Estoque.Aplicacao.Services;
    using Estoque.Aplicacao.Services.Interfaces;
    using Estoque.Dominio.Interfaces.Repositorios;
    using Estoque.Infra.DAL.Repositorios;
    using Estoque.Infra.DAL.Configuration;

    public static class NativeInjectorBootStrapper
    {
        
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // ASPNET
            services.AddSingleton(configuration);
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // Connections
            services.AddScoped<IDbConnection>(ctx => DapperConnectionFactory.Connection(configuration.GetConnectionString("DefaultConnection")));

            // Services
            services.AddScoped<IProdutoService, ProdutoService>();

            // Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            

        }
    }
}
