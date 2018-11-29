using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UrlParser.Lib
{
    interface IUriParser
    {
        XElement Parse(IEnumerable<Uri> elements);
    }
}
