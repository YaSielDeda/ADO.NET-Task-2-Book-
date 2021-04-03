using System;
using System.Collections.Generic;
using System.Text;

namespace Book
{
    public class AuthorFileModel
    {
        public AuthorFileModel(string name, string secondname, string dateOfBirth)
        {
            Name = name;
            Secondname = secondname;
            DateOfBirth = dateOfBirth;
        }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public string DateOfBirth { get; set; }
    }
}
