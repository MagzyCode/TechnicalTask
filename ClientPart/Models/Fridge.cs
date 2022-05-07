using System;

namespace ClientPart.Models
{
    public class Fridge
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }
    }
}
