using System;

namespace ClientPart.ViewModels
{
    public class ProductsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
