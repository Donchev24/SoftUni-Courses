using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; } = null!;

        public virtual ICollection<PlayerStatistic> Players { get; set; }
         = new HashSet<PlayerStatistic>();

        public virtual ICollection<Bet> Bets { get; set; }
        = new HashSet<Bet>();
    }
}
