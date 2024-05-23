using System.Collections.Generic;
using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class BooksService
    {
        private LibraryDbContext _context;

        public BooksService()
        {
            _context = new LibraryDbContext();
        }

        /// <summary>
        /// Return all books in database
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="year"></param>
        /// <returns>List of books</returns>
        public List<Book> GetAllBooks(string? title, string? author, int? year)
        {
            //TODO Poista try catch sit kun kontrolleris on error handling
            try
            {
                var query = _context.Books.Include(b => b.Author).AsQueryable();
                if (title != null) query = query.Where(b => b.Title == title);
                if (author != null) query = query.Where(b => b.Author.Name == author);
                if (year != null) query = query.Where(b => b.Year == year);
                //TODO: add async to all services
                return query.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The book with the specified ID, or null if not found.</returns>
        public Book GetBookById(int id)
        {
            return _context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="newBook">Book object to be added</param>
        /// <returns>Id of the created book</returns>
        public int AddBook(Book newBook)
        {
            var existingBook = _context.Books.FirstOrDefault(existing => existing.Title == newBook.Title && existing.Year == newBook.Year && existing.Author.Name == newBook.Author.Name);
            if (existingBook != null)
            {
                throw new Exception("Book already exists");
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
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook.Id;
        }

        /// <summary>
        /// Deletes a book in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success, false if failed</returns>
        public bool DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;
            _context.Books.Remove(book);
            return _context.SaveChanges() > 0;
        }
    }
}