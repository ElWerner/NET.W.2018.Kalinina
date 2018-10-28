using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryLib
{
    /// <summary>
    /// Class that represents book entity
    /// </summary>
    public class Book : IComparable<Book>, IEquatable<Book>
    {
        /// <summary>
        /// A field to hold ISBN
        /// </summary>
        private string isbn;

        /// <summary>
        /// A field to hold author name
        /// </summary>
        private string author;

        /// <summary>
        /// A field to hold title of the book
        /// </summary>
        private string title;

        /// <summary>
        /// A field to hold publisher name
        /// </summary>
        private string publisher;

        /// <summary>
        /// A field to hold year of publication of the book
        /// </summary>
        private int publicationYear;

        /// <summary>
        /// A field to hold number of pages in the book
        /// </summary>
        private int numberOfPages;

        /// <summary>
        /// Initializes a new instanceof the <see cref="Book"/> with specified parametres
        /// </summary>
        /// <param name="isbn">ISBN</param>
        /// <param name="author">Author's name</param>
        /// <param name="title">Title</param>
        /// <param name="publisher">Publisher</param>
        /// <param name="publicationYear">Year of publication</param>
        /// <param name="numberOfPages">Number of pages</param>
        public Book(string isbn, string author, string title, string publisher, int publicationYear, int numberOfPages)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            PublicationYear = publicationYear;
            NumberOfPages = numberOfPages;
        }

        /// <summary>
        /// Gets or sets ISBN
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when ISBN string is null or empty</exception>
        public string ISBN
        {
            get
            {
                return isbn;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ISBN string is empty.");
                }
                else
                {
                    isbn = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets author's name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when author's name is null or empty</exception>
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Author string is empty.");
                }
                else
                {
                    author = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets title of the book
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when title string is null or empty</exception>
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title string is empty.");
                }
                else
                {
                    title = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets publisher's name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when publisher string is null or empty</exception>
        public string Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Publisher string is empty.");
                }
                else
                {
                    publisher = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets year of publication
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when year of publication
        /// is less then 0</exception>
        public int PublicationYear
        {
            get
            {
                return publicationYear;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Year of publication cannot " +
                        "be less or equal to zero.");
                }
                else
                {
                    publicationYear = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets number of pages in the book
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when number of pages
        /// is less then 0</exception>
        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Amount of pages cannot be less or equal to zero.");
                }
                else
                {
                    numberOfPages = value;
                }
            }
        }

        /// <summary>
        /// Compares this object to the specified object
        /// </summary>
        /// <param name="obj">Specified object to compare</param>
        /// <returns>True if objects are equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Book book = obj as Book;

                return Equals(book);
            }
        }

        /// <summary>
        /// Calculates a hash code for this instance
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            hash += isbn.GetHashCode() * 17;
            hash += author.GetHashCode() * 18;
            hash += title.GetHashCode() * 19;
            hash += publisher.GetHashCode() * 20;
            hash += publicationYear.GetHashCode() * 21;
            hash += numberOfPages.GetHashCode() * 22;

            return hash;
        }

        /// <summary>
        /// Returns a string representation of instance
        /// </summary>
        /// <returns>A string that represents instance</returns>
        public override string ToString()
        {
            return $"Book: ISBN {isbn}, author: {author}, title: {title}, publisher: {publisher}, " +
                $"year of publication: {publicationYear}, amount of pages: {numberOfPages}";
        }

        /// <summary>
        /// Compares this book to the specified book by titles
        /// </summary>
        /// <param name="other">Specified book to compare</param>
        /// <returns>1 if this book title comes before other book title alphabetically.
        /// 0 if the books titles are equal. -1 if this book title comes after other
        /// book title alphabetically.</returns>
        /// <exception cref="ArgumentNullException">Thrown when book to compare is not initialized.</exception>
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("The book is not initialized.");
            }

            return title.CompareTo(other.Title);
        }

        /// <summary>
        /// Compares this book to the specified book
        /// </summary>
        /// <param name="other">Specified book to compare</param>
        /// <returns>True if books are equal. False otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when book to compare is not initialized.</exception>
        public bool Equals(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Book is not initialized.");
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return (ISBN == other.ISBN) && (Author == other.Author) && (Title == other.Title) &&
                    (Publisher == other.Publisher) && (PublicationYear == other.PublicationYear) &&
                    (NumberOfPages == other.NumberOfPages);
        }
    }
}
