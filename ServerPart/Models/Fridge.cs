using ServerPart.Contracts.DbContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models
{
    [Table("Fridges")]
    public class Fridge
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string OwnerName { get; set; }

        [ForeignKey(nameof(FridgeModel))]
        public Guid ModelId { get; set; }

        public FridgeModel FridgeModel { get; set; }

        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
