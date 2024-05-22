using System.Collections.Generic;
using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;

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
                return _context.Books.Include(b => b.Author).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        public bool AddBook(Book book)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Name == book.Author.Name);
            if (author == null)
            {
                _context.Authors.Add(book.Author);
            }
            else
            {
                book.Author = author;
                book.AuthorId = author.Id;
            }
            _context.Books.Add(book);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;
            _context.Books.Remove(book);
            return _context.SaveChanges() > 0;
        }
    }
}