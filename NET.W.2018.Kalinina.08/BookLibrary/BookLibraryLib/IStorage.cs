using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryLib
{
    /// <summary>
    /// Provides methods to read and write elements to file
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public interface IStorage<T>
    {
        /// <summary>
        /// Reads elements from file into list
        /// </summary>
        /// <returns>List of elements</returns>
        List<T> ReadFromFile();

        /// <summary>
        /// Writes element from list into file 
        /// </summary>
        /// <param name="elements">List of elements</param>
        void WriteToFile(List<T> elements);
    }
}
