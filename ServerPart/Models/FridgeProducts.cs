using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPart.Models
{
    [Table("FridgeProducts")]
    public class FridgeProducts
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Fridge))]
        public Guid FridgeId { get; set; }

        [Required]
        [ForeignKey(nameof(Products))]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
