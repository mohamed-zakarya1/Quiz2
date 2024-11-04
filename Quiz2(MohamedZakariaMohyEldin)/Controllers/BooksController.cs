using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;
using Quiz2_MohamedZakariaMohyEldin_.Repo.BooksRepo;

namespace Quiz2_MohamedZakariaMohyEldin_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepo _repo;
        public BooksController(IBooksRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _repo.GetAllBooks();
            if (books == null)
                return NotFound();
            return Ok(books);
        }
        [HttpGet("ID")]
        public IActionResult GetBookById(int id)
        {
            var check = _repo.GetBooksById(id);
            if (check == null)
                return NotFound();
            return Ok(check);
        }
        [HttpPost]
        public IActionResult addBooks(BooksDto books)
        {
            if (books == null)
                return BadRequest();
            _repo.AddBooks(books);
            return Created();
        }
        [HttpPut]
        public IActionResult updateBooks(int id, BooksDto books)
        {
            _repo.UpdateBooks(books, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult deleteBooks(int id)
        {
            _repo.DeleteBooks(id);
            return Accepted();
        }
    }
}
