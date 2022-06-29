using System;

namespace UnitTestDemo.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Author Author { get; set; }
    }
}
