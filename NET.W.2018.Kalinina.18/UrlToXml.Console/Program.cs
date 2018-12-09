using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UrlParser.Lib.Interfaces;
using UrlParser.DependencyResolver;
using Ninject;

namespace UrlToXml.Console
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IXmlCreator xmlCreator = resolver.Get<IXmlCreator>();
            xmlCreator.CreateXmlFile($"D:\\1.txt", $"D:\\3.xml");
        }
    }
}
