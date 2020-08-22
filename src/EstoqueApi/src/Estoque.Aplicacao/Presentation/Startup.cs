
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;

namespace Estorquestrador
{
    using Configuration;
    using Estoque.Aplicacao.Services.ValueObj;

    public class Startup 
    {
        public static IConfiguration Configuration { get; set;}
        public static ServiceProvider Provider{get; set;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDIConfiguration(Configuration);

            CreateCorsPolicies(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();

             //Provider = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region Config MVC

            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("pt-BR")
                {
                    DateTimeFormat =  new DateTimeFormatInfo
                    {
                        ShortDatePattern = "yyyy-MM-dd",
                        LongDatePattern = "yyyy-MM-dd HH:mm:ss",
                        ShortTimePattern = "HH:mm:ss",
                        LongTimePattern = "HH:mm:ss"
                    }
                }
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }

        #region Métodos Privados

        private void CreateCorsPolicies(IServiceCollection services)
        {
            var allowedOrigins = Configuration.GetValue("AllowedOrigins", "");
            if (string.IsNullOrEmpty(allowedOrigins))
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        //.AllowCredentials()
                        //c.WithExposedHeaders("Content-Disposition");
                        );
                });
            }
            else
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithExposedHeaders("Content-Disposition")
                        );
                });
            }
                
        }

        public static T Service<T>() =>
        (T)Startup
        .Provider
        .GetRequiredService(typeof(T));

        public static T GetSetting<T>(string settingName) =>
        (T)Startup
        .Configuration
        .GetSection(settingName)
        .Get<T>();
        #endregion

    }
}
