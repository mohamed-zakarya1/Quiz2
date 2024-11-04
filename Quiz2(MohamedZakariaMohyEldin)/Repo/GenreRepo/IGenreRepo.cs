using Quiz2_MohamedZakariaMohyEldin_.Data.Models;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;

namespace Quiz2_MohamedZakariaMohyEldin_.Repo.GenreRepo
{
    public interface IGenreRepo
    {
        List<Genre> GetAllBooks();
        Genre GetBooksById(int id);
        void AddBooks(GenreDto authorsDto);
        void UpdateBooks(GenreDto authorsDto, int id);
        void DeleteBooks(int id);
    }
}
