using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Estoque.Aplicacao.Services;
using Estoque.Aplicacao.Services.Interfaces;
using Estoque.Dominio.Interfaces.Repositorios;
using Estoque.Infra.DAL.Repositorios;
using Estoque.Infra.DAL.Configuration;
using RebelQuery;

namespace Estoque.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // ASPNET
            services.AddSingleton(configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Connections
            services.AddScoped<IDbConnection>(ctx => DapperConnectionFactory.Connection(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRQuery>(ctx => new RebelQueryConnectionFactory(configuration.GetConnectionString("DefaultConnection")));

            // Services
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IImpostoService, ImpostoService>();

            // Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IImpostoRepository, ImpostoRepository>();

        }
    }
}
