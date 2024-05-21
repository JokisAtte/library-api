using System.Collections.Generic;
using LibraryApi.Data;

namespace LibraryApi.Services
{
    public class BooksService
    {
        private List<Book> _books;
        private LibraryDbContext _context;

        public BooksService()
        {
            _context = new LibraryDbContext();
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return _context.Books.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(int id, Book updatedBook)
        {
            throw new NotImplementedException();

        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

    }
}