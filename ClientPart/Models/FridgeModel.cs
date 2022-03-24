using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Models
{
    public class FridgeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }

        // public ICollection<Fridge> Fridges { get; set; }
    }
}
