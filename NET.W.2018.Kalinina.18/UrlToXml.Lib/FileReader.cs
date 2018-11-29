using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParser.Lib
{
    public class FileReader : IReader
    {
        private string filePath;

        public FileReader(string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is not initialized.");
            }

            if(!File.Exists(filePath))
            {
                throw new ArgumentException($"File is not exists.");
            }

            this.filePath = filePath;
        }

        public IEnumerable<string> ReadLines()
        {
            return Read();
        }

        private IEnumerable<string> Read()
        {
            List<string> uriList = new List<string>();

            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string line = String.Empty;

                while ((line = streamReader.ReadLine()) != null)
                {
                    uriList.Add(line);
                }
            }

            return uriList;
        }
    }
}
