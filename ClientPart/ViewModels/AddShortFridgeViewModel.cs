using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class AddShortFridgeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }
    }
}
