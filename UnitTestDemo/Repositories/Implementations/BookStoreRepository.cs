using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using UnitTestDemo.Models;
using UnitTestDemo.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace UnitTestDemo.Repositories.Implementations
{
    public class BookStoreRepository: IBookStoreRepository
    {
        private readonly BookStoreDb _bookStoreDb;
        public BookStoreRepository(BookStoreDb bookStoreDb) { _bookStoreDb = bookStoreDb ?? throw new ArgumentNullException(nameof(bookStoreDb)); }
        public async Task<T> FindGeneric<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _bookStoreDb.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public Book GetBookById(int id)
        {
            return _bookStoreDb.Set<Book>().FirstOrDefault(book => book.Id == id);
        }

        public List<Book> SearchBooksByPriceRange(decimal min, decimal max)
        {
            return _bookStoreDb.Set<Book>().Where(book => book.Price >= min && book.Price <= max).ToList();
        }

        public List<Book> SearchBooksByAuthorId(int authorId)
        {
            return _bookStoreDb.Set<Book>().Where(book => book.Author.Id == authorId).ToList();
        }

        public List<Book> GetAllBooks()
        {
            return _bookStoreDb.Set<Book>().ToList();
        }

        public Book AddNewBook(Book book)
        {
            _bookStoreDb.Add(book);
            _bookStoreDb.SaveChanges();
            return book;
        }
    }
}
