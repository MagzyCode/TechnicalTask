﻿using System;

namespace ClientPart.ViewModels
{
    public class FridgesViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }
    }
}
