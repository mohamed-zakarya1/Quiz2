using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz2_MohamedZakariaMohyEldin_.Data.Models
{
    public class BooksGenre
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? books { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre? genre { get; set; }
    }
}
