using System;

namespace ServerPart.Models.DTOs
{
    public class FridgeModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
    }
}
