using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class CreationFridgeProductViewModel
    {
        [Required(ErrorMessage = "Foreign key FridgeId is cannot be null")]
        public Guid FridgeId { get; set; }

        [Required(ErrorMessage = "Foreign key ProductId is cannot be null")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Number of products can't be null")]
        [Range(1, 50, ErrorMessage = "Number of products in one fridge can't be less than 1 and more than 50")]
        public int Quantity { get; set; }
    }
}
