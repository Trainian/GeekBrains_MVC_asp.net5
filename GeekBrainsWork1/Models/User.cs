﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeekBrainsWork1.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }
    }
}