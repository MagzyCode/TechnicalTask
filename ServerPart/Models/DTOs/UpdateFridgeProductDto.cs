using System;
using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models.DTOs
{
    public class UpdateFridgeProductDto
    {
        /// <summary>
        /// Represents id of existing fridge.
        /// </summary>
        /// <example>
        /// 7bda868b-9656-4406-8e54-65e626718fb1
        /// </example>
        [Required(ErrorMessage = "Foreign key FridgeId is cannot be null.")]
        public Guid FridgeId { get; set; }

        /// <summary>
        /// Represents id of existing product.
        /// </summary>
        /// <example>
        /// 12e42051-8563-4b4a-9b2a-51b101b14236
        /// </example>
        [Required(ErrorMessage = "Foreign key ProductId is cannot be null.")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Represents updated quantity of product in fridge.
        /// </summary>
        /// <example>
        /// 1
        /// </example>
        [Required(ErrorMessage = "Number of products can't be null.")]
        [Range(1, 50, ErrorMessage = "Number of products in one fridge can't be less than 1 and more than 50.")]
        public int Quantity { get; set; }
    }
}
