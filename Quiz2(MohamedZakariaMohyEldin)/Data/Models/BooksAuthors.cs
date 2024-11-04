using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz2_MohamedZakariaMohyEldin_.Data.Models
{
    public class BooksAuthors
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? books { get; set; }
        public int AuthorsId { get; set; }
        [ForeignKey("AuthorsId")]
        public Authors? authors { get; set; }
    }
}
