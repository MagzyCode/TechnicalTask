using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models.DTOs
{
    public class CreationFridgeDto
    {
        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }
    }
}
