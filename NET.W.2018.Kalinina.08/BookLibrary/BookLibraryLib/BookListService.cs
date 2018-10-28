using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryLib
{
    /// <summary>
    /// Represents a class providing basic operations with book list
    /// </summary>
    public class BookListService : IEnumerable<Book>
    {
        /// <summary>
        /// List that holds books
        /// </summary>
        private List<Book> bookList = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/>
        /// </summary>
        public BookListService()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> with specified list of books
        /// </summary>
        /// <param name="bookList">List of books</param>
        /// <exception cref="ArgumentNullException">Thrown when book list is not initialized</exception>
        public BookListService(List<Book> bookList)
        {
            this.bookList = bookList ??
                throw new ArgumentNullException("List of books is not initialized.");
        }

        /// <summary>
        /// Gets list of books
        /// </summary>
        public List<Book> BookList => this.bookList.ToList<Book>();

        /// <summary>
        /// Adds new book to the book list
        /// </summary>
        /// <param name="book">Added book</param>
        /// <exception cref="Exception">Thrown when added book is already in the book list</exception>
        public void AddBook(Book book)
        {
            if (!this.CheckISBN(book.ISBN))
            {
                this.bookList.Add(book);
            }
            else
            {
                throw new Exception("Book is already in the storage.");
            }
        }

        /// <summary>
        /// Removes book from the book list
        /// </summary>
        /// <param name="book">Removed book</param>
        /// <exception cref="Exception">Thrown when removed book is not in the book list</exception>
        public void RemoveBook(Book book)
        {
            if (this.bookList.Contains(book))
            {
                this.bookList.Remove(book);
            }
            else
            {
                throw new Exception("Book is not in the storage.");
            }
        }

        /// <summary>
        /// Writes books list to the storage
        /// </summary>
        /// <param name="storage">Storage to hold list of books</param>
        /// <param name="books">List of books</param>
        /// <exception cref="ArgumentNullException">Thrown when storage or
        /// list of books is not initialized</exception>
        public void WriteBooks(IStorage<Book> storage, List<Book> books)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("Storage is not initialized");
            }

            if (books == null || books.Count<Book>() == 0)
            {
                throw new ArgumentNullException("Book list is not initialized");
            }

            storage.WriteToFile(books);
        }

        /// <summary>
        /// Reads list of books from the storage
        /// </summary>
        /// <param name="storage">Storage that holds list of books</param>
        /// <exception cref="ArgumentNullException">Thrown when storage is not initialized</exception>
        /// <returns>List of books</returns>
        public List<Book> ReadBooks(IStorage<Book> storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException();
            }

            this.bookList = storage.ReadFromFile();

            return this.bookList.ToList<Book>();
        }

        /// <summary>
        /// Finds book in list of books by specified tag
        /// </summary>
        /// <param name="tagPredicate">Specified tag</param>
        /// <returns>Found book</returns>
        /// <exception cref="ArgumentNullException">Thrown when tag predicate or
        /// list of books is not initialized</exception>
        /// <exception cref="Exception">Thrown when book was not found</exception>
        public Book FindBookByTag(IPredicate<Book> tagPredicate)
        {
            if (this.bookList == null || this.bookList.Count == 0)
            {
                throw new ArgumentNullException("List of books is not initialized");
            }

            if (tagPredicate == null)
            {
                throw new ArgumentNullException("Tag predicate is not intialized");
            }

            foreach (var book in this.bookList)
            {
                if (tagPredicate.FindByTag(book))
                {
                    return book;
                }
            }

            throw new Exception("Books was not found.");
        }

        /// <summary>
        /// Sorts list of books by specified tag
        /// </summary>
        /// <param name="tagComparer">Specified tag</param>
        /// <exception cref="ArgumentNullException">Thrown when tag comparer or
        /// list of books is not initialized</exception>
        public void SortBooksByTag(IComparer<Book> tagComparer)
        {
            if (this.bookList == null || this.bookList.Count == 0)
            {
                throw new ArgumentNullException("List of books is not initialized");
            }

            if (tagComparer == null)
            {
                throw new ArgumentNullException("Tag comparer is not intialized");
            }

            for (int i = 0; i < this.bookList.Count; i++)
            {
                for (int j = 0; j < this.bookList.Count - i - 1; j++)
                {
                    if (tagComparer.Compare(this.bookList[j], this.bookList[j + 1]) > 0)
                    {
                        this.Swap(j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Returns IEnumerator object for list of books
        /// </summary>
        /// <returns>IEnumerator object for list of books</returns>
        public IEnumerator<Book> GetEnumerator()
        {
            return ((IEnumerable<Book>)bookList).GetEnumerator();
        }

        /// <summary>
        /// Returns IEnumerator object for list of books
        /// </summary>
        /// <returns>IEnumerator object for list of books</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Book>)bookList).GetEnumerator();
        }

        /// <summary>
        /// Swaps two books by references
        /// </summary>
        /// <param name="firstBookIndex">Index of the first book</param>
        /// <param name="secondBookIndex">Index of the second book</param>
        private void Swap(int firstBookIndex, int secondBookIndex)
        {
            Book tmp = bookList[firstBookIndex];
            bookList[firstBookIndex] = bookList[secondBookIndex];
            bookList[secondBookIndex] = tmp;
        }

        /// <summary>
        /// Checks if list of books contains book with specified ISBN
        /// </summary>
        /// <param name="checkedISBN">Specified ISBN</param>
        /// <returns>True if list of books contains book with specified ISBN.
        /// False otherwise</returns>
        private bool CheckISBN(string checkedISBN)
        {
            foreach (var book in bookList)
            {
                if (book.ISBN == checkedISBN)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
