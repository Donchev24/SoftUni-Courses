﻿using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>(); 
    }
}