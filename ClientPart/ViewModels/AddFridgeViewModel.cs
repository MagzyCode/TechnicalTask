using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class AddFridgeViewModel
    {
        // public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }

        public List<AddProductInFridgeViewModel> FridgeProducts { get; set; }
    }
}
