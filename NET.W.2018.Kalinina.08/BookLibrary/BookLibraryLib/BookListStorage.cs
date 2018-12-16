using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryLib
{
    /// <summary>
    /// Represents a class providing basic input and output files operations with book list
    /// </summary>
    public class BookListStorage : IStorage<Book>
    {
        #region Fields
        /// <summary>
        /// Field to hold path to the file
        /// </summary>
        private string filePath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListStorage"/> class with specified 
        /// path to the file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <exception cref="ArgumentNullException">Thrown when file path 
        /// string is null or empty</exception>
        public BookListStorage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("File path is not initializes.");
            }

            this.filePath = filePath;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Reads books from file into list of books
        /// </summary>
        /// <returns>List of books</returns>
        /// <exception cref="ArgumentNullException">Thrown when file path is not initialized
        /// or this file is not exists</exception>
        public List<Book> ReadFromFile()
        {
            if (string.IsNullOrEmpty(this.filePath))
            {
                throw new ArgumentNullException("File path is not initialized.");
            }

            if (!File.Exists(this.filePath))
            {
                throw new ArgumentNullException("File is not exists.");
            }

            return this.ReadBooks();
        }

        /// <summary>
        /// Writes books from list into the file
        /// </summary>
        /// <param name="books">List of books</param>
        /// <exception cref="ArgumentNullException">Thrown when file path or list of books
        /// is not initialized</exception>
        public void WriteToFile(List<Book> books)
        {
            if (string.IsNullOrEmpty(this.filePath))
            {
                throw new ArgumentNullException("File path is not initialized.");
            }

            if (books == null || books.Count == 0)
            {
                throw new ArgumentNullException("List of books is not initialized");
            }

            this.WriteBooks(books);
        }

        #endregion

        #region Private API

        /// <summary>
        /// Reads books from file into list of books
        /// </summary>
        /// <returns>List of books</returns>
        /// <exception cref="IOException">Thrown when files reading error occurred</exception>
        private List<Book> ReadBooks()
        {
            List<Book> books = new List<Book>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(this.filePath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string isbn = reader.ReadString();
                        string author = reader.ReadString();
                        string title = reader.ReadString();
                        string publisher = reader.ReadString();
                        int year = reader.ReadInt32();
                        int pages = reader.ReadInt32();

                        Book book = new Book(isbn, author, title, publisher, year, pages);
                        books.Add(book);
                    }

                    return books;
                }
            }
            catch
            {
                throw new IOException("Unable to read from the file");
            }
        }

        /// <summary>
        /// Writes books from list into the file
        /// </summary>
        /// <param name="books">List of books</param>
        /// <exception cref="IOException">Thrown when files writing error occurred</exception>
        private void WriteBooks(List<Book> books)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(this.filePath, FileMode.OpenOrCreate)))
                {
                    foreach (Book book in books)
                    {
                        writer.Write(book.ISBN);
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Publisher);
                        writer.Write(book.PublicationYear);
                        writer.Write(book.NumberOfPages);
                    }
                }
            }
            catch
            {
                throw new IOException("Unable to write into the file");
            }
        }

        #endregion
    }
}
