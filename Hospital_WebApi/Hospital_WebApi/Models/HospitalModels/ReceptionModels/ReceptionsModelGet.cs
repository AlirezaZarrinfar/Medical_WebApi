using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApi.Models
{
    public class ReceptionsModelGet
    {
        public long Id { get; set; }
        [Required]
        public long DoctorId { get; set; }
        [Required]
        public long PatientId { get; set; }
        public DateTime CreateTime { get; set; }
        public double TotalPrice { get; set; }
        public double TotalPriceDiscounted { get; set; }
        public bool IsDiscounted { get; set; }

    }
}
