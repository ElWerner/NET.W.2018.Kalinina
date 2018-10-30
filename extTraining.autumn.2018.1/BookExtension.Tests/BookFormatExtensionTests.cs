using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using BookExtension;
using NUnit.Framework;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        [TestCase("C# in Depth", "Jon Skeet", "Manning", 2019, 4, 40, 900,
            ExpectedResult = "Book record: C# in Depth, Jon Skeet,")]
        [TestCase("Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 1, 5, 350,
            ExpectedResult = "Book record: Three Comrades, Erich Maria Remarque,")]
        [TestCase("Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Itvdn", 2015, 1, 20, 288,
            ExpectedResult = "Book record: Design Patterns via C#, А.Шевчук, Д.Охрименко, А.Касьянов,")]
        public string BookToString_TitleAuthor_Tests(string title, string author, string publisher, int year,
                      decimal price, int edition, int pages)
        {
            IBook b = new Book(title, author, publisher, year, edition, price, pages);

            BookDecorator decorator = new BookFormatExtensionAuthor(new BookFormatExtensionTitle(b));

            return decorator.ToString();
        }

        [TestCase("C# in Depth", "Jon Skeet", "Manning", 2019, 4, 40, 900,
            ExpectedResult = "Book record: C# in Depth, Jon Skeet, Manning,")]
        [TestCase("Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 1, 5, 350,
            ExpectedResult = "Book record: Three Comrades, Erich Maria Remarque, Hutchinson and Co,")]
        [TestCase("Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Itvdn", 2015, 1, 20, 288,
            ExpectedResult = "Book record: Design Patterns via C#, А.Шевчук, Д.Охрименко, А.Касьянов, Itvdn,")]
        public string BookToString_TitleAuthorPublisher(string title, string author, string publisher, int year,
              decimal price, int edition, int pages)
        {
            IBook b = new Book(title, author, publisher, year, edition, price, pages);

            BookDecorator decorator = new BookFormatExtensionPublishingHouse(
                new BookFormatExtensionAuthor(new BookFormatExtensionTitle(b)));

            return decorator.ToString();
        }

        [TestCase("C# in Depth", "Jon Skeet", "Manning", 2019, 4, 40, 900, "technical",
            ExpectedResult = "Book record: C# in Depth, Jon Skeet, technical,")]
        [TestCase("Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 1, 5, 350, "fiction",
            ExpectedResult = "Book record: Three Comrades, Erich Maria Remarque, fiction,")]
        public string BookToString_TitleAuthorGenre(string title, string author, string publisher, int year,
            decimal price, int edition, int pages, string genre)
        {
            IBook b = new Book(title, author, publisher, year, edition, price, pages);

            BookDecorator decorator = new BookGenreDecorator(
                new BookFormatExtensionAuthor(new BookFormatExtensionTitle(b)), genre);

            return decorator.ToString();
        }
    }
}
