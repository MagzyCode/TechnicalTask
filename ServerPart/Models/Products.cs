using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPart.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? DefaultQuantity { get; set; }

        public byte[] Image { get; set; } 

        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
