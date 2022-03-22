﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ViewModels
{
    public class UpdatedFridgeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public Guid ModelId { get; set; }

        public List<AddProductInFridgeViewModel> FridgeProducts { get; set; }
        public Controller Controller { get; set; }
    }
}
