﻿using System;

namespace ServerPart.Models.DTOs
{
    public class CreationFridgeDto
    {
        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }
    }
}
