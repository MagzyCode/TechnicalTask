using ServerPart.Contracts.DbContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models
{
    [Table("FridgeProducts")]
    public class FridgeProducts : IDbModel
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
