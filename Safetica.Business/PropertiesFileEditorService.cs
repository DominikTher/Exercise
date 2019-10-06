using Microsoft.Extensions.Options;
using Safetica.Business.Interface;
using Safetica.Entities;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Safetica.Business
{
    public class PropertiesFileEditorService : IPropertiesFileEditorService
    {
        private readonly FooterOptions footerOptions;
        private readonly IFooterArranger footerArranger;

        public PropertiesFileEditorService(IOptions<FooterOptions> footerOptions, IFooterArranger footerArranger)
        {
            this.footerOptions = footerOptions.Value;
            this.footerArranger = footerArranger;
        }

        public void Process(string filePath)
        {
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            var text = ReadToEnd(stream, footerOptions.MaxLength);
            footerArranger.Arrange(stream, text);
        }

        private string ReadToEnd(Stream stream, int maxLength)
        {
            var length = (stream.Length < maxLength) ? (int)stream.Length : maxLength;
            byte[] bytes = new byte[length];
            stream.Seek(length * -1, SeekOrigin.End);
            stream.Read(bytes, 0, length);

            var text = Encoding.Default.GetString(bytes).Replace("\0", string.Empty);
            return text;
        }
    }
}
