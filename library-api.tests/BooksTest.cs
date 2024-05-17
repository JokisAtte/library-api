using Xunit;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Controllers;
using LibraryApi.Services;


namespace LibraryApi.tests;
public class BooksTest : IDisposable
{
    private BooksService _service;
    private BooksController _controller;

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
        var result = _controller.GetBooks();
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.IsType<List<Book>>(okResult.Value);
    }
}