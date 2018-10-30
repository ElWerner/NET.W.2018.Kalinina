using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookExtension
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
            return $"{base.ToString()} {book.Title},"; 
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
            return $"{base.ToString()} {book.Author},";
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
            return $"{base.ToString()} {book.PublishingHouse},";
        }
    }
}
