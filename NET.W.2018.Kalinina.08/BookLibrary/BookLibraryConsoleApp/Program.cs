using BookLibraryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListStorage storage = new BookListStorage("file.bin");
            BookListService service = new BookListService();

            service.AddBook(new Book("78565121ad45q", "Author 1", "First book", "Publisher 1", 1990, 200));
            service.AddBook(new Book("845dbn454545c", "Author 2", "Second Book", "Publisher 2", 1996, 5));
            service.AddBook(new Book("7854dshj98985", "Author 3", "New book", "Publisher 3", 2000, 45));

            ListInput(service.BookList);

            service.WriteBooks(storage, service.BookList);

            service.AddBook(new Book("84564dhbhb545", "Author 4", "Last book", "Publisher 1", 1995, 60));
            ListInput(service.BookList);

            service.SortBooksByTag(new SortByTitleAsc());
            ListInput(service.BookList);

            Book findedBook = service.FindBookByTag(new FindBookByTitle("Second Book"));
            Console.WriteLine(findedBook);
            Console.WriteLine();

            service.ReadBooks(storage);
            ListInput(service.BookList);

            Console.ReadLine();
        }

        private static void ListInput(List<Book> list)
        {
            foreach (var b in list)
            {
                Console.WriteLine(b);
            }

            Console.WriteLine();
        }
    }

    public class SortByTitleAsc : BookLibraryLib.IComparer<Book>
    {
        public int Compare(Book firstElemet, Book secondElement)
        {
            return string.Compare(firstElemet.Title, secondElement.Title);
        }
    }

    public class FindBookByTitle : IPredicate<Book>
    {
        private string title;

        public FindBookByTitle(string title)
        {
            this.title = title;
        }

        public bool FindByTag(Book tagPredicate)
        {
            return tagPredicate.Title == this.title;
        }
    }
}
