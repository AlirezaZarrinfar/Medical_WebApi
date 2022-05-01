using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Domain.Entities.Laboratory
{
    public class TestsGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<SubTest> SubTests { get; set; }
        public long ReceptionId { get; set; }
    }
}
