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

        public List<Book> GetAllBooks(string? title, string? author, int? year)
        {
            try
            {
                var query = _context.Books.Include(b => b.Author).AsQueryable();
                if (title != null) query = query.Where(b => b.Title == title);
                if (author != null) query = query.Where(b => b.Author.Name == author);
                if (year != null) query = query.Where(b => b.Year == year);
                return query.ToList();
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

        public int AddBook(Book newBook)
        {
            var existingBook = _context.Books.FirstOrDefault(existing => existing.Title == newBook.Title && existing.Year == newBook.Year && existing.Author.Name == newBook.Author.Name);
            if (existingBook != null)
            {
                // Return a negative value to indicate an error
                // TODO: Is there a better way to do this?
                return -1;
            }

            var author = _context.Authors.FirstOrDefault(a => a.Name == newBook.Author.Name);
            if (author == null)
            {
                _context.Authors.Add(newBook.Author);
            }
            else
            {
                newBook.Author = author;
                newBook.AuthorId = author.Id;
            }

            try
            {
                _context.Books.Add(newBook);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return newBook.Id;
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