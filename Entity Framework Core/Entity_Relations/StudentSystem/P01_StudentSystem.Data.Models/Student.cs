using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_StudentSystem.Data.Common.Student;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(StudentNameMaxLength)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "varchar(10)")]
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }


        public virtual ICollection<StudentCourse> Courses { get; set; }
          = new HashSet<StudentCourse>();

        public virtual ICollection<Homework> Homeworks { get; set; } 
          = new HashSet<Homework>();
    }
}
