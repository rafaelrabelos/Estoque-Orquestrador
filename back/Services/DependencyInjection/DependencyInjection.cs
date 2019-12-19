using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace Estorquestrador.Services
{

    public class DependencyInjection
    {
        public static T Service<T>() =>
        (T)Startup
        .Provider
        .GetRequiredService(typeof(T));
        
        public static T GetSetting<T>(string settingName) =>
        (T)Startup
        .Configuration
        .GetSection(settingName)
        .Get<T>();
    }
}