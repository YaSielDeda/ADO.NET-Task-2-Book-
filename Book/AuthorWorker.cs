using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using static Book.Exceptions;

namespace Book 
{   
    public class AuthorWorker
    {
        public Author GetAuthor(string path)
        {
            var authorFileModel = GetAuthorFromFile(path);
            if (AuthorValidation(authorFileModel.Name, authorFileModel.Secondname))
                return new Author(authorFileModel.Name, authorFileModel.Secondname, DateTime.ParseExact(authorFileModel.DateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture));
            else
                throw new Exception("Author error!");
        }
        public AuthorFileModel GetAuthorFromFile(string path)
        {
            string jsonString = null;
            using (StreamReader fs = new StreamReader(path))
            {
                jsonString = fs.ReadLine();
            }
            AuthorFileModel author = null;
            try
            {
                author = JsonSerializer.Deserialize<AuthorFileModel>(jsonString);
            }
            catch
            {
                throw new FileNotFoundException("JSON file is missing!");
            }
            return author;
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
