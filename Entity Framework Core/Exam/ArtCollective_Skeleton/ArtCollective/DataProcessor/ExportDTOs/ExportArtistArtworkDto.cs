using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtCollective.DataProcessor.ExportDTOs
{
    [XmlType("Artwork")]
    public class ExportArtistArtworkDto
    {
        [XmlElement("Title")]
        public string Title { get; set; } = null!;

        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; } = null!;
    }
}
