﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.Models
{
    public class AuthenticationUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
