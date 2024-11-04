using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz2_MohamedZakariaMohyEldin_.Data.Models;
using Quiz2_MohamedZakariaMohyEldin_.Data;
using Microsoft.EntityFrameworkCore;

namespace Quiz2_MohamedZakariaMohyEldin_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksGenreController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BooksGenreController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult getBooksAuthors()
        {
            return Ok(_db.BooksGenres.Include(x => x.genre).Include(x => x.books).ToList());
        }
        [HttpPost]
        public IActionResult addBooksAuthors(int genreId, int booksId)
        {
            var obj = new BooksGenre
            {
                GenreId = genreId,
                BookId = booksId
            };
            _db.BooksGenres.Add(obj);
            _db.SaveChanges();
            return Created();
        }
    }
}
