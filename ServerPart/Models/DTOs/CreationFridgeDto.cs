using System;

namespace ServerPart.Models.DTOs
{
    public class CreationFridgeDto
    {
        /// <summary>
        /// Represents name for creation fridge.
        /// </summary>
        /// <example>
        /// Samsung AJ28
        /// </example>
        public string Name { get; set; }

        /// <summary>
        /// Represents owner name for creation fridge.
        /// </summary>
        /// <example>
        /// Samsung
        /// </example>
        public string OwnerName { get; set; }

        /// <summary>
        /// Represents model of creation fridge.
        /// </summary>
        /// <example>
        /// fceff18a-43f6-4286-ab11-f6d0ad6d3200
        /// </example>
        public Guid ModelId { get; set; }
    }
}
