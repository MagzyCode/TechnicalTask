using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Models
{
    public class Fridge
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }

        public FridgeModel FridgeModel { get; set; }

        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
