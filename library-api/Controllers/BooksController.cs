using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private BooksService _service;

        public BooksController(BooksService service)
        {
            _service = service;
        }
        //[FromQuery(Name = "title")] string? title, [FromQuery(Name = "Author")] string? author, [FromQuery(Name = "Year")] int? year
        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks([FromQuery(Name = "title")] string? title, [FromQuery(Name = "Author")] string? author, [FromQuery(Name = "Year")] int? year)
        {
            return Ok(_service.GetAllBooks(title, author, year));
        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            Book book = _service.GetBookById(id);
            return book == null ? NotFound() : Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            Console.WriteLine(book.Title);
            _service.AddBook(book);
            return Ok();
        }

        // PUT: api/Books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // TODO: Implement DeleteBook
            return Ok();
        }
    }
}