using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _business;
        public BookController(IBookBusiness business) 
        {
            _business = business;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var books = _business.FindAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var book = _business.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book) 
        {
            if (book == null)
                return BadRequest();

            _business.Create(book);

            return Ok(book);
        }

        [HttpPut("")]
        public IActionResult Put([FromBody] Book book) 
        {
            if (book == null)
                return BadRequest();

            _business.Update(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) 
        {
            _business.Delete(id);

            return NoContent();
        }
    }
}
