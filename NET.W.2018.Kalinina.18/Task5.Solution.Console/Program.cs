using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>();
            parts.Add(new BoldText() { Text = "Bold string" });
            parts.Add(new PlainText() { Text = "Plain string" });
            parts.Add(new Hyperlink() { Text = "Hypertext", Url = $"http://github.com" });
            Document document = new Document(parts);

            ITextConverter converter = new ToHtmlConverter();
            System.Console.WriteLine(document.Convert(converter));

            converter = new ToLaTeXConverter();
            System.Console.WriteLine(document.Convert(converter));

            converter = new ToPlainTextConverter();
            System.Console.WriteLine(document.Convert(converter));

            System.Console.ReadLine();

        }

    }
}
