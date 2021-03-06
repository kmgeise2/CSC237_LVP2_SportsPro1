using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_LVP2_SportsPro1.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string CountryID { get; set; }
        public Country Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string fullName => FirstName + " " + LastName; //readonly property
    }
}
