using DataAccessLayer.Entities;
using SharedDtos;


namespace BusinessLogicLayer.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        IEnumerable<Book> SearchByTitle(string title);
        Book CreateBook(BookDto bookDto);
        Book UpdateBook(int id, BookDto book);
        bool DeleteBook(int id);
    }
}
