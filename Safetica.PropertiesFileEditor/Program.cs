using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Safetica.PropertiesFileEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var configuration = Bootstrap.GetConfiguration();

                using (var serviceProvider = Bootstrap.GetServiceProvider(configuration))
                {
                    var service = serviceProvider.GetRequiredService<ConsoleApp>();
                    var files = configuration.GetSection("files").GetChildren().Select(childer => childer.Value);
                    service.RunPropertiesFileEditor(files);
                }

                Console.WriteLine("Processing finished");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Program unexpectedly failed, {exception.Message}");
            }
        }
    }
}
