using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private BooksService _service;

        // TODO: Lisää tähän globaali errorien catchaus
        // Lisää message erroriin joka lähtee asiakkaalle

        public BooksController(BooksService service)
        {
            _service = service;
        }

        //TODO: Add summary (lyö kolme / merkkiä nii tulee automagic)
        /// <summary>
        /// Get all books
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        //TODO: tutki kontrollerin atribuutteja, millä saa esim swaggeriin mitä se palauttaa
        [HttpGet]
        public IActionResult GetBooks([FromQuery] string? title, [FromQuery] string? author, [FromQuery] int? year)
        {
            //TODO: Add error handling
            //TODO: Format data properly
            return Ok(_service.GetAllBooks(title, author, year));
        }

        //TODO: lisää nää kaikkialle
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBook(int id)
        {
            Book book = _service.GetBookById(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
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

            return Ok(new { id = result });
        }

        [HttpDelete("{id}")]
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