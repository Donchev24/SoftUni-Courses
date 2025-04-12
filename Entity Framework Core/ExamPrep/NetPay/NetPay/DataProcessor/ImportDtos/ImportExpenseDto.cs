using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ImportExpenseDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.01", "100000")]
        public decimal Amount { get; set; }

        [Required]
        public string DueDate { get; set; } = null!;

        [Required]
        public string PaymentStatus { get; set; } = null!;

        [Required]
        public int HouseholdId { get; set; }

        [Required]
        public int ServiceId { get; set; }
    }
}
