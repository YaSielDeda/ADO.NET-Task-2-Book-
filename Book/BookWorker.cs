using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using static Book.Exceptions;

namespace Book
{
    class BookWorker
    {
        public Book GetBook(string path)
        {
            var bookFileModel = GetBookFromFile(path);
            if (AuthorValidation(bookFileModel.Author.Name, bookFileModel.Author.Secondname))
                return new Book(
                    bookFileModel.Name,
                    int.Parse(bookFileModel.Pages),
                    bookFileModel.Publisher,
                    DateTime.ParseExact(bookFileModel.DateOfPublishing, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(bookFileModel.DateOfWriting, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        new Author(
                            bookFileModel.Author.Name,
                            bookFileModel.Author.Secondname,
                            DateTime.ParseExact(bookFileModel.Author.DateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                            )
                    );
            else
                throw new Exception("Author error!");
        }
        public BookFileModel GetBookFromFile(string path)
        {
            string jsonString = null;
            using (StreamReader fs = new StreamReader(path))
            {
                jsonString = fs.ReadLine();
            }
            BookFileModel book = null;            
            try
            {
                book = JsonSerializer.Deserialize<BookFileModel>(jsonString);
            }
            catch
            {
                throw new FileNotFoundException("JSON file is missing!");
            }
            return book;
        }
        private bool AuthorValidation(string name, string secondname)
        {
            char[] ViolatedSymbols = new char[] {
                '.', ',', '!', '@', '#', '№', '$', ';', '%', '^',
                ':', '&', '?', '*', '(', ')', '-', '_', '=', '+',
                '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            foreach (var s in ViolatedSymbols)
            {
                if (name.Contains(s) || secondname.Contains(s))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
