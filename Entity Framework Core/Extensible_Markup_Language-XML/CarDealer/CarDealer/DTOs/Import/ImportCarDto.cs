﻿using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [Required]
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [Required]
        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [Required]
        [XmlElement("traveledDistance")]
        public string TraveledDistance { get; set; } = null!;

        [Required]
        [XmlArray("parts")]
        public ImportCarPartsDto[] Parts { get; set; } = null;
    }
}
