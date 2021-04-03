using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using static Book.Exceptions;

namespace Book 
{
    public class AuthorWorker
    {
        public Author GetAuthor(string path)
        {
            var authorFromFile = GetAuthorFromFile(path);
            var result = ParseAuthor(authorFromFile);
            return result;
        }

        private AuthorFileModel GetAuthorFromFile(string path)
        {
            var lines = File.ReadLines(path).ToArray();
            if (lines.Length != 3)
            {
                throw new InvalidAuthorException("Lack of data! Some data may absent or written in one line");
            }
            var result =  new AuthorFileModel(lines[0], lines[1], lines[2]);

            return result;
        }

        private Author ParseAuthor(AuthorFileModel authorFromFile)
        {
            DateTime dateTime = new DateTime();
            if (int.TryParse(authorFromFile.Name, out var _)
                || int.TryParse(authorFromFile.Secondname, out var _))
            {
                throw new FormatException("Name/Secondname can't be a number!");
            }
            try
            {
                dateTime = DateTime.ParseExact(authorFromFile.DateOfBirth.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            catch(FormatException)
            {
                throw new FormatException("Invalid date time");
            }
            return new Author(authorFromFile.Name, authorFromFile.Secondname, dateTime);
        }
    }

}
