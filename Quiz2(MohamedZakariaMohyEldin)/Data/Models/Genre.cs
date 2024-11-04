using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Quiz2_MohamedZakariaMohyEldin_.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [JsonIgnore]
        public IList<BooksGenre>? BooksGenre { get; set; }
    }
}
