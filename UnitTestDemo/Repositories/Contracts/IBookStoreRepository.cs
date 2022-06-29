using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitTestDemo.Models;

namespace UnitTestDemo.Repositories.Contracts
{
    public interface IBookStoreRepository
    {
        Task<T> FindGeneric<T>(Expression<Func<T, bool>> predicate) where T : class;
        Book GetBookById(int id);
        List<Book> SearchBooksByPriceRange(decimal min, decimal max);
        List<Book> SearchBooksByAuthorId(int authorId);
        List<Book> GetAllBooks();
        Book AddNewBook(Book book);
    }
}
