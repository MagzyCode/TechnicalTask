using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class ProductsViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? DefaultQuantity { get; set; }

        public byte[] Image { get; set; }

        // public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
