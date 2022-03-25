using System;

namespace ClientPart.ViewModels
{
    public class FridgeProductsViewModel
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
