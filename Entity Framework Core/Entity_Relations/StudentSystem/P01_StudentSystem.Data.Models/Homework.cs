using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Content { get; set; } = null!;

        [Required]
        public ContentType ContentType { get; set; } = null!;

        [Required]
        public DateTime SubmissionTime { get; set; }


    }
}
