using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using UnitTestDemo.Models;
using UnitTestDemo.Repositories.Contracts;

namespace UnitTestDemo.Repositories.Implementations
{
    public class BookStoreMockRepository : IBookStoreRepository
    {
        private List<Book> _books;
        public BookStoreMockRepository()
        {
            Initialize();
        }

        public Task<T> FindGeneric<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public List<Book> SearchBooksByPriceRange(decimal min, decimal max)
        {
            return _books.Where(book => book.Price >= min && book.Price <= max).ToList();
        }

        public List<Book> SearchBooksByAuthorId(int authorId)
        {
            return _books.Where(book => book.Author.Id == authorId).ToList();
        }

        public List<Book> GetAllBooks()
        {
            return _books.ToList();
        }

        public Book AddNewBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        private void Initialize()
        {
            _books = new List<Book>(){
                new Book(){ Id = 1, Title = "Harry Potter", Price = 200, Author = new Author(){ Id = 1, Name = "J. K. Rowling" } },
                new Book(){ Id = 2, Title = "The Great Gatsby", Price = 100, Author = new Author(){ Id = 2, Name = "F. Scott Fitzgerald" } },
                new Book(){ Id = 3, Title = "The Silk Roads", Price = 50, Author = new Author(){ Id = 3, Name = "Peter Frankopan" } },
                new Book(){ Id = 4, Title = "Grant", Price = 120, Author = new Author(){ Id = 4, Name = "Ron Chernow" } },
                new Book(){ Id = 5, Title = "Steve Jobs", Price = 190, Author = new Author(){ Id = 5, Name = "Walter Isaacson" } }
            };
        }
    }
}
