using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UrlParser.Lib.Interfaces;

namespace UrlParser.Lib.Interfaces
{
    /// <summary>
    /// Represents a class that provides parsing url strings into xml format
    /// </summary>
    public class Parser : IUriParser
    {
        #region Public API
        /// <summary>
        /// Parses list of uri strings to xml format
        /// </summary>
        /// <param name="uriList">List of uri strings</param>
        /// <returns>Parsed url strings in the xml format</returns>
        /// <exception cref="ArgumentNullException">Thrown when list of url addresses is not initialized</exception>
        public XElement Parse(IEnumerable<Uri> uriList)
        {
            if (uriList == null)
            {
                throw new ArgumentNullException($"{nameof(uriList)} is not initialized.");
            }

            XElement rootElement = new XElement("urlAddresses");
            foreach (var uri in uriList)
            {
                rootElement.Add(ParseUri(uri));
            }

            return rootElement;
        }

        #endregion

        #region Private API

        /// <summary>
        /// Parses url address string to xml format
        /// </summary>
        /// <param name="uri">Url address string</param>
        /// <returns>Parsed url string in the xml format</returns>
        private XElement ParseUri(Uri uri)
        {
            XElement uriAddressElement = new XElement("urlAddress");

            uriAddressElement.Add(ParseHostName(uri));

            uriAddressElement.Add(ParseSegments(uri));

            uriAddressElement.Add(ParseParametres(uri));

            return uriAddressElement;
        }

        /// <summary>
        /// Creates xml element, that holds host name of the uri
        /// </summary>
        /// <param name="uri">Uri address</param>
        /// <returns>Xml element, that holds host name of the uri</returns>
        private XElement ParseHostName(Uri uri)
        {
            XElement hostNameElement = new XElement("host");
            XAttribute hostNameAttribute = new XAttribute("name", uri.Host);
            hostNameElement.Add(hostNameAttribute);

            return hostNameElement;
        }

        /// <summary>
        /// Creates xml element, that holds segments info of the uri
        /// </summary>
        /// <param name="uri">Uri address</param>
        /// <returns>Xml element, that holds segments info of the uri</returns>
        private XElement ParseSegments(Uri uri)
        {
            XElement uriElement = new XElement("uri");

            foreach (var segment in uri.Segments)
            {
                if (segment == "/")
                {
                    continue;
                }

                XElement segmentElement = new XElement("segment", segment.Trim('/'));
                uriElement.Add(segmentElement);
            }

            if (uriElement.IsEmpty)
            {
                return null;
            }

            return uriElement;
        }

        /// <summary>
        /// Creates xml element, that holds parameters of the uri
        /// </summary>
        /// <param name="uri">Uri address</param>
        /// <returns>Xml element, that holds parameters of the uri</returns>
        private XElement ParseParametres(Uri uri)
        {
            XElement parametresElement = new XElement("parametres");

            string queryString = new Uri(uri.ToString()).Query;
            var parametres = System.Web.HttpUtility.ParseQueryString(queryString);

            for (int i = 0; i < parametres.Count; i++)
            {
                XElement parameterElement = new XElement("parameter");
                XAttribute valueAttribute = new XAttribute("value", parametres.GetValues(i)[0]);
                XAttribute keyAttribute = new XAttribute("key", parametres.GetKey(i));
                parameterElement.Add(valueAttribute);
                parameterElement.Add(keyAttribute);

                parametresElement.Add(parameterElement);
            }

            if (parametresElement.IsEmpty)
            {
                return null;
            }

            return parametresElement;
        }

        #endregion
    }
}
