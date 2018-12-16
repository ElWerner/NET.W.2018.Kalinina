using System.Collections.Generic;

namespace UrlParser.Lib.Interfaces
{
    /// <summary>
    /// Provides reader, that supports reading url addresses from file
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads url addresses from file
        /// </summary>
        /// <returns>Url addresses</returns>
        IEnumerable<string> ReadLines();
    }
}
