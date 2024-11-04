using System.ComponentModel.DataAnnotations;

namespace Quiz2_MohamedZakariaMohyEldin_.Dtos
{
    public class BooksDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Published Year is required")]
        public DateTime? PublishedYear { get; set; }
    }
}
