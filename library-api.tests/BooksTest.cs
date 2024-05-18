using Xunit;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Controllers;
using LibraryApi.Services;
using LibraryApi.Test.Data;


namespace LibraryApi.tests;
public class BooksTest : IDisposable
{
    private BooksService _service;
    private BooksController _controller;

    private LibraryDbContextTest _context;

    public BooksTest()
    {
        _context = new LibraryDbContextTest();
        _service = new BooksService(_context);
        _controller = new BooksController(_service);

    }

    public void Dispose()
    {
        _service = null;
        _controller = null;

    }

    [Fact]
    public void Test_GetBooks_returnsBooks()
    {
        var result = _controller.GetBooks();
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);
        /* var okResult = result as OkResult;
        Assert.NotNull(okResult);
        Assert.IsType<List<Book>>(okResult.Value); */
    }

    public void Test_addBooks()
    {
        var book = new Book
        {
            Title = "Book1",
        };
        _controller.CreateBook(book);
        var result = _controller.GetBooks();
        Assert.NotNull(result);
        Assert.IsType<OkResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.IsType<List<Book>>(okResult.Value);
        var books = okResult.Value as List<Book>;
        Assert.NotNull(books);
        Assert.Equal(1, books.Count);
        Assert.Equal(book.Id, books[0].Id);
        Assert.Equal(book.Title, books[0].Title);
    }
}