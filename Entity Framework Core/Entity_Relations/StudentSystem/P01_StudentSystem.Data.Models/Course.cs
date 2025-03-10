using System.ComponentModel.DataAnnotations;
using static P01_StudentSystem.Data.Common.Course;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(CourseNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }


        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
            = new HashSet<StudentCourse>();

        public virtual ICollection<Homework> Homeworks { get; set; }
            = new HashSet<Homework>();

        public virtual ICollection<Resource> Resources { get; set; } 
            = new HashSet<Resource>();


    }
}
