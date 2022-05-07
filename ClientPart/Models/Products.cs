using System;

namespace ClientPart.Models
{
    public class Products
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? DefaultQuantity { get; set; }

        public byte[] Image { get; set; }
    }
}
