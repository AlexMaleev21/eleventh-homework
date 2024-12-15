using System.ComponentModel.DataAnnotations;
namespace Dz_11.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Note Title")]
        public string? Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Tag { get; set; }
    }
}
