using System.ComponentModel.DataAnnotations;
using static P02_FootballBetting.Common.EntityValidationConstants.Game;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public short HomeTeamGoals { get; set; }

        [Required]
        public short AwayTeamGoals { get; set; }

        [Required]
        public decimal HomeTeamBetRate { get; set; }

        [Required]
        public decimal AwayTeamBetRate { get; set; }

        [Required]
        public decimal DrawBetRate { get; set; }

        public DateTime? DateTime { get; set; }

        [MaxLength(GameResultMaxLength)]
        public string? Result { get; set; } 


    }
}
