using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Quiz2_MohamedZakariaMohyEldin_.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Published Year is required")]
        public DateTime? PublishedYear { get; set; }
        [JsonIgnore]
        public IList<BooksAuthors>? BooksAuthors { get; set; }
        [JsonIgnore]
        public IList<BooksGenre>? BooksGenre { get; set; }
    }
}
