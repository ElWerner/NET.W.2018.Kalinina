using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookExtension
{
    /// <summary>
    /// Represents a class that provides extending functionality of the book object 
    /// </summary>
    public class BookDecorator : IBook
    {
        /// <summary>
        /// A filed to hold instance of the extandable object
        /// </summary>
        protected IBook book;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookDecorator"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookDecorator(IBook book)
        {
            this.book = book ?? throw new ArgumentNullException("Book is not initialized.");
        }

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
        /// Gets book edition
        /// </summary>
        public int Edition => book.Edition;

        /// <summary>
        /// Gets year of publication
        /// </summary>
        public int Year => book.Year;

        /// <summary>
        /// Gets number of pages of the book
        /// </summary>
        public int Pages => book.Pages;

        /// <summary>
        /// Returns string representation of the instance
        /// </summary>
        /// <returns></returns>
        public new virtual string ToString()
        {
            return book.ToString();
        }
    }
}
