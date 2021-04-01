using System;
using System.Collections.Generic;
using System.Text;

namespace Book
{
    class Author
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
            return string.Format("Name of author: \t{0}\nSecondname of author: \t{1}\nDate of birth: \t{2}", Name, Secondname, DateOfBirth);
        }
    }

}
