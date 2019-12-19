using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Estorquestrador
{
    using Fluxos.Produto;
    using Models.Services;

    public class Startup : Services.DependencyInjection
    {
        public static IConfiguration Configuration { get; set;}
        public static ServiceProvider Provider{get; set;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetSection("connectionstrings:DevConnectionStr").Value;
            
            services.AddSingleton<AppOrm>(_ => new AppOrm( Configuration.GetSection("connectionstrings:DevConnectionStr").Value ) );
            services.AddSingleton<IConfiguration>(Configuration);


            services.AddSingleton<FluxoProduto>();

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            Provider = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
