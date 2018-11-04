using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// </summary>
    public class BookGenreDecorator : BookDecorator, IBook
    {
        #region Fields

        /// <summary>
        /// A field to hold genre of the book
        /// </summary>
        private string genre;

        #endregion

        #region Construtrs
        /// <summary>
        /// Initializes a new instance of the <see cref="BookGenreDecorator"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        /// <param name="genre">Book genre</param>
        public BookGenreDecorator(IBook book, string genre) : base(book)
        {
            this.Genre = genre;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets genre of the book
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when genre string is empty or null</exception>
        public string Genre
        {
            get
            {
                return genre;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Genre is not initialized.");
                }

                genre = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns string representation of the book instance with book genre
        /// </summary>
        /// <returns>String representation of the book instance with book genre</returns>
        public override string ToString()
        {
            return $"{base.ToString()} {this.genre},";
        }

        #endregion
    }
}
