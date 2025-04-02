using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportSaleDto
    {
        [Required]
        public string CarId { get; set; } = null!;

        [Required]
        public string CustomerId { get; set; } = null!;

        [Required]
        public string Discount { get; set; } = null!;
    }
}
