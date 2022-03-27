using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models.DTOs
{
    public class UpdateFridgeDto
    {
        /// <summary>
        /// Represents current or updated name of fridge.
        /// </summary>
        /// <example>
        /// Samsung A58-J7
        /// </example>
        [Required(ErrorMessage = "Name of updated fridge can't be null")]
        [MaxLength(70, ErrorMessage = "Maximum length for the fridge name is 70 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Represents current or updated owner name of fridge.
        /// </summary>
        /// <example>
        /// Samsung
        /// </example>
        [Required(ErrorMessage = "Owner name of updated fridge can't be null")]
        [MaxLength(70, ErrorMessage = "Maximum length for the fridge owner name is 70 characters")]
        public string OwnerName { get; set; }

        /// <summary>
        /// Represents current or updated model of fridge.
        /// </summary>
        /// <example>
        /// fceff18a-43f6-4286-ab11-f6d0ad6d3200
        /// </example>
        [Required]
        public Guid ModelId { get; set; }

        /// <summary>
        /// Represents fridge products.
        /// </summary>
        /// <example>
        /// ["e6106a3d-e706-4f12-8878-f8c1af6cd007", "fceff18a-43f6-4286-ab11-f6d0ad6d3201"]
        /// </example>
        public ICollection<Guid> FridgeProducts { get; set; }
    }
}
