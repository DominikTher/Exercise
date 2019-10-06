using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Safetica.Business.Interface
{
    public interface IPropertiesFileEditorService
    {
        void Process(string filePath);
    }
}
