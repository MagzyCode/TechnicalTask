using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPart.Models
{
    [Table("Fridges")]
    public class Fridge
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string OwnerName { get; set; }

        [ForeignKey(nameof(FridgeModel))]
        public Guid ModelId { get; set; }

        public FridgeModel FridgeModel { get; set; }

        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
