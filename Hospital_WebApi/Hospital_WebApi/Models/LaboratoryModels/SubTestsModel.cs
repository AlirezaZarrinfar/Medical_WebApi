using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApi.Models.HospitalModels
{
    public class SubTestsModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long TestGroupId { get; set; }
    }
}
