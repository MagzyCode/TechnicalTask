using ServerPart.Contracts.DbContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models
{
    [Table("Products")]
    public class Products : IDbModel
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
