using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportPartDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Price { get; set; } = null!;

        [Required]
        public string Quantity { get; set; } = null!;

        [Required]
        public string SupplierId { get; set; } = null!;
    }
}
