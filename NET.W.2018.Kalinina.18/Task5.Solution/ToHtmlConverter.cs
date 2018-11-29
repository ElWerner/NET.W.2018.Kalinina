using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class ToHtmlConverter : ITextConverter
    {
        public string Convert(IEnumerable<DocumentPart> parts)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var part in parts)
            {
                switch (part.GetType().Name)
                {
                    case "BoldText":
                        builder.Append("<b>" + part.Text + "</b>\n");
                        break;
                    case "Hyperlink":
                        builder.Append("<a href=\"" + ((Hyperlink)part).Url + "\">" + part.Text + "</a>\n");
                        break;
                    case "PlainText":
                        builder.Append(part.Text + "\n");
                        break;
                    default:
                        throw new ArgumentException("Type is not defined.");
                }
            }

            return builder.ToString();
        }
    }
}
