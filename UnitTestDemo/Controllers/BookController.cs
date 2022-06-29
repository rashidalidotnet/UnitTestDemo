using Microsoft.AspNetCore.Mvc;
using System;
using UnitTestDemo.Models;
using UnitTestDemo.Repositories.Contracts;

namespace UnitTestDemo.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStoreRepository _bookStoreRepository;
        public BookController(IBookStoreRepository bookStoreRepository)
        {
            _bookStoreRepository = bookStoreRepository ?? throw new ArgumentNullException(nameof(bookStoreRepository));
        }

        public IActionResult GetBookById(int id)
        {
            var result = _bookStoreRepository.GetBookById(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        public IActionResult SearchBooksByPriceRange(decimal min, decimal max)
        {
            var result = _bookStoreRepository.SearchBooksByPriceRange(min, max);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        public IActionResult SearchBooksByAuthorId(int authorId)
        {
            var result = _bookStoreRepository.SearchBooksByAuthorId(authorId);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        public IActionResult GetAllBooks()
        {
            var result = _bookStoreRepository.GetAllBooks();

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        public IActionResult AddNewBook(Book book)
        {
            var result = _bookStoreRepository.AddNewBook(book);
            return Ok(result);
        }
    }
}
