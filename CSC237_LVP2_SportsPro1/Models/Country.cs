using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_LVP2_SportsPro1.Models
{
    public class Country
    {
        [Required]
        public string CountryID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
