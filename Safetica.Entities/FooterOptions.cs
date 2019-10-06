using System;
using System.Collections.Generic;
using System.Text;

namespace Safetica.Entities
{
    public class FooterOptions
    {
        public string Header { get; set; }
        public char Separator { get; set; }
        public string PropertySeparator { get; set; }
        public int MaxLength { get; set; }
        public IDictionary<string, string> Properties { get; set; }
    }
}
