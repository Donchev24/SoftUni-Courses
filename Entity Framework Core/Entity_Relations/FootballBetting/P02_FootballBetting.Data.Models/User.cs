using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using static P02_FootballBetting.Common.EntityValidationConstants.User;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(UserPasswordMaxLength)]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public decimal Balance { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; } = null!;

        public virtual ICollection<Bet> Bets { get; set; }
          = new HashSet<Bet>();

    }
}
