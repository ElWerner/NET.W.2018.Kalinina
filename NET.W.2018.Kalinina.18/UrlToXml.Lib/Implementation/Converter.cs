using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlParser.Lib.Interfaces;

namespace UrlParser.Lib.Implementation
{
    /// <summary>
    /// Represents a class that provides converting list of strings to uri strings
    /// </summary>
    public class Converter : IConverter
    {
        /// <summary>
        /// A field that holds logger variable
        /// </summary>
        public static Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Converts list of strings to uri strings, if possible
        /// </summary>
        /// <param name="list">List of strings</param>
        /// <returns>Uri strings</returns>
        /// <exception cref="ArgumentNullException">Thrown when list of strings is empty or not initialized</exception>
        public IEnumerable<Uri> Convert(IEnumerable<string> list)
        {
            if(list == null || list.Count<string>() == 0)
            {
                throw new ArgumentNullException("List of url strings is not initialized.");
            }

            return ConvertList(list);
        }

        /// <summary>
        /// Converts list of strings to uri strings, if possible, 
        /// or writes error into log file if a strings is not a correct url address
        /// </summary>
        /// <param name="stringList">List of strings</param>
        /// <returns>Uri strings</returns>
        private IEnumerable<Uri> ConvertList(IEnumerable<string> stringList)
        {
            List<Uri> uris = new List<Uri>();

            foreach (var element in stringList)
            {
                Uri newUri;

                if (Uri.TryCreate(element, UriKind.Absolute, out newUri))
                {
                    uris.Add(newUri);
                }
                else
                {
                    log.Error($"String was not processed: {element}.");
                }
            }

            return uris;
        }
    }
}
