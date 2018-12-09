using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UrlParser.Lib.Interfaces;

namespace UrlParser.Lib.Implementation
{
    /// <summary>
    /// Represents a class that provides creating xml document based on url strings, stored in file
    /// </summary>
    public class XmlCreator : IXmlCreator
    {
        /// <summary>
        /// Creates xml document based on url strings, stored in file
        /// </summary>
        /// <param name="openFilePath">Path to the file with url strings</param>
        /// <param name="saveFielPath">Path to the xml document</param>
        /// <exception cref="ArgumentNullException">Thrown when file path or xml document 
        /// file path is not initialized</exception>
        /// <exception cref="ArgumentException">Thrown when opened file is not exist</exception>
        public void CreateXmlFile(string openFilePath, string saveFielPath)
        {
            if(string.IsNullOrEmpty(openFilePath))
            {
                throw new ArgumentNullException("Open file path is not initialized.");
            }

            if (string.IsNullOrEmpty(saveFielPath))
            {
                throw new ArgumentNullException("Save file path is not initializes");
            }

            if(!File.Exists(openFilePath))
            {
                throw new ArgumentException($"{nameof(openFilePath)} is not exist.");
            }

            CreateXml(openFilePath, saveFielPath);
        }

        /// <summary>
        /// Creates xml document based on url strings, stored in file
        /// </summary>
        /// <param name="openFilePath">Path to the file with url strings</param>
        /// <param name="saveFielPath">Path to the xml document</param>
        private void CreateXml(string openFilePath, string saveFielPath)
        {
            IReader reader = new FileReader(openFilePath);
            IEnumerable<string> uriStrings = reader.ReadLines();
            IUriParser parser = new Parser();
            IEnumerable<Uri> uris = new Converter().Convert(uriStrings);
            XDocument doc = new XDocument(parser.Parse(uris));
            doc.Save(saveFielPath);
        }
    }
}
