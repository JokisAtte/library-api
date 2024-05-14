using Xunit;
using LibraryApi.Controllers;
using LibraryApi.Services;


namespace LibraryApi.tests;
public class BooksTest : IDisposable
{
    private readonly BooksService _service;
    private readonly BooksController _controller;

    public BooksTest()
    {
        _service = new BooksService();
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

    }
}