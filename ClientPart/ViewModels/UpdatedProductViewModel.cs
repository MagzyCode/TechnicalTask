using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class UpdatedProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of updated product can't be null")]
        [MaxLength(70, ErrorMessage = "Maximum length for the Name is 70 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Default number of product shouldn't be null")]
        public int? DefaultQuantity { get; set; }

        public byte[] Image { get; set; }
    }
}
