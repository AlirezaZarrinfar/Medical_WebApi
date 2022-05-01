using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Models.SubTestModels
{
    public class SubTestsModelPost
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public long TestsGroupId { get; set; }
    }
}
