using System;
using System.Globalization;
using static Book.Exceptions;

namespace Book
{
    class Program
    {
        static FileWorker fileWorker = new FileWorker();
        public static Author createAuthor(string path)
        {
            Author author;            
            try
            {
                string[] temp = fileWorker.Load(path);
                author = new Author(temp[0], temp[1], DateTime.ParseExact(temp[2], "d.m.yyyy", CultureInfo.InvariantCulture));
            }
            catch(LackOfData)
            {
                author = new Author();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Lack of data! Some data may absent or written in one line");
                Console.ResetColor();
            }
            catch (FormatException)
            {
                author = new Author();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Format exception! It's seems that you write data incorrectly, check the format and try again");
                Console.ResetColor();
            }
            return author;
        }
        public static Book createBook(string path)
        {
            Book book;
            try
            {
                string[] temp = fileWorker.Load(path);
                string correct = temp[3].Trim();
                book = new Book(
                    temp[0],
                    int.Parse(temp[1]),
                    temp[2],
                    DateTime.ParseExact(correct, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(temp[4], "dd.MM.yyyy", CultureInfo.InvariantCulture));
            }
            catch(FormatException)
            {
                book = new Book();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Format exception! It's seems that you write data incorrectly, check the format and try again");
                Console.ResetColor();
            }
            catch(IndexOutOfRangeException)
            {
                book = new Book();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered icorrect data, it is possible that you have written unnecessary information");
                Console.ResetColor();
            }
            catch (LackOfData)
            {
                book = new Book();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Lack of data! Some data may absent or written in one line");
                Console.ResetColor();
            }
            return book;
        }
        static void Main(string[] args)
        {
            string pathAuthor = @"inputAuthor.txt";
            string pathBook = @"inputBook.txt";

            Author author = createAuthor(pathAuthor);
            Console.WriteLine(author.ToString());

            Console.WriteLine();

            Book book = createBook(pathBook);
            Console.WriteLine(book.ToString());
        }
    }
}
