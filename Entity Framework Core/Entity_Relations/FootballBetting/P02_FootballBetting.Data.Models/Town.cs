using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidationConstants.Town;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        public string TownName { get; set; } = null!;
    }
}
