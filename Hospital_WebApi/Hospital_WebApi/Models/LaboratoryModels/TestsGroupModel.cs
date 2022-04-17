using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApi.Models.HospitalModels
{
    public class TestsGroupModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<SubTestsModel> subTests { get; set; }
        public long ReceptionId { get; set; }
        public double TotalPrice { get; set; }
    }
}
