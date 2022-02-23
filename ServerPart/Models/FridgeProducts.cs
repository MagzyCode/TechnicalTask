using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models
{
    [Table("FridgeProducts")]
    public class FridgeProducts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Fridge))]
        public int FridgeId { get; set; }

        [Required]
        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
