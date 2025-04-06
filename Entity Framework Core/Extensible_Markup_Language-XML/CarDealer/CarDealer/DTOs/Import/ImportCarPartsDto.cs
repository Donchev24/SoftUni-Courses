﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("partId")]
    public class ImportCarPartsDto
    {
        [Required]
        [XmlAttribute("id")]
        public string Id { get; set; } = null!;
    }
}
