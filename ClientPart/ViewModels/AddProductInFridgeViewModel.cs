using System;
using System.ComponentModel.DataAnnotations;

namespace ClientPart.ViewModels
{
    public class AddProductInFridgeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public bool IsChecked { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Count of products should be more than zero.")]
        public int Quantity { get; set; }
    }
}
