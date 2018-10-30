using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookLibraryTest
    {
        [TestCase("C# in Depth", "Jon Skeet", "Manning", 2019, 4, 40, 900)]
        [TestCase("Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 1, 5, 350)]
        [TestCase("Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Manning", 2015, 1, 20, 288)]
        [TestCase("War and Peace", "Leo Tolstoy", "AST", 2009, 1, 10, 1225)]
        [TestCase("Системное программирование в среде Windows", "Джонсон М.Харт", "Вильямс", 2005, 3, 30, 586)]
        public void BookLibrary_CreateBook_PositiveTest(string title, string author, string publisher, 
            int year, int edition, decimal price, int pages)
        {
            Book book = new Book(title, author, publisher, year, edition, price, pages);

            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(publisher, book.PublishingHouse);
            Assert.AreEqual(year, book.Year);
            Assert.AreEqual(price, book.Price);
            Assert.AreEqual(edition, book.Edition);
            Assert.AreEqual(pages, book.Pages);
        }

        [TestCase("C# in Depth", "Jon Skeet", "Manning", -105, 4, 40, 900)]
        [TestCase("C# in Depth", "Jon Skeet", "Manning", 2019, -6, 40, 900)]
        [TestCase("C# in Depth", "Jon Skeet", "Manning", 2019, 3, -2.3, 900)]
        [TestCase("C# in Depth", "Jon Skeet", "Manning", 2019, 3, 40, -800)]
        public void BookLibrary_CreateBook_ArgumentOutOfRangeExceptiont(string title, string author, string publisher,
            int year, int edition, decimal price, int pages)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Book(title, author, publisher, year, edition, price, pages));
        }

        [TestCase("", "Jon Skeet", "Manning", 2019, 4, 40, 900)]
        [TestCase("C# in Depth", "", "Manning", 2019, 4, 40, 900)]
        [TestCase("C# in Depth", "Jon Skeet", "", 2019, 3, 40, 900)]
        public void BookLibrary_CreateBook_ArgumentNullException(string title, string author, string publisher,
    int year, int edition, decimal price, int pages)
        {
            Assert.Throws<ArgumentNullException>(() => new Book(title, author, publisher, year, edition, price, pages));
        }
    }
}
