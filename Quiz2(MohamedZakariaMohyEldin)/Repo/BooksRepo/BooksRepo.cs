using Quiz2_MohamedZakariaMohyEldin_.Data;
using Quiz2_MohamedZakariaMohyEldin_.Data.Models;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;

namespace Quiz2_MohamedZakariaMohyEldin_.Repo.BooksRepo
{
    public class BooksRepo : IBooksRepo
    {
        private readonly AppDbContext _db;
        public BooksRepo(AppDbContext db)
        {
            _db = db;
        }
        public void AddBooks(BooksDto authorsDto)
        {
            var obj = new Book
            {
                Title = authorsDto.Title,
                PublishedYear = authorsDto.PublishedYear,
            };
            _db.Books.Add(obj);
            _db.SaveChanges();
        }

        public void DeleteBooks(int id)
        {
            var check = _db.Books.FirstOrDefault(x => x.Id == id);
            if (check != null)
            {
                _db.Books.Remove(check);
                _db.SaveChanges();
            }
            return;
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBooksById(int id)
        {
            var check = _db.Books.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                return null;
            }
            return check;
        }

        public void UpdateBooks(BooksDto authorsDto, int id)
        {
            var check = _db.Books.FirstOrDefault(x => x.Id == id);
            if (check == null)
            {
                return;
            }
            check.Title = authorsDto.Title;
            check.PublishedYear = authorsDto.PublishedYear;
            _db.Books.Update(check);
            _db.SaveChanges();
        }
    }
}
