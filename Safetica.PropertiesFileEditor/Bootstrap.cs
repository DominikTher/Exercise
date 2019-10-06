using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Safetica.Business;
using Safetica.Business.Interface;
using Safetica.Entities;
using System.IO;

namespace Safetica.PropertiesFileEditor
{
    class Bootstrap
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .Build();
        }

        public static ServiceProvider GetServiceProvider(IConfiguration configuration)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ConsoleApp>()
                .AddSingleton<IPropertiesFileEditorService, PropertiesFileEditorService>()
                .AddSingleton<IFooterArranger, FooterArranger>()
                .AddSingleton<IFooterBuilder, FooterBuilder>()
                .Configure<FooterOptions>(configuration.GetSection("footer"))
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
