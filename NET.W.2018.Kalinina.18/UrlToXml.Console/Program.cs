using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UrlParser.Lib;

namespace UrlToXml.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlCreator xmlCreator = new XmlCreator();
            xmlCreator.CreateXmlFile($"D:\\1.txt", $"D:\\2.xml");
        }
    }
}
