using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using static P01_StudentSystem.Data.Common.Resource;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(ResourceNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Url { get; set; } = null!;

        public ResourceType ResourceType { get; set; }
    }
}
