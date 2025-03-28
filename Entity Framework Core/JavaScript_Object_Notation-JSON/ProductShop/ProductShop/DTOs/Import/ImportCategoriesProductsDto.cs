using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Import
{
    public class ImportCategoriesProductsDto
    {
        [Required]
        public string CategoryId { get; set; } = null!;

        [Required]
        public string ProductId { get; set; } = null!;
    }
}
