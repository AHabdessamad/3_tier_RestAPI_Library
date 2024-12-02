using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepository = bookRepo;
        }

        public Book CreateBook(BookDto bookDto)
        {
            if (bookDto == null) return null;
            return  _bookRepository.CreateBook(bookDto);

        }

        public bool DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public Book UpdateBook(int id, BookDto bookDto)
        {
            return _bookRepository.UpdateBook(id, bookDto);
            
        }

        public IEnumerable<Book> SearchByTitle(string title)
        {
            return _bookRepository.SearchByTitle(title);
        }
    }

}
