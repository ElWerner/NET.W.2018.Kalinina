using NLog;

namespace BookServiceLib
{
    /// <summary>
    /// Represents a class that holds instance of the logger
    /// </summary>
    public static class BookServiceLogger
    {
        /// <summary>
        /// A field that holds instance of the logger
        /// </summary>
        public static Logger Log = LogManager.GetCurrentClassLogger();
    }
}
