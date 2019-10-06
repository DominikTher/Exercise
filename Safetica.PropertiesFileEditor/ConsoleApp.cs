using Microsoft.Extensions.Options;
using Safetica.Business.Interface;
using Safetica.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Safetica.PropertiesFileEditor
{
    public class ConsoleApp
    {
        private readonly IPropertiesFileEditorService propertiesFileEditorService;

        public ConsoleApp(IPropertiesFileEditorService propertiesFileEditorService)
        {
            this.propertiesFileEditorService = propertiesFileEditorService;
        }

        public void RunPropertiesFileEditor(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                try
                {
                    propertiesFileEditorService.Process(file);
                }
                catch (Exception excelption)
                {
                    Console.WriteLine($"Processing failed for: {file}, {excelption.Message}");
                }
            }
        }
    }
}
