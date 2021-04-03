using System;
using System.Collections.Generic;
using System.Text;

namespace Book
{
    public class Author
    {
        public string Name { get; set; }
        public string Secondname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Author() { }
        public Author(string name, string secondname, DateTime dateOfBirth)
        {
            Name = name;
            Secondname = secondname;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"Name of author: \t{Name}" +
                $"{Environment.NewLine}Secondname of author: \t{Secondname}" +
                $"{Environment.NewLine}Date of birth:         \t{DateOfBirth.ToLongDateString()}";
        }
    }
}
