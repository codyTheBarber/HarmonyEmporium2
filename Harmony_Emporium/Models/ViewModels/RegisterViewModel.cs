﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class RegisterViewModel
    {
       
        public string Email { get; set; }
       [Required]public string Password { get; set; }
      public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
     
    }
}