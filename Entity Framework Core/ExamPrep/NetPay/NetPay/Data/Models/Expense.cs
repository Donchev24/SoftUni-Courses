using NetPay.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }



        [Required]
        [ForeignKey(nameof(Household))]
        public int HouseholdId { get; set; }

        [Required]
        public virtual Household Household { get; set; } = null!;



        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        [Required]
        public virtual Service Service { get; set; } = null!;
    }
}
