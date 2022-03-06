using System;

namespace ServerPart.Models.DTOs
{
    public class CreationFridgeProductDto
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
