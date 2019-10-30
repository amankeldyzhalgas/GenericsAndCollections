using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeLibrary.Tests.TestClasses
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, int year, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Price = price;
        }

        public int CompareTo(Book book)
        {
            if (this.Price.Equals(book.Price))
            {
                return 0;
            }

            if(this.Price < book.Price)
            {
                return -1;
            }

            return 1;
        }
    }
}
