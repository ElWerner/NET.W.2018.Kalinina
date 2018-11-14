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
        #region Fields
        /// <summary>
        /// A filed to hold instance of the extandable object
        /// </summary>
        protected IBook book;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BookDecorator"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookDecorator(IBook book)
        {
            if (book == null)
            {
                BookServiceLogger.log.Error("Book parameter is null.");
                throw new ArgumentNullException("Book is not initialized.");
            }

            this.book = book;
            BookServiceLogger.log.Trace("Initialized a new instance of the BookDecorator class.");
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets ISBN of the book
        /// </summary>
        public string Isbn => book.Isbn;

        /// <summary>
        /// Gets title of the book
        /// </summary>
        public string Title => book.Title;

        /// <summary>
        /// Get author of the book
        /// </summary>
        public string Author => book.Author;

        /// <summary>
        /// Gets publishing house of the book
        /// </summary>
        public string PublishingHouse => book.PublishingHouse;

        /// <summary>
        /// Gets price of the book
        /// </summary>
        public decimal Price => book.Price;

        /// <summary>
        /// Gets year of publication
        /// </summary>
        public int Year => book.Year;

        /// <summary>
        /// Gets number of pages of the book
        /// </summary>
        public int Pages => book.Pages;

        #endregion

        #region Methods
        /// <summary>
        /// Returns string representation of the instance
        /// </summary>
        /// <returns></returns>
        public new virtual string ToString()
        {
            return book.ToString();
        }

        #endregion
    }
}
