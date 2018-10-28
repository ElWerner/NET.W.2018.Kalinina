using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryLib
{
    /// <summary>
    /// Provides method that finds element by specified tag
    /// </summary>
    /// <typeparam name="T">Type of objects</typeparam>
    public interface IPredicate<in T>
    {
        /// <summary>
        /// Checks if element tag equals to the specified tag
        /// </summary>
        /// <param name="tagPredicate">Element to check</param>
        /// <returns>True if tags are equal. False otherwise</returns>
        bool FindByTag(T tagPredicate);
    }
}
