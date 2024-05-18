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
            // TODO: Implement the logic to retrieve all books from the database
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();

        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();

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

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        // Add other properties as needed
    }
}