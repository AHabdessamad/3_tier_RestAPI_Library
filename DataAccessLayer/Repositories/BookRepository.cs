using DataAccessLayer.Entities;
using SharedDtos;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly List<Book> books = Data.Data.Books;

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public IEnumerable<Book> SearchByTitle(string title)
        {
            var matchedBooks = new List<Book>();
            Console.WriteLine("From Searching");
            foreach (var book in books)
            {
                if (book.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(book);
                    matchedBooks.Add(book);
                }
            }

            return matchedBooks;
        }

        public Book GetBookById(int id)
        {
            return books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book CreateBook(BookDto book)
        {
            var createdBook = new Book
            {
                Id = books.Count() + 1,
                Title = book.Title,
                Author = book.Author,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                NbrOfCopy = book.NbrOfCopy,
            };
            
            books.Add(createdBook);
            return createdBook;
        }

        public Book UpdateBook(int id, BookDto bookDto)
        {
            var foundBook = books.FirstOrDefault(b => b.Id == id);
            if (foundBook == null) return null;

            foundBook.Title = bookDto.Title;
            foundBook.Author = bookDto.Author;
            foundBook.PublishDate = bookDto.PublishDate;
            foundBook.ISBN = bookDto.ISBN;
            foundBook.NbrOfCopy = bookDto.NbrOfCopy;

            return foundBook;
        }

        public bool DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;
            books.Remove(book);
            return true;

        }

        
    }
}
