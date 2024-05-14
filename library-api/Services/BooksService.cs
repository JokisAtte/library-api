using System.Collections.Generic;

namespace LibraryApi.Services
{
    public class BooksService
    {
        private List<Book> _books;

        public BooksService()
        {
            _books = new List<Book>();
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void UpdateBook(int id, Book updatedBook)
        {
            Book book = _books.Find(b => b.Id == id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                // Update other properties as needed
            }
        }

        public void DeleteBook(int id)
        {
            Book book = _books.Find(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
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