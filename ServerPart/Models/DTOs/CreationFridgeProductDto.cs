using System;
using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models.DTOs
{
    public class CreationFridgeProductDto
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
