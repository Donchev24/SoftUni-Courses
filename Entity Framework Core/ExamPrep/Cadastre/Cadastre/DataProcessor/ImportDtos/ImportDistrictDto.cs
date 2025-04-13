using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [Required]
        [XmlAttribute("Region")]
        public string Region { get; set; } = null!;


        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; } = null!;


        [Required]
        [XmlElement("PostalCode")]
        [MinLength(8)]
        [MaxLength(8)]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [XmlArray("Properties")]
        public ImportDistrictPropertyDto[] Properties { get; set; } = null!;

    }
}
