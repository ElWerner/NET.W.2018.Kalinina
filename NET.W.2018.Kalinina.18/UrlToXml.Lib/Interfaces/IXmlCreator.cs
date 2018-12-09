using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParser.Lib.Interfaces
{
    /// <summary>
    /// Xml creator, that provides creating xml document based on file, that stores url addresses
    /// </summary>
    public interface IXmlCreator
    {
        /// <summary>
        /// Creates xml document based on file, that stores url addresses
        /// </summary>
        /// <param name="openFilePath">File, that stores url strings</param>
        /// <param name="saveFielPath">Path to the xml document</param>
        void CreateXmlFile(string openFilePath, string saveFielPath);
    }
}
