using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtCollective.DataProcessor.ImportDTOs
{
    [XmlType("Feedback")]
    public class ImportFeedbackDto
    {
        [Required]
        [XmlAttribute("GivenOn")]
        public string GivenOn { get; set; } = null!;

        [Required]
        [XmlElement("Content")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Content { get; set; } = null!;

        [Required]
        [XmlElement("Status")]
        public string Status { get; set; } = null!;

        [Required]
        [XmlElement("GroupId")]
        public string GroupId { get; set; } = null!;

        [Required]
        [XmlElement("ArtistId")]
        public string ArtistId { get; set; } = null!;
    }
}
