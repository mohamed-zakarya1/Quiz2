using Quiz2_MohamedZakariaMohyEldin_.Data;
using Quiz2_MohamedZakariaMohyEldin_.Data.Models;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;

namespace Quiz2_MohamedZakariaMohyEldin_.Repo.GenreRepo
{
    public class GenreRepo : IGenreRepo
    {
        private readonly AppDbContext _db;
        public GenreRepo(AppDbContext db)
        {
            _db = db;
        }
        public void AddBooks(GenreDto authorsDto)
        {
            var obj = new Genre
            {
                Name = authorsDto.Name,
            };
            _db.Genres.Add(obj);
            _db.SaveChanges();
        }

        public void DeleteBooks(int id)
        {
            var check = _db.Genres.FirstOrDefault(x => x.Id == id);
            if (check != null)
            {
                _db.Genres.Remove(check);
                _db.SaveChanges();
            }
            return;
        }

        public List<Genre> GetAllBooks()
        {
            return _db.Genres.ToList();
        }

        public Genre GetBooksById(int id)
        {
            var check = _db.Genres.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                return null;
            }
            return check;
        }

        public void UpdateBooks(GenreDto authorsDto, int id)
        {
            var check = _db.Genres.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                return;
            }
            check.Name = authorsDto.Name;
            _db.Genres.Update(check);
            _db.SaveChanges();
        }
    }
}
