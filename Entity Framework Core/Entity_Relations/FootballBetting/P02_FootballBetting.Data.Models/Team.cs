using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidationConstants.Team;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(TeamNameMaxLength)]
        public string TeamName { get; set; } = null!;

        [MaxLength(LogoUrlMaxLength)]
        public string? LogoUrl { get; set; }

        [Required]
        [MaxLength(InitialsMaxLength)]
        public string Initials { get; set; } = null!;

        [Required]
        public decimal Budget { get; set; }
    }
}
