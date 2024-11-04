using Quiz2_MohamedZakariaMohyEldin_.Data.Models;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;

namespace Quiz2_MohamedZakariaMohyEldin_.Repo.BooksRepo
{
    public interface IBooksRepo
    {
        List<Book> GetAllBooks();
        Book GetBooksById(int id);
        void AddBooks(BooksDto authorsDto);
        void UpdateBooks(BooksDto authorsDto, int id);
        void DeleteBooks(int id);
    }
}
