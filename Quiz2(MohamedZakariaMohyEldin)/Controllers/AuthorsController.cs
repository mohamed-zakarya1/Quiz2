using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;
using Quiz2_MohamedZakariaMohyEldin_.Repo.AuthorsRepo;
using Quiz2_MohamedZakariaMohyEldin_.Repo.BooksRepo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quiz2_MohamedZakariaMohyEldin_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;
        private readonly IConfiguration _configuration;
        public AuthorsController(IAuthorRepo repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _repo.GetAllAuthors();
            if (books == null)
                return NotFound();
            return Ok(books);
        }
        [Authorize]
        [HttpGet("ID")]
        public IActionResult GetBookById(int id)
        {
            var check = _repo.GetAuthorById(id);
            if (check == null)
                return NotFound();
            return Ok(check);
        }
        [HttpPost]
        public IActionResult addBooks(AuthorsDto books)
        {
            if (books == null)
                return BadRequest();
            _repo.AddAuthors(books);
            return Created();
        }
        [HttpPut]
        public IActionResult updateBooks(int id, AuthorsDto books)
        {
            _repo.UpdateAuthors(books, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult deleteBooks(int id)
        {
            _repo.DeleteAuthors(id);
            return Accepted();
        }
        private string generateJwtTokens(AuthorsDto books)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,value: books.Email),
                new Claim("Id", books.Id.ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("login")]
        public IActionResult login(AuthorsDto books)
        {
            if (books.Name == null || books.Email == null)
            {
                return BadRequest();
            }
            var check = _repo.ValidateUsers(books.Name, books.Email);
            if (check == null)
            {
                return Unauthorized();
            }
            var tokens = generateJwtTokens(books);
            return Ok(tokens);
        }
    }
}
