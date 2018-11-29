using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class Document
    {
        private readonly List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }
        
        public List<DocumentPart> Parts
        {
            get
            {
                return parts;
            }
        }


        public string Convert(ITextConverter converter)
        {
            if(converter == null)
            {
                throw new ArgumentNullException($"{nameof(converter)} is null.");
            }

            return converter.Convert(parts);
        }
    }
}
