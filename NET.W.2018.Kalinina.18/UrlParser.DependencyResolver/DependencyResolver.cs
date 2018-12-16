using Ninject;
using UrlParser.Lib.Implementation;
using UrlParser.Lib.Interfaces;

namespace UrlParser.DependencyResolver
{
    /// <summary>
    /// Represents a class that provides resolving dependencies
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Binds interfaces to implementation
        /// </summary>
        /// <param name="kernel"></param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IXmlCreator>().To<XmlCreator>();
        }
    }
}
