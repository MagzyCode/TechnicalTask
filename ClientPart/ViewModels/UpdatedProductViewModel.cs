using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClientPart.ViewModels
{
    public class UpdatedProductViewModel
    {
        // Used in POST ClientPart.Controllers.ProductsControllers.UpdateProduct(...)
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of updated product can't be null")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Lenght of fridge owner name is should be more than 2 characters and less then 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Default number of product shouldn't be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of products in one fridge can't be less than 1 and more than 2147483647")]
        public int? DefaultQuantity { get; set; }

        public IFormFile ImageData { get; set; }

        public byte[] Image { get; set; }
    }
}
