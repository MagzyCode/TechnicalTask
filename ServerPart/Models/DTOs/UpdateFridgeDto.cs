using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models.DTOs
{
    public class UpdateFridgeDto
    {
        [Required(ErrorMessage = "Name of updated fridge can't be null")]
        [MaxLength(70, ErrorMessage = "Maximum length for the fridge name is 70 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Owner name of updated fridge can't be null")]
        [MaxLength(70, ErrorMessage = "Maximum length for the fridge owner name is 70 characters")]
        public string OwnerName { get; set; }

        [Required]
        public Guid ModelId { get; set; }

        public ICollection<Guid> FridgeProducts { get; set; }
    }
}
