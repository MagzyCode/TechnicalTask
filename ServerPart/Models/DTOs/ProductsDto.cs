using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models.DTOs
{
    public class ProductsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        public byte[] Image { get; set; }
    }
}
