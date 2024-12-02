using BusinessLogicLayer.Results;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedDtos;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<Response<IEnumerable<Book>>> GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();

                if (books == null || !books.Any())
                {
                    return Response<IEnumerable<Book>>.Failure(404, "No books found");
                }

                return Response<IEnumerable<Book>>.Success(200,"Books retrieved successfully", books);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<Book>>.Failure(500, $"Server error {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Book>> GetBookById(int id)
        {
            try
            {

                var book = _bookService.GetBookById(id);

                if (book == null)
                {
                    return Response<Book>.Failure(404, $"Book with id {id} Not Found");
                }

                return Response<Book>.Success( 200 ,"Book fetched successfully", book);
            }
            catch (Exception ex)
            {
                return Response<Book>.Failure(500, $" Server error: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public ActionResult<Response<Book>> SearchByTitle(string title)
        {
            try
            {
                if (string.IsNullOrEmpty(title))
                {
                    return Response<Book>.Failure(400, "Invalid Title");
                }

                var MatchedBook = _bookService.SearchByTitle(title);

                if (MatchedBook == null)
                {
                    return Response<Book>.Failure(404, "Book  Not Found");
                }

                return Response<Book>.Success(201, "Book created successfully", MatchedBook);

            }
            catch (Exception ex)
            {
                return Response<Book>.Failure(500, $"Server error: {ex.Message}");
            }

        }

        [HttpPost]
        public ActionResult<Response<Book>> CreateBook([FromBody] BookDto bookDto)
        {
            try
            {
                if (bookDto == null)
                {
                    return Response<Book>.Failure(400, "Invalid book data");
                }

                var createdBook = _bookService.CreateBook(bookDto);

                if (createdBook == null)
                {
                    return Response<Book>.Failure(400, "Failed to create book");
                }

                return Response<Book>.Success(201, "Book created successfully", createdBook);
                
            }
            catch (Exception ex)
            {
                return Response<Book>.Failure(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Book>> UpdateBook(int id, [FromBody] BookDto bookDto)
        {
            try
            {
                if (bookDto == null)
                {
                    return Response<Book>.Failure(400, "Invalid book data");
                }

                var updatedBook = _bookService.UpdateBook(id, bookDto);

                if (updatedBook == null)
                {
                    return Response<Book>.Failure(401, $"Book with id {id} not found");
                }

                return Response<Book>.Success(200,"Book updated successfully", updatedBook);
            }
            catch (Exception ex)
            {
                return Response<Book>.Failure(500, $"Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<Book>> DeleteBook(int id)
        {
            try
            {
                var deletionResult = _bookService.DeleteBook(id);

                if (!deletionResult)
                {
                    return Response<Book>.Failure(404, $"Book with id {id} not found");
                }

                return Response<Book>.Success(200, "Book deleted successfully", deletionResult);
            }
            catch (Exception ex)
            {
                return Response<Book>.Failure(500, $"Server error: {ex.Message}");
            }
        }
    }
}