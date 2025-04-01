using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        //    "make": "Opel",
        //"model": "Astra",
        //"traveledDistance": 516628215,
        //"partsId": [
        //  39,
        //  62,
        //  72
        //]

        [Required]
        public string Make { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public string TraveledDistance { get; set; } = null!;

        [Required]
        public string[] PartsId { get; set; } = null!;
    }
}
