using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class AddProductInFridgeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public bool IsChecked { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Count of products should be more than zero.")]
        public int Quantity { get; set; }
    }
}
