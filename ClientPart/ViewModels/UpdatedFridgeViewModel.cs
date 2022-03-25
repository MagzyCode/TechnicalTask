using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class UpdatedFridgeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge name is required field.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Lenght of fridge name is should be more than 5 characters and less then 30.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fridge owner name should be required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Lenght of fridge owner name is should be more than 5 characters and less then 100.")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Fridge model should be required.")]
        public Guid ModelId { get; set; }

        public List<AddProductInFridgeViewModel> FridgeProducts { get; set; }
        public List<FridgeModelViewModel> FridgeModels { get; set; }
    }
}
