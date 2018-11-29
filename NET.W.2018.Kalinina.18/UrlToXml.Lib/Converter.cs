using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParser.Lib
{
    public class Converter : IConverter
    {
        public static Logger log = LogManager.GetCurrentClassLogger();

        public IEnumerable<Uri> Convert(IEnumerable<string> list)
        {
            if(list == null || list.Count<string>() == 0)
            {
                throw new ArgumentNullException();
            }

            return ConvertList(list);
        }

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
