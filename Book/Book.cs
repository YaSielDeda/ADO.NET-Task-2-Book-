using System;
using System.Collections.Generic;
using System.Text;

namespace Book
{
    class Book
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public DateTime DateOfPublishing { get; set; }
        public DateTime DateOfWriting { get; set; }
        public Book() { }

        public Book(string name, int pages, string publisher, DateTime dateOfPublishing, DateTime dateOfWriting)
        {
            Name = name;
            Pages = pages;
            Publisher = publisher;
            DateOfPublishing = dateOfPublishing;
            DateOfWriting = dateOfWriting;
        }
        public override string ToString()
        {
            return string.Format("Name of book: \t{0}\nNumber of pages: \t{1}\nPublisher: \t{2}\nDate of publishing: \t{3}\nDate of writing: \t{4}", Name, Pages, Publisher, DateOfPublishing, DateOfWriting);
        }
    }
}
