using System.IO;

namespace Safetica.Business.Interface
{
    public interface IFooterArranger
    {
        void Arrange(Stream stream, string text);
    }
}
