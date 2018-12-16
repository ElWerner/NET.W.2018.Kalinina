using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceLib
{
    /// <summary>
    /// Represents a class that provides extending functionality of the book object 
    /// </summary>
    public class BookDecorator : IBook
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BookDecorator"/> class
        /// </summary>
        /// <param name="book">Extendable object</param>
        public BookDecorator(IBook book)
        {
            if (book == null)
            {
                BookServiceLogger.Log.Error("Book parameter is null.");
                throw new ArgumentNullException("Book is not initialized.");
            }

            this.Book = book;
            BookServiceLogger.Log.Trace("Initialized a new instance of the BookDecorator class.");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets instance to the <see cref="IBook"/> interface
        /// </summary>
        public IBook Book { get; set; }

        /// <summary>
        /// Gets ISBN of the book
        /// </summary>
        public string Isbn => Book.Isbn;

        /// <summary>
        /// Gets title of the book
        /// </summary>
        public string Title => Book.Title;

        /// <summary>
        /// Get author of the book
        /// </summary>
        public string Author => Book.Author;

        /// <summary>
        /// Gets publishing house of the book
        /// </summary>
        public string PublishingHouse => Book.PublishingHouse;

        /// <summary>
        /// Gets price of the book
        /// </summary>
        public decimal Price => Book.Price;

        /// <summary>
        /// Gets year of publication
        /// </summary>
        public int Year => Book.Year;

        /// <summary>
        /// Gets number of pages of the book
        /// </summary>
        public int Pages => Book.Pages;

        #endregion

        #region Methods
        /// <summary>
        /// Returns string representation of the instance
        /// </summary>
        /// <returns></returns>
        public new virtual string ToString()
        {
            return Book.ToString();
        }

        #endregion
    }
}
