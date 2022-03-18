using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class AddProductInFridgeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? DefaultQuantity { get; set; }

        public byte[] Image { get; set; }

        public bool IsChecked { get; set; }

        public int Quantity { get; set; }
    }
}
