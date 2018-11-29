using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UrlParser.Lib
{
    public class XmlCreator
    {
        public void CreateXmlFile(string openFilePath, string saveFielPath)
        {
            if(string.IsNullOrEmpty(openFilePath))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(saveFielPath))
            {
                throw new ArgumentNullException();
            }

            if(!File.Exists(openFilePath))
            {
                throw new ArgumentException();
            }

            CreateXml(openFilePath, saveFielPath);
        }

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
