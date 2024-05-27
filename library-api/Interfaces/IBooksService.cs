public interface IBooksService
{
    Task<List<Book>> GetAllBooks(string? title, string? author, int? year);

    Task<Book> GetBookById(int id);

    Task<int> AddBook(Book newBook);

    Task<bool> DeleteBook(int id);
}