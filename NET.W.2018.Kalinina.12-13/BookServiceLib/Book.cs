using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NLog;
using NLog.Fluent;

namespace BookServiceLib
{
    /// <summary>
    /// Class that represents book entity
    /// </summary>
    public class Book : IBook
    {
        #region Fields
        /// <summary>
        /// A field to hold isbn of the book
        /// </summary>
        private string isbn;

        /// <summary>
        /// A field to hold title of the book
        /// </summary>
        private string title;

        /// <summary>
        /// A field to hold author's name
        /// </summary>
        private string author;

        /// <summary>
        /// A field to hold year of publishing
        /// </summary>
        private int year;

        /// <summary>
        /// A field to hold name of the publishing house
        /// </summary>
        private string publishingHouse;

        /// <summary>
        /// A field to hold book price
        /// </summary>
        private decimal price;

        /// <summary>
        /// A filed to hold amount of pages in the book
        /// </summary>
        private int pages;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class with specified parametres
        /// </summary>
        /// <param name="isbn">Book isbn</param>
        /// <param name="title">Book title</param>
        /// <param name="author">Author's name</param>
        /// <param name="publishingHouse">Publishing house</param>
        /// <param name="year">Year of publishing</param>
        /// <param name="price">Book price</param>
        /// <param name="pages">Amount of pages</param>
        public Book(string isbn, string title, string author, string publishingHouse, int year, decimal price, int pages)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            PublishingHouse = publishingHouse;
            Year = year;
            Price = price;
            Pages = pages;

            BookServiceLogger.log.Trace("Created new instance of the Book class");
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets book ISBN
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when ISBN string is null or empty</exception>
        /// <exception cref="ArgumentException">Thrown when ISBN string doesn't match ISBN format</exception>
        public string Isbn
        {
            get { return isbn; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    BookServiceLogger.log.Error("ISBN string is not initialized.");
                    throw new ArgumentNullException("ISBN string is not initialized.");
                }

                Regex reg = new Regex("[0-9]{3}-[0-9]{1}-[0-9]{4}-[0-9]{4}-[0-9]{1}$");

                if(!reg.IsMatch(value))
                {
                    BookServiceLogger.log.Error("ISBN string doesn't conform to the expected ISBN format.");
                    throw new ArgumentException("ISBN string doesn't conform to the expected ISBN format.");
                }

                isbn = value;
            }
        }

        /// <summary>
        /// Gets or sets book title
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when title string is null or empty</exception>
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    BookServiceLogger.log.Error("Ttile string is not initialized.");
                    throw new ArgumentNullException("Title is not initialized.");
                }

                title = value;
            }
        }

        /// <summary>
        /// Gets or sets author's name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when author's name string is null or empty</exception>
        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    BookServiceLogger.log.Error("Author's name string is not initialized.");
                    throw new ArgumentNullException("Author's name is not initialized.");
                }

                author = value;
            }
        }

        /// <summary>
        /// Gets or sets book name of the publishing house
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when publishing house string is null or empty</exception>
        public string PublishingHouse
        {
            get
            {
                return publishingHouse;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    BookServiceLogger.log.Error("Publishing house string is not initialized.");
                    throw new ArgumentNullException("Publishing house is not initialized.");
                }

                publishingHouse = value;
            }
        }

        /// <summary>
        /// Gets or sets year of publishing
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when year is less than 0</exception>
        public int Year
        {
            get { return year; }
            set
            {
                if (value < 0)
                {
                    BookServiceLogger.log.Error("Year is out of range.");
                    throw new ArgumentOutOfRangeException("Year is out of range");
                }

                year = value;
            }
        }

        /// <summary>
        /// Gets or sets book price
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when price is less than 0</exception>
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    BookServiceLogger.log.Error("Price is out of range.");
                    throw new ArgumentOutOfRangeException("Price is out of range");
                }

                price = value;
            }
        }

        /// <summary>
        /// Gets or sets amount of pages
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount of pages is less than 0</exception>
        public int Pages
        {
            get { return pages; }
            set
            {
                if (value < 0)
                {
                    BookServiceLogger.log.Error("Amount of pages is out of range.");
                    throw new ArgumentOutOfRangeException("Amount of pages is out of range");
                }

                pages = value;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Returns a string representation of instance
        /// </summary>
        /// <returns>A string that represents instance</returns>
        public new string ToString()
        {
            return "";
        }

        #endregion
    }
}
