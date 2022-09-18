﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string NIC { get; set; }
        public string EmailAddress { get; set; }

        public int MobileNo { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        //Navigation

        public Reservations Reservations { get; set; }

    }
}
