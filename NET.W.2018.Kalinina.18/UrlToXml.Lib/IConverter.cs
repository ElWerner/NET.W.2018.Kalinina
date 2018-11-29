using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParser.Lib
{
    interface IConverter
    {
        IEnumerable<Uri> Convert(IEnumerable<string> list);
    }
}
