using Microsoft.Extensions.Options;
using Safetica.Business.Interface;
using Safetica.Entities;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Safetica.Business
{
    public class FooterArranger : IFooterArranger
    {
        private readonly FooterOptions footerOptions;
        private readonly IFooterBuilder footerBuilder;
        private int footerHeaderIndex = -1;

        public FooterArranger(IOptions<FooterOptions> footerOptions, IFooterBuilder footerBuilder)
        {
            this.footerOptions = footerOptions.Value;
            this.footerBuilder = footerBuilder;
        }

        public void Arrange(Stream stream, string text)
        {
            try
            {
                footerHeaderIndex = GetFooterHeaderIndex(text);
                CreateFooter(stream, HasFooter(), text);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Footer arrager exception: {exception.Message}");
            }
        }

        private void CreateFooter(Stream stream, bool hasFooter, string originalFooter)
        {
            var text = footerBuilder.Build();

            if (text.Length > footerOptions.MaxLength)
                throw new Exception($"Footer contains more than {footerOptions.MaxLength} characters");

            if (hasFooter) stream.SetLength(stream.Length - (originalFooter.Length - footerHeaderIndex));
            stream.Write(Encoding.Default.GetBytes(text));
        }

        private bool HasFooter()
        {
            return footerHeaderIndex >= 0;
        }

        private int GetFooterHeaderIndex(string text)
        {
            return text.IndexOf(footerOptions.Header);
        }
    }
}