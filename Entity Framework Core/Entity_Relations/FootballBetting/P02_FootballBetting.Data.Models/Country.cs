using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidationConstants.Country;
namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string CountryName { get; set; } = null!;

        public virtual ICollection<Town> Towns { get; set; } 
           = new HashSet<Town>();
    }
}
