using System;

namespace Book
{
    class Program
    {
        private static AuthorWorker _authorWorker = new AuthorWorker();
        private static BookWorker _bookWorker = new BookWorker();
        static void Main(string[] args)
        {
            string pathAuthor = @"inputAuthor.txt";
            string pathBook = @"inputBook.txt";

            var author = CreateAuthor(pathAuthor);
            Console.WriteLine(author);

            Console.WriteLine();

            var book = CreateBook(pathBook);
            Console.WriteLine(book);
        }

        public static Author CreateAuthor(string path)
        {
            Author author = null;
            try
            {
                author = _authorWorker.GetAuthor(path);
            }
            catch(Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            return author;
        }
        public static Book CreateBook(string path)
        {
            Book book = null;
            try
            {
                book = _bookWorker.GetBook(path);
            }
            catch(Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            return book;
        }
    }
}
