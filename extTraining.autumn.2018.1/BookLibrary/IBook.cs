using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IBook
    {
        string Title { get; }

        string Author { get; }

        string PublishingHouse { get; }

        decimal Price { get; }

        int Edition { get; }

        int Year { get; }

        int Pages { get;}

        string ToString();
    }
}
