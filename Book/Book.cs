using System;

namespace Book
{
     public class Book
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public DateTime DateOfPublishing { get; set; }
        public DateTime DateOfWriting { get; set; }
        public Author Author { get; set; }
        public Book() { }

        public Book(string name, int pages, string publisher, DateTime dateOfPublishing, DateTime dateOfWriting)
        {
            Name = name;
            Pages = pages;
            Publisher = publisher;
            DateOfPublishing = dateOfPublishing;
            DateOfWriting = dateOfWriting;
        }

        public Book(string name, int pages, string publisher, DateTime dateOfPublishing, DateTime dateOfWriting, Author author) 
            : this(name, pages, publisher, dateOfPublishing, dateOfWriting)
        {
            Author = author;
        }
        public override string ToString()
        {
            if (Author.Name != null && Author.Secondname != null && Author.DateOfBirth != null)
                return $"Name of book:          \t{Name}" +
                    $"{Environment.NewLine}Number of pages: \t{Pages}" +
                    $"{Environment.NewLine}Publisher:       \t{Publisher}" +
                    $"{Environment.NewLine}Date of publishing: \t{DateOfPublishing.ToLongDateString()}" +
                    $"{Environment.NewLine}Date of writing: \t{DateOfWriting.ToLongDateString()}" +
                    $"{Environment.NewLine}AUTHOR:" +
                    $"{Environment.NewLine}\tName of author: \t{Author.Name}" +
                    $"{Environment.NewLine}\tSecondname of author: \t{Author.Secondname}" +
                    $"{Environment.NewLine}\tDate of birth:         \t{Author.DateOfBirth.ToLongDateString()}";
            else
                return $"Name of book:          \t{Name}" +
                $"{Environment.NewLine}Number of pages: \t{Pages}" +
                $"{Environment.NewLine}Publisher:       \t{Publisher}" +
                $"{Environment.NewLine}Date of publishing: \t{DateOfPublishing.ToLongDateString()}" +
                $"{Environment.NewLine}Date of writing: \t{DateOfWriting.ToLongDateString()}";
        }
    }
}