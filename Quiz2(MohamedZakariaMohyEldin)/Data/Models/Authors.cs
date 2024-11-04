using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Quiz2_MohamedZakariaMohyEldin_.Data.Models
{
    public class Authors
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required]
        public int? PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Must be valid email")]
        public string? Email { get; set; }
        [JsonIgnore]
        public IList<BooksAuthors>? BooksAuthors { get; set; }
    }
}
