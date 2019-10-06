using Microsoft.Extensions.Options;
using Safetica.Business.Interface;
using Safetica.Entities;
using System.Text;

namespace Safetica.Business
{
    public class FooterBuilder : IFooterBuilder
    {
        private readonly FooterOptions footerOptions;
        private StringBuilder footerBuilder;

        public FooterBuilder(IOptions<FooterOptions> footerOptions)
        {
            this.footerOptions = footerOptions.Value;
        }
        public string Build()
        {
            footerBuilder = new StringBuilder();
            CreateFooterHeader();
            CreateFooterProperties();

            return footerBuilder.ToString();
        }

        private void CreateFooterHeader()
        {
            footerBuilder.Append(footerOptions.Header);
        }

        private void CreateFooterProperties()
        {
            foreach (var item in footerOptions.Properties)
            {
                footerBuilder
                    .Append(footerOptions.Separator)
                    .Append(string.Join(footerOptions.PropertySeparator, item.Key, item.Value));
            }
        }
    }
}
