using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Physemp.Feed.Tools
{
    class XMLReader
    {
        public static XDocument getDoc(string file)
        {
            return XDocument.Load(file);
        }
    }
}
