﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLotnisko.DbClasses
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(250)]
        public string Password { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime SignUpDate { get; set; }
        [StringLength(100)]
        public string AdressStreet { get; set; }
        [StringLength(100)]
        public string AdressNumber { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [StringLength(100)]
        public string AccountType { get; set; }
    }
}
