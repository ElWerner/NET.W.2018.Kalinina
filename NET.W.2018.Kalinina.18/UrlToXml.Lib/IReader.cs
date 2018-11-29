using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParser.Lib
{
    public interface IReader
    {
        IEnumerable<string> ReadLines();
    }
}
