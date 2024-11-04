using Quiz2_MohamedZakariaMohyEldin_.Data;
using Quiz2_MohamedZakariaMohyEldin_.Data.Models;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;

namespace Quiz2_MohamedZakariaMohyEldin_.Repo.AuthorsRepo
{
    public class AuthorsRepo : IAuthorRepo
    {
        private readonly AppDbContext _db;
        public AuthorsRepo(AppDbContext db)
        {
            _db = db;
        }
        public void AddAuthors(AuthorsDto authorsDto)
        {
            var obj = new Authors
            {
                Name = authorsDto.Name,
                PhoneNumber = authorsDto.PhoneNumber,
                Email = authorsDto.Email,
            };
            _db.Authors.Add(obj);
            _db.SaveChanges();
        }

        public void DeleteAuthors(int id)
        {
            var check = _db.Authors.FirstOrDefault(x => x.Id == id);
            if (check != null)
            {
                _db.Authors.Remove(check);
                _db.SaveChanges();
            }
            return;
        }

        public List<Authors> GetAllAuthors()
        {
            return _db.Authors.ToList();
        }

        public Authors GetAuthorById(int id)
        {
            var check = _db.Authors.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                return null;
            }
            return check;
        }

        public void UpdateAuthors(AuthorsDto authorsDto, int id)
        {
            var check = _db.Authors.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                return;
            }
            check.Name = authorsDto.Name;
            check.PhoneNumber = authorsDto.PhoneNumber;
            check.Email = authorsDto.Email;
            _db.Authors.Update(check);
            _db.SaveChanges();
        }

        public Authors ValidateUsers(string name, string email)
        {
            var check = _db.Authors.FirstOrDefault(x => x.Name == name && x.Email == email);
            if (check == null)
            {
                return null;
            }
            return check;
        }
    }
}
