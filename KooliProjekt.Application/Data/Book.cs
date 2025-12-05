using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Range(1000, 2100)]
        public int Year { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
