using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models.DTOs
{
    public class UpdateProductsDto
    {
        /// <summary>
        /// Represents current or updated name of product.
        /// </summary>
        /// <example>
        /// Cheese
        /// </example>
        [Required(ErrorMessage = "Name of updated product can't be null")]
        [MaxLength(70, ErrorMessage = "Maximum length for the Name is 70 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Represents current or updated default quantity of product.
        /// </summary>
        /// <example>
        /// 2
        /// </example>
        [Required(ErrorMessage = "Default number of product shouldn't be null")]
        public int? DefaultQuantity { get; set; }

        public byte[] Image { get; set; }
    }
}
