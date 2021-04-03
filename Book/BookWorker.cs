using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static Book.Exceptions;

namespace Book
{
    class BookWorker
    {
        public Book GetBook(string path)
        {
            var bookFromFile = GetBookFromFile(path);
            var result = ParseBook(bookFromFile);
            return result;
        }

        private string[] GetBookFromFile(string path)
        {
            var lines = File.ReadLines(path).ToArray();
            if (lines.Length < 3)
            {
                throw new InvalidBookException("Lack of data! Some data may absent or written in one line");
            }
            return lines;
        }

        private Book ParseBook(string[] bookFromFile)
        {
            DateTime DateOfPublishing = new DateTime();
            DateTime DateOfWriting = new DateTime();
            try
            {
                int.Parse(bookFromFile[1]);
                DateOfPublishing = DateTime.ParseExact(bookFromFile[3].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateOfWriting = DateTime.ParseExact(bookFromFile[4].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid data!");
            }
            return new Book(bookFromFile[0], int.Parse(bookFromFile[1]), bookFromFile[2], DateOfPublishing, DateOfWriting);
        }
    }
}
