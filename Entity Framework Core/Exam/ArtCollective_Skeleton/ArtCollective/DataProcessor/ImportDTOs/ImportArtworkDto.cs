using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtCollective.DataProcessor.ImportDTOs
{
    public class ImportArtworkDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [MinLength(10)]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public string CreatedOn { get; set; } = null!;

        [Required]
        public string ArtistId { get; set; } = null!;
    }
}
