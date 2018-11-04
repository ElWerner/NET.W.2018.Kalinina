using System;
using BookLibrary;
using NUnit.Framework;

namespace BookLibraryLib.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900)]
        [TestCase("568-1-8526-7515-7", "Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 5, 350)]
        [TestCase("963-0-7236-9635-6", "Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Manning", 2015, 20, 288)]
        [TestCase("126-2-7854-4520-4", "War and Peace", "Leo Tolstoy", "AST", 2009, 10, 1225)]
        [TestCase("785-0-4203-3655-1", "Системное программирование в среде Windows", "Джонсон М.Харт", "Вильямс", 2005, 30, 586)]
        public void BookLibrary_CreateBook_PositiveTest(string isbn, string title, string author, string publisher,
            int year, decimal price, int pages)
        {
            Book book = new Book(isbn, title, author, publisher, year, price, pages);

            Assert.AreEqual(isbn, book.Isbn);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(publisher, book.PublishingHouse);
            Assert.AreEqual(year, book.Year);
            Assert.AreEqual(price, book.Price);
            Assert.AreEqual(pages, book.Pages);
        }

        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", -105, 40, 900)]
        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, -2.3, 900)]
        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, -800)]
        public void BookLibrary_CreateBook_ArgumentOutOfRangeExceptiont(string isbn, string title, string author,
            string publisher, int year, decimal price, int pages)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Book(isbn, title, author, publisher, year, price, pages));
        }

        [TestCase("978-0-7356-6745-7", "", "Jon Skeet", "Manning", 2019, 40, 900)]
        [TestCase("978-0-7356-6745-7", "C# in Depth", "", "Manning", 2019, 40, 900)]
        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "", 2019, 40, 900)]
        public void BookLibrary_CreateBook_ArgumentNullException(string isbn, string title, string author, string publisher,
            int year, decimal price, int pages)
        {
            Assert.Throws<ArgumentNullException>(() => new Book(isbn, title, author, publisher, year, price, pages));
        }

        [TestCase("978-0-7356", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900)]
        [TestCase("978", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900)]
        [TestCase("ewgegreg", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900)]
        [TestCase("97-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900)]
        [TestCase("9787356-674567", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900)]
        public void BookLibrary_CreateBook_ArgumentException(string isbn, string title, string author, string publisher,
            int year, decimal price, int pages)
        {
            Assert.Throws<ArgumentException>(() => new Book(isbn, title, author, publisher, year, price, pages));
        }
    }
}
