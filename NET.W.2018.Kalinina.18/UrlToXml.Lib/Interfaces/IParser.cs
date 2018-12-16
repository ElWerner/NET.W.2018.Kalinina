using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace UrlParser.Lib.Interfaces
{
    /// <summary>
    /// Provides parser, that supports parsing uri addresses to xml document 
    /// </summary>
    public interface IUriParser
    {
        /// <summary>
        /// Parses uri addresses to xml document
        /// </summary>
        /// <param name="elements">Uri addresses</param>
        /// <returns>Xml document</returns>
        XElement Parse(IEnumerable<Uri> elements);
    }
}
