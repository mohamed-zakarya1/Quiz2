using Quiz2_MohamedZakariaMohyEldin_.Data.Models;
using Quiz2_MohamedZakariaMohyEldin_.Dtos;

namespace Quiz2_MohamedZakariaMohyEldin_.Repo.AuthorsRepo
{
    public interface IAuthorRepo
    {
        List<Authors> GetAllAuthors();
        Authors GetAuthorById (int id);
        void AddAuthors(AuthorsDto authorsDto);
        void UpdateAuthors(AuthorsDto authorsDto, int id);
        void DeleteAuthors(int id);
        Authors ValidateUsers(string name, string email);
    }
}
