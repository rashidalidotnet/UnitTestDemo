using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestDemo.Controllers;
using FluentAssertions;
using UnitTestDemo.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using UnitTestDemo.Models;

namespace Tests.UnitTests
{
    [TestClass]
    public class BookControllerTests
    {
        [TestMethod]
        [TestCategory("unit")]
        public void BookControllerConstructor_ShouldThrowExceptionOnNullRepositoryDependency()
        {
            //Arrange
            var bookControllerConstruct = new Action(() =>
            {
                using (var bookController = new BookController(null)) { }
            });

            //Act and Assert
            bookControllerConstruct.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [TestCategory("unit")]
        public void BookControllerConstructor_ShouldConstructOnRepositoryDependencyInjected()
        {
            //Arrange
            var bookControllerConstruct = new Action(() =>
            {
                using (var bookController = new BookController(new BookStoreMockRepository())) { }
            });

            //Act
            bookControllerConstruct.Invoke();

            //Assert
            bookControllerConstruct.Should().NotThrow<ArgumentNullException>();
        }

        [TestMethod]
        [TestCategory("unit")]
        public void BookControllerGetBookById_ShouldReturnNullWhenGivenInvalidId()
        {
            //Arrange
            var bookController = new BookController(new BookStoreMockRepository());

            int bookId = -1;

            //Act
            var action = bookController.GetBookById(bookId);

            //Assert
            var result = action as NotFoundResult;
            result.StatusCode.Should().Be(404);
        }

        [TestMethod]
        [TestCategory("unit")]
        public void BookControllerGetBookById_ShouldReturnOkObjectWhenGivenValidId()
        {
            //Arrange
            var bookController = new BookController(new BookStoreMockRepository());

            int bookId = 1;

            //Act
            var action = bookController.GetBookById(bookId);

            //Assert
            var result = action as OkObjectResult;
            result.StatusCode.Should().Be(200);
        }

        [TestMethod]
        [TestCategory("unit")]
        public void BookControllerSearchBooksByAuthorId_ShouldReturnOkObjectWhenGivenValidAuthorId()
        {
            //Arrange
            var bookController = new BookController(new BookStoreMockRepository());

            int authorId = 1;

            //Act
            var action = bookController.SearchBooksByAuthorId(authorId);

            //Assert
            var result = action as OkObjectResult;
            result.StatusCode.Should().Be(200);
        }

        [TestMethod]
        [TestCategory("unit")]
        public void BookControllerGetAllBooks_ShouldReturnOkObject()
        {
            //Arrange
            var bookController = new BookController(new BookStoreMockRepository());

            //Act
            var action = bookController.GetAllBooks();

            //Assert
            var result = action as OkObjectResult;
            result.StatusCode.Should().Be(200);
        }

        [TestMethod]
        [TestCategory("unit")]
        public void BookControllerAddNewBook_ShouldReturnCreatedObject()
        {
            //Arrange
            var bookController = new BookController(new BookStoreMockRepository());

            var book = new Book() { Title = "Troy", Price = 60 };

            //Act
            var action = bookController.AddNewBook(book);

            //Assert
            var result = action as OkObjectResult;
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType(typeof(Book));
        }
    }
}