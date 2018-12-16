namespace BookServiceLib
{
    /// <summary>
    /// Provides methods for working with book instance
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Gets book ISBN
        /// </summary>
        string Isbn { get; }

        /// <summary>
        /// Gets book title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets book author
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Gets book publishing house
        /// </summary>
        string PublishingHouse { get; }

        /// <summary>
        /// Gets price
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Gets year of publishing
        /// </summary>
        int Year { get; }

        /// <summary>
        /// Gets amount of pages
        /// </summary>
        int Pages { get; }

        /// <summary>
        /// Returns a string representation of book instance
        /// </summary>
        string ToString();
    }
}
