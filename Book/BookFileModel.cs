using System;
using System.Collections.Generic;
using System.Text;

namespace Book
{
    class BookFileModel
    {
        public string Name { get; set; }
        public string Pages { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublishing { get; set; }
        public string DateOfWriting { get; set; }
        public AuthorFileModel Author { get; set; }
        public BookFileModel() { }

        public BookFileModel(string name, string pages, string publisher, string dateOfPublishing, string dateOfWriting, AuthorFileModel author)
        {
            Name = name;
            Pages = pages;
            Publisher = publisher;
            DateOfPublishing = dateOfPublishing;
            DateOfWriting = dateOfWriting;
            Author = author;
        }
    }
}
