using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientPart.ViewModels
{
    public class AddFridgeViewModel
    {

        [Required(ErrorMessage = "Fridge name should be required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Lenght of fridge name is should be more than 5 characters and less then 30.")]
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
