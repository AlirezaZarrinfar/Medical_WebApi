using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApi.Models.Hospital
{
    public class Reception
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public virtual Doctor Doctor { get; set; }
        [Required]
        public long DoctorId { get; set; }
        [Required]
        public virtual Patient Patient { get; set; }
        [Required]
        public long PatientId { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public double TotalPriceDiscounted { get; set; }
        [Required]
        public bool IsDiscounted { get; set; }

    }
}
