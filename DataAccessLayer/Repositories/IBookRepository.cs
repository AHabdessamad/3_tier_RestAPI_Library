using DataAccessLayer.Entities;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        public Book CreateBook(BookDto book);
        public IEnumerable<Book> GetAllBooks();
        public bool DeleteBook(int id);
        public Book GetBookById(int id);
        public IEnumerable<Book> SearchByTitle(string title);
        public Book UpdateBook(int id, BookDto bookDto);
    }
}
