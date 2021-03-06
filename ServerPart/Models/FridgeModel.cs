using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerPart.Models
{
    [Table("FridgeModels")]
    public class FridgeModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Year { get; set; }

        public ICollection<Fridge> Fridges { get; set; }
    }
}
