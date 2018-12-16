using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlParser.Lib.Interfaces;

namespace UrlParser.Lib.Implementation
{
    /// <summary>
    /// Represents a class that provides reading reading from file
    /// </summary>
    public class FileReader : IReader
    {
        #region Fields
        /// <summary>
        /// A field that holds file path
        /// </summary>
        private string filePath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/>  class with specified  file path
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <exception cref="ArgumentNullException">Thrown when file path string is empty or null</exception>
        /// <exception cref="ArgumentException">Thrown when file is not exist</exception>
        public FileReader(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is not initialized.");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"File is not exists.");
            }

            this.filePath = filePath;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Reads strings from file
        /// </summary>
        /// <returns>File strings</returns>
        public IEnumerable<string> ReadLines()
        {
            return Read();
        }

        #endregion

        #region Private API
        /// <summary>
        /// Reads strings from file
        /// </summary>
        /// <returns>File strings</returns>
        private IEnumerable<string> Read()
        {
            List<string> uriList = new List<string>();

            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string line = string.Empty;

                while ((line = streamReader.ReadLine()) != null)
                {
                    uriList.Add(line);
                }
            }

            return uriList;
        }

        #endregion
    }
}
