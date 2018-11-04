using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// Overrides base class method BookToString to return title of the book
    /// </summary>
    public class BookFormatExtensionTitle : BookDecorator, IBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatExtensionTitle"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookFormatExtensionTitle(IBook book) : base(book)
        {
        }

        /// <summary>
        /// Returns string representation of the book instance with book title
        /// </summary>
        /// <returns>String representation of the book instance with book title</returns>
        public override string ToString()
        {
            return $"{base.ToString()} {book.Title},".TrimStart();
        }
    }

    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// Overrides base class method BookToString to return author of the book
    /// </summary>
    public class BookFormatExtensionAuthor : BookDecorator, IBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatExtensionAuthor"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookFormatExtensionAuthor(IBook book) : base(book)
        {
        }

        /// <summary>
        /// Returns string representation of the book instance with book author
        /// </summary>
        /// <returns>String representation of the book instance with book author</returns>
        public override string ToString()
        {
            return $"{base.ToString()} {book.Author},".TrimStart();
        }
    }

    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// Overrides base class method BookToString to return publishing house of the book
    /// </summary>
    public class BookFormatExtensionPublishingHouse : BookDecorator, IBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatExtensionPublishingHouse"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookFormatExtensionPublishingHouse(IBook book) : base(book)
        {
        }

        /// <summary>
        /// Returns string representation of the book instance with publishing house
        /// </summary>
        /// <returns>String representation of the book instance with publishing house</returns>
        public override string ToString()
        {
            return $"{base.ToString()} {book.PublishingHouse},".TrimStart();
        }
    }

    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// Overrides base class method BookToString to return ISBN of the book
    /// </summary>
    public class BookFormatExtensionIsbn : BookDecorator, IBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatExtensionPublishingHouse"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookFormatExtensionIsbn(IBook book) : base(book)
        {
        }

        /// <summary>
        /// Returns string representation of the book instance with ISBN
        /// </summary>
        /// <returns>String representation of the book instance with ISBN</returns>
        public override string ToString()
        {
            return $"ISBN 13: {book.Isbn}, {base.ToString()}".TrimStart();
        }
    }

    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// Overrides base class method BookToString to return year of publishing
    /// </summary>
    public class BookFormatExtensionYear : BookDecorator, IBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatExtensionPublishingHouse"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookFormatExtensionYear(IBook book) : base(book)
        {
        }

        /// <summary>
        /// Returns string representation of the book instance with year of publishing
        /// </summary>
        /// <returns>String representation of the book instance with year of publishing</returns>
        public override string ToString()
        {
            return $"{base.ToString()} {book.Year},".TrimStart();
        }
    }

    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// Overrides base class method BookToString to return number of pages
    /// </summary>
    public class BookFormatExtensionPages : BookDecorator, IBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatExtensionPublishingHouse"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        public BookFormatExtensionPages(IBook book) : base(book)
        {
        }

        /// <summary>
        /// Returns string representation of the book instance with number of pages
        /// </summary>
        /// <returns>String representation of the book instance with number of pages</returns>
        public override string ToString()
        {
            return $"{base.ToString()} P. {book.Pages},".TrimStart();
        }
    }

    /// <summary>
    /// Represents a class that provides extending functionality of the book object. 
    /// Overrides base class method BookToString to return price of the book
    /// </summary>
    public class BookFormatExtensionPrice : BookDecorator, IBook
    {
        /// <summary>
        /// A field to hold culture info
        /// </summary>
        CultureInfo cultureInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatExtensionPublishingHouse"/> class
        /// </summary>
        /// <param name="book">Extandable object</param>
        /// <param name="cultureInfo">Culture info</param>
        /// <exception cref="ArgumentNullException">Thrown when culture info is null</exception>
        public BookFormatExtensionPrice(IBook book, CultureInfo cultureInfo) : base(book)
        {
            if(cultureInfo == null)
            {
                throw new ArgumentNullException("Culture Info is null.");
            }

            this.cultureInfo = cultureInfo;
        }

        /// <summary>
        /// Returns string representation of the book instance with price of the book
        /// </summary>
        /// <returns>String representation of the book instance with price of the book</returns>
        public override string ToString()
        {
            IFormatProvider fp = new PriceFormatProvider(cultureInfo);

            return $"{base.ToString()} {string.Format(fp, "{0}", book.Price)},".TrimStart();
        }
    }
}
