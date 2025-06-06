﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportSupplierDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string isImporter { get; set; } = null!;

    }
}
