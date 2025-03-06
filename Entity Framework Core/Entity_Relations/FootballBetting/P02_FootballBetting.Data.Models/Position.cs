using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidationConstants.Position;

namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(PositionNameMaxLength)]
        public string PositionName { get; set; } = null!;
    }
}
