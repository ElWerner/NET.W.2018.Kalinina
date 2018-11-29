using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UrlParser.Lib
{
    public class Parser : IUriParser
    {
        public XElement Parse(IEnumerable<Uri> uriList)
        {
            if(uriList == null)
            {
                throw new ArgumentNullException($"{nameof(uriList)} is not initialized.");
            }

            XElement rootElement = new XElement("urlAddresses");
            foreach(var uri in uriList)
            {
                rootElement.Add(ParseUri(uri));
            }

            return rootElement;
        }

        private XElement ParseUri(Uri uri)
        {
            XElement uriAddressElement = new XElement("urlAddress");

            uriAddressElement.Add(ParseHostName(uri));

            uriAddressElement.Add(ParseSegments(uri));

            uriAddressElement.Add(ParseParametres(uri));

            return uriAddressElement;
        }

        private XElement ParseHostName(Uri uri)
        {
            XElement hostNameElement = new XElement("host");
            XAttribute hostNameAttribute = new XAttribute("name", uri.Host);
            hostNameElement.Add(hostNameAttribute);

            return hostNameElement;
        }

        private XElement ParseSegments(Uri uri)
        {
            XElement uriElement = new XElement("uri");

            foreach(var segment in uri.Segments)
            {
                if(segment == "/")
                {
                    continue;
                }

                XElement segmentElement = new XElement("segment", segment.Trim('/'));
                uriElement.Add(segmentElement);
            }

            if(uriElement.IsEmpty)
            {
                return null;
            }

            return uriElement;
        }

        private XElement ParseParametres(Uri uri)
        {
            XElement parametresElement = new XElement("parametres");

            string queryString = new Uri(uri.ToString()).Query;
            var parametres = System.Web.HttpUtility.ParseQueryString(queryString);

            for(int i = 0; i < parametres.Count; i++)
            {
                XElement parameterElement = new XElement("parameter");
                XAttribute valueAttribute = new XAttribute("value", parametres.GetValues(i)[0]);
                XAttribute keyAttribute = new XAttribute("key", parametres.GetKey(i));
                parameterElement.Add(valueAttribute);
                parameterElement.Add(keyAttribute);

                parametresElement.Add(parameterElement);
            }

            if(parametresElement.IsEmpty)
            {
                return null;
            }

            return parametresElement;
        }

    }
}
