using System;
using System.Globalization;
using BookLibrary;
using NUnit.Framework;

namespace BookLibraryLib.Tests
{
    [TestFixture]
    class BookFormatExtensionTests
    {
        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900,
            ExpectedResult = "C# in Depth, Jon Skeet,")]
        [TestCase("568-1-8526-7515-7", "Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 5, 350,
            ExpectedResult = "Three Comrades, Erich Maria Remarque,")]
        [TestCase("963-0-7236-9635-6", "Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Itvdn", 2015, 20, 288,
            ExpectedResult = "Design Patterns via C#, А.Шевчук, Д.Охрименко, А.Касьянов,")]
        public string BookToString_TitleAuthor_Tests(string isbn, string title, string author, string publisher, int year,
              decimal price, int pages)
        {
            IBook b = new Book(isbn, title, author, publisher, year, price, pages);

            BookDecorator decorator = new BookFormatExtensionAuthor(new BookFormatExtensionTitle(b));

            return decorator.ToString();
        }

        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900,
            ExpectedResult = "C# in Depth, Jon Skeet, Manning,")]
        [TestCase("568-1-8526-7515-7", "Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 5, 350,
            ExpectedResult = "Three Comrades, Erich Maria Remarque, Hutchinson and Co,")]
        [TestCase("963-0-7236-9635-6", "Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Itvdn", 2015, 20, 288,
            ExpectedResult = "Design Patterns via C#, А.Шевчук, Д.Охрименко, А.Касьянов, Itvdn,")]
        public string BookToString_TitleAuthorPublisher(string isbn, string title, string author, string publisher, int year,
              decimal price, int pages)
        {
            IBook b = new Book(isbn, title, author, publisher, year, price, pages);

            BookDecorator decorator = new BookFormatExtensionPublishingHouse(
                new BookFormatExtensionAuthor(new BookFormatExtensionTitle(b)));

            return decorator.ToString();
        }

        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900, "technical",
            ExpectedResult = "C# in Depth, Jon Skeet, technical,")]
        [TestCase("568-1-8526-7515-7", "Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 5, 350, "fiction",
            ExpectedResult = "Three Comrades, Erich Maria Remarque, fiction,")]
        public string BookToString_TitleAuthorGenre(string isbn, string title, string author, string publisher, int year,
            decimal price, int pages, string genre)
        {
            IBook b = new Book(isbn, title, author, publisher, year, price, pages);

            BookDecorator decorator = new BookGenreDecorator(
                new BookFormatExtensionAuthor(new BookFormatExtensionTitle(b)), genre);

            return decorator.ToString();
        }

        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900,
            ExpectedResult = "ISBN 13: 978-0-7356-6745-7, C# in Depth, Jon Skeet,")]
        [TestCase("568-1-8526-7515-7", "Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 5, 350,
            ExpectedResult = "ISBN 13: 568-1-8526-7515-7, Three Comrades, Erich Maria Remarque,")]
        [TestCase("963-0-7236-9635-6", "Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Itvdn", 2015, 20, 288,
            ExpectedResult = "ISBN 13: 963-0-7236-9635-6, Design Patterns via C#, А.Шевчук, Д.Охрименко, А.Касьянов,")]
        public string BookToString_IsbnTitleAuthor_Tests(string isbn, string title, string author, string publisher, int year,
            decimal price, int pages)
        {
            IBook b = new Book(isbn, title, author, publisher, year, price, pages);

            BookDecorator titleAndAuthorDecorator = new BookFormatExtensionAuthor(new BookFormatExtensionTitle(b));
            BookDecorator isbnDecorator = new BookFormatExtensionIsbn(titleAndAuthorDecorator);

            return isbnDecorator.ToString();
        }

        [TestCase("978-0-7356-6745-7", "C# in Depth", "Jon Skeet", "Manning", 2019, 40, 900, "en-GB",
            ExpectedResult = "C# in Depth, £40.00,")]
        [TestCase("568-1-8526-7515-7", "Three Comrades", "Erich Maria Remarque", "Hutchinson and Co", 2008, 5, 350, "es-ES",
            ExpectedResult = "Three Comrades, 5,00 €,")]
        [TestCase("963-0-7236-9635-6", "Design Patterns via C#", "А.Шевчук, Д.Охрименко, А.Касьянов", "Itvdn", 2015, 20, 288, "ru-RU",
            ExpectedResult = "Design Patterns via C#, 20,00 ₽,")]
        public string BookToString_TitlePrice_Tests(string isbn, string title, string author, string publisher, int year,
            decimal price, int pages, string culture)
        {
            IBook b = new Book(isbn, title, author, publisher, year, price, pages);

            BookDecorator titleDecorator = new BookFormatExtensionTitle(b);


            CultureInfo uk = CultureInfo.GetCultureInfo(culture);

            BookDecorator priceDecorator = new BookFormatExtensionPrice(titleDecorator, uk);

            return priceDecorator.ToString();
        }
    }
}

