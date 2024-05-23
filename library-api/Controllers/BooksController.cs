using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private BooksService _service;

        public class IdResponse
        {
            public int id { get; set; }
        }

        public BooksController(BooksService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns all books in database as an array
        /// Supports filtering by any combination of book title, author and year
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="year">Release year</param>
        /// <returns>Array of books</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Book[]), StatusCodes.Status200OK)]
        public IActionResult GetBooks([FromQuery] string? title, [FromQuery] string? author, [FromQuery] int? year)
        {
            //TODO: Format data according to the specification or remove author object all together
            try
            {
                return Ok(_service.GetAllBooks(title, author, year));
            }
            catch (Exception e)
            {
                //TODO: tarkista status code
                return new ObjectResult(e.Message) { StatusCode = 400 };
            }
        }

        /// <summary>
        /// Returns a single book by ID
        /// </summary>
        /// <param name="id">Id of the book</param>
        /// <returns>Sinlge book</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBook(int id)
        {
            Book book = _service.GetBookById(id);
            return book == null ? NotFound() : Ok(book);
        }

        /// <summary>
        /// Creates a new book in the database
        /// </summary>
        /// <param name="book">Book object to be added</param>
        /// <returns>ID of the created book</returns>
        [HttpPost]
        [ProducesResponseType(typeof(IdResponse), StatusCodes.Status200OK)]
        public IActionResult CreateBook([FromBody] Book book)
        {
            //TODO Validoi input. Nyt hyväksyy ylimääräisiä kenttiä
            int result;
            try
            {
                //TODO: Add await to all
                result = _service.AddBook(book);
            }
            // TODO: Add more specific exceptions
            catch (Exception e)
            {
                return new ObjectResult(e.Message) { StatusCode = 400 };
            }

            return Ok(new IdResponse { id = result });
        }

        /// <summary>
        /// Updates a book in the database
        /// </summary>
        /// <param name="id"> ID of the book to be deleted </param>
        /// <returns>Status 204 if successful</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _service.DeleteBook(id);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message) { StatusCode = 400 };
            }

            return NoContent();
        }
    }
}