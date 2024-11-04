using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz2_MohamedZakariaMohyEldin_.Data;
using Quiz2_MohamedZakariaMohyEldin_.Data.Models;

namespace Quiz2_MohamedZakariaMohyEldin_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksAuthorsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BooksAuthorsController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult getBooksAuthors()
        {
            return Ok(_db.BooksAuthors.Include(x => x.authors).Include(x => x.books).ToList());
        }
        [HttpPost]
        public IActionResult addBooksAuthors(int authorsId, int booksId)
        {
            var obj = new BooksAuthors
            {
                 AuthorsId = authorsId,
                 BookId = booksId
            };
            _db.BooksAuthors.Add(obj);
            _db.SaveChanges();
            return Created();
        }
    }
}
