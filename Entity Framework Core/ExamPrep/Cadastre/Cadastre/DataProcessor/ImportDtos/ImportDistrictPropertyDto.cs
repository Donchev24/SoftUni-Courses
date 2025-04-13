using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class ImportDistrictPropertyDto
    {
        [Required]
        [XmlElement("PropertyIdentifier")]
        [MinLength(16)]
        [MaxLength(20)]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        [XmlElement("Area")]
        [Range(typeof(int), "1", "1000000")]
        public string Area { get; set; } = null!;

        [XmlElement("Details")]
        [MinLength(5)]
        [MaxLength(500)]
        public string? Details { get; set; }

        [Required]
        [XmlElement("Address")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Address { get; set; } = null!;

        [Required]
        [XmlElement("DateOfAcquisition")]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
