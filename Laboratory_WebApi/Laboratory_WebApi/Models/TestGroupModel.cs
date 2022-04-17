using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Models
{
    public class TestGroupModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long ReceptionId { get; set; }
        public double TotalPrice { get; set; }
    }
}
