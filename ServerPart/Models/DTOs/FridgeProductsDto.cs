using System;

namespace ServerPart.Models.DTOs
{
    public class FridgeProductsDto
    {
        public Guid Id { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
