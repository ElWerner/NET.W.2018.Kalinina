using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Class that represents book entity
    /// </summary>
    public class Book : IBook
    {
        /// <summary>
        /// A field to hold title of the book
        /// </summary>
        protected string title;

        /// <summary>
        /// A field to hold author's name
        /// </summary>
        protected string author;

        /// <summary>
        /// A field to hold year of publishing
        /// </summary>
        protected int year;

        /// <summary>
        /// A field to hold name of the publishing house
        /// </summary>
        protected string publishingHouse;

        /// <summary>
        /// A field to hold edition number
        /// </summary>
        protected int edition;

        /// <summary>
        /// A field to hold book price
        /// </summary>
        protected decimal price;

        /// <summary>
        /// A filed to hold amount of pages in the book
        /// </summary>
        protected int pages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class with specified parametres
        /// </summary>
        /// <param name="title">Book title</param>
        /// <param name="author">Author's name</param>
        /// <param name="publishingHouse">Publishing house</param>
        /// <param name="year">Year of publishing</param>
        /// <param name="edition">Edition number</param>
        /// <param name="price">Book price</param>
        /// <param name="pages">Amount of pages</param>
        public Book (string title, string author, string publishingHouse, int year, int edition, decimal price, int pages)
        {
            Title = title;
            Author = author;
            PublishingHouse = publishingHouse;
            Year = year;
            Edition = edition;
            Price = price;
            Pages = pages;
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
                if(string.IsNullOrEmpty(value))
                {
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
                if(string.IsNullOrEmpty(value))
                {
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
            get { return publishingHouse; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
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
                if(value < 0)
                {
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
                if(value < 0)
                {
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
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Amount of pages is out of range");
                }

                pages = value;
            }
        }

        /// <summary>
        /// Gets or sets edition number
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when edition number is less than 0</exception>
        public int Edition
        {
            get { return edition; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Edition number is out of range");
                }

                edition = value;
            }
        }

        /// <summary>
        /// Returns a string representation of instance
        /// </summary>
        /// <returns>A string that represents instance</returns>
        public new string ToString()
        {
            return "Book record:";
        }
    }
}
