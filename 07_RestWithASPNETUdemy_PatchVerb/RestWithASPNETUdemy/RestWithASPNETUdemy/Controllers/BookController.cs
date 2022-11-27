using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Authorize("Bearer")]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(long id)
        {
            var book = _business.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO bookVO) 
        {
            if (bookVO == null)
                return BadRequest();

            _business.Create(bookVO);

            return Ok(bookVO);
        }

        [HttpPut("")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO bookVO) 
        {
            if (bookVO == null)
                return BadRequest();

            _business.Update(bookVO);

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
