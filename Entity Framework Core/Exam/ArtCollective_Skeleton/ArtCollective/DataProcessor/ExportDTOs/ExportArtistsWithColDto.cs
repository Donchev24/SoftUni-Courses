using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArtCollective.DataProcessor.ExportDTOs
{
    [XmlType("Artist")]
    public class ExportArtistsWithColDto
    {
        [XmlAttribute("Collaborations")]
        public string Collaborations { get; set; } = null!;

        [XmlElement("Username")]
        public string Username { get; set; } = null!;

        [XmlArray("Artworks")]
        public ExportArtistArtworkDto[] Artworks { get; set; } = null!;


    }
}
