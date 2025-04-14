﻿using ArtCollective.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtCollective.Data.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime GivenOn { get; set; }

        [Required]
        public Status Status { get; set; }


        [Required]
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        [Required]
        public virtual Group Group { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        [Required]
        public virtual Artist Artist { get; set; } = null!;
    }
}
