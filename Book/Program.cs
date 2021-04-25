using System;
using System.IO;
using System.Text.Json;

namespace Book
{
    class Program
    {
        private static AuthorWorker _authorWorker = new AuthorWorker();
        private static BookWorker _bookWorker = new BookWorker();
        static void Main(string[] args)
        {
            string pathAuthor = "author.json";
            string pathBook = "book.json";

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
        public static async void SerializeBook()
        {
            using (FileStream fs = new FileStream("book.json", FileMode.Create))
            {
                BookFileModel book1 = new BookFileModel(
                    "Crime and punishment",
                    "321",
                    "Exmo",
                    "2015-02-14",
                    "1866-01-23",
                        new AuthorFileModel(
                            "Fedor",
                            "Dostoevskiy",
                            "1821-11-11"
                            )
                    );
                await JsonSerializer.SerializeAsync(fs, book1);
            }
        }
        public static async void SerializeAuthor()
        {
            using (FileStream fs = new FileStream("author.json", FileMode.Create))
            {
                AuthorFileModel author = new AuthorFileModel("Alexander", "Pushkin", "1799-01-26");
                await JsonSerializer.SerializeAsync(fs, author);
            }
        }
    }
}
