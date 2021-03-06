using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_LVP2_SportsPro1.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        public int? TechnicianID { get; set; }
        public Technician Technician { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; } = null;
    }
}
