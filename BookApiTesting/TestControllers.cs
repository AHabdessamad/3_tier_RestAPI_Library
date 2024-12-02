using BookApi.Controllers;
using BusinessLogicLayer.Results;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedDtos;

namespace BookApiTesting
{
    public class TestControllers
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BookController _controller;

        public TestControllers()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BookController(_mockBookService.Object);
        }
        // Using Priciple  of Triple A (Arrange/ Act/Assert)

        [Fact]
        public void GetAllBooks_ReturnsBooksFromList()
        {
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2" }
            };

            _mockBookService.Setup(service => service.GetAllBooks()).Returns(books);

            //Act
            var res = _controller.GetAllBooks();

            // Assert
            var response = Assert.IsType<ActionResult<Response<IEnumerable<Book>>>>(res);
            var successResponse = Assert.IsType<Response<IEnumerable<Book>>>(response.Value);
            Assert.True(successResponse.success);
            Assert.NotEmpty((System.Collections.IEnumerable)successResponse.Data);
        }

        [Fact]
        public void GetBookById_ReturnsBookFromList()
        {

            var book = new Book { Id = 1, Title = "Effective Coding", Author = "Ahmed" };
            _mockBookService.Setup(service => service.GetBookById(1)).Returns(book);

            var res = _controller.GetBookById(1);

            var response = Assert.IsType<ActionResult<Response<Book>>>(res);
            var successResponse = Assert.IsType<Response<Book>>(response.Value);

            Assert.True(successResponse.success);
            Assert.Equal(200, successResponse.StatusCode);

            Assert.NotNull(successResponse.Data);
        }

        [Fact]
        public void CreateBook_ReturnsBookCreated()
        {
            var bookDto = new BookDto(Title: "Effective Code", Author: "Ahmed", PublishDate: new DateTime(2020, 5, 1), ISBN: "292738337",NbrOfCopy: 3);
            var createdBook = new Book { Title= "Effective Code", Author= "Ahmed", PublishDate= new DateTime(2020, 5, 1), ISBN= "292738337",NbrOfCopy= 3};

            _mockBookService.Setup(service => service.CreateBook(bookDto)).Returns(createdBook);
            var result = _controller.CreateBook(bookDto);

            var response = Assert.IsType<ActionResult<Response<Book>>>(result);
            var successResponse = Assert.IsType<Response<Book>>(response.Value);
            Assert.True(successResponse.success);
            Assert.Equal(201, successResponse.StatusCode);
        }

        [Fact]
        public void DeleteBook_IsdeleteBookSuccessed()
        {

            _mockBookService.Setup(service => service.DeleteBook(1)).Returns(true);

            var res = _controller.DeleteBook(1);

            var okResult = Assert.IsType<OkObjectResult>(res.Result);
            var response = Assert.IsType<Response<Book>>(okResult.Value);
            Assert.True(response.success);
            Assert.Equal(200, response.StatusCode);
            Assert.Equal("Book deleted successfully", response.Message);
        }


    }
}