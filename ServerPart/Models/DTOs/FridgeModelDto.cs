using System;

namespace ServerPart.Models.DTOs
{
    public class FridgeModelDto
    {
        /// <example>
        /// 3fa85f64-5717-4562-b3fc-2c963f66afa6
        /// </example>
        public Guid Id { get; set; }

        /// <example>
        /// Samsung-2
        /// </example>
        public string Name { get; set; }

        /// <example>
        /// 1990
        /// </example>
        public int? Year { get; set; }
    }
}
