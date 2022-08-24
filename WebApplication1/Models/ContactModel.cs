using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string NIC { get; set; }

        [Required]
        //[EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public int MobileNo { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }
    }
}
