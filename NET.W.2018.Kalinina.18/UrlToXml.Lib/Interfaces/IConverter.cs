using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParser.Lib.Interfaces
{
    /// <summary>
    /// Provides converter, that supports converting list of url address strings to uri
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Converts list of url address strings to uri list
        /// </summary>
        /// <param name="list">Url address strings</param>
        /// <returns>Uri addresses</returns>
        IEnumerable<Uri> Convert(IEnumerable<string> list);
    }
}
