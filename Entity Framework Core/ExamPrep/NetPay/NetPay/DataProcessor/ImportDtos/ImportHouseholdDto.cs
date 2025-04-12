using NetPay.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class ImportHouseholdDto
    {
        [Required]
        [XmlElement("ContactPerson")]
        [MinLength(5)]
        [MaxLength(50)]
        public string ContactPerson { get; set; } = null!;

        [XmlElement("Email")]
        [MinLength(6)]
        [MaxLength(80)]
        public string? Email { get; set; }

        [Required]
        [XmlAttribute("phone")]
        [MinLength(15)]
        [MaxLength(15)]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        public string PhoneNumber { get; set; } = null!;
    }
}
