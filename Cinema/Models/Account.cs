﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Account
    {
        [Key]
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}