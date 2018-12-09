using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlParser.Lib.Interfaces;
using UrlParser.Lib.Implementation;

namespace UrlParser.DependencyResolver
{
    public static class DependencyResolver
    {
        /// <summary>
        /// Binds interfaces to implementaton
        /// </summary>
        /// <param name="kernel"></param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IXmlCreator>().To<XmlCreator>();
        }
    }
}
