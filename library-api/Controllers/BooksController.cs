using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        public BooksController()
        {
            //_service = service;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok();
        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok();
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
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